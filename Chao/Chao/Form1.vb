Imports Microsoft.VisualBasic.PowerPacks

Public Class Form1
    Dim pos(5, 2) As Double
    Dim pos2(3, 2) As Double
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button3.Enabled = False
    End Sub
    Private Sub DomainUpDown1_SelectedItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim mach As Integer
        If ComboBox1.Text = "開挖機" Then
            PictureBox1.Image = My.Resources.Resource1.小型開挖機_compact_excavator_
            mach = 1
        End If
        If ComboBox1.Text = "拖索開挖機" Then
            PictureBox1.Image = My.Resources.Resource1.小型膠輪式裝料機_compact_loader__wheeled_
            mach = 1
        End If
        If ComboBox1.Text = "抓斗開挖機" Then
            PictureBox1.Image = My.Resources.Resource1.滑移裝料機_skid_steer_loader_
            mach = 1
        End If
        If ComboBox1.Text = "履帶起重機" Then
            PictureBox1.Image = My.Resources.Resource1.履帶式開挖裝料機_crawler_backhoe_loader_
            mach = 1
        End If
        If ComboBox1.Text = "推土機" Then
            PictureBox1.Image = My.Resources.Resource1.履帶式推土機_crawler_dozer_
            mach = 1
        End If
        If ComboBox1.Text = "牽引裝料機" Then
            PictureBox1.Image = My.Resources.Resource1.履帶式裝料機_crawler_loader_
            mach = 1
        End If
        If ComboBox1.Text = "振動式打樁機" Then
            PictureBox1.Image = My.Resources.Resource1.履帶式開挖機_crawler_excavator_
            mach = 2
        End If
        If ComboBox1.Text = "鑽岩機" Then
            PictureBox1.Image = My.Resources.Resource1.膠輪式推土機_wheeled_dozer_
            mach = 2
        End If
        If ComboBox1.Text = "壓路機" Then
            PictureBox1.Image = My.Resources.Resource1.膠輪式開挖裝料機_wheeled_backhoe_loader_
            mach = 2
        End If
        If ComboBox1.Text = "輪胎式壓路機" Then
            PictureBox1.Image = My.Resources.Resource1.膠輪式開挖機_wheeled_excavator_
            mach = 2
        End If
        If ComboBox1.Text = "振動式壓路機" Then
            PictureBox1.Image = My.Resources.Resource1.膠輪式裝料機_wheeled_loader_
            mach = 2
        End If
        If ComboBox1.Text = "混凝土割切機" Then
            PictureBox1.Image = My.Resources.Resource1.壓路機_rollers_
            mach = 2
        End If
        If mach = 1 Then
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            Button2.Enabled = False
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            Button1.Enabled = True
        End If
        If mach = 2 Then
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            Button1.Enabled = False
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            TextBox6.Enabled = True
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox1.Text < 1.5 Then
            TextBox2.Text = "4"
            pos(0, 0) = 4 * 0.7
            pos(0, 1) = 4 * 0.7
            pos(0, 2) = 1.5
            pos(1, 2) = 1.5
            pos(2, 2) = 1.5
            pos(3, 2) = 1.5
            pos(1, 0) = -1 * pos(0, 0)
            pos(1, 1) = pos(0, 1)
            pos(2, 0) = pos(1, 0)
            pos(2, 1) = -1 * pos(1, 2)
            pos(3, 0) = pos(0, 0)
            pos(3, 1) = pos(2, 1)
            pos(4, 0) = 4 * -0.27
            pos(4, 1) = 4 * 0.65
            pos(5, 0) = -1 * pos(4, 0)
            pos(5, 1) = -1 * pos(4, 1)
            pos(4, 2) = pos(5, 2) = 4 * 0.71
            
        End If
        If TextBox1.Text >= 1.5 And TextBox1.Text < 4 Then
            TextBox2.Text = "10"
            pos(0, 0) = 10 * 0.7
            pos(0, 1) = 10 * 0.7
            pos(0, 2) = 1.5
            pos(1, 2) = 1.5
            pos(2, 2) = 1.5
            pos(3, 2) = 1.5
            pos(1, 0) = -1 * pos(0, 0)
            pos(1, 1) = pos(0, 1)
            pos(2, 0) = pos(1, 0)
            pos(2, 1) = -1 * pos(1, 2)
            pos(3, 0) = pos(0, 0)
            pos(3, 1) = pos(2, 1)
            pos(4, 0) = 10 * -0.27
            pos(4, 1) = 10 * 0.65
            pos(5, 0) = -1 * pos(4, 0)
            pos(5, 1) = -1 * pos(4, 1)
            pos(4, 2) = pos(5, 2) = 10 * 0.71
        End If
        If TextBox1.Text >= 4 Then
            TextBox2.Text = "16"
            pos(0, 0) = 16 * 0.7
            pos(0, 1) = 16 * 0.7
            pos(0, 2) = 1.5
            pos(1, 2) = 1.5
            pos(2, 2) = 1.5
            pos(3, 2) = 1.5
            pos(1, 0) = -1 * pos(0, 0)
            pos(1, 1) = pos(0, 1)
            pos(2, 0) = pos(1, 0)
            pos(2, 1) = -1 * pos(1, 2)
            pos(3, 0) = pos(0, 0)
            pos(3, 1) = pos(2, 1)
            pos(4, 0) = 16 * -0.27
            pos(4, 1) = 16 * 0.65
            pos(5, 0) = -1 * pos(4, 0)
            pos(5, 1) = -1 * pos(4, 1)
            pos(4, 2) = pos(5, 2) = 16 * 0.71

        End If
        Button3.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim L1 As Double
        Dim L2 As Double
        Dim L3 As Double
        Dim D0 As Double
        L1 = TextBox3.Text
        L2 = TextBox4.Text
        L3 = TextBox5.Text
        D0 = Math.Sqrt(((L1 / 2) ^ 2) + ((L2 / 2) ^ 2) + (L3 ^ 2))
        TextBox6.Text = 2 * D0
        pos2(0, 0) = 2 * D0 * -0.45
        pos2(0, 1) = 2 * D0 * 0.77
        pos2(0, 2) = 2 * D0 * 0.45
        pos2(1, 0) = 2 * D0 * -0.45
        pos2(1, 1) = 2 * D0 * -0.77
        pos2(1, 2) = 2 * D0 * 0.45
        pos2(2, 0) = 2 * D0 * 0.89
        pos2(2, 1) = 0
        pos2(2, 2) = 2 * D0 * 0.45
        pos2(3, 0) = 0
        pos2(3, 1) = 0
        pos2(3, 2) = 2 * D0

        Button3.Enabled = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form2.Show()
    End Sub
End Class
