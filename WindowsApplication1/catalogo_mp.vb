Imports MySql.Data.MySqlClient
Public Class catalogo_mp
    Sub llenar_datagridview()
        Conexion.open()
        Dim query As String = "SELECT 	materia_prima.codigo_mp 'Codigo materia Prima', materia_prima.nombre_mp 'nombre', materia_prima.fecha_creacion_mp'Fecha de creacion', materia_prima.ubicacion_mp'Ubicacion', materia_prima.unidad_medida_mp'Unidad de medida', familias.nom_familia'Familia', COALESCE(materia_prima_existencias.stock_mp,0)'stock Actual', materia_prima.stock_critico_mp'Stock Critico'FROM materia_prima LEFT JOIN materia_prima_existencias ON materia_prima_existencias.codigo_mp=materia_prima.codigo_mp INNER JOIN familias ON familias.idfamilia=materia_prima.idfamilia"
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
    End Sub
    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
            If (Me.DataGridView1.Rows(i).Cells("stock Actual").Value - Me.DataGridView1.Rows(i).Cells("Stock Critico").Value) < 0 Then
                Me.DataGridView1.Rows(i).Cells("stock Actual").Style.ForeColor = Color.Red
            End If
            If (Me.DataGridView1.Rows(i).Cells("stock Actual").Value - Me.DataGridView1.Rows(i).Cells("Stock Critico").Value) = 0 Then
                Me.DataGridView1.Rows(i).Cells("stock Actual").Style.ForeColor = Color.YellowGreen
            End If
            If (Me.DataGridView1.Rows(i).Cells("stock Actual").Value - Me.DataGridView1.Rows(i).Cells("Stock Critico").Value) > 0 Then
                Me.DataGridView1.Rows(i).Cells("stock Actual").Style.ForeColor = Color.Green
            End If
        Next

    End Sub
    Private Sub catalogo_mp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_datagridview()
    End Sub
End Class