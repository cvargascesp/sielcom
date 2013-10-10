Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class login
    Inherits System.Windows.Forms.Form

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        validarIngreso()
    End Sub

    Private Sub login_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MaskedTextBox1.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.Text = ""
        MaskedTextBox1.Focus()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            End
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Cancelar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            Me.Hide()
            venta.Show()
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        'valida solo numeros y k
        If InStr(1, "0123456789k" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
        If TextBox2.MaxLength = 1 Then
            TextBox1.Focus()
        End If
    End Sub

    Private Sub MaskedTextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MaskedTextBox1.KeyPress
        'valida solo numeros
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub MaskedTextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaskedTextBox1.KeyUp
        If MaskedTextBox1.MaskCompleted Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            validarIngreso()
        End If
    End Sub

    Private Sub validarIngreso()
        If MaskedTextBox1.Text <> "" And TextBox2.Text <> "" And TextBox1.Text <> "" Then
            'Conexion.open()
            'Dim sSQL As String = "SET character_set_results=latin1"
            'Dim cmd = New MySqlCommand(sSQL, Conexion.conn)
            'cmd.ExecuteNonQuery()
            'carga cb cuenta
            Try
                Dim da As MySqlDataAdapter
                Dim ds As New DataSet

                Dim sql As String = "SELECT * FROM usuario where run = '" & MaskedTextBox1.Text & "' and digito='" & TextBox2.Text & "' and clave='" & TextBox1.Text & "'"

                da = New MySqlDataAdapter(sql, Conexion.conn)
                da.Fill(ds)

                ComboBox1.DataSource = ds.Tables(0)
                ComboBox1.DisplayMember = "cuenta"
                ComboBox1.ValueMember = "run"
                lblUsuario.Text = ds.Tables(0).Rows(0)(3).ToString
            Catch err As MySqlException
                MessageBox.Show(err.Message)
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try

            'valida el acceso
            MaskedTextBox1.Focus()
            Select Case ComboBox1.Text
                Case ""
                    MessageBox.Show("Verifique Rut y/o Clave", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MaskedTextBox1.Clear()
                    MaskedTextBox1.Focus()
                    TextBox1.Clear()
                    TextBox2.Clear()
                Case "VENTAS"
                    venta.Button6.Visible = False
                    venta.Button5.Visible = True
                    Me.Hide()
                    venta.Show()
                Case "ADMINISTRADOR"
                    venta.Button6.Visible = True
                    venta.Button5.Visible = False
                    caja.Button5.Visible = False
                    caja.Button6.Visible = True
                    bodega_compraventa.Button5.Visible = False
                    bodega_compraventa.Button6.Visible = True
                    empaque.Button6.Visible = True
                    empaque.Button5.Visible = False
                    Me.Hide()
                    inicio.Show()
                Case "CAJA"
                    caja.Button6.Visible = False
                    caja.Button5.Visible = True
                    Me.Hide()
                    caja.Show()
                Case "BODEGA"
                    bodega_compraventa.Button6.Visible = False
                    bodega_compraventa.Button5.Visible = True
                    Me.Hide()
                    bodega_compraventa.Show()
                Case "EMPAQUE"
                    empaque.Button6.Visible = False
                    empaque.Button5.Visible = True
                    Me.Hide()
                    empaque.Show()
            End Select
        Else
            MessageBox.Show("Ingrese Datos Requeridos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
End Class
