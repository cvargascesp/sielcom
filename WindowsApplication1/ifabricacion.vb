Imports MySql.Data.MySqlClient
Public Class ifabricacion

    Private Sub ifabricacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formatear_fechas()
        preparar_datagrid()
    End Sub

    Sub formatear_fechas()
        Fecha_inicio.Format = DateTimePickerFormat.Custom
        Fecha_inicio.CustomFormat = "yyyy-MM-dd"
        fechatermino.Format = DateTimePickerFormat.Custom
        fechatermino.CustomFormat = "yyyy-MM-dd"
    End Sub
    Sub preparar_datagrid()
        Dim col1, col2, col3, col4 As New DataGridViewTextBoxColumn
        Me.KeyPreview = True
        col1.Name = "Codigo de Producto "
        DataGridView1.Columns.Add(col1)
        col2.Name = "Nombre de Producto"
        DataGridView1.Columns.Add(col2)
        col3.Name = "Cantidad"
        DataGridView1.Columns.Add(col3)
        col4.Name = "Unidad de Medida"
        DataGridView1.Columns.Add(col4)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        bodega_materias_primas_principal.Show()
    End Sub

    Private Sub VolverToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VolverToolStripMenuItem.Click
        bodega_materias_primas_principal.Show()
    End Sub


    
End Class