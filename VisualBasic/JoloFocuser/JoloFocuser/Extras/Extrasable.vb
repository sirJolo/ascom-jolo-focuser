Imports ASCOM.JoloFocuser.Focuser

Interface Extrasable
    Property config() As String                 'serialized module config

    Sub clearPanel(ByRef parent As System.Windows.Forms.GroupBox)
    Sub drawControls(ByRef parent As GroupBox)  'draw controls on the box (using persisted config)
    Sub refreshData()                           'refreshes module data (including re-reading value from Arduino)

    'initializes extrasable with some parameters
    Sub initialize(ByRef parent As GroupBox, ByRef statusLabel As Label, ByRef focuser As JoloFocuser.Focuser, ByRef pin As Byte, ByRef pinName As String, ByRef digitalOnly As Boolean, ByRef saveButton As Button)
End Interface
