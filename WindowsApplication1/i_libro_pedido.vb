Imports MySql.Data.MySqlClient
Public Class i_libro_pedido
    Private Sub i_libro_pedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formatear_fechas()
        llenar_combobox_proveedores()
    End Sub

    Sub formatear_fechas()
        fecha_ingreso.Format = DateTimePickerFormat.Custom
        fecha_ingreso.CustomFormat = "yyyy-MM-dd"
        fecha_tope.Format = DateTimePickerFormat.Custom
        fecha_tope.CustomFormat = "yyyy-MM-dd"
    End Sub
    Sub llenar_combobox_proveedores()
        Dim ssql As String = "select * from proveedor"
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(ssql, Conexion.conn)
        Try
            Dim actual As String = Me.comboproveedor.Text
            da.Fill(ds)
            Me.comboproveedor.DataSource = ds.Tables(0)
            Me.comboproveedor.DisplayMember = "nombre"
            'Me.comboproveedor.ValueMember = "idfamilia"
            Me.comboproveedor.SelectedValue = actual
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class