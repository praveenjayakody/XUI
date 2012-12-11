'Author: Arman Ghazanchyan
'Created date: 01/27/2007
'Last updated: 07/08/2008

Imports System.Drawing.Drawing2D

''' <summary>
''' Provides methods to round the corners of a rectangle or create rounded corner region.
''' </summary>
<CLSCompliant(True)> _
Public NotInheritable Class Shape

#Region " Enumarations "

    <Flags()> _
    Public Enum Corner As Integer
        None = 0
        TopLeft = 1
        TopRight = 2
        BottomRight = 4
        BottomLeft = 8
    End Enum

#End Region

#Region " Methods "

    <DebuggerHidden()> _
    Private Sub New()
    End Sub

    ''' <summary>
    ''' Rounds the corners of a rectangle and returns the graphics path.
    ''' </summary>
    ''' <param name="rect">A rectangle whose corners should be rounded.</param>
    ''' <param name="radius">The radius of the rounded corners. This value should be 
    ''' bigger than or equal to 0 and less or equal to the half of the smallest value 
    ''' of the rectangle’s side.</param>
    ''' <param name="exclude">A value that specifies the corners that should be excluded from rounding. This value 
    ''' can be one or combination of the Shape.Corner enumeration value combined by "OR".</param>
    <DebuggerHidden()> _
    Public Overloads Shared Function RoundedRectangle(ByVal rect As RectangleF, ByVal radius As Single, ByVal exclude As Corner) As Drawing2D.GraphicsPath

        'If radius is less than zero, 
        'throw an ArgumentException.
        If radius < 0.0F Then
            Throw New ArgumentException("Invalid argument. The value cannot be negativ.", "radius")
        End If

        'If the rectangle object is empty, 
        'than throw an ArgumentException.
        If rect.IsEmpty Then
            Throw New ArgumentException("Invalid argument. The rectangle cannot be empty.", "rect")
        End If

        'Return-rounded rectangle path.
        Return Shape.GetPath(rect.X, rect.Y, _
        rect.Width, rect.Height, radius, exclude)

    End Function

    ''' <summary>
    ''' Rounds the corners of a rectangle and returns the graphics path.
    ''' </summary>
    ''' <param name="rect">A rectangle whose corners should be rounded.</param>
    ''' <param name="radius">The radius of the rounded corners. This value should be 
    ''' bigger than or equal to 0 and less or equal to the half of the smallest value 
    ''' of the rectangle’s side.</param>
    ''' <param name="exclude">A value that specifies the corners that should be excluded from rounding. This value 
    ''' can be one or combination of the Shape.Corner enumeration value combined by "OR".</param>
    <DebuggerHidden()> _
    Public Overloads Shared Function RoundedRectangle(ByVal rect As Rectangle, ByVal radius As Integer, ByVal exclude As Corner) As Drawing2D.GraphicsPath

        'If radius is less than zero, 
        'throw an ArgumentException.
        If radius < 0.0F Then
            Throw New ArgumentException("Invalid argument. The value cannot be negativ.", "radius")
        End If

        'If the rectangle object is empty, 
        'than throw an ArgumentException.
        If rect.IsEmpty Then
            Throw New ArgumentException("Invalid argument. The rectangle cannot be empty.", "rect")
        End If

        'Return-rounded rectangle path.
        Return Shape.GetPath(CSng(rect.X), CSng(rect.Y), _
        CSng(rect.Width), CSng(rect.Height), CSng(radius), exclude)

    End Function

    ''' <summary>
    ''' Creats and returns a rounded corner region.
    ''' </summary>
    ''' <param name="rSize">The size of the region.</param>
    ''' <param name="radius">The radius of the rounded corners. This value should be 
    ''' bigger than or equal to 0 and less or equal to the half of the smallest value 
    ''' of the region’s side.</param>
    ''' <param name="exclude">A value that specifies the corners that should be excluded from rounding. This value 
    ''' can be one or combination of the Shape.Corner enumeration value combined by "OR".</param>
    <DebuggerHidden()> _
    Public Overloads Shared Function RoundedRegion(ByVal rSize As SizeF, ByVal radius As Single, ByVal exclude As Corner) As Region

        'If radius is less than zero, 
        'throw an ArgumentException.
        If radius < 0.0F Then
            Throw New ArgumentException("Invalid argument. The value cannot be negativ.", "radius")
        End If

        'If the rectangle object is empty, 
        'than throw an ArgumentException.
        If rSize.IsEmpty Then
            Throw New ArgumentException("Invalid argument. The rectangle cannot be empty.", "rSize")
        End If

        'Return-rounded rectangle region.
        Return Shape.GetRegion(0.0F, 0.0F, rSize.Width, rSize.Height, radius, exclude)

    End Function

    ''' <summary>
    ''' Creats and returns a rounded corner region.
    ''' </summary>
    ''' <param name="rSize">The size of the region.</param>
    ''' <param name="radius">The radius of the rounded corners. This value should be 
    ''' bigger than or equal to 0 and less or equal to the half of the smallest value 
    ''' of the region’s side.</param>
    ''' <param name="exclude">A value that specifies the corners that should be excluded from rounding. This value 
    ''' can be one or combination of the Shape.Corner enumeration value combined by "OR".</param>
    <DebuggerHidden()> _
    Public Overloads Shared Function RoundedRegion(ByVal rSize As Size, ByVal radius As Integer, ByVal exclude As Corner) As Region

        'If radius is less than zero, 
        'throw an ArgumentException.
        If radius < 0.0F Then
            Throw New ArgumentException("Invalid argument. The value cannot be negativ.", "radius")
        End If

        'If the rectangle object is empty, 
        'than throw an ArgumentException.
        If rSize.IsEmpty Then
            Throw New ArgumentException("Invalid argument. The rectangle cannot be empty.", "rSize")
        End If

        'Return-rounded rectangle region.
        Return Shape.GetRegion(0.0F, 0.0F, CSng(rSize.Width), CSng(rSize.Height), CSng(radius), exclude)

    End Function

    ''' <summary>
    ''' Creats and returns a rounded corner region.
    ''' </summary>
    ''' <param name="rect">The rectangle of the region.</param>
    ''' <param name="radius">The radius of the rounded corners. This value should be 
    ''' bigger than or equal to 0 and less or equal to the half of the smallest value 
    ''' of the region’s side.</param>
    ''' <param name="exclude">A value that specifies the corners that should be excluded from rounding. This value 
    ''' can be one or combination of the Shape.Corner enumeration value combined by "OR".</param>
    <DebuggerHidden()> _
    Public Overloads Shared Function RoundedRegion(ByVal rect As RectangleF, ByVal radius As Single, ByVal exclude As Corner) As Region

        'If radius is less than zero, 
        'throw an ArgumentException.
        If radius < 0.0F Then
            Throw New ArgumentException("Invalid argument. The value cannot be negativ.", "radius")
        End If

        'If the rectangle object is empty, 
        'than throw an ArgumentException.
        If rect.IsEmpty Then
            Throw New ArgumentException("Invalid argument. The rectangle cannot be empty.", "rect")
        End If

        'Return-rounded rectangle region.
        Return Shape.GetRegion(rect.X, rect.Y, rect.Width, rect.Height, radius, exclude)

    End Function

    ''' <summary>
    ''' Creats and returns a rounded corner region.
    ''' </summary>
    ''' <param name="rect">The rectangle of the region.</param>
    ''' <param name="radius">The radius of the rounded corners. This value should be 
    ''' bigger than or equal to 0 and less or equal to the half of the smallest value 
    ''' of the region’s side.</param>
    ''' <param name="exclude">A value that specifies the corners that should be excluded from rounding. This value 
    ''' can be one or combination of the Shape.Corner enumeration value combined by "OR".</param>
    <DebuggerHidden()> _
    Public Overloads Shared Function RoundedRegion(ByVal rect As Rectangle, ByVal radius As Integer, ByVal exclude As Corner) As Region

        'If radius is less than zero, 
        'throw an ArgumentException.
        If radius < 0.0F Then
            Throw New ArgumentException("Invalid argument. The value cannot be negativ.", "radius")
        End If

        'If the rectangle object is empty, 
        'than throw an ArgumentException.
        If rect.IsEmpty Then
            Throw New ArgumentException("Invalid argument. The rectangle cannot be empty.", "rect")
        End If

        'Return-rounded rectangle region.
        Return Shape.GetRegion(CSng(rect.X), CSng(rect.Y), CSng(rect.Width), _
        CSng(rect.Height), CSng(radius), exclude)

    End Function

    <DebuggerHidden()> _
    Private Shared Function GetPath( _
    ByVal x As Single, _
    ByVal y As Single, _
    ByVal width As Single, _
    ByVal height As Single, _
    ByVal r As Single, _
    ByVal exclude As Corner) As GraphicsPath

        Dim path As New GraphicsPath()
        'If radius is equal to zero, 
        'than return a simple rectangle path.
        If r = 0.0F Then
            path.AddRectangle(New RectangleF(x, y, width, height))
            Return path
        End If

        'Small corner square-rectangles width
        Dim w As Single = r + r
        'If 'w' is bigger than the smallest value of the whidth/height, 
        'than assign the smallest value of the whidth/height to 'w'.
        If height < width Then
            If w > height Then
                w = height
            End If
        Else
            If w > width Then
                w = width
            End If
        End If
        path.StartFigure()
        'Set top-left corner.
        If (exclude And Corner.TopLeft) <> Corner.TopLeft Then
            path.AddLine(x, y + r, x, y + r)
            path.AddArc(x, y, w, w, 180.0F, 90.0F)
            path.AddLine(x + r, y, x + r, y)
        Else
            path.AddLine(x, y, x, y)
        End If
        'Set top-right corner.
        If (exclude And Corner.TopRight) <> Corner.TopRight Then
            path.AddLine(x + width - r, y, x + width - r, y)
            path.AddArc(x + width - w, y, w, w, 270.0F, 90.0F)
            path.AddLine(x + width, y + r, x + width, y + r)
        Else
            path.AddLine(x + width, y, x + width, y)
        End If
        'Set bottom-right corner.
        If (exclude And Corner.BottomRight) <> Corner.BottomRight Then
            path.AddLine(x + width, y + height - r, x + width, y + height - r)
            path.AddArc(x + width - w, y + height - w, w, w, 0.0F, 90.0F)
            path.AddLine(x + width - r, y + height, x + width - r, y + height)
        Else
            path.AddLine(x + width, y + height, x + width, y + height)
        End If
        'Set bottom-left corner.
        If (exclude And Corner.BottomLeft) <> Corner.BottomLeft Then
            path.AddLine(x + r, y + height, x + r, y + height)
            path.AddArc(x, y + height - w, w, w, 90.0F, 90.0F)
            path.AddLine(x, y + height - r, x, y + height - r)
        Else
            path.AddLine(x, y + height, x, y + height)
        End If
        path.CloseAllFigures()
        Return path

    End Function

    <DebuggerHidden()> _
    Private Shared Function GetRegion( _
    ByVal x As Single, _
    ByVal y As Single, _
    ByVal width As Single, _
    ByVal height As Single, _
    ByVal r As Single, _
    ByVal exclude As Corner) As Region

        Dim path As New GraphicsPath
        'If radius is equal to zero, 
        'than return a simple rectangle region.
        If r = 0.0F Then
            path.AddRectangle(New RectangleF(x, y, width, height))
            Return New Region(path)
        End If

        'Small corner square-rectangles width
        Dim w As Single = r + r
        'If 'w' is bigger than the smallest value of the whidth/height, 
        'than assign the smallest value of the whidth/height to 'w'.
        If height < width Then
            If w > height Then
                w = height
            End If
        Else
            If w > width Then
                w = width
            End If
        End If
        path.StartFigure()
        'Set top-left corner.
        If (exclude And Corner.TopLeft) <> Corner.TopLeft Then
            path.AddLine(x, y + r, x, y + r)
            path.AddArc(x, y, w - 1.0F, w - 1.0F, 180.0F, 90.0F)
            path.AddLine(x + r, y, x + r, y)
        Else
            path.AddLine(x, y, x, y)
        End If
        'Set top-right corner.
        If (exclude And Corner.TopRight) <> Corner.TopRight Then
            path.AddLine(x + width - r, y, x + width - r, y)
            path.AddArc(x + width - w, y, w - 1.0F, w - 1.0F, 270.0F, 90.0F)
            path.AddLine(x + width, y + r, x + width, y + r)
        Else
            path.AddLine(x + width, y, x + width, y)
        End If
        'Set bottom-right corner.
        If (exclude And Corner.BottomRight) <> Corner.BottomRight Then
            path.AddLine(x + width, y + height - r - 1.0F, x + width, y + height - r - 1.0F)
            path.AddArc(x + width - w, y + height - w, w - 1.0F, w - 1.0F, 0.0F, 90.0F)
            path.AddLine(x + width - r - 1.0F, y + height, x + width - r - 1.0F, y + height)
        Else
            path.AddLine(x + width, y + height, x + width, y + height)
        End If
        'Set bottom-left corner.
        If (exclude And Corner.BottomLeft) <> Corner.BottomLeft Then
            path.AddLine(x + r + 1.0F, y + height, x + r + 1.0F, y + height)
            path.AddArc(x, y + height - w, w - 1.0F, w - 1.0F, 90.0F, 90.0F)
            path.AddLine(x, y + height - r - 1.0F, x, y + height - r - 1.0F)
        Else
            path.AddLine(x, y + height, x, y + height)
        End If
        path.CloseAllFigures()
        Return New Region(path)

    End Function

#End Region

End Class
