Option Explicit On
Option Strict On
Option Compare Binary
Option Infer On

Public Class IntegerSelector
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
        Me.numOther = New System.Windows.Forms.NumericUpDown()
        CType(Me.numOther,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        'btnSave
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSave.Location = New System.Drawing.Point(12, 51)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = true
        'btnCancel
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(93, 51)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        'lblInfo
        Me.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblInfo.AutoSize = true
        Me.lblInfo.Location = New System.Drawing.Point(12, 9)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(125, 13)
        Me.lblInfo.TabIndex = 0
        Me.lblInfo.Text = "Select number to set -- to:"
        'numOther
        Me.numOther.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.numOther.Location = New System.Drawing.Point(12, 25)
        Me.numOther.Maximum = System.Int32.MaxValue
        Me.numOther.Name = "numOther"
        Me.numOther.Size = New System.Drawing.Size(156, 20)
        Me.numOther.TabIndex = 0
        'IntegerSelector
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(180, 86)
        Me.Controls.Add(Me.numOther)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        ' Comment this out to get code auto-complete
        Me.Icon = Global.NetEdit.Resources.NetEdit
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "IntegerSelector"
        Me.ShowInTaskbar = false
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Choose Number"
        CType(Me.numOther,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout
    End Sub
    Private numOther As System.Windows.Forms.NumericUpDown
    Private lblInfo As System.Windows.Forms.Label
    Private btnCancel As System.Windows.Forms.Button
    Private btnSave As System.Windows.Forms.Button

    Public Sub New()
        Me.InitializeComponent()
    End Sub
    
    Public Property SelectedInteger As Integer
        Get
            Return Decimal.ToInt32(numOther.Value)
        End Get
        
        Set
            numOther.Value = value
        End Set
    End Property
    
    Public WriteOnly Property IntegerDescription As String
        Set
            Me.lblInfo.Text = "Select number to set " & value & " to:"
        End Set
    End Property
End Class
