Public Class StoryItemClass
    Public Name As String
    Dim ItemReader As System.IO.StreamReader
    Dim Num As Integer
    Sub StoryItemSpawn(ByRef StoryItemNum)
        Num = StoryItemNum
        ItemReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Liam Iverson\Desktop\DungeonCrawl\StoryItems\StoryItem" & StoryItemNum & ".txt")
        Name = ItemReader.ReadLine
    End Sub

    Sub ItemText(ByRef Label As Label)
        ItemReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Liam Iverson\Desktop\DungeonCrawl\StoryItems\StoryItem" & Num & ".txt")
        Label.Text = Nothing
        For x As Integer = 0 To 20
            Label.Text &= ItemReader.ReadLine & vbCrLf
        Next
        ItemReader.Close()
    End Sub
End Class
