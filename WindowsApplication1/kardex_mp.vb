Imports MySql.Data.MySqlClient
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
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Conexion.open()
        Dim query As String = "SELECT fecha_kar'Fecha',materia_prima.nombre_mp 'Producto',usuario.nombre'Usuario', entra_kar'Entra',sale_kar'Sale',saldo_kar'Saldo',obs_kar'Observacion' FROM kardexmp INNER JOIN materia_prima ON materia_prima.codigo_mp=kardexmp.codigo_mp INNER JOIN usuario ON usuario.run=kardexmp.usuario where kardexmp.codigo_mp='" & Me.TextBox1.Text & "' and fecha_kar BETWEEN'" & Me.DateTimePicker1.Text & "' and '" & Me.DateTimePicker2.Text & "'  "
        Dim Adpt As New MySqlDataAdapter(query, Conexion.conn)
        Dim ds As New DataSet()
        Adpt.Fill(ds, "Emp")
        DataGridView1.DataSource = ds.Tables(0)
        Conexion.close()
    End Sub
End Class