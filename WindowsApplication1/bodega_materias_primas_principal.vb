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

<<<<<<< HEAD
    Private Sub Button2h_Click(sender As Object, e As EventArgs) Handles Button2.Click
        libro_ingreso_mercaderia.Show()
=======
    Private Sub FamiliasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FamiliasToolStripMenuItem.Click
        i_familias.Show()
    End Sub

    Private Sub UnidadDeMedidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnidadDeMedidaToolStripMenuItem.Click
        i_unidadmedida.Show()
>>>>>>> 21e51fc7a130c276928d9abdc559fd3770edab20
    End Sub
End Class