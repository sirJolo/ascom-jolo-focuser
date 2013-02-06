'tabs=4
' --------------------------------------------------------------------------------
' TODO fill in this information for your driver, then remove this line!
'
' ASCOM Focuser driver for JoloFocuser
'
' Description:	Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam 
'				nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam 
'				erat, sed diam voluptua. At vero eos et accusam et justo duo 
'				dolores et ea rebum. Stet clita kasd gubergren, no sea takimata 
'				sanctus est Lorem ipsum dolor sit amet.
'
' Implements:	ASCOM Focuser interface version: 1.0
' Author:		(Jol) Jolo (drjolo@gmail.com)
' URL:          http://code.google.com/p/ascom-jolo-focuser/
'
' Edit Log:
'
' Date			Who	Vers	Description
' -----------	---	-----	-------------------------------------------------------
' 21-Jan-2013	Jol	0.0.0	Initial edit, from Focuser template
' 22-Jan-2013	Jol	0.0.1	Interface implementation, serial communication commands
' 23-Jan-2013   Jol 0.0.2   Temperature compensation, backslash
' 06-Feb-2013   Jol 0.0.3   Minor updates, ready to testing
' ---------------------------------------------------------------------------------
'
'
' Your driver's ID is ASCOM.JoloFocuser.Focuser
'
' The Guid attribute sets the CLSID for ASCOM.DeviceName.Focuser
' The ClassInterface/None addribute prevents an empty interface called
' _Focuser from being created and used as the [default] interface
'

' This definition is used to select code that's only applicable for one device type
#Const Device = "Focuser"

Imports ASCOM.Utilities
Imports ASCOM.DeviceInterface
<Guid("7a3855b3-8917-48ab-b1f3-7bc29f41f6d6")> _
<ClassInterface(ClassInterfaceType.None)> _
Public Class Focuser
    '	==========
    ' Early-bind interface implemented by this driver
    '
    Implements IFocuserV2
    '
    ' Driver ID and descriptive string that shows in the Chooser
    '
    Private Const DELTA_T As Double = 0.5

    Private Shared driverID As String = "ASCOM.JoloFocuser.Focuser"
    Private Shared driverDescription As String = "Jolo main focuser"
    Private tempCompTimer As System.Timers.Timer
    Private compStartTemp As Double
    Private compStartPos As Integer = -1
    Private compLastTemp As Double
    Private lastDirection As Integer = 0
    Private sensorConnected As Boolean = False
    Private tempCompensation As Boolean = False
    Private ComPort As System.IO.Ports.SerialPort

    '
    ' Constructor - Must be public for COM registration!
    '
    Public Sub New()
        tempCompTimer = New System.Timers.Timer()
        tempCompTimer.Interval = My.Settings.TempCycle * 1000
        tempCompTimer.Enabled = False

        ComPort = New System.IO.Ports.SerialPort

        AddHandler tempCompTimer.Elapsed, AddressOf OnTempCompensation
    End Sub

#Region "ASCOM Registration"

    Private Shared Sub RegUnregASCOM(ByVal bRegister As Boolean)

        Using P As New Profile() With {.DeviceType = "Focuser"}
            If bRegister Then
                P.Register(driverID, driverDescription)
            Else
                P.Unregister(driverID)
            End If
        End Using

    End Sub

    <ComRegisterFunction()> _
    Public Shared Sub RegisterASCOM(ByVal T As Type)

        RegUnregASCOM(True)

    End Sub

    <ComUnregisterFunction()> _
    Public Shared Sub UnregisterASCOM(ByVal T As Type)

        RegUnregASCOM(False)

    End Sub

