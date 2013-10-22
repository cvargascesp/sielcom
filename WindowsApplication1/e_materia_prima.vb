Imports MySql.Data.MySqlClient
Public Class e_materia_prima
    Sub llenar_combobox_unidadmedida()
        Dim ssql As String = "SELECT nomum FROM unidades_medida"
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(ssql, Conexion.conn)
        Try
            Dim actual As String = combofamilia.Text
            da.Fill(ds)
            unidadmedida_mp.DataSource = ds.Tables(0)
            unidadmedida_mp.DisplayMember = "nomum"
            unidadmedida_mp.SelectedValue = actual
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub e_materia_prima_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenar_combobox_unidadmedida()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        bodega_materias_primas_principal.Show()
    End Sub

    Private Sub txtcodigo_mp_LostFocus(sender As Object, e As EventArgs) Handles txtcodigo_mp.LostFocus
        If Me.txtcodigo_mp.Text <> "" Then




        End If

    End Sub

   
 
End Class