Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class frQLSanPham
    Dim tb As New DataTable
    Dim ChuoiKetNoi As String = "workstation id=congpbps02257.mssql.somee.com;packet size=4096;user id=ps02257;pwd=Cong123456;data source=congpbps02257.mssql.somee.com;persist security info=False;initial catalog=congpbps02257"

    Public Sub LoadData()
        Dim KetNoi As New SqlConnection(ChuoiKetNoi)
        Dim SqlAdapter As New SqlDataAdapter("SELECT * FROM SanPham", KetNoi)
        Try
            SqlAdapter.Fill(tb)
        Catch ex As Exception

        End Try
        DataGridView1.DataSource = tb
        KetNoi.Close()
    End Sub

    Private Sub frQLSanPham_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim KetNoi As New SqlConnection(ChuoiKetNoi)
        Dim SqlAdapter As New SqlDataAdapter("SELECT * FROM SanPham", KetNoi)
        Try
            KetNoi.Open()
            SqlAdapter.Fill(tb)
        Catch ex As Exception

        End Try
        DataGridView1.DataSource = tb
        KetNoi.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        txtMaSP.Text = DataGridView1.Item(0, index).Value
        txtTenSP.Text = DataGridView1.Item(1, index).Value
        txtDonGia.Text = DataGridView1.Item(2, index).Value
        txtSoLuong.Text = DataGridView1.Item(3, index).Value
        txtMaLoai.Text = DataGridView1.Item(4, index).Value
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Dim KetNoi As New SqlConnection(ChuoiKetNoi)
        KetNoi.Open()
        Dim stadd As String = "INSERT INTO SanPham VALUES (@MaSanPham, @TenSanPham, @DonGia, @SoLuong, @MaLoai)"
        Dim com As New SqlCommand(stadd, KetNoi)
        Try
            com.Parameters.AddWithValue("@MaSanPham", txtMaSP.Text)
            com.Parameters.AddWithValue("@TenSanPham", txtTenSP.Text)
            com.Parameters.AddWithValue("@DonGia", txtDonGia.Text)
            com.Parameters.AddWithValue("@SoLuong", txtSoLuong.Text)
            com.Parameters.AddWithValue("@MaLoai", txtMaLoai.Text)
            com.ExecuteNonQuery()
            KetNoi.Close()
        Catch ex As Exception
            MessageBox.Show("Kết nối không thành công")
        End Try
        tb.Clear()
        DataGridView1.DataSource = tb
        DataGridView1.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        Dim KetNoi As New SqlConnection(ChuoiKetNoi)
        KetNoi.Open()
        Dim stadd As String = "UPDATE SanPham SET TenSanPham = @TenSanPham, DonGia = @DonGia, SoLuong = @SoLuong WHERE MaSanPham = @MaSanPham"
        Dim com As New SqlCommand(stadd, KetNoi)
        Try
            com.Parameters.AddWithValue("@MaSanPham", txtMaSP.Text)
            com.Parameters.AddWithValue("@TenSanPham", txtTenSP.Text)
            com.Parameters.AddWithValue("@DonGia", txtDonGia.Text)
            com.Parameters.AddWithValue("@SoLuong", txtSoLuong.Text)
            com.ExecuteNonQuery()
            KetNoi.Close()
        Catch ex As Exception
            MessageBox.Show("Kết nối không thành công")
        End Try
        tb.Clear()
        DataGridView1.DataSource = tb
        DataGridView1.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim KetNoi As New SqlConnection(ChuoiKetNoi)
        KetNoi.Open()
        Dim stadd As String = "DELETE FROM SanPham WHERE MaSanPham = @MaSanPham"
        Dim com As New SqlCommand(stadd, KetNoi)
        Try
            com.Parameters.AddWithValue("@MaSanPham", txtMaSP.Text)
            com.ExecuteNonQuery()
            KetNoi.Close()
        Catch ex As Exception
            MessageBox.Show("Kết nối không thành công")
        End Try
        tb.Clear()
        DataGridView1.DataSource = tb
        DataGridView1.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

End Class