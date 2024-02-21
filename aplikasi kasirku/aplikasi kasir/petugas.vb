Public Class petugas
    Dim id = "0"
    Dim aksi = False

    Sub awal()
        DataGridView1.DataSource = getData("select * from petugas where nama_petugas like '%" & TextBox1.Text & "%'")
        clearForm(GroupBox2)
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Nama Petugas"
        DataGridView1.Columns(2).HeaderText = "Username"
        DataGridView1.Columns(3).HeaderText = "Password"
        DataGridView1.Columns(4).HeaderText = "Telepon"
        DataGridView1.Columns(5).HeaderText = "Level"

        GroupBox1.Enabled = True
        GroupBox2.Enabled = False
        GroupBox3.Enabled = True
    End Sub
    Sub buka()
        GroupBox1.Enabled = False
        GroupBox2.Enabled = True
        GroupBox3.Enabled = False
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        awal()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If adaKosong(GroupBox2) Then
            MsgBox("Ada data kosong")
        Else
            Dim sql
            If Not aksi Then
                sql = "insert into petugas values ('" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox1.Text & "')"
                'MsgBox(sql)
                exc(sql)
                MsgBox("Data Berhasil ditambah")
                awal()
            Else
                sql = "update petugas set nama_petugas = '" & TextBox2.Text & "', username = '" & TextBox3.Text & "', password = '" & TextBox4.Text & "', telp = '" & TextBox5.Text & "', level = '" & ComboBox1.Text & "' where id_petugas = " & id
                'MsgBox(sql)
                exc(sql)
                MsgBox("Data berhasil diubah")
                awal()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clearForm(GroupBox2)
        awal()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clearForm(GroupBox2)
        buka()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If id = "0" Then
            MsgBox("Pilih data dulu")
        Else
            aksi = True
            buka()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If id = "0" Then
            MsgBox("Pilih data dulu")
        Else
            If dialog("Apakah anda yakin ingin menghapus?") Then
                Dim sql = "delete from petugas where id_petugas =" & id
                'MsgBox(sql)
                exc(sql)
                clearForm(GroupBox2)
                awal()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
            id = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub
End Class