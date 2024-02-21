Public Class cari_produk
    Dim id_produk

    Sub awal()
        'MsgBox(getCount("select * from transaksi where pembeli like '%" & TextBox1.Text & "%'"))
        DataGridView1.DataSource = getData("select * from produk where nama_produk like '%" & TextBox1.Text & "%'")
        'MsgBox(getValue("select * from transaksi where pembeli like '%" & TextBox1.Text & "%'", "pembeli"))
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Nama Produk"
        DataGridView1.Columns(2).HeaderText = "Harga"
        DataGridView1.Columns(3).HeaderText = "Stok"

    End Sub
    Private Sub cari_produk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            menu_utama.TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            menu_utama.TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
           
            Label3.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value

            menu_utama.id_produk = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        awal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class