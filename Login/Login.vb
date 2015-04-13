Imports System.Data.SqlClient
Public Class FrLogin

    Private Sub btnDangNhap_Click_1(sender As Object, e As EventArgs) Handles btnDangNhap.Click
        Dim ChuoiKetNoi As String = "workstation id=congpbps02257.mssql.somee.com;packet size=4096;user id=ps02257;pwd=Cong123456;data source=congpbps02257.mssql.somee.com;persist security info=False;initial catalog=congpbps02257"
        Dim KetNoi As SqlConnection = New SqlConnection(ChuoiKetNoi)
        Dim SqlAdapter As New SqlDataAdapter("Select * from NhanVien where MaNhanVien='" & txtUsername.Text & "' and Password='" & txtPassword.Text & "'", KetNoi)
        Dim tb As New DataTable
        Try
            KetNoi.Open()
            SqlAdapter.Fill(tb)
            If tb.Rows.Count > 0 Then
                MessageBox.Show("Kết nối thành công")
                Me.Hide()
                frMain.Show()
            Else
                MessageBox.Show("Sai tài khoản hoặc mật khẩu")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        txtUsername.Clear()
        txtPassword.Clear()
    End Sub

    Private Sub FrLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
