Public Class login

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Username atau Password Kosong")
        Else

            Dim sql = "select * from petugas where username = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'"
            Dim sql1 = "select * from pelanggan where username = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'"

            If getCount(sql) > 0 Then
                If getValue(sql, "level") = "Admin" Then
                    'MsgBox(getValue(sql, "nama_petugas"))
                    menu_utama.Lpetugas.Text = getValue(sql, "nama_petugas")
                    menu_utama.id_petugas = getValue(sql, "id_petugas")
                    menu_utama.MasterToolStripMenuItem.Visible = True
                    menu_utama.PetugasToolStripMenuItem.Visible = True
                    menu_utama.ProdukToolStripMenuItem.Visible = True
                    menu_utama.PelangganToolStripMenuItem.Visible = True
                    menu_utama.Show()
                    Me.Hide()
                    TextBox1.Clear()
                    TextBox2.Clear()
                ElseIf getValue(sql, "level") = "Petugas" Then
                    'MsgBox(getValue(sql, "namapetugas"))
                    menu_utama.Lpetugas.Text = getValue(sql, "nama_petugas")
                    menu_utama.id_petugas = getValue(sql, "id_petugas")
                    menu_utama.MasterToolStripMenuItem.Visible = True
                    menu_utama.PetugasToolStripMenuItem.Visible = False
                    menu_utama.ProdukToolStripMenuItem.Visible = True
                    menu_utama.PelangganToolStripMenuItem.Visible = True
                    menu_utama.Show()
                    Me.Hide()
                    TextBox1.Clear()
                    TextBox2.Clear()
                End If

            ElseIf getCount(sql1) > 0 Then
                'MsgBox(getValue(sql1, "namapelanggan"))
               
                Me.Hide()
                TextBox1.Clear()
                TextBox2.Clear()
            Else
                MsgBox("Username atau Password Salah")
            End If
        End If
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.UseSystemPasswordChar = True
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class
