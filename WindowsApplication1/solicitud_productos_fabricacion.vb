Imports MySql.Data.MySqlClient
Public Class solicitud_productos_fabricacion
    Private Sub solicitud_productos_fabricacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formatear_fechas()
        preparar_datagrid()
        Me.comentamotivo.Enabled = False
        Me.Label7.Visible = False

    End Sub
    Sub formatear_fechas()
        fecha_solicitud.Format = DateTimePickerFormat.Custom
        fecha_solicitud.CustomFormat = "yyyy-MM-dd"
    End Sub
    Sub indicar_stock()
        Conexion.open()
        Dim dataadapter5 As MySqlDataAdapter
        Dim dataset5 As DataSet
        Dim sql5 As String = "SELECT * FROM materia_prima_existencias inner join materia_prima on materia_prima.codigo_mp=materia_prima_existencias.codigo_mp WHERE materia_prima.codigo_mp LIKE '" & Me.producto.Text & "' OR materia_prima.nombre_mp LIKE '" & Me.producto.Text & "'"
        dataadapter5 = New MySqlDataAdapter(sql5, Conexion.conn)
        dataset5 = New DataSet()
        dataadapter5.Fill(dataset5)
        If (dataset5.Tables(0).Rows.Count <> 0) Then
            Me.Label7.Visible = True
            Me.Label7.Text = "Stock Disponible: " + dataset5.Tables(0).Rows(0).Item(1).ToString()
            Me.Label7.ForeColor = Color.Red
            Me.cantidad.Maximum = dataset5.Tables(0).Rows(0).Item(1).ToString()
        End If
        Conexion.close()
    End Sub
    Sub quitar_de_inventario(ByVal codigo_mp, ByVal cantidad_mp)
        Conexion.open()
        Dim sql1 As String = "UPDATE materia_prima_existencias SET stock_mp=stock_mp-'" & cantidad_mp & "' where codigo_mp='" & codigo_mp & "'"
        Dim cmd2 As New MySqlCommand(sql1, Conexion.conn)
        Try
            cmd2.ExecuteNonQuery()
            kardex_mp.add_kardex_salida(codigo_mp, cantidad_mp)
        Catch ex As Exception
            MessageBox.Show(ex.Message + " quitar_inventario()")
        End Try
        Conexion.close()
    End Sub

    Sub nueva_orden_salida()

        For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
            Conexion.open()
            Dim sqlquery1 As String = "INSERT INTO libro_salida_mp (id_salida, codigo_mp,fecha_salida,cantidad_salida,motivo,comentario)VALUES('" & Me.num_salida.Text & "', '" & CInt(Me.DataGridView1.Rows(i).Cells(0).Value.ToString()) & "' , '" & Me.fecha_solicitud.Text & "', '" & Me.Label10.Text & "','" & Me.motivo.SelectedItem & "','" & Me.comentamotivo.Text & "')"
            Dim cmd3 As New MySqlCommand(sqlquery1, Conexion.conn)
            Try
                cmd3.ExecuteNonQuery()
                quitar_de_inventario(CInt(Me.DataGridView1.Rows(i).Cells(0).Value.ToString()), CInt(Me.DataGridView1.Rows(i).Cells(2).Value.ToString()))
            Catch ex As Exception
                MessageBox.Show(ex.Message + " nueva_orden_salida()")
            End Try
            Conexion.close()
        Next
        MessageBox.Show("Solicitud salida Guardada con exito", "Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

    End Sub
    Sub preparar_datagrid()
        Dim col0, col1, col2, col3 As New DataGridViewTextBoxColumn
        Me.KeyPreview = True
        col0.Name = "Codigo"
        DataGridView1.Columns.Add(col0)
        col1.Name = "Producto"
        DataGridView1.Columns.Add(col1)
        col2.Name = "Cantidad"
        DataGridView1.Columns.Add(col2)
        col3.Name = "Unidad de Medida"
        DataGridView1.Columns.Add(col3)
    End Sub
    Sub cargar_mp_datagrid()
        Conexion.open()
        Dim dataadapter4 As MySqlDataAdapter
        Dim dataset4 As DataSet
        Dim sql4 As String = "SELECT * FROM materia_prima WHERE codigo_mp LIKE'" & Me.producto.Text & "' OR nombre_mp LIKE'" & Me.producto.Text & "'"
        dataadapter4 = New MySqlDataAdapter(sql4, Conexion.conn)
        dataset4 = New DataSet()
        dataadapter4.Fill(dataset4)
        If (dataset4.Tables(0).Rows.Count <> 0) Then
            DataGridView1.Rows.Add(New String() {dataset4.Tables(0).Rows(0).Item(0).ToString(), dataset4.Tables(0).Rows(0).Item(1).ToString(), Me.cantidad.Value, dataset4.Tables(0).Rows(0).Item(4).ToString()})
            Me.Label8.Text = dataset4.Tables(0).Rows(0).Item(0).ToString()
            Me.Label10.Text = Me.cantidad.Value
        End If
        Conexion.close()
    End Sub

    Private Sub producto_LostFocus(sender As Object, e As EventArgs) Handles producto.LostFocus
        Conexion.open()
        If Me.producto.Text <> "" Then

            Dim dataadapter3 As MySqlDataAdapter
            Dim dataset3 As DataSet
            Dim sql3 As String = "SELECT * FROM materia_prima WHERE codigo_mp LIKE'" & Me.producto.Text & "' OR nombre_mp LIKE'" & Me.producto.Text & "'"
            dataadapter3 = New MySqlDataAdapter(sql3, Conexion.conn)
            dataset3 = New DataSet()
            dataadapter3.Fill(dataset3)
            If (dataset3.Tables(0).Rows.Count <> 0) Then
                Me.umedida.Text = dataset3.Tables(0).Rows(0).Item(4).ToString()
                indicar_stock()
            Else
                Dim opcion As DialogResult = MessageBox.Show("El producto Ingresado no es Valido", "Error")
                Me.producto.Text = ""
                Me.producto.Focus()


            End If


        End If
        Conexion.close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cargar_mp_datagrid()
        Me.producto.Text = ""
        Me.cantidad.Text = " 0 "
        Me.umedida.Text = ""
        Me.producto.Focus()
    End Sub

    Private Sub motivo_LostFocus(sender As Object, e As EventArgs) Handles motivo.LostFocus
        If Me.motivo.Text <> "" And Me.motivo.Text = "Otro" Then
            Me.comentamotivo.Enabled = True
            Me.comentamotivo.Focus()
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        nueva_orden_salida()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class