Imports Microsoft.VisualBasic.PowerPacks

Public Class Machine_choose
    Dim pos(5, 2) As Double
    Dim pos2(3, 2) As Double
    Private Sub Machine_choose_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setup_finish.Enabled = False

        TextBox_L1.Enabled = False
        TextBox_L2.Enabled = False
        TextBox_L3.Enabled = False
        TextBox_r2.Enabled = False
        Button_L1_L2_L3_check.Enabled = False
        TextBox_L.Enabled = False
        TextBox_r1.Enabled = False
        Button_L_check.Enabled = False
    End Sub
    Private Sub DomainUpDown1_SelectedItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox_machine_list_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox_machine_list.SelectedIndexChanged
        Dim mach As Integer
        If ComboBox_machine_list.Text = "開挖機" Then
            Picture_machine.Image = My.Resources.Resource1.小型開挖機_compact_excavator_
            mach = 1
        End If
        If ComboBox_machine_list.Text = "拖索開挖機" Then
            Picture_machine.Image = My.Resources.Resource1.小型膠輪式裝料機_compact_loader__wheeled_
            mach = 1
        End If
        If ComboBox_machine_list.Text = "抓斗開挖機" Then
            Picture_machine.Image = My.Resources.Resource1.滑移裝料機_skid_steer_loader_
            mach = 1
        End If
        If ComboBox_machine_list.Text = "履帶起重機" Then
            Picture_machine.Image = My.Resources.Resource1.履帶式開挖裝料機_crawler_backhoe_loader_
            mach = 1
        End If
        If ComboBox_machine_list.Text = "推土機" Then
            Picture_machine.Image = My.Resources.Resource1.履帶式推土機_crawler_dozer_
            mach = 1
        End If
        If ComboBox_machine_list.Text = "牽引裝料機" Then
            Picture_machine.Image = My.Resources.Resource1.履帶式裝料機_crawler_loader_
            mach = 1
        End If
        If ComboBox_machine_list.Text = "振動式打樁機" Then
            Picture_machine.Image = My.Resources.Resource1.履帶式開挖機_crawler_excavator_
            mach = 2
        End If
        If ComboBox_machine_list.Text = "鑽岩機" Then
            Picture_machine.Image = My.Resources.Resource1.膠輪式推土機_wheeled_dozer_
            mach = 2
        End If
        If ComboBox_machine_list.Text = "壓路機" Then
            Picture_machine.Image = My.Resources.Resource1.膠輪式開挖裝料機_wheeled_backhoe_loader_
            mach = 2
        End If
        If ComboBox_machine_list.Text = "輪胎式壓路機" Then
            Picture_machine.Image = My.Resources.Resource1.膠輪式開挖機_wheeled_excavator_
            mach = 2
        End If
        If ComboBox_machine_list.Text = "振動式壓路機" Then
            Picture_machine.Image = My.Resources.Resource1.膠輪式裝料機_wheeled_loader_
            mach = 2
        End If
        If ComboBox_machine_list.Text = "混凝土割切機" Then
            Picture_machine.Image = My.Resources.Resource1.壓路機_rollers_
            mach = 2
        End If
        If mach = 1 Then
            TextBox_L1.Enabled = False
            TextBox_L2.Enabled = False
            TextBox_L3.Enabled = False
            TextBox_r2.Enabled = False
            Button_L1_L2_L3_check.Enabled = False
            TextBox_L.Enabled = True
            TextBox_r1.Enabled = True
            Button_L_check.Enabled = True
        End If
        If mach = 2 Then
            TextBox_L.Enabled = False
            TextBox_r1.Enabled = False
            Button_L_check.Enabled = False
            TextBox_L1.Enabled = True
            TextBox_L2.Enabled = True
            TextBox_L3.Enabled = True
            TextBox_r2.Enabled = True
            Button_L1_L2_L3_check.Enabled = True
        End If
    End Sub

    Private Sub Button_L_check_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_L_check.Click
        Dim r1 As Integer
        If TextBox_L.Text < 1.5 Then
            TextBox_r1.Text = "4"
            r1 = 4
        End If
        If TextBox_L.Text >= 1.5 And TextBox_L.Text < 4 Then
            TextBox_r1.Text = "10"
            r1 = 10
        End If
        If TextBox_L.Text >= 4 Then
            TextBox_r1.Text = "16"
            r1 = 16
        End If
        pos(0, 0) = r1 * 0.7
        pos(0, 1) = r1 * 0.7
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
        pos(4, 0) = r1 * -0.27
        pos(4, 1) = r1 * 0.65
        pos(5, 0) = -1 * pos(4, 0)
        pos(5, 1) = -1 * pos(4, 1)
        pos(4, 2) = pos(5, 2) = r1 * 0.71


        setup_finish.Enabled = True


    End Sub

    Private Sub Button_L1_L2_L3_check_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_L1_L2_L3_check.Click
        Dim L1 As Double
        Dim L2 As Double
        Dim L3 As Double
        Dim D0 As Double
        L1 = TextBox_L1.Text
        L2 = TextBox_L2.Text
        L3 = TextBox_L3.Text
        D0 = Math.Sqrt(((L1 / 2) ^ 2) + ((L2 / 2) ^ 2) + (L3 ^ 2))
        TextBox_r2.Text = 2 * D0
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

        setup_finish.Enabled = True
    End Sub

    Private Sub setup_finish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles setup_finish.Click
        Main.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Program.Show()
    End Sub
End Class
