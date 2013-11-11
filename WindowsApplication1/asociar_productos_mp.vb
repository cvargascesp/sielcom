Imports MySql.Data.MySqlClient
Public Class asociar_productos_mp
    Dim ds As New DataSet()
    Sub load_onfields_material()
        'carga datos del producto a fabricar en los textbox
        Conexion.open()
        Dim dataadapter As MySqlDataAdapter
        Dim dataset As DataSet
        Dim sqlquery As String = "SELECT nombre_mp, unidad_medida_mp FROM materia_prima WHERE codigo_mp='" & Me.txtidmaterial.Text & "'"
        dataadapter = New MySqlDataAdapter(sqlquery, Conexion.conn)
        dataset = New DataSet()
        dataadapter.Fill(dataset)
        If (dataset.Tables(0).Rows.Count <> 0) Then
            Me.txtnommaterial.Text = dataset.Tables(0).Rows(0).Item(0).ToString()
            Me.txtumedmat.Text = dataset.Tables(0).Rows(0).Item(1).ToString()
        Else
            MessageBox.Show("ha ocurrido un error load_onfields_material()", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Conexion.close()
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
    End Sub
    Sub inicializar_datagrid()
        ds.Tables.Clear()
        Conexion.open()
        Dim query As String = "SELECT producto_fabricado_materia_prima.codigo_mp'Codigo material',materia_prima.nombre_mp'nombre material',cant_empleada'Cantidad' FROM producto_fabricado_materia_prima INNER JOIN materia_prima ON materia_prima.codigo_mp=producto_fabricado_materia_prima.codigo_mp WHERE producto_fabricado_materia_prima.id_profab='" & Me.TextBox1.Text & "'"
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
    End Sub
    Sub limpiar_ingredientes_producto()
        Conexion.open()
        Dim sql As String = "DELETE FROM producto_fabricado_materia_prima WHERE id_profab='" & Me.TextBox1.Text & "'"
        Dim cmd As New MySqlCommand(sql, Conexion.conn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Conexion.close()
    End Sub
    Private Sub asociar_productos_mp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        load_onfields()
        inicializar_datagrid()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        load_onfields_material()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'insert into datagridview with datasource bounded
        Dim NewRow As DataRow
        NewRow = ds.Tables("Emp").NewRow
        NewRow("Codigo material") = Me.txtidmaterial.Text
        NewRow("nombre material") = Me.txtnommaterial.Text
        NewRow("Cantidad") = Me.txtcantmat.Value
        ds.Tables("Emp").Rows.Add(NewRow)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        limpiar_ingredientes_producto()
        Conexion.open()
        For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
            Dim sql As String = "INSERT INTO producto_fabricado_materia_prima VALUES ('" & Me.TextBox1.Text & "', '" & DataGridView1.Item(0, i).Value & "','" & DataGridView1.Item(2, i).Value & "')"
            Dim cmd As New MySqlCommand(sql, Conexion.conn)
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Next
        MessageBox.Show("Materiales Editados Exitosamente", "Editado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Conexion.close()
    End Sub
End Class