Public Class Configuraciones

    Private Sub Configuraciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Configuraciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtIva.Text = My.Settings.iva
        txtFacturera.Text = My.Settings.imp_facturas
        txtTicket.Text = My.Settings.imp_tickets
        txtCotizaciones.Text = My.Settings.imp_cotizaciones
    End Sub

    Private Sub txtIva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIva.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> vbBack Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        My.Settings.iva = txtIva.Text
        My.Settings.imp_facturas = txtFacturera.Text
        My.Settings.imp_tickets = txtTicket.Text
        My.Settings.imp_cotizaciones = txtCotizaciones.Text
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtFacturera_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFacturera.DoubleClick
        PrintDialog1.ShowDialog()
        txtFacturera.Text = PrintDialog1.PrinterSettings.PrinterName
    End Sub

    Private Sub txtTicket_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTicket.DoubleClick
        PrintDialog1.ShowDialog()
        txtTicket.Text = PrintDialog1.PrinterSettings.PrinterName
    End Sub

    Private Sub txtCotiaciones_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtCotizaciones.DoubleClick
        PrintDialog1.ShowDialog()
        txtCotizaciones.Text = PrintDialog1.PrinterSettings.PrinterName
    End Sub
End Class