Imports System.IO
Imports System.Threading

Public Class CompressionManager

    'type code for the typeHeader value
    '0 = single file, Single Thread
    '1 = Multiple file, single thread
    '2 = single file, multi thread
    '3 = multifile, multi Thread

    'Process For Data Header
    '<TreeHeader><Tree Data><Total Bits><Entension Header><ExtentionData>

    'Properties
    Private Dictionary As New List(Of Object())
    Private rootNode As Node = Nothing
    Private charFx(255) As Long

    Private mainOutputPath As String = Nothing
    Private decOutputPath As String = Nothing
    Private expectedCompress As Long = 0
    Private decFilesize As Long = 0
    Private expectedHeader As Long = 0
    Private skipReading As Boolean = False
    Private compPercent As Double = 0
    Private compDiff As Long = 0

    Private ignoreCheck As Boolean = False
    Private isAdditionalByte As Boolean = False

    'SINGLE FILE ENCODE
    Private firstDict(255, 2) As Object
    Private secondDict(255, 2) As Object

    Public Sub SingleFileEncode_Async(ByVal sourcePath As String, ByVal outDir As String)

        Dim userFile As New FileInfo(sourcePath)

        'Percentage manager

        'Reading File (10%)
        'CreateHuffman (2.5%)
        'AssignByteCode (2.5%)
        'Spliting Files(5%)
        'Compressing files (70%)
        'Merging Files (10%) 

        Form1.status = "Reading File..."
        Form1.progressStatus = "Analyzing File..."
        Form1.folderStatus = userFile.DirectoryName
        Form1.fileStatus = userFile.FullName

        Dim firstHalfPath As String = Nothing
        Dim firstDataLength As Long = 0
        Dim firstDataBits As Long = 0
        'Dim firstDict(255, 2) As Object

        Dim secondHalfPath As String = Nothing
        Dim secondDataLength As Long = 0
        Dim secondDataBits As Long = 0
        'Dim secondDict(255, 2) As Object


        'revision for the header of the first half of the file for accuracy of dictionary.
        Dim exheader As Byte() = BitConverter.GetBytes(userFile.Extension.Length)
        For i As Integer = 0 To exheader.Length - 1
            charFx(exheader(i)) += 1
        Next
        Dim exData As Byte() = System.Text.Encoding.UTF8.GetBytes(userFile.Extension)
        For i As Integer = 0 To exData.Length - 1
            charFx(exData(i)) += 1
        Next

        'skip reading for user confirmation about low compression rate and if it is compressable.
        If Not skipReading Then
            ReadFile(sourcePath, firstDict, secondDict)
            'SAVE THE FIRSTDICT AND SECOND DICT FOR SKIP READING
        End If

        'Check for cancelation
        If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
            Return
        End If

        Form1.status = "Populating Data..."
        Form1.progressStatus = "Examining Data..."

        rootNode = CreateHuffmanTree()
        AssignByteCode()

        'populating the value for the first index and the last index for the seperated dictionary
        For Each arry() As Object In Dictionary
            firstDict(arry(0), 0) = arry(0)
            firstDict(arry(0), 2) = arry(2)

            secondDict(arry(0), 0) = arry(0)
            secondDict(arry(0), 2) = arry(2)
        Next

        'FILE CHECKING
        If Not skipReading Then

            If Not ignoreCheck Then
                'checks if the file is compressable
                If Not IsCompressable(New FileInfo(sourcePath).Length) Then
                    Form1.errorCode = 1
                    Console.WriteLine("cannot compress")
                    Return
                End If

                If IsLowRate(New FileInfo(sourcePath).Length) Then
                    Form1.errorCode = 7
                    Console.WriteLine("low rate")
                    skipReading = True
                    Return
                End If
            End If

        End If

        'check if the file is compressable and if it is low rate.
        'If Not isFileCompressible() Then
        '    Form1.errorCode = 1
        '    Console.WriteLine("cannot compress")
        '    Return
        'End If

        'If isLowRate Then
        '    Form1.errorCode = 7
        '    Console.WriteLine("low rate")
        '    Return
        'End If


        ShowDictionary()

        'Start Compression
        'Compute and WriteHeaders

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
        Console.WriteLine("tree Byte length: " & treeByteLength)

        'assingning the new file output path

        Dim filename As String = Nothing
        If Not userFile.Extension = "" Then
            filename = userFile.Name.Replace(userFile.Extension, "")
        Else
            filename = userFile.Name
        End If

        'Dim filename As String = userFile.Name.Replace(userFile.Extension, "")


        Dim extn As String = ".huff"
        Dim outputPath = outDir & "\" & filename & extn

        'creating a new file name if the current filename exists.
        Dim ctr As Integer = 1
        While File.Exists(outputPath)
            outputPath = outDir & "\" & filename & " (" & ctr.ToString & ")" & extn
            ctr += 1
        End While

        'FOR REPORT
        mainOutputPath = outputPath

        'write the header
        Using Fwriter As New FileStream(outputPath, FileMode.Create, FileAccess.Write)

            'headerDesign
            '<type single or multi><TreeHeader><TreeData><extensionHeader><extensionData><encodedDataLengthOfFirstHalf><totalbitsOfFirstHalf><EncodedDataLengthoflastHalf><TotalBitsOfLastHalf>
            '<1><4><2560><4><??><8><8><8><8>

            'false means singleFile type of encoding
            'Dim encodingType() As Byte = BitConverter.GetBytes(False)
            'Fwriter.Write(encodingType, 0, encodingType.Length)

            'single file multiThread type
            Dim encodingType() As Byte = {2}
            Fwriter.Write(encodingType, 0, encodingType.Length)

            'FOR REPORT
            expectedHeader += encodingType.Length

            '<treeHeader>
            Dim treeHeader() As Byte = BitConverter.GetBytes(treeByteLength)
            Fwriter.Write(treeHeader, 0, treeHeader.Length)
            Console.WriteLine("Tree Header: " & treeByteLength)

            'FOR REPORT
            expectedHeader += treeHeader.Length

            'write the tree data. <TreeData>
            While treeBytes.Count > 0
                Dim treeData As Object() = treeBytes.Dequeue()
                For i As Integer = 0 To treeData.Length - 1
                    Dim buffer As Byte() = treeData(i)
                    Fwriter.Write(buffer, 0, buffer.Length)
                    'Form1.writeSpeed += buffer.Length

                    'FOR REPORT
                    expectedHeader += buffer.Length
                Next
            End While

            '<extensionHeader> = 4
            Dim extsnHeader() As Byte = BitConverter.GetBytes(userFile.Extension.Length)
            Fwriter.Write(extsnHeader, 0, extsnHeader.Length)
            Console.WriteLine("extension Header: " & userFile.Extension.Length)

            'FOR REPORT
            expectedHeader += extsnHeader.Length

            '<extensionData> = extsnData.Length
            Dim extsnData() As Byte = System.Text.Encoding.UTF8.GetBytes(userFile.Extension)
            Fwriter.Write(extsnData, 0, extsnData.Length)
            Console.WriteLine("Extension data: " & userFile.Extension)

            'FOR REPORT
            expectedHeader += extsnData.Length

            ''<TotalBits>
            'Dim totalBitsData() As Byte = BitConverter.GetBytes(userFile.Length)
            'Fwriter.Write(totalBitsData, 0, totalBitsData.Length)

            '***MultiThread Compression***

            Form1.status = "Splitting..."
            Form1.progressStatus = "Splitting File..."

            'split the original file for multithread processing 
            FileSplitter(sourcePath, firstHalfPath, firstDict, secondHalfPath)

            'supply the data length and bits for the first dictionary
            For i As Integer = 0 To firstDict.GetLength(0) - 1
                If firstDict(i, 2) IsNot Nothing Then
                    firstDataBits += firstDict(i, 1) * firstDict(i, 2).ToString.Length
                End If
            Next

            'calculating fdata
            If firstDataBits Mod 8 = 0 Then
                firstDataLength = firstDataBits / 8
            Else
                firstDataLength = (firstDataBits \ 8) + 1
            End If

            'second dictionary
            For i As Integer = 0 To secondDict.GetLength(0) - 1
                If secondDict(i, 2) IsNot Nothing Then
                    secondDataBits += secondDict(i, 1) * secondDict(i, 2).ToString.Length
                End If
            Next

            If secondDataBits Mod 8 = 0 Then
                secondDataLength = secondDataBits / 8
            Else
                secondDataLength = (secondDataBits \ 8) + 1
            End If

            'Return

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Dim firstSplitPath As String = firstHalfPath
            Dim secondSplitPath As String = secondHalfPath

            'Dim firstPath As New FileInfo(firstHalfPath)
            'Dim secondPath As New FileInfo(secondHalfPath)

            Form1.status = "Bonking..."
            Form1.progressStatus = "Compressing Data..."

            Form1.folderStatus = userFile.DirectoryName
            Form1.fileStatus = userFile.FullName
            'send to another thread
            Dim secondWorker As New Thread(Sub()
                                               Console.WriteLine("Second Worker started")
                                               EncodeFile(secondHalfPath, secondDict)
                                               Console.WriteLine("Second Worker ended")
                                           End Sub)
            'tell the second worker to start encoding the secondhalf file
            secondWorker.Start()

            'Then calling Encode file to compress the firstHalf (Doing work)
            EncodeFile(firstHalfPath, firstDict)
            Form1.overAllPercent = 90

            'When done Encoding let us wait for second worker to finish.
            secondWorker.Join()

            'Dim percentage As Double = totalbWrite / totalByte
            'Form1.overAllPercent = (percentage * 60) + 30
            'Form1.processPercent = percentage * 100

            Dim fhalflength As Long = New FileInfo(firstHalfPath).Length
            Dim sHalfLength As Long = New FileInfo(secondHalfPath).Length

            Console.WriteLine("First file path: " & firstHalfPath & "  Size: " & New FileInfo(firstHalfPath).Length)
            Console.WriteLine(("Second file path: " & secondHalfPath & "  Size: " & New FileInfo(secondHalfPath).Length))

            'If Not fhalflength = sHalfLength Then
            '    expectedHeader += 1
            'End If

            'Delete the split files 
            File.Delete(firstSplitPath)
            File.Delete(secondSplitPath)
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            'finally encode and Merge the compressed files.

            '<encodedDataLengthOfFirstHalf> = 8
            Dim fdataLength() As Byte = BitConverter.GetBytes(firstDataLength)
            Fwriter.Write(fdataLength, 0, fdataLength.Length)
            Console.WriteLine("First data length: " & firstDataLength)

            'FOR REPORT
            expectedHeader += fdataLength.Length

            '<totalbitsOfFirstHalf> = 8
            Dim fdataBits() As Byte = BitConverter.GetBytes(firstDataBits)
            Fwriter.Write(fdataBits, 0, fdataBits.Length)
            Console.WriteLine("First data bit length: " & firstDataBits)

            'FOR REPORT
            expectedHeader += fdataBits.Length

            '<EncodedDataLengthoflastHalf> = 8
            Dim sdataLength() As Byte = BitConverter.GetBytes(secondDataLength)
            Fwriter.Write(sdataLength, 0, sdataLength.Length)
            Console.WriteLine("Second data length: " & secondDataLength)

            'FOR REPORT
            expectedHeader += sdataLength.Length

            '<TotalBitsOfLastHalf> = 8
            Dim sdataBits() As Byte = BitConverter.GetBytes(secondDataBits)
            Fwriter.Write(sdataBits, 0, sdataBits.Length)
            Console.WriteLine("Second data bit length: " & secondDataBits)

            'FOR REPORT
            expectedHeader += sdataBits.Length

            expectedCompress = ComputeCompressedSize()
            'ShowDictionary()

            Console.WriteLine(expectedCompress)
            'Return

            If Not (Form1.errorCode = 5 Or Form1.errorCode = 6) Then

                'merge The files
                'first Half

                Form1.fileStatus = firstHalfPath
                Console.WriteLine("Writing the first Half of the File: " & firstHalfPath)
                Using FReader As New FileStream(firstHalfPath, FileMode.Open, FileAccess.Read)

                    Dim bytesRead As Integer = 0
                    Dim totalReadedByte As Long = 0
                    Dim totalfileByte As Long = New FileInfo(firstHalfPath).Length
                    Dim buffer(4096) As Byte

                    Do
                        bytesRead = FReader.Read(buffer, 0, buffer.Length)
                        Fwriter.Write(buffer, 0, bytesRead)
                        totalReadedByte += bytesRead

                        Form1.readSpeed += bytesRead
                        Form1.writeSpeed += bytesRead

                        Dim percentage As Double = totalReadedByte / totalfileByte
                        Form1.overAllPercent = (percentage * 5) + 90
                        Form1.processPercent = percentage * 100

                    Loop While bytesRead > 0

                End Using

                'expectedCompress += New FileInfo(firstHalfPath).Length

                'Delete the split encoded files 
                File.Delete(firstHalfPath)

                'second Half

                Form1.fileStatus = secondHalfPath
                Console.WriteLine("Writing the second Half of the File: " & secondHalfPath)
                Using Freader As New FileStream(secondHalfPath, FileMode.Open, FileAccess.Read)


                    Dim bytesRead As Integer = 0
                    Dim totalReadedByte As Long = 0
                    Dim totalfileByte As Long = New FileInfo(secondHalfPath).Length
                    Dim buffer(4096) As Byte

                    Do
                        bytesRead = Freader.Read(buffer, 0, buffer.Length)
                        Fwriter.Write(buffer, 0, bytesRead)
                        totalReadedByte += bytesRead

                        Form1.readSpeed += bytesRead
                        Form1.writeSpeed += bytesRead

                        Dim percentage As Double = totalReadedByte / totalfileByte
                        Form1.overAllPercent = (percentage * 5) + 95
                        Form1.processPercent = percentage * 100
                    Loop While bytesRead > 0
                End Using

                'expectedCompress += New FileInfo(secondHalfPath).Length

                'Delete the split encoded files 
                File.Delete(secondHalfPath)

            Else

                Console.WriteLine("Deleted: " & vbCrLf & firstHalfPath & vbCrLf & secondHalfPath)

                File.Delete(firstHalfPath)
                File.Delete(secondHalfPath)
            End If

            ''merge The files
            ''first Half

            'Form1.fileStatus = firstHalfPath
            'Console.WriteLine("Writing the first Half of the File: " & firstHalfPath)
            'Using FReader As New FileStream(firstHalfPath, FileMode.Open, FileAccess.Read)

            '    Dim bytesRead As Integer = 0
            '    Dim totalReadedByte As Long = 0
            '    Dim totalfileByte As Long = New FileInfo(firstHalfPath).Length
            '    Dim buffer(4096) As Byte

            '    Do
            '        bytesRead = FReader.Read(buffer, 0, buffer.Length)
            '        Fwriter.Write(buffer, 0, bytesRead)
            '        totalReadedByte += bytesRead

            '        Form1.readSpeed += bytesRead
            '        Form1.writeSpeed += bytesRead

            '        Dim percentage As Double = totalReadedByte / totalfileByte
            '        Form1.overAllPercent = (percentage * 5) + 90
            '        Form1.processPercent = percentage * 100

            '    Loop While bytesRead > 0

            'End Using

            ''expectedCompress += New FileInfo(firstHalfPath).Length

            ''Delete the split encoded files 
            'File.Delete(firstHalfPath)

            ''second Half

            'Form1.fileStatus = secondHalfPath
            'Console.WriteLine("Writing the second Half of the File: " & secondHalfPath)
            'Using Freader As New FileStream(secondHalfPath, FileMode.Open, FileAccess.Read)


            '    Dim bytesRead As Integer = 0
            '    Dim totalReadedByte As Long = 0
            '    Dim totalfileByte As Long = New FileInfo(secondHalfPath).Length
            '    Dim buffer(4096) As Byte

            '    Do
            '        bytesRead = Freader.Read(buffer, 0, buffer.Length)
            '        Fwriter.Write(buffer, 0, bytesRead)
            '        totalReadedByte += bytesRead

            '        Form1.readSpeed += bytesRead
            '        Form1.writeSpeed += bytesRead

            '        Dim percentage As Double = totalReadedByte / totalfileByte
            '        Form1.overAllPercent = (percentage * 5) + 95
            '        Form1.processPercent = percentage * 100
            '    Loop While bytesRead > 0
            'End Using

            ''expectedCompress += New FileInfo(secondHalfPath).Length

            ''Delete the split encoded files 
            'File.Delete(secondHalfPath)

        End Using

        If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
            File.Delete(outputPath)
        End If


        'ShowDictionary()
        'expectedCompress = ComputeCompressedSize()

        'reset all properties
        Dictionary = New List(Of Object())
        rootNode = Nothing
        charFx = New Long(255) {}

    End Sub

    Public Sub SingleFileDecode_Async(ByVal sourcePath As String, ByVal outDir As String)

        'Percentage manager

        'Reading Header (10%)
        'CreateHuffman (2.5%)
        'AssignByteCode (2.5%)
        'Spliting Files(10%)
        'Decompressing files (65%)
        'Merging Files (10%)

        Console.WriteLine("out directory" & outDir)
        'Return

        Dim userFile As New FileInfo(sourcePath)

        Form1.status = "Reading File..."
        Form1.progressStatus = "Analyzing File..."
        Form1.folderStatus = userFile.DirectoryName
        Form1.fileStatus = userFile.FullName

        Dim firstFilePath As String = outDir & "\" & userFile.Name.Replace(userFile.Extension, "") & " (1).dec"
        Dim secondFilePath As String = outDir & "\" & userFile.Name.Replace(userFile.Extension, "") & " (2).dec"

        Console.WriteLine(firstFilePath)
        Console.WriteLine(secondFilePath)

        Dim firstTotalBitsLength As Long = 0
        Dim secondTotalBitsLength As Long = 0


        Using Freader As New FileStream(sourcePath, FileMode.Open, FileAccess.Read)

            '<Read Headers>
            '<type single or multi><TreeHeader><TreeData><extensionHeader><extensionData><encodedDataLengthOfFirstHalf><totalbitsOfFirstHalf><EncodedDataLengthoflastHalf><TotalBitsOfLastHalf>
            '<1><4><2560><4><??><8><8><8><8>

            '<encoding type> boolean
            Dim encodingType(0) As Byte
            Freader.Read(encodingType, 0, encodingType.Length)
            'Dim encType As Boolean = BitConverter.ToBoolean(encodingType, 0)

            'FOR REPORT
            expectedHeader += encodingType.Length

            Dim treeHeader(3) As Byte
            Freader.Read(treeHeader, 0, treeHeader.Length)
            Dim treeHeaderLength As Integer = BitConverter.ToInt32(treeHeader, 0)
            Console.WriteLine("Decode: TreeHeader: " & treeHeaderLength)

            'FOR REPORT
            expectedHeader += treeHeader.Length

            Dim treeData(treeHeaderLength - 1) As Byte
            Freader.Read(treeData, 0, treeData.Length)

            'FOR REPORT
            expectedHeader += treeData.Length

            For i As Integer = 0 To treeData.Length - 1 Step 10
                'reverse the bytes
                Dim bytevalarry() As Byte = {treeData(i), treeData(i + 1)}
                Dim byteFxarry() As Byte = {treeData(i + 2), treeData(i + 3), treeData(i + 4), treeData(i + 5), treeData(i + 6), treeData(i + 7), treeData(i + 8), treeData(i + 9)}

                Dim byteval As Integer = BitConverter.ToInt16(bytevalarry, 0)
                Dim byteFx As Long = BitConverter.ToInt64(byteFxarry, 0)

                Dim arry() As Object = {byteval, byteFx, Nothing}
                Dictionary.Add(arry)
            Next

            rootNode = CreateHuffmanTree()
            AssignByteCode()

            'extension
            '<extensionHeader> = 4
            Dim extsnHeader(3) As Byte
            Freader.Read(extsnHeader, 0, extsnHeader.Length)
            Dim extsnLength As Integer = BitConverter.ToInt32(extsnHeader, 0)
            Console.WriteLine("Decode: extension Header: " & extsnLength)

            'FOR REPORT
            expectedHeader += extsnHeader.Length

            '<extensionData> = extsnData.Length
            Dim extsnData(extsnLength - 1) As Byte
            Freader.Read(extsnData, 0, extsnData.Length)
            Dim extsn As String = System.Text.Encoding.UTF8.GetString(extsnData)
            Console.WriteLine("Decode: Extension data: " & extsn)

            'FOR REPORT
            expectedHeader += extsnData.Length

            '<totalDataOfFirstHalf> = 8
            Dim fdataLength(7) As Byte
            Freader.Read(fdataLength, 0, fdataLength.Length)
            Dim firstTotalByteLength As Long = BitConverter.ToInt64(fdataLength, 0)
            Console.WriteLine("Decode: First data length: " & firstTotalByteLength)

            'FOR REPORT
            expectedHeader += fdataLength.Length

            '<totalbitsOfFirstHalf> = 8
            Dim fdataBits(7) As Byte
            Freader.Read(fdataBits, 0, fdataBits.Length)
            firstTotalBitsLength = BitConverter.ToInt64(fdataBits, 0)
            Console.WriteLine("Decode: First data bit length: " & firstTotalBitsLength)

            'FOR REPORT
            expectedHeader += fdataBits.Length

            '<EncodedDataLengthoflastHalf> = 8
            Dim sdataLength(7) As Byte
            Freader.Read(sdataLength, 0, sdataLength.Length)
            Dim secondTotalByteLength As Long = BitConverter.ToInt64(sdataLength, 0)
            Console.WriteLine("Decode: Second data length: " & secondTotalByteLength)

            'FOR REPORT
            expectedHeader += sdataLength.Length

            '<TotalBitsOfLastHalf> = 8
            Dim sdataBits(7) As Byte
            Freader.Read(sdataBits, 0, sdataBits.Length)
            secondTotalBitsLength = BitConverter.ToInt64(sdataBits, 0)
            Console.WriteLine("Decode: Second data bit length: " & secondTotalBitsLength)

            'FOR REPORT
            expectedHeader += sdataBits.Length

            'ShowDictionary()

            Form1.status = "Extracting File..."
            Form1.progressStatus = "Splitting File..."

            'retrieve the files

            'gets the first file
            Using FWriter As New FileStream(firstFilePath, FileMode.Create, FileAccess.Write)

                Dim bytesRead As Integer = 0
                Dim totalBytesRead As Long = 0

                Do
                    Dim buffer() As Byte
                    If (firstTotalByteLength - totalBytesRead) >= 4096 Then
                        buffer = New Byte(4095) {}
                    Else
                        buffer = New Byte(firstTotalByteLength - totalBytesRead - 1) {}
                    End If

                    bytesRead = Freader.Read(buffer, 0, buffer.Length)
                    totalBytesRead += bytesRead

                    FWriter.Write(buffer, 0, buffer.Length)

                    If firstTotalByteLength - totalBytesRead = 0 Then
                        Exit Do
                    End If

                    Form1.readSpeed += bytesRead
                    Form1.writeSpeed += bytesRead
                    Form1.overAllPercent = (totalBytesRead / firstTotalByteLength * 2.5) + 15
                    Form1.processPercent = totalBytesRead / firstTotalByteLength * 100

                Loop While bytesRead > 0

            End Using

            decFilesize += New FileInfo(firstFilePath).Length

            'gets the second file
            Using FWriter As New FileStream(secondFilePath, FileMode.Create, FileAccess.Write)
                Dim bytesRead As Integer = 0
                Dim totalBytesRead As Long = 0
                Dim buffer(4096) As Byte
                Do
                    bytesRead = Freader.Read(buffer, 0, buffer.Length)
                    FWriter.Write(buffer, 0, bytesRead)
                    totalBytesRead += bytesRead

                    Form1.readSpeed += bytesRead
                    Form1.writeSpeed += bytesRead
                    Form1.overAllPercent = (totalBytesRead / secondTotalByteLength * 2.5) + 17.5
                    Form1.processPercent = totalBytesRead / secondTotalByteLength * 100

                Loop While bytesRead > 0
            End Using

            decFilesize += New FileInfo(secondFilePath).Length

        End Using

        expectedCompress = ComputeCompressedSize()
        ShowDictionary()

        'Delete Source Path

        'Optional 
        'File.Delete(sourcePath)

        Form1.status = "Extracting File..."
        Form1.progressStatus = "Decoding File..."

        'decompress the two files
        'send to another thread
        Dim secondWorker As New Thread(Sub()
                                           Console.WriteLine("Second Worker started")
                                           DecodeFile(secondFilePath, secondTotalBitsLength, rootNode)
                                           Console.WriteLine("Second Worker ended")
                                       End Sub)

        'tell the second worker to start encoding the secondhalf file
        secondWorker.Start()

        'Console.WriteLine("Decoding...")
        DecodeFile(firstFilePath, firstTotalBitsLength, rootNode)

        Form1.overAllPercent = 90

        'When done Encoding let us wait for second worker to finish.
        secondWorker.Join()

        Form1.status = "Compressing File..."
        Form1.progressStatus = "Merging File..."
        'merge the decoded file.
        FileMerger(firstFilePath)

        Form1.status = "Finished!"
        Form1.progressStatus = "Finished!"
        Form1.folderStatus = "Done."
        Form1.fileStatus = "Done."

        'reset all properties
        Dictionary = New List(Of Object())
        rootNode = Nothing
        charFx = New Long(255) {}

    End Sub

    Private identicalPath As New List(Of String)
    Private firstTFilePath As New List(Of String)
    Private secondTFilePath As New List(Of String)
    Public Sub MultiFileEncode_Async(ByVal fileQueue As Queue(Of String), ByVal fileName As String, ByVal outDir As String)

        'NOTE: MAY PROBLEMA TAYO SA SPLITTING NG FILE LALO NA TUWING SAME FILE NAME BUT DIFFERENT FILE TYPE

        If Not skipReading Then

            'TODO
            'identify the tree header.
            'read file
            'Dim identicalPath As New List(Of String)
            'Dim firstTFilePath As New List(Of String)
            'Dim secondTFilePath As New List(Of String)

            Dim fpathQ As New Queue(Of String)
            Dim totalByteToRead As Long = 0

            Dim parentDir As New FileInfo(fileQueue.Peek())
            While fileQueue.Count > 0

                Dim fpath As String = fileQueue.Dequeue
                Dim userFile As New FileInfo(fpath)
                Dim newPath As String = Nothing

                Dim fAttribute As FileAttribute = File.GetAttributes(fpath)
                If fAttribute.HasFlag(FileAttribute.Hidden) Then
                    Continue While
                End If

                If fAttribute.HasFlag(FileAttribute.Directory) Then
                    Dim dirInfo As New DirectoryInfo(fpath)
                    For Each fileinfo As FileSystemInfo In dirInfo.GetFileSystemInfos
                        Dim atbute As FileAttribute = File.GetAttributes(fileinfo.FullName)

                        If atbute.HasFlag(FileAttribute.Hidden) Then
                            Continue For
                        Else
                            fileQueue.Enqueue(fileinfo.FullName)
                        End If
                    Next

                    newPath = userFile.FullName.Replace(parentDir.DirectoryName, "0")
                Else

                    totalByteToRead += userFile.Length
                    fpathQ.Enqueue(fpath)
                    newPath = userFile.FullName.Replace(parentDir.DirectoryName, "1")
                End If

                'Dim repairedPath As String = RepairPath(newPath)
                Console.WriteLine(newPath)
                'Console.WriteLine("New Path: " & repairedPath)

                identicalPath.Add(newPath)
            End While

            'Return

            Form1.status = "Reading File..."
            Form1.progressStatus = "Analyzing File..."

            Dim filesReaded As Integer = 0
            Dim filesToRead As Integer = fpathQ.Count
            While fpathQ.Count > 0

                Dim firstHalfP As String = Nothing
                Dim secondHalfP As String = Nothing

                Dim fileP As String = fpathQ.Dequeue()
                Form1.fileStatus = fileP

                'read the file for dictionary, split file, and ready it for the encoding
                ReadFile(fileP, firstHalfP, secondHalfP, totalByteToRead)

                filesReaded += 1
                Form1.overAllPercent = (filesReaded / filesToRead * 20)

                firstTFilePath.Add(firstHalfP)
                secondTFilePath.Add(secondHalfP)

                'SAVE FIRST TFILEPATH AND SECONDTFILEPATH FOR SKIP READING

                Console.WriteLine(firstHalfP)
                Console.WriteLine(secondHalfP)

            End While

            '==================================================================================================================================================
            'Return

            'populate data for the creation of huffman tree.
            'CreateByteFrequency()
            'rootNode = CreateHuffmanTree()
            'AssignByteCode()

            'expectedCompress = ComputeCompressedSize()
            'ShowDictionary()

            CreateByteFrequency()
            rootNode = CreateHuffmanTree()
            AssignByteCode()

            expectedCompress = ComputeCompressedSize()
            ShowDictionary()

            'Return

            If Not ignoreCheck Then
                'checks if the file is compressable
                If Not IsCompressable(totalByteToRead) Then
                    Form1.errorCode = 1
                    Console.WriteLine("cannot compress")

                    For Each fpath In firstTFilePath
                        File.Delete(fpath)
                    Next

                    For Each fpath In secondTFilePath
                        File.Delete(fpath)
                    Next

                    Return
                End If

                If IsLowRate(totalByteToRead) Then
                    Form1.errorCode = 7
                    Console.WriteLine("low rate")
                    skipReading = True
                    Return
                End If

                If Form1.errorCode = 5 Or Form1.errorCode = 6 Then

                    For Each fpath In firstTFilePath
                        File.Delete(fpath)
                    Next

                    For Each fpath In secondTFilePath
                        File.Delete(fpath)
                    Next

                    Return
                End If

            End If

        End If

        '=========================================================================

        'For i As Integer = 0 To firstTFilePath.Count - 1
        '    Console.WriteLine("CHECKING: " & firstTFilePath(i))
        'Next

        'For i As Integer = 0 To secondTFilePath.Count - 1
        '    Console.WriteLine("CHECKING: " & secondTFilePath(i))
        'Next

        'ShowDictionary()

        'Return


        'If Not isFileCompressible() Then
        '    Form1.errorCode = 1
        '    Console.WriteLine("cannot compress")
        '    Return
        'End If

        'If isLowRate Then
        '    Form1.errorCode = 7
        '    Console.WriteLine("low rate")
        '    Return
        'End If

        'encode the list of Filepaths - MULTITHREADING
        'copy the data of ditionary into 2nd array or NOT
        Dim dictArray(255, 2) As Object
        For Each arry() As Object In Dictionary
            dictArray(arry(0), 0) = arry(0)
            dictArray(arry(0), 1) = arry(1)
            dictArray(arry(0), 2) = arry(2)
        Next

        Dim firstEncData As New List(Of Long)
        Dim secondEncData As New List(Of Long)

        Dim firstOutPath As String = outDir & "\" & "firstOutput.enc"
        Dim secondOutPath As String = outDir & "\" & "secondOutput.enc"

        Form1.status = "Compressing..."
        Form1.progressStatus = "Compressing Data..."

        Dim secondWorker As New Thread(Sub()
                                           Console.WriteLine("Second Worker started")
                                           EncodeFile(secondTFilePath, secondEncData, dictArray, secondOutPath)
                                           Console.WriteLine("Second Worker ended")
                                       End Sub)

        'tell the second worker to start encoding the secondhalf file
        secondWorker.Start()

        'work of the first half
        EncodeFile(firstTFilePath, firstEncData, dictArray, firstOutPath)

        'wait for second worker to finish.
        secondWorker.Join()

        ''==================================================================================================================================================
        'Return

        If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
            Return
        End If

        Console.WriteLine("FIRST ENC COUNT: " & firstEncData.Count)
        Console.WriteLine("SECOND ENC COUNT: " & secondEncData.Count)

        'Tree Header
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
        'Console.WriteLine("tree Byte length: " & treeByteLength)

        'assingning the new file output path
        'creating a new file name if the current filename exists.
        Dim outputPath As String = outDir & "\" & fileName & ".huff"
        Dim ctr As Integer = 1
        While File.Exists(outputPath)
            outputPath = outDir & "\" & fileName & " (" & ctr.ToString & ")" & ".huff"
            ctr += 1
        End While

        'create the file header.
        '<Type of Encoding Single or Multi File><tree Length><Tree data> <TotalFiles><Path header><path length><first half Long header><long data>

        'compressed data
        '<encodedDataLength><DataLength For the First Thread>

        Form1.status = "Merging..."
        Form1.progressStatus = "Merging Data..."

        'FOR REPORT
        mainOutputPath = outputPath

        Using Fwriter As New FileStream(outputPath, FileMode.Create, FileAccess.Write)

            '<Type of Encoding Single or Multi File> (Byte)
            'if true means multi file type encode
            'Dim encodingType() As Byte = BitConverter.GetBytes(True)
            'Fwriter.Write(encodingType, 0, encodingType.Length)

            'Multi file multiThread type
            Dim encodingType() As Byte = {3}
            Fwriter.Write(encodingType, 0, encodingType.Length)

            'FOR REPORT
            expectedHeader += encodingType.Length

            '<tree Length> (Integer)
            Dim treeHeader() As Byte = BitConverter.GetBytes(treeByteLength)
            Fwriter.Write(treeHeader, 0, treeHeader.Length)

            'FOR REPORT
            expectedHeader += treeHeader.Length

            '<tree data>
            While treeBytes.Count > 0
                Dim treeData As Object() = treeBytes.Dequeue()
                For i As Integer = 0 To treeData.Length - 1
                    Dim buffer As Byte() = treeData(i)
                    Fwriter.Write(buffer, 0, buffer.Length)

                    'FOR REPORT
                    expectedHeader += buffer.Length
                Next
            End While

            'total directory,file number <TotalFile> (Integer)
            Dim firstLength() As Byte = BitConverter.GetBytes(identicalPath.Count)
            Fwriter.Write(firstLength, 0, firstLength.Length)

            'FOR REPORT
            expectedHeader += firstLength.Length

            For Each uPath As String In identicalPath

                'inuna muna ung pathlength para mabasa ung accurate bytes of the string
                Dim pathLength() As Byte = System.Text.Encoding.UTF8.GetBytes(uPath)
                Dim patHeader() As Byte = BitConverter.GetBytes(pathLength.Length)
                Fwriter.Write(patHeader, 0, patHeader.Length)
                Fwriter.Write(pathLength, 0, pathLength.Length)

                ''<path header>
                'Dim patHeader() As Byte = BitConverter.GetBytes(uPath.Length)
                'Fwriter.Write(patHeader, 0, patHeader.Length)
                ''<path length>
                'Dim pathLength() As Byte = System.Text.Encoding.UTF8.GetBytes(uPath)
                'Fwriter.Write(patHeader, 0, patHeader.Length)

                Console.WriteLine(uPath & " H: " & patHeader.Length & " D: " & pathLength.Length)

                'FOR REPORT
                expectedHeader += patHeader.Length + pathLength.Length

            Next

            '<long counter header>
            Dim longHeader() As Byte = BitConverter.GetBytes(firstEncData.Count)
            Fwriter.Write(longHeader, 0, longHeader.Length)

            'FOR REPORT
            expectedHeader += longHeader.Length

            '<first long data>
            For Each firstLongData As Long In firstEncData
                Dim longData() As Byte = BitConverter.GetBytes(firstLongData)
                Fwriter.Write(longData, 0, longData.Length)

                'FOR REPORT
                expectedHeader += longData.Length
            Next

            '<Second long counter header>
            Dim secondLongHeader() As Byte = BitConverter.GetBytes(secondEncData.Count)
            Fwriter.Write(secondLongHeader, 0, secondLongHeader.Length)

            'FOR REPORT
            expectedHeader += secondLongHeader.Length

            '<second Long data>
            For Each secondLongData As Long In secondEncData
                Dim longData() As Byte = BitConverter.GetBytes(secondLongData)
                Fwriter.Write(longData, 0, longData.Length)

                'FOR REPORT
                expectedHeader += longData.Length
            Next

            'encoded data here
            Dim encDataHeader() As Byte = BitConverter.GetBytes(New FileInfo(firstOutPath).Length)
            Fwriter.Write(encDataHeader, 0, encDataHeader.Length)

            'FOR REPORT
            expectedHeader += encDataHeader.Length

            Form1.fileStatus = firstOutPath
            Using Freader As New FileStream(firstOutPath, FileMode.Open, FileAccess.Read)
                Dim totalReadedBytes As Long = 0
                Dim readedBytes As Integer = 0
                Dim readBuffer(8192) As Byte
                Dim totalBytes As Long = New FileInfo(firstOutPath).Length

                Do
                    readedBytes = Freader.Read(readBuffer, 0, readBuffer.Length)
                    Fwriter.Write(readBuffer, 0, readedBytes)
                    totalReadedBytes += readedBytes

                    Form1.readSpeed += readedBytes
                    Form1.writeSpeed += readedBytes
                    Form1.processPercent = totalReadedBytes / totalBytes * 100
                Loop While readedBytes > 0
            End Using

            'delete the firstoutpath
            File.Delete(firstOutPath)

            Form1.overAllPercent = 95

            'second Encoded data.

            Form1.fileStatus = secondOutPath
            Using Freader As New FileStream(secondOutPath, FileMode.Open, FileAccess.Read)
                Dim totalReadedBytes As Long = 0
                Dim readedBytes As Integer = 0
                Dim readBuffer(8192) As Byte
                Dim totalBytes As Long = New FileInfo(secondOutPath).Length

                Do
                    readedBytes = Freader.Read(readBuffer, 0, readBuffer.Length)
                    Fwriter.Write(readBuffer, 0, readedBytes)
                    totalReadedBytes += readedBytes

                    Form1.readSpeed += readedBytes
                    Form1.writeSpeed += readedBytes
                    Form1.processPercent = totalReadedBytes / totalBytes * 100
                Loop While readedBytes > 0
            End Using

            If isAdditionalByte Then
                expectedHeader += 1
            End If

            Form1.overAllPercent = 100

            'delete the secoutpath
            File.Delete(secondOutPath)

        End Using

        Form1.status = "Finished!"
        Form1.progressStatus = "Finished!"
        Form1.folderStatus = "Done."
        Form1.fileStatus = "Done."

    End Sub

    Public Sub MultiFileDecode_Async(ByVal sourcePath As String, ByVal outPath As String)

        Dim folderPath As New List(Of String)
        Dim filePath As New List(Of String)
        Dim splPath As New List(Of String)

        Dim firstHalfDataLength As New List(Of Long)
        Dim secondHalfDataLength As New List(Of Long)

        Dim fstOutputPath As String = outPath & "\" & "firstOutput.dec"
        Dim secOutputPath As String = outPath & "\" & "secondOutput.dec"

        Form1.status = "Reading File"
        Form1.progressStatus = "Analyzing file"

        Using Freader As New FileStream(sourcePath, FileMode.Open, FileAccess.Read)

            '<encoding type> boolean
            Dim encodingType(0) As Byte
            Freader.Read(encodingType, 0, encodingType.Length)
            'Dim encType As Boolean = BitConverter.ToBoolean(encodingType, 0)
            'Console.WriteLine("Is multiFile? : " & encType)

            'FOR REPORT
            expectedHeader += encodingType.Length


            '<treeheader> Int
            Dim treeHeader(3) As Byte
            Freader.Read(treeHeader, 0, treeHeader.Length)
            Dim treeHeaderlength As Integer = BitConverter.ToInt32(treeHeader, 0)

            'FOR REPORT
            expectedHeader += treeHeader.Length

            '<treeData>
            Dim treeData(treeHeaderlength - 1) As Byte
            Freader.Read(treeData, 0, treeData.Length)

            'FOR REPORT
            expectedHeader += treeData.Length

            're-writing the data tree
            For i As Integer = 0 To treeData.Length - 1 Step 10
                'reverse the bytes
                Dim bytevalarry() As Byte = {treeData(i), treeData(i + 1)}
                Dim byteFxarry() As Byte = {treeData(i + 2), treeData(i + 3), treeData(i + 4), treeData(i + 5), treeData(i + 6), treeData(i + 7), treeData(i + 8), treeData(i + 9)}

                Dim byteval As Integer = BitConverter.ToInt16(bytevalarry, 0)
                Dim byteFx As Long = BitConverter.ToInt64(byteFxarry, 0)

                Dim arry() As Object = {byteval, byteFx, Nothing}
                Dictionary.Add(arry)
            Next

            rootNode = CreateHuffmanTree()
            AssignByteCode()

            expectedCompress = ComputeCompressedSize()
            ShowDictionary()

            'total directory,file number <TotalFile> (Integer)
            Dim firstLength(3) As Byte
            Freader.Read(firstLength, 0, firstLength.Length)
            Dim totalFile As Integer = BitConverter.ToInt32(firstLength, 0)

            'FOR REPORT
            expectedHeader += firstLength.Length

            For i As Integer = 0 To totalFile - 1

                '<path header value> Int
                Dim pathHeader(3) As Byte
                Freader.Read(pathHeader, 0, pathHeader.Length)
                Dim pathLength As Integer = BitConverter.ToInt32(pathHeader, 0)

                '<path data> String
                Dim pathData(pathLength - 1) As Byte
                Freader.Read(pathData, 0, pathData.Length)
                Dim pathName As String = System.Text.Encoding.UTF8.GetString(pathData)

                If pathName(0) = "0" Then
                    folderPath.Add(pathName.Remove(0, 1))
                    Console.WriteLine("folder" & pathName.Remove(0, 1))
                ElseIf pathName(0) = "1" Then
                    filePath.Add(pathName.Remove(0, 1))
                    Console.WriteLine("file" & pathName.Remove(0, 1))
                End If

                'FOR REPORT
                expectedHeader += pathHeader.Length + pathData.Length
            Next

            For Each fileP As String In filePath
                'Dim splitString() As String = fileP.Split(".")

                'NEW
                'Dim splitPath As String = fileP.Replace("." & splitString(splitString.Length - 1), "")
                'Dim extensionPath As String = splitString(splitString.Length - 1)
                'splitPath += "." & extensionPath(extensionPath.Length - 1)
                splPath.Add(outPath & fileP)
                Console.WriteLine("split path: " & outPath & fileP)

                'Console.WriteLine("full file name: " & fileP)
                'Console.WriteLine("split file name: " & outPath & fileP)
                ''splPath.Add(outPath & fileP)

                'OLD
                'splPath.Add(outPath & splitString(0))
                'Console.WriteLine("full file name: " & fileP)
                'Console.WriteLine("split path: " & splitPath)
                'Console.WriteLine("split file name: " & outPath & splitString(0))
            Next

            'create the file directories
            If folderPath.Count > 0 Then
                For Each folderP As String In folderPath
                    'Console.WriteLine(outPath & folderP)
                    If Not Directory.Exists(outPath & folderP) Then
                        Directory.CreateDirectory(outPath & folderP)
                    End If
                Next
            End If


            '<Long header> Int
            Dim longHeader(3) As Byte
            Freader.Read(longHeader, 0, longHeader.Length)
            Dim firstHeaderLength As Integer = BitConverter.ToInt32(longHeader, 0)

            'FOR REPORT
            expectedHeader += longHeader.Length

            For i As Integer = 0 To firstHeaderLength - 1
                Dim longData(7) As Byte
                Freader.Read(longData, 0, longData.Length)
                Dim dataLength As Long = BitConverter.ToInt64(longData, 0)
                firstHalfDataLength.Add(dataLength)
                Console.WriteLine("First Data length: " & dataLength)

                'FOR REPORT
                expectedHeader += longData.Length
            Next

            Dim secLongHeader(3) As Byte
            Freader.Read(secLongHeader, 0, secLongHeader.Length)
            Dim secHeaderLength As Integer = BitConverter.ToInt32(secLongHeader, 0)

            'FOR REPORT
            expectedHeader += secLongHeader.Length

            For i As Integer = 0 To secHeaderLength - 1
                Dim longData(7) As Byte
                Freader.Read(longData, 0, longData.Length)
                Dim dataLength As Long = BitConverter.ToInt64(longData, 0)
                secondHalfDataLength.Add(dataLength)
                Console.WriteLine("Second Data length: " & dataLength)

                'FOR REPORT
                expectedHeader += longData.Length
            Next

            'correct output

            'split the compressed data.
            'first Compressed file name: firstOutput.dec
            'second Compressed file name: secondOutput.dec

            Dim encHeader(7) As Byte
            Freader.Read(encHeader, 0, encHeader.Length)
            Dim FirstbytesToRead As Long = BitConverter.ToInt64(encHeader, 0)

            'FOR REPORT
            expectedHeader += encHeader.Length

            Dim totalfileLength As Long = New FileInfo(sourcePath).Length
            Dim totalReadedBytes As Long = 0

            Form1.overAllPercent = 0


            Form1.fileStatus = fstOutputPath
            Using Fwriter As New FileStream(fstOutputPath, FileMode.Create, FileAccess.Write)
                Dim bytesRead As Integer = 0
                Dim buffer(4096) As Byte

                Do
                    'exits the loop
                    If (FirstbytesToRead - totalReadedBytes) = 0 Then
                        Exit Do
                    End If

                    If (FirstbytesToRead - totalReadedBytes) >= 4096 Then
                        buffer = New Byte(4095) {}
                    Else
                        buffer = New Byte(FirstbytesToRead - totalReadedBytes - 1) {}
                    End If

                    bytesRead = Freader.Read(buffer, 0, buffer.Length)
                    Fwriter.Write(buffer, 0, bytesRead)
                    totalReadedBytes += bytesRead

                    Form1.readSpeed += bytesRead
                    Form1.writeSpeed += bytesRead
                    Form1.processPercent = totalReadedBytes / totalfileLength * 100
                Loop While bytesRead > 0

            End Using

            Form1.overAllPercent = 10

            'decFilesize += New FileInfo(fstOutputPath).Length


            Form1.fileStatus = secOutputPath
            Using Fwriter As New FileStream(secOutputPath, FileMode.Create, FileAccess.Write)
                Dim bytesread As Integer = 0
                Dim buffer(4096) As Byte

                Do
                    bytesread = Freader.Read(buffer, 0, buffer.Length)
                    Fwriter.Write(buffer, 0, bytesread)
                    totalReadedBytes += bytesread

                    Form1.readSpeed += bytesread
                    Form1.writeSpeed += bytesread
                    Form1.processPercent = totalReadedBytes / totalfileLength * 100
                Loop While bytesread > 0
            End Using

            'decFilesize += New FileInfo(secOutputPath).Length

            Form1.overAllPercent = 20

        End Using

        'Return
        ''================================================================================

        'you can delete the compressed file

        Form1.status = "Decompressing...."
        Form1.progressStatus = "Decompressing Data...."

        'decompress the seperated bytes
        Dim splitedFirstPath As New List(Of String)
        Dim splitedSecondPath As New List(Of String)

        'start MultiThreading

        Dim secondWorker As New Thread(Sub()
                                           Console.WriteLine("Second Worker started")
                                           DecodeFile(secOutputPath, splPath, secondHalfDataLength, splitedSecondPath, rootNode, False)
                                           Console.WriteLine("Second Worker ended")
                                       End Sub)

        'tell the second worker to start encoding the secondhalf file
        secondWorker.Start()
        DecodeFile(fstOutputPath, splPath, firstHalfDataLength, splitedFirstPath, rootNode, True)
        secondWorker.Join()

        'delete used compressed data
        File.Delete(fstOutputPath)
        File.Delete(secOutputPath)

        If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
            Return
        End If

        Form1.status = "Merging...."
        Form1.progressStatus = "Merging Data...."

        'Return

        'Merge the files
        Dim mergingFileCount As Integer = 0
        For i As Integer = 0 To filePath.Count - 1
            Dim outputPath As String = outPath & filePath(i)

            ''optimize this code. make the encoded half length
            'Using Fwriter As New FileStream(outPath & filePath(i), FileMode.Create, FileAccess.Write)
            '    Dim totalBytesToRead As Long = New FileInfo(splitedFirstPath(i)).Length + New FileInfo(splitedSecondPath(i)).Length
            '    Dim totalBytesReaded As Long = 0

            '    Form1.fileStatus = splitedFirstPath(i)
            '    Using Freader As New FileStream(splitedFirstPath(i), FileMode.Open, FileAccess.Read)
            '        Dim bytesRead As Integer = 0
            '        Dim buffer(4096) As Byte
            '        Do
            '            bytesRead = Freader.Read(buffer, 0, buffer.Length)
            '            Fwriter.Write(buffer, 0, bytesRead)
            '            totalBytesReaded += bytesRead

            '            Form1.readSpeed += bytesRead
            '            Form1.writeSpeed += bytesRead
            '            Form1.processPercent = totalBytesReaded / totalBytesToRead * 100
            '        Loop While bytesRead > 0
            '    End Using

            '    'delete the first splitted path
            '    'File.Delete(splitedFirstPath(i))

            '    Form1.fileStatus = splitedSecondPath(i)
            '    Using Freader As New FileStream(splitedSecondPath(i), FileMode.Open, FileAccess.Read)
            '        Dim bytesRead As Integer = 0
            '        Dim buffer(4096) As Byte
            '        Do
            '            bytesRead = Freader.Read(buffer, 0, buffer.Length)
            '            Fwriter.Write(buffer, 0, bytesRead)
            '            totalBytesReaded += bytesRead

            '            Form1.readSpeed += bytesRead
            '            Form1.writeSpeed += bytesRead
            '            Form1.processPercent = totalBytesReaded / totalBytesToRead * 100
            '        Loop While bytesRead > 0
            '    End Using

            '    'delete the second splitted path
            '    'File.Delete(splitedSecondPath(i))

            'End Using

            '****************************OPTIMIZED WAY***********************************************
            Dim totalBytesToRead As Long = New FileInfo(splitedFirstPath(i)).Length + New FileInfo(splitedSecondPath(i)).Length
            Dim totalBytesReaded As Long = 0

            Form1.fileStatus = splitedFirstPath(i)
            Using Fwriter As New FileStream(splitedFirstPath(i), FileMode.Append, FileAccess.Write)
                totalBytesReaded += Fwriter.Length
                Form1.fileStatus = splitedSecondPath(i)
                Using Freader As New FileStream(splitedSecondPath(i), FileMode.Open, FileAccess.Read)
                    Dim bytesRead As Integer = 0
                    Dim buffer(4096) As Byte

                    Do
                        bytesRead = Freader.Read(buffer, 0, buffer.Length)
                        Fwriter.Write(buffer, 0, bytesRead)
                        totalBytesReaded += bytesRead

                        Form1.readSpeed += bytesRead
                        Form1.writeSpeed += bytesRead
                        Form1.processPercent = totalBytesReaded / totalBytesToRead * 100
                    Loop While bytesRead > 0
                End Using
            End Using

            'moves the outputfile to a new location.
            My.Computer.FileSystem.MoveFile(splitedFirstPath(i), outputPath)
            '****************************OPTIMIZED WAY***********************************************

            'FOR REPORT
            decFilesize += New FileInfo(outputPath).Length
            mergingFileCount += 1
            Form1.overAllPercent = (mergingFileCount / filePath.Count * 10) + 90
        Next

        For i As Integer = 0 To filePath.Count - 1
            File.Delete(splitedFirstPath(i))
            File.Delete(splitedSecondPath(i))
        Next

        Form1.status = "Finished!"
        Form1.progressStatus = "Finished!"
        Form1.folderStatus = "Done."
        Form1.fileStatus = "Done."

    End Sub

    Private Sub EncodeFile(ByRef fpath As String, ByRef dictArray(,) As Object)

        ', ByRef dataLength As Long, ByRef dataBits As Long

        Dim userFile As New FileInfo(fpath)
        Dim outputFile As String = userFile.Directory.FullName & "\" & userFile.Name.Replace(userFile.Extension, ".enc")

        'Dim dictionaryArray(256, 2) As Object
        'For Each arry() As Object In Dictionary
        '    dictionaryArray(arry(0), 0) = arry(0)
        '    dictionaryArray(arry(0), 1) = 0
        '    dictionaryArray(arry(0), 2) = arry(2)
        'Next

        ''supplement new data frequency(fx)

        'Form1.progressStatus = "Reading File..."
        'ReadFile(fpath, dictionaryArray)
        'Form1.progressStatus = "Compressing File..."

        ''dataLength = userFile.Length
        'dataBits = 0
        'For i As Integer = 0 To dictionaryArray.GetLength(0) - 1
        '    If dictionaryArray(i, 2) IsNot Nothing Then
        '        dataBits += dictionaryArray(i, 1) * dictionaryArray(i, 2).ToString.Length
        '    End If
        'Next

        'If dataBits Mod 8 = 0 Then
        '    dataLength = dataBits / 8
        'Else
        '    dataLength = (dataBits \ 8) + 1
        'End If

        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'Console.WriteLine("byteVal   fx        code      ")

        'Dim totalFx As Long = 0
        'Dim totalBitCount As Long = 0

        'For i As Integer = 0 To dictionaryArray.GetLength(0) - 1
        '    totalFx += dictionaryArray(i, 1)

        '    Dim info As String = Nothing

        '    If dictionaryArray(i, 0) IsNot Nothing Then
        '        info += dictionaryArray(i, 0).ToString.PadRight(10)
        '    End If

        '    If dictionaryArray(i, 1) IsNot Nothing Then
        '        info += dictionaryArray(i, 1).ToString.PadRight(10)
        '    End If

        '    If dictionaryArray(i, 2) IsNot Nothing Then
        '        info += dictionaryArray(i, 2).ToString.PadRight(10)
        '        totalBitCount += dictionaryArray(i, 1) * dictionaryArray(i, 2).ToString.Length
        '    End If

        '    Console.WriteLine(info)
        'Next

        'If totalBitCount Mod 8 = 0 Then
        '    writetotalByte += totalBitCount / 8
        'Else
        '    writetotalByte += (totalBitCount \ 8) + 1
        'End If

        'Console.WriteLine(StrDup(30, "="))
        'Console.WriteLine(Dictionary.Count.ToString.PadRight(10) & totalFx.ToString.PadRight(30) & totalBitCount.ToString.PadRight(30))
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'bago ka mag encode check mo muna kung tama ung magiging frequency nung file

        'Console.WriteLine("Write Total byte: " & writetotalByte)

        'Dim originaltotalWrite As Long = 0

        'Encoding
        Using FWriter As New FileStream(outputFile, FileMode.Create, FileAccess.Write)

            'reading the original file
            Using Freader As New FileStream(fpath, FileMode.Open, FileAccess.Read)

                Dim byteCode As String = Nothing
                Dim bytesRead As Integer = 0

                Dim totalBytesRead As Long = 0
                Dim totalBytes As Long = New FileInfo(fpath).Length

                Do
                    'read 4096bytes of chunk
                    Dim buffer(4096) As Byte
                    bytesRead = Freader.Read(buffer, 0, buffer.Length)
                    totalBytesRead += bytesRead

                    'report
                    Form1.readSpeed += bytesRead

                    For i As Integer = 0 To bytesRead - 1
                        byteCode += dictArray(buffer(i), 2)

                        While byteCode.Length >= 8
                            'get the first 8 bits and convert to byte
                            FWriter.WriteByte(BinaryToByte(byteCode.Substring(0, 8)))

                            'report
                            'originaltotalWrite += 1
                            Form1.writeSpeed += 1

                            byteCode = byteCode.Remove(0, 8)
                        End While
                    Next

                    Form1.processPercent = (totalBytesRead / totalBytes) * 100
                    If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                        fpath = outputFile
                        Return
                    End If

                Loop While bytesRead > 0

                'ung current directory mo mapapalitan
                fpath = outputFile

                If byteCode.Length <> 0 Then
                    byteCode += StrDup(8 - byteCode.Length, "0")
                    FWriter.WriteByte(BinaryToByte(byteCode))
                    Form1.writeSpeed += 1
                End If

                'If byteCode.Length = 0 Then
                '    Return
                'End If

                'If byteCode.Length < 8 Then
                '    byteCode += StrDup(8 - byteCode.Length, "0")
                'End If

                'FWriter.WriteByte(BinaryToByte(byteCode))

                'report
                'originaltotalWrite += 1
                'Form1.writeSpeed += 1

            End Using

        End Using

        'Console.WriteLine("Original writed Total byte: " & originaltotalWrite)
        'Console.WriteLine("Total writed byte: " & totalWritedByte)

    End Sub

    Private Sub EncodeFile(ByRef listOfFiles As List(Of String), ByRef encDataToReadList As List(Of Long), ByRef dict(,) As Object, ByVal outPath As String)

        Using Fwriter As New FileStream(outPath, FileMode.Create, FileAccess.Write)

            Dim byteCodes As String = Nothing
            Dim readedFileCount As Integer = 0

            For Each fpath As String In listOfFiles
                'action will be cancelled after a file
                If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                    Exit For
                End If

                Dim userFile As New FileInfo(fpath)

                Form1.fileStatus = userFile.FullName

                Using Freader As New FileStream(fpath, FileMode.Open, FileAccess.Read)
                    Dim totalBytesRead As Long = 0
                    Dim bytesRead As Integer = 0
                    Dim buffer(4096) As Byte

                    Do
                        bytesRead = Freader.Read(buffer, 0, buffer.Length)
                        totalBytesRead += bytesRead

                        For i As Integer = 0 To bytesRead - 1
                            byteCodes += dict(buffer(i), 2)

                            While byteCodes.Length >= 8
                                Fwriter.WriteByte(BinaryToByte(byteCodes.Substring(0, 8)))
                                byteCodes = byteCodes.Remove(0, 8)
                                Form1.writeSpeed += 1
                            End While
                        Next

                        Form1.readSpeed += bytesRead
                        Form1.processPercent = (totalBytesRead / userFile.Length) * 100

                    Loop While bytesRead > 0
                End Using
                encDataToReadList.Add(userFile.Length)
                Console.WriteLine(userFile.FullName & ": FileLength: " & userFile.Length)

                readedFileCount += 1
                Form1.overAllPercent = (readedFileCount / listOfFiles.Count * 70) + 20

                'delete the path
                'File.Delete(fpath)
            Next

            For Each fpath In listOfFiles
                'delete the path
                File.Delete(fpath)
            Next

            If byteCodes.Length <> 0 Then
                byteCodes += StrDup(8 - byteCodes.Length, "0")
                Fwriter.WriteByte(BinaryToByte(byteCodes))
                isAdditionalByte = True
                Console.WriteLine("Additional byte: true")
            Else
                Console.WriteLine("Additional byte: false")
            End If

        End Using

        If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
            File.Delete(outPath)
        End If


    End Sub

    Private Sub DecodeFile(ByRef fpath As String, ByVal dataBitLength As Long, ByVal rNode As Node)

        Dim userFile As New FileInfo(fpath)
        Dim outpath As String = userFile.DirectoryName & "\" & userFile.Name.Replace(userFile.Extension, "") & ".spl"
        Dim currentNode As Node = rNode

        Using Freader As New FileStream(fpath, FileMode.Open, FileAccess.Read)

            Using Fwriter As New FileStream(outpath, FileMode.Create, FileAccess.Write)
                Dim bytesRead As Integer = 0
                Dim totalBytesRead As Long = 0
                Dim totalBytes As Long = userFile.Length
                Dim buffer(32768) As Byte


                'NOTE MAKE A function TO A NODE TO RETURN THE NUMBER OF BITS TO LOCATE THE PARENT NODE.
                'TEST ONLY TO CHECK IF IT IS OPTIMAL

                Do
                    'Console.WriteLine("Data bit Length: " & dataBitLength)
                    If dataBitLength <= 0 Then
                        Exit Do
                    End If

                    bytesRead = Freader.Read(buffer, 0, buffer.Length)
                    totalBytesRead += bytesRead

                    Dim bin As New BitArray(buffer)

                    Dim bitToRead As Integer = 0
                    If dataBitLength >= bin.Count Then
                        bitToRead = bin.Count
                    Else
                        bitToRead = dataBitLength
                    End If
                    dataBitLength -= bitToRead

                    For i As Integer = 0 To bitToRead - 1

                        'traverse
                        If bin(i) Then
                            currentNode = currentNode.getLNode()
                        Else
                            currentNode = currentNode.getRNode()
                        End If

                        'checks if the current node is leaf
                        If Not currentNode.HasChild() Then
                            Fwriter.WriteByte(currentNode.GetData(0))
                            Form1.writeSpeed += 1
                            currentNode = rNode
                        End If

                    Next

                    Form1.readSpeed += bytesRead
                    Form1.processPercent = totalBytesRead / totalBytes * 100

                    If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                        Exit Do
                    End If

                Loop While bytesRead > 0
            End Using

            If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                File.Delete(outpath)
            End If

        End Using

        'Delete the readed file
        File.Delete(fpath)
        'Console.WriteLine("DECOMPRESSION FPATH: " & fpath)

        fpath = outpath

    End Sub

    Private Sub DecodeFile(ByVal encPath As String, ByRef fpaths As List(Of String), ByRef dataToRead As List(Of Long), ByRef splPath As List(Of String), ByVal rNode As Node, ByVal isFirst As Boolean)

        Using Freader As New FileStream(encPath, FileMode.Open, FileAccess.Read)
            Dim totalBytesToRead As Long = New FileInfo(encPath).Length
            Dim totalBytesReaded As Long = 0
            Dim bytesRead As Integer = 0
            Dim buffer(8192) As Byte
            Dim bin As BitArray = Nothing
            Dim index As Integer = 0
            Dim isComplete As Boolean = True
            Dim currentNode As Node = rNode

            Dim encodedFileCount As Integer = 0
            For i As Integer = 0 To fpaths.Count - 1
                Dim outputPath As String = Nothing

                'NEW
                Dim currentPath As String = fpaths(i)
                Dim splitPath As String() = fpaths(i).Split(".")

                Console.WriteLine("split path length: " & splitPath.Length)
                For j As Integer = 0 To splitPath.Length - 1
                    Console.WriteLine("spl: " & splitPath(j))
                Next

                'If isFirst Then
                '    outputPath = currentPath.Substring(0, currentPath.Length - (splitPath(splitPath.Length - 1).Length + 1)) & " (1)." & splitPath(splitPath.Length - 1)
                'Else
                '    outputPath = currentPath.Substring(0, currentPath.Length - (splitPath(splitPath.Length - 1).Length + 1)) & " (2)." & splitPath(splitPath.Length - 1)
                'End If

                'V 0_04
                If Not splitPath.Length = 1 Then
                    If isFirst Then
                        outputPath = currentPath.Substring(0, currentPath.Length - (splitPath(splitPath.Length - 1).Length + 1)) & " (1)." & splitPath(splitPath.Length - 1) & "spl"
                    Else
                        outputPath = currentPath.Substring(0, currentPath.Length - (splitPath(splitPath.Length - 1).Length + 1)) & " (2)." & splitPath(splitPath.Length - 1) & "spl"
                    End If
                Else
                    If isFirst Then
                        outputPath = currentPath & " (1)"
                    Else
                        outputPath = currentPath & " (2)"
                    End If
                End If




                'Dim currentPath As String = fpaths(i)
                'If isFirst Then
                '    outputPath = currentPath.Substring(0, currentPath.Length - 2) & " (1).spl" & currentPath(currentPath.Length - 1)
                'Else
                '    outputPath = currentPath.Substring(0, currentPath.Length - 2) & " (2).spl" & currentPath(currentPath.Length - 1)
                'End If

                'outputPath = fpaths(i)

                'OLD
                'If isFirst Then
                '    outputPath = fpaths(i) & " (1).spl"
                'Else
                '    outputPath = fpaths(i) & " (2).spl"
                'End If

                splPath.Add(outputPath)
                Console.WriteLine("Output PATH: " & outputPath)

                'Continue For

                Form1.fileStatus = outputPath
                Using Fwriter As New FileStream(outputPath, FileMode.Create, FileAccess.Write)
                    Dim bytesToRead As Long = dataToRead(i)

                    'new
                    If bytesToRead <= 0 Then
                        Continue For
                    End If

                    Do
                        If isComplete Then
                            bytesRead = Freader.Read(buffer, 0, buffer.Length)
                            bin = New BitArray(buffer)
                            isComplete = False
                            totalBytesReaded += bytesRead

                            Form1.readSpeed += bytesRead
                            Form1.processPercent = totalBytesReaded / totalBytesToRead * 100
                        End If

                        For j As Integer = index To bin.Length - 1

                            'traverse
                            If bin(j) Then
                                currentNode = currentNode.getLNode()
                            Else
                                currentNode = currentNode.getRNode()
                            End If

                            'checks if the current node is leaf
                            If Not currentNode.HasChild() Then
                                Fwriter.WriteByte(currentNode.GetData(0))
                                Form1.writeSpeed += 1
                                currentNode = rNode
                                bytesToRead -= 1

                                If bytesToRead = 0 Then

                                    'chinecheck kung ung current index naten is nasa end na nung bitArray index, 
                                    'kung ganon rest ng value tas mag fill up ng bagong data para sa bin
                                    'pag hindi set mo ung value ng j to index tas ung isComplete = false
                                    If j = bin.Length - 1 Then
                                        index = 0
                                        isComplete = True
                                    Else
                                        index = j + 1
                                        isComplete = False
                                    End If

                                    Exit Do
                                End If

                            End If

                        Next

                        'reset the values if done
                        index = 0
                        isComplete = True
                    Loop While bytesRead > 0

                End Using

                'this will be cancelled after a complete file
                If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                    File.Delete(outputPath)
                    Exit For
                End If

                encodedFileCount += 1
                Form1.overAllPercent = (encodedFileCount / fpaths.Count * 70) + 20
            Next

        End Using

        'If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
        '    File.Delete(encPath)
        'End If
    End Sub


    Public Sub FileSplitter(ByVal fpath As String, ByRef firstHPath As String, ByRef firstDict(,) As Object, ByRef lastHPath As String)


        'ByVal fpath As String, ByRef firstHPath As String, ByRef lastHPath As String
        'ByVal fpath As String, ByRef firstHPath As String, ByRef fdataLength As Long, ByRef fdataBits As Long, ByRef fdictionary(,) As Object, ByRef lastHPath As String, ByRef sdataLength As Long, ByRef sdataBits As Long, ByRef sdictionary(,) As Object

        'ByRef dataLength As Long, ByRef dataBits As Long

        Dim userFile As New FileInfo(fpath)
        Dim fileTotalByte As Long = userFile.Length
        Dim halfValue As Long = userFile.Length \ 2
        Dim readedTotalByte As Long = 0

        If Not userFile.Extension = "" Then
            firstHPath = userFile.Directory.FullName & "\" & userFile.Name.Replace(userFile.Extension, "") & " (1).spl"
            lastHPath = userFile.Directory.FullName & "\" & userFile.Name.Replace(userFile.Extension, "") & " (2).spl"
        Else
            firstHPath = userFile.Directory.FullName & "\" & userFile.Name & " (1).spl"
            lastHPath = userFile.Directory.FullName & "\" & userFile.Name & " (2).spl"
        End If

        Console.WriteLine(fileTotalByte)
        Console.WriteLine(halfValue)
        Console.WriteLine(firstHPath)

        Dim totalBytesRead As Long = 0

        Form1.folderStatus = fpath
        Using fReader As New FileStream(fpath, FileMode.Open, FileAccess.Read)

            'encode the header for the splitter 
            '<Integer><identicalExtension><Integer><LastHalf>


            'writing the half of a file to new file
            Form1.fileStatus = firstHPath
            Using fWriter As New FileStream(firstHPath, FileMode.Create, FileAccess.Write)

                'Dictionary
                'For Each arry() As Object In Dictionary
                '    fdictionary(arry(0), 0) = arry(0)
                '    fdictionary(arry(0), 1) = 0
                '    fdictionary(arry(0), 2) = arry(2)
                'Next

                'extensionHeader = 4bytes
                Dim extsnHeader As Byte() = BitConverter.GetBytes(userFile.Extension.Length)
                fWriter.Write(extsnHeader, 0, extsnHeader.Length)
                Form1.writeSpeed += extsnHeader.Length

                'FOR REPORTING
                'expectedHeader += extsnHeader.Length

                'TEST FOR REVISION UNCOMMENT THIS AND "THE REVISION BEFORE READING THE ENTIRE FILE" AT THE TOP.
                ''writing the header
                'For i As Integer = 0 To extsnHeader.Length - 1
                '    firstDict(extsnHeader(i), 1) += 1
                'Next

                Console.WriteLine("Entry header: " & userFile.Extension.Length)

                'extensionData = string length in bytes
                Dim extensionData As Byte() = System.Text.Encoding.UTF8.GetBytes(userFile.Extension)
                fWriter.Write(extensionData, 0, extensionData.Length)
                Console.WriteLine("Entry Extension: " & userFile.Extension)
                Form1.writeSpeed += extensionData.Length

                'FOR REPORTING
                'expectedHeader += extensionData.Length

                'TEST FOR REVISION UNCOMMENT THIS AND "THE REVISION BEFORE READING THE ENTIRE FILE" AT THE TOP.
                ''writing the header
                'For i As Integer = 0 To extensionData.Length - 1
                '    firstDict(extensionData(i), 1) += 1
                'Next

                ''TargetPathHeader = 4bytes
                'Dim lastHalfPath As String = userFile.Directory.FullName & "\" & userFile.Name.Replace(userFile.Extension, "") & " (" & (numOrder + 1).ToString & ").spl"
                'Dim lastHalfHeader As Byte() = BitConverter.GetBytes(lastHalfPath.Length)
                'fWriter.Write(lastHalfHeader, 0, lastHalfHeader.Length)

                ''LastTargetData = string length in bytes
                'Dim lastTargetPath As Byte() = System.Text.Encoding.UTF8.GetBytes(lastHalfPath)
                'fWriter.Write(lastTargetPath, 0, lastTargetPath.Length)

                Dim bytesRead As Integer = 0
                Do
                    'Console.WriteLine("Half: " & halfValue & " Readed: " & readedTotalByte)
                    'Thread.Sleep(1000)

                    'bumase ka doon sa value nung sa condition na dapat ganon din ung magiging laman ng buffer
                    Dim buffer() As Byte
                    If (halfValue - readedTotalByte) >= 4096 Then
                        buffer = New Byte(4095) {}
                    Else
                        buffer = New Byte(halfValue - readedTotalByte - 1) {}
                    End If

                    bytesRead = fReader.Read(buffer, 0, buffer.Length)

                    ''creating new dictionary for the first half of the file
                    'For i As Integer = 0 To bytesRead - 1
                    '    fdictionary(buffer(i), 1) += 1
                    'Next

                    'fWriter.Write(buffer, 0, buffer.Length)
                    fWriter.Write(buffer, 0, bytesRead)
                    totalBytesRead += bytesRead


                    'Report
                    Form1.readSpeed += bytesRead
                    Form1.writeSpeed += bytesRead
                    Form1.processPercent = totalBytesRead / fileTotalByte * 50

                    'If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                    '    Return
                    'End If

                    'Console.WriteLine("BytesRead: " & bytesRead)
                    'Console.WriteLine("Actual Data: " & System.Text.Encoding.UTF8.GetString(buffer))
                    readedTotalByte += bytesRead

                    If readedTotalByte = halfValue Then
                        Exit Do
                    End If

                Loop While bytesRead > 0

                ''calculating totalBits for the first file
                'fdataBits = 0
                'For i As Integer = 0 To fdictionary.GetLength(0) - 1
                '    If fdictionary(i, 2) IsNot Nothing Then
                '        fdataBits += fdictionary(i, 1) * fdictionary(i, 2).ToString.Length
                '    End If
                'Next

                ''calculating fdata
                'If fdataBits Mod 8 = 0 Then
                '    fdataLength = fdataBits / 8
                'Else
                '    fdataLength = (fdataBits \ 8) + 1
                'End If

            End Using

            'writing the last half of a file to new file
            Form1.fileStatus = lastHPath
            Using fWriter As New FileStream(lastHPath, FileMode.Create, FileAccess.Write)

                'For Each arry() As Object In Dictionary
                '    sdictionary(arry(0), 0) = arry(0)
                '    sdictionary(arry(0), 1) = 0
                '    sdictionary(arry(0), 2) = arry(2)
                'Next

                Dim bytesRead As Integer = 0
                Do
                    Dim buffer(4096) As Byte
                    bytesRead = fReader.Read(buffer, 0, buffer.Length)

                    ''creating new dictionary for the first half of the file
                    'For i As Integer = 0 To bytesRead - 1
                    '    sdictionary(buffer(i), 1) += 1
                    'Next

                    fWriter.Write(buffer, 0, bytesRead)
                    totalBytesRead += bytesRead

                    'report
                    Form1.readSpeed += bytesRead
                    Form1.writeSpeed += bytesRead
                    Form1.processPercent = (totalBytesRead / fileTotalByte) * 100

                    'If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                    '    Return
                    'End If

                    'Console.WriteLine(totalBytesRead & " / " & fileTotalByte)

                Loop While bytesRead > 0

                'sdataBits = 0
                'For i As Integer = 0 To sdictionary.GetLength(0) - 1
                '    If sdictionary(i, 2) IsNot Nothing Then
                '        sdataBits += sdictionary(i, 1) * sdictionary(i, 2).ToString.Length
                '    End If
                'Next

                'If sdataBits Mod 8 = 0 Then
                '    sdataLength = sdataBits / 8
                'Else
                '    sdataLength = (sdataBits \ 8) + 1
                'End If

            End Using

            Form1.overAllPercent = 20

        End Using

    End Sub

    Public Sub FileMerger(ByVal fpath As String)

        Dim userFile As New FileInfo(fpath)
        'just add identical extension for the identical path

        'current Identical path has no extension it will be included after reading it from the file
        Dim identicalPath As String = userFile.Directory.FullName & "\" & userFile.Name.Remove(userFile.Name.Length - userFile.Extension.Length - 4, userFile.Extension.Length + 4)
        Dim lastHalfPath As String = userFile.Directory.FullName & "\" & userFile.Name.Remove(userFile.Name.Length - userFile.Extension.Length - 2, userFile.Extension.Length + 2) & "2)" & userFile.Extension

        Console.WriteLine("File merger: information")
        Console.WriteLine(identicalPath)
        Console.WriteLine(lastHalfPath)

        Dim lastuserFile As New FileInfo(lastHalfPath)

        'Dim Fwriter As FileStream = Nothing
        Dim outputPath As String = Nothing

        'First Half of the file to be merged
        Using FReader As New FileStream(fpath, FileMode.Open, FileAccess.Read)

            Dim header(3) As Byte
            FReader.Read(header, 0, header.Length)

            Dim extsnLength As Integer = BitConverter.ToInt32(header, 0)
            Console.WriteLine("Output header: " & extsnLength)

            Dim extsnData(extsnLength - 1) As Byte
            FReader.Read(extsnData, 0, extsnData.Length)

            Dim extensionS As String = System.Text.Encoding.UTF8.GetString(extsnData)
            Console.WriteLine("Output String: " & extensionS)

            'check for filename if it is exist
            outputPath = identicalPath & extensionS
            Dim finfo As New FileInfo(outputPath)
            Dim ctr As Integer = 1
            While File.Exists(outputPath)
                outputPath = finfo.DirectoryName & "\" & finfo.Name.Replace(finfo.Extension, "") & " (" & ctr.ToString & ")" & finfo.Extension
                ctr += 1
            End While

            'FOR DATA REPORT
            'decOutputPath = outputPath
            mainOutputPath = outputPath

            Using Fwriter As New FileStream(outputPath, FileMode.Create, FileAccess.Write)

                'first Half
                Dim bytesRead As Integer = 0
                Dim totalBytesRead As Long = 0
                Dim totalBytes As Long = userFile.Length + lastuserFile.Length

                Do
                    Dim buffer(4096) As Byte
                    bytesRead = FReader.Read(buffer, 0, buffer.Length)
                    Fwriter.Write(buffer, 0, bytesRead)
                    totalBytesRead += bytesRead

                    'report
                    Form1.readSpeed += bytesRead
                    Form1.writeSpeed += bytesRead
                    Form1.processPercent = (totalBytesRead / totalBytes) * 100

                    If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                        Return
                    End If

                Loop While bytesRead > 0

                Form1.overAllPercent = (totalBytesRead / totalBytes) * 10 + 90

                'Last Half of the file to be merged
                'double check the name and application of the variable name
                Using flastReader As New FileStream(lastHalfPath, FileMode.Open, FileAccess.Read)
                    Dim lbytesRead As Integer = 0
                    Do
                        Dim buffer(4096) As Byte
                        lbytesRead = flastReader.Read(buffer, 0, buffer.Length)
                        Fwriter.Write(buffer, 0, lbytesRead)
                        totalBytesRead += lbytesRead

                        'report
                        Form1.readSpeed += lbytesRead
                        Form1.writeSpeed += lbytesRead
                        Form1.processPercent = (totalBytesRead / totalBytes) * 100

                        If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                            Return
                        End If

                    Loop While lbytesRead > 0
                End Using

                Form1.overAllPercent = (totalBytesRead / totalBytes) * 10 + 90

            End Using

            decFilesize = New FileInfo(outputPath).Length

        End Using



        'Delete the left decoded files
        File.Delete(fpath)
        File.Delete(lastHalfPath)

        Form1.overAllPercent = 100
        Form1.processPercent = 100

    End Sub


    Private Sub ReadFile(ByVal fpath As String, ByRef firstDictArry(,) As Object, ByRef secondDictArry(,) As Object)
        Dim userfile As New FileInfo(fpath)
        Dim fileTotalByte As Long = userfile.Length
        Dim halfValue As Long = userfile.Length \ 2
        Dim totalBytesRead As Long = 0
        Dim firsthalf As Boolean = True

        'Reading The File
        Using freader As New FileStream(fpath, FileMode.Open, FileAccess.Read)

            Dim bytesRead As Integer = 0
            Dim buffer(4096) As Byte

            Do
                If firsthalf Then

                    'ung 4096 is nakabase sa bytes na babasahin, kaya 4095 sa pag create ng buffer kasi bilang ung 0 dun.
                    If (halfValue - totalBytesRead) >= 4096 Then
                        buffer = New Byte(4095) {}
                    Else
                        buffer = New Byte(halfValue - totalBytesRead - 1) {}
                    End If

                    bytesRead = freader.Read(buffer, 0, buffer.Length)

                    'ang mafifilup lang neto is ung frequency
                    For i As Integer = 0 To bytesRead - 1
                        charFx(buffer(i)) += 1
                    Next

                    totalBytesRead += bytesRead

                    If totalBytesRead = halfValue Then

                        'copy the value of char fx to first byte
                        For i As Integer = 0 To charFx.Length - 1
                            firstDictArry(i, 1) = charFx(i)
                        Next

                        buffer = New Byte(4096) {}
                        firsthalf = False
                        'Exit Do
                    End If

                Else

                    bytesRead = freader.Read(buffer, 0, buffer.Length)
                    For i As Integer = 0 To bytesRead - 1
                        charFx(buffer(i)) += 1
                    Next
                    totalBytesRead += bytesRead

                End If

                'report
                Form1.readSpeed += bytesRead
                Form1.overAllPercent = (totalBytesRead / fileTotalByte * 10)
                Form1.processPercent = totalBytesRead / fileTotalByte * 100

                If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                    Return
                End If

                'Check for cancelation
            Loop While bytesRead > 0

            'transfer the second half frequency to secondDictionary
            For i As Integer = 0 To charFx.Length - 1
                secondDictArry(i, 1) = charFx(i) - firstDictArry(i, 1)
            Next

        End Using

        CreateByteFrequency()
    End Sub

    'For multi Reading of files.
    Private Sub ReadFile(ByVal fpath As String, ByRef firstHPath As String, ByRef secondHPath As String, ByVal totalByte As Long)

        'make read files with split
        Dim userFile As New FileInfo(fpath)
        Dim totalbytes As Long = userFile.Length
        Dim halfValue As Long = userFile.Length \ 2

        'V 0_01
        'firstHPath = userFile.FullName.Replace(userFile.Extension, "") & " (1).spl"
        'secondHPath = userFile.FullName.Replace(userFile.Extension, "") & " (2).spl"

        'V 0_02
        'new revised file name, to prevent file path duplication
        'firstHPath = userFile.FullName.Replace(userFile.Extension, "") & " (1).spl" & userFile.Extension(userFile.Extension().Length - 1)
        'secondHPath = userFile.FullName.Replace(userFile.Extension, "") & " (2).spl" & userFile.Extension(userFile.Extension().Length - 1)

        Console.WriteLine("Userfile: " & userFile.FullName & " : " & "Extension: " & userFile.Extension)

        'firstHPath = userFile.FullName.Replace(userFile.Extension, "") & " (1)" & userFile.Extension()
        'secondHPath = userFile.FullName.Replace(userFile.Extension, "") & " (2)" & userFile.Extension()

        'V 0_03
        'there's an issue creating a compress reference for the compression because there's a file that has no extension
        'If Not userFile.Extension = "" Then
        '    firstHPath = userFile.FullName.Replace(userFile.Extension, "") & " (1)" & userFile.Extension()
        '    secondHPath = userFile.FullName.Replace(userFile.Extension, "") & " (2)" & userFile.Extension()
        'Else
        '    firstHPath = userFile.FullName & " (1)" & userFile.Extension()
        '    secondHPath = userFile.FullName & " (2)" & userFile.Extension()
        'End If

        'V 0_03
        'there's an issue creating a compress reference for the compression because there's a file that has no extension
        If Not userFile.Extension = "" Then
            firstHPath = userFile.FullName.Replace(userFile.Extension, "") & " (1)" & userFile.Extension() & "spl"
            secondHPath = userFile.FullName.Replace(userFile.Extension, "") & " (2)" & userFile.Extension() & "spl"
        Else
            firstHPath = userFile.FullName & " (1)" & userFile.Extension()
            secondHPath = userFile.FullName & " (2)" & userFile.Extension()
        End If

        Using Fwriter As New FileStream(firstHPath, FileMode.Create, FileAccess.Write)
            Using Swriter As New FileStream(secondHPath, FileMode.Create, FileAccess.Write)

                Using Freader As New FileStream(fpath, FileMode.Open, FileAccess.Read)
                    Dim totalBytesRead As Long = 0
                    Dim bytesRead As Integer = 0
                    Dim buffer(4096) As Byte
                    Dim isFirst As Boolean = True

                    Do

                        If isFirst Then

                            'filter the first file
                            If (halfValue - totalBytesRead) >= 4096 Then
                                buffer = New Byte(4095) {}
                            Else
                                buffer = New Byte(halfValue - totalBytesRead - 1) {}
                            End If

                            bytesRead = Freader.Read(buffer, 0, buffer.Length)
                            'write the readed file to a new file
                            Fwriter.Write(buffer, 0, bytesRead)
                            'compute total bytes read
                            totalBytesRead += bytesRead

                            'fill up the charFx for the Main Dictionary
                            For i As Integer = 0 To bytesRead - 1
                                charFx(buffer(i)) += 1
                            Next

                            If halfValue = totalBytesRead Then
                                isFirst = False
                                buffer = New Byte(4096) {}
                            End If

                        Else

                            bytesRead = Freader.Read(buffer, 0, buffer.Length)
                            Swriter.Write(buffer, 0, bytesRead)
                            totalBytesRead += bytesRead

                            'fill up the charFx for the Main Dictionary
                            For i As Integer = 0 To bytesRead - 1
                                charFx(buffer(i)) += 1
                            Next

                        End If

                        Form1.readSpeed += bytesRead
                        Form1.processPercent = totalBytesRead / userFile.Length * 100

                        If Form1.errorCode = 5 Or Form1.errorCode = 6 Then
                            Return
                        End If

                    Loop While bytesRead > 0
                End Using

            End Using
        End Using

        'delete the original file if needed.
        'HERE

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
            Form1.overAllPercent = (percentage * 2.5) + 10
            Form1.processPercent = percentage * 100
            ''ShowProgressPercentage((percentage * 5) + 20)

        End While

        Return treeNodes(0)

    End Function

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

                    'left = 1
                    'right = 0

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
                        Form1.overAllPercent = (percentage * 2.5) + 12.5
                        Form1.processPercent = percentage * 100

                        'Console.WriteLine("%: " & (percentage * 5) + 45)
                        'ShowProgressPercentage((percentage * 5) + 25)

                        Exit For
                    End If
                Next
            End If

        End While

    End Sub

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

    Private Sub CreateByteFrequency()

        For i As Integer = 0 To charFx.Length - 1

            If charFx(i) <> 0 Then
                Dim nums(3) As Object
                nums(0) = i
                nums(1) = charFx(i)
                nums(2) = Nothing

                'Console.WriteLine("added!")

                Dictionary.Add(nums)
            End If

        Next

    End Sub

    Private Sub CalculateByteFrequency(ByVal buffer As Byte(), ByVal bytesRead As Integer)
        For i As Integer = 0 To bytesRead - 1
            charFx(buffer(i)) += 1
        Next
    End Sub

    Private Function BinaryToByte(ByVal binary As String) As Byte
        Return (Val(binary(0)) * (2 ^ 0)) + (Val(binary(1)) * (2 ^ 1)) + (Val(binary(2)) * (2 ^ 2)) + (Val(binary(3)) * (2 ^ 3)) + (Val(binary(4)) * (2 ^ 4)) + (Val(binary(5)) * (2 ^ 5)) + (Val(binary(6)) * (2 ^ 6)) + (Val(binary(7)) * (2 ^ 7))
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
            Else
                Console.WriteLine("File cannot be compressed!")
            End If

        End If

    End Sub

    Private Function IsCompressable(ByVal sourceLength As Long) As Boolean

        Dim expCompressedSize As Long = ComputeCompressedSize()
        Dim remainingBytes As Long = sourceLength - expCompressedSize

        If remainingBytes <= 0 Then
            Return False
        End If

        Return True

    End Function

    Private Function IsLowRate(ByVal sourceLength As Long) As Boolean

        Dim expCompressedSize As Long = ComputeCompressedSize()

        Dim remainingBytes As Long = sourceLength - expCompressedSize
        Dim compressionPercent As Double = Math.Round((remainingBytes / sourceLength) * 100, 2)
        compPercent = compressionPercent
        compDiff = remainingBytes

        If compressionPercent < 3.0 Then
            Return True
        End If

        Return False

    End Function

    Private Function ComputeCompressedSize() As Long

        Dim totalBitCount As Long = 0
        Dim expectedOutputSize As Long = 0

        For Each arry() As Object In Dictionary
            totalBitCount += arry(1) * arry(2).ToString.Length
        Next

        Console.WriteLine("Total Bit Count: " & totalBitCount)

        If Not (totalBitCount) Mod 8 = 0 Then
            expectedOutputSize = (totalBitCount \ 8) + 1
        Else
            expectedOutputSize = totalBitCount / 8
        End If

        Return expectedOutputSize

    End Function

    Public Sub SuspendSpliitedFiles()
        For Each fpath In firstTFilePath
            File.Delete(fpath)
        Next

        For Each fpath In secondTFilePath
            File.Delete(fpath)
        Next
    End Sub

    Public Sub SetIgnore(ByVal status As Boolean)
        Me.ignoreCheck = status
    End Sub

    Public Function GetCompressionDifference() As Long
        Return compDiff
    End Function

    Public Function GetCompressionPercent() As Double
        Return compPercent
    End Function

    Public Function GetComputeCompressedSize() As Long
        Return expectedCompress
    End Function

    Public Function GetComputedCompressedHeader() As Long
        Return expectedHeader
    End Function

    Public Function GetOutputPath() As String
        Return mainOutputPath
    End Function

    'Public Function GetDecompressOutputPath() As String
    '    Return decFilesize
    'End Function

    Public Function GetDecodedTotalBytes() As Long
        Return decFilesize
    End Function
End Class
