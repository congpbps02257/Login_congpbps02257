Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class frQLKhachHang
    Dim tb As New DataTable
    'Tạo biến bảng'
    Dim ChuoiKetNoi As String = "workstation id=congpbps02257.mssql.somee.com;packet size=4096;user id=ps02257;pwd=Cong123456;data source=congpbps02257.mssql.somee.com;persist security info=False;initial catalog=congpbps02257"
    'Tạo liên kết đến database'
    Public Sub LoadData()
        Dim KetNoi As New SqlConnection(ChuoiKetNoi)
        'Khai báo kết nối'
        Dim SqlAdapter As New SqlDataAdapter("SELECT * FROM KhachHang", KetNoi)
        'Khai báo đối tượng truy vấn'
        Try
            SqlAdapter.Fill(tb)
            'Tải dữ liệu lên table'
        Catch ex As Exception

        End Try
        DataGridView1.DataSource = tb
        'Hiển thị dữ liệu lên DataGridView'
        KetNoi.Close()
        'Đóng kết nối'
    End Sub
    Private Sub frQLKhachHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim KetNoi As New SqlConnection(ChuoiKetNoi)
        'Khai báo kết nối'
        Dim SqlAdapter As New SqlDataAdapter("SELECT * FROM KhachHang", KetNoi)
        'Khai báo đối tượng truy vấn'
        Try
            KetNoi.Open()
            'Mở kết nối'
            SqlAdapter.Fill(tb)
            'Tải dữ liệu lên table'
        Catch ex As Exception

        End Try
        DataGridView1.DataSource = tb
        'Hiển thị dữ liệu lên DataGridView'
        KetNoi.Close()
        'Đóng kết nối'
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'Tạo sự kiện click lấy dữ liệu khi click vào một cell bất kỳ' 
        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        txtMaKH.Text = DataGridView1.Item(0, index).Value
        txtTenKH.Text = DataGridView1.Item(1, index).Value
        txtSoDT.Text = DataGridView1.Item(2, index).Value
        txtDiaChi.Text = DataGridView1.Item(3, index).Value
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Dim KetNoi As New SqlConnection(ChuoiKetNoi)
        'Khai báo kết nối'
        KetNoi.Open()
        'Mở kết nối'
        Dim stadd As String = "INSERT INTO KhachHang VALUES (@MaKhachHang, @TenKhachHang, @DiaChi, @DienThoai)"
        'Khai báo đối tượng truy vấn'
        Dim com As New SqlCommand(stadd, KetNoi)
        Try
            'Thêm dữ liệu vào câu truy vấn'
            com.Parameters.AddWithValue("@MaKhachHang", txtMaKH.Text)
            com.Parameters.AddWithValue("@TenKhachHang", txtTenKH.Text)
            com.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text)
            com.Parameters.AddWithValue("@DienThoai", txtSoDT.Text)
            com.ExecuteNonQuery()
            'Thực thi và sửa dữ liệu trong database'
            KetNoi.Close()
            'Đóng kết nối
        Catch ex As Exception
            MessageBox.Show("Kết nối không thành công")
        End Try
        'Xóa và load lại bảng'
        tb.Clear()
        DataGridView1.DataSource = tb
        DataGridView1.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        Dim KetNoi As New SqlConnection(ChuoiKetNoi)
        KetNoi.Open()
        Dim stadd As String = "UPDATE KhachHang SET TenKhachHang = @TenKhachHang, DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaKhachHang = @MaKhachHang"
        Dim com As New SqlCommand(stadd, KetNoi)
        Try
            com.Parameters.AddWithValue("@MaKhachHang", txtMaKH.Text)
            com.Parameters.AddWithValue("@TenKhachHang", txtTenKH.Text)
            com.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text)
            com.Parameters.AddWithValue("@DienThoai", txtSoDT.Text)
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
        Dim stadd As String = "DELETE FROM KhachHang WHERE MaKhachHang = @MaKhachHang"
        Dim com As New SqlCommand(stadd, KetNoi)
        Try
            com.Parameters.AddWithValue("@MaKhachHang", txtMaKH.Text)
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