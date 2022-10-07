Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
    End Sub

    Sub dataWords()
        da = New MySql.Data.MySqlClient.MySqlDataAdapter("
        SELECT * FROM words
        ", conn)
        dt = New DataTable
        data = da.Fill(dt)
        If data > 0 Then
            DataGridView1.DataSource = dt
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.Columns(0).HeaderText = "No"
            DataGridView1.Columns(1).HeaderText = "Words"
            DataGridView1.Columns(2).HeaderText = "Hint 1"
            DataGridView1.Columns(3).HeaderText = "Hint 2"
        End If
    End Sub

    Sub kondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Silahkan isi Form yang disediakan")
        Else
            cmd = New MySql.Data.MySqlClient.MySqlCommand("
            INSERT INTO words VALUES
            (
                NULL,
                '" & TextBox2.Text & "',
                '" & TextBox3.Text & "',
                '" & TextBox4.Text & "'
            )
            ", conn)
            cmd.ExecuteNonQuery()
            dataWords()
            kondisiAwal()
        End If
    End Sub
End Class