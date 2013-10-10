Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Public Class factura
    Dim ds As New DataSet
    Private Sub factura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Conexion.open()
        Label9.Text = ""
        'carga listbox codigo
        Try
            Dim sql2 As String = "select t.codigo, t.cantidad, p.nombre, p.marca, p.modelo, p.descripcion, t.precioventa, t.total from ticketdetalle t join producto p on(t.codigo=p.codigo) where numdocu='" & Label19.Text & "'"
            Dim da As New MySqlDataAdapter(sql2, Conexion.conn)
            da.Fill(ds, "detalles")
            
            ''carga listbox descripcion
            'Dim sql2 As String
            'Dim cn2 As MySqlConnection
            'Dim cm2 As MySqlCommand
            'Dim dr2 As MySqlDataReader
            'cn2 = New MySqlConnection(Conexion.strConn)
            'cn2.Open()
            'sql2 = "select descripcion from ticket where numdocu='" & Label19.Text & "'"
            'cm2 = New MySqlCommand()
            'cm2.CommandText = sql2
            'cm2.CommandType = CommandType.Text
            'cm2.Connection = cn2
            'dr2 = cm2.ExecuteReader()
            'While dr2.Read()
            '    ListBox2.Items.Add(CStr(dr2("descripcionpro")))
            'End While
            'cn2.Close()


            'carga listbox cantidad

            'Dim cn2 As MySqlConnection
            'cn2 = New MySqlConnection(Conexion.strConn)
            'cn2.Open()
            'sql2 = "select cantidad from ticketdetalle where numdocu='" & Label19.Text & "'"
            'cm2 = New MySqlCommand()
            'cm2.CommandText = sql2
            'cm2.CommandType = CommandType.Text
            'cm2.Connection = cn2
            'dr2 = cm2.ExecuteReader()
            'While dr2.Read()
            '    ListBox3.Items.Add(CStr(dr2("cantidadpro")))
            'End While
            'cn2.Close()


            ''carga listbox precio unitario

            'cn2 = New MySqlConnection(Conexion.strConn)
            'cn2.Open()
            'sql2 = "select precioventa from ticketdetalle where numdocu='" & Label19.Text & "'"
            'cm2 = New MySqlCommand()
            'cm2.CommandText = sql2
            'cm2.CommandType = CommandType.Text
            'cm2.Connection = cn2
            'dr2 = cm2.ExecuteReader()
            'While dr2.Read()
            '    ListBox4.Items.Add(CStr(dr2("preciopro")))
            'End While
            'cn2.Close()


            ''carga listbox total

            'cn2 = New MySqlConnection(Conexion.strConn)
            'cn2.Open()
            'sql2 = "select total from ticket where numdocu='" & Label19.Text & "'"
            'cm2 = New MySqlCommand()
            'cm2.CommandText = sql2
            'cm2.CommandType = CommandType.Text
            'cm2.Connection = cn2
            'dr2 = cm2.ExecuteReader()
            'While dr2.Read()
            '    ListBox5.Items.Add(CStr(dr2("total")))
            'End While
            'cn2.Close()
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        Conexion.close()

        If My.Settings.imp_facturas <> "" Then
            PrintDocument1.PrinterSettings.PrinterName = My.Settings.imp_facturas
        End If
        PrintDocument1.Print()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'PrintPreviewDialog1.Document = PrintDocument1 'PrintPreviewDialog associate with PrintDocument.
        'PrintPreviewDialog1.ShowDialog() 'open the print preview

    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' La fuente a usar
        Dim prFont1 As New Font("Arial", 15, FontStyle.Bold)
        Dim prFont2 As New Font("Arial", 8)
        ' imprimimos la cadena
        e.Graphics.DrawString(Label6.Text, prFont2, Brushes.Black, 610, 105)
        e.Graphics.DrawString(Label1.Text, prFont2, Brushes.Black, 110, 200)
        e.Graphics.DrawString(Label2.Text, prFont2, Brushes.Black, 110, 228)
        e.Graphics.DrawString(Label3.Text, prFont2, Brushes.Black, 110, 255)
        e.Graphics.DrawString(Label4.Text, prFont2, Brushes.Black, 110, 284)
        e.Graphics.DrawString(Label5.Text, prFont2, Brushes.Black, 323, 290)
        e.Graphics.DrawString(Label18.Text, prFont2, Brushes.Black, 385, 290)
        e.Graphics.DrawString(Label7.Text, prFont2, Brushes.Black, 665, 260)
        e.Graphics.DrawString(Label8.Text, prFont2, Brushes.Black, 200, 345)
        e.Graphics.DrawString(Label9.Text, prFont2, Brushes.Black, 165, 380)

        'DETALLE
        Dim r As DataRow
        Dim x As Integer = 450
        For i = 0 To ds.Tables("detalles").Rows.Count - 1
            r = ds.Tables("detalles").Rows(i)
            e.Graphics.DrawString(r.Item("codigo"), prFont2, Brushes.Black, 30, x)

            e.Graphics.DrawString(r.Item("nombre"), prFont2, Brushes.Black, 110, x)
            e.Graphics.DrawString(r.Item("cantidad"), prFont2, Brushes.Black, 550, x)
            e.Graphics.DrawString(r.Item("precioventa"), prFont2, Brushes.Black, 630, x)
            e.Graphics.DrawString(r.Item("total"), prFont2, Brushes.Black, 710, x)
            x = x + 10
        Next

        e.Graphics.DrawString(Label10.Text, prFont2, Brushes.Black, 75, 880)
        e.Graphics.DrawString(Label11.Text, prFont2, Brushes.Black, 75, 950)
        e.Graphics.DrawString(Label12.Text, prFont2, Brushes.Black, 75, 965)
        e.Graphics.DrawString(Label13.Text, prFont2, Brushes.Black, 388, 950)
        e.Graphics.DrawString(Label14.Text, prFont2, Brushes.Black, 295, 965)
        e.Graphics.DrawString(Label15.Text, prFont2, Brushes.Black, 705, 905)
        e.Graphics.DrawString(Label16.Text, prFont2, Brushes.Black, 705, 950)
        e.Graphics.DrawString(Label17.Text, prFont2, Brushes.Black, 705, 995)
        ' indicamos que ya no hay nada más que imprimir
        ' (el valor predeterminado de esta propiedad es False)
        e.HasMorePages = False

        Me.Close()
    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label19.Click

    End Sub
End Class