VERSION 5.00
Begin VB.UserControl xButton 
   BackColor       =   &H00FFFFFF&
   ClientHeight    =   1950
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   2820
   ScaleHeight     =   1950
   ScaleWidth      =   2820
   ToolboxBitmap   =   "xButton.ctx":0000
   Begin VB.Timer Timer1 
      Enabled         =   0   'False
      Interval        =   10
      Left            =   1920
      Top             =   840
   End
   Begin VB.Timer tmrAnim 
      Enabled         =   0   'False
      Interval        =   10
      Left            =   1080
      Top             =   840
   End
   Begin VB.Image imgIcon 
      Height          =   600
      Left            =   960
      Picture         =   "xButton.ctx":0404
      Stretch         =   -1  'True
      Top             =   0
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.Label lblMain 
      Alignment       =   2  'Center
      BackColor       =   &H00F95107&
      Caption         =   "Click"
      BeginProperty Font 
         Name            =   "Times New Roman"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00FFFFFF&
      Height          =   330
      Left            =   600
      TabIndex        =   0
      Top             =   0
      Width           =   975
   End
End
Attribute VB_Name = "xButton"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

Dim Color1 As OLE_COLOR
Dim Color2 As OLE_COLOR

Dim blnImage As Boolean
Dim blnMM As Boolean

Dim h As Integer

Dim WithEvents MyTrak As clsTrackInfo
Attribute MyTrak.VB_VarHelpID = -1

Public Event MouseLeave()
Public Event MouseHover()
Event Click()
Event DblClick()
Event MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
Event MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
Event MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)


Private Sub imgIcon_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
blnMM = True
Timer1.Enabled = True
End Sub

Private Sub lblMain_DblClick()
RaiseEvent DblClick
End Sub

Private Sub lblMain_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
lblMain.BackColor = Color2
lblMain.ForeColor = Color1
RaiseEvent MouseDown(Button, Shift, X, Y)
End Sub

Public Sub DummyMouseLeave()
lblMain.BackColor = Color1
lblMain.ForeColor = Color2
End Sub

Private Sub lblMain_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
lblMain.BackColor = Color2
lblMain.ForeColor = Color1
RaiseEvent MouseMove(Button, Shift, X, Y)

'CreateEllipticRgnApi 1232, 213, 13, 23
End Sub

Private Sub lblMain_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
RaiseEvent MouseUp(Button, Shift, X, Y)
End Sub

Private Sub Timer1_Timer()
If blnMM = True Then
    lblMain.Visible = True
    lblMain.Width = UserControl.ScaleWidth
    If UserControl.Width >= h Then
        UserControl.Width = UserControl.Width + 10
    Else
        Timer1.Enabled = False
    End If
    'imgIcon.Left = 0
End If
End Sub

Private Sub tmrAnim_Timer()
Dim intIWidthChunk As Integer
intIWidthChunk = 10
Dim intDWidthChunk As Integer
intDWidthChunk = 10
If blnMM = True Then
    If lblMain.Width >= UserControl.ScaleWidth Then
        tmrAnim.Enabled = False
    Else
        lblMain.Width = lblMain.Width + intIWidthChunk
    End If
Else
    If lblMain.Width <= imgIcon.Width Then
        lblMain.Width = imgIcon.Width
        tmrAnim.Enabled = False
    Else
        lblMain.Width = lblMain.Width - intDWidthChunk
    End If
End If
End Sub

Private Sub UserControl_ReadProperties(PropBag As PropertyBag)
lblMain.Caption = PropBag.ReadProperty("Caption", "Done!")

Color1 = PropBag.ReadProperty("bColor", &HF95107)
Color2 = PropBag.ReadProperty("fColor", vbWhite)
lblMain.BackColor = Color1
lblMain.ForeColor = Color2

lblMain.FontName = PropBag.ReadProperty("FontName", "Times New Roman")
lblMain.FontSize = PropBag.ReadProperty("FontSize", 12)

Set MyTrak = New clsTrackInfo
MyTrak.hWnd = UserControl.hWnd

MyTrak.HoverTime = PropBag.ReadProperty("HoverTime", 400)

blnImage = PropBag.ReadProperty("PictButton", False)
imgIcon.Visible = blnImage

If Ambient.UserMode Then
    StartTrack MyTrak
End If
End Sub

Public Property Get FontSize() As Integer
FontSize = lblMain.FontSize
End Property

Public Property Get FontName() As String
FontName = lblMain.FontName
End Property

Public Property Get Caption() As String
Caption = lblMain.Caption
End Property

Public Property Get bColor() As OLE_COLOR
bColor = Color1
lblMain.BackColor = Color1
lblMain.ForeColor = Color2
End Property

Public Property Get fColor() As OLE_COLOR
fColor = Color2
lblMain.BackColor = Color1
lblMain.ForeColor = Color2
End Property

