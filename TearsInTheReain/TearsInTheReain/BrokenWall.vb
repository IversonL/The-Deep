Public Class BrokenWall
    Public Hp As Integer
    Public Attack As Integer
    Public WallSprite As PictureBox = New PictureBox
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
        Hp = 10
    End Sub

    Sub StateCheck()
        If Hp < 1 Then
            IsAlive = False
            Remove()
        End If
    End Sub

    Sub Spawn(ByRef Sprite As PictureBox)
        If IsAlive = True Then
            WallSprite.Visible = True
            Sprite.Location = New Point(XPos, YPos)
            Sprite.Size = New Size(50, 50)
            Sprite.BringToFront()
            Sprite.Image = My.Resources.Brickwall_Connor
            WallSprite = Sprite
            WallSprite.Tag = 6
        Else
            Remove()
        End If


    End Sub

    Sub Remove()
        WallSprite.Visible = False
        WallSprite.Tag = 0
        WallSprite.SendToBack()
    End Sub

    Sub Movement()

    End Sub

    Sub CollisionDetection()

    End Sub

    Sub GoblinAttack()

    End Sub

    Sub Hit(ByRef Label As Label)
        EnemyHit = 5 * Rnd()
        Hp -= EnemyHit
        CommandUpdate(Label)
    End Sub

    Sub ImageUpdate()

    End Sub

    Sub CommandUpdate(ByRef Label As Label)

    End Sub
End Class
