Option Explicit On
Option Strict On
Option Compare Binary
Option Infer On

Public Class NetworkTypeSelector
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Private Sub InitializeComponent()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.optPrivate = New System.Windows.Forms.RadioButton()
        Me.optPublic = New System.Windows.Forms.RadioButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.SuspendLayout
        'btnSave
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSave.Location = New System.Drawing.Point(12, 85)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = true
        'btnCancel
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(93, 85)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        'optPrivate
        Me.optPrivate.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.optPrivate.Location = New System.Drawing.Point(12, 25)
        Me.optPrivate.Name = "optPrivate"
        Me.optPrivate.Size = New System.Drawing.Size(156, 24)
        Me.optPrivate.TabIndex = 1
        Me.optPrivate.TabStop = true
        Me.optPrivate.Text = "Private Network"
        Me.optPrivate.UseVisualStyleBackColor = true
        'optPublic
        Me.optPublic.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.optPublic.Location = New System.Drawing.Point(12, 55)
        Me.optPublic.Name = "optPublic"
        Me.optPublic.Size = New System.Drawing.Size(156, 24)
        Me.optPublic.TabIndex = 2
        Me.optPublic.TabStop = true
        Me.optPublic.Text = "Public Network"
        Me.optPublic.UseVisualStyleBackColor = true
        'lblInfo
        Me.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblInfo.AutoSize = true
        Me.lblInfo.Location = New System.Drawing.Point(12, 9)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(145, 13)
        Me.lblInfo.TabIndex = 0
        Me.lblInfo.Text = "Select type to set network to:"
        'NetworkTypeSelector
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(180, 120)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.optPublic)
        Me.Controls.Add(Me.optPrivate)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        ' Comment this out to get code auto-complete
        Me.Icon = Global.NetEdit.Resources.NetEdit
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "NetworkTypeSelector"
        Me.ShowInTaskbar = false
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Network Type"
        Me.ResumeLayout(false)
        Me.PerformLayout
    End Sub
    Private lblInfo As System.Windows.Forms.Label
    Private optPublic As System.Windows.Forms.RadioButton
    Private optPrivate As System.Windows.Forms.RadioButton
    Private btnCancel As System.Windows.Forms.Button
    Private btnSave As System.Windows.Forms.Button

    Public Sub New()
        Me.InitializeComponent()
    End Sub
    
    Public Property SelectedNetworkType As NetworkCategory
        Get
            If optPrivate.Checked Then
                Return NetworkCategory.Private
            ElseIf optPublic.Checked Then
                Return NetworkCategory.Public
            Else
                Throw New Exception("No input selected")
            End If
        End Get
        
        Set
            Select Case value
                Case NetworkCategory.Private
                    optPrivate.Checked = True
                Case NetworkCategory.Public
                    optPublic.Checked = True
            End Select
        End Set
    End Property
End Class

Public Enum NetworkCategory
    [Private]
    [Public]
End Enum
