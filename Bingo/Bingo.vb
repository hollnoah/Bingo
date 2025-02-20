'Noah Holloway
'Bingo Game Program
'Clinet: Shady Acres
'Spring 2025

Option Strict On
Option Explicit On
Option Compare Text

'TODO
'[] Display Bingo Board
'[] Draw a random ball that has not already been drawn
'[] Update display to show all drawn balls
'[] Refresh tracking with "C" or when all balls have been drawn 


Module Bingo

    Sub Main()
        DisplayBoard()
    End Sub

    Sub DisplayBoard()
        Dim temp As String = "X  |"
        Dim heading() As String = {"B", "I", "N", "G", "O"}
        For Each letter In heading
            Console.Write(letter.PadLeft(2).PadRight(4))
        Next
        Console.WriteLine()
        Console.WriteLine(StrDup(20, "_"))
        For i = 1 To 15
            For j = 1 To 5
                temp = temp.PadLeft(3)
                Console.Write(temp)
            Next
            Console.WriteLine()
        Next
    End Sub
    Function RandomNumberBetween(min As Integer, max As Integer) As Integer
        Dim temp As Single
        Randomize()
        temp = Rnd()
        temp *= (max + 1) - min
        temp += min
        Return CInt(temp)
    End Function
End Module
