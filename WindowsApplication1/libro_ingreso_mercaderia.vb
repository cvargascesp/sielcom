Imports MySql.Data.MySqlClient
Public Class libro_ingreso_mercaderia

    Dim existe As Integer

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub libro_ingreso_mercaderia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formato_datetimepicker()

    End Sub

    Private Sub ComboBox1_LostFocus(sender As Object, e As EventArgs) Handles ComboBox1.LostFocus
        If ComboBox1.Text <> "" Then
            Try
                'verifica si existe proveedor
                Dim r As Integer
                Conexion.open()
                Dim sql As String = "SELECT COUNT(*) FROM materia_prima WHERE codigo_mp ='" & ComboBox1.Text & "'"
                Dim cm As New MySqlCommand(sql, Conexion.conn)
                r = cm.ExecuteScalar()
                Conexion.close()
                If r = 0 Then
                    Dim resul As DialogResult

                    resul = MessageBox.Show("Proveedor NO Existe, Desea Crearlo", "Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    If resul = Windows.Forms.DialogResult.Yes Then
                        Dim n_proveedor As New n_proveedor
                        n_proveedor.TextBox2.Text = ComboBox1.Text
                        n_proveedor.ShowDialog()
                        ComboBox1.DataSource = Nothing

                    End If

                End If
            Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult
        result = MessageBox.Show("¿Desea Volver?", "Volver", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        If result = Windows.Forms.DialogResult.Yes Then
            Me.Close()
            bodega_materias_primas_principal.Show()
        End If
    End Sub
    Sub formato_datetimepicker()
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        Try
            'verifica si existe producto
            existe = 0
            Conexion.open()
            Dim sql As String = "SELECT COUNT(*) FROM materia_prima WHERE codigo_mp ='" & TextBox1.Text & "' limit 1"
            Dim cm As New MySqlCommand(sql, Conexion.conn)
            existe = cm.ExecuteScalar()
            Conexion.close()
            If existe = 0 Then
                If (Me.TextBox1.Text <> "") Then
                    MessageBox.Show("El Producto ingresado No existe desea Crearlo", "Ingresar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    'agregar resultado del dialogresult anterior
                    agregar_materia_prima.Show()
                End If
                
            End If
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
    End Sub

   
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class