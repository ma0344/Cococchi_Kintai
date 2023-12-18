<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditorForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        CABtn = New Button()
        OKBtn = New Button()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        EDDate = New DateTimePicker()
        EDM = New ComboBox()
        EDH = New ComboBox()
        STM = New ComboBox()
        STH = New ComboBox()
        STDate = New DateTimePicker()
        NameBox = New ComboBox()
        Label4 = New Label()
        Label5 = New Label()
        WTypeLbl = New Label()
        WTChangeBtn = New Button()
        SuspendLayout()
        ' 
        ' CABtn
        ' 
        CABtn.Font = New Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point)
        CABtn.Location = New Point(192, 293)
        CABtn.Name = "CABtn"
        CABtn.Size = New Size(131, 43)
        CABtn.TabIndex = 27
        CABtn.Text = "中　止"
        CABtn.UseVisualStyleBackColor = True
        ' 
        ' OKBtn
        ' 
        OKBtn.Font = New Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point)
        OKBtn.Location = New Point(31, 293)
        OKBtn.Name = "OKBtn"
        OKBtn.Size = New Size(131, 43)
        OKBtn.TabIndex = 26
        OKBtn.Text = "登　録"
        OKBtn.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(12, 209)
        Label3.Name = "Label3"
        Label3.Size = New Size(88, 25)
        Label3.TabIndex = 30
        Label3.Text = "終了日時"' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(12, 128)
        Label2.Name = "Label2"
        Label2.Size = New Size(88, 25)
        Label2.TabIndex = 29
        Label2.Text = "開始日時"' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Yu Gothic UI", 14F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(14, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(50, 25)
        Label1.TabIndex = 28
        Label1.Text = "氏名"' 
        ' EDDate
        ' 
        EDDate.Enabled = False
        EDDate.Font = New Font("Yu Gothic UI", 16F, FontStyle.Regular, GraphicsUnit.Point)
        EDDate.Location = New Point(12, 237)
        EDDate.Name = "EDDate"
        EDDate.Size = New Size(200, 36)
        EDDate.TabIndex = 23
        ' 
        ' EDM
        ' 
        EDM.Font = New Font("Yu Gothic UI", 16F, FontStyle.Regular, GraphicsUnit.Point)
        EDM.FormattingEnabled = True
        EDM.Location = New Point(295, 237)
        EDM.Name = "EDM"
        EDM.Size = New Size(45, 38)
        EDM.TabIndex = 25
        ' 
        ' EDH
        ' 
        EDH.Font = New Font("Yu Gothic UI", 16F, FontStyle.Regular, GraphicsUnit.Point)
        EDH.FormattingEnabled = True
        EDH.Location = New Point(233, 237)
        EDH.Name = "EDH"
        EDH.Size = New Size(45, 38)
        EDH.TabIndex = 24
        ' 
        ' STM
        ' 
        STM.Font = New Font("Yu Gothic UI", 16F, FontStyle.Regular, GraphicsUnit.Point)
        STM.FormattingEnabled = True
        STM.Location = New Point(295, 156)
        STM.Name = "STM"
        STM.Size = New Size(45, 38)
        STM.TabIndex = 22
        ' 
        ' STH
        ' 
        STH.Font = New Font("Yu Gothic UI", 16F, FontStyle.Regular, GraphicsUnit.Point)
        STH.FormattingEnabled = True
        STH.Location = New Point(233, 156)
        STH.Name = "STH"
        STH.Size = New Size(45, 38)
        STH.TabIndex = 21
        ' 
        ' STDate
        ' 
        STDate.Enabled = False
        STDate.Font = New Font("Yu Gothic UI", 16F, FontStyle.Regular, GraphicsUnit.Point)
        STDate.Location = New Point(12, 156)
        STDate.Name = "STDate"
        STDate.Size = New Size(200, 36)
        STDate.TabIndex = 20
        ' 
        ' NameBox
        ' 
        NameBox.DropDownStyle = ComboBoxStyle.Simple
        NameBox.Font = New Font("Yu Gothic UI", 16F, FontStyle.Regular, GraphicsUnit.Point)
        NameBox.FormattingEnabled = True
        NameBox.Location = New Point(70, 12)
        NameBox.Name = "NameBox"
        NameBox.Size = New Size(255, 38)
        NameBox.TabIndex = 18
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(268, 159)
        Label4.Name = "Label4"
        Label4.Size = New Size(38, 32)
        Label4.TabIndex = 31
        Label4.Text = "："' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(268, 240)
        Label5.Name = "Label5"
        Label5.Size = New Size(38, 32)
        Label5.TabIndex = 32
        Label5.Text = "："' 
        ' WTypeLbl
        ' 
        WTypeLbl.BorderStyle = BorderStyle.Fixed3D
        WTypeLbl.Font = New Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        WTypeLbl.Location = New Point(27, 56)
        WTypeLbl.Margin = New Padding(2, 0, 2, 0)
        WTypeLbl.Name = "WTypeLbl"
        WTypeLbl.Size = New Size(113, 60)
        WTypeLbl.TabIndex = 33
        WTypeLbl.Tag = "0"
        WTypeLbl.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' WTChangeBtn
        ' 
        WTChangeBtn.Font = New Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point)
        WTChangeBtn.Location = New Point(161, 56)
        WTChangeBtn.Name = "WTChangeBtn"
        WTChangeBtn.Size = New Size(162, 60)
        WTChangeBtn.TabIndex = 34
        WTChangeBtn.Text = "夜勤⇔日勤"
        WTChangeBtn.UseVisualStyleBackColor = True
        ' 
        ' EditorForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(345, 347)
        Controls.Add(WTChangeBtn)
        Controls.Add(WTypeLbl)
        Controls.Add(CABtn)
        Controls.Add(OKBtn)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(EDDate)
        Controls.Add(EDM)
        Controls.Add(EDH)
        Controls.Add(STM)
        Controls.Add(STH)
        Controls.Add(STDate)
        Controls.Add(NameBox)
        Controls.Add(Label4)
        Controls.Add(Label5)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "EditorForm"
        StartPosition = FormStartPosition.Manual
        Text = "編集"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents CABtn As Button
    Friend WithEvents OKBtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents EDDate As DateTimePicker
    Friend WithEvents EDM As ComboBox
    Friend WithEvents EDH As ComboBox
    Friend WithEvents STM As ComboBox
    Friend WithEvents STH As ComboBox
    Friend WithEvents STDate As DateTimePicker
    Friend WithEvents NameBox As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents WTypeLbl As Label
    Friend WithEvents WTChangeBtn As Button
End Class
