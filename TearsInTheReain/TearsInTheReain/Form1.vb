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
    Dim EnemyCount As Integer = -1
    Dim EnemyMapLocation(9, 9) As String
    Dim Enemy(9) As Object
    Dim EnemySprites() As PictureBox

    'Items'
    Dim ItemSprites() As PictureBox
    Dim Item As String
    Dim StoryItem(6) As Object





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
        EnemySprites = {EnemyBox, EnemyBox2, EnemyBox3}
        ItemSprites = {ItemBox1, ItemBox2, ItemBox3, ItemBox4, ItemBox5, ItemBox6}
        Intro()


    End Sub

    Sub Intro()
        Me.Setting.BringToFront()
        Me.Setting.Image = My.Resources.TitleCard
        My.Computer.Audio.Play("C:\Users\Liam Iverson\Desktop\DungeonCrawl\Intro.wav")
    End Sub


    Private Sub Setting_Click(sender As Object, e As EventArgs) Handles Setting.Click
        GameStart()
    End Sub

    Sub GameStart()
        Me.Setting.SendToBack()
        Me.Setting.Image = Nothing
        Dim music As String = "C:\Users\Liam Iverson\Desktop\DungeonCrawl\Background.wav" ' *.wav file location
        Dim media As New Media.SoundPlayer(music)
        media.Play()
        LoadMap = True

        Call Overworld()
        Call EnemyRead()


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
            Tile94.Click, Tile95.Click, Tile96.Click, Tile97.Click, Tile98.Click, Tile99.Click, Tile100.Click, EnemyBox.Click, EnemyBox2.Click, EnemyBox3.Click, ItemBox1.Click, ItemBox2.Click, ItemBox3.Click, ItemBox4.Click, ItemBox5.Click, ItemBox6.Click

        Dim ClickedBox As PictureBox
        ClickedBox = CType(sender, PictureBox)

        If ClickedBox.Tag = 6 Then
            EnemyClick()
        ElseIf ClickedBox.Tag = 7
            ItemClick()
        Else
            Call Attack()
        End If


    End Sub

    'GameLoop
    Private Sub GameLoop_Tick(sender As Object, e As EventArgs) Handles GameLoop.Tick
        If LoadMap = True Then
            Call MapRead()
            Call MapLoad()
            Call EnemySpawn()
            Call ItemSpawn()
            LoadMap = False
        Else
            Call PlayerAnimation(PlayerAttack)
            Call EnemyAI()


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
                grid(x).Image = My.Resources.Brickwall_Connor
                grid(x).Tag = 1
            ElseIf MapLocal.Chars(x) = "2" Then
                grid(x).Image = My.Resources.Floor_Connor
                grid(x).Tag = 2
            ElseIf MapLocal.Chars(x) = "3" Then
                grid(x).Image = My.Resources.Concrete
                grid(x).Tag = 3
            ElseIf MapLocal.Chars(x) = "4" Then
                grid(x).Image = My.Resources.Door2
                grid(x).Tag = 4
            ElseIf MapLocal.Chars(x) = "5" Then
                grid(x).Image = My.Resources.Chest
                grid(x).Tag = 5
            ElseIf MapLocal.Chars(x) = "9" Then
                grid(x).Image = Nothing
                grid(x).Tag = 9
            Else
                grid(x).Tag = 0
                grid(x).Image = Nothing
                grid(x).BackColor = Color.Black
            End If
        Next
    End Sub

    Sub ItemClick()
        For x As Integer = 0 To 5
            If ((ItemSprites(x).Bounds.Y + 60) >= Player.Bounds.Y And Player.Bounds.Y >= (ItemSprites(x).Bounds.Y - 60)) And ((ItemSprites(x).Bounds.X + 60) >= Player.Bounds.X And Player.Bounds.X >= (ItemSprites(x).Bounds.X - 60)) Then
                If ItemSprites(x).Tag = 7 Then
                    StoryItemClick(x)
                End If
            End If

        Next

    End Sub

    Sub EnemyClick()
        For x As Integer = 0 To EnemyCount
            If ((EnemySprites(x).Bounds.Y + 150) >= Player.Bounds.Y And Player.Bounds.Y >= (EnemySprites(x).Bounds.Y - 150)) And ((EnemySprites(x).Bounds.X + 150) >= Player.Bounds.X And Player.Bounds.X >= (EnemySprites(x).Bounds.X - 150)) Then
                Enemy(x).Hit(List)
            End If
        Next
    End Sub


    Sub CollisionDetection()

        For x As Integer = 0 To 99
            If grid(x).Tag = 1 Or grid(x).Tag = 5 Or grid(x).Tag = 7 Or grid(x).Tag = 8 Then
                If Player.Bounds.IntersectsWith(grid(x).Bounds) Then
                    Call CollisionType(1)
                End If
            ElseIf grid(x).Tag = 4 Or grid(x).Tag = 9 Then
                If Player.Bounds.IntersectsWith(grid(x).Bounds) Then
                    Call OverworldUpdate()
                End If
            End If
        Next

        For x As Integer = 0 To 2
            If EnemySprites(x).Tag = 6 Then
                If Player.Bounds.IntersectsWith(EnemySprites(x).Bounds) Then
                    Call CollisionType(1)
                End If
            End If
        Next

        For x As Integer = 0 To 2
            If ItemSprites(x).Tag = 1 Or ItemSprites(x).Tag = 7 Then
                If Player.Bounds.IntersectsWith(ItemSprites(x).Bounds) Then
                    Call CollisionType(1)
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
            Me.Player.Top += 210
        ElseIf Direction = 2 Then
            Me.Player.Left -= 350
        ElseIf Direction = 3 Then
            Me.Player.Top -= 210
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
            Me.Player.Image = My.Resources.Player_Connor
            If Direction = 2 Or Direction = 4 Then
                Me.Player.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Else
                Me.Player.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            End If
        End If
    End Sub

    Sub EnemyRead()

        Dim EnemyReader As System.IO.StreamReader

        For x As Integer = 1 To 4

            Dim Map As String = Nothing
            EnemyReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Liam Iverson\Desktop\DungeonCrawl\EnemyLocations\EnemySpawn" & x & ".txt")

            For y As Integer = 0 To 9
                EnemyMapLocation(x, y) = EnemyReader.ReadLine
                Map += EnemyMapLocation(x, y)
            Next

            For z As Integer = 0 To 89
                If Map.Chars(z) = "G" Then
                    EnemyCount += 1
                    Enemy(EnemyCount) = New Goblin
                    Enemy(EnemyCount).Create(grid(z).Location.X, grid(z).Location.Y, x, EnemyCount)
                ElseIf Map.Chars(z) = "W" Then
                    EnemyCount += 1
                    Enemy(EnemyCount) = New BrokenWall
                    Enemy(EnemyCount).Create(grid(z).Location.X, grid(z).Location.Y, x, EnemyCount)


                End If
            Next
        Next



    End Sub

    Sub EnemySpawn()
        For x As Integer = 0 To EnemyCount
            If Enemy(x).map = CurrentMap Then
                Enemy(x).Spawn(EnemySprites(x))
                Me.Controls.Add(EnemySprites(x))
                EnemySprites(x).BringToFront()
                EnemySprites(x).Tag = 6
            Else
                Enemy(x).Remove()
            End If
        Next
    End Sub

    Sub EnemyAI()
        For x As Integer = 0 To EnemyCount
            Enemy(x).Movement
            EnemyCollisionCheck(x)
            Enemy(x).StateCheck()
        Next
    End Sub

    Sub EnemyCollisionCheck(ByRef y As Integer)
        For x As Integer = 0 To 99
            If (grid(x).Tag = 4) Or (grid(x).Tag = 1) Then
                If EnemySprites(y).Bounds.IntersectsWith(grid(x).Bounds) Then
                    Enemy(y).CollisionDetection()
                End If
            End If
        Next
        If EnemySprites(y).Bounds.IntersectsWith(Player.Bounds) Then
            Enemy(y).CollisionDetection()
        End If
    End Sub

    Sub ItemSpawn()
        Dim StoryItem As Integer
        Dim Direction As Integer
        Dim Width As Integer
        Dim Height As Integer
        Dim ItemReader As System.IO.StreamReader
        ItemReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Liam Iverson\Desktop\DungeonCrawl\ItemLocations\ItemLocation" & CurrentMap & ".txt")
        For x As Integer = 0 To 5
            ItemSprites(x).Image = Nothing
            ItemSprites(x).Tag = 0
            ItemSprites(x).SendToBack()
        Next
        For x As Integer = 0 To 5
            Dim Item As String = ItemReader.ReadLine()
            If Item = Nothing Then
                Exit Sub
            Else
                If Item.Chars(0) = "1" Then
                    ItemSprites(x).Image = My.Resources.Couch
                ElseIf Item.Chars(0) = "2" Then
                    ItemSprites(x).Image = My.Resources.Counter
                ElseIf Item.Chars(0) = "3" Then
                    ItemSprites(x).Image = My.Resources.Table
                ElseIf Item.Chars(0) = "4" Then
                    ItemSprites(x).Image = My.Resources.Loose_Paper
                ElseIf Item.Chars(0) = "5" Then
                    ItemSprites(x).Image = My.Resources.Vet
                ElseIf Item.Chars(0) = "6" Then
                    ItemSprites(x).Image = My.Resources.Bed
                ElseIf Item.Chars(0) = "8" Then
                    ItemSprites(x).Image = My.Resources.Desk
                ElseIf Item.Chars(0) = "9" Then
                    ItemSprites(x).Image = My.Resources.Necronomicon1
                End If
                ItemSprites(x).BringToFront()

                StoryItem = Val(Item.Substring(20, 1))
                ItemSprites(x).Top = Val(Item.Substring(2, 3))
                ItemSprites(x).Left = Val(Item.Substring(6, 3))
                ItemSprites(x).Tag = 1

                Direction = Val(Item.Substring(18, 1))
                Width = Val(Item.Substring(10, 3))
                Height = Val(Item.Substring(14, 3))

                ItemRotation_Scale(Direction, ItemSprites(x), Width, Height)
                If StoryItem > 0 Then
                    StoryItemSpawn(ItemSprites, StoryItem, x)
                    ItemSprites(x).Tag = 7
                End If

            End If


        Next
    End Sub

    Sub ItemRotation_Scale(ByRef ItemDirection As Integer, ByRef ItemSprite As PictureBox, ByRef Width As Integer, ByRef Height As Integer)
        If ItemDirection = 1 Then
            ItemSprite.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            ItemSprite.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            ItemSprite.Height = Height
            ItemSprite.Width = Width
        ElseIf ItemDirection = 2 Then
            ItemSprite.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            ItemSprite.Width = Height
            ItemSprite.Height = Width
        ElseIf ItemDirection = 3 Then
            ItemSprite.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            ItemSprite.Height = Height
            ItemSprite.Width = Width
        ElseIf ItemDirection = 4 Then
            ItemSprite.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            ItemSprite.Width = Height
            ItemSprite.Height = Width
        End If
    End Sub

    Sub StoryItemSpawn(ByRef Sprite, ByRef StoryItemNum, ByRef x)
        StoryItem(x) = New StoryItemClass
        StoryItem(x).StoryItemSpawn(StoryItemNum)



    End Sub

    Sub StoryItemClick(ByRef x)
        StoryItem(x).ItemText(Command)
    End Sub
End Class