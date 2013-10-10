Public Class bodega_general

    Private Sub bodega_general_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bodega_compraventa.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        bodega_materias_primas_principal.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Volver?", "Volver", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            Me.Close()
            inicio.Show()
        End If
    End Sub
End Class