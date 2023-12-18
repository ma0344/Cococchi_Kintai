Public Class DDClass
    Public SDate As String
    Public WType As String
    Public NSTim As String
    Public NETim As String
    Public NType As String
    Public NEDat As String
    Public YSTim As String
    Public YETim As String
    Public YType As String
    Public YEDat As String
    Public Function setCls(ByRef CCTag As DDClass, ByVal FD As FormData) As DDClass
        Select Case CInt(CCTag.WType)
            Case 1
                CCTag.WType = CCTag.WType Or CInt(FD.WType)
                CCTag.NSTim = FD.STime.ToString
                CCTag.NETim = FD.ETime.ToString
                CCTag.NType = "日勤"
            Case 2
                CCTag.WType = CCTag.WType Or CInt(FD.WType)
                CCTag.YSTim = FD.STime.ToString
                CCTag.YETim = FD.ETime.ToString
                CCTag.YType = "夜勤"
        End Select
        Return CCTag
    End Function
    Public Function Arr2DDCls(ByVal AR) As DDClass
        With Me
            .SDate = AR(DType.SDate).ToString
            .WType = AR(DType.WType).ToString
            .NSTim = AR(DType.NSTim).ToString
            .NETim = AR(DType.NETim).ToString
            .NType = AR(DType.NType).ToString
            .NEDat = AR(DType.NEDat).ToString
            .YSTim = AR(DType.YSTim).ToString
            .YETim = AR(DType.YETim).ToString
            .YType = AR(DType.YType).ToString
            .YEDat = AR(DType.YEDat).ToString
        End With
        Return Me
    End Function
    Public Function DDCls2Arr(ByVal DDCls As DDClass)
        Dim ret(9)
        With DDCls
            ret(DType.SDate) = .SDate
            ret(DType.WType) = .WType
            ret(DType.NSTim) = .NSTim
            ret(DType.NETim) = .NETim
            ret(DType.NType) = .NType
            ret(DType.NEDat) = .NEDat
            ret(DType.YSTim) = .YSTim
            ret(DType.YETim) = .YETim
            ret(DType.YType) = .YType
            ret(DType.YEDat) = .YEDat
        End With
        Return ret
    End Function

End Class
