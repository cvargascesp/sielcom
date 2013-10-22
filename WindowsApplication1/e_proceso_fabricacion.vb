Imports MySql.Data.MySqlClient
Public Class e_proceso_fabricacion
    Private Sub e_proceso_fabricacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formatear_fechas()
        Me.GroupBox2.Enabled = False
    End Sub
    Sub formatear_fechas()
        fecha_solicitud.Format = DateTimePickerFormat.Custom
        fecha_solicitud.CustomFormat = "yyyy-MM-dd"
        fecha_i.Format = DateTimePickerFormat.Custom
        fecha_i.CustomFormat = "yyyy-MM-dd"
        fecha_t.Format = DateTimePickerFormat.Custom
        fecha_t.CustomFormat = "yyyy-MM-dd"
    End Sub
    Sub llenar_combobox_estado()
        Dim ssql As String = "SELECT * FROM estados_de_produccion"
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(ssql, Conexion.conn)
        Try
            Dim actual As String = Me.estado_fab.Text
            da.Fill(ds)
            Me.estado_fab.DataSource = ds.Tables(0)
            Me.estado_fab.DisplayMember = "nom_est_pro"
            Me.estado_fab.ValueMember = "id_est_pro"
            Me.estado_fab.SelectedValue = actual
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub limpiar_formulario()
        Me.n_fabricacion_c.Text = ""
        Me.cod_fab.Text = ""
        Me.prod_fab.Text = ""
        Me.estado_fab.Text = ""
        Me.fecha_i.Text = ""
        Me.fecha_solicitud.Text = ""
        Me.fecha_t.Text = ""
        Me.GroupBox2.Enabled = False
        Me.n_fabricacion_c.Focus()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        llenar_combobox_estado()
        Me.GroupBox2.Enabled = True
        Me.fecha_i.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        bodega_materias_primas_principal.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar_formulario()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        limpiar_formulario()
    End Sub
End Class