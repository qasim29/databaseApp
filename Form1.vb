Imports MySql.Data.MySqlClient
Public Class Form1

    Dim connection As New MySqlConnection("datasource=localhost;port=3306;username=root;password=qasimmohammad;database=database01")

    Private Sub search_button_data_gridview_Click(sender As Object, e As EventArgs) Handles MyBase.Click, search_button_data_gridview.Click

        Dim search_command As New MySqlCommand("SELECT * FROM `company data` WHERE `job`=@job", connection)
        search_command.Parameters.Add("@job", MySqlDbType.VarChar).Value = TextBox2.Text

        Dim adapter As New MySqlDataAdapter(search_command)

        Dim table As New DataTable()
        Try
            adapter.Fill(table)

            If table.Rows.Count > (0) Then


                TextBox3.Text = table(0)(2)
                TextBox4.Text = table(0)(3)
                TextBox5.Text = table(0)(4)
                TextBox6.Text = table(0)(5)
                TextBox7.Text = table(0)(6)
                TextBox8.Text = table(0)(7)
                TextBox9.Text = table(0)(8)
                TextBox10.Text = table(0)(9)
                TextBox11.Text = table(0)(10)
                TextBox12.Text = table(0)(11)
                TextBox13.Text = table(0)(12)
            Else


                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""
                TextBox10.Text = ""
                TextBox11.Text = ""
                TextBox12.Text = ""
                TextBox13.Text = ""
                MessageBox.Show("Sorry! No Data Found")

            End If

        Catch ex As Exception

            MessageBox.Show("sorry wrong format")

        End Try

    End Sub

    Function execCommand(ByVal cmd As MySqlCommand) As Boolean

        If connection.State = ConnectionState.Closed Then
            connection.Open()
        End If

        If cmd.ExecuteNonQuery() = 1 Then
            Return True

        Else
            Return False

        End If

        If connection.State = ConnectionState.Open Then
            connection.Close()
        End If

    End Function

    Private Sub submit_Button_Click(sender As Object, e As EventArgs) Handles submit_Button.Click

        Dim insert_command As New MySqlCommand("INSERT INTO `company data`(`JOB`,`CONSIGNEE`,`DESC`,`B/L NO`,`COUNT`,`S`,`LINE`,`W`,`VESSEl`,`ETA`,`PKGES`,`CLIENT`) Values(@job,@con,@desc,@blno,@count,@s,@line,@w,@vessel,@eta,@pkges,@clients)", connection)
        insert_command.Parameters.Add("@job", MySqlDbType.VarChar).Value = TextBox2.Text
        insert_command.Parameters.Add("@con", MySqlDbType.VarChar).Value = TextBox3.Text
        insert_command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = TextBox4.Text
        insert_command.Parameters.Add("@blno", MySqlDbType.VarChar).Value = TextBox5.Text
        insert_command.Parameters.Add("@count", MySqlDbType.VarChar).Value = TextBox6.Text
        insert_command.Parameters.Add("@s", MySqlDbType.VarChar).Value = TextBox7.Text
        insert_command.Parameters.Add("@line", MySqlDbType.VarChar).Value = TextBox8.Text
        insert_command.Parameters.Add("@w", MySqlDbType.VarChar).Value = TextBox9.Text
        insert_command.Parameters.Add("@vessel", MySqlDbType.VarChar).Value = TextBox10.Text
        insert_command.Parameters.Add("@eta", MySqlDbType.VarChar).Value = TextBox11.Text
        insert_command.Parameters.Add("@pkges", MySqlDbType.VarChar).Value = TextBox12.Text
        insert_command.Parameters.Add("@clients", MySqlDbType.VarChar).Value = TextBox13.Text

        If execCommand(insert_command) Then
            MessageBox.Show("Data Inserted")
        Else
            MessageBox.Show("Data Not Inserted")
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class

