Public Class Goblin
    Public Hp As Integer
    Public Attack As Integer
    Public GoblinSprite As PictureBox = New PictureBox
    Public XPos As Integer
    Public YPos As Integer
    Public Map As Integer
    Public ID As Integer
    Public Rand As Integer
    Public Direction As Integer
    Public EnemyHit As Integer
    Public IsAlive As Boolean = True

    Sub Create(ByRef X, ByRef Y, ByRef CurrentMap, ByRef CurrentEnemy)
        XPos = X
        YPos = Y
        Map = CurrentMap
        ID = CurrentEnemy
        Randomize()
        Hp = 10 * Rnd()


    End Sub
    Sub StateCheck()
        If Hp < 1 Then
            IsAlive = False
            Remove()
        End If
    End Sub

    Sub Spawn(ByRef Sprite As PictureBox)
        If IsAlive = True Then
            GoblinSprite.Visible = True
            Sprite.Location = New Point(XPos, YPos)
            Sprite.Size = New Size(50, 50)
            Sprite.BringToFront()
            Sprite.Image = My.Resources.Goblin
            GoblinSprite = Sprite
            GoblinSprite.Tag = 6
        Else
            Remove()
        End If


    End Sub

    Sub Remove()
        GoblinSprite.Visible = False
        GoblinSprite.Tag = 0
        GoblinSprite.SendToBack()
    End Sub

    Sub Movement()
        Randomize()
        Direction = (Rnd() * 4) + 1
        If Direction = 1 Then
            Me.GoblinSprite.Top += 10
        ElseIf Direction = 2 Then
            Me.GoblinSprite.Left -= 10
        ElseIf Direction = 3 Then
            Me.GoblinSprite.Top -= 10
        ElseIf Direction = 4 Then
            Me.GoblinSprite.Left += 10
        End If
    End Sub

    Sub CollisionDetection()
        If Direction = 1 Then
            Me.GoblinSprite.Top -= 10
        ElseIf Direction = 2 Then
            Me.GoblinSprite.Left += 10
        ElseIf Direction = 3 Then
            Me.GoblinSprite.Top += 10
        ElseIf Direction = 4 Then
            Me.GoblinSprite.Left -= 10
        End If
    End Sub

    Sub GoblinAttack()

    End Sub

    Sub GoblinHit(ByRef Label As Label)
        EnemyHit = 5 * Rnd()
        Hp -= EnemyHit
        CommandUpdate(Label)
    End Sub

    Sub ImageUpdate()

    End Sub

    Sub CommandUpdate(ByRef Label As Label)
        Label.Text &= "Goblin hit for: " & EnemyHit & vbCrLf & "Enemy Health: " & Hp & vbCrLf
    End Sub
End Class
