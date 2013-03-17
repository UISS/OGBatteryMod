Module SharedCode

    Public Function JustAfter(ByVal Str As String, ByVal Seq As String, ByVal SeqEnd As String) As String
        Dim Orgi As String = Str
        Try
            Str = Str.ToLower()
            Seq = Seq.ToLower()
            SeqEnd = SeqEnd.ToLower()

            Dim i As Integer = Str.IndexOf(Seq)

            If i < 0 Then
                Return Nothing
            End If

            i = i + Seq.Length

            Dim j As Integer = Str.IndexOf(SeqEnd, i)
            Dim [end] As Integer

            If j > 0 Then
                [end] = j - i
            Else
                [end] = Str.Length - i
            End If

            Return Orgi.Substring(i, [end])
        Catch generatedExceptionName As Exception
            Return ""
        End Try
    End Function

    Public Function ReadLines(ByVal Text As String) As String()
        Dim num2 As Integer
        Dim list As New ArrayList
        Dim i As Integer = 0
        Do While (i < [Text].Length)
            num2 = i
            Do While (num2 < [Text].Length)
                Dim ch As Char = [Text].Chars(num2)
                If ((ch = ChrW(13)) OrElse (ch = ChrW(10))) Then
                    Exit Do
                End If
                num2 += 1
            Loop
            Dim str2 As String = [Text].Substring(i, (num2 - i))
            list.Add(str2)
            If ((num2 < [Text].Length) AndAlso ([Text].Chars(num2) = ChrW(13))) Then
                num2 += 1
            End If
            If ((num2 < [Text].Length) AndAlso ([Text].Chars(num2) = ChrW(10))) Then
                num2 += 1
            End If
            i = num2
        Loop
        If (([Text].Length > 0) AndAlso (([Text].Chars(([Text].Length - 1)) = ChrW(13)) OrElse ([Text].Chars(([Text].Length - 1)) = ChrW(10)))) Then
            list.Add("")
        End If
        Return DirectCast(list.ToArray(GetType(String)), String())
    End Function

    Public Function ReadFiles(ByVal str As String, ByVal Types As String()) As String()
        Dim lst As New List(Of String)
        str = str.Replace(" ", vbNewLine)
        For Each Line In ReadLines(str)
            For Each Type In Types
                If Line.Trim.ToLower.EndsWith(Type) Then
                    lst.Add(Line.Trim)
                    Exit For
                End If
            Next   
        Next
        Return lst.ToArray
    End Function
End Module
