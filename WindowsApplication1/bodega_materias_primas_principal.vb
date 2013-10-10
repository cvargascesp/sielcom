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
End Class