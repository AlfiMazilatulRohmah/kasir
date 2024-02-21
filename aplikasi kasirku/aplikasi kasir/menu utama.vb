Public Class menu_utama
    Public id_produk, id_penjualan, id_detail, id_petugas As String
    Dim aksi = False
    Dim Logout

    Sub getDetail_Penjualan()
        id_penjualan = getValue("select top(1) * from penjualan order by id_penjualan desc", "id_penjualan")
        Dim sql
        'MsgBox(sql)
        'apabila data kosong krn blm ada transaksi
        If getCount("select * from penjualan order by id_penjualan desc") = "0" Then
            tampilKosong()
            'MsgBox("1")
        Else
            'apabila sudah dibayar
            If getValue("select * from penjualan order by id_penjualan desc", "status") = "1" Then
                tampilKosong()
                'MsgBox("2")
            Else
                'apabila status 0 krn blm dibayar
                'MsgBox("3")
                sql = "select * from vdetail where id_penjualan =" & id_penjualan
                DataGridView1.DataSource = getData("select id_penjualan, nama_pelanggan, nama_produk, harga, jumlah_produk, subtotal, tgl_penjualan, id_detail from vdetail where id_penjualan=" & id_penjualan)
                DataGridView1.Columns(0).Visible = True
                DataGridView1.Columns(1).HeaderText = "Pelanggan"
                DataGridView1.Columns(2).HeaderText = "Produk"
                DataGridView1.Columns(3).HeaderText = "Harga"
                DataGridView1.Columns(4).HeaderText = "Jumlah Produk"
                DataGridView1.Columns(5).HeaderText = "Subtotal"
                DataGridView1.Columns(6).HeaderText = "Tanggal Penjualan"


                Dim subtotal = getValue("select SUM (subtotal) as sub FROM detail_penjualan where id_penjualan = " & id_penjualan, "sub")
                Label7.Text = subtotal
            End If
        End If
        id_detail = "0"
    End Sub

    Sub tampilKosong()
        'jika data kosong
        id_penjualan = getValue("select top(1) * from penjualan order by id_penjualan desc", "id_penjualan")
        Dim sql
        sql = "select top(0) * from vdetail"
        DataGridView1.DataSource = getData("select id_penjualan, nama_pelanggan, nama_produk, harga, jumlah_produk, subtotal, tgl_penjualan, id_detail from vdetail where id_penjualan=" & id_penjualan)
        DataGridView1.Columns(0).Visible = True
        DataGridView1.Columns(1).HeaderText = "Pelanggan"
        DataGridView1.Columns(2).HeaderText = "Produk"
        DataGridView1.Columns(3).HeaderText = "Harga"
        DataGridView1.Columns(4).HeaderText = "Jumlah Produk"
        DataGridView1.Columns(5).HeaderText = "Subtotal"
        DataGridView1.Columns(6).HeaderText = "Tanggal Penjualan"

        Label7.Text = "0"
    End Sub

    Sub buka()
        GroupBox1.Enabled = True
        GroupBox2.Enabled = True
        GroupBox3.Enabled = True
    End Sub

    Sub tutup()
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
    End Sub

    Private Sub menu_utama_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If aksi = False Then
            login.Close()
        End If
    End Sub

    Private Sub menu_utama_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PetugasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PetugasToolStripMenuItem.Click
        petugas.ShowDialog()
    End Sub

    Private Sub ProdukToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProdukToolStripMenuItem.Click
        produk.ShowDialog()
    End Sub

    Private Sub PelangganToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PelangganToolStripMenuItem.Click
        pelanggan.ShowDialog()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        aksi = True
        Me.Close()
        login.Show()
    End Sub

    Private Sub LaporanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanToolStripMenuItem.Click
        laporan.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cari_produk.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cari_pelanggan.ShowDialog()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        Dim stok = getValue("select * from produk where id_produk =" & id_produk, "stok")
        'MsgBox(stok)
        If NumericUpDown1.Value > stok Then
            NumericUpDown1.Value = stok
            MsgBox("Melebihi Stok")
        End If
        TextBox4.Text = NumericUpDown1.Value * Double.Parse(TextBox3.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        id_penjualan = getValue("select top(1) * from penjualan order by id_penjualan desc", "id_penjualan")
        If id_produk = "" Or id_penjualan = "" Or NumericUpDown1.Value = 0 Then
            MsgBox("Data masih kosong")
        Else
            Dim sql = "insert into detail_penjualan values ('" & id_penjualan & "','" & id_produk & "','" & NumericUpDown1.Value & "','" & TextBox4.Text & "')"
            'MsgBox(sql)
            exc(sql)
            getDetail_Penjualan()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value

            id_detail = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Label7.Text = "0" Then
            MsgBox("Data Kosong")
        Else
            transaksi.TextBox2.Text = Label7.Text
            transaksi.ShowDialog()
        End If
        clearForm(GroupBox1)
        clearForm(GroupBox3)
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        GroupBox1.Enabled = True
        GroupBox2.Enabled = True
        GroupBox3.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If id_detail = "0" Then
            MsgBox("Pilih data dulu")
        Else
            If dialog("Apakah anda yakin ingin menghapus?") Then
                Dim sql = "delete from detail_penjualan where id_detail =" & id_detail
                'MsgBox(sql)
                exc(sql)
                clearForm(GroupBox2)
                clearForm(GroupBox3)
                getDetail_Penjualan()
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If dialog("Apakah anda yakin ingin membatalkan transaksi?") Then
            id_penjualan = getValue("select top(1) * from penjualan order by id_penjualan desc", "id_penjualan")
            Dim sql = "delete from detail_penjualan where id_penjualan =" & id_penjualan
            Dim sql1 = "delete from penjualan where id_penjualan =" & id_penjualan
            'MsgBox(sql)
            exc(sql)
            'MsgBox(sql1)
            exc(sql)
            getDetail_Penjualan()
            clearForm(GroupBox1)
            clearForm(GroupBox3)

            GroupBox1.Enabled = False
            GroupBox2.Enabled = False
            GroupBox3.Enabled = False
        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class