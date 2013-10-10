Imports MySql.Data.MySqlClient
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Public Class i_ranking

    Private Sub i_ranking_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub i_ranking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label4.Text = ""
        Label6.Text = ""

        'Cargar Combos
        Dim sql As String = "select distinct linea, linea dato from producto"
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(sql, Conexion.conn)
        da.Fill(ds, "lineas")

        Dim sql1 As String = "select distinct categoria, categoria dato from producto"
        Dim da1 As New MySqlDataAdapter(sql1, Conexion.conn)
        da1.Fill(ds, "categorias")

        Dim r As DataRow
        r = ds.Tables("lineas").NewRow
        r.Item("linea") = "TODAS"
        r.Item("dato") = "*"
        ds.Tables("lineas").Rows.InsertAt(r, 0)
        cbLinea.DataSource = ds.Tables("lineas")
        cbLinea.DisplayMember = "linea"
        cbLinea.ValueMember = "dato"


        r = ds.Tables("categorias").NewRow
        r.Item("categoria") = "TODAS"
        r.Item("dato") = "*"
        ds.Tables("categorias").Rows.InsertAt(r, 0)
        cbCategoria.DataSource = ds.Tables("categorias")
        cbCategoria.DisplayMember = "categoria"
        cbCategoria.ValueMember = "dato"
        'CargarDatos()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub DateTimePicker1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker1.TextChanged
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        Label4.Text = ""
        Label6.Text = ""

        Try
            Conexion.open()

            Dim ssql As String = "select p.linea, p.categoria, t.codigo, concat_ws(' ', p.nombre, p.marca, p.modelo) descripcion, count(t.codigo) cantidad, sum(b.total) venta from boleta b join ticketdetalle t on (b.numticket=t.numdocu) join producto p on(t.codigo=p.codigo)" &
                " where b.estado='EMITIDA' and fechadocu between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "'" &
                IIf(cbLinea.SelectedValue = "*", "", " and p.linea = '" & cbLinea.SelectedValue & "'") &
                IIf(cbCategoria.SelectedValue = "*", "", " and p.categoria = '" & cbCategoria.SelectedValue & "'") &
                " group by t.codigo order by cantidad desc"
            Dim Ds As New DataSet
            Dim Da As New MySqlDataAdapter(ssql, Conexion.conn)

            Da.Fill(Ds, "boleta")
            With Me.DataGridView1
                .DataSource = Ds.Tables("boleta").DefaultView
            End With

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.White
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue

            Conexion.close()
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try

            'Intentar generar el documento.

            Dim doc As New Document(PageSize.A4.Rotate(), 10, 10, 10, 10)

            'Path que guarda el reporte en el escritorio de windows (Desktop).

            Dim filename As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\ReporteVentas_" + Now.Date + ".pdf"

            Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)

            PdfWriter.GetInstance(doc, file)

            doc.Open()

            ExportarDatosPDF(doc)

            doc.Close()

            Process.Start(filename)

        Catch ex As Exception

            'Si el intento es fallido, mostrar MsgBox.

            MessageBox.Show("No se puede generar el documento PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
    Public Sub ExportarDatosPDF(ByVal document As iTextSharp.text.Document)

        'Se crea un objeto PDFTable con el numero de columnas del DataGridView.

        Dim datatable As New PdfPTable(DataGridView1.ColumnCount)

        'Se asignan algunas propiedades para el diseño del PDF.

        datatable.DefaultCell.Padding = 3

        Dim headerwidths As Single() = GetColumnasSize(DataGridView1)

        datatable.SetWidths(headerwidths)

        datatable.WidthPercentage = 100
        datatable.DefaultCell.BorderWidth = 2

        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER

        'Se crea el encabezado en el PDF.

        Dim encabezado As New Paragraph("Libreria.", New Font(Font.Name = "Tahoma", 20, Font.Bold))



        'Se crea el texto abajo del encabezado.

        Dim texto As New Phrase("Informe de Ventas:" + Now.Date(), New Font(Font.Name = "Tahoma", 14, Font.Bold))

        'Se capturan los nombres de las columnas del DataGridView.

        For i As Integer = 0 To DataGridView1.ColumnCount - 1

            datatable.AddCell(DataGridView1.Columns(i).HeaderText)

        Next

        datatable.HeaderRows = 1

        datatable.DefaultCell.BorderWidth = 1

        'Se generan las columnas del DataGridView.

        For i As Integer = 0 To DataGridView1.RowCount - 1

            For j As Integer = 0 To DataGridView1.ColumnCount - 1

                datatable.AddCell(DataGridView1(j, i).Value.ToString())

            Next

            datatable.CompleteRow()

        Next

        'Se agrega el PDFTable al documento.

        document.Add(encabezado)

        document.Add(texto)

        document.Add(datatable)

    End Sub
    Public Function GetColumnasSize(ByVal dg As DataGridView) As Single()

        Dim values As Single() = New Single(dg.ColumnCount - 1) {}

        For i As Integer = 0 To dg.ColumnCount - 1

            values(i) = CSng(dg.Columns(i).Width)

        Next

        Return values

    End Function

    Private Sub DateTimePicker2_TextChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker2.TextChanged
        CargarDatos()
    End Sub

    Private Sub cbLinea_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbLinea.SelectedIndexChanged
        CargarDatos()
    End Sub

    Private Sub cbCategoria_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbCategoria.SelectedIndexChanged
        CargarDatos()
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub
End Class