Imports System.IO
Public Class Form1

    Private Shared cRootNode As PathNode = Nothing
    Private Shared currentPNode As PathNode = Nothing
    Public Shared selectedControls As New List(Of DirectoryControl)
    Private dirControlCollection As New List(Of DirectoryControl)

    Private currentDir As String = Nothing

    Private compressor As New CompressFile
    Private decompressor As New DecompressFile

    'reports
    Public Shared overAllPercent As Double = 0.0
    Public Shared status As String = Nothing

    Public Shared progressStatus As String = Nothing
    Public Shared processPercent As Double = 0

    Public Shared folderStatus As String = Nothing
    Public Shared fileStatus As String = Nothing

    Public Shared writeSpeed As Long = 0
    Public Shared readSpeed As Long = 0

    Dim isProcessing As Boolean = False
    Dim isCompressing As Boolean = True
    Dim isLowRate As Boolean = False

    Dim isMultiThread As Boolean = False
    Dim isIgnore As Boolean = False

    'error code meaning
    '0 = no errors
    '1 = file cannot be compressed.
    '2 = file is unsupported file type
    '3 = file is already compressed, the file is for decompress only
    '5 = operation cancellation
    '6 = raise to exit
    '7 = Low compression rate
    '8 = .huff file corrupted
    Public Shared errorCode As Integer = 0

    Public Sub SetRootNode(ByVal p As PathNode)
        cRootNode = p
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Dim vScrollBarHelper As Guna.UI.Lib.ScrollBar.PanelScrollHelper

    Dim d As New DirectoryControl
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        vScrollBarHelper = New Guna.UI.Lib.ScrollBar.PanelScrollHelper(flpFileDirectory, vsbFileDirectory, True)
        vScrollBarHelper.UpdateScrollBar()

        'Dim totalBit As Long = 1911178408
        'Dim totalByte As Double = totalBit / 8

        'Console.WriteLine(totalByte)
        'Console.WriteLine(totalByte Mod 8)

        'If Not (totalBit / 8) Mod 8 = 0 Then
        '    expectedOutputSize = (totalBitCount \ 8) + 1
        'Else
        '    expectedOutputSize = totalBitCount / 8
        'End If

        'Dim sampleString As String = "y2mate.com - Disco Cha Cha Line Dance 신나는 디스코 차차를 즐겨보세요"
        'Console.WriteLine("String length: " & sampleString.Length)

        'Dim textByte() As Byte = System.Text.Encoding.UTF8.GetBytes(sampleString)
        'Console.WriteLine("Actual String length (bytes): " & textByte.Length)

        'For i As Integer = 0 To sampleString.Length - 1
        '    Console.WriteLine(sampleString(i) & " : " & Convert.ToString(Convert.ToInt32(sampleString(i)), 16))
        'Next

        'Dim outputString As String = System.Text.Encoding.UTF8.GetString(textByte)
        'Console.WriteLine(outputString)

        'For i As Integer = 0 To outputString.Length - 1
        '    Console.WriteLine(outputString(i) & " : " & Convert.ToString(Convert.ToInt32(outputString(i)), 16))
        'Next
        Console.WriteLine("start!")
        For i As Integer = 0 To 0 - 1
            Console.WriteLine("hello!")
        Next

        Console.WriteLine("end!")




        'Dim queue1 As New Queue(Of Integer)
        'queue1.Enqueue(1)
        'queue1.Enqueue(2)
        'queue1.Enqueue(3)

        'Dim queue2 As New Queue(Of Integer)(queue1)
        'queue2.Enqueue(5)

        'While queue1.Count > 0
        '    Console.WriteLine("q1: " & queue1.Dequeue)
        'End While

        'While queue2.Count > 0
        '    Console.WriteLine("q2: " & queue2.Dequeue)
        'End While


        'Dim sourcePathAttribute As FileSystemObject = GetPathType("X:\TestCompression\Comparison")
        'If sourcePathAttribute.HasFlag(FileSystemObject.File) Then
        '    Console.WriteLine("is a file")
        'ElseIf sourcePathAttribute.HasFlag(FileSystemObject.Directory) Then
        '    Console.WriteLine("is a directory")
        '    Console.WriteLine("total bytes: " & CalculateBytes(GetDirectorySize("X:\TestCompression\Comparison")))
        'End If


        'ShowDetails(True)

        'compressor = New CompressFile
        'decompressor = New DecompressFile
        'Console.WriteLine(compressor.BinaryToByte("01000001"))
        'Console.WriteLine(decompressor.ByteToBinary(130))

        'Dim bytes() As Byte = {BinaryToByte("01000001")}

        'Dim bin As New BitArray(bytes)
        'Console.WriteLine("Bin count: " & bin.Count)
        'For i As Integer = bin.Count - 1 To 0 Step -1
        '    If bin(i) Then
        '        Console.Write("1")
        '    Else
        '        Console.Write("0")
        '    End If
        'Next
        'Console.WriteLine("End")

        'Dim cm As New CompressionManager
        'cm.SingleFileMulti_Async("X:\TestCompression\Testing.mp4", "X:\TestCompression")
        'cm.FileSplitter("X:\TestCompression\download.jpg")
        'cm.FileMerger("X:\TestCompression\Testing (1).spl")


        'Dim dictionaryArray(256, 3) As Object
        'Console.WriteLine("Dictionary Length: " & dictionaryArray.GetLength(0))

        'Dim numArr() As Integer = New Integer(10) {}
        'numArr = New Integer(20) {}


        'Console.WriteLine("Array length: " & numArr.Length)


        'Dim controlCollection As New List(Of DirectoryControl)
        'Console.WriteLine(controlCollection.Count)
        'controlCollection.Add(New DirectoryControl)
        'Console.WriteLine(controlCollection.Count)
        'controlCollection(0).Dispose()
        'Dim p As String = Nothing
        'Console.WriteLine(Directory.Exists(p))
        'Console.WriteLine(controlCollection.Count)

        'Dim Fwriter As New BitStream("C:\Users\Lanz Pancho\Downloads\ABTest Compression\Test.txt", FileMode.Open, FileAccess.Read)

        'Dim bin As String = ""
        'While Fwriter.IsBitAvailable()
        '    If Fwriter.ReadBit() Then
        '        bin += "1"
        '    Else
        '        bin += "0"
        '    End If

        '    If bin.Length = 8 Then
        '        Dim b As Byte = BinaryToByte(bin)
        '        Console.WriteLine(bin & " : " & b & " : " & Convert.ToChar(b))
        '        bin = ""
        '    End If
        'End While

        'Dim b As Byte() = {1, 2}
        'Dim bitA As New BitArray(b)

        'Dim c((8 * b.Length) - 1) As Boolean
        'bitA.CopyTo(c, 0)

        'Dim bin As String = ""
        'Dim sum As Integer = 0
        'For i As Integer = 0 To c.Length - 1

        '    If c(i) Then
        '        bin += "1"
        '    Else
        '        bin += "0"
        '    End If

        '    If bin.Length = 8 Then
        '        Console.WriteLine(bin)
        '        bin = ""
        '    End If

        '    sum += 1

        'Next

        'Console.WriteLine(sum)

        'Dim ctr = 1
        'For i As Integer = 1 To 10

        '    Console.WriteLine(i)

        '    If ctr > 0 Then
        '        If i = 5 Then
        '            i = 0
        '            ctr -= 1
        '        End If
        '    End If

        'Next


        'Dim bBytes(255) As Byte
        ''Console.WriteLine("Length: " & bBytes.Length)
        'For i As Integer = 0 To bBytes.Length - 1
        '    'Console.WriteLine(i)
        '    bBytes(i) = i
        'Next

        'Dim bin As New BitArray(bBytes)
        'Console.WriteLine("bit length: " & bin.Length)

        'Dim binI As Integer = 8

        'Dim ctr As Integer = 0
        'Dim binL As Integer = 7
        'Dim report As String = ""
        'For i As Integer = 0 To bin.Length - 1

        '    Dim index As Integer = (i + binL) - ctr

        '    If bin(index) Then
        '        report += "1"
        '    Else
        '        report += "0"
        '    End If

        '    If report.Length = 8 Then
        '        report += " : " & BinaryToByte(report) & " : " & binI.ToString()
        '        binI += 8
        '        Console.WriteLine(report)
        '        report = ""
        '    End If

        '    If binL = 0 Then
        '        binL = 7
        '        ctr = 0
        '    Else
        '        binL -= 1
        '        ctr += 1
        '    End If
        'Next

        status = "Operation Ready"
        folderStatus = "You can select files to compress or decompress."

        progressStatus = "Waiting for Operation"
        fileStatus = "..."

        StartFileExplorer()

        'Dim q As New Queue(Of String)
        'q.Enqueue("X:\TestCompression\TestFolder")

        'Dim cm As New CompressionManager()
        'cm.MultiFileEncode_Async(q, "Hotdog", "X:\TestCompression\TestFolder")
        'cm.MultiFileDecode_Async("X:\TestCompression\TestFolder\Hotdog.huff", "X:\TestCompression\TestFolder\Example")

        'Dim bin As String = "0"
        'Console.WriteLine(bin.Length)

        'X:\TestCompression\TestFolder\TestVideo.mp4
        'Dim userFile As New FileInfo("X:\TestCompression\TestFolder\TestVideo.mp4")
        'Dim totalBytes As Long = userFile.Length
        'Dim halfByte As Long = userFile.Length \ 2

        'Console.WriteLine(halfByte - totalBytes)


        'Console.WriteLine(userFile.DirectoryName)
        'Console.WriteLine(userFile.FullName.Replace(userFile.DirectoryName & "\", ""))

        'Dim fileBytes(halfByte - totalBytes) As Byte
        'Console.WriteLine("array length: " & fileBytes.Length)



        'testing
        'btnProgress.PerformClick()
        'ShowDetails(True)
        'bwMulti.RunWorkerAsync()
        'TabControl1.SelectedTab = tbReport
    End Sub

    Private Function BinaryToByte(ByVal binary As String) As Byte
        Return (Val(binary(7)) * (2 ^ 0)) + (Val(binary(6)) * (2 ^ 1)) + (Val(binary(5)) * (2 ^ 2)) + (Val(binary(4)) * (2 ^ 3)) + (Val(binary(3)) * (2 ^ 4)) + (Val(binary(2)) * (2 ^ 5)) + (Val(binary(1)) * (2 ^ 6)) + (Val(binary(0)) * (2 ^ 7))
    End Function

    Public Function CalculateBytes(ByVal totalbyte As Long) As String

        Dim ctr As Integer = 0
        Dim sizeTerm As String() = {"B", "KB", "MB", "GB", "TB", "PB"}
        Dim size As Double = Convert.ToDouble(totalbyte)

        While size > 1024
            size /= 1024
            ctr += 1
        End While

        If ctr > 5 Then
            ctr = 5
        End If

        If size = Int(size) Then
            Return size.ToString() & " " & sizeTerm(ctr)
        Else
            Return size.ToString("F2") & " " & sizeTerm(ctr)
        End If

    End Function

    Private Sub Splitter1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles Splitter1.SplitterMoved
        UpdateSplitterPosition()
    End Sub

    Private Sub Splitter2_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles Splitter2.SplitterMoved
        UpdateSplitterPosition()
    End Sub

    Private Sub Splitter3_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles Splitter3.SplitterMoved
        UpdateSplitterPosition()
    End Sub

    Private Sub UpdateSplitterPosition()

        For Each control As DirectoryControl In flpFileDirectory.Controls

            control.pnlName.Width = Me.pnlName.Width + 1
            control.pnlSize.Width = Me.pnlSize.Width + 1
            control.pnlType.Width = Me.pnlType.Width + 1
            control.pnlDate.Width = Me.pnlDate.Width + 1

        Next

    End Sub

    Dim isDrag As Boolean = False
    Dim cursorPos As Point
    Private Sub pnlNavigation_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlNavigation.MouseDown
        isDrag = True
        cursorPos = New Point(e.X, e.Y)
    End Sub

    Private Sub pnlNavigation_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlNavigation.MouseUp
        isDrag = False
        cursorPos = Nothing
    End Sub

    Private Sub pnlNavigation_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlNavigation.MouseMove
        If isDrag Then
            Me.Location = New Point(Me.Location.X + e.X - cursorPos.X, Me.Location.Y + e.Y - cursorPos.Y)
        End If
    End Sub

    Private Sub btnExplorer_Click(sender As Object, e As EventArgs) Handles btnExplorer.Click
        TabControl1.SelectedTab = tbMain
    End Sub

    Private Sub btnStatus_Click(sender As Object, e As EventArgs) Handles btnProgress.Click
        'TabControl1.SelectedTab = tbProcess
        If isProcessing Then
            TabControl1.SelectedTab = tbProcess
        Else
            TabControl1.SelectedTab = tbReport
        End If
    End Sub

    Public isMultiselect As Boolean = False

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.ControlKey Then
            isMultiselect = True
        End If
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        isMultiselect = False
    End Sub

    Public Sub RemoveSelectedControls()
        For Each c As DirectoryControl In selectedControls
            c.Unselect()
        Next
        selectedControls.Clear()
    End Sub

    Private Sub btnSortName_Click(sender As Object, e As EventArgs) Handles btnSortName.Click

        For Each c As DirectoryControl In dirControlCollection
            With c
                Dim sum As Integer = 0
                For j As Integer = 0 To c.filepath.Length - 1
                    sum += Asc(c.filepath(j))
                Next
                .nameSum = sum
            End With
        Next

        If btnSortName.Checked Then
            'action
            SortControlsBy(0)
            dirControlCollection.Reverse()

            'pnlName.BackColor = Color.FromArgb(250, 250, 250)
            'Panel2.BackColor = Color.FromArgb(250, 250, 250)

            btnSortSize.Checked = False
            btnSortType.Checked = False
            btnSortDate.Checked = False
        Else
            SortControlsBy(0)

            'pnlName.BackColor = Color.FromArgb(255, 255, 255)
            'Panel2.BackColor = Color.FromArgb(255, 255, 255)
        End If

        RefreshControls()

    End Sub

    Private Sub btnSortSize_Click(sender As Object, e As EventArgs) Handles btnSortSize.Click

        If btnSortSize.Checked Then

            SortControlsBy(1)

            btnSortName.Checked = False
            btnSortType.Checked = False
            btnSortDate.Checked = False

            'action
        Else
            SortControlsBy(0)
        End If

        RefreshControls()

    End Sub

    Private Sub btnSortType_Click(sender As Object, e As EventArgs) Handles btnSortType.Click

        For Each c As DirectoryControl In dirControlCollection
            With c
                Dim sum As Integer = 0
                For j As Integer = 0 To c.type.Length - 1
                    sum += Asc(c.type(j))
                Next
                .typeSum = sum
            End With
        Next

        If btnSortType.Checked Then

            SortControlsBy(2)

            btnSortName.Checked = False
            btnSortSize.Checked = False
            btnSortDate.Checked = False

            'action
        Else
            SortControlsBy(0)
        End If

        RefreshControls()

    End Sub

    Private Sub btnSortDate_Click(sender As Object, e As EventArgs) Handles btnSortDate.Click

        If btnSortDate.Checked Then

            SortControlsBy(3)

            btnSortName.Checked = False
            btnSortSize.Checked = False
            btnSortType.Checked = False

            'action
        Else
            SortControlsBy(0)
        End If

        RefreshControls()

    End Sub

    Private Sub StartFileExplorer()

        Dim drives As String() = Directory.GetLogicalDrives()

        For Each drive As String In drives
            cbDrives.Items.Add(drive)
        Next

        If cbDrives.Items.Count > 0 Then
            cbDrives.SelectedIndex = 0
        End If

        pageView = 0

        btnPageStart.Enabled = False
        btnPagePrev.Enabled = False
        btnPageNext.Enabled = True
        btnPageEnd.Enabled = True

        LoadDirectories(cbDrives.SelectedItem.ToString)

    End Sub

    'pathnode means view the files and directories inside compressed files.
    Private Sub LoadDirectories(ByVal p As PathNode)

        btnSortName.Checked = False
        btnSortSize.Checked = False
        btnSortType.Checked = False
        btnSortDate.Checked = False

        If cRootNode IsNot Nothing Then

            'For i As Integer = dirControlCollection.Count - 1 To 0 Step -1
            '    dirControlCollection(i).Dispose()
            '    dirControlCollection(i) = Nothing
            'Next

            For i As Integer = flpFileDirectory.Controls.Count - 1 To 0 Step -1
                flpFileDirectory.Controls(i).Dispose()
            Next
            dirControlCollection.Clear()


            Dim totalpath As Integer = p.GetList().Count

            Console.WriteLine("total path of compressed file: " & totalpath)
            Dim currentPathcount As Integer = 0

            Dim startView As Integer = pageView * controlsToView
            Dim endView As Integer = startView + controlsToView

            If totalpath <= controlsToView Then
                btnPageStart.Visible = False
                btnPagePrev.Visible = False
                btnPageNext.Visible = False
                btnPageEnd.Visible = False
            Else
                btnPageStart.Visible = True
                btnPagePrev.Visible = True
                btnPageNext.Visible = True
                btnPageEnd.Visible = True
            End If

            For Each np As PathNode In p.GetList()

                If Not (currentPathcount >= startView And currentPathcount < endView) Then
                    currentPathcount += 1
                    Continue For
                End If

                'Console.WriteLine(np.GetName())

                Dim dc As New DirectoryControl
                With dc
                    .Margin = New Padding(0, 0, 0, 0)
                    .isCompressedDirectory = True
                    .currentP = np
                    .fileSize = np.GetFileSize()
                    .dateDiff = 0

                    .lblName.Text = np.GetName()
                    .lblDate.Text = ""

                    If np.IsNodeFile() Then
                        .btnSelect.Image = My.Resources.document_48px

                        Dim filename As String = np.GetName()
                        Dim extsn As String = Nothing
                        For i As Integer = filename.Length - 1 To 0 Step -1
                            If filename(i) = "." Then
                                Exit For
                            End If
                            extsn += filename(i)
                        Next

                        If Not String.IsNullOrWhiteSpace(extsn) Then
                            Dim fext As String = Nothing
                            For i As Integer = extsn.Length - 1 To 0 Step -1
                                fext += extsn(i)
                            Next
                            fext = fext.ToUpper()

                            .type = fext & " File"
                            .lblType.Text = fext & " File"
                        Else
                            .type = "File"
                            .lblType.Text = "File"
                        End If


                        .lblSize.Text = CalculateBytes(np.GetFileSize())
                    Else
                        .btnSelect.Image = My.Resources.folder_48px
                        .type = "File Folder"
                        .lblType.Text = "File Folder"
                        .lblSize.Text = ""
                    End If

                End With

                dirControlCollection.Add(dc)
                flpFileDirectory.Controls.Add(dc)

                currentPathcount += 1
            Next

        End If

    End Sub

    Dim pageView As Integer = 0
    Dim controlsToView As Integer = 20

    Private Sub LoadDirectories(ByVal path As String)

        Console.WriteLine("directory counter: " & dirControlCollection.Count)
        Console.WriteLine("selected directory counter: " & selectedControls.Count)

        btnSortName.Checked = False
        btnSortSize.Checked = False
        btnSortType.Checked = False
        btnSortDate.Checked = False

        'tinago na flowlayout para mabilis mag load ang controls na ilalagay 
        Me.flpFileDirectory.Visible = False

        'clearing the controls in the flowlayout
        For i As Integer = flpFileDirectory.Controls.Count - 1 To 0 Step -1
            flpFileDirectory.Controls(i).Dispose()
        Next
        'flpFileDirectory.Controls.Clear()

        'clearing the controls in the dirControlCollection
        For i As Integer = dirControlCollection.Count - 1 To 0 Step -1
            dirControlCollection(i).Dispose()
        Next

        dirControlCollection = New List(Of DirectoryControl)
        'dirControlCollection.Clear()

        'For i As Integer = selectedControls.Count - 1 To 0 Step -1
        '    selectedControls(i).Dispose()
        'Next
        'selectedControls.Clear()

        'checks kung ang path naten ay merong parent directory, para pwede mag back
        If path.Split("\").Length = 2 Then
            btnBack.Enabled = True
        End If

        currentDir = path
        txtPath.Text = path

        Dim dir As New DirectoryInfo(path)
        Dim fileInfo As FileSystemInfo


        Dim totalpath As Integer = dir.GetFileSystemInfos.Count
        lastCurrentPathCount = totalpath

        Dim currentPathcount As Integer = 0

        Dim startView As Integer = pageView * controlsToView
        Dim endView As Integer = startView + controlsToView


        If totalpath <= controlsToView Then
            btnPageStart.Visible = False
            btnPagePrev.Visible = False
            btnPageNext.Visible = False
            btnPageEnd.Visible = False
        Else
            btnPageStart.Visible = True
            btnPagePrev.Visible = True
            btnPageNext.Visible = True
            btnPageEnd.Visible = True
        End If

        For Each fileInfo In dir.GetFileSystemInfos

            'Dito mo lagay ung sa next previous feature para di nag ka-crash ung system
            'Here

            If Not (currentPathcount >= startView And currentPathcount < endView) Then
                currentPathcount += 1
                Continue For
            End If

            '=================


            Dim fAttribute As FileAttribute = File.GetAttributes(fileInfo.FullName)

            If fAttribute.HasFlag(FileAttribute.Hidden) Then
                Continue For
            End If

            Dim p As New DirectoryControl
            With p
                .Margin = New Padding(0, 0, 0, 0)
                .filepath = fileInfo.FullName

                Dim filename As String = System.IO.Path.GetFileNameWithoutExtension(fileInfo.Name)
                If String.IsNullOrWhiteSpace(filename) Then
                    filename = fileInfo.Name
                End If


                Dim filesize As Long
                Dim fileextsn As String = Nothing
                'the path is a file
                If Not fAttribute.HasFlag(FileAttribute.Directory) And Not fAttribute.HasFlag(FileAttribute.Hidden) Then

                    Dim fi As New FileInfo(fileInfo.FullName)

                    .isFolder = False
                    filesize = fi.Length
                    .lblSize.Text = CalculateBytes(filesize)

                    fileextsn = fileInfo.Extension.Replace(".", "").ToUpper() & " File"
                    .btnSelect.Image = My.Resources.document_48px

                    Try

                        Dim encMode As Integer = -1
                        'retrive the file mode.
                        Using Freader As New FileStream(fi.FullName, FileMode.Open, FileAccess.Read)
                            Dim encodingType(0) As Byte
                            Freader.Read(encodingType, 0, encodingType.Length)
                            encMode = encodingType(0)
                        End Using

                        Console.WriteLine("EncMode: " & encMode)

                        If fileInfo.Extension = ".huff" Then
                            .isFileDecompressable = True
                        End If

                        If encMode = 1 Or encMode = 3 Then
                            .isMultipleFiles = True
                            .btnSelect.Image = My.Resources.archive_folder_48px
                        End If

                    Catch ex As Exception
                        'when it returns an exception a file is currently using it is because of a realtime checking for the updation of files/directories
                        Console.WriteLine(ex.Message & vbCrLf & " File is currently using.")
                    End Try


                    'Dim extsn As String = fi.Extension.Replace(".", "").ToLower()
                    'If extsn = "bonk" Or extsn = "rawr" Then
                    '    .isFileDecompressable = True
                    '    .btnSelect.Image = My.Resources.archive_folder_48px
                    'End If

                    'If extsn = "bonk" Then
                    '    .isMultipleFiles = True
                    'End If

                ElseIf fAttribute.HasFlag(FileAttribute.Directory) Then
                    .isFolder = True
                    fileextsn = "File Folder"
                    filesize = 0
                    .lblSize.Text = ""
                End If

                p.fileSize = filesize


                .dateDiff = (DateTime.Now - fileInfo.LastAccessTime).Days
                'Console.WriteLine(Format(DateTime.Now, "MM/dd/yyyy hh:mm tt") & " " & Format(fileInfo.LastAccessTime, "MM/dd/yyyy hh:mm tt") & " Days Diff =: " & .dateDiff)

                .lblName.Text = filename

                .type = fileextsn
                .lblType.Text = fileextsn
                .lblDate.Text = Format(fileInfo.LastAccessTime, "MM/dd/yyyy hh:mm tt")
            End With

            dirControlCollection.Add(p)
            flpFileDirectory.Controls.Add(p)

            currentPathcount += 1
            'lblLoadingStatus.Text = currentPathcount.ToString() & " out of " & totalpath.ToString() & " completed."
        Next

        Me.flpFileDirectory.Visible = True

        Console.WriteLine("Path count: " & currentPathcount)
        Console.WriteLine("Total Path count: " & totalpath)
        Console.WriteLine("Total displayed controls: " & flpFileDirectory.Controls.Count)
        Console.WriteLine("Current pageView: " & pageView)
        Console.WriteLine()

    End Sub


    Private Sub SortControlsBy(ByVal state As Integer)

        '0 = Name sort
        '1 = Size Sort
        '2 = Type Sort
        '3 = Date Sort

        Dim swapCount As Integer = 0

        While True

            For i As Integer = 0 To dirControlCollection.Count - 2

                Dim Felement As DirectoryControl = dirControlCollection(i)
                Dim Selement As DirectoryControl = dirControlCollection(i + 1)

                Dim isSwappable As Boolean = False

                If state = 0 Then
                    If Selement.nameSum < Felement.nameSum Then
                        isSwappable = True
                    End If
                ElseIf state = 1 Then
                    If Selement.fileSize < Felement.fileSize Then
                        isSwappable = True
                    End If
                ElseIf state = 2 Then
                    If Selement.typeSum < Felement.typeSum Then
                        isSwappable = True
                    End If
                ElseIf state = 3 Then
                    If Selement.dateDiff < Felement.dateDiff Then
                        isSwappable = True
                    End If
                End If

                If isSwappable Then
                    dirControlCollection(i) = Selement
                    dirControlCollection(i + 1) = Felement
                    swapCount += 1
                End If

            Next

            If swapCount = 0 Then
                Return
            Else
                swapCount = 0
            End If

        End While

    End Sub

    Private Sub RefreshControls()

        If flpFileDirectory.Controls.Count > 0 Then
            For i As Integer = flpFileDirectory.Controls.Count - 1 To 0 Step -1
                flpFileDirectory.Controls.RemoveAt(i)
            Next
        End If

        flpFileDirectory.Controls.Clear()
        For Each c As DirectoryControl In dirControlCollection
            flpFileDirectory.Controls.Add(c)
        Next

    End Sub

    Public Sub Redirectory()

        pageView = 0

        btnPageStart.Enabled = False
        btnPagePrev.Enabled = False
        btnPageNext.Enabled = True
        btnPageEnd.Enabled = True

        LoadDirectories(currentDir)
    End Sub

    Public Sub ReDirectory(ByVal p As PathNode)

        pageView = 0

        btnPageStart.Enabled = False
        btnPagePrev.Enabled = False
        btnPageNext.Enabled = True
        btnPageEnd.Enabled = True

        currentPNode = p
        LoadDirectories(p)
    End Sub

    Public Sub ReDirectory(ByVal path As String)

        pageView = 0

        btnPageStart.Enabled = False
        btnPagePrev.Enabled = False
        btnPageNext.Enabled = True
        btnPageEnd.Enabled = True

        LoadDirectories(path)
    End Sub

    Private Sub cbDrives_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDrives.SelectedIndexChanged
        pageView = 0
        LoadDirectories(cbDrives.SelectedItem.ToString)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

        'Viewing the directories and files of a compressed file
        If cRootNode IsNot Nothing AndAlso Not cRootNode.Equals(currentPNode) Then
            Dim pNode As PathNode = currentPNode.GetParent()
            If pNode IsNot Nothing Then
                currentPNode = pNode

                'pageViewing
                pageView = 0

                btnPageStart.Enabled = False
                btnPagePrev.Enabled = False
                btnPageNext.Enabled = True
                btnPageEnd.Enabled = True

                LoadDirectories(currentPNode)
                RemoveSelectedControls()
                Console.WriteLine("Selected controls count: " & selectedControls.Count)
            End If
            Return
        Else
            If cRootNode IsNot Nothing And currentPNode IsNot Nothing Then
                cRootNode = Nothing
                currentPNode = Nothing

                pageView = 0

                btnPageStart.Enabled = False
                btnPagePrev.Enabled = False
                btnPageNext.Enabled = True
                btnPageEnd.Enabled = True

                LoadDirectories(currentDir)
                RemoveSelectedControls()
                Return
            End If
        End If

        'redirecting the current path 
        Dim currentPath As String() = currentDir.Split("\")
        Dim newPath As String = Nothing

        While Not Directory.Exists(newPath)

            If newPath IsNot Nothing Then
                currentPath = newPath.Split("\")
                newPath = Nothing
            End If

            Dim revCount As Integer = 0
            For i As Integer = 0 To currentPath.Length - 2
                If i < currentPath.Length - 2 Then
                    newPath += currentPath(i) & "\"
                Else
                    newPath += currentPath(i)
                End If
                revCount += 1
            Next

            If revCount = 1 Then
                newPath += "\"
                btnBack.Enabled = False
            End If

            'System.Threading.Thread.Sleep(2000)
            Console.WriteLine(newPath)
            Console.WriteLine(Directory.Exists(newPath))

        End While

        pageView = 0

        btnPageStart.Enabled = False
        btnPagePrev.Enabled = False
        btnPageNext.Enabled = True
        btnPageEnd.Enabled = True

        LoadDirectories(newPath)
        RemoveSelectedControls()

    End Sub

    Public Sub ResetCompressedDirectory()
        cRootNode = Nothing
        currentPNode = Nothing
    End Sub

    Private Sub DesktopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesktopToolStripMenuItem.Click
        ReDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
        ResetCompressedDirectory()
    End Sub

    Private Sub DocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentToolStripMenuItem.Click
        ReDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
        ResetCompressedDirectory()
    End Sub

    Private Sub DownloadsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadsToolStripMenuItem.Click
        Dim dFolder As String = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal))
        dFolder = Path.Combine(dFolder, "Downloads")
        ReDirectory(dFolder)
        ResetCompressedDirectory()
    End Sub

    Private Sub MusicToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MusicToolStripMenuItem.Click
        ReDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic))
        ResetCompressedDirectory()
    End Sub

    Private Sub PicturesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PicturesToolStripMenuItem.Click
        ReDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
        ResetCompressedDirectory()
    End Sub

    Private Sub VideosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VideosToolStripMenuItem.Click
        ReDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos))
        ResetCompressedDirectory()
    End Sub

    Private Sub txtPath_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPath.KeyDown
        If e.KeyCode = Keys.Return Then

            If Directory.Exists(txtPath.Text) Then
                LoadDirectories(txtPath.Text)
            Else
                If File.Exists(txtPath.Text) Then
                    Dim fi As New FileInfo(txtPath.Text)
                    LoadDirectories(fi.DirectoryName)
                Else
                    MsgBox("Path does not exist.", vbCritical, "Invalid action")
                    txtPath.Text = currentDir
                End If
            End If

        End If
    End Sub

    Dim isMultiThreadCompression As Boolean = True
    Dim mtSourcePath As String = Nothing
    Dim mtOutputPath As String = Nothing
    Dim isSingleFile As Boolean = True
    Dim outPutFileName As String = Nothing
    Dim mtSourcelength As Long = 0
    'fileQ for the compression
    Dim fileQ As New Queue(Of String)

    Private Sub btnBonk_Click(sender As Object, e As EventArgs) Handles btnBonk.Click

        'Currently viewving compressed file
        If cRootNode IsNot Nothing And currentPNode IsNot Nothing Then
            MsgBox("You are currently viewing compressed folder/s and file/s.", vbCritical, "Invalid action")
            Return
        End If

        'If currently processing
        If isProcessing Then
            MsgBox("You are currently in process, Please wait for the process to finish.", vbCritical, "Invalid Action")
            Return
        End If

        cRootNode = Nothing
        currentPNode = Nothing

        If isMultiThread Then

            isMultiThreadCompression = True
            Dim lastuserFile As String = 0
            Dim fcount As Integer = 0

            'clear the fileQ
            fileQ.Clear()

            'pathQ will serve as filteration for counting the fileNumber of the selected files.
            'to determine if it is single file or multifile
            Dim pathQ As New Queue(Of String)
            Dim totalBytesLength As Long = 0
            Dim mselectedFileTotalbyte As Long = 0

            For Each control As DirectoryControl In dirControlCollection
                If Not control.isControlSelected Then
                    Continue For
                End If

                pathQ.Enqueue(control.filepath)
                fileQ.Enqueue(control.filepath)

                If Not control.isFolder Then
                    mselectedFileTotalbyte += New FileInfo(control.filepath).Length
                End If
            Next

            'FOR REPORTING
            If pathQ.Count = 1 Then
                'FOR REPORT
                sourceFile = pathQ.Peek()

                If mselectedFileTotalbyte > 0 Then
                    sourceFile = Directory.GetParent(pathQ.Peek()).FullName

                    sourceFileLength = mselectedFileTotalbyte
                    Dim q2 As New Queue(Of String)(pathQ)
                    While q2.Count > 0

                        Dim userFile As New FileInfo(q2.Dequeue)
                        Dim fattribute As FileAttribute = File.GetAttributes(userFile.FullName)

                        If fattribute.HasFlag(FileAttribute.Hidden) Then
                            Continue While
                        End If

                        If fattribute.HasFlag(FileAttribute.Directory) Then
                            sourceFileLength += GetDirectorySize(userFile.FullName)
                        Else
                            sourceFileLength += userFile.Length
                        End If

                        'Console.WriteLine("Directory name: " & q2.Peek())
                        'sourceFileLength += GetDirectorySize(q2.Dequeue)
                    End While

                    isSourceStrict = True
                End If
            ElseIf pathQ.Count > 1 Then
                sourceFile = Directory.GetParent(pathQ.Peek()).FullName

                sourceFileLength = mselectedFileTotalbyte
                Dim q2 As New Queue(Of String)(pathQ)
                While q2.Count > 0

                    Dim userFile As New FileInfo(q2.Dequeue)
                    Dim fattribute As FileAttribute = File.GetAttributes(userFile.FullName)

                    If fattribute.HasFlag(FileAttribute.Hidden) Then
                        Continue While
                    End If

                    If fattribute.HasFlag(FileAttribute.Directory) Then
                        sourceFileLength += GetDirectorySize(userFile.FullName)
                    Else
                        sourceFileLength += userFile.Length
                    End If

                    'Console.WriteLine("Directory name: " & q2.Peek())
                    'sourceFileLength += GetDirectorySize(q2.Dequeue)
                End While

                isSourceStrict = True
            End If

            'filteration
            While pathQ.Count > 0

                Dim userFile As New FileInfo(pathQ.Dequeue)
                Dim fattribute As FileAttribute = File.GetAttributes(userFile.FullName)

                If fattribute.HasFlag(FileAttribute.Hidden) Then
                    Continue While
                End If

                If fattribute.HasFlag(FileAttribute.Directory) Then
                    Dim dirInfo As New DirectoryInfo(userFile.FullName)

                    For Each fInfo As FileSystemInfo In dirInfo.GetFileSystemInfos
                        pathQ.Enqueue(fInfo.FullName)
                    Next
                Else
                    totalBytesLength += userFile.Length
                    lastuserFile = userFile.FullName
                    fcount += 1
                End If

            End While

            If fcount = 1 Then

                isSingleFile = True
                'run the background worker
                mtSourcePath = lastuserFile
                mtSourcelength = totalBytesLength

                FolderBrowserDialog1.Description = "Choose a destination folder, this is where the compressed files go."
                Dim r As DialogResult = FolderBrowserDialog1.ShowDialog()

                If r = DialogResult.OK Then
                    mtOutputPath = FolderBrowserDialog1.SelectedPath

                    lblThreadType.Text = "Single-File, Multi-Thread"
                    ShowDetails(True)

                    'FOR REPORT
                    sourceFile = lastuserFile

                    'PROCESS MODE 
                    processMode = True
                    processType = True
                    packageType = False

                    'Asynchronous work
                    isProcessing = True
                    btnProgress.PerformClick()
                    bwMulti.RunWorkerAsync()
                End If
            ElseIf fcount > 1 Then

                isSingleFile = False
                'multifile
                mtSourcePath = New FileInfo(fileQ.Peek()).DirectoryName
                mtSourcelength = totalBytesLength

                FolderBrowserDialog1.Description = "Choose a destination folder, this is where the compressed files go."
                Dim r As DialogResult = FolderBrowserDialog1.ShowDialog()

                If r = DialogResult.OK Then
                    mtOutputPath = FolderBrowserDialog1.SelectedPath


                    While True
                        Dim suggestedName As String = InputBox("Enter a file name.", "Output File Name", "")
                        If Not String.IsNullOrWhiteSpace(suggestedName) Then
                            'checks for prohibited chars
                            Dim prohibitedChars As String = "\/:*?""<>|."

                            Dim isProhibited As Boolean = False
                            For i As Integer = 0 To prohibitedChars.Length - 1
                                If suggestedName.Contains(prohibitedChars(i)) Then
                                    isProhibited = True
                                    Exit For
                                End If
                            Next

                            If Not isProhibited Then
                                outPutFileName = suggestedName
                                Exit While
                            End If

                        Else
                            Console.WriteLine("Whitespace")
                            Return
                        End If

                        MsgBox("File name should not blank, or having special characters like: \/:*?""<>|.", vbOK, "Invalid File Name")
                    End While

                    lblThreadType.Text = "Multi-File, Multi-Thread"
                    ShowDetails(True)

                    'PROCESS MODE 
                    processMode = True
                    processType = True
                    packageType = True

                    'Asynchronous work
                    isProcessing = True
                    btnProgress.PerformClick()
                    bwMulti.RunWorkerAsync()
                End If

            ElseIf fcount = 0 Then
                MsgBox("Please select a file or a folder.", vbCritical, "Invalid Action")
            End If

            'end method
            Return
        End If



        'Single Thread Approach Below
        Dim FilePaths As New List(Of String)
        Dim pathSize As New List(Of Long)
        Dim q As New Queue(Of String)

        Dim lastFilePath As String = Nothing
        Dim fileCount As Integer = 0
        Dim selectedFileTotalByte As Long = 0

        For Each control As DirectoryControl In dirControlCollection

            If Not control.isControlSelected Then
                Continue For
            End If

            If control.isFolder Then
                q.Enqueue(control.filepath)
            Else
                lastFilePath = control.filepath
                FilePaths.Add(control.filepath)
                pathSize.Add(New FileInfo(control.filepath).Length)
                fileCount += 1

                Dim fileFI As New FileInfo(control.filepath)
                selectedFileTotalByte += fileFI.Length
            End If

        Next

        If q.Count = 1 Then
            'FOR REPORT
            sourceFile = q.Peek()

            If selectedFileTotalByte > 0 Then
                sourceFile = Directory.GetParent(q.Peek()).FullName

                sourceFileLength = selectedFileTotalByte
                Dim q2 As New Queue(Of String)(q)
                While q2.Count > 0
                    sourceFileLength += GetDirectorySize(q2.Dequeue)
                End While

                isSourceStrict = True
            End If
        ElseIf q.Count > 1 Then
            sourceFile = Directory.GetParent(q.Peek()).FullName

            sourceFileLength = selectedFileTotalByte
            Dim q2 As New Queue(Of String)(q)
            While q2.Count > 0
                sourceFileLength += GetDirectorySize(q2.Dequeue)
            End While

            isSourceStrict = True
        End If

        While q.Count > 0

            Dim dirPath As String = q.Dequeue()
            FilePaths.Add(dirPath)

            Dim dirInfo As New DirectoryInfo(dirPath)
            Dim fileInfo As FileSystemInfo

            For Each fileInfo In dirInfo.GetFileSystemInfos
                Dim atbute As FileAttribute = File.GetAttributes(fileInfo.FullName)

                If atbute.HasFlag(FileAttribute.Hidden) Then
                    Continue For
                End If

                If atbute.HasFlag(FileAttribute.Directory) Then
                    q.Enqueue(fileInfo.FullName)
                Else
                    lastFilePath = fileInfo.FullName
                    FilePaths.Add(fileInfo.FullName)
                    pathSize.Add(New FileInfo(fileInfo.FullName).Length)
                    fileCount += 1
                End If
            Next

        End While

        Console.WriteLine("File counter: " & fileCount)

        If fileCount = 0 Then
            MsgBox("Please select a folder or a file.", vbCritical, "Invalid Action")
            Return
        End If

        FolderBrowserDialog1.Description = "Choose a destination folder, this is where the compressed files go."
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()

        If result = DialogResult.OK Then

            Dim destinationP As String = FolderBrowserDialog1.SelectedPath

            'Console.WriteLine(destinationP)

            If fileCount > 1 Then

                Console.WriteLine("multiple")

                Dim pathName As String = InputBox("Enter a file name.", "Output File Name", "")

                If Not String.IsNullOrWhiteSpace(pathName) Then

                    Dim prohibitedChars As String = "\/:*?""<>|"

                    Dim isProhibited As Boolean = False
                    For i As Integer = 0 To prohibitedChars.Length - 1
                        If pathName.Contains(prohibitedChars(i)) Then
                            isProhibited = True
                            Exit For
                        End If
                    Next

                    If Not isProhibited Then
                        lblThreadType.Text = "Multi-File, Single-Thread"

                        'PROCESS MODE 
                        processMode = True
                        processType = False
                        packageType = True

                        compressor.AssignData(destinationP, pathName, currentDir, FilePaths, pathSize, True)
                    Else
                        MsgBox("A file name cannot contain any of the following characters:" & vbCrLf & "\ / : * ? "" < > |", vbCritical, "Invalid action")
                        Return
                    End If

                Else
                    Console.WriteLine("Whitespace")
                    Return
                End If

            ElseIf fileCount = 1 Then
                Console.WriteLine("single")
                lblThreadType.Text = "Single-File, Single-Thread"

                'FOR REPORT
                sourceFile = lastFilePath

                'PROCESS MODE 
                processMode = True
                processType = False
                packageType = False

                compressor.AssignData(destinationP, lastFilePath, False)
                Console.WriteLine(lastFilePath)
            End If

            ShowDetails(True)

            isProcessing = True
            isCompressing = True
            btnProgress.PerformClick()
            BackgroundWorker1.RunWorkerAsync()

        End If


    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        compressor.SetIgnore(isIgnore) 'for ignore warnings

        If isCompressing Then

            'If isLowRate Then
            '    compressor.DirectCompression()
            '    isLowRate = False
            '    Return
            'End If

            compressor.Start()
        Else

            'untry the decompressor to identify the error for debugging
            Try
                decompressor.Start()
            Catch ex As Exception
                Console.WriteLine(ex.Message & vbCrLf & ex.StackTrace)
                errorCode = 8
            End Try

        End If

    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        Console.WriteLine("Single thread done.")

        lblLastAvgRead.Text = "Avg Read Speed: " & CalculateBytes(GetTotalReadSpeed() / avgReadSpeed.Count) & "/s"
        lblLastAvgWrite.Text = "Avg Write Speed: " & CalculateBytes(GetTotalWriteSpeed() / avgWriteSpeed.Count) & "/s"

        isProcessing = False

        If errorCode = 1 Then
            MsgBox("File/s cannot be compressed.", vbInformation, "Compression")
        ElseIf errorCode = 5 Or errorCode = 6 Then

            MsgBox("Operation cancelled.", vbInformation, "User Action")

            lblLastAvgRead.Text = "Avg Read Speed: 0b/s"
            lblLastAvgWrite.Text = "Avg Write Speed: 0b/s"
            lblTotalFileSize.Text = "File/s Overall Size: "
            lblLastTimeElapsed.Text = "Elapsed Time: 00:00:00"

            'reset
            pbDone.Image = My.Resources.Checkmark_96px
            ShowDetails(False)

            status = "Operation Ready"
            folderStatus = "You can select files to compress or decompress."

            folderStatus = "You can select files to compress or decompress again."
            progressStatus = "Waiting for Operation"
            fileStatus = "..."
            overAllPercent = 0.0
            processPercent = 0.0

            compressor = New CompressFile
            decompressor = New DecompressFile

            secondsElapsed = 0
            errorCode = 0

            Return

        ElseIf errorCode = 7 Then

            isLowRate = True
            Dim report As String = "File has low compression rate with " & compressor.compressionPercent.ToString("F2") & " %." & vbCrLf &
                                "Estimated Saved size: " & CalculateBytes(compressor.compressionDiff) & vbCrLf &
                                vbCrLf &
                                "Do you want to still compress the file? (Not Recommended)"

            Dim result As MsgBoxResult = MsgBox(report, vbExclamation + vbYesNo, "Low Compression Rate")
            If result = MsgBoxResult.Yes Then
                errorCode = 0
                isProcessing = True
                BackgroundWorker1.RunWorkerAsync()
                Return
            End If

        ElseIf errorCode = 8 Then
            MsgBox("Invalid Signature, File is corrupted.", vbCritical, "Invalid Signature")
        End If

        ShowDetails(False)

        If processMode Then
            outputFile = compressor.GetOutputPath()

            'If Not processType Then
            '    outputFile = compressor.GetOutputPath()
            'Else
            '    outputFile = cm.GetOutputPath()
            'End If
        Else
            If isOutputStrict Then
                outputFileLength = decompressor.GetDecodedTotalBytes()
            Else
                outputFile = decompressor.GetOutputPath()
            End If
        End If

        ''SINGLE FILE, SINGLE THREAD, COMPRESSION MODE
        'If Not packageType And Not processType And processMode Then
        '    outputFile = compressor.GetOutputPath()
        'End If

        ''SINGLE FILE, SINGLE THREAD, DECOMPRESSION MODE
        'If Not packageType And Not processType And Not processMode Then
        '    outputFile = decompressor.GetOutputPath()
        'End If

        'REPORT DATA
        ReportData()
        TabControl1.SelectedTab = tbReport

        pbDone.Image = My.Resources.Checkmark_96px

        If isCompressing Then
            status = "Compression finished successfully!"
            lblTotalFileSize.Text = "File/s Overall Size: " & CalculateBytes(compressor.GetTotalByteOfRawFiles())
        Else
            status = "Decompression finished successfully!"
            lblTotalFileSize.Text = "File/s Overall Size (Compressed): " & CalculateBytes(decompressor.GetTotalByteOfRawFiles())
        End If

        isCompressing = True

        folderStatus = "You can select files to compress or decompress again."
        progressStatus = "Waiting for Operation"
        fileStatus = "..."
        overAllPercent = 0.0
        processPercent = 0.0

        secondsElapsed = 0
        errorCode = 0

        compressor = New CompressFile
        decompressor = New DecompressFile

        isSourceStrict = False
        isOutputStrict = False

        ReDirectory(currentDir)
        'btnExplorer.PerformClick()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles tmProgress.Tick

        'reporter
        lblFolderStatus.Text = folderStatus
        lblFileStatus.Text = fileStatus

        lblStatus.Text = status
        lblProcessedStatus.Text = progressStatus

        lblOverallPercent.Text = overAllPercent.ToString("F1") & " %"
        lblProcessPercent.Text = processPercent.ToString("F1") & " %"

        Try
            pbOverall.Value = Convert.ToInt32(Math.Round(overAllPercent, 1) * 100)
            pbProcessed.Value = Convert.ToInt32(Math.Round(processPercent, 1) * 100)
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace & vbCrLf & ex.Message)
        End Try

    End Sub


    Dim currentPercent As Double = 0.0
    Dim secondsElapsed As Long = 0

    Dim avgReadSpeed As New List(Of Long)
    Dim avgWriteSpeed As New List(Of Long)

    Dim lastCurrentPathCount As Integer = 0
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        'Console.WriteLine("Lsat currentDirectory count: " & lastCurrentPathCount)
        'Dim dir As New DirectoryInfo(currentDir)
        'If lastCurrentPathCount <> dir.GetFileSystemInfos.Count Then
        '    Redirectory()
        'End If



        'If decompressor.isBitStreaming Then
        '    lblReadSpeed.Text = "Read Speed: " & CalculateBytes(decompressor.GetBitReadSpeed()) & "/s"
        'Else
        '    lblReadSpeed.Text = "Read Speed: " & CalculateBytes(readSpeed) & "/s"
        'End If

        lblReadSpeed.Text = "Read Speed: " & CalculateBytes(readSpeed) & "/s"
        lblWriteSpeed.Text = "Write Speed: " & CalculateBytes(writeSpeed) & "/s"

        If isProcessing Then

            Dim remPercent As Double = 100.0 - overAllPercent
            Dim speed As Double = overAllPercent - currentPercent
            currentPercent = overAllPercent

            Dim secondRemaining As Long = 0
            If speed = 0 Then
                speed = 1
            End If

            secondRemaining = remPercent / speed
            lblTimeRemaining.Text = "Time Remaining: " & ConvertSecToTime(secondRemaining)
            lblElapsedTime.Text = "Elapsed Time: " & ConvertSecToTime(secondsElapsed)

            lblLastTimeElapsed.Text = "Elapsed Time: " & ConvertSecToTime(secondsElapsed)
            secondsElapsed += 1
        End If

        Dim avgInterval As Integer = 10
        If avgReadSpeed.Count > avgInterval Then
            avgReadSpeed.RemoveAt(0)
        End If

        If avgWriteSpeed.Count > avgInterval Then
            avgWriteSpeed.RemoveAt(0)
        End If

        'If decompressor.isBitStreaming Then
        '    avgReadSpeed.Add(decompressor.GetBitReadSpeed())
        'Else
        '    avgReadSpeed.Add(readSpeed)
        'End If

        avgReadSpeed.Add(readSpeed)
        avgWriteSpeed.Add(writeSpeed)

        lblReadAvgSpeed.Text = "Avg Read Speed: " & CalculateBytes(GetTotalReadSpeed() / avgReadSpeed.Count) & "/s"
        lblWriteAvgSpeed.Text = "Avg Write Speed: " & CalculateBytes(GetTotalWriteSpeed() / avgWriteSpeed.Count) & "/s"

        writeSpeed = 0
        readSpeed = 0
    End Sub

    Private Function GetTotalReadSpeed() As Long
        Dim totalReadSpeed As Long = 0
        For i As Integer = 0 To avgReadSpeed.Count - 1
            totalReadSpeed += avgReadSpeed(i)
        Next
        Return totalReadSpeed
    End Function

    Private Function GetTotalWriteSpeed() As Long
        Dim totalWriteSpeed As Long = 0
        For i As Integer = 0 To avgWriteSpeed.Count - 1
            totalWriteSpeed += avgWriteSpeed(i)
        Next
        Return totalWriteSpeed
    End Function

    Private Function ConvertSecToTime(ByVal seconds As Integer) As String

        Dim hour As Integer = Math.Floor(seconds / 3600)
        seconds -= hour * 3600
        Dim min As Integer = Math.Floor(seconds / 60)
        seconds -= min * 60
        Dim sec As Integer = seconds

        Dim time As String = hour.ToString("00") & ":" & min.ToString("00") & ":" & sec.ToString("00")
        Return time

    End Function

    Private Sub btnUnbonk_Click(sender As Object, e As EventArgs) Handles btnUnbonk.Click

        If cRootNode IsNot Nothing And currentPNode IsNot Nothing Then
            MsgBox("You are currently viewing compressed folder/s and file/s.", vbCritical, "Invalid action")
            Return
        End If

        'If currently processing
        If isProcessing Then
            MsgBox("You are currently in process, Please wait for the process to finish.", vbCritical, "Invalid Action")
            Return
        End If

        If selectedControls.Count = 1 Then

            'check if the selected control is a folder, if it is then return.
            If selectedControls(0).isFolder Then
                MsgBox("Please select a file.", vbCritical, "Invalid Action")
                Return
            End If

            'checks if the file is a valid .huff file.
            Dim userFile As New FileInfo(selectedControls(0).filepath)
            If Not userFile.Extension.Equals(".huff") Then
                MsgBox("Unsupported file type, file should be (.)huff format.", vbCritical, "Invalid Action")
                Return
            End If

            Dim encMode As Integer = -1
            'retrive the file mode.
            Using Freader As New FileStream(userFile.FullName, FileMode.Open, FileAccess.Read)
                Dim encodingType(0) As Byte
                Freader.Read(encodingType, 0, encodingType.Length)
                encMode = encodingType(0)
            End Using

            If (encMode < 0 Or encMode > 3) Then
                MsgBox("Not Valid .(huff) file.", vbCritical, "Invalid Signature")
                Return
            End If

            Console.WriteLine("EncMode: " & encMode)

            FolderBrowserDialog1.Description = "Choose a destination folder to extract data."
            Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
            Dim outputPath As String = Nothing

            If result = DialogResult.OK Then
                outputPath = FolderBrowserDialog1.SelectedPath()

                'FOR REPORT
                sourceFile = userFile.FullName
                outputFile = outputPath

                'single file or multifile  (single thread)
                If encMode = 0 Or encMode = 1 Then

                    Console.WriteLine("Single mode")

                    Console.WriteLine("output file: " & outputFile)

                    If encMode = 0 Then
                        lblThreadType.Text = "Single-File, Single Thread"
                        packageType = False
                    ElseIf encMode = 1 Then
                        lblThreadType.Text = "Multi-File, Single Thread"
                        packageType = True
                        isOutputStrict = True
                    End If

                    ShowDetails(True)
                    decompressor.AssignData(userFile.FullName, outputPath)
                    isProcessing = True
                    isCompressing = False
                    btnProgress.PerformClick()


                    'PROCESS MODE 
                    processMode = False
                    processType = False

                    BackgroundWorker1.RunWorkerAsync()

                    'single file (multi thread)
                ElseIf encMode = 2 Then

                    Console.WriteLine("multi mode")
                    lblThreadType.Text = "Single File, Multi-thread"

                    mtSourcePath = userFile.FullName
                    mtOutputPath = outputPath

                    Console.WriteLine("starting output path:" & outputPath)
                    'Return
                    'isOutputStrict = True

                    isMultiThreadCompression = False
                    isSingleFile = True

                    ShowDetails(True)
                    'Asynchronous work
                    isProcessing = True
                    btnProgress.PerformClick()

                    'PROCESS MODE 
                    processMode = False
                    processType = True
                    packageType = False


                    bwMulti.RunWorkerAsync()

                    'multifile (multi thread)
                ElseIf encMode = 3 Then

                    Console.WriteLine("multi mode")
                    lblThreadType.Text = "Multi-file, Multi-thread"

                    mtSourcePath = userFile.FullName
                    mtOutputPath = outputPath
                    isOutputStrict = True

                    Console.WriteLine("multifile MT isStrict: " & isOutputStrict)

                    isMultiThreadCompression = False
                    isSingleFile = False

                    ShowDetails(True)
                    'Asynchronous work
                    isProcessing = True
                    btnProgress.PerformClick()

                    'PROCESS MODE 
                    processMode = False
                    processType = True
                    packageType = True

                    bwMulti.RunWorkerAsync()
                End If

            End If

        ElseIf selectedControls.Count > 1 Then
            MsgBox("Please select a single file.", vbCritical, "Invalid Action")
        Else
            MsgBox("Please select a file.", vbCritical, "Invalid Action")
        End If


        'If isMultiThread Then
        '    isMultiThreadCompression = False

        '    If selectedControls.Count = 1 Then
        '        Dim userFile As New FileInfo(selectedControls(0).filepath)

        '        If Not userFile.Extension.Equals(".huff") Then
        '            MsgBox("Unsupported file type, file should be (.)huff format.", vbCritical, "Invalid Action")
        '            Return
        '        End If

        '        FolderBrowserDialog1.Description = "Choose a destination folder, this is where the compressed files go."
        '        Dim r As DialogResult = FolderBrowserDialog1.ShowDialog()

        '        If r = DialogResult.OK Then
        '            mtSourcePath = userFile.FullName
        '            mtOutputPath = FolderBrowserDialog1.SelectedPath

        '            Using Freader As New FileStream(userFile.FullName, FileMode.Open, FileAccess.Read)

        '                Dim encodingType(0) As Byte
        '                Freader.Read(encodingType, 0, encodingType.Length)

        '                If encodingType(0) = 2 Then
        '                    isSingleFile = True
        '                ElseIf encodingType(0) = 3 Then
        '                    isSingleFile = False
        '                End If

        '                ''if true Meaning multiFile else SingleFile
        '                'Dim encType As Boolean = BitConverter.ToBoolean(encodingType, 0)

        '                'isSingleFile = Not encType

        '            End Using

        '            ShowDetails(True)
        '            'Asynchronous work
        '            btnProgress.PerformClick()
        '            bwMulti.RunWorkerAsync()
        '        End If

        '    ElseIf selectedControls.Count > 1 Then
        '        MsgBox("Please select a single file.", vbCritical, "Invalid Action")
        '    ElseIf selectedControls.Count = 0 Then
        '        MsgBox("Please select a file.", vbCritical, "Invalid Action")
        '    End If

        '    Return
        'End If


        'If cRootNode IsNot Nothing And currentPNode IsNot Nothing Then
        '    MsgBox("You are currently viewing compressed folder/s and file/s.", vbCritical, "Invalid action")
        '    Return
        'End If

        'If selectedControls.Count = 1 Then

        '    If Not selectedControls(0).isFolder Then

        '        Dim filePath As String = selectedControls(0).filepath
        '        Dim fi As String = New FileInfo(filePath).Extension.Replace(".", "").ToLower()

        '        Dim dPath As String = Nothing
        '        Dim assigned As Boolean = False

        '        If fi = "bonk" Then

        '            Console.WriteLine("multiple file decompressor")
        '            Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        '            If result = DialogResult.OK Then
        '                dPath = FolderBrowserDialog1.SelectedPath()
        '                assigned = True
        '            End If

        '        ElseIf fi = "rawr" Then

        '            Console.WriteLine("single file decompressor")
        '            Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        '            If result = DialogResult.OK Then
        '                dPath = FolderBrowserDialog1.SelectedPath()
        '                assigned = True
        '            End If

        '        Else
        '            MsgBox("Unsupported file type, file should be (.)rawr or (.)bonk format.", vbCritical, "Invalid Action")
        '            Return
        '        End If

        '        If assigned Then
        '            ShowDetails(True)
        '            decompressor.AssignData(filePath, dPath)
        '            btnProgress.PerformClick()
        '            isCompressing = False
        '            BackgroundWorker1.RunWorkerAsync()
        '        End If

        '    Else
        '        MsgBox("Please select a file.", vbCritical, "Invalid Action")
        '    End If

        'ElseIf selectedControls.Count > 1 Then
        '    MsgBox("Please select a single file.", vbCritical, "Invalid Action")
        'Else
        '    MsgBox("Please select a file.", vbCritical, "Invalid Action")
        'End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Dim result As MsgBoxResult = MsgBox("Are you sure to cancel operations? This will result of file ghosts.", vbQuestion + vbYesNo, "Confirming Action")

        If result = MsgBoxResult.Yes Then
            errorCode = 5
        End If

    End Sub

    Private Sub ShowDetails(ByVal status As Boolean)

        If status Then

            lblElapsedTime.Visible = True
            lblTimeRemaining.Visible = True
            Label13.Visible = True
            'lblThreadType.Visible = True
            lblOverallPercent.Visible = True
            pnlLoading.Visible = True
            btnCancel.Visible = True
            pnlProcessDetail.Visible = True
            pnlDetails.Visible = False

        Else

            lblElapsedTime.Visible = False
            lblTimeRemaining.Visible = False
            Label13.Visible = False
            'lblThreadType.Visible = False
            lblOverallPercent.Visible = False
            pnlLoading.Visible = False
            btnCancel.Visible = False
            pnlProcessDetail.Visible = False
            pnlDetails.Visible = True

        End If

    End Sub

    Public Sub BonkFileToCurrentDirectory()

        If cRootNode IsNot Nothing And currentPNode IsNot Nothing Then
            MsgBox("You are currently viewing compressed folder/s and file/s.", vbCritical, "Invalid action")
            Return
        End If

        'If currently processing
        If isProcessing Then
            MsgBox("You are currently in process, Please wait for the process to finish.", vbCritical, "Invalid Action")
            Return
        End If

        Dim destinationP As String = currentDir

        If isMultiThread Then

            isMultiThreadCompression = True
            Dim lastuserFile As String = 0
            Dim fcount As Integer = 0

            'clear the fileQ
            fileQ.Clear()

            'pathQ will serve as filteration for counting the fileNumber of the selected files.
            'to determine if it is single file or multifile
            Dim pathQ As New Queue(Of String)
            Dim totalBytesLength As Long = 0
            Dim mselectedFileTotalbyte As Long = 0

            For Each control As DirectoryControl In dirControlCollection
                If Not control.isControlSelected Then
                    Continue For
                End If

                pathQ.Enqueue(control.filepath)
                fileQ.Enqueue(control.filepath)

                If Not control.isFolder Then
                    mselectedFileTotalbyte += New FileInfo(control.filepath).Length
                End If
            Next

            'FOR REPORTING
            If pathQ.Count = 1 Then
                'FOR REPORT
                sourceFile = pathQ.Peek()

                If mselectedFileTotalbyte > 0 Then
                    sourceFile = Directory.GetParent(pathQ.Peek()).FullName

                    sourceFileLength = mselectedFileTotalbyte
                    Dim q2 As New Queue(Of String)(pathQ)
                    While q2.Count > 0

                        Dim userFile As New FileInfo(q2.Dequeue)
                        Dim fattribute As FileAttribute = File.GetAttributes(userFile.FullName)

                        If fattribute.HasFlag(FileAttribute.Hidden) Then
                            Continue While
                        End If

                        If fattribute.HasFlag(FileAttribute.Directory) Then
                            sourceFileLength += GetDirectorySize(userFile.FullName)
                        Else
                            sourceFileLength += userFile.Length
                        End If

                        'Console.WriteLine("Directory name: " & q2.Peek())
                        'sourceFileLength += GetDirectorySize(q2.Dequeue)
                    End While

                    isSourceStrict = True
                End If
            ElseIf pathQ.Count > 1 Then
                sourceFile = Directory.GetParent(pathQ.Peek()).FullName

                sourceFileLength = mselectedFileTotalbyte
                Dim q2 As New Queue(Of String)(pathQ)
                While q2.Count > 0

                    Dim userFile As New FileInfo(q2.Dequeue)
                    Dim fattribute As FileAttribute = File.GetAttributes(userFile.FullName)

                    If fattribute.HasFlag(FileAttribute.Hidden) Then
                        Continue While
                    End If

                    If fattribute.HasFlag(FileAttribute.Directory) Then
                        sourceFileLength += GetDirectorySize(userFile.FullName)
                    Else
                        sourceFileLength += userFile.Length
                    End If

                    'Console.WriteLine("Directory name: " & q2.Peek())
                    'sourceFileLength += GetDirectorySize(q2.Dequeue)
                End While

                isSourceStrict = True
            End If

            'filteration
            While pathQ.Count > 0

                Dim userFile As New FileInfo(pathQ.Dequeue)
                Dim fattribute As FileAttribute = File.GetAttributes(userFile.FullName)

                If fattribute.HasFlag(FileAttribute.Hidden) Then
                    Continue While
                End If

                If fattribute.HasFlag(FileAttribute.Directory) Then
                    Dim dirInfo As New DirectoryInfo(userFile.FullName)

                    For Each fInfo As FileSystemInfo In dirInfo.GetFileSystemInfos
                        pathQ.Enqueue(fInfo.FullName)
                    Next
                Else
                    totalBytesLength += userFile.Length
                    lastuserFile = userFile.FullName
                    fcount += 1
                End If

            End While

            If fcount = 1 Then

                isSingleFile = True
                'run the background worker
                mtSourcePath = lastuserFile
                mtSourcelength = totalBytesLength
                mtOutputPath = destinationP

                sourceFile = lastuserFile
                ShowDetails(True)

                'PROCESS MODE 
                processMode = True
                processType = True
                packageType = False

                'Asynchronous work
                isProcessing = True
                btnProgress.PerformClick()
                bwMulti.RunWorkerAsync()

            ElseIf fcount > 1 Then

                isSingleFile = False
                'multifile
                mtSourcePath = New FileInfo(fileQ.Peek()).DirectoryName
                mtSourcelength = totalBytesLength
                mtOutputPath = destinationP

                While True
                    Dim suggestedName As String = InputBox("Enter a file name.", "Output File Name", "")
                    If Not String.IsNullOrWhiteSpace(suggestedName) Then
                        'checks for prohibited chars
                        Dim prohibitedChars As String = "\/:*?""<>|."

                        Dim isProhibited As Boolean = False
                        For i As Integer = 0 To prohibitedChars.Length - 1
                            If suggestedName.Contains(prohibitedChars(i)) Then
                                isProhibited = True
                                Exit For
                            End If
                        Next

                        If Not isProhibited Then
                            outPutFileName = suggestedName
                            Exit While
                        End If

                    Else
                        Console.WriteLine("Whitespace")
                        Return
                    End If

                    MsgBox("File name should not blank, or having special characters like: \/:*?""<>|.", vbOK, "Invalid File Name")
                End While

                ShowDetails(True)

                'PROCESS MODE 
                processMode = True
                processType = True
                packageType = True

                'Asynchronous work
                isProcessing = True
                btnProgress.PerformClick()
                bwMulti.RunWorkerAsync()


            ElseIf fcount = 0 Then
                MsgBox("Please select a file or a folder.", vbCritical, "Invalid Action")
            End If

            'end method
            Return
        End If

        'Single Thread approach below

        Dim FilePaths As New List(Of String)
        Dim pathSize As New List(Of Long)
        Dim q As New Queue(Of String)

        Dim lastFilePath As String = ""
        Dim fileCount As Integer = 0
        Dim selectedFileTotalByte As Long = 0

        For Each control As DirectoryControl In dirControlCollection

            If Not control.isControlSelected Then
                Continue For
            End If

            If control.isFolder Then
                q.Enqueue(control.filepath)
            Else
                lastFilePath = control.filepath
                FilePaths.Add(control.filepath)
                pathSize.Add(New FileInfo(control.filepath).Length)
                fileCount += 1

                Dim fileFI As New FileInfo(control.filepath)
                selectedFileTotalByte += fileFI.Length
            End If

        Next

        If q.Count = 1 Then
            'FOR REPORT
            sourceFile = q.Peek()

            If selectedFileTotalByte > 0 Then
                sourceFile = Directory.GetParent(q.Peek()).FullName

                sourceFileLength = selectedFileTotalByte
                Dim q2 As New Queue(Of String)(q)
                While q2.Count > 0
                    sourceFileLength += GetDirectorySize(q2.Dequeue)
                End While

                isSourceStrict = True
            End If
        ElseIf q.Count > 1 Then
            sourceFile = Directory.GetParent(q.Peek()).FullName

            sourceFileLength = selectedFileTotalByte
            Dim q2 As New Queue(Of String)(q)
            While q2.Count > 0
                sourceFileLength += GetDirectorySize(q2.Dequeue)
            End While

            isSourceStrict = True
        End If

        While q.Count > 0

            Dim dirPath As String = q.Dequeue()
            FilePaths.Add(dirPath)

            Dim dirInfo As New DirectoryInfo(dirPath)
            Dim fileInfo As FileSystemInfo

            For Each fileInfo In dirInfo.GetFileSystemInfos
                Dim atbute As FileAttribute = File.GetAttributes(fileInfo.FullName)

                If atbute.HasFlag(FileAttribute.Hidden) Then
                    Continue For
                End If

                If atbute.HasFlag(FileAttribute.Directory) Then
                    q.Enqueue(fileInfo.FullName)
                Else
                    lastFilePath = fileInfo.FullName
                    FilePaths.Add(fileInfo.FullName)
                    pathSize.Add(New FileInfo(fileInfo.FullName).Length)
                    fileCount += 1
                End If
            Next

        End While

        If fileCount > 1 Then

            Console.WriteLine("multiple")

            Dim pathName As String = InputBox("Enter a file name.", "Output File Name", "")
            If Not String.IsNullOrWhiteSpace(pathName) Then

                Dim prohibitedChars As String = "\/:*?""<>|"

                Dim isProhibited As Boolean = False
                For i As Integer = 0 To prohibitedChars.Length - 1
                    If pathName.Contains(prohibitedChars(i)) Then
                        isProhibited = True
                        Exit For
                    End If
                Next

                If Not isProhibited Then

                    'PROCESS MODE 
                    processMode = True
                    processType = False
                    packageType = True

                    compressor.AssignData(destinationP, pathName, currentDir, FilePaths, pathSize, True)
                Else
                    MsgBox("A file name cannot contain any of the following characters:" & vbCrLf & "\ / : * ? "" < > |", vbCritical, "Invalid action")
                    Return
                End If
            Else
                Return
            End If

        ElseIf fileCount = 1 Then
            Console.WriteLine("single")
            Console.WriteLine(lastFilePath)

            'FOR REPORT
            sourceFile = lastFilePath

            Console.WriteLine("Source Path: " & sourceFile)
            Console.WriteLine("Output Path: " & outputFile)

            'PROCESS MODE 
            processMode = True
            processType = False
            packageType = False

            compressor.AssignData(destinationP, lastFilePath, False)
        End If

        ShowDetails(True)
        isProcessing = True
        isCompressing = True
        btnProgress.PerformClick()

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Public Sub UnbonkFileToCurrentDirectory(ByVal sourcePath As String)

        If cRootNode IsNot Nothing And currentPNode IsNot Nothing Then
            MsgBox("You are currently viewing compressed folder/s and file/s.", vbCritical, "Invalid action")
            Return
        End If

        'If currently processing
        If isProcessing Then
            MsgBox("You are currently in process, Please wait for the process to finish.", vbCritical, "Invalid Action")
            Return
        End If

        If selectedControls.Count = 1 Then

            'check if the selected control is a folder, if it is then return.
            If selectedControls(0).isFolder Then
                MsgBox("Please select a file.", vbCritical, "Invalid Action")
                Return
            End If

            'checks if the file is a valid .huff file.
            Dim userFile As New FileInfo(sourcePath)
            If Not userFile.Extension.Equals(".huff") Then
                MsgBox("Unsupported file type, file should be (.)huff format.", vbCritical, "Invalid Action")
                Return
            End If

            Dim encMode As Integer = -1
            'retrive the file mode.
            Using Freader As New FileStream(userFile.FullName, FileMode.Open, FileAccess.Read)
                Dim encodingType(0) As Byte
                Freader.Read(encodingType, 0, encodingType.Length)
                encMode = encodingType(0)
            End Using

            If (encMode < 0 Or encMode > 3) Then
                MsgBox("Not Valid .(huff) file.", vbCritical, "Invalid Signature")
                Return
            End If

            Console.WriteLine("EncMode: " & encMode)

            Dim outputPath As String = userFile.DirectoryName
            'single file or multifile  (single thread)

            'FOR REPORT
            sourceFile = userFile.FullName
            outputFile = outputPath

            If encMode = 0 Or encMode = 1 Then

                Console.WriteLine("Single mode")
                Console.WriteLine("output file: " & outputFile)

                If encMode = 0 Then
                    lblThreadType.Text = "Single-File, Single Thread"
                    packageType = False
                ElseIf encMode = 1 Then
                    lblThreadType.Text = "Multi-File, Single Thread"
                    packageType = True
                    isOutputStrict = True
                End If

                ShowDetails(True)
                decompressor.AssignData(userFile.FullName, outputPath)
                isProcessing = True
                isCompressing = False
                btnProgress.PerformClick()


                'PROCESS MODE 
                processMode = False
                processType = False

                BackgroundWorker1.RunWorkerAsync()

                'single file (multi thread)
            ElseIf encMode = 2 Then

                Console.WriteLine("multi mode")
                lblThreadType.Text = "Single File, Multi-thread"

                mtSourcePath = userFile.FullName
                mtOutputPath = outputPath

                isMultiThreadCompression = False
                isSingleFile = True

                ShowDetails(True)
                'Asynchronous work
                isProcessing = True
                btnProgress.PerformClick()

                'PROCESS MODE 
                processMode = False
                processType = True
                packageType = True


                bwMulti.RunWorkerAsync()

                'multifile (multi thread)
            ElseIf encMode = 3 Then

                Console.WriteLine("multi mode")
                lblThreadType.Text = "Multi-file, Multi-thread"

                mtSourcePath = userFile.FullName
                mtOutputPath = outputPath
                isOutputStrict = True

                isMultiThreadCompression = False
                isSingleFile = False

                ShowDetails(True)
                'Asynchronous work
                isProcessing = True
                btnProgress.PerformClick()

                'PROCESS MODE 
                processMode = False
                processType = True
                packageType = True

                bwMulti.RunWorkerAsync()
            End If

        ElseIf selectedControls.Count > 1 Then
            MsgBox("Please select a single file.", vbCritical, "Invalid Action")
        Else
            MsgBox("Please select a file.", vbCritical, "Invalid Action")
        End If

        'If selectedControls.Count = 1 Then

        '    If Not selectedControls(0).isFolder Then

        '        Dim filePath As String = sourcePath
        '        Dim fi As String = New FileInfo(filePath).Extension.Replace(".", "").ToLower()

        '        Dim dpath As String = currentDir
        '        Dim assigned As Boolean = False

        '        If fi = "bonk" Then
        '            Console.WriteLine("multiple file decompressor")
        '            assigned = True
        '        ElseIf fi = "rawr" Then
        '            Console.WriteLine("single file decompressor")
        '            assigned = True
        '        Else
        '            MsgBox("Unsupported file type, file should be (.)rawr or (.)bonk format.", vbCritical, "Invalid Action")
        '            Return
        '        End If

        '        If assigned Then
        '            ShowDetails(True)
        '            decompressor.AssignData(sourcePath, dpath)
        '            btnProgress.PerformClick()
        '            isCompressing = False
        '            BackgroundWorker1.RunWorkerAsync()
        '        End If

        '    Else
        '        MsgBox("Please select a file.", vbCritical, "Invalid Action")
        '    End If

        'ElseIf selectedControls.Count > 1 Then
        '    MsgBox("Please select a single file.", vbCritical, "Invalid Action")
        'Else
        '    MsgBox("Please select a file.", vbCritical, "Invalid Action")
        'End If

    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        TabControl1.SelectedTab = tbAbout
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        TabControl1.SelectedTab = tbSettings
    End Sub

    Private Sub NewFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewFolderToolStripMenuItem.Click

        'Console.WriteLine(currentDir)
        Dim pathName As String = InputBox("Enter a folder name.", "Create folder", "New folder")

        If Not String.IsNullOrWhiteSpace(pathName) Then

            Dim prohibitedChars As String = "\/:*?""<>|"

            Dim isProhibited As Boolean = False
            For i As Integer = 0 To prohibitedChars.Length - 1
                If pathName.Contains(prohibitedChars(i)) Then
                    isProhibited = True
                    Exit For
                End If
            Next

            If Not isProhibited Then
                Directory.CreateDirectory(currentDir & "\" & pathName)
                Redirectory()
            Else
                MsgBox("A file name cannot contain any of the following characters:" & vbCrLf & "\ / : * ? "" < > |", vbCritical, "Invalid action")
            End If

        Else
            Console.WriteLine("Whitespace")
            Return
        End If

        'Console.WriteLine(pathName)

    End Sub

    Private Function RepairInvalidFilenameByPath(ByVal path As String) As String

        Dim pathDepth As String() = path.Split("\")
        Dim fname As String = pathDepth(pathDepth.Length - 1)
        Dim NFname As String = Nothing

        For i As Integer = 0 To fname.Length - 1
            Dim prohibitedChars() As Char = System.IO.Path.GetInvalidFileNameChars

            For j As Integer = 0 To prohibitedChars.Length - 1
                If fname.Contains(prohibitedChars(j)) Then
                    NFname = fname.Replace(prohibitedChars(j), "")
                    Return path.Replace(fname, NFname)
                End If
            Next
        Next

        Return Nothing
    End Function

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private cm As New CompressionManager 
    Private Sub bwMulti_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwMulti.DoWork
        Console.WriteLine("Thread @MultiWork: Has started his task")

        cm.SetIgnore(isIgnore) 'for ignoring errors

        'cm = New CompressionManager()
        If isMultiThreadCompression Then
            'compression process

            If isSingleFile Then
                cm.SingleFileEncode_Async(mtSourcePath, mtOutputPath)
            Else
                cm.MultiFileEncode_Async(New Queue(Of String)(fileQ), outPutFileName, mtOutputPath)
            End If

        Else
            'decompression process
            'untry the code to navigate the error (debugging)
            Try
                If isSingleFile Then
                    cm.SingleFileDecode_Async(mtSourcePath, mtOutputPath)
                Else
                    cm.MultiFileDecode_Async(mtSourcePath, mtOutputPath)
                End If
            Catch ex As Exception
                Console.WriteLine(ex.Message & vbCrLf & ex.StackTrace)
                errorCode = 8
            End Try

        End If

        'If isMultiThreadCompression Then
        '    cm.SingleFileEncode_Async(mtSourcePath, mtOutputPath)
        'Else
        '    cm.SingleFileDecode_Async(mtSourcePath, mtOutputPath)
        'End If

        'Dim q As New Queue(Of String)
        'q.Enqueue("X:\TestCompression\TestFolder")

        'Dim cm As New CompressionManager()
        'cm.MultiFileEncode_Async(q, "Hotdog", "X:\TestCompression\TestFolder")
        'cm.MultiFileDecode_Async("X:\TestCompression\TestFolder\Hotdog.huff", "X:\TestCompression\TestFolder\Example")

        'cm.FileMerger("X:\TestCompression\")
        'cm.SingleFileMultiEncode_Async("X:\TestCompression\TestVideo.mp4", "X:\TestCompression")
        'cm.DecodeFile("X:\TestCompression\Sample (1).dec", "X:\TestCompression")

        'Dim fpath As String = Nothing
        'Dim spath As String = Nothing
        'cm.FileSplitter("X:\TestCompression\Fast and furious.mp4", fpath, spath)
        'cm.FileMerger("X:\TestCompression\Fast and furious (1).spl")


    End Sub

    Private Sub bwMulti_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwMulti.RunWorkerCompleted

        Console.WriteLine("Thread @MultiWork: Has Done his task")

        lblLastAvgRead.Text = "Avg Read Speed: " & CalculateBytes(GetTotalReadSpeed() / avgReadSpeed.Count) & "/s"
        lblLastAvgWrite.Text = "Avg Write Speed: " & CalculateBytes(GetTotalWriteSpeed() / avgWriteSpeed.Count) & "/s"

        isProcessing = False
        pbDone.Image = My.Resources.Checkmark_96px

        '====================================================================

        If errorCode = 1 Then
            MsgBox("File/s cannot be compressed.", vbInformation, "Compression")
        ElseIf errorCode = 5 Or errorCode = 6 Then 'CANCELLED ACTION

            MsgBox("Operation cancelled.", vbInformation, "User Action")

            lblLastAvgRead.Text = "Avg Read Speed: 0b/s"
            lblLastAvgWrite.Text = "Avg Write Speed: 0b/s"
            lblTotalFileSize.Text = "File/s Overall Size: "
            lblLastTimeElapsed.Text = "Elapsed Time: 00:00:00"

            'reset
            pbDone.Image = My.Resources.Checkmark_96px
            ShowDetails(False)

            status = "Operation Ready"
            folderStatus = "You can select files to compress or decompress."

            folderStatus = "You can select files to compress or decompress again."
            progressStatus = "Waiting for Operation"
            fileStatus = "..."
            overAllPercent = 0.0
            processPercent = 0.0

            secondsElapsed = 0
            errorCode = 0

        ElseIf errorCode = 7 Then 'FILE HAS LOW COMPRESSION RATE

            Dim report As String = "File has low compression rate with " & cm.GetCompressionPercent.ToString() & " %." & vbCrLf &
                                "Estimated Saved size: " & CalculateBytes(cm.GetCompressionDifference()) & vbCrLf &
                                vbCrLf &
                                "Do you want to still compress the file? (Not Recommended)"

            Dim result As MsgBoxResult = MsgBox(report, vbExclamation + vbYesNo, "Low Compression Rate")
            If result = MsgBoxResult.Yes Then
                errorCode = 0
                isProcessing = True
                bwMulti.RunWorkerAsync()
                Return
            Else
                cm.SuspendSpliitedFiles()
            End If

        ElseIf errorCode = 8 Then
            MsgBox("Invalid Signature, File is corrupted.", vbCritical, "Invalid Signature")
        ElseIf errorCode = 0 Then 'NO ERROR

            If isMultiThreadCompression Then
                status = "Compression finished successfully!"
                lblTotalFileSize.Text = "File/s Overall Size: " & CalculateBytes(mtSourcelength)
            Else
                status = "Decompression finished successfully!"
                lblTotalFileSize.Text = "File/s Overall Size (Compressed): " & CalculateBytes(mtSourcelength)
            End If

            ShowDetails(False)

            If processMode Then
                outputFile = cm.GetOutputPath()
            Else
                If isOutputStrict Then
                    outputFileLength = cm.GetDecodedTotalBytes()

                    Console.WriteLine("outputfilelength: " & outputFileLength)
                    Console.WriteLine("outfile: " & outputFile)
                Else
                    outputFile = cm.GetOutputPath()
                End If
            End If

            'REPORT DATA
            ReportData()
            TabControl1.SelectedTab = tbReport

        End If

        TabControl1.SelectedTab = tbReport
        '====================================================================
        'RESET THE COMPRESSION MANAGER
        cm = New CompressionManager()

        folderStatus = "You can select files to compress or decompress again."
        progressStatus = "Waiting for Operation"
        fileStatus = "..."
        overAllPercent = 0.0
        processPercent = 0.0

        secondsElapsed = 0
        errorCode = 0

        isSourceStrict = False
        isOutputStrict = False

        ReDirectory(currentDir)

    End Sub

    Private Sub btnPageStart_Click(sender As Object, e As EventArgs) Handles btnPageStart.Click
        pageView = 0
        btnPageStart.Enabled = False
        btnPagePrev.Enabled = False

        btnPageNext.Enabled = True
        btnPageEnd.Enabled = True

        'checks if the user is currently previewing the compressed file/s
        If cRootNode IsNot Nothing And currentPNode IsNot Nothing Then
            LoadDirectories(currentPNode)
        Else
            LoadDirectories(currentDir)
        End If

    End Sub

    Private Sub btnPageEnd_Click(sender As Object, e As EventArgs) Handles btnPageEnd.Click

        'checks if the user is currently previewing the compressed file/s
        If cRootNode IsNot Nothing And currentPNode IsNot Nothing Then

            pageView = currentPNode.GetList().Count \ controlsToView
            btnPageEnd.Enabled = False
            btnPageNext.Enabled = False

            btnPageStart.Enabled = True
            btnPagePrev.Enabled = True
            LoadDirectories(currentPNode)

        Else

            Dim dir As New DirectoryInfo(currentDir)
            pageView = dir.GetFileSystemInfos.Count \ controlsToView
            btnPageEnd.Enabled = False
            btnPageNext.Enabled = False

            btnPageStart.Enabled = True
            btnPagePrev.Enabled = True

            LoadDirectories(currentDir)

        End If


    End Sub

    Private Sub btnPageNext_Click(sender As Object, e As EventArgs) Handles btnPageNext.Click

        'checks if the user is currently previewing the compressed file/s
        If cRootNode IsNot Nothing And currentPNode IsNot Nothing Then
            pageView += 1

            If pageView >= currentPNode.GetList().Count \ controlsToView Then
                btnPageNext.Enabled = False
                btnPageEnd.Enabled = False
            End If

            If pageView > 0 Then
                btnPageStart.Enabled = True
                btnPagePrev.Enabled = True
            End If

            LoadDirectories(currentPNode)
        Else
            Dim dir As New DirectoryInfo(currentDir)
            pageView += 1
            'page view equal to max page view
            If pageView >= dir.GetFileSystemInfos.Count \ controlsToView Then
                btnPageNext.Enabled = False
                btnPageEnd.Enabled = False
            End If

            If pageView > 0 Then
                btnPageStart.Enabled = True
                btnPagePrev.Enabled = True
            End If

            LoadDirectories(currentDir)
        End If

    End Sub

    Private Sub btnPagePrev_Click(sender As Object, e As EventArgs) Handles btnPagePrev.Click

        'checks if the user is currently previewing the compressed file/s
        If cRootNode IsNot Nothing And currentPNode IsNot Nothing Then
            pageView -= 1

            If pageView <= 0 Then
                btnPagePrev.Enabled = False
                btnPageStart.Enabled = False
            End If

            If pageView < currentPNode.GetList().Count \ controlsToView Then
                btnPageNext.Enabled = True
                btnPageEnd.Enabled = True
            End If

            LoadDirectories(currentPNode)
        Else

            Dim dir As New DirectoryInfo(currentDir)
            pageView -= 1

            If pageView <= 0 Then
                btnPagePrev.Enabled = False
                btnPageStart.Enabled = False
            End If

            If pageView < dir.GetFileSystemInfos.Count \ controlsToView Then
                btnPageNext.Enabled = True
                btnPageEnd.Enabled = True
            End If

            LoadDirectories(currentDir)

        End If

    End Sub

    Private Sub swMulti_CheckedChanged(sender As Object, e As EventArgs) Handles swMulti.CheckedChanged
        If swMulti.Checked Then
            isMultiThread = True
            lblCmpMode.Text = "Compression Mode: MT"
        Else
            isMultiThread = False
            lblCmpMode.Text = "Compression Mode: ST"
        End If
    End Sub

    Private Enum FileSystemObject
        Invalidpath
        Directory
        File
    End Enum

    Private Function GetPathType(ByVal path As String) As FileSystemObject
        If Directory.Exists(path) Then
            Return FileSystemObject.Directory
        ElseIf File.Exists(path) Then
            Return FileSystemObject.File
        Else
            Return FileSystemObject.Invalidpath
        End If
    End Function

    Private Function GetDirectorySize(ByVal path As String) As Long

        Dim totalBytes As Long = 0
        Dim fileQ As New Queue(Of String)
        fileQ.Enqueue(path)

        While fileQ.Count > 0

            Dim dir As New DirectoryInfo(fileQ.Dequeue)
            Dim fileInfo As FileSystemInfo

            For Each fileInfo In dir.GetFileSystemInfos
                Dim fileAtt As FileAttribute = File.GetAttributes(fileInfo.FullName)

                If fileAtt.HasFlag(FileAttribute.Hidden) Then
                    Continue For
                End If

                If fileAtt.HasFlag(FileAttribute.Directory) Then
                    fileQ.Enqueue(fileInfo.FullName)
                    Continue For
                End If

                Dim fileFI As New FileInfo(fileInfo.FullName)
                totalBytes += fileFI.Length

            Next

        End While

        Return totalBytes
    End Function

    'FOR DATA REPORT VARIABLES
    'FILE INFO
    Dim sourceFile As String = Nothing
    Dim outputFile As String = Nothing

    Dim sourceFileLength As Long = 0
    Dim isSourceStrict As Boolean = False 'false means you can change the value of sourcefilelength variable otherwise you cannot.
    Dim outputFileLength As Long = 0
    Dim isOutputStrict As Boolean = False

    'PROCESS
    Dim processMode As Boolean = False ' Decompression
    Dim processType As Boolean = False ' Single Thread
    Dim packageType As Boolean = False ' single-file

    Private Sub ReportData()

        flpReport.Visible = True

        Dim sourceFI As FileInfo = Nothing
        Dim isSourceFile As Boolean = False
        Dim outputFI As FileInfo = Nothing
        Dim isOutputFile As Boolean = False

        Dim sourcePathAttribute As FileSystemObject = GetPathType(sourceFile)
        If sourcePathAttribute.HasFlag(FileSystemObject.File) Then
            sourceFI = New FileInfo(sourceFile)
            isSourceFile = True
        ElseIf sourcePathAttribute.HasFlag(FileSystemObject.Directory) Then
            If Not isSourceStrict Then
                sourceFileLength = GetDirectorySize(sourceFile)
            End If
            isSourceFile = False
        End If

        Dim outputPathAttribute As FileSystemObject = GetPathType(outputFile)
        If outputPathAttribute.HasFlag(FileSystemObject.File) Then
            outputFI = New FileInfo(outputFile)
            isOutputFile = True
        ElseIf outputPathAttribute.HasFlag(FileSystemObject.Directory) Then
            If Not isOutputStrict Then
                outputFileLength = GetDirectorySize(outputFile)
            End If
            isOutputFile = False
        End If

        If isSourceFile Then
            lblSourceF.Text = sourceFI.FullName
            lblSourceSize.Text = CalculateBytes(sourceFI.Length) & " (" & sourceFI.Length.ToString("N0") & " byte/s)"
            lblSourceType.Text = sourceFI.Extension.Replace(".", "").ToUpper & " File (" & sourceFI.Extension & ")"
        Else
            lblSourceF.Text = sourceFile
            lblSourceSize.Text = CalculateBytes(sourceFileLength) & " (" & sourceFileLength.ToString("N0") & " byte/s)"
            lblSourceType.Text = "Directory"
        End If

        If isOutputFile Then
            lblOutputF.Text = outputFI.FullName
            lblOutputSize.Text = CalculateBytes(outputFI.Length) & " (" & outputFI.Length.ToString("N0") & " byte/s)"
            lblOutputType.Text = outputFI.Extension.Replace(".", "").ToUpper & " File (" & outputFI.Extension & ")"
        Else
            lblOutputF.Text = outputFile
            lblOutputSize.Text = CalculateBytes(outputFileLength) & " (" & outputFileLength.ToString("N0") & " byte/s)"
            lblOutputType.Text = "Directory"
        End If

        'COMPUTE BYTE DIFF WHEN COMPRESSING, HIDE WHEN DECOMPRESSING.
        If processMode Then
            Dim byteDiff As Long = 0

            If isSourceFile Then
                byteDiff = sourceFI.Length
            Else
                byteDiff = sourceFileLength
            End If

            If isOutputFile Then
                byteDiff -= outputFI.Length
            Else
                byteDiff -= outputFileLength
            End If

            lblActualSave.Text = CalculateBytes(byteDiff) & " (" & byteDiff.ToString("N0") & " byte/s)"


            If isSourceFile Then
                lblActualPer.Text = ((byteDiff / sourceFI.Length) * 100).ToString("N2") & "%"
            Else
                lblActualPer.Text = ((byteDiff / sourceFileLength) * 100).ToString("N2") & "%"
            End If

        Else
            lblActualSave.Text = "--"
            lblActualPer.Text = "--"
        End If


        'PROCESS INFO
        If processMode Then
            lblProcessMode.Text = "Compression"
        Else
            lblProcessMode.Text = "Decompression"
        End If

        If processType Then
            lblProcessType.Text = "Multi-Thread"
        Else
            lblProcessType.Text = "Single Thread"
        End If

        If packageType Then
            lblPackageType.Text = "Multiple File"
        Else
            lblPackageType.Text = "Single File"
        End If

        If processMode Then
            'COMPRESSION

            gbCompression.Visible = True
            gbDecompression.Visible = False

            Dim totalCompressedSize As Long = 0
            Dim totalHeaderSize As Long = 0

            If Not processType Then
                totalCompressedSize = compressor.GetComputeCompressedSize()
                totalHeaderSize = compressor.GetComputedCompressedHeader()
            Else
                totalCompressedSize = cm.GetComputeCompressedSize()
                totalHeaderSize = cm.GetComputedCompressedHeader()
            End If

            lblReportMsg.Text = "The file/s have been successfully compressed to " & CalculateBytes(totalCompressedSize) & " . Saving Up to " & lblActualPer.Text & " of the original file."

            lblCTimeElapsed.Text = ConvertSecToTime(secondsElapsed)
            lblCTreeTotalByte.Text = CalculateBytes(totalCompressedSize) & " (" & totalCompressedSize.ToString("N0") & " byte/s)"
            lblCHeaderTotalByte.Text = CalculateBytes(totalHeaderSize) & " (" & totalHeaderSize.ToString("N0") & " byte/s)"
            lblCExpSize.Text = CalculateBytes(totalCompressedSize + totalHeaderSize) & " (" & (totalCompressedSize + totalHeaderSize).ToString("N0") & " byte/s)"
            lblCWriteSpeed.Text = CalculateBytes(GetTotalWriteSpeed() / avgWriteSpeed.Count) & "/s"
            lblCReadSpeed.Text = CalculateBytes(GetTotalReadSpeed() / avgReadSpeed.Count) & "/s"
        Else
            'DECOMPRESSION

            gbCompression.Visible = False
            gbDecompression.Visible = True

            Dim totalCompressedSize As Long = 0
            Dim totalDecompressedSize As Long = 0
            Dim totalHeaderSize As Long = 0

            If Not processType Then
                totalCompressedSize = decompressor.GetComputeCompressedSize()
                totalHeaderSize = decompressor.GetComputedCompressedHeader()
                totalDecompressedSize = decompressor.GetOutputTotalBytes()
            Else
                totalCompressedSize = cm.GetComputeCompressedSize()
                totalDecompressedSize = cm.GetDecodedTotalBytes()
                totalHeaderSize = cm.GetComputedCompressedHeader()
            End If

            lblDTimeElapsed.Text = ConvertSecToTime(secondsElapsed)
            lblDTreeTotalByte.Text = CalculateBytes(totalCompressedSize) & " (" & totalCompressedSize.ToString("N0") & " byte/s)"
            lblDHeaderTotalByte.Text = CalculateBytes(totalHeaderSize) & " (" & totalHeaderSize.ToString("N0") & " byte/s)"
            lblDExpSize.Text = CalculateBytes(totalDecompressedSize) & " (" & (totalDecompressedSize).ToString("N0") & " byte/s)"
            lblDWriteSpeed.Text = CalculateBytes(GetTotalWriteSpeed() / avgWriteSpeed.Count) & "/s"
            lblDReadSpeed.Text = CalculateBytes(GetTotalReadSpeed() / avgReadSpeed.Count) & "/s"
        End If

        'clear the list of read and write speeds
        avgReadSpeed.Clear()
        avgWriteSpeed.Clear()


    End Sub

    Private Sub swIgnore_CheckedChanged(sender As Object, e As EventArgs) Handles swIgnore.CheckedChanged
        If swIgnore.Checked Then
            isIgnore = True
        Else
            isIgnore = False
        End If
    End Sub
End Class
