Enum CFormType
    YKN_OR_NKN
    ADD_OR_EDIT
End Enum
Enum InputType
    NewDt
    Edit
    AddDt
End Enum
Public Class EditorForm
    Dim StInfo = MainForm.Staffinf
    Dim FD As FormData = MainForm.FD
    Dim CC As DataGridViewCell
    Dim CCTag As DDClass
    Dim dgv As DataGridView
    Public NMBoxCount As Integer
    Public Shared _EditorForm As EditorForm
    Public Shared Property EFInstance() As EditorForm
        Get
            Return _EditorForm
        End Get
        Set(ByVal Value As EditorForm)
            _EditorForm = Value
        End Set
    End Property
    Public ReadOnly Property NameBoxCount() As Object
        Get
            Return Me.NameBox.Items.Count
        End Get
    End Property
    Public Sub EditorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv = MainForm.mdgv
        CC = dgv.CurrentCell
        CCTag = CC.Tag
        NameBox.Enabled = False
        NameBox.ForeColor = SystemColors.WindowText
        NameBox.BackColor = SystemColors.Window
        Call FormLocation()
        Dim ch As DialogResult = DialogResult.None
        If CCTag.WType = WorkType.NoWork Then 'セルが空
            SetNewRec(WorkType.NoWork)
        Else
            If CCTag.WType = WorkType.Renkin Then 'CCTag.WType = 3(連勤) 選択セルが連勤であるか 
                ch = choice(CFormType.YKN_OR_NKN) '編集対象選択 日勤 OR 夜勤
                SetEditRec(ch)
            Else 'CCTag.WType = 1 OR 2 選択したセルが日勤か夜勤の場合の処理
                ch = choice(CFormType.ADD_OR_EDIT) '選択した既存勤務セルの 編集 OR 追加
                If ch = InputType.Edit Then '選択結果(ch)が編集の処理 
                    SetEditRec(CInt(CCTag.WType))
                Else 'ch = inputtype.AddDt 選択結果(ch)が追加の処理
                    SetNewRec(CInt(CCTag.WType))
                End If
            End If
        End If
        If ch = DialogResult.No Then Me.Close()
    End Sub
    Public Sub FormLocation()
        Dim scrBnd As Rectangle = System.Windows.Forms.Screen.GetWorkingArea(MainForm)
        'ディスプレイの高さと幅を取得
        Dim Val As Rectangle = SystemInformation.VirtualScreen

        With Me
            If .Top < Val.Top Then .Top = 0
            If .Left < Val.Left Then .Left = 0
            If .Left + .Width > scrBnd.Width Then .Left = scrBnd.Width - .Width
            If .Top + Height > scrBnd.Height Then .Top = scrBnd.Height - .Height
        End With
    End Sub
    ''' ---------------------------------------------------------------------------------------
    ''' <summary>
    ''' EditrFormに新しい勤務データをセットします
    ''' <para>
    ''' <see cref="WorkType"/></para>
    ''' <para>NoWorkで新規</para>
    ''' <para>勤務が渡されると空いている勤務帯をセット</para>
    ''' <para>NoWorkで新規</para>
    ''' </summary>
    ''' <param name="WT">セットするデータの勤務種別</param>
    ''' ---------------------------------------------------------------------------------------
    Private Sub SetNewRec(ByVal WT As WorkType)
        NameBox.SelectedIndex = dgv.CurrentRow.Index
        STDate.Value = CDate(CCTag.SDate.ToString)
        Dim D = IIf(WTypeLbl.Tag = WorkType.Nikkin, 0, 1)
        EDDate.Value = DateAdd(DateInterval.Day, D, STDate.Value)
        WTChangeBtn.Enabled = True
        If WT <> 0 Then
            WTypeLbl.Text = getWTText(3 Xor WT)
            WTChangeBtn.Enabled = False
        End If
    End Sub
    ''' ---------------------------------------------------------------------------------------
    ''' <summary>
    ''' EditrFormに既存勤務データをセットします
    ''' <para>
    ''' <see cref="WorkType"/></para>
    ''' <para>渡された勤務種別のデータをセット</para>
    ''' </summary>
    ''' <param name="WT">セットするデータの勤務種別</param>
    ''' ---------------------------------------------------------------------------------------
    Public Sub SetEditRec(ByVal WT As WorkType)
        Dim FD As FormData
        If WT = WorkType.Nikkin Then
            FD.NmIdx = dgv.CurrentRow.Index
            FD.WType = WorkType.Nikkin
            FD.SDate = CCTag.SDate
            FD.SHour = Strings.Left(Strings.Right("0" & CCTag.NSTim, 4), 2)
            FD.SMinu = Strings.Right(CCTag.NSTim, 2)
            FD.EDate = CCTag.NEDat
            FD.EHour = Strings.Left(Strings.Right("0" & CCTag.NETim, 4), 2)
            FD.EMinu = Strings.Right(CCTag.NETim, 2)
        Else
            FD.NmIdx = dgv.CurrentRow.Index
            FD.WType = WorkType.Yakin
            FD.SDate = CCTag.SDate
            FD.SHour = Strings.Left(Strings.Right("0" & CCTag.YSTim, 4), 2)
            FD.SMinu = Strings.Right(CCTag.YSTim, 2)
            FD.EDate = CCTag.YEDat
            FD.EHour = Strings.Left(Strings.Right("0" & CCTag.YETim, 4), 2)
            FD.EMinu = Strings.Right(CCTag.YETim, 2)
        End If
        EventSwichTo(False)
        NameBox.SelectedIndex = FD.NmIdx
        STDate.Value = FD.SDate
        WTypeLbl.Text = WTTransfer(FD.WType)
        STH.Text = FD.SHour.ToString
        STM.Text = FD.SMinu.ToString
        EDDate.Value = FD.EDate
        EDH.Text = FD.EHour.ToString
        EDM.Text = FD.EMinu.ToString
        EventSwichTo(True)
        WTChangeBtn.Enabled = False
    End Sub
    Private Function Choice(ByVal ct As CFormType) As Integer
        Dim lo As System.Drawing.Point = CC.AccessibilityObject.Bounds.Location
        Dim c As New ChoiceForm

        With c
            .Left = lo.X - (.FstBtn.Left + (.FstBtn.Width / 2)) + (CC.Size.Width / 2)
            .Top = lo.Y - (.FstBtn.Top + (.FstBtn.Height)) + (CC.Size.Height / 2)
            '.Left = lo.X - (.Width / 2) + (CC.Size.Width / 2)
            '.Top = lo.Y - (.Height / 2) + (CC.Size.Height / 2)
            If ct = CFormType.YKN_OR_NKN Then
                .Text = "勤務の選択"
                .Label1.Text = "変更する勤務を選択してください"
                .FstBtn.Text = "日　勤"
                .SecBtn.Text = "夜　勤"
            ElseIf ct = CFormType.ADD_OR_EDIT Then
                .Text = "操作の選択"
                .Label1.Text = "追加ボタンで" & getWTText(3 Xor CInt(CCTag.WType)) & "を追加できます"
                .FstBtn.Text = "編　集"
                .SecBtn.Text = "追　加"
            End If
            Return .ShowDialog(Me)
        End With
    End Function

    Private Sub CABtn_Click(sender As Object, e As EventArgs) Handles CABtn.Click
        Me.Close()
    End Sub

    Private Sub OKBtn_Click(sender As Object, e As EventArgs) Handles OKBtn.Click
        Dim flg As Boolean
        flg = False
        flg = IIf(NameBox.SelectedIndex < 0, True, flg)
        flg = IIf(STDate.Value > EDDate.Value, True, flg)
        flg = IIf(STH.SelectedIndex < 0, True,
              IIf(STM.SelectedIndex < 0, True,
              IIf(EDH.SelectedIndex < 0, True,
              IIf(EDM.SelectedIndex < 0, True, flg))))
        If flg Then
            MsgBox("入力が正しくありません" & vbCrLf & "入力内容を確認してください")
            Exit Sub
        End If
        Dim ret = SetCCTag(GetWTEnum(WTypeLbl.Text))
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Save()
        Me.Close()
    End Sub
    Public Function SetCCTag(ByVal WT As WorkType) As WorkType
        With CCTag
            If WT = WorkType.Nikkin Then
                .NSTim = STH.SelectedItem.ToString & STM.SelectedItem.ToString
                .NETim = EDH.SelectedItem.ToString & EDM.SelectedItem.ToString
                .NType = "日勤"
                .NEDat = EDDate.Value
            ElseIf WT = WorkType.Yakin Then
                .YSTim = STH.SelectedItem.ToString & STM.SelectedItem.ToString
                .YETim = EDH.SelectedItem.ToString & EDM.SelectedItem.ToString
                .YType = "夜勤"
                .YEDat = EDDate.Value
            End If
            .WType = Me.WTypeLbl.Tag Or CInt(.WType)
            CC.Value = GetMark(.WType)
            Dim DC As DDClass = MainForm.mdgv.CurrentCell.Tag
            MainForm.mdgv.CurrentCell.ToolTipText = Join(DC.DDCls2Arr(DC), vbCrLf)
            Return .WType
        End With
    End Function

    Public Sub STDate_ValueChanged(sender As Object, e As EventArgs) Handles STDate.ValueChanged
        If ActiveControl Is Nothing Then Exit Sub
        If Me.ActiveControl.Name = "STDate" Then
            Dim D = IIf(WTypeLbl.Tag = WorkType.Yakin, 1, 0)
            EDDate.Value = DateAdd(DateInterval.Day, D, STDate.Value)
        End If
    End Sub

    Public Sub EDDate_ValueChanged(sender As Object, e As EventArgs) Handles EDDate.ValueChanged
        If ActiveControl Is Nothing Then Exit Sub
        If Me.ActiveControl.Name = "EDDate" Then
            Dim D = IIf(WTypeLbl.Tag = WorkType.Nikkin, -1, 0)
            STDate.Value = DateAdd(DateInterval.Day, D, EDDate.Value)
        End If
    End Sub
    Public Sub NameBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles NameBox.SelectedIndexChanged
        If NameBox.SelectedItem Is Nothing Then Exit Sub
        WTypeLbl.Text = StInfo(NameBox.SelectedItem)(2)
    End Sub
    Public Sub EventSwichTo(Flg As Boolean)
        If Flg Then
            AddHandler NameBox.SelectedIndexChanged, AddressOf NameBox_SelectedIndexChanged
            AddHandler STDate.ValueChanged, AddressOf STDate_ValueChanged
            AddHandler EDDate.ValueChanged, AddressOf EDDate_ValueChanged
            AddHandler WTypeLbl.TextChanged, AddressOf WTypeLbl_TextChanged
            AddHandler WTypeLbl.TextChanged, AddressOf WTypeLbl_TextChanged
        Else
            RemoveHandler NameBox.SelectedIndexChanged, AddressOf NameBox_SelectedIndexChanged
            RemoveHandler STDate.ValueChanged, AddressOf STDate_ValueChanged
            RemoveHandler EDDate.ValueChanged, AddressOf EDDate_ValueChanged
            RemoveHandler WTypeLbl.TextChanged, AddressOf WTypeLbl_TextChanged
            RemoveHandler WTypeLbl.TextChanged, AddressOf WTypeLbl_TextChanged
        End If
    End Sub
    ''' ---------------------------------------------------------------------------------------
    ''' <summary>
    '''     指定したコントロール内に含まれるコントロールを指定した名前で検索します。</summary>
    ''' <param name="hParent">
    '''     検索対象となる親コントロール。</param>
    ''' <param name="stName">
    '''     検索するコントロールの名前。</param>
    ''' <returns>
    '''     取得したコントロールのインスタンス。取得できなかった場合は Nothing。</returns>
    ''' ---------------------------------------------------------------------------------------

    'Private Sub RadioYKN_Click(sender As Object, e As EventArgs)

    '    If RadioYKN.Checked = True Then
    '        RadioChange(RadioYKN)
    '    End If
    'End Sub
    'Private Sub RadioNKN_Click(sender As Object, e As EventArgs)
    '    If RadioNKN.Checked = True Then
    '        RadioChange(RadioNKN)
    '    End If
    'End Sub

    Private Sub WTChangeBtn_Click(sender As Object, e As EventArgs) Handles WTChangeBtn.Click
        Select Case WTypeLbl.Text
            Case "日勤"
                WTypeLbl.Text = "夜勤"
            Case "夜勤"
                WTypeLbl.Text = "日勤"
            Case Else
                WTypeLbl.Text = "夜勤"
        End Select
    End Sub
    Private Sub WTypeLbl_TextChanged(sender As Object, e As EventArgs) Handles WTypeLbl.TextChanged
        Select Case WTypeLbl.Text
            Case "日勤"
                WTypeLbl.Tag = WorkType.Nikkin
            Case "夜勤"
                WTypeLbl.Tag = WorkType.Yakin
            Case Else
                WTypeLbl.Tag = WorkType.NoWork
        End Select
        WTChange(WTypeLbl)

    End Sub
    Public Shared Function GetMark(ByVal WT As WorkType) As String
        Dim mark As String
        Select Case WT
            Case WorkType.Nikkin
                mark = "◎"
            Case WorkType.Yakin
                mark = "○"
            Case WorkType.Renkin
                mark = "◓"
            Case Else
                mark = ""
        End Select
        Return mark
    End Function
    Public Shared Function GetWTEnum(ByVal WT As String) As WorkType
        Select Case WT
            Case "日勤"
                Return WorkType.Nikkin
            Case "夜勤"
                Return WorkType.Yakin
            Case "連勤"
                Return WorkType.Renkin
            Case Else
                Return WorkType.NoWork
        End Select
    End Function

    Public Shared Function GetWTText(ByVal wt As WorkType) As String
        Dim WTText As String
        Select Case wt
            Case WorkType.NoWork
                WTText = ""
            Case WorkType.Nikkin
                WTText = "日勤"
            Case WorkType.Yakin
                WTText = "夜勤"
            Case WorkType.Renkin
                WTText = "連勤"
            Case Else
                WTText = ""
        End Select
        Return WTText
    End Function
    Public Sub WTChange(ByRef WT As Label)
        Select Case WTypeLbl.Tag
            Case WorkType.Nikkin
                Dim TArr As TimeClass = GetTimeArr(NameBox.Text)
                STH.SelectedItem = TArr.SH
                STM.SelectedItem = TArr.SM
                EDH.SelectedItem = TArr.EH
                EDM.SelectedItem = TArr.EM
                EDDate.Value = STDate.Value
            Case WorkType.Yakin
                STH.SelectedItem = "17"
                STM.SelectedItem = "00"
                EDH.SelectedItem = "9"
                EDM.SelectedItem = "00"
                EDDate.Value = DateAdd(DateInterval.Day, 1, STDate.Value)
            Case Else
        End Select
    End Sub
    Private Function GetTimeArr(ByVal StName As String) As TimeClass
        Dim inf As Object = StInfo(StName)
        Dim ret As New TimeClass
        Dim st As String = Strings.Right("0" & inf(3).ToString, 4)
        Dim et As String = Strings.Right("0" & inf(4).ToString, 4)
        ret.SH = Strings.Format("0", CInt(Strings.Left(st, 2)))
        ret.SM = Strings.Right(st, 2)
        ret.EH = Strings.Format("0", Strings.Left(et, 2))
        ret.EM = Strings.Right(et, 2)
        GetTimeArr = ret
    End Function

End Class
