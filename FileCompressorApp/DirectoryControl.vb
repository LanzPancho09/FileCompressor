Imports System.IO

Public Class DirectoryControl

    Dim isSelected As Boolean = False
    Public filepath As String = Nothing
    Public isFolder As Boolean = False
    Public Property isFileDecompressable As Boolean = False
    Public isMultipleFiles As Boolean = False

    Public currentP As PathNode
    Public isCompressedDirectory As Boolean = False

    Public type As String = Nothing
    Public fileSize As Long = 0
    Public nameSum As Integer = 0
    Public typeSum As Integer = 0
    Public dateDiff As Integer = 0

    Public Function isControlSelected() As Boolean
        Return isSelected
    End Function

    'NOTE AYUSIN MO NA UNG ABOUT SA RE_DIRECTING NG COMPRESSED FILES

    Private Sub btnSelect_MouseClick(sender As Object, e As MouseEventArgs) Handles btnSelect.MouseClick, pnlName.MouseClick, pnlSize.MouseClick, pnlType.MouseClick, pnlDate.MouseClick, lblName.MouseClick, lblSize.MouseClick, lblType.MouseClick, lblDate.MouseClick

        If Not e.Button = MouseButtons.Left Then
            Return
        End If

        If Not Form1.isMultiselect Then
            Form1.RemoveSelectedControls()
        End If

        'changing context menu
        If isCompressedDirectory Then
            Me.ContextMenuStrip = ContextMenuStrip2
            btnSelect.ContextMenuStrip = ContextMenuStrip2
            pnlName.ContextMenuStrip = ContextMenuStrip2
            pnlSize.ContextMenuStrip = ContextMenuStrip2
            pnlType.ContextMenuStrip = ContextMenuStrip2
            pnlDate.ContextMenuStrip = ContextMenuStrip2
            lblName.ContextMenuStrip = ContextMenuStrip2
            lblSize.ContextMenuStrip = ContextMenuStrip2
            lblType.ContextMenuStrip = ContextMenuStrip2
            lblDate.ContextMenuStrip = ContextMenuStrip2

            tsmNewfolder.Enabled = False
        Else
            Me.ContextMenuStrip = ContextMenuStrip1
            btnSelect.ContextMenuStrip = ContextMenuStrip1
            pnlName.ContextMenuStrip = ContextMenuStrip1
            pnlSize.ContextMenuStrip = ContextMenuStrip1
            pnlType.ContextMenuStrip = ContextMenuStrip1
            pnlDate.ContextMenuStrip = ContextMenuStrip1
            lblName.ContextMenuStrip = ContextMenuStrip1
            lblSize.ContextMenuStrip = ContextMenuStrip1
            lblType.ContextMenuStrip = ContextMenuStrip1
            lblDate.ContextMenuStrip = ContextMenuStrip1

            tsmNewfolder.Enabled = False
        End If

        'If isCompressedDirectory Then
        '    OpenToolStripMenuItem.Enabled = False
        '    BonkHereToolStripMenuItem.Enabled = False
        '    UnbonkHereToolStripMenuItem.Enabled = False
        'Else
        '    OpenToolStripMenuItem.Enabled = True
        '    BonkHereToolStripMenuItem.Enabled = True
        '    UnbonkHereToolStripMenuItem.Enabled = True
        'End If

        If Not isFileDecompressable Then
            OpenToolStripMenuItem.Enabled = False
            UnbonkHereToolStripMenuItem.Enabled = False
        Else
            If isMultipleFiles Then
                OpenToolStripMenuItem.Enabled = True
            Else
                OpenToolStripMenuItem.Enabled = False
            End If

            UnbonkHereToolStripMenuItem.Enabled = True
        End If


        If Not isSelected Then
            isSelected = True
            btnSelect.BaseColor = Color.FromArgb(208, 205, 255)
            btnSelect.OnHoverBaseColor = Color.FromArgb(208, 205, 255)
            pnlName.BackColor = Color.FromArgb(208, 205, 255)
            pnlSize.BackColor = Color.FromArgb(208, 205, 255)
            pnlType.BackColor = Color.FromArgb(208, 205, 255)
            pnlDate.BackColor = Color.FromArgb(208, 205, 255)
            Form1.selectedControls.Add(Me)
        End If


    End Sub

    Private Sub btnSelect_MouseEnter(sender As Object, e As EventArgs) Handles btnSelect.MouseEnter, pnlName.MouseEnter, pnlSize.MouseEnter, pnlType.MouseEnter, pnlDate.MouseEnter, lblName.MouseEnter, lblSize.MouseEnter, lblType.MouseEnter, lblDate.MouseEnter

        If Not isSelected Then
            btnSelect.BaseColor = Color.FromArgb(239, 238, 255)
            btnSelect.OnHoverBaseColor = Color.FromArgb(239, 238, 255)
            pnlName.BackColor = Color.FromArgb(239, 238, 255)
            pnlSize.BackColor = Color.FromArgb(239, 238, 255)
            pnlType.BackColor = Color.FromArgb(239, 238, 255)
            pnlDate.BackColor = Color.FromArgb(239, 238, 255)
        End If

    End Sub

    Private Sub btnSelect_MouseLeave(sender As Object, e As EventArgs) Handles btnSelect.MouseLeave, pnlName.MouseLeave, pnlSize.MouseLeave, pnlType.MouseLeave, pnlDate.MouseLeave, lblName.MouseLeave, lblSize.MouseLeave, lblType.MouseLeave, lblDate.MouseLeave

        If Not isSelected Then
            btnSelect.BaseColor = Color.FromArgb(248, 248, 248)
            btnSelect.OnHoverBaseColor = Color.FromArgb(248, 248, 248)
            pnlName.BackColor = Color.FromArgb(248, 248, 248)
            pnlSize.BackColor = Color.FromArgb(248, 248, 248)
            pnlType.BackColor = Color.FromArgb(248, 248, 248)
            pnlDate.BackColor = Color.FromArgb(248, 248, 248)
        End If

    End Sub

    Public Sub Unselect()

        isSelected = False
        btnSelect.BaseColor = Color.FromArgb(248, 248, 248)
        btnSelect.OnHoverBaseColor = Color.FromArgb(248, 248, 248)
        pnlName.BackColor = Color.FromArgb(248, 248, 248)
        pnlSize.BackColor = Color.FromArgb(248, 248, 248)
        pnlType.BackColor = Color.FromArgb(248, 248, 248)
        pnlDate.BackColor = Color.FromArgb(248, 248, 248)

        Me.ContextMenuStrip = ContextMenuStrip2
        btnSelect.ContextMenuStrip = ContextMenuStrip2
        pnlName.ContextMenuStrip = ContextMenuStrip2
        pnlSize.ContextMenuStrip = ContextMenuStrip2
        pnlType.ContextMenuStrip = ContextMenuStrip2
        pnlDate.ContextMenuStrip = ContextMenuStrip2
        lblName.ContextMenuStrip = ContextMenuStrip2
        lblSize.ContextMenuStrip = ContextMenuStrip2
        lblType.ContextMenuStrip = ContextMenuStrip2
        lblDate.ContextMenuStrip = ContextMenuStrip2

        txtNewFilename.Visible = False
        txtNewFilename.Text = ""

    End Sub

    Private Sub btnSelect_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles btnSelect.MouseDoubleClick, pnlName.MouseDoubleClick, pnlSize.MouseDoubleClick, pnlType.MouseDoubleClick, pnlDate.MouseDoubleClick, lblName.MouseDoubleClick, lblSize.MouseDoubleClick, lblType.MouseDoubleClick, lblDate.MouseDoubleClick

        If isMultipleFiles Then
            OpenToolStripMenuItem.PerformClick()
            Return
        End If

        If isCompressedDirectory Then
            Form1.ReDirectory(currentP)
            Form1.btnBack.Enabled = True
            Return
        End If

        If Directory.Exists(Me.filepath) Then
            Form1.ReDirectory(Me.filepath)
            Form1.RemoveSelectedControls()
        End If

        Form1.btnBack.Enabled = True
    End Sub

    Private Sub DesktopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesktopToolStripMenuItem.Click
        Form1.ReDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
        Form1.ResetCompressedDirectory()
    End Sub

    Private Sub DocumentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentsToolStripMenuItem.Click
        Form1.ReDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
        Form1.ResetCompressedDirectory()
    End Sub

    Private Sub DownloadsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadsToolStripMenuItem.Click
        Dim dFolder As String = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal))
        dFolder = Path.Combine(dFolder, "Downloads")
        Form1.ReDirectory(dFolder)
        Form1.ResetCompressedDirectory()
    End Sub

    Private Sub MusicToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MusicToolStripMenuItem.Click
        Form1.ReDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic))
        Form1.ResetCompressedDirectory()
    End Sub

    Private Sub PicturesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PicturesToolStripMenuItem.Click
        Form1.ReDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
        Form1.ResetCompressedDirectory()
    End Sub

    Private Sub VideosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VideosToolStripMenuItem.Click
        Form1.ReDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos))
        Form1.ResetCompressedDirectory()
    End Sub

    Private Sub tsmDesktop_Click(sender As Object, e As EventArgs) Handles tsmDesktop.Click
        Form1.ReDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
        Form1.ResetCompressedDirectory()
    End Sub

    Private Sub tsmDocument_Click(sender As Object, e As EventArgs) Handles tsmDocument.Click
        Form1.ReDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
        Form1.ResetCompressedDirectory()
    End Sub

    Private Sub tsmDownloads_Click(sender As Object, e As EventArgs) Handles tsmDownloads.Click
        Dim dFolder As String = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal))
        dFolder = Path.Combine(dFolder, "Downloads")
        Form1.ReDirectory(dFolder)
        Form1.ResetCompressedDirectory()
    End Sub

    Private Sub tsmMusic_Click(sender As Object, e As EventArgs) Handles tsmMusic.Click
        Form1.ReDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic))
        Form1.ResetCompressedDirectory()
    End Sub

    Private Sub tsmPictures_Click(sender As Object, e As EventArgs) Handles tsmPictures.Click
        Form1.ReDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
        Form1.ResetCompressedDirectory()
    End Sub

    Private Sub tsmVideos_Click(sender As Object, e As EventArgs) Handles tsmVideos.Click
        Form1.ReDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos))
        Form1.ResetCompressedDirectory()
    End Sub

    Private Sub UnbonkHereToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnbonkHereToolStripMenuItem.Click
        If Not IsPathExist() Then
            MsgBox("The file or folder does not exist. It might be moved or deleted.", vbCritical, "Path not exist")
            Return
        End If
        Form1.UnbonkFileToCurrentDirectory(filepath)
    End Sub

    Private Sub BonkHereToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BonkHereToolStripMenuItem.Click
        If Not IsPathExist() Then
            MsgBox("The file or folder does not exist. It might be moved or deleted.", vbCritical, "Path not exist")
            Return
        End If
        Form1.BonkFileToCurrentDirectory()
    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem.Click
        If Not IsPathExist() Then
            MsgBox("The file or folder does not exist. It might be moved or deleted.", vbCritical, "Path not exist")
            Return
        End If

        Dim fi As New FileInfo(filepath)

        If Not isFolder Then
            txtNewFilename.Text = fi.Name.Replace(fi.Extension, "")
        Else
            txtNewFilename.Text = fi.Name
        End If

        txtNewFilename.Visible = True
        txtNewFilename.Select()
    End Sub

    Private Sub txtNewFilename_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNewFilename.KeyDown
        If e.KeyCode = Keys.Return Then
            Console.WriteLine("Entered!")

            Dim fi As New FileInfo(filepath)

            If isFolder Then

                Dim oldFilename As String = fi.Name
                Dim newFilename As String = txtNewFilename.Text

                If Not oldFilename.Equals(newFilename) Then
                    My.Computer.FileSystem.RenameDirectory(filepath, newFilename)
                End If

            Else

                Dim oldFilename As String = fi.Name.Replace(fi.Extension, "")
                Dim newFilename As String = txtNewFilename.Text

                If Not oldFilename.Equals(newFilename) Then
                    My.Computer.FileSystem.RenameFile(filepath, txtNewFilename.Text & fi.Extension)
                End If

            End If

            Form1.Redirectory()
        End If
    End Sub

    Private Sub txtNewFilename_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNewFilename.KeyPress

        Dim prohibitedChars As String = "\/:*?""<>|"

        If prohibitedChars.Contains(e.KeyChar) Then
            e.Handled = True
            Me.ErrorProvider1.SetError(txtNewFilename, "A file name cannot contain any of the following characters:" & vbCrLf & "\ / : * ? "" < > |")
        Else
            Me.ErrorProvider1.SetError(txtNewFilename, "")
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

        If Not IsPathExist() Then
            MsgBox("The file or folder does not exist. It might be moved or deleted.", vbCritical, "Path not exist")
            Return
        End If

        Form1.txtPath.Text = filepath
        Dim fi As New FileInfo(filepath)

        Dim encMode As Integer = -1
        'retrive the file mode.
        Using Freader As New FileStream(fi.FullName, FileMode.Open, FileAccess.Read)
            Dim encodingType(0) As Byte
            Freader.Read(encodingType, 0, encodingType.Length)
            encMode = encodingType(0)
        End Using

        If encMode = 1 Then
            'original

            'Dim extsn As String = fi.Extension.Replace(".", "").ToLower

            'If extsn = "rawr" Then
            '    Return
            'End If

            Using Freader As New System.IO.FileStream(filepath, FileMode.Open, FileAccess.Read)

                Dim encodingType(0) As Byte
                Freader.Read(encodingType, 0, encodingType.Length)

                'tree header and data
                Dim treeHeader(4 - 1) As Byte
                Freader.Read(treeHeader, 0, treeHeader.Length)

                Dim treeHeaderLength As Integer = BitConverter.ToInt32(treeHeader, 0)
                Console.WriteLine("Readed Bin header: " & treeHeaderLength)

                Dim treeData(treeHeaderLength - 1) As Byte
                Freader.Read(treeData, 0, treeData.Length)

                Dim fileNames As New List(Of String)
                Dim fileSizes As New Queue(Of Long)

                'file Paths header and data
                Dim fileNameHeader(2 - 1) As Byte
                Freader.Read(fileNameHeader, 0, fileNameHeader.Length)

                Dim fileNameHeaderLength As Short = BitConverter.ToInt16(fileNameHeader, 0)
                'Console.WriteLine("readed filenameheader: " & fileNameHeaderLength)

                While fileNameHeaderLength > 0

                    Dim pathHeader(3) As Byte
                    Freader.Read(pathHeader, 0, pathHeader.Length)
                    Dim pathLength As Integer = BitConverter.ToInt16(pathHeader, 0)

                    Dim fileNameData(pathLength - 1) As Byte
                    Freader.Read(fileNameData, 0, fileNameData.Length)

                    Dim fileData As String = System.Text.Encoding.UTF8.GetString(fileNameData, 0, fileNameData.Length)
                    'Console.WriteLine(fileData & " : " & fileData.Length)

                    fileNames.Add(fileData)
                    fileNameHeaderLength -= 1
                End While

                'File Size header And data
                Dim fileSizeHeader(4 - 1) As Byte
                Freader.Read(fileSizeHeader, 0, fileSizeHeader.Length)

                Dim fileSizeHeaderLength As Integer = BitConverter.ToInt32(fileSizeHeader, 0)
                'Console.WriteLine("readed file size header: " & fileSizeHeaderLength)

                Dim fileSizeData(fileSizeHeaderLength - 1) As Byte
                Freader.Read(fileSizeData, 0, fileSizeData.Length)

                'Console.WriteLine("decoded filesizedata: " & fileSizeData.Length)

                For i As Integer = 0 To fileSizeData.Length - 1 Step 8
                    Dim sizeByte() As Byte = {fileSizeData(i), fileSizeData(i + 1), fileSizeData(i + 2), fileSizeData(i + 3), fileSizeData(i + 4), fileSizeData(i + 5), fileSizeData(i + 6), fileSizeData(i + 7)}
                    Dim size As Long = BitConverter.ToInt64(sizeByte, 0)
                    fileSizes.Enqueue(size)
                    'Console.WriteLine("file size: " & size)
                Next
                Console.WriteLine("queue size: " & fileSizes.Count)

                ' Dim ctr As Integer = 0
                Dim root As New PathNode("root")
                Dim currentNode As PathNode = root

                For Each filename As String In fileNames

                    'Console.WriteLine(filename)

                    If filename(0) = "0" Then
                        Dim output As String = filename.Remove(0, 2)
                        Console.WriteLine(filename)
                        Console.WriteLine(output)
                        Dim fsplit As String() = output.Split("\")

                        Dim ctrs As Integer = 0
                        For Each f As String In fsplit

                            'Console.WriteLine(f & " : " & ctr.ToString())

                            If currentNode.Count() <= 0 Then
                                Dim node As PathNode = New PathNode(f)
                                node.SetParent(currentNode)
                                currentNode.AddNode(node)
                                currentNode = node
                            Else
                                Dim node As PathNode = currentNode.GetNodeByName(f)

                                If node Is Nothing Then
                                    Dim nNode As PathNode = New PathNode(f)
                                    nNode.SetParent(currentNode)
                                    currentNode.AddNode(nNode)
                                    currentNode = nNode
                                Else
                                    currentNode = node
                                End If
                            End If

                            'ctr += 1

                        Next

                        'Console.WriteLine()
                    ElseIf filename(0) = "1" Then

                        Dim output As String = filename.Remove(0, 2)
                        'Console.WriteLine(output)

                        Dim fsplit As String() = output.Split("\")
                        For Each f As String In fsplit

                            If String.IsNullOrWhiteSpace(f) Then
                                Continue For
                            End If

                            If currentNode.Count() <= 0 Then
                                Dim node As PathNode = New PathNode(f)
                                node.SetParent(currentNode)
                                node.SetFile()
                                node.SetFileSize(fileSizes.Dequeue())
                                'ctr += 1

                                currentNode.AddNode(node)
                                currentNode = node
                            Else
                                Dim node As PathNode = currentNode.GetNodeByName(f)

                                If node Is Nothing Then
                                    Dim nNode As PathNode = New PathNode(f)
                                    nNode.SetParent(currentNode)
                                    nNode.SetFile()
                                    nNode.SetFileSize(fileSizes.Dequeue())
                                    ' ctr += 1

                                    currentNode.AddNode(nNode)
                                    currentNode = nNode
                                Else
                                    currentNode = node
                                End If
                            End If

                            'Console.WriteLine("Current dequeued items: " & ctr)

                        Next

                    End If

                    currentNode = root
                Next

                Form1.SetRootNode(root)
                Form1.ReDirectory(root)

                'Console.WriteLine()

                'Dim q As New Queue(Of PathNode)
                'q.Enqueue(root)

                'While q.Count > 0
                '    Dim cNode As PathNode = q.Dequeue()
                '    Console.WriteLine(cNode.GetName() & " : " & cNode.IsNodeFile())

                '    For Each p As PathNode In cNode.GetList()
                '        q.Enqueue(p)
                '    Next
                'End While

                'For Each filesize As Long In fileSizes
                '    Console.WriteLine(filesize)
                'Next

            End Using

        ElseIf encMode = 3 Then


            Using Freader As New FileStream(filepath, FileMode.Open, FileAccess.Read)

                '<encoding type> boolean
                Dim encodingType(0) As Byte
                Freader.Read(encodingType, 0, encodingType.Length)
                'Dim encType As Boolean = BitConverter.ToBoolean(encodingType, 0)


                '<treeheader> Int
                Dim treeHeader(3) As Byte
                Freader.Read(treeHeader, 0, treeHeader.Length)
                Dim treeHeaderlength As Integer = BitConverter.ToInt32(treeHeader, 0)


                '<treeData>
                Dim treeData(treeHeaderlength - 1) As Byte
                Freader.Read(treeData, 0, treeData.Length)

                'total directory,file number <TotalFile> (Integer)
                Dim firstLength(3) As Byte
                Freader.Read(firstLength, 0, firstLength.Length)
                Dim totalFile As Integer = BitConverter.ToInt32(firstLength, 0)
                Console.WriteLine("total file: " & totalFile)


                Dim fileNames As New List(Of String)
                Dim fileSizes As New Queue(Of Long)

                For i As Integer = 0 To totalFile - 1

                    '<path header value> Int
                    Dim pathHeader(3) As Byte
                    Freader.Read(pathHeader, 0, pathHeader.Length)
                    Dim pathLength As Integer = BitConverter.ToInt32(pathHeader, 0)
                    Console.WriteLine("pathlength: " & pathLength)

                    '<path data> String
                    Dim pathData(pathLength - 1) As Byte
                    Freader.Read(pathData, 0, pathData.Length)
                    Dim pathName As String = System.Text.Encoding.UTF8.GetString(pathData)

                    'If pathName(0) = "0" Then
                    '    folderPath.Add(pathName.Remove(0, 1))
                    '    Console.WriteLine("folder" & pathName.Remove(0, 1))
                    'ElseIf pathName(0) = "1" Then
                    '    filepath.Add(pathName.Remove(0, 1))
                    '    Console.WriteLine("file" & pathName.Remove(0, 1))
                    'End If

                    fileNames.Add(pathName)
                Next

                Dim firsthalfDataLength As New List(Of Long)
                Dim secondHalfDataLength As New List(Of Long)

                '<Long header> Int
                Dim longHeader(3) As Byte
                Freader.Read(longHeader, 0, longHeader.Length)
                Dim firstHeaderLength As Integer = BitConverter.ToInt32(longHeader, 0)
                Console.WriteLine("counter: " & firstHeaderLength)

                For i As Integer = 0 To firstHeaderLength - 1
                    Dim longData(7) As Byte
                    Freader.Read(longData, 0, longData.Length)
                    Dim dataLength As Long = BitConverter.ToInt64(longData, 0)
                    firstHalfDataLength.Add(dataLength)
                    Console.WriteLine("First Data length: " & dataLength)
                Next

                Dim secLongHeader(3) As Byte
                Freader.Read(secLongHeader, 0, secLongHeader.Length)
                Dim secHeaderLength As Integer = BitConverter.ToInt32(secLongHeader, 0)
                Console.WriteLine("counter: " & secHeaderLength)

                For i As Integer = 0 To secHeaderLength - 1
                    Dim longData(7) As Byte
                    Freader.Read(longData, 0, longData.Length)
                    Dim dataLength As Long = BitConverter.ToInt64(longData, 0)
                    secondHalfDataLength.Add(dataLength)
                    Console.WriteLine("Second Data length: " & dataLength)
                Next

                For i As Integer = 0 To firsthalfDataLength.Count - 1
                    Console.WriteLine("file size: " & (firsthalfDataLength(i) + secondHalfDataLength(i)))
                    fileSizes.Enqueue(firsthalfDataLength(i) + secondHalfDataLength(i))
                Next


                Dim root As New PathNode("root")
                Dim currentNode As PathNode = root

                For Each filename As String In fileNames

                    'Console.WriteLine(filename)

                    If filename(0) = "0" Then
                        Dim output As String = filename.Remove(0, 2)
                        Console.WriteLine(filename)
                        Console.WriteLine(output)
                        Dim fsplit As String() = output.Split("\")

                        Dim ctrs As Integer = 0
                        For Each f As String In fsplit

                            'Console.WriteLine(f & " : " & ctr.ToString())

                            If currentNode.Count() <= 0 Then
                                Dim node As PathNode = New PathNode(f)
                                node.SetParent(currentNode)
                                currentNode.AddNode(node)
                                currentNode = node
                            Else
                                Dim node As PathNode = currentNode.GetNodeByName(f)

                                If node Is Nothing Then
                                    Dim nNode As PathNode = New PathNode(f)
                                    nNode.SetParent(currentNode)
                                    currentNode.AddNode(nNode)
                                    currentNode = nNode
                                Else
                                    currentNode = node
                                End If
                            End If

                            'ctr += 1

                        Next

                        'Console.WriteLine()
                    ElseIf filename(0) = "1" Then

                        Dim output As String = filename.Remove(0, 2)
                        'Console.WriteLine(output)

                        Dim fsplit As String() = output.Split("\")
                        For Each f As String In fsplit

                            If String.IsNullOrWhiteSpace(f) Then
                                Continue For
                            End If

                            If currentNode.Count() <= 0 Then
                                Dim node As PathNode = New PathNode(f)
                                node.SetParent(currentNode)
                                node.SetFile()
                                node.SetFileSize(fileSizes.Dequeue())
                                'ctr += 1

                                currentNode.AddNode(node)
                                currentNode = node
                            Else
                                Dim node As PathNode = currentNode.GetNodeByName(f)

                                If node Is Nothing Then
                                    Dim nNode As PathNode = New PathNode(f)
                                    nNode.SetParent(currentNode)
                                    nNode.SetFile()
                                    nNode.SetFileSize(fileSizes.Dequeue())
                                    ' ctr += 1

                                    currentNode.AddNode(nNode)
                                    currentNode = nNode
                                Else
                                    currentNode = node
                                End If
                            End If

                            'Console.WriteLine("Current dequeued items: " & ctr)

                        Next

                    End If

                    currentNode = root
                Next

                Form1.SetRootNode(root)
                Form1.ReDirectory(root)

            End Using


        End If

    End Sub

    Private Function IsPathExist() As Boolean

        If isFolder Then
            If Directory.Exists(filepath) Then
                Return True
            Else
                Return False
            End If
        Else
            If File.Exists(filepath) Then
                Return True
            Else
                Return False
            End If
        End If

    End Function

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If Not IsPathExist() Then
            MsgBox("The file or folder does not exist. It might be moved or deleted.", vbCritical, "Path not exist")
            Return
        End If

        Dim msgDes As String = Nothing
        If isFolder Then
            msgDes = "Are you sure to delete this folder? It cannot be undone."
        Else
            msgDes = "Are you sure to delete this file? It cannot be undone."
        End If

        Dim msgResult As MsgBoxResult = MsgBox(msgDes, vbQuestion + vbYesNo, "Action confirmation")

        If msgResult = MsgBoxResult.Yes Then
            If isFolder Then
                Directory.Delete(filepath, True)
            Else
                File.Delete(filepath)
            End If
            Form1.Redirectory()
        End If

    End Sub

    Private Sub tsmNewfolder_Click(sender As Object, e As EventArgs) Handles tsmNewfolder.Click
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

                Dim fi As New FileInfo(filepath)
                Dim currentDir As String = fi.DirectoryName
                Directory.CreateDirectory(currentDir & "\" & pathName)
                Form1.Redirectory()
            Else
                MsgBox("A file name cannot contain any of the following characters:" & vbCrLf & "\ / : * ? "" < > |", vbCritical, "Invalid action")
            End If

        End If
    End Sub

End Class
