Imports MySql.Data.MySqlClient
Public Class proceso_de_fabricacion
    Private Sub proceso_de_fabricacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formatear_fechas()
        preparar_datagrid()
    End Sub
    Sub formatear_fechas()
        fechaconsulta.Format = DateTimePickerFormat.Custom
        fechaconsulta.CustomFormat = "yyyy-MM-dd"
    End Sub
 
    Sub preparar_datagrid()
        Dim col1, col2, col3, col4 As New DataGridViewTextBoxColumn
        Me.KeyPreview = True
        col1.Name = "Numero de Salida "
        DataGridView1.Columns.Add(col1)
        col2.Name = "Fecha de Inicio de Fabricacion"
        DataGridView1.Columns.Add(col2)
        col3.Name = "Estado"
        DataGridView1.Columns.Add(col3)
        col4.Name = "Fecha Estimada de Finalizacion"
        DataGridView1.Columns.Add(col4)
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

    End Sub
End Class