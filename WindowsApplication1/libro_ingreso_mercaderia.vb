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
            If TextBox1.Text <> "" And TextBox2.Text <> "" And NumericUpDown1.TextAlign = "0" And comboproveedor.Text <> "0" And TextBox5.Text <> "0" And TextBox6.Text <> "0" And TextBox7.Text <> "0" And TextBox8.Text <> "0" Then
                Dim sqlquery As String = "insert into libro_ingreso_mp (codigo_mp,fecha_ingresomp,cantidad_mp,rut_proveedor,precio_compra_mp,numero_factura,guia_despacho,orden_compra) values('" & Me.TextBox1.Text & "',  '" & Me.DateTimePicker1.Text & "',  '" & Me.NumericUpDown1.Value & "', '" & Me.comboproveedor.SelectedValue & "',   '" & Me.TextBox5.Text & "',  '" & Me.TextBox6.Text & "' ,  '" & Me.TextBox7.Text & "',  '" & Me.TextBox8.Text & "' )"
                Dim cmd As New MySqlCommand(sqlquery, Conexion.conn)
                Try
                    Conexion.open()
                    cmd.ExecuteNonQuery()
                    Conexion.close()
                    MessageBox.Show("Familia Guardada con exito", "Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
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
        If (dataset2.Tables(0).Rows.Count <> 0) Then
            Return dataset2.Tables(0).Rows(0).Item(0).ToString()
            Conexion.close()
        Else
            Return "2344"
            'valor solo referencial
        End If
    End Function

    
End Class