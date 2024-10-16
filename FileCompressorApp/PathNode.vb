Public Class PathNode

    Private parentNode As PathNode = Nothing
    Private currentNode As New List(Of PathNode)
    Private name As String = Nothing
    Private isFile As Boolean = False
    Private fileSize As Long = 0

    Public Sub New()
    End Sub

    Public Sub New(ByVal n As String)
        Me.name = n
    End Sub

    Public Function GetName() As String
        Return Me.name
    End Function

    Public Function GetParent() As PathNode
        If parentNode IsNot Nothing Then
            Return Me.parentNode
        End If
        Return Nothing
    End Function

    Public Function GetList() As List(Of PathNode)
        Return currentNode
    End Function

    Public Function GetAt(ByVal i As Integer) As PathNode
        If currentNode.Count <= 0 Then
            Return Nothing
        End If

        Return currentNode(i)
    End Function

    Public Function GetFileSize() As Long
        Return fileSize
    End Function

    Public Sub SetFile()
        Me.isFile = True
    End Sub

    Public Sub SetFileSize(ByVal val As Long)
        Me.fileSize = val
    End Sub

    Public Sub SetParent(ByVal p As PathNode)
        Me.parentNode = p
    End Sub

    Public Sub AddNode(ByVal n As PathNode)
        Me.currentNode.Add(n)
    End Sub

    Public Function GetNodeByName(ByVal n As String) As PathNode
        If currentNode.Count <= 0 Then
            Return Nothing
        End If

        For Each p As PathNode In currentNode
            If p.GetName.ToLower().Equals(n.ToLower()) Then
                Return p
            End If
        Next
        Return Nothing
    End Function

    Public Function Count() As Integer
        Return currentNode.Count
    End Function

    Public Function IsNodeFile() As Boolean
        Return isFile
    End Function

End Class