#End Region
    '
    ' PUBLIC COM INTERFACE IFocuserV2 IMPLEMENTATION
    '

    ''' <summary>
    ''' Displays the Setup Dialog form.
    ''' If the user clicks the OK button to dismiss the form, then
    ''' the new settings are saved, otherwise the old values are reloaded.
    ''' THIS IS THE ONLY PLACE WHERE SHOWING USER INTERFACE IS ALLOWED!
    ''' </summary>
    Public Sub SetupDialog() Implements IFocuserV2.SetupDialog
        ' consider only showing the setup dialog if not connected
        ' or call a different dialog if connected
        If IsConnected Then
            System.Windows.Forms.MessageBox.Show("Already connected, just press OK")
        End If

        Using F As SetupDialogForm = New SetupDialogForm()
            Dim result As System.Windows.Forms.DialogResult = F.ShowDialog()
            If result = DialogResult.OK Then
                My.MySettings.Default.Save()
                Exit Sub
            End If
            My.MySettings.Default.Reload()
        End Using
    End Sub

    Public ReadOnly Property SupportedActions() As ArrayList Implements IFocuserV2.SupportedActions
        Get
            Return New ArrayList()
        End Get
    End Property

    Public Function Action(ByVal ActionName As String, ByVal ActionParameters As String) As String Implements IFocuserV2.Action
        Throw New MethodNotImplementedException("Action")
    End Function

    Public Sub CommandBlind(ByVal Command As String, Optional ByVal Raw As Boolean = False) Implements IFocuserV2.CommandBlind
        CheckConnected("CommandBlind")
        ' Call CommandString and return as soon as it finishes
        Me.CommandString(Command, Raw)
    End Sub

    Public Function CommandBool(ByVal Command As String, Optional ByVal Raw As Boolean = False) As Boolean Implements IFocuserV2.CommandBool
        CheckConnected("CommandBool")
        Dim ret As String = CommandString(Command, Raw)
        Return ret = Command + ":true"
    End Function

    Public Function CommandString(ByVal Command As String, Optional ByVal Raw As Boolean = False) As String Implements IFocuserV2.CommandString
        CheckConnected("CommandString")
        ' it's a good idea to put all the low level communication with the device here,
        ' then all communication calls this function
        ' you need something to ensure that only one command is in progress at a time
        Dim commandToSend As String = Command
        If Not (Raw) Then
            commandToSend = Command + Constants.vbLf
        End If
        ComPort.Write(commandToSend)

        Dim answer As String
        Try
            answer = ComPort.ReadTo(Constants.vbLf)
        Catch ex As System.TimeoutException
            Throw New ASCOM.DriverException("Serial port timeout for command " + Command)
        End Try
        Return answer.Trim(Constants.vbLf)
    End Function

    Public Property Connected() As Boolean Implements IFocuserV2.Connected
        Get
            Return IsConnected
        End Get
        Set(ByVal value As Boolean)
            If (value = IsConnected) Then
                Return
            End If

            If (value) Then
                Connect()
            Else
                Disconnect()
            End If
        End Set
    End Property

    Public ReadOnly Property DriverVersion() As String Implements IFocuserV2.DriverVersion
        Get
            ' Get our own assembly and report its version number
            Return Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString(2)
        End Get
    End Property

    Public ReadOnly Property InterfaceVersion() As Short Implements IFocuserV2.InterfaceVersion
        Get
            Return 2
        End Get
    End Property

    Public ReadOnly Property Description() As String Implements IFocuserV2.Description
        Get
            ' this pattern seems to be needed to allow a public property to return a private field
            Dim d As String = driverDescription
            Return d
        End Get
    End Property

    Public ReadOnly Property DriverInfo() As String Implements IFocuserV2.DriverInfo
        Get
            Throw New PropertyNotImplementedException("DriverInfo", False)
        End Get
    End Property

