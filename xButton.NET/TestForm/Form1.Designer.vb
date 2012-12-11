<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.XButton2 = New xButton.xButton
        Me.XButton1 = New xButton.xButton
        Me.XtraButton1 = New xButton.xButton
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(68, 133)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(305, 143)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'XButton2
        '
        Me.XButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.XButton2.ExcludedCorners = 0
        Me.XButton2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.XButton2.ForeColor = System.Drawing.Color.Black
        Me.XButton2.Location = New System.Drawing.Point(133, 185)
        Me.XButton2.mmForeColor = System.Drawing.Color.White
        Me.XButton2.Name = "XButton2"
        Me.XButton2.nForeColor = System.Drawing.Color.Black
        Me.XButton2.Radius = 0
        Me.XButton2.Size = New System.Drawing.Size(51, 52)
        Me.XButton2.TabIndex = 3
        Me.XButton2.Text = "XButton2"
        Me.XButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'XButton1
        '
        Me.XButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.XButton1.ExcludedCorners = 3
        Me.XButton1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.XButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.XButton1.Location = New System.Drawing.Point(124, 133)
        Me.XButton1.mmForeColor = System.Drawing.Color.White
        Me.XButton1.Name = "XButton1"
        Me.XButton1.nForeColor = System.Drawing.Color.FromArgb(CType(CType(7, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.XButton1.Radius = 5
        Me.XButton1.Size = New System.Drawing.Size(104, 28)
        Me.XButton1.TabIndex = 2
        Me.XButton1.Text = "XButton1"
        Me.XButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'XtraButton1
        '
        Me.XtraButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.XtraButton1.ExcludedCorners = 0
        Me.XtraButton1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.XtraButton1.ForeColor = System.Drawing.Color.Black
        Me.XtraButton1.Location = New System.Drawing.Point(0, 0)
        Me.XtraButton1.mmForeColor = System.Drawing.Color.Black
        Me.XtraButton1.Name = "XtraButton1"
        Me.XtraButton1.nForeColor = System.Drawing.Color.Black
        Me.XtraButton1.Radius = 0
        Me.XtraButton1.Size = New System.Drawing.Size(112, 56)
        Me.XtraButton1.TabIndex = 0
        Me.XtraButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(493, 340)
        Me.Controls.Add(Me.XButton2)
        Me.Controls.Add(Me.XButton1)
        Me.Controls.Add(Me.PictureBox1)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents XtraButton1 As xButton.xButton
    Friend WithEvents XButton1 As xButton.xButton
    Friend WithEvents XButton2 As xButton.xButton

End Class
