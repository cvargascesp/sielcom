<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class i_libro_pedido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(i_libro_pedido))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fecha_ingreso = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.comboproveedor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.fecha_tope = New System.Windows.Forms.DateTimePicker()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtmateriaprima = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtcantmp = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_unidadmedida = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtoc_mp = New System.Windows.Forms.TextBox()
        CType(Me.txtcantmp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        '
        'fecha_ingreso
        '
        Me.fecha_ingreso.Location = New System.Drawing.Point(122, 20)
        Me.fecha_ingreso.Name = "fecha_ingreso"
        Me.fecha_ingreso.Size = New System.Drawing.Size(200, 20)
        Me.fecha_ingreso.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Proveedor:"
        '
        'comboproveedor
        '
        Me.comboproveedor.FormattingEnabled = True
        Me.comboproveedor.Location = New System.Drawing.Point(122, 86)
        Me.comboproveedor.Name = "comboproveedor"
        Me.comboproveedor.Size = New System.Drawing.Size(200, 21)
        Me.comboproveedor.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Fecha Tope:"
        '
        'fecha_tope
        '
        Me.fecha_tope.Location = New System.Drawing.Point(122, 123)
        Me.fecha_tope.Name = "fecha_tope"
        Me.fecha_tope.Size = New System.Drawing.Size(200, 20)
        Me.fecha_tope.TabIndex = 7
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(394, 26)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(53, 13)
        Me.label5.TabIndex = 8
        Me.label5.Text = "Producto:"
        '
        'txtmateriaprima
        '
        Me.txtmateriaprima.Location = New System.Drawing.Point(494, 23)
        Me.txtmateriaprima.Name = "txtmateriaprima"
        Me.txtmateriaprima.Size = New System.Drawing.Size(240, 20)
        Me.txtmateriaprima.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(394, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Cantidad:"
        '
        'txtcantmp
        '
        Me.txtcantmp.Location = New System.Drawing.Point(494, 87)
        Me.txtcantmp.Name = "txtcantmp"
        Me.txtcantmp.Size = New System.Drawing.Size(240, 20)
        Me.txtcantmp.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(394, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Unidad medida:"
        '
        'txt_unidadmedida
        '
        Me.txt_unidadmedida.Location = New System.Drawing.Point(494, 57)
        Me.txt_unidadmedida.Name = "txt_unidadmedida"
        Me.txt_unidadmedida.ReadOnly = True
        Me.txt_unidadmedida.Size = New System.Drawing.Size(240, 20)
        Me.txt_unidadmedida.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(15, 161)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 52)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Agregar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.ControlLight
        Me.DataGridView1.Location = New System.Drawing.Point(15, 219)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(750, 150)
        Me.DataGridView1.TabIndex = 15
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(282, 417)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(165, 58)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Generar pedido"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Orden de compra:"
        '
        'txtoc_mp
        '
        Me.txtoc_mp.Location = New System.Drawing.Point(122, 57)
        Me.txtoc_mp.Name = "txtoc_mp"
        Me.txtoc_mp.Size = New System.Drawing.Size(200, 20)
        Me.txtoc_mp.TabIndex = 18
        '
        'i_libro_pedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 498)
        Me.Controls.Add(Me.txtoc_mp)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txt_unidadmedida)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtcantmp)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtmateriaprima)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.fecha_tope)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.comboproveedor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.fecha_ingreso)
        Me.Controls.Add(Me.Label1)
        Me.Name = "i_libro_pedido"
        Me.Text = "Ingresar Libro de pedido"
        CType(Me.txtcantmp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fecha_ingreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents comboproveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents fecha_tope As System.Windows.Forms.DateTimePicker
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents txtmateriaprima As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtcantmp As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_unidadmedida As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtoc_mp As System.Windows.Forms.TextBox
End Class
