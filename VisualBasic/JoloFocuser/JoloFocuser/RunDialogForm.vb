Imports ASCOM.JoloFocuser.Focuser

Public Class RunDialogForm

    Public dialogFocuser As JoloFocuser.Focuser

    Public Property focuser() As JoloFocuser.Focuser
        Get
            Return dialogFocuser
        End Get
        Set(ByVal value As JoloFocuser.Focuser)
            dialogFocuser = value
        End Set
    End Property


    Private Sub RunButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunButton.Click
        focuser.CommandString("RUN:")
    End Sub

    Private Sub StarStopButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StarStopButton.Click, StartScheduleButton.Click



    End Sub
End Class