'Noah Holloway
'Bingo Game Program
'Clinet: Shady Acres
'Spring 2025

Option Strict On
Option Explicit On
Option Compare Text

'TODO
'[x] Display Bingo Board
'[x] Draw a random ball that has not already been drawn
'[x] Update display to show all drawn balls
'[] Update display to show actual ball number
'[] Refresh tracking with "C" or when all balls have been drawn 


Module Bingo

    Sub Main()
        Dim userInput As String

        Do
            Console.Clear()
            DisplayBoard()
            Console.WriteLine()
            'prompt
            userInput = Console.ReadLine()

            Select Case userInput
                Case "d" 'draw ball
                    DrawBall()
                Case "c" 'clear/ new game
                    BingoTracker(0, 0,, True)
                Case Else
                    'pass
            End Select

        Loop Until userInput = "q" 'quit

        Console.Clear()
        Console.WriteLine("Have a nice day!")
    End Sub

    Sub DrawBall(Optional clearCount As Boolean = False)
        Dim temp(,) As Boolean = BingoTracker(0, 0)
        Dim currentBallNumber As Integer
        Dim currentBallLetter As Integer
        Static ballCounter As Integer

        If clearCount Then

            ballCounter = 0

        Else

            Do
                currentBallNumber = RandomNumberBetween(0, 14) 'get row
                currentBallLetter = RandomNumberBetween(0, 4) 'get column
            Loop Until temp(currentBallNumber, currentBallLetter) = False Or ballCounter >= 75
            BingoTracker(currentBallNumber, currentBallLetter, True)
            ballCounter += 1
            Console.WriteLine($"the current column is {currentBallLetter} and row is {currentBallNumber}")

        End If

    End Sub
    ''' <summary>
    ''' Contains a persistent array that tracks all possible bingo balls 
    ''' and whether they have been drawn during the current game.
    ''' </summary>
    ''' <param name="ballNumber"></param>
    ''' <param name="ballLetter"></param>
    ''' <param name="clear"></param>
    ''' <returns>Current Tracking Array</returns>
    Function BingoTracker(ballNumber As Integer, ballLetter As Integer, Optional update As Boolean = False, Optional clear As Boolean = False) As Boolean(,)
        Static _bingoTracker(14, 4) As Boolean

        If update Then
            _bingoTracker(ballNumber, ballLetter) = True
        End If

        If clear Then
            ReDim _bingoTracker(14, 4) 'clears the array. could also loop through array and set all elements to false.
        End If

        Return _bingoTracker
    End Function
    ''' <summary>
    ''' Iterates through the tracker array and displays bingoboard to the console
    ''' </summary>
    Sub DisplayBoard()
        Dim displayString As String = "  |"
        Dim heading() As String = {"B", "I", "N", "G", "O"}
        Dim tracker(,) As Boolean = BingoTracker(0, 0)
        Dim columnWidth As Integer = 5
        For Each letter In heading
            Console.Write(letter.PadLeft(CInt(Math.Ceiling((columnWidth / 2)))).PadRight(columnWidth))
        Next
        Console.WriteLine()
        Console.WriteLine(StrDup(columnWidth * 5, "_"))
        For currentNumber = 0 To 14
            For currentLetter = 0 To 4

                If tracker(currentNumber, currentLetter) Then
                    displayString = $" {FormatBallNumber(currentNumber, currentLetter)} |" 'display for drawn balls
                Else
                    displayString = "   |" 'display for not drawn balls
                End If
                displayString = displayString.PadLeft(columnWidth)
                Console.Write(displayString)
            Next
            Console.WriteLine()
        Next
        Console.WriteLine(vbNewLine & StrDup(20, "_"))
    End Sub

    Function FormatBallNumber(ballNumber As Integer, ballLetter As Integer) As String
        Dim _ballNumber As String
        _ballNumber = CStr((ballNumber + 1) + (ballLetter * 15))

        Return _ballNumber

    End Function
    Function RandomNumberBetween(min As Integer, max As Integer) As Integer
        Dim temp As Single
        Randomize()
        temp = Rnd()
        temp *= (max + 1) - min
        temp += min
        Return CInt(Math.Floor(temp))
    End Function
End Module