#Region "private properties and methods"
    ' here are some useful properties and methods that can be used as required
    ' to help with

    ''' <summary>
    ''' Returns true if there is a valid connection to the driver hardware
    ''' </summary>
    Private ReadOnly Property IsConnected() As Boolean
        Get
            Return (Not (ComPort Is Nothing) AndAlso (ComPort.IsOpen))
        End Get
    End Property

    Private Sub Connect()
        ComPort.PortName = My.Settings.CommPort
        ComPort.BaudRate = 9600
        ComPort.ReadTimeout = 2000
        ComPort.Open()

        Dim answer As String = CommandString("#")
        If (answer <> "*") Then
            Throw New ASCOM.NotConnectedException
        End If

        answer = CommandString("S:" + My.Settings.StepperRPM.ToString)
        If (answer <> "S") Then
            Throw New ASCOM.NotConnectedException
        End If

        Try
            sensorConnected = True
            Dim temp As Double = Temperature
        Catch ex As ASCOM.NotConnectedException When (ex.Message = "Temperature sensor disconnected")
            sensorConnected = False
        End Try
    End Sub

    Private Sub Disconnect()
        tempCompTimer.Enabled = False
        ComPort.Close()
    End Sub

    ''' <summary>
    ''' Use this function to throw an exception if we aren't connected to the hardware
    ''' </summary>
    ''' <param name="message"></param>
    Private Sub CheckConnected(ByVal message As String)
        If Not IsConnected Then
            Throw New NotConnectedException(message)
        End If
    End Sub

    ' Temperature compensation routine
    ' Works only when enabled and when focuser is not moving
    Private Sub OnTempCompensation(ByVal source As Object, ByVal e As System.Timers.ElapsedEventArgs)
        TemperatureCompensation()
    End Sub

    Private Sub TemperatureCompensation()
        If (Not IsMoving AndAlso My.Settings.StepsPerC <> 0) Then
            tempCompTimer.Enabled = False
            Try
                Dim temp As Double = Temperature
                If (compStartPos = -1) Then
                    compStartTemp = temp
                    compStartPos = Position
                    compLastTemp = temp
                Else
                    CheckConnected("OnTempCompensation")
                    If (Math.Abs(compLastTemp - temp) > DELTA_T) Then
                        Dim newPos As Integer = compStartPos + (temp - compStartTemp) * My.Settings.StepsPerC
                        MoveInternal(newPos)
                        compLastTemp = temp
                    End If
                End If
                tempCompTimer.Enabled = True
            Catch ex As ASCOM.NotConnectedException When (ex.Message = "Temperature sensor disconnected")
                tempCompTimer.Enabled = False
            End Try
        End If
    End Sub

    ' Move without resetting temperature compensation position
    Private Sub MoveInternal(ByVal Position As Integer)
        Position += BackslashCompensation(Position)
        Dim answer As String = CommandString("M:" + Position.ToString)
        If (answer <> "M") Then
            Throw New ASCOM.DriverException("Wrong device answer: expected M, got " + answer)
        End If
    End Sub


    ' Backslash compensation
    Function BackslashCompensation(ByVal newPos As Integer) As Integer
        Dim backslash As Integer = 0
        If (My.Settings.Backslash > 0) Then
            Dim currentPos As Integer = Position
            Dim moveDirection As Integer = Math.Sign(newPos - currentPos)
            If (moveDirection <> lastDirection) Then
                backslash = My.Settings.Backslash
                lastDirection = moveDirection
            End If
        End If
        Return backslash
    End Function

#End Region

    Public ReadOnly Property Absolute() As Boolean Implements DeviceInterface.IFocuserV2.Absolute
        Get
            Return True
        End Get
    End Property

    Public Sub Dispose() Implements DeviceInterface.IFocuserV2.Dispose
        '
    End Sub

    Public Sub Halt() Implements DeviceInterface.IFocuserV2.Halt
        Dim answer As String = CommandString("H")
        If (answer <> "H") Then
            Throw New ASCOM.DriverException("Wrong device answer: expected H, got " + answer)
        End If
    End Sub

    Public ReadOnly Property IsMoving() As Boolean Implements DeviceInterface.IFocuserV2.IsMoving
        Get
            Return CommandBool("I")
        End Get
    End Property

    Public Property Link() As Boolean Implements DeviceInterface.IFocuserV2.Link
        Get
            Return IsConnected
        End Get
        Set(ByVal value As Boolean)
            Connected = value
        End Set
    End Property

    Public ReadOnly Property MaxIncrement() As Integer Implements DeviceInterface.IFocuserV2.MaxIncrement
        Get
            CheckConnected("MaxIncrement")
            Return My.Settings.MaxIncrement
        End Get
    End Property

    Public ReadOnly Property MaxStep() As Integer Implements DeviceInterface.IFocuserV2.MaxStep
        Get
            CheckConnected("MaxStep")
            Return My.Settings.FocuserMax
        End Get
    End Property

    Public Sub Move(ByVal Position As Integer) Implements DeviceInterface.IFocuserV2.Move
        If (TempComp) Then
            Throw New ASCOM.InvalidOperationException("Temperature compensation enabled during MOVE command")
        End If
        If (Position > My.Settings.FocuserMax) Then
            Throw New ASCOM.InvalidOperationException("MOVE larger than maximum focuser position")
        End If
        MoveInternal(Position)
        compStartPos = -1 ' Reset compensation position
    End Sub

    Public ReadOnly Property Name() As String Implements DeviceInterface.IFocuserV2.Name
        Get
            Return driverDescription
        End Get
    End Property

    Public ReadOnly Property Position() As Integer Implements DeviceInterface.IFocuserV2.Position
        Get
            Dim answer As String = CommandString("P")
            Dim values() As String = Split(answer, ":")
            If (values(0) <> "P") Then
                Throw New ASCOM.DriverException("Wrong device answer: expected P, got " + answer)
            End If
            Return Integer.Parse(values(1))
        End Get
    End Property

    Public ReadOnly Property StepSize() As Double Implements DeviceInterface.IFocuserV2.StepSize
        Get
            CheckConnected("StepSize")
            Return My.Settings.StepSize
        End Get
    End Property

    Public Property TempComp() As Boolean Implements DeviceInterface.IFocuserV2.TempComp
        Get
            Return tempCompTimer.Enabled
        End Get
        Set(ByVal value As Boolean)
            If (value) Then
                TemperatureCompensation()
            Else
                compStartPos = -1
            End If
            tempCompTimer.Enabled = value
        End Set
    End Property

    Public ReadOnly Property TempCompAvailable() As Boolean Implements DeviceInterface.IFocuserV2.TempCompAvailable
        Get
            Return sensorConnected
        End Get
    End Property

    Public ReadOnly Property Temperature() As Double Implements DeviceInterface.IFocuserV2.Temperature
        Get
            Dim answer As String = CommandString("T")
            Dim values() As String = Split(answer, ":")
            If (values(0) <> "T") Then
                Throw New ASCOM.DriverException("Wrong device answer: expected T, got " + answer)
            End If
            If (values(1) = "false") Then
                Throw New ASCOM.NotConnectedException("Temperature sensor disconnected")
            End If
            Return Double.Parse(values(1), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
        End Get
    End Property
End Class

