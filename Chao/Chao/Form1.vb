

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DomainUpDown1_SelectedItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "開挖機" Then
            PictureBox1.Image = My.Resources.Resource1.小型開挖機_compact_excavator_
        End If
        If ComboBox1.Text = "拖索開挖機" Then
            PictureBox1.Image = My.Resources.Resource1.小型膠輪式裝料機_compact_loader__wheeled_
        End If
        If ComboBox1.Text = "抓斗開挖機" Then
            PictureBox1.Image = My.Resources.Resource1.滑移裝料機_skid_steer_loader_
        End If
        If ComboBox1.Text = "履帶起重機" Then
            PictureBox1.Image = My.Resources.Resource1.履帶式開挖裝料機_crawler_backhoe_loader_
        End If
        If ComboBox1.Text = "推土機" Then
            PictureBox1.Image = My.Resources.Resource1.履帶式推土機_crawler_dozer_
        End If
        If ComboBox1.Text = "牽引裝料機" Then
            PictureBox1.Image = My.Resources.Resource1.履帶式裝料機_crawler_loader_
        End If
        If ComboBox1.Text = "振動式打樁機" Then
            PictureBox1.Image = My.Resources.Resource1.履帶式開挖機_crawler_excavator_
        End If
        If ComboBox1.Text = "鑽岩機" Then
            PictureBox1.Image = My.Resources.Resource1.膠輪式推土機_wheeled_dozer_
        End If
        If ComboBox1.Text = "壓路機" Then
            PictureBox1.Image = My.Resources.Resource1.膠輪式開挖裝料機_wheeled_backhoe_loader_
        End If
        If ComboBox1.Text = "輪胎式壓路機" Then
            PictureBox1.Image = My.Resources.Resource1.膠輪式開挖機_wheeled_excavator_
        End If
        If ComboBox1.Text = "振動式壓路機" Then
            PictureBox1.Image = My.Resources.Resource1.膠輪式裝料機_wheeled_loader_
        End If
        If ComboBox1.Text = "混凝土割切機" Then
            PictureBox1.Image = My.Resources.Resource1.壓路機_rollers_
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text < 1.5 Then
            TextBox2.Text = "4"
        End If
        If TextBox1.Text >= 1.5 And TextBox1.Text < 4 Then
            TextBox2.Text = "10"
        End If
        If TextBox1.Text >= 4 Then
            TextBox2.Text = "16"
        End If
    End Sub
End Class
