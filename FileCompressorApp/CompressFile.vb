Imports System.IO
Imports System.Threading

Public Class CompressFile

    Private isMultiple As Boolean = False

    Private Dictionary As New List(Of Object())
    Private rootNode As Node = Nothing
    Private totalFileRawBytes As Long = 0

    Private destPath As String = Nothing
    Private destFilename As String = Nothing
    Private rootPath As String = Nothing
    Private fileNames As List(Of String)
    Private fileSizes As List(Of Long)

    Public isLowRate As Boolean = False
    Public compressionDiff As Long = 0
    Public compressionPercent As Double = 0.0

    Private expectedHeader As Long = 0
    Private fileOutputPath As String = Nothing

    Private skipReading As Boolean = False
    Private ignoreCheck As Boolean = False

    Public Sub AssignData(ByVal dPath As String, ByVal dFilename As String, ByVal isMultiple As Boolean)
        Me.isMultiple = isMultiple
        Me.destPath = dPath
        Me.destFilename = dFilename
    End Sub

    Public Sub AssignData(ByVal dPath As String, ByVal dFilename As String, ByVal rootDir As String, ByVal filePaths As List(Of String), ByVal fileSizes As List(Of Long), ByVal isMultiple As Boolean)
        Me.isMultiple = isMultiple
        Me.destPath = dPath
        Me.destFilename = dFilename
        Me.rootPath = rootDir
        Me.fileNames = filePaths
        Me.fileSizes = fileSizes
    End Sub

    Public Sub Start()
        If isMultiple Then
            If Not Me.destPath = Nothing And Not Me.destFilename = Nothing And Not Me.rootPath = Nothing And Not Me.fileNames Is Nothing And Not Me.fileSizes Is Nothing Then
                'multiple files to be encoded
                EncodeMultipleFiles()
            End If
        Else
            If Not Me.destPath = Nothing Then
                EncodeFile()
            End If
        End If
    End Sub

    Public Sub EncodeFile()

        If Not skipReading Then

            'babasahin ung file tapos mag cecreate ng basic dictionary.
            Form1.status = "Reading File..."
            Form1.progressStatus = "Analyzing File..."

            ReadFile(Me.destFilename)
            'ShowDictionary()

            If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                Return
            End If

            'after mag read ng file kailangan mong gumawa ng tree. (Huffman tree)
            Form1.status = "Populating Data..."
            Form1.progressStatus = "Examining Data..."
            rootNode = CreateHuffmanTree()
            'Console.WriteLine(rootNode.getTotalFrequency())

            'after ng tree, need mo kunin ung code ng bawat byteValue.
            AssignByteCode()
            'ShowDictionary()

            Form1.status = "Checking for data integrity..."
            Form1.progressStatus = "Examining Data..."


            If Not ignoreCheck Then

                If Not isFileCompressible() Then
                    Form1.errorCode = 1
                    Console.WriteLine("cannot compress")
                    Return
                End If

                If isLowRate Then
                    Form1.errorCode = 7
                    Console.WriteLine("low rate")
                    skipReading = True
                    Return
                End If

            End If

        End If

        ShowDictionary()
        'gawa na ng binary header tapos convert mo na ung byteval then ung fx sa byte array.
        '(cecreate na ng binaryheader kasama nung data para sa tree.)
        Form1.status = "Compressing..."
        Form1.progressStatus = "Compressing Data..."

        WriteBinaryHeaderAndBits()

        Form1.status = "Finished!"
        Form1.progressStatus = "Finished!"
        Form1.folderStatus = "Done."
        Form1.fileStatus = "Done."

        'ShowProgressStatus("Finished")

    End Sub

    Public Sub DirectCompression()
        Form1.status = "Compressing..."
        Form1.progressStatus = "Compressing Data..."

        WriteBinaryHeaderAndBits()

        Form1.status = "Finished!"
        Form1.progressStatus = "Finished!"
        Form1.folderStatus = "Done."
        Form1.fileStatus = "Done."
    End Sub

    Private Sub EncodeMultipleFiles()

        If Not skipReading Then

            'read the files 
            Form1.status = "Reading Folder..."
            Form1.progressStatus = "Reading File..."
            ReadMultipleFiles()

            If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                Return
            End If

            'create huffman tree
            Form1.status = "Populating Data..."
            Form1.progressStatus = "Processing Data..."
            Form1.folderStatus = "Ongoing..."
            Form1.fileStatus = "Ongoing..."
            rootNode = CreateHuffmanTree()
            'assign tree bit code
            AssignByteCode()

            ShowDictionary()

            If Not ignoreCheck Then

                If Not isFilesCompressible() Then
                    Form1.errorCode = 1
                    Console.WriteLine("cannot compress")
                    Return
                    'Form1.status = "Compressing..."
                    'Form1.progressStatus = "Compressing Data..."
                    'WriteFilesBinaryHeader()
                End If

                If isLowRate Then
                    Form1.errorCode = 7
                    Console.WriteLine("low rate")
                    skipReading = True
                    Return
                End If

            End If

        End If

        Form1.status = "Compressing..."
        Form1.progressStatus = "Compressing Data..."
        WriteFilesBinaryHeader()

        Form1.status = "Finished!"
        Form1.progressStatus = "Finished!"
        Form1.folderStatus = "Done."
        Form1.fileStatus = "Done."


    End Sub

    Private Sub ReadFile(ByVal path As String)

        Dim myFile As New FileInfo(path)
        Dim sizeinbytes As Long = myFile.Length
        Dim totalBytesRead As Long = 0

        totalFileRawBytes = sizeinbytes

        Form1.folderStatus = myFile.DirectoryName
        Form1.fileStatus = myFile.Name

        Using fReader As New FileStream(path, FileMode.Open, FileAccess.Read)
            Dim bytesRead As Integer = 0
            Dim buffer(4096) As Byte

            Do
                bytesRead = fReader.Read(buffer, 0, buffer.Length)
                totalBytesRead += bytesRead
                CalculateByteFrequency(buffer, bytesRead)
                Form1.readSpeed += bytesRead

                'report
                Dim percent As Double = totalBytesRead / sizeinbytes
                Form1.overAllPercent = (percent * 20)
                Form1.processPercent = percent * 100

                If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                    Return
                End If

            Loop While bytesRead > 0
        End Using

        CreateByteFrequency()

    End Sub

    Private Sub ReadMultipleFiles()

        Dim overAllByteSize As Long = 0
        Dim overAllBytesRead As Long = 0

        For Each fpath As String In fileNames
            Dim fAttribute As FileAttribute = System.IO.File.GetAttributes(fpath)
            If fAttribute.HasFlag(FileAttribute.Directory) Then
                Continue For
            End If

            overAllByteSize += New FileInfo(fpath).Length
        Next

        totalFileRawBytes = overAllByteSize

        For Each fpath As String In fileNames

            'checks the path if it is directory, if the directory skip the current loop.
            Dim fAttribute As FileAttribute = System.IO.File.GetAttributes(fpath)
            If fAttribute.HasFlag(FileAttribute.Directory) Then
                Form1.folderStatus = fpath
                Continue For
            End If

            'file info
            Dim file As New FileInfo(fpath)
            Form1.folderStatus = file.DirectoryName
            Dim fileSize As Long = file.Length
            Dim totalBytesRead As Long = 0

            'read the file
            Form1.fileStatus = file.Name
            Using fReader As New FileStream(fpath, FileMode.Open, FileAccess.Read)
                Dim bytesRead As Integer = 0
                Dim buffer(4096) As Byte

                Do
                    bytesRead = fReader.Read(buffer, 0, buffer.Length)
                    totalBytesRead += bytesRead
                    overAllBytesRead += bytesRead
                    Form1.readSpeed += bytesRead
                    CalculateByteFrequency(buffer, bytesRead)

                    'report
                    Form1.overAllPercent = (overAllBytesRead / overAllByteSize) * 20
                    Form1.processPercent = (totalBytesRead / fileSize) * 100
                    'Console.WriteLine("Bytes Read: " & overAllBytesRead & " Total Byte Size: " & overAllByteSize & " %: " & overAllPercent)

                    If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                        Return
                    End If

                Loop While bytesRead > 0
            End Using

        Next

        CreateByteFrequency()

    End Sub

    Dim charFx(256) As Long
    Private Sub CalculateByteFrequency(ByVal buffer As Byte(), ByVal bytesRead As Integer)
        For i As Integer = 0 To bytesRead - 1
            charFx(buffer(i)) += 1
        Next
    End Sub

    Private Sub CreateByteFrequency()

        For i As Integer = 0 To charFx.Length - 1

            If charFx(i) <> 0 Then
                Dim nums(3) As Object
                nums(0) = i
                nums(1) = charFx(i)
                nums(2) = Nothing

                Dictionary.Add(nums)
            End If

        Next

    End Sub

    Private Function CreateHuffmanTree() As Node

        Dim treeNodes As New List(Of Node)

        'convert the array type dictionary to node
        For Each arry() As Object In Dictionary
            Dim n As New Node
            n.SetData(arry)
            n.setTotalFrequency(arry(1))
            treeNodes.Add(n)
        Next

        Dim treelength As Integer = treeNodes.Count

        'SortTreeNode(treeNodes)

        'Dim highestNode As Node = treeNodes(0)
        'For i As Integer = 0 To treeNodes.Count - 1
        '    Dim currentNode As Node = treeNodes(i)
        '    If highestNode.GetData(1) < currentNode.GetData(1) Then
        '        highestNode = currentNode
        '    End If
        'Next

        'treeNodes.Remove(highestNode)

        'Console.WriteLine("The highest node fx was: ")
        'Console.WriteLine(highestNode.GetData(0) & "     " & highestNode.GetData(1) & "           " & Form1.CalculateBytes(highestNode.GetData(1)))
        'Console.WriteLine()

        'Console.WriteLine("Index   ByteVal     FX         Size")
        'Console.WriteLine("======================================")
        'For i As Integer = 0 To treeNodes.Count - 1
        '    Console.WriteLine(i & "     " & treeNodes(i).GetData(0) & "     " & treeNodes(i).GetData(1) & "           " & Form1.CalculateBytes(treeNodes(i).GetData(1)))
        'Next

        'Console.WriteLine("creating tree percentage")

        While treeNodes.Count > 1

            'una sort ung list 
            SortTreeNode(treeNodes)

            'combine ang lowest 2 nodes
            Dim firstNode As Node = treeNodes(0)
            Dim secondNode As Node = treeNodes(1)

            Dim n As New Node
            'sets the parent node of the first and second nodes.
            firstNode.SetPNode(n)
            secondNode.SetPNode(n)

            'the lowest fx value node must set to the left and the highest value must set to the right
            n.setLNode(firstNode)
            n.setRNode(secondNode)

            'set the total fq
            Dim fx As Long = firstNode.getTotalFrequency() + secondNode.getTotalFrequency()
            n.setTotalFrequency(fx)

            Dim dataArry() As Object = {"Node", fx, Nothing}
            n.SetData(dataArry)

            treeNodes.RemoveAt(0)
            treeNodes.RemoveAt(0)

            treeNodes.Add(n)

            Dim percentage As Double = (treelength - treeNodes.Count) / treelength
            Form1.overAllPercent = (percentage * 2.5) + 20
            Form1.processPercent = percentage * 100
            'ShowProgressPercentage((percentage * 5) + 20)

        End While

        'Dim nw As New Node

        'Dim currentRNode As Node = treeNodes(0)
        'highestNode.SetPNode(nw)
        'currentRNode.SetPNode(nw)

        ''if the highest node fx was less than or equal to the current root node. 
        ''the highest node will set to Left node and the current node will set at the right node.
        ''otherwise, the opposite way.
        ''following Binary tree rules here.
        'If highestNode.GetData(1) <= currentRNode.GetData(1) Then
        '    nw.setLNode(highestNode)
        '    nw.setRNode(currentRNode)
        'Else
        '    nw.setLNode(currentRNode)
        '    nw.setRNode(highestNode)
        'End If

        'Dim totalNodeFx As Long = highestNode.getTotalFrequency() + currentRNode.getTotalFrequency()
        'nw.setTotalFrequency(totalNodeFx)
        'Dim dArray() As Object = {"Node", totalNodeFx, Nothing}
        'nw.SetData(dArray)

        Form1.overAllPercent = 22.5
        Form1.processPercent = 100

        'ShowProgressPercentage(25.0)

        'Console.WriteLine("byteVal   fx        code      ")
        'For Each nd As Node In treeNodes
        '    Dim arry() As Object = nd.GetData()
        '    Dim info As String = arry(0).ToString.PadRight(10) & arry(1).ToString.PadRight(10)
        '    Console.WriteLine(info)
        'Next

        Return treeNodes(0)

    End Function

    Private Sub SortTreeNode(ByRef treeNode As List(Of Node))

        While True

            Dim swaps As Integer = 0

            For i As Integer = 0 To treeNode.Count - 2

                Dim element1 As Node = treeNode(i)
                Dim element2 As Node = treeNode(i + 1)

                If element1.getTotalFrequency() > element2.getTotalFrequency() Then
                    treeNode(i) = element2
                    treeNode(i + 1) = element1
                    swaps += 1
                End If

            Next

            If swaps = 0 Then
                Exit While
            End If

        End While

    End Sub


    Private Sub AssignByteCode()

        Dim dictionaryLength As Integer = Dictionary.Count
        Dim assignedCount As Integer = 0

        'Console.WriteLine("Assign percentage: ")

        Dim q As New Queue(Of Node)
        q.Enqueue(rootNode)

        While q.Count > 0

            Dim n As Node = q.Dequeue()

            If n.getLNode() IsNot Nothing Then
                q.Enqueue(n.getLNode())
            End If

            If n.getRNode() IsNot Nothing Then
                q.Enqueue(n.getRNode())
            End If

            If Not n.HasChild Then
                'traverse the current node.

                Dim code As String = ""
                Dim currentNode As Node = n

                While Not currentNode.Equals(rootNode)

                    Dim parentNode As Node = currentNode.GetPNode()

                    If parentNode Is Nothing Then
                        Exit While
                    End If

                    If parentNode.getLNode().Equals(currentNode) Then
                        code += "1"
                    ElseIf parentNode.getRNode().Equals(currentNode) Then
                        code += "0"
                    End If

                    currentNode = parentNode

                End While

                code = StrReverse(code)

                'hinahanap ung bytevalue sa dictionary tapos iseset ung code nito.
                For Each arry() As Object In Dictionary

                    Dim nodeData As Object() = n.GetData()

                    If arry(0).Equals(nodeData(0)) Then
                        arry(2) = code

                        assignedCount += 1
                        Dim percentage As Double = assignedCount / dictionaryLength
                        Form1.overAllPercent = (percentage * 2.5) + 22.5
                        Form1.processPercent = percentage * 100

                        'Console.WriteLine("%: " & (percentage * 5) + 45)
                        'ShowProgressPercentage((percentage * 5) + 25)

                        Exit For
                    End If
                Next
            End If

        End While

    End Sub

    Private Sub WriteBinaryHeaderAndBits()

        'data tree
        Dim treeBytes As New Queue(Of Object())

        Dim treeByteLength As Integer = 0
        For Each arry() As Object In Dictionary
            Dim byteVal As Byte = arry(0)
            Dim byteFx As Long = arry(1)

            'bitConverter of short is = 2 and long is 8 = 10 per data.
            Dim nodeByte As Object() = {BitConverter.GetBytes(byteVal), BitConverter.GetBytes(byteFx)}
            treeBytes.Enqueue(nodeByte)
        Next

        'so the multiple of the data is 10 
        treeByteLength = treeBytes.Count * 10

        'assingning the new file output path
        Dim fi As New FileInfo(destFilename)
        Console.WriteLine("NAME: " & fi.Name)
        Console.WriteLine("EXTENSION: " & fi.Extension)

        'Dim filename As String = Nothing
        'If fi.Extension = "" Then
        '    filename = fi.Name
        'Else
        '    filename = fi.Name.Replace(fi.Extension, "")
        'End If

        Dim filename As String = fi.Name.Replace(fi.Extension, "")
        Dim extn As String = ".huff"
        Dim directory As String = destPath
        Dim outputPath = directory & "\" & filename & extn

        Dim ctr As Integer = 1
        While File.Exists(outputPath)
            outputPath = directory & "\" & filename & " (" & ctr.ToString & ")" & extn
            ctr += 1
        End While

        'DATA REPORT
        fileOutputPath = outputPath

        'isulat sa file ung treeByteArray then isama ung binary header
        Using Fwriter As New FileStream(outputPath, FileMode.Create, FileAccess.Write)

            'single file single thread type
            Dim encodingType() As Byte = {0}
            Fwriter.Write(encodingType, 0, encodingType.Length)

            'FOR REPORT
            expectedHeader += encodingType.Length

            'Console.WriteLine("Writed Bytes: ")
            'write binary header consists of 4 bytes
            Dim binHeader As Byte() = BitConverter.GetBytes(treeByteLength)
            Fwriter.Write(binHeader, 0, binHeader.Length)
            Form1.writeSpeed += binHeader.Length

            'FOR REPORT
            expectedHeader += binHeader.Length

            'For i As Integer = 0 To binHeader.Length - 1
            '    Console.Write(binHeader(i) & " ")
            'Next

            'write the tree data.
            While treeBytes.Count > 0
                Dim treeData As Object() = treeBytes.Dequeue()
                For i As Integer = 0 To treeData.Length - 1
                    Dim buffer As Byte() = treeData(i)
                    Fwriter.Write(buffer, 0, buffer.Length)
                    Form1.writeSpeed += buffer.Length

                    'FOR REPORT
                    expectedHeader += buffer.Length
                Next
            End While

            'and lastly write the totalbits to be read by the decoder.
            'change the bit to read to byte.
            Dim bitHeader() As Byte = BitConverter.GetBytes(fi.Length)
            Fwriter.Write(bitHeader, 0, bitHeader.Length)
            Form1.writeSpeed += bitHeader.Length

            'FOR REPORT
            expectedHeader += bitHeader.Length

            'totalBitsLength = totalBitCount
            'Console.WriteLine("total bit count: " & totalBitCount)

            'writing the file extension header and the original extension.
            Dim identicalExtsn As String = fi.Extension.Replace(".", "")
            Dim extsnHeader As Byte = identicalExtsn.Length
            Fwriter.WriteByte(extsnHeader)

            expectedHeader += 1

            Dim extnData() As Byte = System.Text.Encoding.UTF8.GetBytes(identicalExtsn)
            Fwriter.Write(extnData, 0, extnData.Length)
            Form1.writeSpeed += extnData.Length

            'FOR REPORT
            expectedHeader += extnData.Length

            'isulat mo na ung bytes to compressed bytes sa outputfile.
            WriteCompressedBytes(Fwriter)
            '==============================================
        End Using

        If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
            File.Delete(outputPath)
        End If

    End Sub

    Private Sub WriteFilesBinaryHeader()

        Form1.folderStatus = "Packing..."
        Form1.fileStatus = "Packing Data..."

        'data tree
        Dim treeBytes As New Queue(Of Object())

        For Each arry() As Object In Dictionary
            Dim byteVal As Byte = arry(0)
            Dim byteFx As Long = arry(1)

            'bitConverter of short is = 2 and long is 8 = 10 per data.
            Dim nodeByte As Object() = {BitConverter.GetBytes(byteVal), BitConverter.GetBytes(byteFx)}
            treeBytes.Enqueue(nodeByte)
        Next

        Dim treeByteLength As Integer = treeBytes.Count * 10



        Dim fpathQ As New Queue(Of String)
        Dim fileNamesCount As Short = fileNames.Count

        For Each fpath As String In fileNames
            Dim fAttribute As FileAttribute = File.GetAttributes(fpath)
            Dim outpath As String = Nothing
            If fAttribute.HasFlag(FileAttribute.Directory) Then
                outpath = "0" & fpath.Remove(0, rootPath.Length)
            Else
                outpath = "1" & fpath.Remove(0, rootPath.Length)
            End If
            fpathQ.Enqueue(outpath)
        Next

        'Console.WriteLine("File names count: " & fileNamesCount & "wroted filenames count: " & fpathQ.Count)

        Dim fileSizeByteCount As Integer = fileSizes.Count * 8

        Dim extn As String = ".huff"
        Dim outputPath = destPath & "\" & destFilename & extn

        Dim ctr As Integer = 1
        While File.Exists(outputPath)
            outputPath = destPath & "\" & destFilename & " (" & ctr.ToString & ")" & extn
            ctr += 1
        End While

        Form1.folderStatus = outputPath

        'data report
        fileOutputPath = outputPath

        'write the data
        Using fWriter As New FileStream(outputPath, FileMode.Create, FileAccess.Write)

            Dim encodingType() As Byte = {1}
            fWriter.Write(encodingType, 0, encodingType.Length)

            'FOR REPORT
            expectedHeader += encodingType.Length ' 1

            'tree data header
            Dim binHeader As Byte() = BitConverter.GetBytes(treeByteLength)
            fWriter.Write(binHeader, 0, binHeader.Length)
            Form1.writeSpeed += binHeader.Length

            'FOR REPORT
            expectedHeader += binHeader.Length ' 4

            'write the tree data.
            While treeBytes.Count > 0
                Dim treeData As Object() = treeBytes.Dequeue()
                For i As Integer = 0 To treeData.Length - 1
                    Dim buffer As Byte() = treeData(i)
                    fWriter.Write(buffer, 0, buffer.Length)
                    Form1.writeSpeed += buffer.Length

                    'FOR REPORT
                    expectedHeader += buffer.Length '???
                Next
            End While

            'file names data header
            Dim fileHeader As Byte() = BitConverter.GetBytes(fileNamesCount)
            fWriter.Write(fileHeader, 0, fileHeader.Length)
            Form1.writeSpeed += fileHeader.Length
            Console.WriteLine("Directory count: " & fileNamesCount & " Header length: " & fileHeader.Length)

            'FOR REPORT
            expectedHeader += fileHeader.Length


            'write path data.
            While fpathQ.Count > 0
                Dim fpath As String = fpathQ.Dequeue()

                Dim pathData As Byte() = System.Text.Encoding.UTF8.GetBytes(fpath)
                Dim pathLength As Byte() = BitConverter.GetBytes(pathData.Length)
                fWriter.Write(pathLength, 0, pathLength.Length)
                fWriter.Write(pathData, 0, pathData.Length)

                'Dim pathLength As Short = Convert.ToInt16(fpath.Length)

                'Dim pathLData As Byte() = BitConverter.GetBytes(pathLength)
                'fWriter.Write(pathLData, 0, pathLData.Length)
                'Form1.writeSpeed += pathLData.Length

                'Dim pathData As Byte() = System.Text.Encoding.ASCII.GetBytes(fpath)
                'fWriter.Write(pathData, 0, pathData.Length)
                'Form1.writeSpeed += pathData.Length

                'FOR REPORT
                expectedHeader += (pathLength.Length + pathData.Length)

                Console.WriteLine(fpath & " : " & " PathLength: " & pathData.Length & " Pdata: " & pathData.Length)
            End While

            'fileSize Header
            Dim fileSizeHeader As Byte() = BitConverter.GetBytes(fileSizeByteCount)
            fWriter.Write(fileSizeHeader, 0, fileSizeHeader.Length)
            Form1.writeSpeed += fileSizeHeader.Length

            'FOR REPORT
            expectedHeader += fileSizeHeader.Length

            'Console.WriteLine("file size header " & fileSizeByteCount)

            'write file size data
            For Each fsize As Long In fileSizes
                Console.WriteLine("File size: " & fsize)
                Dim fileSize As Byte() = BitConverter.GetBytes(fsize)
                fWriter.Write(fileSize, 0, fileSize.Length)
                Form1.writeSpeed += fileSize.Length

                'FOR REPORT
                expectedHeader += fileSize.Length
            Next

            'compress the file.
            WriteFilesCompressedBytes(fWriter, fileNames)

        End Using

        If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
            File.Delete(outputPath)
        End If

    End Sub

    Private Sub WriteFilesCompressedBytes(ByRef fwriter As FileStream, ByVal fileNames As List(Of String))

        Dim totalByte As Long = 0
        Dim totalReadedByte As Long = 0
        Dim totalwritedbyte As Long = 0

        For Each file As String In fileNames

            Dim fAttribute As FileAttribute = System.IO.File.GetAttributes(file)
            If fAttribute.HasFlag(FileAttribute.Directory) Then
                Continue For
            End If

            totalByte += New FileInfo(file).Length
        Next

        Dim dictionaryArray(256, 3) As Object

        For Each arry() As Object In Dictionary
            dictionaryArray(arry(0), 0) = arry(0)
            dictionaryArray(arry(0), 1) = arry(1)
            dictionaryArray(arry(0), 2) = arry(2)
        Next

        Dim byteCode As String = Nothing

        For Each file As String In fileNames

            Dim fAttribute As FileAttribute = System.IO.File.GetAttributes(file)

            If fAttribute.HasFlag(FileAttribute.Directory) Then
                Form1.folderStatus = file
                Continue For
            End If

            Dim fileSize As Long = New FileInfo(file).Length
            Dim readedBytes As Long = 0

            Dim fi As New FileInfo(file)
            Form1.fileStatus = "\" & fi.Name

            'NEW
            If fi.Length <= 0 Then
                Continue For
            End If

            Using Freader As New FileStream(file, FileMode.Open, FileAccess.Read)
                Dim bytesRead As Integer = 0

                Do
                    Dim buffer(4096) As Byte
                    bytesRead = Freader.Read(buffer, 0, buffer.Length)
                    readedBytes += bytesRead
                    totalReadedByte += bytesRead
                    Form1.readSpeed += bytesRead

                    For i As Integer = 0 To bytesRead - 1
                        byteCode += dictionaryArray(buffer(i), 2)

                        While byteCode.Length >= 8
                            'get the first 8 bits and convert to byte
                            fwriter.WriteByte(BinaryToByte(byteCode.Substring(0, 8)))
                            totalwritedbyte += 1
                            Form1.writeSpeed += 1

                            byteCode = byteCode.Remove(0, 8)
                        End While

                    Next

                    Dim percentage As Double = totalReadedByte / totalByte
                    Form1.overAllPercent = (percentage * 75) + 25
                    Form1.processPercent = (readedBytes / fileSize) * 100

                    If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                        Return
                    End If

                Loop While bytesRead > 0

            End Using

        Next

        If byteCode.Length = 0 Then
            Console.WriteLine("Total compressed data: " & totalWritedByte)
            Return
        End If

        If byteCode.Length < 8 Then
            byteCode += StrDup(8 - byteCode.Length, "0")
        End If
        'Console.WriteLine(byteCode)

        'get the first 8 bits and convert to byte
        Dim lastbyte As Byte = BinaryToByte(byteCode)
        fwriter.WriteByte(lastbyte)
        totalwritedbyte += 1
        Form1.writeSpeed += 1

        Console.WriteLine("Total compressed data: " & totalWritedByte)


    End Sub

    Private Sub WriteCompressedBytes(ByRef Fwriter As FileStream)

        Dim totalBitCount As Long = 0
        For Each arry() As Object In Dictionary
            totalBitCount += arry(1) * arry(2).ToString.Length
        Next

        Dim byteDecimal As Double = totalBitCount / 8
        Dim totalByteToWrite As Long = 0

        If byteDecimal <> Int(byteDecimal) Then
            totalByteToWrite = Math.Floor(byteDecimal) + 1
        Else
            totalByteToWrite = CLng(byteDecimal)
        End If

        Dim totalWritedByte As Long = 0

        Dim dictionaryArray(256, 3) As Object
        For Each arry() As Object In Dictionary
            dictionaryArray(arry(0), 0) = arry(0)
            dictionaryArray(arry(0), 1) = arry(1)
            dictionaryArray(arry(0), 2) = arry(2)
        Next

        'so una ang gagawin mo isulat mo sa string ung code nung byte by chunks.
        'pero convert mo muna ung list dictionary into array para mabilis ung time complexity.
        Using Freader As New FileStream(destFilename, FileMode.Open, FileAccess.Read)

            Dim byteCode As String = Nothing
            Dim bytesRead As Integer = 0

            Console.WriteLine("Compressed buffer: ")

            Do

                Dim buffer(4096) As Byte
                'read 4096bytes of chunk
                bytesRead = Freader.Read(buffer, 0, buffer.Length)
                Form1.readSpeed += bytesRead

                For i As Integer = 0 To bytesRead - 1
                    byteCode += dictionaryArray(buffer(i), 2)

                    While byteCode.Length >= 8

                        'get the first 8 bits and convert to byte
                        Fwriter.WriteByte(BinaryToByte(byteCode.Substring(0, 8)))
                        totalWritedByte += 1
                        Form1.writeSpeed += 1

                        byteCode = byteCode.Remove(0, 8)
                    End While

                Next

                Dim percentage As Double = totalWritedByte / totalByteToWrite
                Form1.overAllPercent = (percentage * 75) + 25
                Form1.processPercent = (totalWritedByte / totalByteToWrite) * 100

                If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                    Return
                End If

            Loop While bytesRead > 0

            'Console.WriteLine("Original bin")
            'Console.WriteLine(origBin)
            'Console.WriteLine("Remaining bits: " & byteCode.Length)

            If byteCode.Length = 0 Then
                Return
            End If

            If byteCode.Length < 8 Then
                byteCode += StrDup(8 - byteCode.Length, "0")
            End If
            'Console.WriteLine(byteCode)

            'get the first 8 bits and convert to byte
            Dim lastbyte As Byte = BinaryToByte(byteCode)
            Fwriter.WriteByte(lastbyte)
            totalWritedByte += 1

            'report
            Form1.overAllPercent = (totalWritedByte / totalByteToWrite * 75) + 25
            Form1.processPercent = (totalWritedByte / totalByteToWrite) * 100

            Console.WriteLine("Total writed byte: " & totalWritedByte)
        End Using

    End Sub

    Private Function isFileCompressible() As Boolean

        Dim totalFx As Long = 0
        Dim totalBitCount As Long = 0
        Dim hasByteCode As Boolean = False

        For Each arry() As Object In Dictionary
            totalFx += arry(1)
            'Dim info As String = arry(0).ToString.PadRight(10) & arry(1).ToString.PadRight(10)

            If arry(2) IsNot Nothing Then
                hasByteCode = True
                'info += arry(2).ToString.PadRight(10)
                totalBitCount += arry(1) * arry(2).ToString.Length
            End If
        Next

        Console.WriteLine("File size: " & totalFx)

        If hasByteCode Then
            'calculating if the file is compressable and calculating the approximate compressed byte
            Dim byteDecimal As Double = totalBitCount / 8
            Dim CompressedData As Long = 0

            If byteDecimal <> Int(byteDecimal) Then
                CompressedData = Math.Floor(byteDecimal) + 1
            Else
                CompressedData = CLng(byteDecimal)
            End If

            'not included the file extension data
            '12 means = 4 bytes for the binary header then 8 bytes for the totalbitstoread.
            Dim totalCompressedByte As Long = 4 + (Dictionary.Count * 10) + 12 + CompressedData

            compressionDiff = totalFx - totalCompressedByte
            compressionPercent = (compressionDiff / totalFx) * 100

            Console.WriteLine("Compression difference (Actual saved bytes): " & compressionDiff)
            Console.WriteLine("Compression percentage: " & compressionPercent.ToString & " %")

            If totalCompressedByte < totalFx Then
                'Console.WriteLine("File can be compressed!")

                If compressionPercent < 3.0 Then
                    isLowRate = True
                End If

                Return True
            End If
            'Console.WriteLine("Approximate total compressed Byte: " & totalCompressedByte)
        End If

        Return False
    End Function

    Private Function isFilesCompressible()

        Dim hasByteCode = True
        Dim totalByte As Long = 0
        Dim totalBitCount As Long = 0

        For Each arry() As Object In Dictionary
            totalByte += arry(1)

            If arry(2) IsNot Nothing Then
                hasByteCode = True
                totalBitCount += arry(1) * arry(2).ToString.Length
            End If
        Next

        Console.WriteLine("File size: " & totalByte)
        Dim totalCompressedByte As Long = 0

        If hasByteCode Then

            Dim byteDecimal As Double = totalBitCount / 8
            Dim CompressedData As Long = 0

            Console.WriteLine("divided byte decimal: " & byteDecimal)

            If byteDecimal <> Int(byteDecimal) Then
                CompressedData = Math.Floor(byteDecimal) + 1
            Else
                CompressedData = CLng(byteDecimal)
            End If

            Dim fileNameBytesCount As Integer = 0
            For Each file As String In fileNames
                fileNameBytesCount += file.Remove(0, rootPath.Length).Length + 3
            Next

            Dim fileSizeByteCount As Integer = fileSizes.Count * 8

            totalCompressedByte = 4 + (Dictionary.Count * 10) + 2 + fileNameBytesCount + 4 + fileSizeByteCount + CompressedData
            compressionDiff = totalByte - totalCompressedByte
            compressionPercent = (compressionDiff / totalByte) * 100

            Console.WriteLine("data header length: " & (4 + (Dictionary.Count * 10) + 2 + fileNameBytesCount + 4 + fileSizeByteCount))
            Console.WriteLine("Compressed Data: " & CompressedData)
            Console.WriteLine("Compression difference (Actual saved bytes): " & compressionDiff)
            Console.WriteLine("Compression percentage: " & compressionPercent.ToString & " %")

        End If

        If totalCompressedByte < totalByte Then

            If compressionPercent < 3.0 Then
                isLowRate = True
            End If

            Return True
        End If

        Return False

    End Function

    Public Sub ShowDictionary()

        Console.WriteLine("byteVal   fx        code      ")

        Dim totalFx As Long = 0
        Dim totalBitCount As Long = 0
        Dim hasByteCode As Boolean = False

        For Each arry() As Object In Dictionary
            totalFx += arry(1)
            Dim info As String = arry(0).ToString.PadRight(10) & arry(1).ToString.PadRight(10)

            If arry(2) IsNot Nothing Then
                hasByteCode = True
                info += arry(2).ToString.PadRight(10)
                totalBitCount += arry(1) * arry(2).ToString.Length
            End If

            Console.WriteLine(info)
        Next

        Console.WriteLine(StrDup(30, "="))
        Console.WriteLine(Dictionary.Count.ToString.PadRight(10) & totalFx.ToString.PadRight(30) & totalBitCount.ToString.PadRight(30))

        If hasByteCode Then

            'calculating if the file is compressable and calculating the approximate compressed byte
            Dim byteDecimal As Double = totalBitCount / 8
            Dim CompressedData As Long = 0

            If byteDecimal <> Int(byteDecimal) Then
                CompressedData = Math.Floor(byteDecimal) + 1
            Else
                CompressedData = CLng(byteDecimal)
            End If

            Dim headerData As Long = 4 + (Dictionary.Count * 10) + 12
            Dim totalCompressedByte As Long = headerData + CompressedData

            Console.WriteLine("Header data length: " & headerData)
            Console.WriteLine("Compressed Data length: " & CompressedData)
            Console.WriteLine("Approximate total compressed Byte: " & totalCompressedByte)

            If totalCompressedByte < totalFx Then
                Console.WriteLine("File can be compressed!")
            End If

        End If

    End Sub

    Public Function GetComputeCompressedSize() As Long

        Dim totalBitCount As Long = 0
        Dim expectedOutputSize As Long = 0

        For Each arry() As Object In Dictionary
            totalBitCount += arry(1) * arry(2).ToString.Length
        Next

        If Not (totalBitCount / 8) Mod 8 = 0 Then
            expectedOutputSize = (totalBitCount \ 8) + 1
        Else
            expectedOutputSize = totalBitCount / 8
        End If

        Return expectedOutputSize

    End Function

    Public Function GetComputedCompressedHeader() As Long
        Return expectedHeader
    End Function

    Public Function GetOutputPath() As String
        Return fileOutputPath
    End Function

    Public Sub SetIgnore(ByVal status As Boolean)
        Me.ignoreCheck = status
    End Sub


    'need 8 bits
    '========o(8)=======
    'Private Function BinaryToByte(ByVal binary As String) As Byte
    '    Dim bitsValue() As Integer = {128, 64, 32, 16, 8, 4, 2, 1}
    '    Dim binaryValue As Integer = 0

    '    For i As Integer = 0 To binary.Length - 1
    '        If binary(i) = "1" Then
    '            binaryValue += bitsValue(i)
    '        End If
    '    Next

    '    Return binaryValue
    'End Function

    Public Function BinaryToByte(ByVal binary As String) As Byte
        Return (Val(binary(0)) * (2 ^ 0)) + (Val(binary(1)) * (2 ^ 1)) + (Val(binary(2)) * (2 ^ 2)) + (Val(binary(3)) * (2 ^ 3)) + (Val(binary(4)) * (2 ^ 4)) + (Val(binary(5)) * (2 ^ 5)) + (Val(binary(6)) * (2 ^ 6)) + (Val(binary(7)) * (2 ^ 7))
    End Function

    Public Function GetTotalByteOfRawFiles() As Long
        Return totalFileRawBytes
    End Function

End Class
