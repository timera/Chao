Public Class Main

    Dim timeLeft As Integer
    Private Sub Button_BGcheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_BGcheck.Click
        light_BG.BackColor = Color.SpringGreen

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (timeLeft > 0) Then
            timeLeft = timeLeft - 1
            timeLabel.Text = timeLeft & " s"
        Else
            Timer1.Stop()
            timeLabel.Text = "Time's up!"
            startButton.Enabled = True
        End If
    End Sub

    Private Sub startButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startButton.Click
        startButton.Enabled = False
        stopButton.Enabled = True
        continueButton.Enabled = False

        timeLeft = 30
        timeLabel.Text = "30 s"
        Timer1.Start()
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        light_BG.BackColor = Color.Red
        light_1st.BackColor = Color.Red
        light_2nd.BackColor = Color.Red
        light_3rd.BackColor = Color.Red
        light_Additional.BackColor = Color.Red
        light_RSS.BackColor = Color.Red

        startButton.Enabled = True
        stopButton.Enabled = False
        continueButton.Enabled = False
    End Sub

    Private Sub stopButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stopButton.Click
        startButton.Enabled = True
        stopButton.Enabled = False
        continueButton.Enabled = True
        Timer1.Stop()
    End Sub

    Private Sub continueButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles continueButton.Click
        startButton.Enabled = False
        stopButton.Enabled = True
        continueButton.Enabled = False
        Timer1.Start()
    End Sub
End Class