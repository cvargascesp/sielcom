Imports MySql.Data.MySqlClient
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO

Public Class i_stock

    Private Sub i_stock_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub

    Private Sub i_stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarDatos()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CargarDatos()

        Try
            Conexion.open()

            Dim sql As String = "select codigo,nombre,marca,ubicacion,stock-porvender stock,critico, porllegar from producto "
            Dim Ds As New DataSet
            Dim Da As New MySqlDataAdapter(sql, Conexion.conn)

            Da.Fill(Ds, "stock")
            With Me.DataGridView1
                .DataSource = Ds.Tables("stock").DefaultView
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

            Dim filename As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\ReporteStock_" + Now.Date + ".pdf"

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

        Dim texto As New Phrase("Stock al:" + Now.Date(), New Font(Font.Name = "Tahoma", 14, Font.Bold))

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

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class