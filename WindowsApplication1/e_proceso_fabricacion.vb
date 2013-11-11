Imports MySql.Data.MySqlClient

Public Class e_proceso_fabricacion
    Public nombre_producto_fab As String
    Private Sub e_proceso_fabricacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formatear_fechas()
        Me.GroupBox2.Enabled = False
      
    End Sub
    Sub formatear_fechas()
        fecha_solicitud.Format = DateTimePickerFormat.Custom
        fecha_solicitud.CustomFormat = "yyyy-MM-dd"
        fecha_i.Format = DateTimePickerFormat.Custom
        fecha_i.CustomFormat = "yyyy-MM-dd"
        fecha_t.Format = DateTimePickerFormat.Custom
        fecha_t.CustomFormat = "yyyy-MM-dd"
    End Sub
    Sub llenar_combobox_estado()
        Dim ssql As String = "SELECT * FROM estados_de_produccion"
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(ssql, Conexion.conn)
        Try
            Dim actual As String = Me.estado_fab.Text
            da.Fill(ds)
            Me.estado_fab.DataSource = ds.Tables(0)
            Me.estado_fab.DisplayMember = "nom_est_pro"
            Me.estado_fab.ValueMember = "id_est_pro"
            Me.estado_fab.SelectedValue = actual
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub limpiar_formulario()
        Me.n_fabricacion_c.Text = ""
        Me.cod_fab.Text = ""
        Me.prod_fab.Text = ""
        Me.estado_fab.Text = ""
        Me.fecha_i.Text = ""
        Me.fecha_solicitud.Text = ""
        Me.fecha_t.Text = ""
        Me.GroupBox2.Enabled = False
        Me.n_fabricacion_c.Focus()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        llenar_combobox_estado()
        Me.GroupBox2.Enabled = True
        Me.fecha_i.Enabled = False
        'carga de datos
        Conexion.open()
        Dim dataadapter As MySqlDataAdapter
        Dim dataset As DataSet
        Dim sqlquery As String = "SELECT proceso_fabricacion.id_fab, producto_fabricado.nom_profab, proceso_fabricacion.id_salida, proceso_fabricacion.fecha_inicio_fab, proceso_fabricacion.fecha_termino_fab, proceso_fabricacion.id_est_pro, estados_de_produccion.nom_est_pro FROM proceso_fabricacion INNER JOIN estados_de_produccion ON estados_de_produccion.id_est_pro=proceso_fabricacion.id_est_pro INNER JOIN producto_fabricado ON producto_fabricado.id_profab=proceso_fabricacion.id_profab WHERE id_fab='" & Me.n_fabricacion_c.Text & "'"
        dataadapter = New MySqlDataAdapter(sqlquery, Conexion.conn)
        dataset = New DataSet()
        dataadapter.Fill(dataset)
        If (dataset.Tables(0).Rows.Count <> 0) Then
            Me.cod_fab.Text = dataset.Tables(0).Rows(0).Item(0).ToString()
            Me.prod_fab.Text = dataset.Tables(0).Rows(0).Item(1).ToString()
            Me.fecha_i.Value = dataset.Tables(0).Rows(0).Item(3).ToString()
            Me.fecha_t.Value = dataset.Tables(0).Rows(0).Item(4).ToString()
            Me.estado_fab.SelectedText = dataset.Tables(0).Rows(0).Item(6).ToString()
            Me.estado_fab.SelectedValue = CInt(dataset.Tables(0).Rows(0).Item(5))
        Else
            MessageBox.Show("el numero de fabricacion es invalido", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Conexion.close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        bodega_materias_primas_principal.Show()
    End Sub
    Sub enviar_nuevo_producto()
        If (estado_fab.Text = "Terminado" Or estado_fab.Text = "terminado" Or estado_fab.Text = "TERMINADO") Then
            nombre_producto_fab = CStr(Me.prod_fab.Text)
            MessageBox.Show(nombre_producto_fab)
            Me.Hide()
            n_producto.Show()
        End If


    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar_formulario()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Conexion.open()
        Dim query_update = "UPDATE proceso_fabricacion SET fecha_termino_fab='" & Me.fecha_t.Text & "', id_est_pro='" & Me.estado_fab.SelectedValue & "'    WHERE id_fab ='" & Me.n_fabricacion_c.Text & "'"
        Dim cmd As New MySqlCommand(query_update, Conexion.conn)
        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("Datos modificados exitosamente", "guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        enviar_nuevo_producto()
        Conexion.close()
        limpiar_formulario()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class