Imports MySql.Data.MySqlClient
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Core
Imports System.IO
Public Class kardex_mp
    Sub formato_datetimepicker()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy-MM-dd"

    End Sub

    Public Function get_saldo(ByVal producto As Integer)
        Conexion.open()
        Dim dataadapter3 As MySqlDataAdapter
        Dim dataset3 As DataSet
        Dim sql3 As String = "SELECT saldo_kar FROM kardexmp WHERE codigo_mp='" & producto & "' ORDER BY id_kar DESC LIMIT 1 "
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

    Public Sub add_kardex_entrada(ByVal producto As Integer, ByVal cant_entrante As Integer)
        Conexion.open()
        Dim query_elim As String = "INSERT INTO kardexmp (fecha_kar,codigo_mp,usuario,entra_kar,sale_kar,saldo_kar,obs_kar) VALUES (curdate(),'" & producto & "','" & login.MaskedTextBox1.Text & "', '" & cant_entrante & "', 0, '" & get_saldo(producto) + cant_entrante & "','--')"
        Dim cmd As New MySqlCommand(query_elim, Conexion.conn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Conexion.close()
    End Sub

    Public Sub add_kardex_salida(ByVal producto As Integer, ByVal cant_saliente As Integer)
        Conexion.open()
        Dim query_elim As String = "INSERT INTO kardexmp (fecha_kar,codigo_mp,usuario,entra_kar,sale_kar,saldo_kar,obs_kar) VALUES (curdate(),'" & producto & "','" & login.MaskedTextBox1.Text & "', '0','" & cant_saliente & "', '" & get_saldo(producto) - cant_saliente & "','--')"
        Dim cmd As New MySqlCommand(query_elim, Conexion.conn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Conexion.close()
    End Sub

    Public Sub add_kardex_inicial(ByVal producto As Integer)
        Conexion.open()
        Dim query_elim As String = "INSERT INTO kardexmp (fecha_kar,codigo_mp,usuario,entra_kar,sale_kar,saldo_kar,obs_kar) VALUES (curdate(),'" & producto & "','" & login.MaskedTextBox1.Text & "', '0', 0, '0','inic')"
        Dim cmd As New MySqlCommand(query_elim, Conexion.conn)
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Conexion.close()
    End Sub
    Private Sub kardex_mp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formato_datetimepicker()
        Me.Button2.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Conexion.open()
        Dim query As String = "SELECT fecha_kar'Fecha',materia_prima.nombre_mp 'Producto',usuario.nombre'Usuario', entra_kar'Entra',sale_kar'Sale',saldo_kar'Saldo',obs_kar'Observacion' FROM kardexmp INNER JOIN materia_prima ON materia_prima.codigo_mp=kardexmp.codigo_mp INNER JOIN usuario ON usuario.run=kardexmp.usuario where kardexmp.codigo_mp='" & Me.TextBox1.Text & "' and fecha_kar BETWEEN'" & Me.DateTimePicker1.Text & "' and '" & Me.DateTimePicker2.Text & "'  "
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
        Me.Button2.Enabled = True
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
            xlWorkSheet.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + CStr("\kardex_materia_prima.xlsx"))
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