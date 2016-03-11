Public Class Goblin
    Public Hp As Integer
    Public Attack As Integer
    Dim GoblinSprite As PictureBox
    Dim x As Integer = ((500 * Rnd()) + 1)
    Dim y As Integer = ((500 * Rnd()) + 1)

    Sub Spawn(ByRef Sprite As PictureBox)
        Randomize()
        Sprite = New PictureBox
        Sprite.Location = New Point(((500 * Rnd()) + 1), ((500 * Rnd()) + 1))
        Sprite.Size = New Size(50, 50)
        Sprite.BringToFront()
        Sprite.Image = My.Resources.Chest
        GoblinSprite = Sprite

    End Sub

    Sub Movement()
        x += 10
        GoblinSprite.Location = New Point(x, y)
    End Sub
End Class
