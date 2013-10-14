Imports MySql.Data.MySqlClient
Public Class libro_ingreso_mercaderia

    Dim existe As Integer


    Private Sub libro_ingreso_mercaderia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formato_datetimepicker()
        llenar_combobox_proveedores()
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

                    MessageBox.Show("El Producto ingresado No existe desea Crearlo", "Ingresar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    'agregar resultado del dialogresult anterior
                    agregar_materia_prima.Show()
                    Me.Button1.Enabled = False
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
            If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And NumericUpDown1.Value >= 1 And comboproveedor.Text <> "" And TextBox5.Text <> "" And TextBox6.Text <> "" And TextBox7.Text <> "" And TextBox8.Text <> "" Then
                Dim sql As String
                'inserta un nuevo producto
                '  sql = "INSERT INTO producto (codigo,codigoint,nombre,descripcion,marca,modelo,linea,categoria,proveedor,ubicacion,umedida,stock,critico,porvender,porllegar,fechapedido,preciouni,margen,precioventa,utilidaduni,estado,fechaingreso,creado)" & _
                ' "VALUES('" & TextBox1.Text & "','" & Label25.Text & "','" & txtNombre.Text & "', '" & TextBox4.Text & "', '" & ComboBox1.Text & "', '" & ComboBox6.Text & "', '" & cbLinea.Text & "', '" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & txtUbicacion.Text & "','" & txtUmedida.Text & "'," & NumericUpDown1.Value & "," & NumericUpDown2.Value & "," & nupPorvender.Value & "," & nupPorllegar.Value & ", " & IIf(fechapedido = Nothing, "NULL", "'" & fechapedido.ToString("yyyy-MM-dd HH:mm:ss") & "'") & "," & TextBox7.Text & "," & TextBox8.Text.Replace(",", ".") & "," & TextBox10.Text & ",0,'NUEVO','" & CDate(Label17.Text).Date.ToString("yyyy-MM-dd") & " " & Now.ToString("HH:mm:ss") & "','" & Label35.Text & "')"
                Console.Write(sql)
                Dim cm3 As New MySqlCommand(sql, Conexion.conn)
                Conexion.open()
                cm3.ExecuteNonQuery()
                Conexion.close()

                MessageBox.Show("Producto Guardado con Exito", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Hide()
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
End Class