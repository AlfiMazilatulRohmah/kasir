Public Class cari_pelanggan
    Dim id_pelanggan

    Sub awal()
        'MsgBox(getCount("select * from transaksi where pembeli like '%" & TextBox1.Text & "%'"))
        DataGridView1.DataSource = getData("select * from pelanggan where nama_pelanggan like '%" & TextBox1.Text & "%'")
        'MsgBox(getValue("select * from transaksi where pembeli like '%" & TextBox1.Text & "%'", "pembeli"))
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Nama Pelanggan"
        DataGridView1.Columns(2).HeaderText = "Alamat"
        DataGridView1.Columns(3).HeaderText = "Telp"
       
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        awal()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            menu_utama.TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            Lpelanggan.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value


            id_pelanggan = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub cari_pelanggan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Lpelanggan.Text = "" Then
            MsgBox("Pelanggan Kosong")
        Else
            Dim sql = "insert into penjualan values ('" & Date.Now.ToString("yyyy/MM/dd") & "',0,'" & id_pelanggan & "',0)"
            'MsgBox(sql)
            exc(sql)
            Me.Close()
        End If
    End Sub
End Class