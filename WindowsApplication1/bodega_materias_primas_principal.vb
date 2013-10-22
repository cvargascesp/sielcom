Public Class bodega_materias_primas_principal

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
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


    Private Sub Button2h_Click(sender As Object, e As EventArgs) Handles Button2.Click
        libro_ingreso_mercaderia.Show()
    End Sub
    Private Sub FamiliasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FamiliasToolStripMenuItem.Click
        i_familias.Show()
    End Sub

    Private Sub UnidadDeMedidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnidadDeMedidaToolStripMenuItem.Click
        i_unidadmedida.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        i_libro_pedido.Show()
    End Sub

    Private Sub OrdenesDeCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenesDeCompraToolStripMenuItem.Click
        Libro_pedidos.Show()
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

    End Sub
End Class