Imports MySql.Data.MySqlClient
Public Class Libro_pedidos
    Public buscar_libro_pedido As Integer
    Private Sub Libro_pedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_grilla()
        formato_datetimepicker()
    End Sub
    Sub llenar_grilla()
        Conexion.open()
        Dim query As String = "SELECT id_ordencompramp'Numero Orden de compra',proveedor.nombre'Nombre Proveedor',fecha_creacion'Fecha Emision',fecha_tope'Fecha de Tope',fecha_tope-CURDATE()'Dias Restantes', IF(fecha_tope-CURDATE()>=0,'OK','Atrasado')'estado' FROM orden_compramp_cabezera inner JOIN proveedor ON proveedor.rut=orden_compramp_cabezera.rut"
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
    End Sub

    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If DataGridView1.Columns(e.ColumnIndex).Name.Equals("Dias Restantes") Then
            If (CInt(e.Value) = 0) Then
                DataGridView1.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.Yellow
            End If
            If (CInt(e.Value) > 0) Then
                DataGridView1.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.Green
            End If
            If (CInt(e.Value) < 0) Then
                DataGridView1.Rows(e.RowIndex).Cells(5).Style.BackColor = Color.Red
            End If
        End If
    End Sub

    Sub formato_datetimepicker()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy-MM-dd"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Conexion.open()
        Dim query As String = "SELECT id_ordencompramp'Numero Orden de compra',proveedor.nombre'Nombre Proveedor',fecha_creacion'Fecha Emision',fecha_tope'Fecha de Tope',fecha_tope-CURDATE()'Dias Restantes', IF(fecha_tope-CURDATE()>=0,'OK','Atrasado')'estado' FROM orden_compramp_cabezera INNER JOIN proveedor ON proveedor.rut=orden_compramp_cabezera.rut WHERE fecha_creacion BETWEEN '" & Me.DateTimePicker1.Text & "' AND '" & Me.DateTimePicker2.Text & "'"
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        llenar_grilla()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ((IsNumeric(Me.NumericUpDown1.Value))) Then
            buscar_libro_pedido = CInt(Me.NumericUpDown1.Value)
            libro_pedido_desglose.Show()
            Me.NumericUpDown1.Value = 0
        Else
            MessageBox.Show("Valor a buscar invalido", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
End Class