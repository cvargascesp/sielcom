Imports MySql.Data.MySqlClient
Public Class solicitud_productos_fabricacion2
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
            Dim sqlquery1 As String = "INSERT INTO libro_salida_mp (id_salida, codigo_mp,fecha_salida,cantidad_salida,motivo,comentario)VALUES('" & Me.txtordensalida.Text & "', '" & CInt(Me.DataGridView1.Rows(i).Cells(1).Value.ToString()) & "' , '" & Me.fecha_salida.Text & "', '" & CInt(Me.DataGridView1.Rows(i).Cells(3).Value.ToString()) & "','" & Me.Combomotivo.SelectedItem & "','" & Me.txtcomentario.Text & "')"
            Dim cmd3 As New MySqlCommand(sqlquery1, Conexion.conn)
            Try
                cmd3.ExecuteNonQuery()
                quitar_de_inventario(CInt(Me.DataGridView1.Rows(i).Cells(1).Value.ToString()), CInt(Me.DataGridView1.Rows(i).Cells(3).Value.ToString()))
            Catch ex As Exception
                MessageBox.Show(ex.Message + " nueva_orden_salida()")
            End Try
            Conexion.close()
        Next
        MessageBox.Show("Solicitud salida Guardada con exito", "Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

    End Sub

    Function get_idsalida()
        Conexion.open()
        Dim dataadapter As MySqlDataAdapter
        Dim dataset As DataSet
        Dim sqlquery As String = "SELECT id_salida + 1 'nueva_salida' FROM libro_salida_mp ORDER BY id_salida DESC LIMIT 1"
        dataadapter = New MySqlDataAdapter(sqlquery, Conexion.conn)
        dataset = New DataSet()
        dataadapter.Fill(dataset)
        If (dataset.Tables(0).Rows.Count <> 0) Then
            Return dataset.Tables(0).Rows(0).Item(0).ToString()
        Else
            Return 0
        End If
        Conexion.close()
    End Function
    Sub formatear_fechas()
        fecha_salida.Format = DateTimePickerFormat.Custom
        fecha_salida.CustomFormat = "yyyy-MM-dd"
        fecha_salida.Visible = False
    End Sub
    Sub load_onfields()
        'carga datos del producto a fabricar en los textbox
        Conexion.open()
        Dim dataadapter As MySqlDataAdapter
        Dim dataset As DataSet
        Dim sqlquery As String = "SELECT nom_profab,umed_profab,familias.nom_familia FROM producto_fabricado left JOIN familias ON familias.idfamilia=producto_fabricado.id_profab WHERE id_profab='" & Me.TextBox1.Text & "'"
        dataadapter = New MySqlDataAdapter(sqlquery, Conexion.conn)
        dataset = New DataSet()
        dataadapter.Fill(dataset)
        If (dataset.Tables(0).Rows.Count <> 0) Then
            Me.txtnombre.Text = dataset.Tables(0).Rows(0).Item(0).ToString()
            Me.txtunidadmedida.Text = dataset.Tables(0).Rows(0).Item(1).ToString()
            Me.txtfamilia.Text = dataset.Tables(0).Rows(0).Item(2).ToString()
        Else
            Me.txtnombre.Text = ""
            Me.txtunidadmedida.Text = ""
            Me.txtfamilia.Text = ""
        End If
        Conexion.close()
        Me.cantfab.Enabled = True
    End Sub
    Function recorrer_datagrid()
        Dim contador As Integer
        For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
            If (DataGridView1.Item(4, i).Value.ToString() = "insuficiente") Then
                contador = contador + 1
            End If
        Next
        Return contador
    End Function
    Sub iniciar_datagrid()
        Conexion.open()
        Dim query As String = "SELECT id_profab'Codigo producto',producto_fabricado_materia_prima.codigo_mp'Codigo material',materia_prima.nombre_mp'Nombre material',(cant_empleada)'Cant a utilizar',stock_mp'Cantidad disponible',IF(stock_mp < (cant_empleada),'insuficiente','Suficiente')'Disponibilidad' FROM producto_fabricado_materia_prima LEFT JOIN materia_prima_existencias ON materia_prima_existencias.codigo_mp=producto_fabricado_materia_prima.codigo_mp  INNER JOIN materia_prima ON materia_prima.codigo_mp=producto_fabricado_materia_prima.codigo_mp WHERE id_profab='" & Me.TextBox1.Text & "'"
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
    End Sub
    Private Sub solicitud_productos_fabricacion2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Button2.Enabled = False
        Me.cantfab.Enabled = False
        formatear_fechas()
        Me.txtcomentario.Enabled = False
        Me.txtordensalida.Text = get_idsalida()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        load_onfields()
        iniciar_datagrid()
        If (recorrer_datagrid() >= 1) Then
            Me.Button2.Enabled = False
        Else
            Me.Button2.Enabled = True
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles cantfab.ValueChanged
        Conexion.open()
        Dim query As String = "SELECT id_profab'Codigo producto',producto_fabricado_materia_prima.codigo_mp'Codigo material',materia_prima.nombre_mp'Nombre material',(cant_empleada * '" & Me.cantfab.Value & "')'Cant a utilizar',stock_mp'Cantidad disponible',IF(stock_mp < (cant_empleada * '" & Me.cantfab.Value & "'),'insuficiente','Suficiente')'Disponibilidad' FROM producto_fabricado_materia_prima LEFT JOIN materia_prima_existencias ON materia_prima_existencias.codigo_mp=producto_fabricado_materia_prima.codigo_mp INNER JOIN materia_prima ON materia_prima.codigo_mp=producto_fabricado_materia_prima.codigo_mp WHERE id_profab='" & Me.TextBox1.Text & "'"
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
        If (recorrer_datagrid() >= 1) Then
            Me.Button2.Enabled = False
        Else
            Me.Button2.Enabled = True
        End If
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combomotivo.SelectedIndexChanged
        If (Combomotivo.Text = "Otro") Then
            txtcomentario.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        nueva_orden_salida()
    End Sub
End Class