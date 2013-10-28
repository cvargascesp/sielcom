Imports MySql.Data.MySqlClient
Public Class libro_pedido_desglose
    Sub formato_datetimepicker()
        txtfechacreacion.Format = DateTimePickerFormat.Custom
        txtfechacreacion.CustomFormat = "yyyy-MM-dd"
        txtfechatope.Format = DateTimePickerFormat.Custom
        txtfechatope.CustomFormat = "yyyy-MM-dd"
        txtfechatope.Enabled = False
        txtfechacreacion.Enabled = False
    End Sub

    Sub get_detalle_ondatagrid()
        Conexion.open()
        Dim query As String = "SELECT id_ordencompramp'Numero de orden', materia_prima.nombre_mp'materia Prima',orden_compramp_detalle.cantidad_mp_oc'Cantidad' FROM orden_compramp_detalle INNER JOIN materia_prima ON materia_prima.codigo_mp=orden_compramp_detalle.codigo_mp WHERE id_ordencompramp='" & Libro_pedidos.buscar_libro_pedido & "'"
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
    End Sub
    Sub get_cabezera_ontextfields()
        Conexion.open()
        Dim dataadapter As MySqlDataAdapter
        Dim dataset As DataSet
        Dim sqlquery As String = "SELECT id_ordencompramp'Numero de orden',proveedor.nombre'Proveedor',orden_compramp_cabezera.fecha_creacion'Fecha de creacion',orden_compramp_cabezera.fecha_tope'Fecha Tope' FROM orden_compramp_cabezera  INNER JOIN proveedor ON proveedor.rut=orden_compramp_cabezera.rut WHERE orden_compramp_cabezera.id_ordencompramp='" & Libro_pedidos.buscar_libro_pedido & "'"
        dataadapter = New MySqlDataAdapter(sqlquery, Conexion.conn)
        dataset = New DataSet()
        dataadapter.Fill(dataset)
        If (dataset.Tables(0).Rows.Count <> 0) Then
            Me.txtnumpedido.Text = dataset.Tables(0).Rows(0).Item(0).ToString()
            Me.txtproveedor.Text = dataset.Tables(0).Rows(0).Item(1).ToString()
            Me.txtfechacreacion.Text = dataset.Tables(0).Rows(0).Item(2).ToString()
            Me.txtfechatope.Text = dataset.Tables(0).Rows(0).Item(3).ToString()
        End If
        Conexion.close()
    End Sub

    Private Sub libro_pedido_desglose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formato_datetimepicker()
        If (Not (IsNumeric(Libro_pedidos.buscar_libro_pedido))) Then
            MessageBox.Show("numero de pedido invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        Else
            get_detalle_ondatagrid()
            get_cabezera_ontextfields()
        End If
    End Sub
End Class