Imports MySql.Data.MySqlClient
Module Module1
    Public conn As MySqlConnection
    Public da As MySqlDataAdapter
    Public dr As MySqlDataReader
    Public cmd As MySqlCommand
    Public ds As DataSet
    Public dt As DataTable
    Public data As Integer
    Public qry As String
    Public words As String
    Public random As Random = New Random()
    Public score As Integer = 0
    Public waktu As DateTime
    Public mundur As TimeSpan = TimeSpan.FromSeconds(20)
    Public jj, mm, dd As Integer
    Public totatWords As Integer

    Sub koneksi()
        Try
            qry = "server=localhost;userid=root;password=;database=db_game;convert zero datetime = true"
            conn = New MySqlConnection(qry)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Module
