Imports MySql.Data.MySqlClient
Public Class agregar_materia_prima

    Private Sub agregar_materia_prima_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formato_datetimepicker()
        llenar_combobox_familias()
        llenar_combobox_unidadmedida()
    End Sub
    Private Sub combofamilia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combofamilia.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'boton para guardar materia prima
        If (Me.txtcodigo_mp.Text <> "" Or Me.txt_nom_mp.Text <> "") Then
            agregar_materia_prima()
        Else
            MessageBox.Show("Campos Faltantes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If

    End Sub



    Sub agregar_materia_prima()
        Dim sqlquery As String = "insert into materia_prima values('" & Me.txtcodigo_mp.Text & "', '" & Me.txt_nom_mp.Text & "', '" & Me.DateTimePicker1.Text & "','" & Me.txt_ubicacion_mp.Text & "','" & Me.unidadmedida_mp.Text & "', '" & Me.combofamilia.SelectedValue & "'  )"
        Dim cmd As New MySqlCommand(sqlquery, Conexion.conn)
        Try
            Conexion.open()
            cmd.ExecuteNonQuery()
            Conexion.close()
            MessageBox.Show("Materia Prima Guardada Con Exito", "Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



    Sub llenar_combobox_familias()
        Dim ssql As String = "select * from familias"
        Dim ds As New DataSet
        Dim da As New MySqlDataAdapter(ssql, Conexion.conn)
        Try
            Dim actual As String = combofamilia.Text
            da.Fill(ds)
            combofamilia.DataSource = ds.Tables(0)
            combofamilia.DisplayMember = "nom_familia"
            combofamilia.ValueMember = "idfamilia"
            combofamilia.SelectedValue = actual
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub formato_datetimepicker()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
    End Sub

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


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        bodega_materias_primas_principal.Show()
    End Sub

  
End Class