Attribute VB_Name = "mdlProc"
Option Explicit
'Functions
Public Declare Function SetWindowRgn Lib "user32" (ByVal hWnd As Long, ByVal hRgn As Long, ByVal bRedraw As Boolean) As Long
Public Declare Function CreatePolygonRgn Lib "gdi32" (lpPoint As Any, ByVal nCount As Long, ByVal nPolyFillMode As Long) As Long
Public Declare Function Polygon Lib "gdi32" (ByVal hdc As Long, lpPoint As Any, ByVal nCount As Long) As Long
Public Declare Function FillRgn Lib "gdi32" (ByVal hdc As Long, ByVal hRgn As Long, ByVal hBrush As Long) As Long
Public Declare Function GetStockObject Lib "gdi32" (ByVal nIndex As Long) As Long
Public Declare Function DeleteObject Lib "gdi32" (ByVal hObject As Long) As Long

Private Declare Function TrackMouseEvent Lib "user32" (ByRef lpEventTrack As tagTRACKMOUSEEVENT) As Long
Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hWnd As Long, ByVal nIndex As Long, ByVal dwNewLong As Long) As Long
Private Declare Function CallWindowProc Lib "user32" Alias _
"CallWindowProcA" (ByVal lpPrevWndFunc As Long, _
   ByVal hWnd As Long, ByVal msg As Long, _
   ByVal wParam As Long, ByVal lParam As Long) As Long

'Types
Private Type tagTRACKMOUSEEVENT
    cbSize As Long
    dwFlags As Long
    hwndTrack As Long
    dwHoverTime As Long
End Type

Public Type COORD
    x As Long
    y As Long
End Type

'Constants
Private Const TME_HOVER = &H1
Private Const TME_LEAVE = &H2
Private Const TME_CANCEL = &H80000000
Private Const HOVER_DEFAULT = &HFFFFFFFF
Private Const WM_MOUSELEAVE = &H2A3
Private Const WM_MOUSEHOVER = &H2A1
Private Const WM_MOUSEMOVE = &H200
Private Const GWL_WNDPROC = (-4)

Public Const ALTERNATE = 1 ' ALTERNATE and WINDING are
Public Const WINDING = 2 ' constants for FillMode.
Public Const BLACKBRUSH = 4 ' Constant for brush type.


'Variables
Dim trackCol As Collection

Public Function StartTrack(trak As clsTrackInfo)
Dim prevProc As Long

If trackCol Is Nothing Then
    Set trackCol = New Collection
End If

trak.prevProc = SetWindowLong(trak.hWnd, GWL_WNDPROC, AddressOf WindowProc)
trackCol.Add trak, CStr(trak.hWnd)

RequestTracking trak

End Function
Public Function EndTrack(trak As clsTrackInfo)
If trackCol Is Nothing Then Exit Function

Call SetWindowLong(trak.hWnd, GWL_WNDPROC, trak.prevProc)

Dim trk As tagTRACKMOUSEEVENT
trk.cbSize = 16
trk.dwFlags = TME_LEAVE Or TME_HOVER Or TME_CANCEL
trk.hwndTrack = trak.hWnd
TrackMouseEvent trk

trackCol.Remove CStr(trak.hWnd)
If trackCol.Count = 0 Then
    Set trackCol = Nothing
End If


End Function

Private Function WindowProc(ByVal hWnd As Long, ByVal uMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
On Error GoTo 10:
Dim trak As clsTrackInfo
Set trak = trackCol.Item(CStr(hWnd))

If uMsg = WM_MOUSELEAVE Then
    trak.RaiseMouseLeave
ElseIf uMsg = WM_MOUSEHOVER Then
    trak.RaiseMouseHover
ElseIf uMsg = WM_MOUSEMOVE Then
    RequestTracking trak
    WindowProc = CallWindowProc(trak.prevProc, hWnd, uMsg, wParam, lParam)
Else
    WindowProc = CallWindowProc(trak.prevProc, hWnd, uMsg, wParam, lParam)
    'Debug.Print uMsg
End If

Exit Function
10:
Debug.Print Err.Description
End Function

Private Function RequestTracking(trak As clsTrackInfo)
Dim trk As tagTRACKMOUSEEVENT
trk.cbSize = 16
trk.dwFlags = TME_LEAVE Or TME_HOVER
trk.dwHoverTime = trak.HoverTime
trk.hwndTrack = trak.hWnd

TrackMouseEvent trk
End Function



