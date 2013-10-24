Imports MySql.Data.MySqlClient
Public Class proceso_de_fabricacion
    Private Sub proceso_de_fabricacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formatear_fechas()
        llenar_datagrid()
    End Sub
    Sub formatear_fechas()
        fechaconsulta.Format = DateTimePickerFormat.Custom
        fechaconsulta.CustomFormat = "yyyy-MM-dd"
        fechaconsulta2.Format = DateTimePickerFormat.Custom
        fechaconsulta2.CustomFormat = "yyyy-MM-dd"
    End Sub
    Sub llenar_datagrid()
        Conexion.open()
        Dim query As String = "SELECT id_fab'Numero orden fabricacion',nombre_prod_fab'Nombre producto a fabricar',id_salida'orden de salida bodega', fecha_inicio_fab'Fecha inicio',fecha_termino_fab'fecha termino',IF(fecha_termino_fab-CURDATE()>=0,'OK','Atrasado')'Tiempo',estados_de_produccion.nom_est_pro'Estado de fabricacion' FROM proceso_fabricacion INNER JOIN estados_de_produccion ON estados_de_produccion.id_est_pro=proceso_fabricacion.id_est_pro"
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        bodega_materias_primas_principal.Show()
    End Sub

    Private Sub VolverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VolverToolStripMenuItem.Click
        bodega_materias_primas_principal.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        bodega_materias_primas_principal.Show()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Conexion.open()
        Dim query As String = "SELECT id_fab'Numero orden fabricacion',nombre_prod_fab'Nombre producto a fabricar',id_salida'orden de salida bodega', fecha_inicio_fab'Fecha inicio',fecha_termino_fab'fecha termino',IF(fecha_termino_fab-CURDATE()>=0,'OK','Atrasado')'Tiempo',estados_de_produccion.nom_est_pro'Estado de fabricacion' FROM proceso_fabricacion INNER JOIN estados_de_produccion ON estados_de_produccion.id_est_pro=proceso_fabricacion.id_est_pro WHERE (fecha_inicio_fab>='%" & Me.fechaconsulta.Text & "%' AND fecha_termino_fab<'%" & Me.fechaconsulta2.Text & "%') OR id_fab LIKE '%" & Me.txtid_sal.Value & "%'   OR id_salida LIKE '%" & Me.n_ordensalida.Text & "%'"
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
    End Sub

End Class