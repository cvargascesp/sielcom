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
                'carga datos de mp en los componentes del formulario
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
            If TextBox1.Text <> "" And TextBox2.Text <> "" And NumericUpDown1.TextAlign = "0" And comboproveedor.Text <> "0" And TextBox5.Text <> "0" And TextBox6.Text <> "0" And TextBox7.Text <> "0" And TextBox8.Text <> "0" Then
                Dim sqlquery As String = "insert into libro_ingreso_mp (codigo_mp,fecha_ingresomp,cantidad_mp,rut_proveedor,precio_compra_mp,numero_factura,guia_despacho,orden_compra) values ('" & Me.TextBox1.Text & "',  '" & Me.DateTimePicker1.Text & "',  '" & Me.NumericUpDown1.Value & "', '" & Me.comboproveedor.SelectedValue & "','" & Me.TextBox5.Text & "',  '" & Me.TextBox6.Text & "' ,  '" & Me.TextBox7.Text & "',  '" & Me.TextBox8.Text & "' )"
                Dim cmd As New MySqlCommand(sqlquery, Conexion.conn)
                Try
                    cmd.ExecuteNonQuery()
                    ingreso_stock_mp(Me.TextBox1.Text, Me.NumericUpDown1.Value)
                    MessageBox.Show("ingreso exitoso a existencias", "Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

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
        Else
            Me.Button1.Enabled = True
        End If


        If (check_ot_ontime() = 1) Then
            MessageBox.Show("La orden de compra sobrepaso su fecha tope", "error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Button1.Enabled = False
        Else
            Me.Button1.Enabled = True
        End If


    End Sub

    Sub cargador_datos(ByVal orden_compra As Integer, ByVal codigomp As Integer)
        'carga los datos en los campos
        Conexion.open()
        Dim sqlquery As String = "SELECT proveedor.nombre'nombre_proveedor',proveedor.rut'rut',materia_prima.nombre_mp'producto',orden_compramp_detalle.cantidad_mp_oc'cantidad' FROM orden_compramp_cabezera INNER JOIN proveedor ON orden_compramp_cabezera.rut=proveedor.rut INNER JOIN orden_compramp_detalle ON orden_compramp_detalle.id_ordencompramp=orden_compramp_cabezera.id_ordencompramp INNER JOIN materia_prima ON materia_prima.codigo_mp=orden_compramp_detalle.codigo_mp WHERE orden_compramp_cabezera.id_ordencompramp='" & orden_compra & "' AND orden_compramp_detalle.codigo_mp='" & codigomp & "'"
        Dim dataset5 As New DataSet
        Dim dataadapter5 As New MySqlDataAdapter(sqlquery, Conexion.conn)
        dataadapter5.Fill(dataset5)
        If (dataset5.Tables(0).Rows.Count <> 0) Then
            Me.TextBox2.Text = dataset5.Tables(0).Rows(0).Item(2).ToString()
            Me.NumericUpDown1.Value = dataset5.Tables(0).Rows(0).Item(3).ToString()
            Me.comboproveedor.SelectedText = dataset5.Tables(0).Rows(0).Item(0).ToString()
            Me.comboproveedor.SelectedValue = dataset5.Tables(0).Rows(0).Item(1).ToString()
        Else
            MessageBox.Show("error en los campos ingresados", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Conexion.close()
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
    Function check_mp_on_ordencompramp(ByVal idorden_compra As Integer, ByVal codigomp As Integer)
        'verifica que el la materia prima a ingresar exista en la orden de compra mencionada
        Conexion.open()
        Dim sqlquery As String = "SELECT COUNT(orden_compramp_detalle.codigo_mp) FROM orden_compramp_cabezera JOIN orden_compramp_detalle ON orden_compramp_cabezera.id_ordencompramp=orden_compramp_detalle.id_ordencompramp WHERE orden_compramp_detalle.id_ordencompramp='" & idorden_compra & "' AND orden_compramp_detalle.codigo_mp='" & codigomp & "' "
        Dim dataset4 As New DataSet
        Dim dataadapter4 As New MySqlDataAdapter(sqlquery, Conexion.conn)
        dataadapter4.Fill(dataset4)
        If (dataset4.Tables(0).Rows.Count <> 0) Then
            Return dataset4.Tables(0).Rows(0).Item(0).ToString()
            'retorna 0 si el producto no existe asociado a esa orden de compra
        Else
            Return 0
            'retorna 0 si no encuentra nada por algun error
        End If
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
        If (dataset2.Tables(0).Rows.Count <> 0) Then
            Return dataset2.Tables(0).Rows(0).Item(0).ToString()
            Conexion.close()
        Else
            Return "2344"
            'valor solo referencial
        End If
    End Function

    Sub ingreso_stock_mp(ByVal codigo_mp, ByVal cantidad_mp)
        'checkeamos si el producto existe
        Conexion.open()
        Dim query3 As String = "SELECT * FROM materia_prima_existencias where codigo_mp='" & codigo_mp & "'"
        Dim dataset3 As New DataSet
        Dim dataadapter3 As New MySqlDataAdapter(query3, Conexion.conn)
        dataadapter3.Fill(dataset3)
        If (dataset3.Tables(0).Rows.Count <> 0) Then
            'producto existe y hay que modificarlo
            Dim query_update As String = "UPDATE materia_prima_existencias SET stock_mp=stock_mp+'" & cantidad_mp & "' where codigo_mp='" & codigo_mp & "'"
            Dim cmd2 As New MySqlCommand(query_update, Conexion.conn)
            Try
                cmd2.ExecuteNonQuery()
                kardex_mp.add_kardex_entrada(codigo_mp, cantidad_mp)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        Else
            'producto no existe y se inserta a existencias
            Dim query_insert As String = "INSERT INTO materia_prima_existencias VALUES ('" & codigo_mp & "','" & cantidad_mp & "')"
            Dim cmd2 As New MySqlCommand(query_insert, Conexion.conn)
            Try
                cmd2.ExecuteNonQuery()
                kardex_mp.add_kardex_entrada(codigo_mp, cantidad_mp)
                Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub


    Private Sub TextBox8_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox8.LostFocus
        If (check_mp_on_ordencompramp(Me.TextBox8.Text, Me.TextBox1.Text) = 0) Then
            MessageBox.Show("El producto ingresado no existe asociado a la orden de compra especificada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            cargador_datos(Me.TextBox8.Text, Me.TextBox1.Text)
        End If
    End Sub
End Class