Imports MySql.Data.MySqlClient
Public Class n_usuario

    Private Sub n_usuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub n_usuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label11.Text = login.lblUsuario.Text
    End Sub

    Private Sub ComboBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.GotFocus
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("ADMINISTRADOR")
        ComboBox1.Items.Add("BODEGA")
        ComboBox1.Items.Add("VENTAS")
        ComboBox1.Items.Add("CAJA")
        ComboBox1.Items.Add("EMPAQUE")
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        'valida solo numeros y k
        If InStr(1, "0123456789k" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            'verifica si existe run
            Dim r As Integer
            Dim sql As String = "SELECT COUNT(*) FROM usuario WHERE run ='" & MaskedTextBox1.Text & "'and digito = '" & TextBox1.Text & "'"
            Dim cm As New MySqlCommand(sql, Conexion.conn)
            Conexion.open()
            r = cm.ExecuteScalar()
            Conexion.close()

            If r <> 0 Then
                Dim resul As DialogResult
                resul = MessageBox.Show("Desea Actualizar Datos", "Actualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                If resul = Windows.Forms.DialogResult.Yes Then
                    Button3.Visible = True
                    Try
                        'carga datos para actualizar
                        Dim ds As New DataSet
                        Dim sql2 As String = "SELECT * FROM usuario WHERE run ='" & MaskedTextBox1.Text & "'and digito = '" & TextBox1.Text & "'"
                        Dim da As New MySqlDataAdapter(sql2, Conexion.conn)

                        da.Fill(ds)
                        TextBox2.Text = ds.Tables(0).Rows(0)(2).ToString()
                        ComboBox1.Items.Add(ds.Tables(0).Rows(0)(3).ToString())
                        ComboBox1.SelectedIndex = 0
                        Label6.Text = ds.Tables(0).Rows(0)(4).ToString()

                    Catch err As MySqlException
                        MessageBox.Show(err.Message)
                    Catch err As Exception
                        MessageBox.Show(err.Message)
                    End Try
                Else
                    Me.Hide()
                End If
            End If
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        'valida solo numeros y letras
        If InStr(1, "0123456789abcdefghijklmnñopqrstuvwxyz " & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "ADMINISTRADOR" Then
            Label6.Text = "TOTAL"
        ElseIf ComboBox1.Text = "--SELECCIONE--" Then
            Label6.Text = ""
        Else
            Label6.Text = "RESTRINGIDO"
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Cancelar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        'valida solo numeros y letras
        If InStr(1, "0123456789abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ " & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        'valida solo numeros y letras
        If InStr(1, "0123456789abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ " & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox3.Text <> TextBox4.Text Then
            MessageBox.Show("Las claves no coinciden, verifique", "Clave", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox3.Focus()
        Else
            Try
                'valida que no hayan datos vacios
                If MaskedTextBox1.Text <> "" And TextBox1.Text <> "" And TextBox2.Text <> "" And ComboBox1.Text <> "--SELECCIONE--" And Label6.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" Then
                    'verifica si existe run
                    Dim r As Integer
                    Dim sql As String = "SELECT COUNT(*) FROM usuario WHERE run ='" & MaskedTextBox1.Text & "'and digito = '" & TextBox1.Text & "'"
                    Dim cm As New MySqlCommand(sql, Conexion.conn)
                    Conexion.open()
                    r = cm.ExecuteScalar()
                    Conexion.close()

                    If r <> 0 Then
                        Dim resul As DialogResult
                        resul = MessageBox.Show("Desea Actualizar Datos", "Actualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                        If resul = Windows.Forms.DialogResult.Yes Then
                            Try
                                'actualiza datos
                                Dim sql2 As String = "UPDATE usuario SET run='" & MaskedTextBox1.Text & "', digito='" & TextBox1.Text & "',nombre='" & TextBox2.Text & "',cuenta='" & ComboBox1.Text & "',permiso='" & Label6.Text & "',clave='" & TextBox3.Text & "',fechac='" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "' where run ='" & MaskedTextBox1.Text & "' and digito='" & TextBox1.Text & "'"
                                Dim cm2 As New MySqlCommand(sql2, Conexion.conn)
                                Conexion.open()
                                cm2.ExecuteNonQuery()
                                Conexion.close()
                                MessageBox.Show("Usuario Actualizado con Exito", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Me.Close()
                            Catch err As MySqlException
                                MessageBox.Show(err.Message)
                            Catch err As Exception
                                MessageBox.Show(err.Message)
                            End Try
                        End If
                    Else
                        Try
                            'inserta un nuevo usuario
                            Dim sql3 As String = "INSERT INTO usuario (run,digito,nombre,cuenta,permiso,clave,creado,fechac) " & _
                             "VALUES('" & MaskedTextBox1.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "', '" & ComboBox1.Text & "', '" & Label6.Text & "', '" & TextBox3.Text & "','" & Label11.Text & "', '" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "') "
                            Dim cm3 As New MySqlCommand(sql3, Conexion.conn)
                            Conexion.open()
                            cm3.ExecuteNonQuery()
                            Conexion.close()
                            MessageBox.Show("Usuario Guardado con Exito", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Close()
                        Catch err As MySqlException
                            MessageBox.Show(err.Message)
                        Catch err As Exception
                            MessageBox.Show(err.Message)
                        End Try
                    End If
                Else
                    MessageBox.Show("Complete Información Requerida", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Usuario NO Guardado", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim resul As DialogResult
        resul = MessageBox.Show("Desea Eliminar Usuario", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If resul = Windows.Forms.DialogResult.Yes Then
            Try
                Dim sql As String = "DELETE FROM usuario WHERE run='" & MaskedTextBox1.Text & "' and digito='" & TextBox1.Text & "'"
                Dim cm As New MySqlCommand(sql, Conexion.conn)
                Conexion.open()
                cm.ExecuteNonQuery()
                Conexion.close()
                MessageBox.Show("Usuario Eliminado con Exito", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Catch err As MySqlException
                MessageBox.Show(err.Message)
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        Else
            MessageBox.Show("Usuario NO Eliminado", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        If TextBox3.Text <> "" Then
            If TextBox3.TextLength < 6 Or TextBox3.TextLength > 15 Then
                MessageBox.Show("Ingrese un mínimo de 6 y Máximo de 15 Carácteres", "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox3.Clear()
                TextBox3.Focus()
            End If
        End If
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub
End Class