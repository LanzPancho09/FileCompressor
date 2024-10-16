Public Class Node

    'Class Properties
    Private totalFrequency As Long = 0
    Private data As Object() = Nothing

    'For storing Nodes.
    Private PNode As Node = Nothing 'parent
    Private LNode As Node = Nothing 'left
    Private RNode As Node = Nothing 'right

    'Setter and getters

    Public Sub SetData(ByVal arry As Object())
        Me.data = arry
    End Sub

    Public Function GetData() As Object()
        Return Me.data
    End Function

    'Frequency
    Public Sub setTotalFrequency(ByVal num As Long)
        Me.totalFrequency = num
    End Sub

    Public Function getTotalFrequency() As Long
        Return Me.totalFrequency
    End Function

    Public Sub setRNode(ByVal Rnode As Node)
        Me.RNode = Rnode
    End Sub

    Public Sub setLNode(ByVal Lnode As Node)
        Me.LNode = Lnode
    End Sub

    'Node getter
    Public Function getLNode() As Node
        Return Me.LNode
    End Function

    Public Function getRNode() As Node
        Return Me.RNode
    End Function

    Public Sub SetPNode(ByVal n As Node)
        Me.PNode = n
    End Sub

    Public Function GetPNode() As Node
        Return Me.PNode
    End Function

    Public Function HasChild() As Boolean
        If Me.LNode IsNot Nothing Or Me.RNode IsNot Nothing Then
            Return True
        End If

        Return False
    End Function

End Class
