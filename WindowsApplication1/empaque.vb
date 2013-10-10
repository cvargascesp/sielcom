Imports MySql.Data.MySqlClient
Public Class empaque

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.Clear()
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        'valida solo numeros y letras
        If InStr(1, "0123456789 abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text <> "" Then
            'verifica si existe ticket
            Dim r As Integer
            Dim sql As String = "SELECT COUNT(*) FROM ticket WHERE numdocu ='" & TextBox1.Text & "' and estado='PAGADO'"
            Dim cm As New MySqlCommand(sql, Conexion.conn)
            Conexion.open()
            r = cm.ExecuteScalar()
            Conexion.close()
            If r <> 0 Then
                'carga la grilla
                Try
                    Dim sql2 As String = "select t.codigo as Código, t.cantidad as Cantidad, p.nombre as Nombre, p.descripcion as Descripción, t.precioventa as PrecioUnitario from ticketdetalle t join producto p on(t.codigo=p.codigo) WHERE numdocu ='" & TextBox1.Text & "'"
                    Dim Ds2 As New DataSet
                    Dim Da2 As New MySqlDataAdapter(sql2, Conexion.conn)

                    Da2.Fill(Ds2, "ticket")

                    DataGridView1.DataSource = Ds2.Tables("ticket").DefaultView
                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
                    DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
                Catch err As MySQLException
                    MessageBox.Show(err.Message)
                Catch err As Exception
                    MessageBox.Show(err.Message)
                End Try
            Else
                TextBox1.Focus()
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text <> "" Then
            Try
                'actualiza datos
                Dim sql2 As String = "UPDATE ticket SET estado ='ENTREGADO' where numdocu='" & TextBox1.Text & "'"
                Dim cm2 As New MySqlCommand(sql2, Conexion.conn)
                Conexion.open()
                cm2.ExecuteNonQuery()
                Conexion.close()
            Catch err As MySQLException
                MessageBox.Show(err.Message)
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try

            TextBox1.Clear()
            TextBox1.Focus()
            DataGridView1.DataSource = Nothing
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            login.Button5.Enabled = True
            login.MaskedTextBox1.Clear()
            login.TextBox1.Clear()
            login.TextBox2.Clear()
            login.ComboBox1.DataSource = Nothing
            Me.Hide()
            login.Show()
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Volver?", "Volver", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            Me.Hide()
            inicio.Show()
        End If
    End Sub

    Private Sub CambiarContraseñaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarContraseñaToolStripMenuItem.Click
        Dim n_usuario As New n_usuario
        n_usuario.MaskedTextBox1.Text = login.MaskedTextBox1.Text
        n_usuario.TextBox1.Text = login.TextBox2.Text
        n_usuario.MaskedTextBox1.Enabled = False
        n_usuario.TextBox1.Enabled = False
        n_usuario.TextBox2.Enabled = False
        n_usuario.ComboBox1.Enabled = False
        n_usuario.Button3.Visible = False
        n_usuario.Show()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub empaque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.Text = login.lblUsuario.Text
    End Sub
End Class