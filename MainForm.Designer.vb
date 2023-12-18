<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CABtn = New System.Windows.Forms.Button()
        Me.mdgv = New System.Windows.Forms.DataGridView()
        Me.DelBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NSTLabel = New System.Windows.Forms.Label()
        Me.NETLabel = New System.Windows.Forms.Label()
        Me.YETLabel = New System.Windows.Forms.Label()
        Me.YSTLabel = New System.Windows.Forms.Label()
        Me.DateLabel = New System.Windows.Forms.Label()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SDLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EDLabel = New System.Windows.Forms.Label()
        Me.PrevBtn = New System.Windows.Forms.Button()
        Me.NextBtn = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.mdgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CABtn
        '
        Me.CABtn.Font = New System.Drawing.Font("Yu Gothic UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CABtn.Location = New System.Drawing.Point(994, 67)
        Me.CABtn.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CABtn.Name = "CABtn"
        Me.CABtn.Size = New System.Drawing.Size(131, 46)
        Me.CABtn.TabIndex = 11
        Me.CABtn.Text = "終　了"
        Me.CABtn.UseVisualStyleBackColor = True
        '
        'mdgv
        '
        Me.mdgv.AllowUserToAddRows = False
        Me.mdgv.AllowUserToDeleteRows = False
        Me.mdgv.AllowUserToResizeColumns = False
        Me.mdgv.AllowUserToResizeRows = False
        Me.mdgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.mdgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mdgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.mdgv.ColumnHeadersHeight = 50
        Me.mdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Yu Gothic UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.mdgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.mdgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.mdgv.EnableHeadersVisualStyles = False
        Me.mdgv.Location = New System.Drawing.Point(2, 119)
        Me.mdgv.Margin = New System.Windows.Forms.Padding(0)
        Me.mdgv.MultiSelect = False
        Me.mdgv.Name = "mdgv"
        Me.mdgv.ReadOnly = True
        Me.mdgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.mdgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.mdgv.RowHeadersWidth = 130
        Me.mdgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.mdgv.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.mdgv.RowTemplate.Height = 30
        Me.mdgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.mdgv.Size = New System.Drawing.Size(1280, 303)
        Me.mdgv.TabIndex = 20
        '
        'DelBtn
        '
        Me.DelBtn.Image = Global.ここっち勤怠記録.My.Resources.Resources.Del24
        Me.DelBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.DelBtn.Location = New System.Drawing.Point(923, 67)
        Me.DelBtn.Name = "DelBtn"
        Me.DelBtn.Size = New System.Drawing.Size(64, 46)
        Me.DelBtn.TabIndex = 26
        Me.DelBtn.Text = "削除"
        Me.DelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.DelBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Yu Gothic UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(238, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 25)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "日勤"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(238, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 25)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "夜勤"
        '
        'NSTLabel
        '
        Me.NSTLabel.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.NSTLabel.Location = New System.Drawing.Point(294, 26)
        Me.NSTLabel.Name = "NSTLabel"
        Me.NSTLabel.Size = New System.Drawing.Size(69, 32)
        Me.NSTLabel.TabIndex = 28
        Me.NSTLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NETLabel
        '
        Me.NETLabel.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.NETLabel.Location = New System.Drawing.Point(392, 26)
        Me.NETLabel.Name = "NETLabel"
        Me.NETLabel.Size = New System.Drawing.Size(69, 32)
        Me.NETLabel.TabIndex = 29
        Me.NETLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'YETLabel
        '
        Me.YETLabel.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.YETLabel.Location = New System.Drawing.Point(392, 59)
        Me.YETLabel.Name = "YETLabel"
        Me.YETLabel.Size = New System.Drawing.Size(69, 32)
        Me.YETLabel.TabIndex = 31
        Me.YETLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'YSTLabel
        '
        Me.YSTLabel.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.YSTLabel.Location = New System.Drawing.Point(294, 59)
        Me.YSTLabel.Name = "YSTLabel"
        Me.YSTLabel.Size = New System.Drawing.Size(69, 32)
        Me.YSTLabel.TabIndex = 30
        Me.YSTLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DateLabel
        '
        Me.DateLabel.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DateLabel.Location = New System.Drawing.Point(17, 28)
        Me.DateLabel.Name = "DateLabel"
        Me.DateLabel.Size = New System.Drawing.Size(215, 30)
        Me.DateLabel.TabIndex = 32
        Me.DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NameLabel
        '
        Me.NameLabel.Font = New System.Drawing.Font("Yu Gothic UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.NameLabel.Location = New System.Drawing.Point(55, 59)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(177, 34)
        Me.NameLabel.TabIndex = 27
        Me.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Yu Gothic UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label9.Location = New System.Drawing.Point(361, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 25)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "～"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Yu Gothic UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label10.Location = New System.Drawing.Point(361, 65)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 25)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "～"
        '
        'SDLabel
        '
        Me.SDLabel.Font = New System.Drawing.Font("Yu Gothic UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.SDLabel.Location = New System.Drawing.Point(90, 22)
        Me.SDLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.SDLabel.Name = "SDLabel"
        Me.SDLabel.Size = New System.Drawing.Size(195, 32)
        Me.SDLabel.TabIndex = 33
        Me.SDLabel.Text = "2023年12月16日"
        Me.SDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(288, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 25)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "～"
        '
        'EDLabel
        '
        Me.EDLabel.Font = New System.Drawing.Font("Yu Gothic UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.EDLabel.Location = New System.Drawing.Point(171, 50)
        Me.EDLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.EDLabel.Name = "EDLabel"
        Me.EDLabel.Size = New System.Drawing.Size(195, 32)
        Me.EDLabel.TabIndex = 33
        Me.EDLabel.Text = "2023年12月16日"
        Me.EDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PrevBtn
        '
        Me.PrevBtn.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.PrevBtn.Location = New System.Drawing.Point(16, 29)
        Me.PrevBtn.Name = "PrevBtn"
        Me.PrevBtn.Size = New System.Drawing.Size(75, 53)
        Me.PrevBtn.TabIndex = 35
        Me.PrevBtn.Text = "前月 ⋘"
        Me.PrevBtn.UseVisualStyleBackColor = True
        '
        'NextBtn
        '
        Me.NextBtn.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.NextBtn.Location = New System.Drawing.Point(360, 29)
        Me.NextBtn.Name = "NextBtn"
        Me.NextBtn.Size = New System.Drawing.Size(75, 53)
        Me.NextBtn.TabIndex = 35
        Me.NextBtn.Text = "⋙ 次月"
        Me.NextBtn.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DateLabel)
        Me.GroupBox1.Controls.Add(Me.NameLabel)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.YETLabel)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.YSTLabel)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.NETLabel)
        Me.GroupBox1.Controls.Add(Me.NSTLabel)
        Me.GroupBox1.Font = New System.Drawing.Font("Yu Gothic UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.GroupBox1.Location = New System.Drawing.Point(450, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(467, 101)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "選択中の記録"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1284, 423)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.NextBtn)
        Me.Controls.Add(Me.PrevBtn)
        Me.Controls.Add(Me.DelBtn)
        Me.Controls.Add(Me.mdgv)
        Me.Controls.Add(Me.CABtn)
        Me.Controls.Add(Me.SDLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.EDLabel)
        Me.Font = New System.Drawing.Font("Yu Gothic UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "MainForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "-1"
        Me.Text = "ここっち勤怠記録"
        CType(Me.mdgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CABtn As Button
    Friend WithEvents mdgv As DataGridView
    Friend WithEvents DelBtn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents NSTLabel As Label
    Friend WithEvents NETLabel As Label
    Friend WithEvents YETLabel As Label
    Friend WithEvents YSTLabel As Label
    Friend WithEvents DateLabel As Label
    Friend WithEvents NameLabel As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents SDLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents EDLabel As Label
    Friend WithEvents PrevBtn As Button
    Friend WithEvents NextBtn As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
