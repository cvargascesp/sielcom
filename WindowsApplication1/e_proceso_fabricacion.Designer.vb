<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class e_proceso_fabricacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.fecha_solicitud = New System.Windows.Forms.DateTimePicker()
        Me.n_fabricacion_c = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.fecha_t = New System.Windows.Forms.DateTimePicker()
        Me.fecha_i = New System.Windows.Forms.DateTimePicker()
        Me.prod_fab = New System.Windows.Forms.TextBox()
        Me.cod_fab = New System.Windows.Forms.TextBox()
        Me.estado_fab = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.fecha_solicitud)
        Me.GroupBox1.Controls.Add(Me.n_fabricacion_c)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(681, 165)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingrese datos de Busqueda:"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(293, 117)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(121, 35)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Limpiar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(156, 117)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 35)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'fecha_solicitud
        '
        Me.fecha_solicitud.Location = New System.Drawing.Point(156, 63)
        Me.fecha_solicitud.Name = "fecha_solicitud"
        Me.fecha_solicitud.Size = New System.Drawing.Size(200, 20)
        Me.fecha_solicitud.TabIndex = 4
        '
        'n_fabricacion_c
        '
        Me.n_fabricacion_c.Location = New System.Drawing.Point(156, 37)
        Me.n_fabricacion_c.Name = "n_fabricacion_c"
        Me.n_fabricacion_c.Size = New System.Drawing.Size(111, 20)
        Me.n_fabricacion_c.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha de Fabricacion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numero de Fabricacion:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.fecha_t)
        Me.GroupBox2.Controls.Add(Me.fecha_i)
        Me.GroupBox2.Controls.Add(Me.prod_fab)
        Me.GroupBox2.Controls.Add(Me.cod_fab)
        Me.GroupBox2.Controls.Add(Me.estado_fab)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(27, 211)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(681, 195)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Editar  Proceso de Fabricacion"
        '
        'fecha_t
        '
        Me.fecha_t.Location = New System.Drawing.Point(420, 76)
        Me.fecha_t.Name = "fecha_t"
        Me.fecha_t.Size = New System.Drawing.Size(200, 20)
        Me.fecha_t.TabIndex = 9
        '
        'fecha_i
        '
        Me.fecha_i.Location = New System.Drawing.Point(139, 76)
        Me.fecha_i.Name = "fecha_i"
        Me.fecha_i.Size = New System.Drawing.Size(167, 20)
        Me.fecha_i.TabIndex = 8
        '
        'prod_fab
        '
        Me.prod_fab.Location = New System.Drawing.Point(427, 39)
        Me.prod_fab.Name = "prod_fab"
        Me.prod_fab.ReadOnly = True
        Me.prod_fab.Size = New System.Drawing.Size(193, 20)
        Me.prod_fab.TabIndex = 7
        '
        'cod_fab
        '
        Me.cod_fab.Location = New System.Drawing.Point(139, 39)
        Me.cod_fab.Name = "cod_fab"
        Me.cod_fab.ReadOnly = True
        Me.cod_fab.Size = New System.Drawing.Size(167, 20)
        Me.cod_fab.TabIndex = 6
        '
        'estado_fab
        '
        Me.estado_fab.FormattingEnabled = True
        Me.estado_fab.Location = New System.Drawing.Point(139, 114)
        Me.estado_fab.Name = "estado_fab"
        Me.estado_fab.Size = New System.Drawing.Size(167, 21)
        Me.estado_fab.TabIndex = 5
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(156, 155)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(258, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Guardar Cambios"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Estado:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(318, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Fecha de Termino:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Fecha de Inicio:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(318, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Producto a Fabricar:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Codigo de Fabricacion:"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(588, 412)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Volver"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'e_proceso_fabricacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(748, 438)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "e_proceso_fabricacion"
        Me.Text = "Edion de Proceso de Fabricacion"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents fecha_solicitud As System.Windows.Forms.DateTimePicker
    Friend WithEvents n_fabricacion_c As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents estado_fab As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents fecha_t As System.Windows.Forms.DateTimePicker
    Friend WithEvents fecha_i As System.Windows.Forms.DateTimePicker
    Friend WithEvents prod_fab As System.Windows.Forms.TextBox
    Friend WithEvents cod_fab As System.Windows.Forms.TextBox
End Class
