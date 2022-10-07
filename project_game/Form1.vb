Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        dataLeaderboard()
        Timer1.Interval = 1000
        waktu = DateTime.Now.Add(mundur)
        Label1.Text = "Press Start/Enter to Start The Games"
        Button1.Enabled = False
        Button2.Select()
        Label4.Visible = False
        Label7.Visible = False
    End Sub

    Sub dataWords()
        da = New MySql.Data.MySqlClient.MySqlDataAdapter("
        SELECT * FROM `words`;
        ", conn)
        ds = New DataSet
        data = da.Fill(ds, "words")
    End Sub

    Sub dataLeaderboard()
        da = New MySql.Data.MySqlClient.MySqlDataAdapter("
        SELECT no, score FROM leaderboard
        ", conn)
        dt = New DataTable
        data = da.Fill(dt)
        If data > 0 Then
            DataGridView1.DataSource = dt
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.Columns(0).HeaderText = "No"
            DataGridView1.Columns(1).HeaderText = "Score"
        End If
    End Sub

    Sub displayWord()
        cmd = New MySql.Data.MySqlClient.MySqlCommand("
        SELECT * FROM `words`;
        ", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            Label4.Text = dr.Item("no").ToString
            Label7.Text = dr.Item("word").ToString
            TextBox2.Text = dr.Item("hint1").ToString
            TextBox3.Text = dr.Item("hint2").ToString
        End If
        cmd.Dispose()
        dr.Close()
    End Sub

    Sub randomWords()
        Dim pos1 As Integer = System.Convert.ToInt32(((random.Next((words.Length)))))
        Dim pos2 As Integer = System.Convert.ToInt32(((random.Next((words.Length)))))
        Dim pos3 As Integer = System.Convert.ToInt32(((random.Next((words.Length)))))

        Dim word As String = words

        word = word.Remove(pos1, 1).Insert(pos1, "_")
        word = word.Remove(pos2, 1).Insert(pos2, "_")
        word = word.Remove(pos3, 1).Insert(pos3, "_")

        Label1.Text = word
    End Sub

    Sub checkWord()
        If words.Equals(TextBox1.Text) Then
            Label3.Text = "Correct"
            Label3.BackColor = Color.Green
            score += 1
        Else
            Label3.Text = "Wrong"
            Label3.BackColor = Color.Red
        End If
        dataWords()
        For i = 0 To ds.Tables("words").Rows.Count
            totatWords = i
        Next
        If Label4.Text = totatWords Then
            Timer1.Stop()
            Label3.Text += " ( " & score & " / " & totatWords & " )"
            Label3.BackColor = Color.OrangeRed
            Button1.Enabled = False
            Button2.Enabled = True
            Button2.Select()
            Label1.Text = "Game Over"
            cmd = New MySql.Data.MySqlClient.MySqlCommand("
            INSERT INTO leaderboard (no, score) VALUES
            (
                NULL,
                '" & score & "'
            )
            ", conn)
            cmd.ExecuteNonQuery()
            dataLeaderboard()
        End If
        TextBox1.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label5.Text = "00.00"
        Timer1.Start()
        Timer1.Interval = 1000
        waktu = DateTime.Now.Add(mundur)
        TextBox1.Select()
        TextBox1.Text = ""
        Label3.Text = ""
        score = 0
        Button1.Enabled = True
        Button2.Enabled = False
        displayWord()
        words = Label7.Text
        randomWords()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Select()
        checkWord()
        dataWords()
        If Label4.Text < 6 Then
            For i = 0 To ds.Tables("words").Rows.Count - 1
                If Label4.Text = ds.Tables("words").Rows(i)(0) Then
                    Label4.Text = ds.Tables("words").Rows(i + 1)(0)
                    Label7.Text = ds.Tables("words").Rows(i + 1)(1)
                    TextBox2.Text = ds.Tables("words").Rows(i + 1)(2)
                    TextBox3.Text = ds.Tables("words").Rows(i + 1)(3)
                    words = Label7.Text
                    randomWords()
                    Return
                End If
            Next
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim wkt As TimeSpan = waktu.Subtract(DateTime.Now)
        If wkt.TotalSeconds > 0 Then
            Label5.Text = wkt.ToString("mm\.ss")
        Else
            dataWords()

            For i = 0 To ds.Tables("words").Rows.Count
                totatWords = i
            Next

            Label5.Text = "00.00"
            Timer1.Stop()
            MessageBox.Show("Time Out", "Information")
            If Label4.Text = Label4.Text Then
                Timer1.Stop()
                Label3.Text += " ( " & score & " / " & totatWords & " )"
                Label3.BackColor = Color.OrangeRed
                Button1.Enabled = False
                Button2.Enabled = True
                Button2.Select()
                Label1.Text = "Game Over"
                cmd = New MySql.Data.MySqlClient.MySqlCommand("
                INSERT INTO leaderboard (no, score) VALUES
                (
                    NULL,
                    '" & score & "'
                )
                ", conn)
                cmd.ExecuteNonQuery()
                dataLeaderboard()
            End If
            TextBox1.Text = ""
        End If
    End Sub
End Class
