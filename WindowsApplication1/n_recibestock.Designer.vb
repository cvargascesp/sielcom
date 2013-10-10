<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class n_recibestock
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnRecalculaVenta = New System.Windows.Forms.Button()
        Me.lblUtilidad = New System.Windows.Forms.Label()
        Me.txtMargen = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblPorllegar = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbProveedor = New System.Windows.Forms.ComboBox()
        Me.txtTotalcompra = New System.Windows.Forms.TextBox()
        Me.txtPrecioventa = New System.Windows.Forms.TextBox()
        Me.txtPreciouni = New System.Windows.Forms.TextBox()
        Me.lblFechaingreso = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 283)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Aceptar"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancelar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Documento :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.btnRecalculaVenta)
        Me.GroupBox1.Controls.Add(Me.lblUtilidad)
        Me.GroupBox1.Controls.Add(Me.txtMargen)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblPorllegar)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cbProveedor)
        Me.GroupBox1.Controls.Add(Me.txtTotalcompra)
        Me.GroupBox1.Controls.Add(Me.txtPrecioventa)
        Me.GroupBox1.Controls.Add(Me.txtPreciouni)
        Me.GroupBox1.Controls.Add(Me.lblFechaingreso)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtFactura)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(411, 256)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de ingreso"
        '
        'btnRecalculaVenta
        '
        Me.btnRecalculaVenta.Image = Global.WindowsApplication1.My.Resources.Resources.DownArrowShort
        Me.btnRecalculaVenta.Location = New System.Drawing.Point(196, 153)
        Me.btnRecalculaVenta.Name = "btnRecalculaVenta"
        Me.btnRecalculaVenta.Size = New System.Drawing.Size(22, 28)
        Me.btnRecalculaVenta.TabIndex = 18
        Me.btnRecalculaVenta.UseVisualStyleBackColor = True
        '
        'lblUtilidad
        '
        Me.lblUtilidad.AutoSize = True
        Me.lblUtilidad.Location = New System.Drawing.Point(242, 160)
        Me.lblUtilidad.Name = "lblUtilidad"
        Me.lblUtilidad.Size = New System.Drawing.Size(45, 13)
        Me.lblUtilidad.TabIndex = 17
        Me.lblUtilidad.Text = "Label10"
        Me.lblUtilidad.Visible = False
        '
        'txtMargen
        '
        Me.txtMargen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMargen.Location = New System.Drawing.Point(108, 157)
        Me.txtMargen.MaxLength = 5
        Me.txtMargen.Name = "txtMargen"
        Me.txtMargen.Size = New System.Drawing.Size(73, 20)
        Me.txtMargen.TabIndex = 15
        Me.txtMargen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(49, 160)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 14)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Margen :"
        '
        'lblPorllegar
        '
        Me.lblPorllegar.AutoSize = True
        Me.lblPorllegar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorllegar.Location = New System.Drawing.Point(309, 105)
        Me.lblPorllegar.Name = "lblPorllegar"
        Me.lblPorllegar.Size = New System.Drawing.Size(33, 15)
        Me.lblPorllegar.TabIndex = 14
        Me.lblPorllegar.Text = "valor"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(242, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 14)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Por llegar :"
        '
        'cbProveedor
        '
        Me.cbProveedor.FormattingEnabled = True
        Me.cbProveedor.Location = New System.Drawing.Point(108, 50)
        Me.cbProveedor.Name = "cbProveedor"
        Me.cbProveedor.Size = New System.Drawing.Size(274, 21)
        Me.cbProveedor.TabIndex = 1
        '
        'txtTotalcompra
        '
        Me.txtTotalcompra.Location = New System.Drawing.Point(108, 210)
        Me.txtTotalcompra.Name = "txtTotalcompra"
        Me.txtTotalcompra.ReadOnly = True
        Me.txtTotalcompra.Size = New System.Drawing.Size(128, 20)
        Me.txtTotalcompra.TabIndex = 6
        Me.txtTotalcompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioventa
        '
        Me.txtPrecioventa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrecioventa.Location = New System.Drawing.Point(108, 183)
        Me.txtPrecioventa.Name = "txtPrecioventa"
        Me.txtPrecioventa.Size = New System.Drawing.Size(128, 20)
        Me.txtPrecioventa.TabIndex = 5
        Me.txtPrecioventa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPreciouni
        '
        Me.txtPreciouni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPreciouni.Location = New System.Drawing.Point(108, 131)
        Me.txtPreciouni.Name = "txtPreciouni"
        Me.txtPreciouni.Size = New System.Drawing.Size(128, 20)
        Me.txtPreciouni.TabIndex = 4
        Me.txtPreciouni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFechaingreso
        '
        Me.lblFechaingreso.AutoSize = True
        Me.lblFechaingreso.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaingreso.Location = New System.Drawing.Point(284, 23)
        Me.lblFechaingreso.Name = "lblFechaingreso"
        Me.lblFechaingreso.Size = New System.Drawing.Size(37, 14)
        Me.lblFechaingreso.TabIndex = 12
        Me.lblFechaingreso.Text = "Fecha"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 134)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 14)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Precio Compra :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(25, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 14)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Precio Venta :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Total Compra :"
        '
        'txtCantidad
        '
        Me.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidad.Location = New System.Drawing.Point(108, 104)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(128, 20)
        Me.txtCantidad.TabIndex = 3
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(41, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Cantidad :"
        '
        'txtCodigo
        '
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Location = New System.Drawing.Point(108, 77)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(160, 20)
        Me.txtCodigo.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(51, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Código :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(35, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Proveedor :"
        '
        'txtFactura
        '
        Me.txtFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFactura.Location = New System.Drawing.Point(108, 23)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(128, 20)
        Me.txtFactura.TabIndex = 0
        '
        'n_recibestock
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(435, 315)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "n_recibestock"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recepción de stock"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFactura As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalcompra As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecioventa As System.Windows.Forms.TextBox
    Friend WithEvents txtPreciouni As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaingreso As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents lblPorllegar As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMargen As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblUtilidad As System.Windows.Forms.Label
    Friend WithEvents btnRecalculaVenta As System.Windows.Forms.Button

End Class
