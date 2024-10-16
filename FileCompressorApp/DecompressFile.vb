Imports System.IO

Public Class DecompressFile

    Private ReadOnly BinArray As String() = {
            "00000000",
            "00000001",
            "00000010",
            "00000011",
            "00000100",
            "00000101",
            "00000110",
            "00000111",
            "00001000",
            "00001001",
            "00001010",
            "00001011",
            "00001100",
            "00001101",
            "00001110",
            "00001111",
            "00010000",
            "00010001",
            "00010010",
            "00010011",
            "00010100",
            "00010101",
            "00010110",
            "00010111",
            "00011000",
            "00011001",
            "00011010",
            "00011011",
            "00011100",
            "00011101",
            "00011110",
            "00011111",
            "00100000",
            "00100001",
            "00100010",
            "00100011",
            "00100100",
            "00100101",
            "00100110",
            "00100111",
            "00101000",
            "00101001",
            "00101010",
            "00101011",
            "00101100",
            "00101101",
            "00101110",
            "00101111",
            "00110000",
            "00110001",
            "00110010",
            "00110011",
            "00110100",
            "00110101",
            "00110110",
            "00110111",
            "00111000",
            "00111001",
            "00111010",
            "00111011",
            "00111100",
            "00111101",
            "00111110",
            "00111111",
            "01000000",
            "01000001",
            "01000010",
            "01000011",
            "01000100",
            "01000101",
            "01000110",
            "01000111",
            "01001000",
            "01001001",
            "01001010",
            "01001011",
            "01001100",
            "01001101",
            "01001110",
            "01001111",
            "01010000",
            "01010001",
            "01010010",
            "01010011",
            "01010100",
            "01010101",
            "01010110",
            "01010111",
            "01011000",
            "01011001",
            "01011010",
            "01011011",
            "01011100",
            "01011101",
            "01011110",
            "01011111",
            "01100000",
            "01100001",
            "01100010",
            "01100011",
            "01100100",
            "01100101",
            "01100110",
            "01100111",
            "01101000",
            "01101001",
            "01101010",
            "01101011",
            "01101100",
            "01101101",
            "01101110",
            "01101111",
            "01110000",
            "01110001",
            "01110010",
            "01110011",
            "01110100",
            "01110101",
            "01110110",
            "01110111",
            "01111000",
            "01111001",
            "01111010",
            "01111011",
            "01111100",
            "01111101",
            "01111110",
            "01111111",
            "10000000",
            "10000001",
            "10000010",
            "10000011",
            "10000100",
            "10000101",
            "10000110",
            "10000111",
            "10001000",
            "10001001",
            "10001010",
            "10001011",
            "10001100",
            "10001101",
            "10001110",
            "10001111",
            "10010000",
            "10010001",
            "10010010",
            "10010011",
            "10010100",
            "10010101",
            "10010110",
            "10010111",
            "10011000",
            "10011001",
            "10011010",
            "10011011",
            "10011100",
            "10011101",
            "10011110",
            "10011111",
            "10100000",
            "10100001",
            "10100010",
            "10100011",
            "10100100",
            "10100101",
            "10100110",
            "10100111",
            "10101000",
            "10101001",
            "10101010",
            "10101011",
            "10101100",
            "10101101",
            "10101110",
            "10101111",
            "10110000",
            "10110001",
            "10110010",
            "10110011",
            "10110100",
            "10110101",
            "10110110",
            "10110111",
            "10111000",
            "10111001",
            "10111010",
            "10111011",
            "10111100",
            "10111101",
            "10111110",
            "10111111",
            "11000000",
            "11000001",
            "11000010",
            "11000011",
            "11000100",
            "11000101",
            "11000110",
            "11000111",
            "11001000",
            "11001001",
            "11001010",
            "11001011",
            "11001100",
            "11001101",
            "11001110",
            "11001111",
            "11010000",
            "11010001",
            "11010010",
            "11010011",
            "11010100",
            "11010101",
            "11010110",
            "11010111",
            "11011000",
            "11011001",
            "11011010",
            "11011011",
            "11011100",
            "11011101",
            "11011110",
            "11011111",
            "11100000",
            "11100001",
            "11100010",
            "11100011",
            "11100100",
            "11100101",
            "11100110",
            "11100111",
            "11101000",
            "11101001",
            "11101010",
            "11101011",
            "11101100",
            "11101101",
            "11101110",
            "11101111",
            "11110000",
            "11110001",
            "11110010",
            "11110011",
            "11110100",
            "11110101",
            "11110110",
            "11110111",
            "11111000",
            "11111001",
            "11111010",
            "11111011",
            "11111100",
            "11111101",
            "11111110",
            "11111111"
        }

    Private Dictionary As New List(Of Object())
    Private rootNode As Node = Nothing
    Private totalFileRawBytes As Long = 0

    Private expectedHeader As Long = 0
    Private fileOutputPath As String = Nothing
    Private expectedOutputLength As Long = 0

    'Private bstream As BitStream = Nothing
    'Private isBitStream As Boolean = False

    Private filePath As String = Nothing
    Private destinationPath As String = Nothing
    Private decodedTotalBytes As Long = 0 ' for multiple file and for tracking exact value of extracted datas.

    Public Sub AssignData(ByVal filePath As String, ByVal destinationPath As String)
        Me.filePath = filePath
        Me.destinationPath = destinationPath
    End Sub

    Public Sub Start()

        Dim userFile As New FileInfo(Me.filePath)
        Dim encMode As Integer = -1
        'retrive the file mode.
        Using Freader As New FileStream(userFile.FullName, FileMode.Open, FileAccess.Read)
            Dim encodingType(0) As Byte
            Freader.Read(encodingType, 0, encodingType.Length)
            encMode = encodingType(0)
        End Using


        If encMode = 0 Then
            UnBonkFile(Me.filePath, Me.destinationPath)
        ElseIf encMode = 1 Then
            UnBonkFiles(Me.filePath, Me.destinationPath)
        End If

        ''checks if the user assigns the file path and the destination path.
        'If Me.filePath IsNot Nothing And Me.destinationPath IsNot Nothing Then

        '    Dim fi As New FileInfo(filePath)
        '    totalFileRawBytes = fi.Length
        '    Dim extsn As String = fi.Extension.Replace(".", "").ToLower

        '    If extsn = "bonk" Then
        '        UnBonkFiles(Me.filePath, Me.destinationPath)
        '    ElseIf extsn = "rawr" Then
        '        UnBonkFile(Me.filePath, Me.destinationPath)
        '    End If
        'End If
    End Sub

    Public Sub UnBonkFile(ByVal filePath As String, ByVal destPath As String)

        Form1.status = "Populating Data..."
        Form1.progressStatus = "Reading Data..."

        Dim totalHeaderReaded As Long = 0
        'Decoder 
        Using Freader As New FileStream(filePath, FileMode.Open, FileAccess.Read)

            'reading the file type
            Dim encodingType(0) As Byte
            Freader.Read(encodingType, 0, encodingType.Length)

            'REPORT
            expectedHeader += encodingType.Length

            'reads four bytes starting from 0 to 3
            Dim binHeader(3) As Byte
            Freader.Read(binHeader, 0, binHeader.Length)
            Form1.readSpeed += binHeader.Length

            'REPORT
            expectedHeader += binHeader.Length

            totalHeaderReaded += 4

            Dim binHeaderlength As Integer = BitConverter.ToInt32(binHeader, 0) - 1
            Console.WriteLine("Readed Bin header: " & binHeaderlength)

            Dim treeData(binHeaderlength) As Byte
            Freader.Read(treeData, 0, treeData.Length)
            Form1.readSpeed += treeData.Length

            'REPORT
            expectedHeader += treeData.Length

            For i As Integer = 0 To treeData.Length - 1 Step 10
                'reverse the bytes
                'Console.WriteLine(treeData(i) & " " & treeData(i + 1))
                Dim bytevalarry() As Byte = {treeData(i), treeData(i + 1)}
                Dim byteFxarry() As Byte = {treeData(i + 2), treeData(i + 3), treeData(i + 4), treeData(i + 5), treeData(i + 6), treeData(i + 7), treeData(i + 8), treeData(i + 9)}

                Dim byteval As Integer = BitConverter.ToInt16(bytevalarry, 0)
                Dim byteFx As Long = BitConverter.ToInt64(byteFxarry, 0)

                Dim arry() As Object = {byteval, byteFx, Nothing}
                Dictionary.Add(arry)
                'Console.WriteLine(byteval & " " & byteFx)
            Next

            'TODO: create a huffman tree from the tree data.
            rootNode = CreateHuffmanTree()

            'assign byte code 
            AssignByteCode()
            'ShowDictionary()

            totalHeaderReaded += Dictionary.Count * 10

            Dim bitHeader(7) As Byte
            Freader.Read(bitHeader, 0, bitHeader.Length)
            Form1.readSpeed += bitHeader.Length
            Dim totalByteToWrite As Long = BitConverter.ToInt64(bitHeader, 0)
            Console.WriteLine("Byte to write: " & totalByteToWrite)

            'REPORT
            expectedHeader += bitHeader.Length

            'reading the file extension header and the original extension.
            Dim extsnHeader As Byte = Freader.ReadByte() - 1
            Dim extnData(extsnHeader) As Byte
            Freader.Read(extnData, 0, extnData.Length)
            Form1.readSpeed += extnData.Length

            'REPORT
            expectedHeader += 1 + extnData.Length

            Dim fi As New FileInfo(filePath)
            Dim filename As String = fi.Name.Replace(fi.Extension, "")
            Dim extn As String = "." & System.Text.Encoding.UTF8.GetString(extnData)
            Dim directory As String = destPath
            Dim outPath = directory & "\" & filename & extn

            fileOutputPath = outPath

            'Dim ctr As Integer = 1
            'While File.Exists(outPath)
            '    outPath = directory & "\" & filename & " (" & ctr.ToString & ")" & extn
            '    ctr += 1
            'End While

            totalHeaderReaded += 12

            Console.WriteLine("Total Header length readed: " & totalHeaderReaded)

            'Console.WriteLine("Decompresing filename: " & outPath)

            'TODO: start Decompress.
            Form1.status = "Extracting Data..."
            Form1.progressStatus = "Decompressing Data..."

            DecodeBytes(Freader, totalByteToWrite, outPath)

            '====================================================
        End Using


        Form1.status = "Finished!"
        Form1.progressStatus = "Finished!"

        Form1.folderStatus = "Done"
        Form1.fileStatus = "Done"
    End Sub

    Public Sub UnBonkFiles(ByVal path As String, ByVal destinationPath As String)

        If Not Directory.Exists(destinationPath) Then
            Directory.CreateDirectory(destinationPath)
        End If

        Form1.status = "Populating Data..."
        Form1.progressStatus = "Processing Data..."

        Using Freader As New FileStream(path, FileMode.Open, FileAccess.Read)

            Dim encodingType(0) As Byte
            Freader.Read(encodingType, 0, encodingType.Length)

            'REPORT
            expectedHeader += encodingType.Length

            'tree header and data
            Dim treeHeader(4 - 1) As Byte
            Freader.Read(treeHeader, 0, treeHeader.Length)

            'REPORT
            expectedHeader += treeHeader.Length

            Dim treeHeaderLength As Integer = BitConverter.ToInt32(treeHeader, 0)
            Console.WriteLine("Readed Bin header: " & treeHeaderLength)

            Dim treeData(treeHeaderLength - 1) As Byte
            Freader.Read(treeData, 0, treeData.Length)

            'REPORT
            expectedHeader += treeData.Length

            For i As Integer = 0 To treeData.Length - 1 Step 10
                'reverse the bytes
                Dim bytevalarry() As Byte = {treeData(i), treeData(i + 1)}
                Dim byteFxarry() As Byte = {treeData(i + 2), treeData(i + 3), treeData(i + 4), treeData(i + 5), treeData(i + 6), treeData(i + 7), treeData(i + 8), treeData(i + 9)}

                Dim byteval As Integer = BitConverter.ToInt16(bytevalarry, 0)
                Dim byteFx As Long = BitConverter.ToInt64(byteFxarry, 0)

                Dim arry() As Object = {byteval, byteFx, Nothing}
                Dictionary.Add(arry)
                'Console.WriteLine(byteval & " " & byteFx)
            Next

            'TODO: create a huffman tree from the tree data.
            rootNode = CreateHuffmanTree()

            'assign byte code 
            AssignByteCode()

            ShowDictionary()

            Dim fileNames As New List(Of String)
            Dim fileSizes As New List(Of Long)

            'file Paths header and data
            Dim fileNameHeader(2 - 1) As Byte
            Freader.Read(fileNameHeader, 0, fileNameHeader.Length)

            'REPORT
            expectedHeader += fileNameHeader.Length

            Dim fileNameHeaderLength As Short = BitConverter.ToInt16(fileNameHeader, 0)
            'Console.WriteLine("readed filenameheader: " & fileNameHeaderLength)

            While fileNameHeaderLength > 0

                Dim pathHeader(3) As Byte
                Freader.Read(pathHeader, 0, pathHeader.Length)
                Dim pathLength As Short = BitConverter.ToInt16(pathHeader, 0)

                'REPORT
                expectedHeader += pathHeader.Length

                Dim fileNameData(pathLength - 1) As Byte
                Freader.Read(fileNameData, 0, fileNameData.Length)

                'REPORT
                expectedHeader += fileNameData.Length

                Dim fileData As String = System.Text.Encoding.UTF8.GetString(fileNameData, 0, fileNameData.Length)
                Console.WriteLine(fileData & " : " & fileData.Length)

                If fileData(0) = "0" Then
                    Form1.folderStatus = fileData.Remove(0, 1)
                ElseIf fileData(0) = "1" Then
                    Form1.fileStatus = fileData.Remove(0, 1)
                End If

                fileNames.Add(fileData)
                fileNameHeaderLength -= 1

                If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                    Return
                End If
            End While

            'File Size header And data
            Dim fileSizeHeader(4 - 1) As Byte
            Freader.Read(fileSizeHeader, 0, fileSizeHeader.Length)

            'REPORT
            expectedHeader += fileSizeHeader.Length

            Dim fileSizeHeaderLength As Integer = BitConverter.ToInt32(fileSizeHeader, 0)
            'Console.WriteLine("readed file size header: " & fileSizeHeaderLength)

            Dim fileSizeData(fileSizeHeaderLength - 1) As Byte
            Freader.Read(fileSizeData, 0, fileSizeData.Length)

            'REPORT
            expectedHeader += fileSizeData.Length

            'Console.WriteLine("decoded filesizedata: " & fileSizeData.Length)
            For i As Integer = 0 To fileSizeData.Length - 1 Step 8
                Dim sizeByte() As Byte = {fileSizeData(i), fileSizeData(i + 1), fileSizeData(i + 2), fileSizeData(i + 3), fileSizeData(i + 4), fileSizeData(i + 5), fileSizeData(i + 6), fileSizeData(i + 7)}
                Dim size As Long = BitConverter.ToInt64(sizeByte, 0)
                fileSizes.Add(size)

                decodedTotalBytes += size
                Console.WriteLine("file size: " & size)
            Next

            Form1.overAllPercent = 5
            Form1.processPercent = 100

            Form1.status = "Extracting Data..."
            Form1.progressStatus = "Decompressing Files..."

            'Return

            'decoding files
            DecodeFiles(Freader, destinationPath, fileNames, fileSizes)
        End Using

        Form1.status = "Finished!"
        Form1.progressStatus = "Finished!"

        Form1.folderStatus = "Done"
        Form1.fileStatus = "Done"

    End Sub

    Private Sub DecodeFiles(ByRef Freader As FileStream, ByVal outputPath As String, ByVal fNames As List(Of String), ByVal fSizes As List(Of Long))

        Dim totalBytesToWrite As Long = 0
        Dim totalWritedBytes As Long = 0

        For Each size As Long In fSizes
            totalBytesToWrite += size
        Next

        expectedOutputLength = totalBytesToWrite

        Dim dictionaryArray(256, 3) As Object

        For Each arry() As Object In Dictionary
            dictionaryArray(arry(0), 0) = arry(0)
            dictionaryArray(arry(0), 1) = arry(1)
            dictionaryArray(arry(0), 2) = arry(2)
        Next

        Form1.folderStatus = outputPath

        Dim fileQ As New Queue(Of String)

        For Each file As String In fNames
            Dim path As String = outputPath & file.Remove(0, 1)

            'Sometimes it returns Invalid path names "path characters"

            'NOTE IMPORTANT!!!
            'FILTER ALL THE FILENAMES AND PATHS IN THE READING FILE BEFORE DECOMPRESSION FOR ACCURACY
            'SOME FILES ARE NOT LOADED (DECOMPRESSED or MISSING) TO SPECIFIC FOLDER, BECAUSE THE CREATION OF DIRECTORY IS MODIFIED. IT FOLLOWS THE ORIGINAL PATH THAT IS INTENDED.
            'RESOLVED BUT CHECK FOR ERRORS

            Console.WriteLine(path)
            'Dim repairedP As String = RepairPath(path)
            'Console.WriteLine("Repaired path location: " & repairedP)
            'Console.WriteLine()

            If file(0) = "0" Then
                If Not Directory.Exists(path) Then
                    Directory.CreateDirectory(path)
                End If
            ElseIf file(0) = "1" Then
                fileQ.Enqueue(path)
            End If
        Next

        'Return

        ''Fix THIS SHIT======================================================================================================================================================
        ''Error: Invalid Filename the file name contains invalid Characters.
        ''Dim Fwriter As FileStream
        ''While fileQ.Count > 0
        ''    Dim filepath As String = fileQ.Dequeue()
        ''    Try
        ''        Console.WriteLine(filepath)
        ''        Fwriter = New FileStream(filepath, FileMode.Create, FileAccess.Write)
        ''    Catch ex As Exception
        ''        Console.WriteLine("There is an error creating a file. " & vbCrLf & "StackTrace: " & ex.Message & vbCrLf & ex.StackTrace)
        ''        Console.WriteLine("Repairing path...")
        ''        Dim NFilePath As String = RepairInvalidFilenameByPath(filepath)
        ''        Fwriter = New FileStream(NFilePath, FileMode.Create, FileAccess.Write)
        ''    End Try
        ''End While
        ''================================================================================================================================================================================
        ''Return

        Dim currentNode As Node = rootNode

        Dim ctr As Integer = 0
        Dim Fwriter As New FileStream(fileQ.Dequeue(), FileMode.Create, FileAccess.Write)
        Dim fileTotalByteToWrite As Long = fSizes(ctr)
        Dim fileByte As Long = fSizes(ctr)
        Dim writedByte As Long = 0

        Dim buffer(131702) As Byte
        Dim bytesRead As Integer = 0

        Do
            bytesRead = Freader.Read(buffer, 0, buffer.Length)
            Form1.readSpeed += bytesRead

            Dim bin As New BitArray(buffer)
            For i As Integer = 0 To (bytesRead * 8) - 1

                If bin(i) Then
                    currentNode = currentNode.getLNode()
                Else
                    currentNode = currentNode.getRNode()
                End If

                'checks if the current node is leaf
                If Not currentNode.HasChild() Then

                    'write the decoded byte in the output file
                    Fwriter.WriteByte(currentNode.GetData(0))
                    fileTotalByteToWrite -= 1
                    totalWritedBytes += 1
                    writedByte += 1
                    Form1.writeSpeed += 1

                    If fileTotalByteToWrite <= 0 Then
                        Fwriter.Dispose()
                        Fwriter = Nothing

                        If fileQ.Count > 0 Then
                            Dim fileName As String = fileQ.Dequeue()
                            Form1.fileStatus = fileName.Remove(0, outputPath.Length)

                            'Fwriter = New FileStream(fileName, FileMode.Create, FileAccess.Write)

                            'THE PATH IS FILTERED BEFORE DECOMPRESSING, PROVIDE ANOTHER FILTER IF THE ISSUE PERSISTS
                            'Try
                            '    Fwriter = New FileStream(fileName, FileMode.Create, FileAccess.Write)
                            'Catch ex As Exception
                            '    Console.WriteLine("There is an error creating a file. " & vbCrLf & "StackTrace: " & ex.Message)
                            '    Console.WriteLine("Repairing path...")

                            '    Console.WriteLine("Current Invalid path: " & fileName)
                            '    Dim newFileName As String = RepairPath(fileName)
                            '    Console.WriteLine("Repaired path: " & newFileName)
                            '    Console.WriteLine()

                            '    Fwriter = New FileStream(newFileName, FileMode.Create, FileAccess.Write)
                            'End Try

                            ctr += 1

                            'NEW BLOCK
                            While fSizes(ctr) = 0
                                Fwriter = New FileStream(fileName, FileMode.Create, FileAccess.Write)
                                Fwriter.Dispose()
                                Fwriter = Nothing

                                fileName = fileQ.Dequeue()
                                ctr += 1
                            End While

                            Fwriter = New FileStream(fileName, FileMode.Create, FileAccess.Write)
                            fileTotalByteToWrite = fSizes(ctr)
                            fileByte = fSizes(ctr)
                            writedByte = 0
                        Else
                            Exit Do
                        End If

                    End If

                    'set the current node as root node.
                    currentNode = rootNode
                End If

                Dim percentage As Double = totalWritedBytes / totalBytesToWrite
                Form1.overAllPercent = (percentage * 95) + 5
                Form1.processPercent = (writedByte / fileByte) * 100

                If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                    Exit Do
                End If
            Next

        Loop While bytesRead > 0

        If Fwriter IsNot Nothing Then
            Fwriter.Dispose()
            Fwriter = Nothing
        End If

    End Sub

    Private Sub DecodeBytes(ByRef FReader As FileStream, ByVal totalByteToWrite As Long, ByVal outputPath As String)

        Dim byteToWrite As Long = totalByteToWrite
        Dim writedByte As Long = 0

        'convert the dictionary to dictionaryArray for faster searching.
        Dim dictionaryArray(256, 3) As Object

        For Each arry() As Object In Dictionary
            dictionaryArray(arry(0), 0) = arry(0)
            dictionaryArray(arry(0), 1) = arry(1)
            dictionaryArray(arry(0), 2) = arry(2)
        Next

        Form1.folderStatus = outputPath
        Form1.fileStatus = outputPath

        Using FWriter As New FileStream(outputPath, FileMode.Create, FileAccess.Write)

            Dim currentNode As Node = rootNode
            Dim buffer(131702) As Byte
            Dim bytesRead As Integer = 0

            Do
                bytesRead = FReader.Read(buffer, 0, buffer.Length)
                Form1.readSpeed += bytesRead

                Dim bin As New BitArray(buffer)
                For i As Integer = 0 To (bytesRead * 8) - 1

                    If bin(i) Then
                        currentNode = currentNode.getLNode()
                    Else
                        currentNode = currentNode.getRNode()
                    End If

                    'checks if the current node is leaf
                    If Not currentNode.HasChild() Then

                        'write the decoded byte in the output file
                        FWriter.WriteByte(currentNode.GetData(0))
                        writedByte += 1
                        totalByteToWrite -= 1
                        Form1.writeSpeed += 1

                        If totalByteToWrite <= 0 Then
                            Exit Do
                        End If

                        'set the current node as root node.
                        currentNode = rootNode
                    End If

                Next

                Form1.overAllPercent = ((writedByte / byteToWrite) * 95) + 5
                Form1.processPercent = (writedByte / byteToWrite) * 100

                If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                    Exit Do
                End If

            Loop While bytesRead > 0

        End Using
        expectedOutputLength = New FileInfo(outputPath).Length


        'Console.WriteLine("writed byte: " & writedByte)

        If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
            File.Delete(outputPath)
            Return
        End If

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

        While treeNodes.Count > 1

            'una sort ung list 
            SortTreeNode(treeNodes)

            'Console.WriteLine("byteVal   fx        code      ")
            'For Each nd As Node In treeNodes
            '    Dim arry() As Object = nd.GetData()
            '    Dim info As String = arry(0).ToString.PadRight(10) & arry(1).ToString.PadRight(10)
            '    Console.WriteLine(info)
            'Next

            'combine ang lowest 2 nodes
            Dim firstNode As Node = treeNodes(0)
            Dim secondNode As Node = treeNodes(1)

            Dim n As New Node
            firstNode.SetPNode(n)
            secondNode.SetPNode(n)

            n.setLNode(firstNode)
            n.setRNode(secondNode)

            Dim fx As Long = firstNode.getTotalFrequency() + secondNode.getTotalFrequency()
            n.setTotalFrequency(fx)

            Dim dataArry() As Object = {"Node", fx, Nothing}
            n.SetData(dataArry)

            treeNodes.RemoveAt(0)
            treeNodes.RemoveAt(0)

            treeNodes.Add(n)

            Dim percentage As Double = (treelength - treeNodes.Count) / treelength
            Form1.overAllPercent = (percentage * 2.5)
            Form1.processPercent = percentage * 100
            'Console.WriteLine(percentage * 5)

        End While

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
                        Form1.overAllPercent = (percentage * 2.5) + 2.5
                        Form1.processPercent = percentage * 100
                        'Console.WriteLine((percentage * 5) + 5)
                        Exit For
                    End If
                Next
            End If


        End While

    End Sub

    Public Sub ShowDictionary()

        Console.WriteLine("byteVal   fx        code      ")

        Dim totalFx As Long = 0

        For Each arry() As Object In Dictionary
            totalFx += arry(1)
            Dim info As String = arry(0).ToString.PadRight(10) & arry(1).ToString.PadRight(10)

            If arry(2) IsNot Nothing Then
                info += arry(2).ToString.PadRight(10)
            End If

            Console.WriteLine(info)
        Next

        Console.WriteLine(StrDup(30, "="))
        Console.WriteLine(StrDup(10, " ") & totalFx & vbCrLf)

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

    Private Function RepairPath(ByVal p As String) As String

        Dim invalidChars() As Char = Path.GetInvalidPathChars()
        Dim customCharFilter() As Char = {"?"}

        For i As Integer = 0 To invalidChars.Length - 1
            'Console.WriteLine("invalid char: " & Convert.ToString(Convert.ToInt32(invalidChars(i)), 16))
            p = p.Replace(invalidChars(i), "")
        Next

        For i As Integer = 0 To customCharFilter.Length - 1
            p = p.Replace(customCharFilter(i), "")
            'Console.WriteLine("char: " & Convert.ToString(Convert.ToInt32(p(i)), 16) & " " & p(i))
        Next

        Return p

    End Function

    Private Function RepairFileName(ByVal p As String) As String

        Dim invalidChars() As Char = Path.GetInvalidFileNameChars()
        Dim customCharFilter() As Char = {"?"}

        For i As Integer = 0 To invalidChars.Length - 1
            'Console.WriteLine("invalid char: " & Convert.ToString(Convert.ToInt32(invalidChars(i)), 16))
            p = p.Replace(invalidChars(i), "")
        Next

        For i As Integer = 0 To customCharFilter.Length - 1
            p = p.Replace(customCharFilter(i), "")
            'Console.WriteLine("char: " & Convert.ToString(Convert.ToInt32(p(i)), 16) & " " & p(i))
        Next

        Return p

    End Function

    Public Function GetComputedCompressedHeader() As Long
        Return expectedHeader
    End Function

    Public Function GetOutputPath() As String
        Return fileOutputPath
    End Function

    Public Function GetDecodedTotalBytes() As Long
        Return decodedTotalBytes
    End Function

    'Private Function ByteToBinary(ByVal n As Byte) As String

    '    Dim current As Integer = n
    '    Dim binary As String = Nothing

    '    If current = 0 Then
    '        binary = "00000000"
    '        Return binary
    '    End If

    '    While current > 0

    '        If current Mod 2 = 1 Then
    '            binary += "1"
    '        ElseIf current Mod 2 = 0 Then
    '            binary += "0"
    '        End If

    '        current = Int(current / 2)

    '    End While

    '    Dim fbinary As String = StrReverse(binary)

    '    'binary repair
    '    If fbinary.Length < 8 Then
    '        Dim bits As String = Nothing
    '        bits += StrDup(8 - fbinary.Length, "0") & fbinary
    '        fbinary = bits
    '    End If

    '    Return fbinary

    'End Function

    Public Function ByteToBinary(ByVal b As Byte) As String
        Return BinArray(b)
    End Function

    Public Function GetTotalByteOfRawFiles() As Long
        Return totalFileRawBytes
    End Function

    Public Function GetOutputTotalBytes() As Long
        Return expectedOutputLength
    End Function

    'Public Function isBitStreaming() As Boolean
    '    Return isBitStream
    'End Function

    'Public Function GetBitReadSpeed() As Long
    '    Return bstream.GetReadSpeed()
    'End Function

End Class
