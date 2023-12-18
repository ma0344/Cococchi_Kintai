Imports System.Text
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.FileIO
Imports Newtonsoft.Json
Imports System.Windows.Forms.VisualStyles
''' <summary>
''' 勤務種別を指定する列挙体</summary>
Public Enum WorkType
    NoWork
    Nikkin
    Yakin
    Renkin
End Enum
Public Enum DType
    SDate
    WType
    NSTim
    NETim
    NType
    NEDat
    YSTim
    YETim
    YType
    YEDat
End Enum
Public Structure FormData
    Public NmIdx As Integer
    Public SName As String
    Public WType As WorkType
    Public SDate As Date
    Public STime As String
    Public SHour As String
    Public SMinu As String
    Public EDate As Date
    Public ETime As String
    Public EHour As String
    Public EMinu As String
    Public Btn As System.Windows.Forms.RadioButton
End Structure
Public Class MainForm

    Public Shared WDataStaffsList As New Dictionary(Of String, Object)()
    Public StInfo As New Dictionary(Of String, Object)()
    Public Shared WDSList As New List(Of String)
    Dim TC As New TimeClass
    Public Shared _MainForm As MainForm
    Public Shared _dgv As DataGridView
    Public Shared FD As FormData
    Public BeforSelectedCell As DataGridViewCell
    Public Shared ReadOnly Property VS As Rectangle
    Public Shared Property GVInstance() As DataGridView
        Get
            Return _dgv
        End Get
        Set(value As DataGridView)
            _dgv = value
        End Set
    End Property

    Public Shared Property MFInstance() As MainForm
        Get
            Return _MainForm
        End Get
        Set(ByVal Value As MainForm)
            _MainForm = Value
        End Set
    End Property
    Public ReadOnly Property Staffinf() As Object
        Get
            Return StInfo
        End Get
    End Property
    Public Shared arr()
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim arrCsv()() As String
            arrCsv = ReadCsv("Staffs.csv", False, False)
            For i = 0 To arrCsv.Length - 1
                StInfo.Add(arrCsv(i)(1), arrCsv(i))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim TD As Date = Now()
        PrevBtn.Text = "前月" & vbCrLf & "⋘"
        NextBtn.Text = "次月" & vbCrLf & "⋙"

        SDLabel.Tag = FirstDayOfPayTerm(TD)
        Dim t = SDLabel.Tag
        SDLabel.Text = CDate(SDLabel.Tag).ToString("D")
        EDLabel.Tag = EndDayOfPayTerm(TD)
        EDLabel.Text = CDate(EDLabel.Tag).ToString("D")
        Setup(CDate(EDLabel.Tag))
    End Sub
    Public Sub Setup(ByVal TD As Date)
        arr = ReadData(TD)
        For i = 0 To UBound(arr)
            If WDSList.Contains(arr(i)(0)(0)) <= 0 Then
                WDSList.Add(arr(i)(0)(0))
                EditorForm.NameBox.Items.Add(WDSList(WDSList.Count - 1))
            End If
        Next
        Call DGV_Set(TD)

        For i = 0 To 24
            EditorForm.STH.Items.Add(CStr(i))
            EditorForm.EDH.Items.Add(CStr(i))
        Next i
        For i = 0 To 45 Step 15
            EditorForm.STM.Items.Add(Strings.Right("0" & CStr(i), 2))
            EditorForm.EDM.Items.Add(Strings.Right("0" & CStr(i), 2))
        Next i
        MainForm.MFInstance = Me
        mdgv.Rows(0).HeaderCell.Style.BackColor = Color.LightBlue
        'mdgv.AutoResizeRows()
        'mdgv.AutoResizeColumnHeadersHeight()

    End Sub
    Public Sub DGV_Set(ByVal td As Date)
        Dim EDt = EndDayOfPayTerm(td)
        Dim SDt = FirstDayOfPayTerm(td)
        Dim MxDt = DateDiff(DateInterval.Day, SDt, EDt) + 1
        Dim DTable As New DataTable With {.TableName = "DTable"}
        SDLabel.Text = SDt.ToString("yyyy年") & SDt.ToString("M")
        '列ラベルの設定
        For i = 0 To MxDt - 1
            Dim TC As String = DateAdd(DateInterval.Day, i, SDt).ToString("M/d")
            Dim d As String = DateAdd(DateInterval.Day, i, SDt).ToString("(ddd)")
            TC = TC & vbCrLf & d
            DTable.Columns.Add(TC.ToString, Type.GetType("System.String"))
        Next
        'カレンダー表示内容設定
        Dim x As Integer
        For i = 0 To UBound(arr)
            Dim RowArr()
            ReDim RowArr(MxDt - 1)
            Dim mark As String
            For x = 0 To MxDt - 1
                Select Case CInt(arr(i)(x + 1)(1))
                    Case WorkType.Nikkin
                        mark = "◎"
                    Case WorkType.Yakin
                        mark = "○"
                    Case WorkType.Renkin
                        mark = "◓"
                    Case Else
                        mark = ""
                End Select
                RowArr(x) = mark
            Next
            Dim DRow As DataRow = DTable.NewRow
            DRow.ItemArray = RowArr
            DTable.Rows.Add(DRow)
        Next

        mdgv.AllowUserToAddRows = False
        mdgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        mdgv.ColumnHeadersHeight = 50
        mdgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        mdgv.ColumnHeadersDefaultCellStyle.Padding = New Padding(0, 0, 0, 0)
        'mdgv.AutoResizeColumnHeadersHeight()
        With mdgv.DefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font("HG丸ｺﾞｼｯｸM-PRO", 18)
            .Padding = New Padding(0, 0, 0, 0)
            .WrapMode = DataGridViewTriState.False
            .Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
        mdgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

        mdgv.DataSource = DTable
        For i = 0 To UBound(arr)
            Dim PMData As New Dictionary(Of String, Object)()
            For x = 1 To MxDt
                With mdgv.Rows(i).Cells(x - 1)
                    .Tag = Arr2DDCls(arr(i)(x))
                    .ToolTipText = Join(arr(i)(x), vbCrLf)

                    Dim d As String = .Tag.SDate
                    If CDate(.Tag.SDate).DayOfWeek = DayOfWeek.Saturday Then
                        .Style.BackColor = Color.LightCyan
                    ElseIf CDate(.Tag.SDate.ToString).DayOfWeek = DayOfWeek.Sunday Then
                        .Style.BackColor = Color.LavenderBlush
                    End If
                End With
            Next
            mdgv.Rows(i).HeaderCell.Value = EditorForm.NameBox.Items(i)
            mdgv.Rows(i).Height = 40

        Next
        Dim h As Integer = mdgv.ColumnHeadersHeight + mdgv.Rows(0).Height * arr.Length
        Dim w As Integer = 0
        Dim c As DataGridViewColumn
        For Each c In mdgv.Columns
            If InStr(c.HeaderText, "土") Then
                c.HeaderCell.Style.BackColor = Color.LightCyan
            ElseIf InStr(c.HeaderText, "日") Then
                c.HeaderCell.Style.BackColor = Color.LavenderBlush
            End If
            c.Width = 39

            c.Name = DateAndTime.Day(DateAdd(DateInterval.Day, CDbl(c.Index), SDt)) 'CStr(i)
            c.SortMode = DataGridViewColumnSortMode.NotSortable
            w += c.Width
        Next
        Dim GVWidth As Integer = mdgv.RowHeadersWidth + w
        mdgv.Height = h
        Me.Height = mdgv.Top + h + 0
        mdgv.Width = GVWidth
        'Debug.Print(Me.Width)
        'CABtn.Left = mdgv.Width - CABtn.Width - 8
        'OKBtn.Left = CABtn.Left - OKBtn.Width - 8
        'DelBtn.Left = OKBtn.Left - DelBtn.Width - 8

    End Sub
    Private Sub Mdgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles mdgv.CellDoubleClick
        Dim dgv As DataGridView = sender
        If e.ColumnIndex = -1 Or e.RowIndex = -1 Then Exit Sub
        Dim DDCls As DDClass = mdgv.SelectedCells(0).Tag
        Dim CC As DataGridViewCell = dgv.CurrentCell
        Dim CCTag As DDClass = CC.Tag
        Dim locate As System.Drawing.Point = CC.AccessibilityObject.Bounds.Location
        Dim rec = DDCls.DDCls2Arr(DDCls)
        '現在フォームが存在しているディスプレイを取得
        Dim sc As System.Windows.Forms.Screen = System.Windows.Forms.Screen.FromControl(Me)
        'ディスプレイの高さと幅を取得
        Dim sch As Integer = sc.WorkingArea.Height
        Dim scw As Integer = sc.WorkingArea.Width

        With EditorForm
            Dim le = locate.X - .OKBtn.Left - (.OKBtn.Width / 2) + (CC.Size.Width / 2)
            If le + .Width > scw Then le = scw - .Width
            Dim tp = locate.Y - .OKBtn.Top - (.OKBtn.Height) + (CC.Size.Height / 2)
            If tp + .Height > sch Then tp = sch - .Height
            .Location = New Point(le, tp)
            If EditorForm.ShowDialog(Me) = DialogResult.OK Then

            End If
        End With
        Cellchange()
    End Sub

    Private Sub CABtn_Click(sender As Object, e As EventArgs) Handles CABtn.Click
        End
    End Sub

    Private Sub DelBtn_Click(sender As Object, e As EventArgs) Handles DelBtn.Click
        DelRec()
    End Sub
    Public Sub DelRec()
        Dim CC As DataGridViewCell = Me.mdgv.CurrentCell
        Dim CCTag As DDClass = CC.Tag
        Dim ch As WorkType

        If CCTag.WType = 3 Then
            ch = Choice()
            If ch = DialogResult.No Then Exit Sub
        Else
            ch = CInt(CCTag.WType)
        End If

        If MsgBox("選択中の勤務記録を削除します", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            DelCCTag(ch)
            Cellchange()
            Save()
        End If

    End Sub
    Public Function DelCCTag(ByVal WT As WorkType) As WorkType
        With Me.mdgv.CurrentCell.Tag
            If WT = WorkType.Nikkin Then
                .NSTim = ""
                .NETim = ""
                .NType = ""
                .NEDat = ""
            ElseIf WT = WorkType.Yakin Then
                .YSTim = ""
                .YETim = ""
                .YType = ""
                .YEDat = ""
            End If
            .WType = .wtype - WT
            Me.mdgv.CurrentCell.Value = EditorForm.GetMark(.WType)
            Dim DC As DDClass = Me.mdgv.CurrentCell.Tag
            Me.mdgv.CurrentCell.ToolTipText = Join(DC.DDCls2Arr(DC), vbCrLf)
            Return .WType
        End With
    End Function
    Private Function Choice() As Integer
        Dim c As New ChoiceForm
        Dim CC As DataGridViewCell = mdgv.CurrentCell
        Dim lo As System.Drawing.Point = DelBtn.AccessibilityObject.Bounds.Location

        With c
            .Left = lo.X + (DelBtn.Width / 2) - (c.Width / 2)
            .Top = lo.Y + DelBtn.Height
            '.Top = DelBtn.Top + DelBtn.Height
            '.Left = DelBtn.Left + (DelBtn.Width / 2) - (c.Width / 2)
            .Text = "勤務の選択"
            .Label1.Text = "削除する勤務を選択してください"
            .FstBtn.Text = "日　勤"
            .SecBtn.Text = "夜　勤"
            Return .ShowDialog(Me)
        End With
    End Function

    Private Sub Mdgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles mdgv.CellClick
        If mdgv.CurrentCell.Value = "" Then DelBtn.Enabled = False Else DelBtn.Enabled = True
    End Sub

    Private Sub Mdgv_SelectionChanged(sender As Object, e As EventArgs) Handles mdgv.SelectionChanged
        Cellchange()
    End Sub
    Private Sub Cellchange()
        If mdgv.CurrentCell Is Nothing Then Exit Sub
        If mdgv.CurrentCell.Value = "" Then DelBtn.Enabled = False Else DelBtn.Enabled = True
        Dim T As DDClass = mdgv.CurrentCell.Tag
        If T IsNot Nothing Then
            Me.NameLabel.Text = mdgv.Rows(mdgv.CurrentCell.RowIndex).HeaderCell.Value.ToString
            Me.DateLabel.Text = CDate(T.SDate).ToString("D") & CDate(T.SDate).ToString("(ddd)")
            Me.NSTLabel.Text = T.NSTim
            Me.NETLabel.Text = T.NETim
            Me.YSTLabel.Text = T.YSTim
            Me.YETLabel.Text = T.YETim
        End If
        Dim c As DataGridViewColumn = mdgv.Columns(mdgv.CurrentCell.ColumnIndex)
        Dim cr As DataGridViewRow = mdgv.Rows(mdgv.CurrentCell.RowIndex)
        If BeforSelectedCell IsNot Nothing Then
            If BeforSelectedCell.RowIndex >= 0 Then
                Dim b As DataGridViewColumn = mdgv.Columns(BeforSelectedCell.ColumnIndex)
                Dim br As DataGridViewRow = mdgv.Rows(BeforSelectedCell.RowIndex)
                If InStr(b.HeaderText, "土") Then
                    b.HeaderCell.Style.BackColor = Color.LightCyan
                ElseIf InStr(b.HeaderText, "日") Then
                    b.HeaderCell.Style.BackColor = Color.LavenderBlush
                Else b.HeaderCell.Style.BackColor = mdgv.ColumnHeadersDefaultCellStyle.BackColor
                End If
                br.HeaderCell.Style.BackColor = mdgv.RowHeadersDefaultCellStyle.BackColor
                cr.HeaderCell.Style.BackColor = Color.LightBlue
            Else
            End If
        End If
        c.HeaderCell.Style.BackColor = Color.LightBlue
        BeforSelectedCell = mdgv.CurrentCell
    End Sub
    Private Sub NextBtn_Click(sender As Object, e As EventArgs) Handles NextBtn.Click
        SDLabel.Tag = DateAdd(DateInterval.Day, 1, CDate(EDLabel.Tag))
        SDLabel.Text = CDate(SDLabel.Tag).ToString("D")
        EDLabel.Tag = EndDayOfPayTerm(DateAdd(DateInterval.Month, 1, CDate(EDLabel.Tag)))
        EDLabel.Text = CDate(EDLabel.Tag).ToString("D")
        Setup(CDate(EDLabel.Tag))
    End Sub

    Private Sub PrevBtn_Click(sender As Object, e As EventArgs) Handles PrevBtn.Click
        EDLabel.Tag = DateAdd(DateInterval.Day, -1, CDate(SDLabel.Tag))
        EDLabel.Text = CDate(EDLabel.Tag).ToString("D")
        SDLabel.Tag = FirstDayOfPayTerm(DateAdd(DateInterval.Month, -1, CDate(SDLabel.Tag)))
        SDLabel.Text = CDate(SDLabel.Tag).ToString("D")
        Setup(CDate(EDLabel.Tag))

    End Sub

    Private Sub OKBtn_Click(sender As Object, e As EventArgs)
        Save()
    End Sub
End Class