Public Property Get PictButton() As Boolean
PictButton = imgIcon.Visible
End Property

Private Sub UserControl_Resize()
If Not blnImage = True Then 'UserControl.Ambient = False Then
    lblMain.Height = UserControl.Height
    'If UserControl.Ambient = False Then
    lblMain.Visible = True
    lblMain.Width = UserControl.Width
    lblMain.Left = 0
    'End If
Else
    lblMain.Width = 0
    lblMain.Visible = False
    h = UserControl.ScaleWidth
    imgIcon.Left = UserControl.ScaleWidth - imgIcon.Width
End If

    'KPD-Team 1999
    'URL: http://www.allapi.net/
    'E-Mail: KPDTeam@Allapi.net
    'Dim poly(1 To 4) As COORD, NumCoords As Long, hBrush As Long, hRgn As Long
    'UserControl.Cls
    ' Number of vertices in polygon.
    'NumCoords = 4
    ' Set scalemode to pixels to set up points of triangle.
    'UserControl.ScaleMode = vbPixels
    ' Assign values to points.
    'poly(1).x = UserControl.ScaleWidth / 2
    'poly(1).y = UserControl.ScaleHeight / 2
    'poly(2).x = UserControl.ScaleWidth / 4
    'poly(2).y = 3 * UserControl.ScaleHeight / 4
    'poly(3).x = 3 * UserControl.ScaleWidth / 4
    'poly(3).y = 3 * UserControl.ScaleHeight / 4
    'poly(4).x = 2 * UserControl.ScaleWidth / 2
    'poly(4).y = 2 * UserControl.ScaleHeight / 4
    '' Polygon function creates unfilled polygon on screen.
    '' Remark FillRgn statement to see results.
   '' Polygon Me.hdc, poly(1), NumCoords
    '' Gets stock black brush.
    ''hBrush = GetStockObject(BLACKBRUSH)
    '' Creates region to fill with color.
    ''hRgn = CreatePolygonRgn(poly(1), NumCoords, ALTERNATE)
    'SetWindowRgn UserControl.hWnd, hRgn, True
    '' If the creation of the region was successful then color.
    'If hRgn Then FillRgn UserControl.hdc, hRgn, hBrush
    'DeleteObject hRgn
End Sub

Private Sub UserControl_Show()
If blnImage = True Then
    imgIcon.Visible = True
    UserControl.Width = imgIcon.Width
    imgIcon.Left = h - imgIcon.Width
End If
End Sub

Private Sub UserControl_WriteProperties(PropBag As PropertyBag)
Call PropBag.WriteProperty("Caption", lblMain.Caption, "Done!")
Call PropBag.WriteProperty("bColor", bColor, &HF95107)
Call PropBag.WriteProperty("fColor", fColor, vbWhite)
Call PropBag.WriteProperty("FontName", FontName, "Times New Roman")
Call PropBag.WriteProperty("FontSize", FontSize, 12)
Call PropBag.WriteProperty("HoverTime", MyTrak.HoverTime, 400)
Call PropBag.WriteProperty("PictButton", PictButton, False)
End Sub

Public Property Let FontSize(ByVal New_FontSize As Integer)
lblMain.FontSize = New_FontSize
PropertyChanged "FontSize"
End Property

Public Property Let FontName(ByVal New_FontName As String)
lblMain.FontName = New_FontName
PropertyChanged "FontName"
End Property

Public Property Let Caption(ByVal New_Caption As String)
lblMain.Caption = New_Caption
PropertyChanged "Caption"
End Property

Public Property Let fColor(ByVal New_fColor As OLE_COLOR)
Color2 = New_fColor
PropertyChanged fColor
End Property

Public Property Let bColor(ByVal New_bColor As OLE_COLOR)
Color1 = New_bColor
PropertyChanged bColor
End Property

Public Property Let PictButton(ByVal New_PictButton As Boolean)
blnImage = New_PictButton
imgIcon.Visible = blnImage
PropertyChanged PictButton
End Property

Private Sub lblMain_Click()
RaiseEvent Click
End Sub

Private Sub MyTrak_MouseHover()
RaiseEvent MouseHover
End Sub

Private Sub MyTrak_MouseLeave()
RaiseEvent MouseLeave
lblMain.BackColor = Color1
lblMain.ForeColor = Color2
End Sub

Public Property Get HoverTime() As Long
HoverTime = MyTrak.HoverTime
End Property

Public Property Let HoverTime(newHoverTime As Long)
MyTrak.HoverTime = newHoverTime
PropertyChanged "HoverTime"
End Property

Private Sub UserControl_InitProperties()
Set MyTrak = New clsTrackInfo
If blnImage = True Then
    imgIcon.Visible = True
    UserControl.Width = imgIcon.Width
    imgIcon.Left = h - imgIcon.Width
End If
End Sub

Private Sub UserControl_Terminate()
EndTrack MyTrak
Set MyTrak = Nothing
End Sub

