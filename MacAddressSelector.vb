Option Explicit On
Option Strict On
Option Compare Binary
Option Infer On

Public Class MacAddressSelector
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
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.txtMacAddress = New System.Windows.Forms.TextBox()
        Me.pbxStatus = New System.Windows.Forms.PictureBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        CType(Me.pbxStatus,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        'btnSave
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSave.Location = New System.Drawing.Point(12, 73)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = true
        'btnCancel
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(93, 73)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        'lblInfo
        Me.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblInfo.AutoSize = true
        Me.lblInfo.Location = New System.Drawing.Point(12, 9)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(102, 13)
        Me.lblInfo.TabIndex = 0
        Me.lblInfo.Text = "Enter MAC Address:"
        'txtMacAddress
        Me.txtMacAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtMacAddress.Location = New System.Drawing.Point(12, 25)
        Me.txtMacAddress.Name = "txtMacAddress"
        Me.txtMacAddress.Size = New System.Drawing.Size(156, 20)
        Me.txtMacAddress.TabIndex = 1
        'pbxStatus
        Me.pbxStatus.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxStatus.Location = New System.Drawing.Point(12, 51)
        Me.pbxStatus.Name = "pbxStatus"
        Me.pbxStatus.Size = New System.Drawing.Size(16, 16)
        Me.pbxStatus.TabIndex = 10
        Me.pbxStatus.TabStop = false
        'lblStatus
        Me.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblStatus.AutoSize = true
        Me.lblStatus.Location = New System.Drawing.Point(28, 52)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(65, 13)
        Me.lblStatus.TabIndex = 2
        Me.lblStatus.Text = "Enter Text..."
        'MacAddressSelector
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(180, 108)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pbxStatus)
        Me.Controls.Add(Me.txtMacAddress)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        ' Comment this out to get code auto-complete
        Me.Icon = Global.NetEdit.Resources.NetEdit
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "MacAddressSelector"
        Me.ShowInTaskbar = false
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change MAC Address"
        CType(Me.pbxStatus,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout
    End Sub
    Private WithEvents txtMacAddress As System.Windows.Forms.TextBox
    Private pbxStatus As System.Windows.Forms.PictureBox
    Private lblStatus As System.Windows.Forms.Label
    Private lblInfo As System.Windows.Forms.Label
    Private btnCancel As System.Windows.Forms.Button
    Private btnSave As System.Windows.Forms.Button

    Public Sub New()
        Me.InitializeComponent()
    End Sub
    
    Public Property MacAddress As String
        Get
            Return txtMacAddress.Text.Replace("-", ":")
        End Get
        
        Set
            txtMacAddress.Text = value
        End Set
    End Property
    
    Sub txtMacAddress_TextChanged() Handles txtMacAddress.TextChanged
        If txtMacAddress.Text.Split(":".ToCharArray).Length = 6 Or txtMacAddress.Text.Split("-".ToCharArray).Length = 6 Then
            If IsConvertable(txtMacAddress.Text) Then
                btnSave.Enabled = True
                lblStatus.Text = "Valid Mac Address"
                pbxStatus.Image = Resources.accept
            Else
                btnSave.Enabled = False
                lblStatus.Text = "Invalid Mac Address"
                pbxStatus.Image = Resources.warning
            End If
        Else
            btnSave.Enabled = False
            lblStatus.Text = "Invalid Mac Address (Needs 6 sections)"
            pbxStatus.Image = Resources.warning
        End If
    End Sub
    
    Function IsConvertable(inputStr As String) As Boolean
        If inputStr.Contains("-") Then inputStr = inputStr.Replace("-", ":")
        
        Dim finalBytes(5) As Byte
        Dim counter As Integer = 0
        Try
            For Each byteNibbles As String In inputStr.Split(":".ToCharArray)
                finalBytes(counter) = Convert.ToByte(byteNibbles, 16) ' thanks to https://stackoverflow.com/a/1230330/2999220 for the 16 part
                counter += 1
            Next
        Catch
            Return False
        End Try
        
        Return True
    End Function
End Class
