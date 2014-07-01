Public Class ADCSetupForm

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim errors As Boolean = False
        If (A_TextBox.Text = String.Empty) Then
            MessageBox.Show("Please enter coefficient A", "Data error")
            errors = True
        End If
        If (B_TextBox.Text = String.Empty) Then
            MessageBox.Show("Please enter coefficient B", "Data error")
            errors = True
        End If
        Dim a As Double
        If (Not Double.TryParse(A_TextBox.Text, a)) Then
            MessageBox.Show(A_TextBox.Text + " is not a valid number", "Data error")
            errors = True
        End If
        If (Not Double.TryParse(B_TextBox.Text, a)) Then
            MessageBox.Show(B_TextBox.Text + " is not a valid number", "Data error")
            errors = True
        End If
        If (Not errors) Then
            Me.Close()
            My.Settings.Save()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class