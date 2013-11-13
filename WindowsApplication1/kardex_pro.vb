Imports MySql.Data.MySqlClient
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Core
Imports System.IO


Public Class kardex_pro


    Sub formato_datetimepicker()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy-MM-dd"

    End Sub

    Public Sub kardexpro_salida(ByVal codigopro As String, ByVal cantidadpro_saliente As Integer)
        If (get_saldopro(codigopro) = 0) Then
            inic_kardex_pro(codigopro)
        End If

        Dim sqlquery As String = "INSERT INTO kardexpro(fecha_karpro,codigo_pro,usr_karpro,entra_karpro,sale_karpro,saldo_karpro,coment_karpro) VALUES (curdate(),'" & codigopro & "','" & login.MaskedTextBox1.Text & "', '0','" & cantidadpro_saliente & "','" & get_saldopro(codigopro) - cantidadpro_saliente & "','')"
        Dim cmd As New MySqlCommand(sqlquery, Conexion.conn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message + " Agregar_kardexpro()")
        End Try


    End Sub
    Public Sub agregar_kardexpro(ByVal codigopro As String, ByVal cantpro_entrante As Integer)
        If (get_saldopro(codigopro) = 0) Then
            inic_kardex_pro(codigopro)
        End If
        Conexion.open()
        Dim sqlquery As String = "INSERT INTO kardexpro(fecha_karpro,codigo_pro,usr_karpro,entra_karpro,sale_karpro,saldo_karpro,coment_karpro) VALUES (curdate(),'" & codigopro & "','" & login.MaskedTextBox1.Text & "', '" & cantpro_entrante & "','0','" & get_saldopro(codigopro) + cantpro_entrante & "','')"
        Dim cmd As New MySqlCommand(sqlquery, Conexion.conn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message + " Agregar_kardexpro()")
        End Try
        Conexion.close()
    End Sub

    Public Function get_saldopro(ByVal codigopro As String)
        Conexion.open()
        Dim dataadapter3 As MySqlDataAdapter
        Dim dataset3 As DataSet
        Dim sql3 As String = "SELECT saldo_karpro FROM kardexpro WHERE codigo_pro='" & codigopro & "' ORDER BY id_karpro DESC LIMIT 1 "
        dataadapter3 = New MySqlDataAdapter(sql3, Conexion.conn)
        dataset3 = New DataSet()
        dataadapter3.Fill(dataset3)
        If (dataset3.Tables(0).Rows.Count <> 0) Then
            Return (dataset3.Tables(0).Rows(0).Item(0).ToString())
        Else
            Return 0
        End If
        Conexion.close()
    End Function
    Public Sub inic_kardex_pro(ByVal codigo_pro As String)
        Conexion.open()
        Dim query_inic As String = "INSERT INTO kardexpro(fecha_karpro,codigo_pro,usr_karpro,entra_karpro,sale_karpro,saldo_karpro,coment_karpro) VALUES (curdate(),'" & codigo_pro & "','" & login.MaskedTextBox1.Text & "', '0','0','0','inic')"
        Dim cmd2 As New MySqlCommand(query_inic, Conexion.conn)
        Try
            cmd2.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message + " inic_kardex_pro()")
        End Try
        Conexion.close()
    End Sub
    Private Sub kardex_pro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formato_datetimepicker()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Conexion.open()
        Dim query As String = "SELECT fecha_karpro'Fecha',producto.codigo'codigo',producto.nombre 'Producto',producto.marca'marca',usuario.nombre'Usuario', entra_karpro'Entra',sale_karpro'Sale',saldo_karpro'Saldo',coment_karpro'Observacion' FROM kardexpro INNER JOIN producto ON producto.codigo=kardexpro.codigo_pro INNER JOIN usuario ON usuario.run=kardexpro.usr_karpro where kardexpro.codigo_pro='" & Me.TextBox1.Text & "' and fecha_karpro BETWEEN'" & Me.DateTimePicker1.Text & "' and '" & Me.DateTimePicker2.Text & "'  "
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.ActiveSheet



        For i = 0 To DataGridView1.RowCount - 1
            For j = 0 To DataGridView1.ColumnCount - 1
                For k As Integer = 1 To DataGridView1.Columns.Count
                    xlWorkSheet.Cells(1, k) = DataGridView1.Columns(k - 1).HeaderText
                    xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1(j, i).Value.ToString()
                Next
            Next
        Next

        Try
            xlWorkSheet.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + CStr("\kardex_productos.xlsx"))
            MessageBox.Show("El archivo se guardo en: " + (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) + CStr("\kardex_productos.xlsx"), "Exportacion", MessageBoxButtons.OK, MessageBoxIcon.Question)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)


    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Class