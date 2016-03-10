Public Class Chest
    Public locked As Boolean
    Public gold As Integer

    Sub Treasure()
        gold = ((10 * Rnd()) + 1)
    End Sub

End Class
