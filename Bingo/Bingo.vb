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
        For i = 1 To 10

            DrawBall()
            DisplayBoard()
            Console.Read()
            Console.Clear()
        Next
    End Sub

    Sub DrawBall()
        Dim temp(,) As Boolean = BingoTracker(0, 0)
        Dim currentBallNumber As Integer
        Dim currentBallLetter As Integer

        Do

            currentBallNumber = RandomNumberBetween(0, 14) 'get row
            currentBallLetter = RandomNumberBetween(0, 4) 'get column

        Loop Until temp(currentBallNumber, currentBallLetter) = False
        BingoTracker(currentBallNumber, currentBallLetter)

        Console.WriteLine($"the current row is {currentBallNumber} and column is {currentBallLetter}")
    End Sub

    Function BingoTracker(ballNumber As Integer, ballLetter As Integer, Optional clear As Boolean = False) As Boolean(,)
        Static _bingoTracker(14, 4) As Boolean
        'actual code here
        _bingoTracker(ballNumber, ballLetter) = True
        Return _bingoTracker
    End Function

    Sub DisplayBoard()
        Dim temp As String = "  |"
        Dim heading() As String = {"B", "I", "N", "G", "O"}
        Dim tracker(,) As Boolean = BingoTracker(0, 0)
        For Each letter In heading
            Console.Write(letter.PadLeft(2).PadRight(4))
        Next
        Console.WriteLine()
        Console.WriteLine(StrDup(20, "_"))
        For currentNumber = 0 To 14
            For currentLetter = 0 To 4

                If tracker(currentNumber, currentLetter) Then
                    temp = "X |" 'display for drawn balls
                Else
                    temp = "" 'display for not drawn balls
                End If
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
        Return CInt(Math.Floor(temp))
    End Function
End Module
