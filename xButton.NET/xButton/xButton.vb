Imports System.ComponentModel
Imports System.Drawing.Color
Imports System.Drawing.Drawing2D
Imports xButton.Shape

Public Class xButton
    Inherits System.Windows.Forms.Label

    Private transMM As Integer = 255
    Private transN As Integer = 0
    Private sngRadius As Single = 0
    Private intCorners As Integer = 0
    Private ForecolorMM As Color = White
    Private ForecolorN As Color = White
    'Private mmColor As Color = Color.FromArgb(7, 81, 249)


#Region " Properties"
    <Description("Corners that are not rounded TopLeft = 1,TopRight = 2,BottomRight = 4,BottomLeft = 8"), DefaultValue(255)> _
    Property ExcludedCorners() As Integer
        Get
            ExcludedCorners = intCorners
        End Get
        Set(ByVal Value As Integer)
            intCorners = Value
            Me.Refresh()
        End Set
    End Property

    <Description("Radius of the rounded border(0=No Rounded Border)"), DefaultValue(255)> _
    Property Radius() As Integer
        Get
            Radius = sngRadius
        End Get
        Set(ByVal Value As Integer)
            sngRadius = Value
            Me.Refresh()
        End Set
    End Property

    <Description("Transparency when mouse is over the control (0-255)"), DefaultValue(255)> _
    Property mmTransparency() As Integer
        Get
            mmTransparency = transMM
        End Get
        Set(ByVal Value As Integer)
            transMM = Value
        End Set
    End Property

    <Description("Default Transparency (0-255)"), DefaultValue(0)> _
    Property nTransparency() As Integer
        Get
            nTransparency = transN
        End Get
        Set(ByVal Value As Integer)
            transN = Value
            Me.BackColor = FromArgb(transN, Me.BackColor.R, Me.BackColor.G, Me.BackColor.B)
        End Set
    End Property

    <Description("MouseMoved Forecolor"), DefaultValue(0)> _
    Property mmForeColor() As Color
        Get
            mmForeColor = ForecolorMM
        End Get
        Set(ByVal Value As Color)
            ForecolorMM = Value
        End Set
    End Property

    <Description("Normal Forecolor"), DefaultValue(0)> _
    Property nForeColor() As Color
        Get
            nForeColor = ForecolorN
        End Get
        Set(ByVal Value As Color)
            ForecolorN = Value
            Me.ForeColor = Value
        End Set
    End Property
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl1 overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'XtraButton
        '
        Me.BackColor = FromArgb(0, 7, 81, 249) 'System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel)
        Me.ForeColor = ForecolorN 'System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Size = New System.Drawing.Size(112, 56)
        Me.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AutoSize = False
        Me.Size = New System.Drawing.Size(112, 56)
        Me.Refresh()
        Me.ResumeLayout(False)
    End Sub

#End Region

    Private Sub xButton_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseEnter
        If transN < transMM Then
            For i As Int32 = transN To transMM
                Me.BackColor = Color.FromArgb(i, Me.BackColor.R, Me.BackColor.G, Me.BackColor.B)
                Me.ForeColor = ForecolorMM
                'Threading.Thread.Sleep(100)
                Me.Refresh()
            Next
        Else
            For i As Int32 = transN To transMM Step -1
                Me.BackColor = Color.FromArgb(i, Me.BackColor.R, Me.BackColor.G, Me.BackColor.B)
                Me.ForeColor = ForecolorMM
                Me.Refresh()
            Next
        End If
    End Sub

    Private Sub xButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseLeave
        If transN < transMM Then
            'THIS IS WORKING WELL!
            For i As Int32 = transMM To transN Step -1
                Me.BackColor = Color.FromArgb(i, Me.BackColor.R, Me.BackColor.G, Me.BackColor.B)
                Me.ForeColor = ForecolorN
                Me.Refresh()
            Next
        Else
            For i As Int32 = transMM To transN
                Me.BackColor = Color.FromArgb(i, Me.BackColor.R, Me.BackColor.G, Me.BackColor.B)
                Me.ForeColor = ForecolorN
                Me.Refresh()
            Next
        End If
    End Sub

    Private Sub xButton_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim szF As System.Drawing.SizeF
        szF.Height = Me.Height
        szF.Width = Me.Width
        Me.Region = RoundedRegion(szF, sngRadius, intCorners)
    End Sub
End Class
