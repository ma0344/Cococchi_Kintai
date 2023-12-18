<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChoiceForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.FstBtn = New System.Windows.Forms.Button()
        Me.SecBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CanButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'FstBtn
        '
        Me.FstBtn.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.FstBtn.Font = New System.Drawing.Font("Yu Gothic UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FstBtn.Location = New System.Drawing.Point(12, 45)
        Me.FstBtn.Name = "FstBtn"
        Me.FstBtn.Size = New System.Drawing.Size(104, 59)
        Me.FstBtn.TabIndex = 1
        Me.FstBtn.Text = "日　勤"
        Me.FstBtn.UseVisualStyleBackColor = True
        '
        'SecBtn
        '
        Me.SecBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SecBtn.Font = New System.Drawing.Font("Yu Gothic UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.SecBtn.Location = New System.Drawing.Point(122, 45)
        Me.SecBtn.Name = "SecBtn"
        Me.SecBtn.Size = New System.Drawing.Size(104, 59)
        Me.SecBtn.TabIndex = 4
        Me.SecBtn.Text = "夜　勤"
        Me.SecBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic UI", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 28)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "変更する勤務を選択してください"
        '
        'CanButton
        '
        Me.CanButton.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CanButton.Location = New System.Drawing.Point(232, 63)
        Me.CanButton.Name = "CanButton"
        Me.CanButton.Size = New System.Drawing.Size(104, 41)
        Me.CanButton.TabIndex = 6
        Me.CanButton.Text = "中　止"
        Me.CanButton.UseVisualStyleBackColor = True
        '
        'ChoiceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 114)
        Me.ControlBox = False
        Me.Controls.Add(Me.CanButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SecBtn)
        Me.Controls.Add(Me.FstBtn)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChoiceForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "勤務の選択"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FstBtn As Button
    Friend WithEvents SecBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents CanButton As Button
End Class
