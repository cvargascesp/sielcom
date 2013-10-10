Imports MySql.Data.MySqlClient
Public Class m_bol_fac

    Private Sub m_bol_fac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'carga cajero
            Dim sql2 As String
            Dim cn2 As MySQLConnection
            Dim cm2 As MySQLCommand
            Dim da As MySQLDataAdapter
            Dim ds As DataSet
            cn2 = New MySQLConnection(Conexion.strConn)
            cn2.Open()
            sql2 = "SELECT nombre FROM usuario WHERE run ='" & login.MaskedTextBox1.Text & "'and digito = '" & login.TextBox2.Text & "'"
            cm2 = New MySQLCommand()
            cm2.CommandText = sql2
            cm2.CommandType = CommandType.Text
            cm2.Connection = cn2
            da = New MySQLDataAdapter(cm2)
            ds = New DataSet()
            da.Fill(ds)
            Label17.Text = ds.Tables(0).Rows(0)(0).ToString()
            cn2.Close()
        Catch err As MySQLException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        'valida numeros 
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        If TextBox2.Text <> "" Then
            'verifica si existe documento
            Dim sql As String
            Dim cn As MySQLConnection
            Dim cm As MySQLCommand
            Dim r As Integer
            cn = New MySQLConnection(Conexion.strConn)
            cn.Open()
            sql = "SELECT COUNT(*) FROM boleta WHERE numdocu ='" & TextBox2.Text & "' and tipodocu='" & ComboBox1.Text & "'"
            cm = New MySQLCommand()
            cm.CommandText = sql
            cm.CommandType = CommandType.Text
            cm.Connection = cn
            r = cm.ExecuteScalar()
            cn.Close()
            If r <> 0 Then
                'carga datos documento
                Try
                    Dim sql5 As String
                    Dim cn5 As MySQLConnection
                    Dim cm5 As MySQLCommand
                    Dim da5 As MySQLDataAdapter
                    Dim ds5 As DataSet
                    cn5 = New MySQLConnection(Conexion.strConn)
                    cn5.Open()
                    sql5 = "SELECT * FROM boleta where numdocu='" & TextBox2.Text & "'"
                    cm5 = New MySQLCommand()
                    cm5.CommandText = sql5
                    cm5.CommandType = CommandType.Text
                    cm5.Connection = cn5
                    da5 = New MySQLDataAdapter(cm5)
                    ds5 = New DataSet()
                    da5.Fill(ds5)
                    cn5.Close()
                    Label28.Text = ds5.Tables(0).Rows(0)(3).ToString()
                    Label13.Text = ds5.Tables(0).Rows(0)(4).ToString()
                    Label1.Text = ds5.Tables(0).Rows(0)(5).ToString()
                    MaskedTextBox1.Text = ds5.Tables(0).Rows(0)(1).ToString()
                    Label9.Text = ds5.Tables(0).Rows(0)(6).ToString()
                Catch err As MySQLException
                    MessageBox.Show(err.Message)
                Catch err As Exception
                    MessageBox.Show(err.Message)
                End Try
                'carga la grilla
                Try
                    Dim cn2 As MySQLConnection
                    cn2 = New MySQLConnection(Conexion.strConn)
                    Dim sql2 As String = "select cantidadpro as Cantidad, nombrepro as Nombre, descripcionpro as Descripción, preciopro as PrecioUnitario from ticket WHERE numdocu ='" & Label9.Text & "'"
                    Dim Ds2 As New DataSet
                    Dim Da2 As New MySQLDataAdapter(sql2, cn2)
                    cn2.Open()
                    Da2.Fill(Ds2, "ticket")
                    With Me.DataGridView1
                        .DataSource = Ds2.Tables("ticket").DefaultView
                    End With
                    cn2.Close()
                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
                    DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
                Catch err As MySQLException
                    MessageBox.Show(err.Message)
                Catch err As Exception
                    MessageBox.Show(err.Message)
                End Try
                'carga total
                Try
                    Dim sql5 As String
                    Dim cn5 As MySQLConnection
                    Dim cm5 As MySQLCommand
                    Dim da5 As MySQLDataAdapter
                    Dim ds5 As DataSet
                    cn5 = New MySQLConnection(Conexion.strConn)
                    cn5.Open()
                    sql5 = "SELECT total,descuento FROM ticket where numdocu='" & Label9.Text & "'"
                    cm5 = New MySQLCommand()
                    cm5.CommandText = sql5
                    cm5.CommandType = CommandType.Text
                    cm5.Connection = cn5
                    da5 = New MySQLDataAdapter(cm5)
                    ds5 = New DataSet()
                    da5.Fill(ds5)
                    cn5.Close()
                    Label15.Text = ds5.Tables(0).Rows(0)(0).ToString()
                    Label10.Text = ds5.Tables(0).Rows(0)(1).ToString()
                    Label20.Text = CInt(Label15.Text) - CInt(Label10.Text)
                Catch err As MySQLException
                    MessageBox.Show(err.Message)
                Catch err As Exception
                    MessageBox.Show(err.Message)
                End Try
            Else
                'MessageBox.Show("Número Documento NO Existe", "Verifique Ticket", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim n_ticket As New n_ticket
        n_ticket.Label6.Text = Label9.Text
        n_ticket.ComboBox1.Items.Add(Label17.Text)
        n_ticket.ComboBox1.SelectedIndex = 0
        n_ticket.ComboBox1.Enabled = False
        Me.Hide()
        n_ticket.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Cancelar la Boleta?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            Me.Hide()
            inicio.Show()
        End If
    End Sub

    Private Sub Button1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button3.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox19_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox19.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox7_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox7.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox8_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox8.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox19_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox19.KeyPress
        'valida numeros y k
        If InStr(1, "0123456789k" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        'valida numeros y letras
        If InStr(1, "0123456789 abcdefghijklmnñopqrstuvwxyz" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        'valida numeros y letras
        If InStr(1, "0123456789 abcdefghijklmnñopqrstuvwxyz" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        'valida numeros y letras
        If InStr(1, "0123456789 abcdefghijklmnñopqrstuvwxyz." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        'valida letras
        If InStr(1, " abcdefghijklmnñopqrstuvwxyz" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        'valida numeros 
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub
End Class