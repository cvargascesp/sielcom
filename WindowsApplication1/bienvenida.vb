Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class bienvenida
    Dim c As Integer

    Private Sub bienvenida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'bloquea cierre alt+f4
        If e.KeyData = Keys.Alt + Keys.F4 Then
            e.Handled = True
        End If
    End Sub
    Private Sub bienvenida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub validaConexion()

        'Verifica conexion a internet
        If My.Computer.Network.IsAvailable = False Then
            MsgBox("No Está conectado a internet, Verifique su Conexión")
            End
        End If

        ' La conexión a usar, indicando la base master
        Conexion.conn = New MySqlConnection(Conexion.strConn)
        Dim cn As MySqlConnection = Conexion.conn
        Try
            ' Abrimos la conexión y si existe la bd pasará correctamente...
            Conexion.open()
            'Dim sSQL As String = "SET character_set_results=latin1"
            'Dim cmd = New MySqlCommand(sSQL, cn)
            'cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message, _
                            "Error al conectarse a MySQL", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Por si se produce un error,
            ' comprobar si la conexión está abierta
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

            End
        End Try

        ProgressBar1.PerformStep()

        'elimina ticket inpago despues de 1 dia
        Dim sqlsel As String = "select codigo, cantidad from ticket t join ticketdetalle d on(t.numdocu=d.numdocu) where fechadocu < curdate() and estado = 'TICKET'"
        Dim sqlupd As String = "update producto set porvender = porvender - @porvender where codigo = @codigo"

        Dim trx As MySqlTransaction = Conexion.conn.BeginTransaction
        Try
            Dim cmdupd As New MySqlCommand(sqlupd, Conexion.conn)

            Dim da As New MySqlDataAdapter(sqlsel, Conexion.conn)
            Dim ds As New DataSet
            da.Fill(ds, "antiguos")

            Dim p1 As New MySqlParameter("@codigo", MySqlDbType.VarChar)
            Dim p2 As New MySqlParameter("@porvender", MySqlDbType.Int32)
            cmdupd.Parameters.Add(p1)
            cmdupd.Parameters.Add(p2)
            cmdupd.Prepare()
            For Each r As DataRow In ds.Tables("antiguos").Rows
                p1.Value = r("codigo")
                p2.Value = r("cantidad")
                cmdupd.ExecuteNonQuery()
            Next

            Dim sql As String = "DELETE FROM ticket WHERE fechadocu < curdate() and estado='TICKET'"
            'MessageBox.Show("Usuario Eliminado con Exito", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim cm As New MySqlCommand(sql, Conexion.conn)
            cm.ExecuteNonQuery()

            trx.Commit()
        Catch err As MySqlException
            trx.Rollback()
            MessageBox.Show(err.Message)
        Catch err As Exception
            trx.Rollback()
            MessageBox.Show(err.Message)
        End Try

        ProgressBar1.PerformStep()
        'verifica si existe tabla boleta
        Try
            Dim sql As String
            Dim cm As MySqlCommand
            Dim r As String
            sql = "show tables like 'boleta'"
            cm = New MySqlCommand()
            cm.CommandText = sql
            cm.CommandType = CommandType.Text
            cm.Connection = cn
            r = cm.ExecuteScalar()

            If r = "" Then
                'crea tabla boleta
                ' La orden T-SQL para crear la tabla
                Dim s3 As String = "CREATE TABLE `boleta` (`numdocu` varchar(45) default NULL,`cliente` varchar(150) default NULL,`tipodocu` varchar(60) default NULL,`fechadocu` varchar(45) default NULL,`vendedor` varchar(150) default NULL,`responsable` varchar(150) default NULL,`numticket` varchar(60) default NULL,`total` varchar(45) default NULL,`pago` varchar(45) default NULL,`formapago` varchar(60) default NULL,`cuotas` varchar(30) default NULL,`vuelto` varchar(45) default NULL,`estado` varchar(60) default NULL)ENGINE=InnoDB DEFAULT CHARSET=latin1;"
                Dim cmd3 As New MySqlCommand(s3, cn)
                Try
                    ' Abrimos la conexión y ejecutamos el comando
                    cmd3.ExecuteNonQuery()
                    '
                Catch ex As Exception
                    MessageBox.Show(ex.Message, _
                                    "Error al crear la tabla", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        ProgressBar1.PerformStep()
        'verifica si existe tabla cliente
        Try
            Dim sql As String
            Dim cm As MySqlCommand
            Dim r As String

            sql = "show tables like 'cliente'"
            cm = New MySqlCommand()
            cm.CommandText = sql
            cm.CommandType = CommandType.Text
            cm.Connection = cn
            r = cm.ExecuteScalar()

            If r = "" Then
                'crea tabla cliente
                ' La orden T-SQL para crear la tabla
                Dim s4 As String = "CREATE TABLE `cliente` (`rut` varchar(33) default NULL,`digito` varchar(6) default NULL,`nombre` varchar(150) default NULL,`giro` varchar(150) default NULL,`contacto` varchar(150) default NULL,`direccion` varchar(150) default NULL,`telefono1` varchar(45) default NULL,`telefono2` varchar(45) default NULL,`fax` varchar(45) default NULL,`region` varchar(150) default NULL,`provincia` varchar(150) default NULL,`comuna` varchar(150) default NULL,`mail` varchar(150) default NULL,`creado` varchar(150) default NULL,`fechac` varchar(45) default NULL) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
                Dim cmd4 As New MySqlCommand(s4, cn)
                Try
                    ' Abrimos la conexión y ejecutamos el comando
                    cmd4.ExecuteNonQuery()
                    '
                Catch ex As Exception
                    MessageBox.Show(ex.Message, _
                                    "Error al crear la tabla", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        ProgressBar1.PerformStep()
        'verifica si existe tabla comunas
        Try
            Dim sql As String
            Dim cm As MySqlCommand
            Dim r As String
            sql = "show tables like 'comunas'"
            cm = New MySqlCommand()
            cm.CommandText = sql
            cm.CommandType = CommandType.Text
            cm.Connection = cn
            r = cm.ExecuteScalar()

            If r = "" Then
                'crea tabla cliente
                ' La orden T-SQL para crear la tabla
                Dim s4 As String = "CREATE TABLE `comunas` (`comuna_id` bigint(20) default NULL,`comuna_nom` varchar(192) default NULL,`provincia_` bigint(20) default NULL) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
                Dim cmd4 As New MySqlCommand(s4, cn)
                Try
                    ' Abrimos la conexión y ejecutamos el comando
                    cmd4.ExecuteNonQuery()
                    '
                Catch ex As Exception
                    MessageBox.Show(ex.Message, _
                                    "Error al crear la tabla", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        ProgressBar1.PerformStep()
        'verifica si existe tabla producto
        Try
            Dim sql As String
            Dim cm As MySqlCommand
            Dim r As String
            sql = "show tables like 'producto'"
            cm = New MySqlCommand()
            cm.CommandText = sql
            cm.CommandType = CommandType.Text
            cm.Connection = cn
            r = cm.ExecuteScalar()

            If r = "" Then
                'crea tabla cliente
                ' La orden T-SQL para crear la tabla
                Dim s4 As String = "CREATE TABLE `producto` (`codigo` varchar(150) default NULL,`codigoint` varchar(150) default NULL,`nombre` varchar(150) default NULL,`descripcion` longtext,`marca` varchar(150) default NULL,`modelo` varchar(150) default NULL,`categoria` varchar(150) default NULL,`factura` varchar(150) default NULL,`proveedor` varchar(150) default NULL,`cantidad` varchar(30) default NULL,`critico` varchar(30) default NULL,`preciouni` varchar(30) default NULL,`totalcompra` varchar(30) default NULL,`precioventa` varchar(30) default NULL,`utilidaduni` varchar(30) default NULL,`utilidadtotal` varchar(30) default NULL,`estado` varchar(60) default NULL,`fechaingreso` varchar(45) default NULL,`creado` varchar(150) default NULL) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
                Dim cmd4 As New MySqlCommand(s4, cn)
                Try
                    ' Abrimos la conexión y ejecutamos el comando
                    cmd4.ExecuteNonQuery()
                    '
                Catch ex As Exception
                    MessageBox.Show(ex.Message, _
                                    "Error al crear la tabla", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        ProgressBar1.PerformStep()
        'verifica si existe tabla proveedor
        Try
            Dim sql As String
            Dim cm As MySqlCommand
            Dim r As String
            sql = "show tables like 'proveedor'"
            cm = New MySqlCommand()
            cm.CommandText = sql
            cm.CommandType = CommandType.Text
            cm.Connection = cn
            r = cm.ExecuteScalar()

            If r = "" Then
                'crea tabla cliente
                ' La orden T-SQL para crear la tabla
                Dim s4 As String = "CREATE TABLE `proveedor` (`rut` varchar(33) NOT NULL default '',`digito` varchar(6) default NULL,`nombre` varchar(150) default NULL,`contacto` varchar(150) default NULL,`direccion` varchar(150) default NULL,`telefono1` varchar(45) default NULL,`telefono2` varchar(45) default NULL,`fax` varchar(45) default NULL,`region` varchar(12) default NULL,`provincia` varchar(150) default NULL,`comuna` varchar(150) default NULL,`mail` varchar(150) default NULL,`creado` varchar(150) default NULL,`fechac` varchar(45) default NULL,PRIMARY KEY  (`rut`)) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
                Dim cmd4 As New MySqlCommand(s4, cn)
                Try
                    ' Abrimos la conexión y ejecutamos el comando
                    cmd4.ExecuteNonQuery()
                    '
                Catch ex As Exception
                    MessageBox.Show(ex.Message, _
                                    "Error al crear la tabla", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        ProgressBar1.PerformStep()
        'verifica si existe tabla provincias
        Try
            Dim sql As String
            Dim cm As MySqlCommand
            Dim r As String
            sql = "show tables like 'provincias'"
            cm = New MySqlCommand()
            cm.CommandText = sql
            cm.CommandType = CommandType.Text
            cm.Connection = cn
            r = cm.ExecuteScalar()

            If r = "" Then
                'crea tabla cliente
                ' La orden T-SQL para crear la tabla
                Dim s4 As String = "CREATE TABLE `provincias` (`provincia_` bigint(20) default NULL,`provincia1` varchar(192) default NULL,`region_id_` bigint(20) default NULL) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
                Dim cmd4 As New MySqlCommand(s4, cn)
                Try
                    ' Abrimos la conexión y ejecutamos el comando
                    cmd4.ExecuteNonQuery()
                    '
                Catch ex As Exception
                    MessageBox.Show(ex.Message, _
                                    "Error al crear la tabla", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        ProgressBar1.PerformStep()
        'verifica si existe tabla regiones
        Try
            Dim sql As String
            Dim cm As MySqlCommand
            Dim r As String
            sql = "show tables like 'regiones'"
            cm = New MySqlCommand()
            cm.CommandText = sql
            cm.CommandType = CommandType.Text
            cm.Connection = cn
            r = cm.ExecuteScalar()

            If r = "" Then
                'crea tabla cliente
                ' La orden T-SQL para crear la tabla
                Dim s4 As String = "CREATE TABLE `regiones` (`region_id_` bigint(20) default NULL,`region_nom` varchar(192) default NULL,`region_ord` varchar(12) default NULL) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
                Dim cmd4 As New MySqlCommand(s4, cn)
                Try
                    ' Abrimos la conexión y ejecutamos el comando
                    cmd4.ExecuteNonQuery()
                    '
                Catch ex As Exception
                    MessageBox.Show(ex.Message, _
                                    "Error al crear la tabla", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        ProgressBar1.PerformStep()
        'verifica si existe tabla ticket
        Try
            Dim sql As String
            Dim cm As MySqlCommand
            Dim r As String
            sql = "show tables like 'ticket'"
            cm = New MySqlCommand()
            cm.CommandText = sql
            cm.CommandType = CommandType.Text
            cm.Connection = cn
            r = cm.ExecuteScalar()

            If r = "" Then
                'crea tabla cliente
                ' La orden T-SQL para crear la tabla
                Dim s4 As String = "CREATE TABLE `ticket` (`responsable` varchar(150) default NULL,`numdocu` varchar(45) default NULL,`fechadocu` varchar(45) default NULL,`cliente` varchar(150) default NULL,`codigopro` varchar(150) default NULL,`cantidadpro` varchar(30) default NULL,`nombrepro` varchar(150) default NULL,`descripcionpro` varchar(150) default NULL,`marcapro` varchar(150) default NULL,`modelopro` varchar(150) default NULL,`preciopro` varchar(30) default NULL,`total` varchar(30) default NULL,`descuento` varchar(30) default NULL,`estado` varchar(150) default NULL) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
                Dim cmd4 As New MySqlCommand(s4, cn)
                Try
                    ' Abrimos la conexión y ejecutamos el comando
                    cmd4.ExecuteNonQuery()
                    '
                Catch ex As Exception
                    MessageBox.Show(ex.Message, _
                                    "Error al crear la tabla", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        ProgressBar1.PerformStep()

        'verifica si existe tabla usuario
        Try
            Dim sql As String
            Dim cm As MySqlCommand
            Dim r As String
            sql = "show tables like 'usuario'"
            cm = New MySqlCommand()
            cm.CommandText = sql
            cm.CommandType = CommandType.Text
            cm.Connection = cn
            r = cm.ExecuteScalar()

            If r = "" Then
                'crea tabla cliente
                ' La orden T-SQL para crear la tabla
                Dim s4 As String = "CREATE TABLE `usuario` (`run` varchar(33) NOT NULL default '',`digito` varchar(6) default NULL,`nombre` varchar(150) default NULL,`cuenta` varchar(60) default NULL,`permiso` varchar(60) default NULL,`clave` varchar(60) default NULL,`creado` varchar(150) default NULL,`fechac` varchar(45) default NULL,`modificado` varchar(150) default NULL,`fecham` varchar(45) default NULL,PRIMARY KEY  (`run`)) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
                Dim cmd4 As New MySqlCommand(s4, cn)
                Try
                    ' Abrimos la conexión y ejecutamos el comando
                    cmd4.ExecuteNonQuery()
                    '
                Catch ex As Exception
                    MessageBox.Show(ex.Message, _
                                    "Error al crear la tabla", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Catch err As MySqlException
            MessageBox.Show(err.Message)
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        ProgressBar1.PerformStep()
        Conexion.close()

        Me.Hide()
        login.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        'login.ComboBox1.SelectedIndex = 0
        validaConexion()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class