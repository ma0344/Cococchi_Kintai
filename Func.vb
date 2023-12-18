Imports System.Text
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.FileIO
Public Enum WriteMode
    overWrite = 0
    appendWrite = -1
End Enum
Module Func
    Public Function ReadCsv(ByVal astrFileName As String,
                         ByVal ablnTab As Boolean,
                         ByVal ablnQuote As Boolean) As String()()
        ReadCsv = Nothing
        'ファイルStreamReader
        Dim parser As TextFieldParser = Nothing
        Try
            'Shift-JISエンコードで変換できない場合は「?」文字の設定
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance) ' // memo: Shift-JISを扱うためのおまじない
            Dim encFallBack As New DecoderReplacementFallback("?")
            Dim enc As Encoding =
            Encoding.GetEncoding("shift_jis", EncoderFallback.ReplacementFallback, encFallBack)

            'TextFieldParserクラス
            '区切りの指定
            parser = New TextFieldParser(astrFileName, enc) With {
                .TextFieldType = FieldType.Delimited
            }
            If ablnTab = False Then
                'カンマ区切り
                parser.SetDelimiters(",")
            Else
                'タブ区切り
                parser.SetDelimiters(vbTab)
            End If

            If ablnQuote = True Then
                'フィールドが引用符で囲まれているか
                parser.HasFieldsEnclosedInQuotes = True
            End If

            'フィールドの空白トリム設定
            parser.TrimWhiteSpace = False

            Dim strArr()() As String = Nothing
            Dim nLine As Integer = 0
            'ファイルの終端までループ
            While Not parser.EndOfData
                'フィールドを読込
                Dim strDataArr As String() = parser.ReadFields()

                '戻り値領域の拡張
                ReDim Preserve strArr(nLine)

                '退避
                strArr(nLine) = strDataArr
                nLine += 1
            End While

            '正常終了
            Return strArr

        Catch ex As Exception
            'エラー
            MsgBox(ex.Message)
        Finally
            '閉じる
            If parser IsNot Nothing Then
                parser.Close()
            End If
        End Try
    End Function
    Public Function WriteCsv(ByVal astrFileName As String, ByVal aarrData As Object()(), Mode As writeMode) As Boolean
        WriteCsv = False
        'ファイルStreamWriter
        Dim sw As System.IO.StreamWriter = Nothing

        Try
            'CSVファイル書込に使うEncoding
            Dim enc As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
            '書き込むファイルを開く
            sw = New System.IO.StreamWriter(astrFileName, Mode, enc)
            Dim csvstr As String = Nothing
            For Each arrLine() As Object In aarrData
                csvstr = csvstr & (Join(arrLine, ",") & vbCrLf)
            Next
            'Stop
            sw.Write(csvstr)
            '正常終了
            Return True

        Catch ex As Exception
            'エラー
            MsgBox(ex.Message)
        Finally
            '閉じる
            If sw IsNot Nothing Then
                sw.Close()
            End If
        End Try
    End Function

End Module
Public Class TimeClass
    Public SH As String
    Public SM As String
    Public EH As String
    Public EM As String
End Class