Imports MySql.Data.MySqlClient
Public Class bodega_materias_primas_principal

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Volver?", "Volver", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            Me.Close()
            inicio.Show()
        End If
    End Sub

    Private Sub AgregarMateriaPrimaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarMateriaPrimaToolStripMenuItem.Click
        agregar_materia_prima.Show()
    End Sub
    Private Sub FamiliasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FamiliasToolStripMenuItem.Click
        i_familias.Show()
    End Sub

    Private Sub UnidadDeMedidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnidadDeMedidaToolStripMenuItem.Click
        i_unidadmedida.Show()

    End Sub





    Private Sub PcesoDeFabricacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PcesoDeFabricacionToolStripMenuItem.Click

    End Sub

    Private Sub SolicitudDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SolicitudDeProductosToolStripMenuItem.Click
        solicitud_productos_fabricacion.Show()

    End Sub

    Private Sub ConsultaDeProcesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeProcesoToolStripMenuItem.Click
        proceso_de_fabricacion.Show()
    End Sub

    Private Sub IngresarProductosAFabricacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresarProductosAFabricacionToolStripMenuItem.Click
        ifabricacion.Show()
    End Sub

    Private Sub EditarProcesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarProcesoToolStripMenuItem.Click
        e_proceso_fabricacion.Show()
    End Sub

    Private Sub EditarMateriaPrimaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarMateriaPrimaToolStripMenuItem.Click
        e_materia_prima.Show()
    End Sub

    Private Sub CatalogoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CatalogoToolStripMenuItem.Click
        catalogo_mp.Show()
    End Sub


    Private Sub KardexToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KardexToolStripMenuItem.Click
        kardex_mp.Show()
    End Sub

    Private Sub OrdenesDeCompraToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OrdenesDeCompraToolStripMenuItem1.Click
        Libro_pedidos.Show()
    End Sub

    Private Sub LibroDePedidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LibroDePedidosToolStripMenuItem.Click
        i_libro_pedido.Show()
    End Sub

    Private Sub LibroDeRecepcionDeMercaderiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LibroDeRecepcionDeMercaderiaToolStripMenuItem.Click
        libro_ingreso_mercaderia.Show()
    End Sub

    
    Sub llenar_datagrid_stock_critico()
        Conexion.open()
        Dim query As String = "SELECT 	materia_prima.codigo_mp 'Codigo materia Prima', materia_prima.nombre_mp 'nombre', materia_prima.unidad_medida_mp'Unidad de medida', familias.nom_familia'Familia', COALESCE(materia_prima_existencias.stock_mp,0)'stock Actual', materia_prima.stock_critico_mp'Stock Critico'FROM materia_prima LEFT JOIN materia_prima_existencias ON materia_prima_existencias.codigo_mp=materia_prima.codigo_mp INNER JOIN familias ON familias.idfamilia=materia_prima.idfamilia  WHERE COALESCE(materia_prima_existencias.stock_mp,0)<= materia_prima.stock_critico_mp"
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
    End Sub

    Private Sub bodega_materias_primas_principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_datagrid_stock_critico()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        inicio.Show()
    End Sub

    Private Sub NuevoProductoAFabricarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoProductoAFabricarToolStripMenuItem.Click
        i_productofabricado.Show()
    End Sub

    Private Sub AsociarIngredientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsociarIngredientesToolStripMenuItem.Click
        asociar_productos_mp.Show()
    End Sub

    Private Sub SacarDeBodegaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SacarDeBodegaToolStripMenuItem.Click
        solicitud_productos_fabricacion2.Show()
    End Sub
End Class