Module MainModule
    Dim MFI As MainForm.ControlCollection
    Dim MFIC As MainForm.ControlAccessibleObject
    Dim StInfo = MainForm.Staffinf
    Public Sub Save()
        WriteCsv(GetFilename(MainForm.EDLabel.Tag), DGV_To_Arr(), WriteMode.overWrite)
    End Sub

    Public Function DGV_To_Arr() As Object()()
        Dim dgv As DataGridView = MainForm.mdgv
        Dim colCount As Integer = dgv.Columns.Count
        Dim rowCount As Integer = dgv.Rows.Count * 10 - 1
        Dim RetArr(rowCount)()
        For ret = 0 To rowCount
            RetArr(ret) = New String(colCount) {}
        Next
        Dim c As DataGridViewColumn
        Dim r As DataGridViewRow
        For Each c In dgv.Columns
            For Each r In dgv.Rows
                Dim TagArr As Array = DDCls2Arr(r.Cells(c.Index).Tag)
                r.HeaderCell.Value.ToString()

                For i = 0 To UBound(TagArr)
                    RetArr(r.Index * 10 + i)(c.Index + 1) = TagArr(i).ToString
                Next
            Next
        Next
        For Each r In dgv.Rows
            For i = 0 To 9
                RetArr(r.Index * 10 + i)(0) = r.HeaderCell.Value
            Next
        Next
        'Stop
        Return RetArr

    End Function

    Public Function ReadData(ByVal TDate As Date)
        Dim FName As String = GetFilename(TDate)
        If Not System.IO.File.Exists(FName) Then MakeNewFile(TDate)
        Dim arrCsv()() As String
        Dim DayArr()
        Dim MonthArr()
        Dim reformArr()
        Dim RetArr() = Nothing
        Try
            arrCsv = ReadCsv(FName, False, False)
            ReDim reformArr((arrCsv.Length / 10) - 1)
            ReDim DayArr(9)
            ReDim MonthArr(arrCsv(0).Length - 1)
            ReDim RetArr(((arrCsv.Length) / 10) - 1)
            For s = 0 To (arrCsv.Length / 10) - 1
                For c = 0 To UBound(arrCsv(0))
                    For r = 0 To 9
                        'Stop
                        DayArr(r) = arrCsv(s * 10 + r)(c)
                        'reformArr(s + 1)(s * 9 + c)(c) = arrCsv(s * 9 + c)(c)
                    Next
                    MonthArr(c) = DayArr
                    ReDim DayArr(9)
                Next
                RetArr(s) = MonthArr
                ReDim MonthArr(arrCsv(0).Length - 1)
            Next
            Return RetArr
        Catch ex As Exception
            MsgBox(ex.Message)
            Return RetArr
        End Try
    End Function
    Public Function GetFilename(ByVal TargetDate As Date) As String
        Dim YVal As String = Year(TargetDate).ToString
        Dim MVal As String = Format(Month(TargetDate), "00")
        Return "ここっち勤怠記録V2_" & YVal & MVal & ".csv"
    End Function
    Public Function WTTransfer(ByVal WT As WorkType) As String
        Dim ret As String = 0
        Select Case WT
            Case WorkType.NoWork
                ret = ""
            Case WorkType.Nikkin
                ret = "日勤"
            Case WorkType.Yakin
                ret = "夜勤"
            Case WorkType.Renkin
                ret = "連勤"
        End Select
        Return ret
    End Function

    Public Function DDCls2Arr(ByVal DDCls As DDClass)
        Dim ret(9)
        ret(DType.SDate) = DDCls.SDate
        ret(DType.WType) = DDCls.WType
        ret(DType.NSTim) = DDCls.NSTim
        ret(DType.NETim) = DDCls.NETim
        ret(DType.NType) = DDCls.NType
        ret(DType.NEDat) = DDCls.NEDat
        ret(DType.YSTim) = DDCls.YSTim
        ret(DType.YETim) = DDCls.YETim
        ret(DType.YType) = DDCls.YType
        ret(DType.YEDat) = DDCls.YEDat
        Return ret
    End Function
    Public Function Arr2DDCls(ByVal AR) As DDClass
        Dim ret As New DDClass With {
            .SDate = AR(DType.SDate).ToString,
            .WType = AR(DType.WType).ToString,
            .NSTim = AR(DType.NSTim).ToString,
            .NETim = AR(DType.NETim).ToString,
            .NType = AR(DType.NType).ToString,
            .NEDat = AR(DType.NEDat).ToString,
            .YSTim = AR(DType.YSTim).ToString,
            .YETim = AR(DType.YETim).ToString,
            .YType = AR(DType.YType).ToString,
            .YEDat = AR(DType.YEDat).ToString
        }
        Return ret
    End Function
    Public Function FirstDayOfPayTerm(ByVal TD As Date) As Date
        Return DateSerial(Year(DateAdd(DateInterval.Month, -1, MonthOfPayTterm(TD))), Month(DateAdd(DateInterval.Month, -1, MonthOfPayTterm(TD))), 16)
    End Function
    Public Function EndDayOfPayTerm(ByVal TD As Date) As Date
        Return DateSerial(Year(MonthOfPayTterm(TD)), Month(MonthOfPayTterm(TD)), 15)
    End Function
    Public Function MonthOfPayTterm(ByVal TD As Date)
        Return EOMonth(DateAdd(DateInterval.Month, 1, DateAdd(DateInterval.Day, -15, TD)))
    End Function
    Public Function EOMonth(Target As Date) As Date
        Return DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateSerial(Year(Target), Month(Target), 1)))
    End Function
    Public Sub MakeNewFile(ByVal TDate As Date)
        Dim STI = MainForm.Staffinf
        Dim SD As Date = FirstDayOfPayTerm(TDate)
        Dim ED As Date = EndDayOfPayTerm(TDate)
        Dim FName As String = GetFilename(ED)
        Dim Diff As Integer = DateDiff(DateInterval.Day, SD, ED)
        Dim ArrStr As String
        Dim ArrStr2 As String
        Dim CSVArr As String = ""
        For Each K In STI.Keys
            ArrStr = K
            ArrStr2 = K
            For D = 0 To Diff
                ArrStr &= "," & DateAdd(DateInterval.Day, D, SD)
                ArrStr2 &= ",0"
            Next
            ArrStr = ArrStr & ControlChars.CrLf & ArrStr2 & ControlChars.CrLf
            ArrStr2 = K & StrDup(Diff + 1, ",") & ControlChars.CrLf
            For d = 1 To 3
                ArrStr2 &= ArrStr2
            Next
            ArrStr &= ArrStr2
            CSVArr &= ArrStr
        Next
        Dim sw As New System.IO.StreamWriter(FName, False, Text.Encoding.GetEncoding("shift_jis"))
        sw.Write(CSVArr.ToString)
        sw.Close()
    End Sub
End Module
