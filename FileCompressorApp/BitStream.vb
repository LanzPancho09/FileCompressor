Imports System.IO
Public Class BitStream

    Private Shared Freader As FileStream = Nothing

    Private Shared bitArray As BitArray
    Private Shared buffer(4096) As Byte

    Private Shared bytesRead As Integer = 0

    'speed
    Private Shared totalBytesRead As Long = 0

    Public Sub New()
    End Sub

    Public Sub New(ByRef Fread As FileStream)
        Freader = Fread
        bytesRead = Freader.Read(buffer, 0, buffer.Length)
        bitArray = New BitArray(buffer)
        totalBytesRead += bytesRead
    End Sub

    Public Sub New(ByRef Fread As FileStream, ByVal isSet As Boolean)
        Freader = Fread
    End Sub

    Public Sub New(ByVal filename As String, ByVal mode As FileMode, ByVal access As FileAccess)
        Try
            Freader = New FileStream(filename, mode, access)
            bytesRead = Freader.Read(buffer, 0, buffer.Length)
            bitArray = New BitArray(buffer)
            totalBytesRead += bytesRead
        Catch ex As Exception
            Freader = Nothing
            Console.WriteLine("There's a problem creating a file. " & ex.Message)
        End Try
    End Sub

    Public Function GetBufferLength() As Integer
        'Console.WriteLine(buffer.Length)
        Return buffer.Length
    End Function

    Public Function Read(ByRef _buffer As Boolean()) As Integer
        bytesRead = Freader.Read(buffer, 0, buffer.Length)
        bitArray = New BitArray(buffer)
        'Console.WriteLine("b length: " & bitArray.Length)
        bitArray.CopyTo(_buffer, 0)
        Return bytesRead
    End Function

    Private currentIndex As Integer = 0

    Public Function ReadBit() As Boolean
        currentIndex += 1
        Return bitArray.Get(currentIndex - 1)
    End Function

    Public Function IsBitAvailable() As Boolean

        If currentIndex > (bytesRead * 8) - 1 Then
            bytesRead = Freader.Read(buffer, 0, buffer.Length)
            bitArray = New BitArray(buffer)
            totalBytesRead += bytesRead
            currentIndex = 0
        End If

        If bytesRead > 0 Then
            Return True
        End If
        Freader.Dispose()
        Return False

    End Function

    Public Function GetReadSpeed() As Long
        Dim bytesRetrived As Long = totalBytesRead
        totalBytesRead = 0
        Return bytesRetrived
    End Function

End Class
