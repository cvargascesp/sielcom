Imports MySql.Data.MySqlClient
Public Class libro_ingreso_mercaderia

    Dim existe As Integer

    Private Sub libro_ingreso_mercaderia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formato_datetimepicker()
        llenar_combobox_proveedores()
        Me.Button1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Volver?", "Volver", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            Me.Close()
            bodega_materias_primas_principal.Show()
        End If
    End Sub
    Sub formato_datetimepicker()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        Try
            'verifica si existe producto
            existe = 0
            Conexion.open()
            Dim sql As String = "SELECT COUNT(*) FROM materia_prima WHERE codigo_mp ='" & TextBox1.Text & "' limit 1"
            Dim cm As New MySqlCommand(sql, Conexion.conn)
            existe = cm.ExecuteScalar()
            If existe = 0 Then
                If (Me.TextBox1.Text <> "") Then
                    MessageBox.Show("El Producto ingresado no esta Registrado, Debe Ser creado", "Error")
                    Me.Button1.Enabled = False
                    Me.TextBox1.Text = ""
                    Me.TextBox1.Focus()
                End If
            Else
                Dim dataadapter2 As MySqlDataAdapter
                Dim dataset2 As DataSet
                Dim sql2 As String = "Select * From materia_prima where codigo_mp='" & Me.TextBox1.Text & "'"
                dataadapter2 = New MySqlDataAdapter(sql2, Conexion.conn)
                dataset2 = New DataSet()
                dataadapter2.Fill(dataset2)
                Me.TextBox2.Text = dataset2.Tables(0).Rows(0).Item(1).ToString()
                Me.Button1.Enabled = True
                Me.NumericUpDown1.Focus()
            End If


            Conexion.close()
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        End Try
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Sub llenar_combobox_proveedores()
        Dim ssql As String = "select * from proveedor"
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(ssql, Conexion.conn)
        Try
            Dim actual As String = Me.comboproveedor.Text
            da.Fill(ds)
            Me.comboproveedor.DataSource = ds.Tables(0)
            Me.comboproveedor.DisplayMember = "nombre"
            Me.comboproveedor.ValueMember = "rut"
            Me.comboproveedor.SelectedValue = actual
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'valida que no hayan datos vacios
            If TextBox1.Text <> "" And TextBox2.Text <> "" And NumericUpDown1.TextAlign = "0" And comboproveedor.Text <> "0" And TextBox5.Text <> "0" And TextBox6.Text <> "0" And TextBox7.Text <> "0" And TextBox8.Text <> "0" And TextBox3.Text <> "0" Then



                'Dim sql As String
                ' If existe = 0 Then
                'inserta un nuevo producto ans
                '   Sql = "INSERT INTO producto (codigo,codigoint,nombre,descripcion,marca,modelo,linea,categoria,proveedor,ubicacion,umedida,stock,critico,porvender,porllegar,fechapedido,preciouni,margen,precioventa,utilidaduni,estado,fechaingreso,creado)" & _
                '      "VALUES('" & TextBox1.Text & "','" & Label25.Text & "','" & txtNombre.Text & "', '" & TextBox4.Text & "', '" & ComboBox1.Text & "', '" & ComboBox6.Text & "', '" & cbLinea.Text & "', '" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & txtUbicacion.Text & "','" & txtUmedida.Text & "'," & NumericUpDown1.Value & "," & NumericUpDown2.Value & "," & nupPorvender.Value & "," & nupPorllegar.Value & ", " & IIf(fechapedido = Nothing, "NULL", "'" & fechapedido.ToString("yyyy-MM-dd HH:mm:ss") & "'") & "," & TextBox7.Text & "," & TextBox8.Text.Replace(",", ".") & "," & TextBox10.Text & ",0,'NUEVO','" & CDate(Label17.Text).Date.ToString("yyyy-MM-dd") & " " & Now.ToString("HH:mm:ss") & "','" & Label35.Text & "')"
                '    Console.Write(Sql)
                '  Else
                'modificar un producto
                '   Sql = "UPDATE producto SET " &
                '   "codigo = '" & TextBox1.Text &
                '   "', codigoint = '" & Label25.Text &
                '  "', nombre = '" & txtNombre.Text &
                '    "', descripcion = '" & TextBox4.Text &
                '   "', marca = '" & ComboBox1.Text &
                '    "', modelo = '" & ComboBox6.Text &
                '  "', linea = '" & cbLinea.Text &
                '   "', categoria = '" & ComboBox2.Text &
                '    "', proveedor = '" & ComboBox3.Text &
                '     "', ubicacion = '" & txtUbicacion.Text &
                '      "', umedida = '" & txtUmedida.Text &
                '       "', stock = " & NumericUpDown1.Value &
                '        ", critico = " & NumericUpDown2.Value &
                '         ", porvender = " & nupPorvender.Value &
                '          ", porllegar = " & nupPorllegar.Value &
                '           ", fechapedido = " & IIf(fechapedido = Nothing, "NULL", "'" & fechapedido.ToString("yyyy-MM-dd HH:mm:ss") & "'") &
                '            ", preciouni = " & TextBox7.Text &
                '             ", margen = " & TextBox8.Text.Replace(",", ".") &
                '              ", precioventa = " & TextBox10.Text &
                '               " WHERE codigo = '" & TextBox1.Text & "'"
                '        End If

                'Dim cm3 As New MySqlCommand(sql, Conexion.conn)
                'Conexion.open()
                'cm3.ExecuteNonQuery()
                'Conexion.close()
                'producto = producto + 1
                ' Label25.Text = producto
                ' MessageBox.Show("Producto Guardado con Exito", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '  Me.Hide()
            Else
                MessageBox.Show("Complete Información Requerida", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        Conexion.close()
    End Sub

    
    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.LostFocus
        If (check_oc_exists() = 0) Then
            MessageBox.Show("La orden de compra ingresada no existe", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Button1.Enabled = False
        End If
        If (check_ot_ontime() = 1) Then
            MessageBox.Show("La orden de compra sobrepaso su fecha tope", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Button1.Enabled = False
        End If
    End Sub

    Function check_oc_exists()
        'verificamos que la orden ingresada exista
        Conexion.open()
        Dim query As String = "SELECT COUNT(*) FROM orden_compramp_cabezera WHERE id_ordencompramp='" & Me.TextBox8.Text & "'"
        Dim dataset1 As New DataSet
        Dim dataadapter1 As New MySqlDataAdapter(query, Conexion.conn)
        dataadapter1.Fill(dataset1)
        Return dataset1.Tables(0).Rows(0).Item(0).ToString()
        Conexion.close()
    End Function
    Function check_ot_ontime()
        'verifica que la orden de compra no este atrasada
        ' retorna 0 si a tiempo o 1 si atrasada
        Conexion.open()
        Dim query2 As String = "SELECT  IF(fecha_tope-CURDATE()>=0,'0','1')'estado' FROM orden_compramp_cabezera WHERE id_ordencompramp='" & Me.TextBox8.Text & "'"
        Dim dataset2 As New DataSet
        Dim dataadapter2 As New MySqlDataAdapter(query2, Conexion.conn)
        dataadapter2.Fill(dataset2)
        Return dataset2.Tables(0).Rows(0).Item(0).ToString()
        Conexion.close()
        Return 0
    End Function

    
End Class