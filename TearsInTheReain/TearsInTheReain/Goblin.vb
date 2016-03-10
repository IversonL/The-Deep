Public Class Goblin
    Public Hp As Integer
    Public Attack As Integer

    Sub Spawn(ByRef Enemy As PictureBox)
        Enemy = New PictureBox
        Enemy.Location = New Point(10, 10)
        Enemy.Size = New Size(50, 50)
        Enemy.Image = My.Resources.Chest

    End Sub
End Class
