Public Class Form2

    Dim timeLeft As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PictureBox1.Image = My.Resources.green

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (timeLeft > 0) Then
            timeLeft = timeLeft - 1
            timeLabel.Text = timeLeft & "seconds"
        Else
            Timer1.Stop()
            timeLabel.Text = "Time's up!"
            startButton.Enabled = True
        End If
    End Sub

    Private Sub startButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startButton.Click
        startButton.Enabled = False
        timeLeft = 30
        timeLabel.Text = "30 s"
        Timer1.Start()
    End Sub
End Class