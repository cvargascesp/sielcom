<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class proceso_de_fabricacion
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.RchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MisDatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VolverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadoDeFrabricacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarEstadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.fechaconsulta2 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.n_ordensalida = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.fechaconsulta = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtid_sal = New System.Windows.Forms.NumericUpDown()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtid_sal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RchivoToolStripMenuItem, Me.ConsultaToolStripMenuItem, Me.EstadoDeFrabricacionToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(695, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'RchivoToolStripMenuItem
        '
        Me.RchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MisDatosToolStripMenuItem, Me.VolverToolStripMenuItem})
        Me.RchivoToolStripMenuItem.Name = "RchivoToolStripMenuItem"
        Me.RchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.RchivoToolStripMenuItem.Text = "Archivo"
        '
        'MisDatosToolStripMenuItem
        '
        Me.MisDatosToolStripMenuItem.Name = "MisDatosToolStripMenuItem"
        Me.MisDatosToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.MisDatosToolStripMenuItem.Text = "Mis Datos"
        '
        'VolverToolStripMenuItem
        '
        Me.VolverToolStripMenuItem.Name = "VolverToolStripMenuItem"
        Me.VolverToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.VolverToolStripMenuItem.Text = "Volver"
        '
        'ConsultaToolStripMenuItem
        '
        Me.ConsultaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuscarProductosToolStripMenuItem})
        Me.ConsultaToolStripMenuItem.Name = "ConsultaToolStripMenuItem"
        Me.ConsultaToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ConsultaToolStripMenuItem.Text = "Consulta"
        '
        'BuscarProductosToolStripMenuItem
        '
        Me.BuscarProductosToolStripMenuItem.Name = "BuscarProductosToolStripMenuItem"
        Me.BuscarProductosToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.BuscarProductosToolStripMenuItem.Text = "Buscar Productos"
        '
        'EstadoDeFrabricacionToolStripMenuItem
        '
        Me.EstadoDeFrabricacionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarEstadoToolStripMenuItem})
        Me.EstadoDeFrabricacionToolStripMenuItem.Name = "EstadoDeFrabricacionToolStripMenuItem"
        Me.EstadoDeFrabricacionToolStripMenuItem.Size = New System.Drawing.Size(138, 20)
        Me.EstadoDeFrabricacionToolStripMenuItem.Text = "Estado de Frabricacion"
        '
        'EditarEstadoToolStripMenuItem
        '
        Me.EditarEstadoToolStripMenuItem.Name = "EditarEstadoToolStripMenuItem"
        Me.EditarEstadoToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.EditarEstadoToolStripMenuItem.Text = "Editar estado"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(26, 234)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(655, 229)
        Me.DataGridView1.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtid_sal)
        Me.GroupBox1.Controls.Add(Me.fechaconsulta2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.n_ordensalida)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.fechaconsulta)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(655, 167)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos a Consultar"
        '
        'fechaconsulta2
        '
        Me.fechaconsulta2.Location = New System.Drawing.Point(127, 64)
        Me.fechaconsulta2.Name = "fechaconsulta2"
        Me.fechaconsulta2.Size = New System.Drawing.Size(179, 20)
        Me.fechaconsulta2.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Fecha de termino:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(176, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Numero de Reporte de Fabricacion:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(389, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(154, 61)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Consultar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'n_ordensalida
        '
        Me.n_ordensalida.Location = New System.Drawing.Point(127, 95)
        Me.n_ordensalida.Name = "n_ordensalida"
        Me.n_ordensalida.Size = New System.Drawing.Size(179, 20)
        Me.n_ordensalida.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Orden de Salida:"
        '
        'fechaconsulta
        '
        Me.fechaconsulta.Location = New System.Drawing.Point(127, 27)
        Me.fechaconsulta.Name = "fechaconsulta"
        Me.fechaconsulta.Size = New System.Drawing.Size(179, 20)
        Me.fechaconsulta.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha de Inicio:"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(747, 482)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Volver"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(603, 482)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Volver"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtid_sal
        '
        Me.txtid_sal.Location = New System.Drawing.Point(192, 125)
        Me.txtid_sal.Name = "txtid_sal"
        Me.txtid_sal.Size = New System.Drawing.Size(114, 20)
        Me.txtid_sal.TabIndex = 9
        '
        'proceso_de_fabricacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(695, 517)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "proceso_de_fabricacion"
        Me.Text = "Consulta de Estado de Fabricacion"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtid_sal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents RchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MisDatosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstadoDeFrabricacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarEstadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents n_ordensalida As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents fechaconsulta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents VolverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents fechaconsulta2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtid_sal As System.Windows.Forms.NumericUpDown
End Class
