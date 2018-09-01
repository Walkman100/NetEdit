Option Explicit On
Option Strict On
Option Compare Binary
Option Infer On

Public Class NameTypeSelector
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
        Me.optWired = New System.Windows.Forms.RadioButton()
        Me.optVPN = New System.Windows.Forms.RadioButton()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.optWireless = New System.Windows.Forms.RadioButton()
        Me.optMobile = New System.Windows.Forms.RadioButton()
        Me.numOther = New System.Windows.Forms.NumericUpDown()
        Me.grpOther = New System.Windows.Forms.GroupBox()
        Me.optOther = New System.Windows.Forms.RadioButton()
        CType(Me.numOther,System.ComponentModel.ISupportInitialize).BeginInit
        Me.grpOther.SuspendLayout
        Me.SuspendLayout
        'btnSave
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSave.Location = New System.Drawing.Point(20, 202)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = true
        'btnCancel
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(101, 202)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        'optWired
        Me.optWired.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.optWired.Location = New System.Drawing.Point(12, 25)
        Me.optWired.Name = "optWired"
        Me.optWired.Size = New System.Drawing.Size(173, 24)
        Me.optWired.TabIndex = 1
        Me.optWired.TabStop = true
        Me.optWired.Text = "Wired Network"
        Me.optWired.UseVisualStyleBackColor = true
        'optVPN
        Me.optVPN.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.optVPN.Location = New System.Drawing.Point(12, 55)
        Me.optVPN.Name = "optVPN"
        Me.optVPN.Size = New System.Drawing.Size(173, 24)
        Me.optVPN.TabIndex = 2
        Me.optVPN.TabStop = true
        Me.optVPN.Text = "VPN"
        Me.optVPN.UseVisualStyleBackColor = true
        'lblInfo
        Me.lblInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblInfo.AutoSize = true
        Me.lblInfo.Location = New System.Drawing.Point(12, 9)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(159, 13)
        Me.lblInfo.TabIndex = 0
        Me.lblInfo.Text = "Select type to set NameType to:"
        'optWireless
        Me.optWireless.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.optWireless.Location = New System.Drawing.Point(12, 85)
        Me.optWireless.Name = "optWireless"
        Me.optWireless.Size = New System.Drawing.Size(173, 24)
        Me.optWireless.TabIndex = 3
        Me.optWireless.TabStop = true
        Me.optWireless.Text = "Wireless Network"
        Me.optWireless.UseVisualStyleBackColor = true
        'optMobile
        Me.optMobile.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.optMobile.Location = New System.Drawing.Point(12, 115)
        Me.optMobile.Name = "optMobile"
        Me.optMobile.Size = New System.Drawing.Size(173, 24)
        Me.optMobile.TabIndex = 4
        Me.optMobile.TabStop = true
        Me.optMobile.Text = "Mobile Broadband"
        Me.optMobile.UseVisualStyleBackColor = true
        'numOther
        Me.numOther.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.numOther.Location = New System.Drawing.Point(6, 19)
        Me.numOther.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numOther.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numOther.Name = "numOther"
        Me.numOther.Size = New System.Drawing.Size(161, 20)
        Me.numOther.TabIndex = 0
        Me.numOther.Value = New Decimal(New Integer() {1, 0, 0, 0})
        'grpOther
        Me.grpOther.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpOther.Controls.Add(Me.numOther)
        Me.grpOther.Location = New System.Drawing.Point(12, 150)
        Me.grpOther.Name = "grpOther"
        Me.grpOther.Size = New System.Drawing.Size(173, 46)
        Me.grpOther.TabIndex = 6
        Me.grpOther.TabStop = false
        'optOther
        Me.optOther.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.optOther.BackColor = System.Drawing.Color.Transparent
        Me.optOther.Location = New System.Drawing.Point(12, 145)
        Me.optOther.Name = "optOther"
        Me.optOther.Size = New System.Drawing.Size(54, 24)
        Me.optOther.TabIndex = 5
        Me.optOther.TabStop = true
        Me.optOther.Text = "Other:"
        Me.optOther.UseVisualStyleBackColor = False
        'NameTypeSelector
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(197, 237)
        Me.Controls.Add(Me.optOther)
        Me.Controls.Add(Me.grpOther)
        Me.Controls.Add(Me.optMobile)
        Me.Controls.Add(Me.optWireless)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.optVPN)
        Me.Controls.Add(Me.optWired)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        ' Comment this out to get code auto-complete
        Me.Icon = Global.NetEdit.Resources.NetEdit
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "NameTypeSelector"
        Me.ShowInTaskbar = false
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Network NameType"
        CType(Me.numOther,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpOther.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout
    End Sub
    Private WithEvents optWired As System.Windows.Forms.RadioButton
    Private WithEvents optVPN As System.Windows.Forms.RadioButton
    Private WithEvents optWireless As System.Windows.Forms.RadioButton
    Private WithEvents optMobile As System.Windows.Forms.RadioButton
    Private numOther As System.Windows.Forms.NumericUpDown
    Private grpOther As System.Windows.Forms.GroupBox
    Private WithEvents optOther As System.Windows.Forms.RadioButton
    Private lblInfo As System.Windows.Forms.Label
    Private btnCancel As System.Windows.Forms.Button
    Private btnSave As System.Windows.Forms.Button

    Public Sub New()
        Me.InitializeComponent()
    End Sub
    
    Public Property SelectedNameType As Integer
        Get
            Return Decimal.ToInt32(numOther.Value)
        End Get
        
        Set
            numOther.Value = value
            Select Case value
                Case 6: optWired.Checked = True
                Case 23: optVPN.Checked = True
                Case 71: optWireless.Checked = True
                Case 243: optMobile.Checked = True
                Case Else: optOther.Checked = True
            End Select
        End Set
    End Property
    
    Sub OptionsCheckedChanged() Handles optWired.CheckedChanged, optVPN.CheckedChanged, optWireless.CheckedChanged, optMobile.CheckedChanged, optOther.CheckedChanged
        If optWired.Checked Then numOther.Value = 6
        If optVPN.Checked Then numOther.Value = 23
        If optWireless.Checked Then numOther.Value = 71
        If optMobile.Checked Then numOther.Value = 243
        grpOther.Enabled = optOther.Checked
    End Sub
End Class

'Public Enum NameType
'    WiredNetwork = 6
'    VPN = 23
'    WirelessNetwork = 71
'    MobileBroadband = 243
'End Enum
