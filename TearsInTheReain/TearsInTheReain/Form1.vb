Public Class Form1
    Dim Direction As Integer = 0
    Dim PlayerAttack As Boolean = False
    Dim grid() As PictureBox
    Dim Map() As String
    Dim LoadMap As Boolean
    Dim Collision As Boolean = False
    Dim CurrentMap As String = "1"
    Dim OverworldMap(3) As String
    Dim CurrentOverworldPos As Integer = 4

    'Enemies'
    Dim EnemyMapLocation(9) As String
    Dim Enemies(10, 10, 2) As PictureBox


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Map = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        GameLoop.Enabled = True
        grid = {Tile1, Tile2, Tile3, Tile4, Tile5, Tile6, Tile7, Tile8, Tile9, Tile10, Tile11, Tile12, Tile13,
        Tile14, Tile15, Tile16, Tile17, Tile18, Tile19, Tile20, Tile21, Tile22, Tile23, Tile24, Tile25, Tile26, Tile27, Tile28, Tile29,
        Tile30, Tile31, Tile32, Tile33, Tile34, Tile35, Tile36, Tile37, Tile38, Tile39, Tile40, Tile41, Tile42, Tile43, Tile44, Tile45, Tile46, Tile47, Tile48, Tile49, Tile50,
        Tile51, Tile52, Tile53, Tile54, Tile55, Tile56, Tile57, Tile58, Tile59, Tile60, Tile61, Tile62, Tile63, Tile64, Tile65, Tile66, Tile67, Tile68, Tile69, Tile70, Tile71,
        Tile72, Tile73, Tile74, Tile75, Tile76, Tile77, Tile78, Tile79, Tile80, Tile81, Tile82, Tile83, Tile84, Tile85, Tile86, Tile87, Tile88, Tile89, Tile90, Tile91, Tile92, Tile93, Tile94,
        Tile95, Tile96, Tile97, Tile98, Tile99, Tile100}

        LoadMap = True

        Call Overworld()


    End Sub


    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.W Then
            Me.Player.Top -= 10
            Direction = 1
        ElseIf e.KeyCode = Keys.S Then
            Me.Player.Top += 10
            Direction = 3
        ElseIf e.KeyCode = Keys.A Then
            Me.Player.Left -= 10
            Direction = 4
        ElseIf e.KeyCode = Keys.D Then
            Me.Player.Left += 10
            Direction = 2
        End If
        Call CollisionDetection()


    End Sub

    Private Sub Tile1_Click(sender As Object, e As EventArgs) Handles Tile1.Click, Tile2.Click, Tile3.Click, Tile4.Click, Tile5.Click, Tile6.Click, Tile7.Click, Tile8.Click, Tile9.Click, Tile10.Click, Tile11.Click,
            Tile12.Click, Tile13.Click, Tile14.Click, Tile15.Click, Tile16.Click, Tile17.Click, Tile18.Click, Tile19.Click, Tile20.Click, Tile21.Click, Tile22.Click, Tile23.Click, Tile24.Click, Tile25.Click, Tile26.Click,
            Tile27.Click, Tile28.Click, Tile29.Click, Tile30.Click, Tile31.Click, Tile32.Click, Tile33.Click, Tile34.Click, Tile35.Click, Tile36.Click, Tile37.Click, Tile38.Click, Tile39.Click, Tile40.Click, Tile41.Click, Tile42.Click,
            Tile43.Click, Tile44.Click, Tile45.Click, Tile46.Click, Tile47.Click, Tile48.Click, Tile49.Click, Tile50.Click, Tile51.Click, Tile52.Click, Tile53.Click, Tile54.Click, Tile55.Click, Tile56.Click, Tile57.Click, Tile58.Click, Tile59.Click,
            Tile60.Click, Tile61.Click, Tile62.Click, Tile63.Click, Tile64.Click, Tile65.Click, Tile66.Click, Tile67.Click, Tile68.Click, Tile69.Click, Tile70.Click, Tile71.Click, Tile72.Click, Tile73.Click, Tile74.Click, Tile75.Click, Tile76.Click,
            Tile77.Click, Tile78.Click, Tile79.Click, Tile80.Click, Tile81.Click, Tile82.Click, Tile83.Click, Tile84.Click, Tile85.Click, Tile86.Click, Tile87.Click, Tile88.Click, Tile89.Click, Tile90.Click, Tile91.Click, Tile92.Click, Tile93.Click,
            Tile94.Click, Tile95.Click, Tile96.Click, Tile97.Click, Tile98.Click, Tile99.Click, Tile100.Click

        Dim ClickedBox As PictureBox
        ClickedBox = CType(sender, PictureBox)

        If ClickedBox.Tag = 5 Then
            Call ItemClick(ClickedBox)
        Else
            Call Attack()
        End If


    End Sub

    'GameLoop
    Private Sub GameLoop_Tick(sender As Object, e As EventArgs) Handles GameLoop.Tick
        If LoadMap = True Then
            Call MapRead()
            Call MapLoad()
            Call EnemyRead()
            Call EnemySpawn()
            LoadMap = False
        Else
            Call PlayerAnimation(PlayerAttack)


        End If

    End Sub

    Sub Overworld()
        Dim Overworld As System.IO.StreamReader
        Overworld = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Liam Iverson\Desktop\DungeonCrawl\Overworld.txt")
        For x As Integer = 0 To 2
            OverworldMap(x) = Overworld.ReadLine
        Next
    End Sub

    Sub OverworldUpdate()
        Dim OverworldLocal As String = Nothing
        For x As Integer = 0 To 2
            OverworldLocal += OverworldMap(x)
        Next
        If Direction = 1 Then
            CurrentOverworldPos -= 4
            CurrentMap = OverworldLocal.Chars(CurrentOverworldPos)
        ElseIf Direction = 2 Then
            CurrentOverworldPos += 1
            CurrentMap = OverworldLocal.Chars(CurrentOverworldPos)
        ElseIf Direction = 3 Then
            CurrentOverworldPos += 4
            CurrentMap = OverworldLocal.Chars(CurrentOverworldPos)
        ElseIf Direction = 4 Then
            CurrentOverworldPos -= 1
            CurrentMap = OverworldLocal.Chars(CurrentOverworldPos)

        End If
        Call PlayerRespawn()
        LoadMap = True
    End Sub


    Sub MapRead()
        Dim Mapreader As System.IO.StreamReader
        Mapreader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Liam Iverson\Desktop\DungeonCrawl\Map" & CurrentMap & ".txt")
        For x As Integer = 0 To 9
            Map(x) = Mapreader.ReadLine
        Next

    End Sub

    Sub MapLoad()
        Dim MapLocal As String = Nothing
        For x As Integer = 0 To 9
            MapLocal += Map(x)
        Next
        For x As Integer = 0 To 89
            If MapLocal.Chars(x) = "1" Then
                grid(x).Image = My.Resources.BrickWall
                grid(x).Tag = 1
            ElseIf MapLocal.Chars(x) = "2" Then
                grid(x).Image = My.Resources.Floor
                grid(x).Tag = 2
            ElseIf MapLocal.Chars(x) = "3" Then
                grid(x).Image = My.Resources.Concrete
                grid(x).Tag = 3
            ElseIf MapLocal.Chars(x) = "4" Then
                grid(x).Image = Nothing
                grid(x).Tag = 4
            ElseIf MapLocal.Chars(x) = "5" Then
                grid(x).Image = My.Resources.Chest
                grid(x).Tag = 5

            Else
                grid(x).Tag = 0
                grid(x).Image = Nothing
                grid(x).BackColor = Color.Black
            End If
        Next
    End Sub

    Sub ItemClick(ByRef Tile As PictureBox)
        If ((Tile.Bounds.Y + 50) >= Player.Bounds.Y And Player.Bounds.Y >= (Tile.Bounds.Y - 50)) And ((Tile.Bounds.X + 50) >= Player.Bounds.X And Player.Bounds.X >= (Tile.Bounds.X - 50)) Then

        End If
    End Sub


    Sub CollisionDetection()

        For x As Integer = 0 To 99
            If grid(x).Tag = 1 Or grid(x).Tag = 5 Then
                If Player.Bounds.IntersectsWith(grid(x).Bounds) Then
                    Call CollisionType(1)
                End If
            ElseIf grid(x).Tag = 4 Then
                If Player.Bounds.IntersectsWith(grid(x).Bounds) Then
                    Call OverworldUpdate()
                End If
            End If
        Next




    End Sub

    Sub CollisionType(ByRef x As Integer)
        If x = 1 Then
            Collision = True
            If Direction = 1 Then
                Me.Player.Top += 10
            ElseIf Direction = 2 Then
                Me.Player.Left -= 10
            ElseIf Direction = 3 Then
                Me.Player.Top -= 10
            ElseIf Direction = 4 Then
                Me.Player.Left += 10
            End If
        End If
    End Sub

    Sub Attack()
        If PlayerAttack = False Then
            PlayerAttack = True
        Else
            PlayerAttack = False
        End If

    End Sub

    Sub PlayerRespawn()
        If Direction = 1 Then
            Me.Player.Top += 300
        ElseIf Direction = 2 Then
            Me.Player.Left -= 350
        ElseIf Direction = 3 Then
            Me.Player.Top -= 300
        ElseIf Direction = 4 Then
            Me.Player.Left += 350
        End If
    End Sub

    Sub PlayerAnimation(ByRef PlayerAttack)
        If PlayerAttack = True Then
            Me.Player.Image = My.Resources.Player_Punch1
            Call Attack()
            PlayerAttack = False
            If Direction = 1 Then
                Me.Player.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
                Me.Player.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            ElseIf Direction = 2 Then
                Me.Player.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            ElseIf Direction = 3 Then
                Me.Player.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            ElseIf Direction = 4 Then
                Me.Player.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            End If
        Else
            Me.Player.Image = My.Resources.Player_Static
            If Direction = 2 Or Direction = 4 Then
                Me.Player.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Else
                Me.Player.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            End If
        End If
    End Sub

    Sub EnemyRead()
        Dim EnemyReader As System.IO.StreamReader
        EnemyReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Liam Iverson\Desktop\DungeonCrawl\EnemyLocations\EnemySpawn" & CurrentMap & ".txt")
        For x As Integer = 0 To 9
            EnemyMapLocation(x) = EnemyReader.ReadLine
        Next
    End Sub

    Sub EnemySpawn()
        Dim EnemyLocal As String = Nothing
        For x As Integer = 0 To 9
            EnemyLocal += EnemyMapLocation(x)
        Next
        For x As Integer = 0 To 89
            If EnemyLocal.Chars(x) = "G" Then
                Dim box As PictureBox = New PictureBox
                box.Location = New Point(500, 500)
                box.Size = New Size(50, 50)
                Controls.Add(box)
                box.BringToFront()
                box.Image = My.Resources.Chest

            End If
        Next



    End Sub

End Class

