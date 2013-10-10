Imports MySql.Data.MySqlClient
Public Class n_proveedor

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Cancelar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub n_proveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.GotFocus
        'carca cb regiones
        Try
            Dim ds2 As New DataSet
            Dim sql2 As String = "SELECT region_ordinal FROM regiones order by region_ordinal"
            Dim da2 As New MySQLDataAdapter(sql2, Conexion.conn)

            da2.Fill(ds2)
            ' asignar el DataSource al combobox  
            ComboBox1.DataSource = ds2.Tables(0)
            ' Asignar el campo a la propiedad DisplayMember del combo   
            ComboBox1.DisplayMember = ds2.Tables(0).Columns(0).Caption.ToString

        Catch ex As MySQLException
            MessageBox.Show("No se ha podido conectar al servidor")
        End Try
    End Sub

    Private Sub ComboBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.GotFocus
        'carga cb provincias
        Try
            Dim ds2 As New DataSet
            Dim sql2 As String = "SELECT provincia_nombre from comunas INNER JOIN provincias on comunas.provincia_id = provincias.provincia_id INNER JOIN regiones ON provincias.region_id = regiones.region_id WHERE region_ordinal Like '" & ComboBox1.Text & "' group by provincia_nombre order by provincia_nombre"
            Dim da2 As New MySQLDataAdapter(sql2, Conexion.conn)

            da2.Fill(ds2)
            'asignar el DataSource al combobox  
            ComboBox2.DataSource = ds2.Tables(0)

            ' Asignar el campo a la propiedad DisplayMember del combo   
            ComboBox2.DisplayMember = ds2.Tables(0).Columns(0).Caption.ToString

        Catch ex As MySQLException
            MessageBox.Show("No se ha podido conectar al servidor")
        End Try
    End Sub

    Private Sub ComboBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.GotFocus
        'carga cb comunas
        Try
            Dim ds2 As New DataSet
            Dim sql2 As String = "SELECT comuna_nombre from comunas INNER JOIN provincias on comunas.provincia_id = provincias.provincia_id INNER JOIN regiones ON provincias.region_id = regiones.region_id WHERE provincia_nombre Like '" & ComboBox2.Text & "' group by comuna_nombre order by comuna_nombre"
            Dim da2 As New MySQLDataAdapter(sql2, Conexion.conn)

            da2.Fill(ds2)
            'asignar el DataSource al combobox  
            ComboBox3.DataSource = ds2.Tables(0)

            ' Asignar el campo a la propiedad DisplayMember del combo   
            ComboBox3.DisplayMember = ds2.Tables(0).Columns(0).Caption.ToString

        Catch ex As MySQLException
            MessageBox.Show("No se ha podido conectar al servidor")
        End Try
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        'valida solo numeros y k
        If InStr(1, "0123456789k" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        'valida solo letras y numeros
        If InStr(1, "abcdefghijklmnñopqrstuvwxyz- 0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        'valida solo letras
        If InStr(1, "abcdefghijklmnñopqrstuvwxyz " & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        'valida solo numeros, letras y .
        If InStr(1, "0123456789 abcdefghijklmnñopqrstuvwxyz.-" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        'valida solo numeros
        If InStr(1, "0123456789-" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        'valida solo numeros
        If InStr(1, "0123456789-" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        'valida texto
        If InStr(1, "0123456789abcdefghijklmnñopqrstuvwxyz.-_@" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub n_proveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'usuario responsable
        Label16.Text = login.lblUsuario.Text
        Button3.Visible = False
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            Try
                'verifica si existe rut
                Dim r As Integer
                Dim sql As String = "SELECT COUNT(*) FROM proveedor WHERE rut ='" & MaskedTextBox1.Text & "'and digito = '" & TextBox1.Text & "'"
                Dim cm As New MySqlCommand(sql, Conexion.conn)
                Conexion.open()
                r = cm.ExecuteScalar()
                Conexion.close()

                If r <> 0 Then
                    Dim resul As DialogResult
                    resul = MessageBox.Show("Desea Actualizar Datos", "Actualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    If resul = Windows.Forms.DialogResult.Yes Then
                        Button3.Visible = True
                        'carga datos para actualizar
                        Dim ds As New DataSet
                        Dim sql2 As String = "SELECT * FROM proveedor WHERE rut ='" & MaskedTextBox1.Text & "'and digito = '" & TextBox1.Text & "'"
                        Dim da As New MySqlDataAdapter(sql2, Conexion.conn)

                        da.Fill(ds)
                        TextBox2.Text = ds.Tables(0).Rows(0)(2).ToString()
                        TextBox3.Text = ds.Tables(0).Rows(0)(3).ToString()
                        TextBox4.Text = ds.Tables(0).Rows(0)(4).ToString()
                        TextBox5.Text = ds.Tables(0).Rows(0)(5).ToString()
                        TextBox9.Text = ds.Tables(0).Rows(0)(6).ToString()
                        TextBox6.Text = ds.Tables(0).Rows(0)(7).ToString()
                        ComboBox1.Items.Add(ds.Tables(0).Rows(0)(8).ToString())
                        ComboBox1.SelectedIndex = 0
                        ComboBox2.Items.Add(ds.Tables(0).Rows(0)(9).ToString())
                        ComboBox2.SelectedIndex = 0
                        ComboBox3.Items.Add(ds.Tables(0).Rows(0)(10).ToString())
                        ComboBox3.SelectedIndex = 0
                        TextBox7.Text = ds.Tables(0).Rows(0)(11).ToString()

                    Else
                        Button3.Visible = False
                        MaskedTextBox1.Clear()
                        MaskedTextBox1.Focus()
                        TextBox1.Clear()
                    End If
                End If
            Catch err As MySqlException
                MessageBox.Show(err.Message)
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        End If
    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        'valida numeros
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            'valida que no hayan datos vacios
            If MaskedTextBox1.Text <> "" And TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And ComboBox1.Text <> "--SELECCIONE--" And ComboBox2.Text <> "--SELECCIONE--" And ComboBox3.Text <> "--SELECCIONE--" Then
                'verifica si existe run
                Dim r As Integer
                Dim sql As String = "SELECT COUNT(*) FROM proveedor WHERE rut ='" & MaskedTextBox1.Text & "'and digito = '" & TextBox1.Text & "'"
                Dim cm As New MySqlCommand(sql, Conexion.conn)
                Conexion.open()
                r = cm.ExecuteScalar()
                Conexion.close()
                If r <> 0 Then
                    Dim resul As DialogResult
                    resul = MessageBox.Show("Desea Actualizar Datos", "Actualizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    If resul = Windows.Forms.DialogResult.Yes Then
                        'actualiza datos
                        Dim sql2 As String = "UPDATE proveedor SET rut='" & MaskedTextBox1.Text & "', digito='" & TextBox1.Text & "',nombre='" & TextBox2.Text & "',contacto='" & TextBox3.Text & "',direccion='" & TextBox4.Text & "',telefono1='" & TextBox5.Text & "',telefono2='" & TextBox9.Text & "',fax='" & TextBox6.Text & "',region='" & ComboBox1.Text & "',provincia='" & ComboBox2.Text & "',comuna='" & ComboBox3.Text & "',mail='" & TextBox7.Text & "',creado='" & Label16.Text & "',fechac='" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "' where rut ='" & MaskedTextBox1.Text & "' and digito='" & TextBox1.Text & "'"
                        Dim cm2 = New MySqlCommand(sql2, Conexion.conn)
                        Conexion.open()
                        cm2.ExecuteNonQuery()
                        Conexion.close()
                        MessageBox.Show("Proveedor Actualizado con Exito", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    End If
                Else
                    'inserta un nuevo proveedor
                    Dim sql3 As String = "INSERT INTO proveedor (rut,digito,nombre,contacto,direccion,telefono1,telefono2,fax,region,provincia,comuna,mail,creado,fechac)" & _
                     "VALUES('" & MaskedTextBox1.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "','" & TextBox9.Text & "','" & TextBox6.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & TextBox7.Text & "','" & Label16.Text & "','" & Now.ToString("yyyy-MM-dd HH:mm:ss") & "') "
                    Dim cm3 As New MySqlCommand(sql3, Conexion.conn)
                    Conexion.open()
                    cm3.ExecuteNonQuery()
                    Conexion.close()
                    MessageBox.Show("Proveedor Guardado con Exito", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            Else
                MessageBox.Show("Complete Información Requerida", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch err As MySQLException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            'eliminar proveedor
            Dim resul As DialogResult
            resul = MessageBox.Show("Desea Eliminar Proveedor", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If resul = Windows.Forms.DialogResult.Yes Then
                Dim sql As String = "DELETE FROM proveedor WHERE rut='" & MaskedTextBox1.Text & "' and digito='" & TextBox1.Text & "'"
                Dim cm As New MySqlCommand(sql, Conexion.conn)
                Conexion.open()
                cm.ExecuteNonQuery()
                Conexion.close()
                MessageBox.Show("Proveedor Eliminado con Exito", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBox.Show("Proveedor NO Eliminado", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch err As MySQLException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub
End Class