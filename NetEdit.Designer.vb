
Partial Class NetEdit
    Inherits System.Windows.Forms.Form
    
    ''' <summary>
    ''' Designer variable used to keep track of non-visual components.
    ''' </summary>
    Private components As System.ComponentModel.IContainer
    
    ''' <summary>
    ''' Disposes resources used by the form.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    
    ''' <summary>
    ''' This method is required for Windows Forms designer support.
    ''' Do not change the method contents inside the source code editor. The Forms designer might
    ''' not be able to load this method if it was changed manually.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim listViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Loading...")
        Dim listViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Loading...")
        Me.grpAll = New System.Windows.Forms.GroupBox()
        Me.grpConnected = New System.Windows.Forms.GroupBox()
        Me.timerDelayedScan = New System.Windows.Forms.Timer(Me.components)
        Me.lstAll = New System.Windows.Forms.ListView()
        Me.headAllNetworkName = New System.Windows.Forms.ColumnHeader()
        Me.lstConnected = New System.Windows.Forms.ListView()
        Me.headAllNetworkCategory = New System.Windows.Forms.ColumnHeader()
        Me.headAllNetworkDesc = New System.Windows.Forms.ColumnHeader()
        Me.headAllNetworkManaged = New System.Windows.Forms.ColumnHeader()
        Me.headAllNetworkNameType = New System.Windows.Forms.ColumnHeader()
        Me.headAllNetworkCategoryType = New System.Windows.Forms.ColumnHeader()
        Me.headAllSignatureMac = New System.Windows.Forms.ColumnHeader()
        Me.headAllSignatureDesc = New System.Windows.Forms.ColumnHeader()
        Me.headAllSignatureFirstNetwork = New System.Windows.Forms.ColumnHeader()
        Me.headAllSignatureDNS = New System.Windows.Forms.ColumnHeader()
        Me.headAllSignatureSource = New System.Windows.Forms.ColumnHeader()
        Me.headConnName = New System.Windows.Forms.ColumnHeader()
        Me.headConnInterface = New System.Windows.Forms.ColumnHeader()
        Me.headConnV4Status = New System.Windows.Forms.ColumnHeader()
        Me.headConnV6Status = New System.Windows.Forms.ColumnHeader()
        Me.headConnType = New System.Windows.Forms.ColumnHeader()
        Me.btnAllName = New System.Windows.Forms.Button()
        Me.btnConnChangeType = New System.Windows.Forms.Button()
        Me.btnAllCategory = New System.Windows.Forms.Button()
        Me.btnAllDescription = New System.Windows.Forms.Button()
        Me.btnAllManaged = New System.Windows.Forms.Button()
        Me.btnAllNameType = New System.Windows.Forms.Button()
        Me.btnAllCategoryType = New System.Windows.Forms.Button()
        Me.btnAllSignatureGateway = New System.Windows.Forms.Button()
        Me.grpAllSignature = New System.Windows.Forms.GroupBox()
        Me.btnAllSignatureDNS = New System.Windows.Forms.Button()
        Me.btnAllSignatureDescription = New System.Windows.Forms.Button()
        Me.btnAllSignatureFirstNetwork = New System.Windows.Forms.Button()
        Me.btnAllSignatureSource = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button3 = New System.Windows.Forms.Button()
        Me.grpAll.SuspendLayout
        Me.grpConnected.SuspendLayout
        Me.grpAllSignature.SuspendLayout
        Me.SuspendLayout
        '
        'grpAll
        '
        Me.grpAll.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
                        Or System.Windows.Forms.AnchorStyles.Left)  _
                        Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpAll.Controls.Add(Me.button1)
        Me.grpAll.Controls.Add(Me.grpAllSignature)
        Me.grpAll.Controls.Add(Me.btnAllCategoryType)
        Me.grpAll.Controls.Add(Me.btnAllNameType)
        Me.grpAll.Controls.Add(Me.btnAllManaged)
        Me.grpAll.Controls.Add(Me.btnAllDescription)
        Me.grpAll.Controls.Add(Me.btnAllCategory)
        Me.grpAll.Controls.Add(Me.btnAllName)
        Me.grpAll.Controls.Add(Me.lstAll)
        Me.grpAll.Location = New System.Drawing.Point(12, 12)
        Me.grpAll.Name = "grpAll"
        Me.grpAll.Size = New System.Drawing.Size(1065, 300)
        Me.grpAll.TabIndex = 0
        Me.grpAll.TabStop = false
        Me.grpAll.Text = "All Profiles:"
        '
        'grpConnected
        '
        Me.grpConnected.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
                        Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpConnected.Controls.Add(Me.btnConnChangeType)
        Me.grpConnected.Controls.Add(Me.lstConnected)
        Me.grpConnected.Location = New System.Drawing.Point(12, 318)
        Me.grpConnected.Name = "grpConnected"
        Me.grpConnected.Size = New System.Drawing.Size(1065, 300)
        Me.grpConnected.TabIndex = 1
        Me.grpConnected.TabStop = false
        Me.grpConnected.Text = "Connected Networks:"
        '
        'timerDelayedScan
        '
        Me.timerDelayedScan.Interval = 50
        '
        'lstAll
        '
        Me.lstAll.AllowColumnReorder = true
        Me.lstAll.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
                        Or System.Windows.Forms.AnchorStyles.Left)  _
                        Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lstAll.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.headAllNetworkName, Me.headAllNetworkCategory, Me.headAllNetworkDesc, Me.headAllNetworkManaged, Me.headAllNetworkNameType, Me.headAllNetworkCategoryType, Me.headAllSignatureMac, Me.headAllSignatureDNS, Me.headAllSignatureDesc, Me.headAllSignatureFirstNetwork, Me.headAllSignatureSource})
        Me.lstAll.FullRowSelect = true
        Me.lstAll.GridLines = true
        Me.lstAll.HideSelection = false
        listViewItem1.StateImageIndex = 0
        Me.lstAll.Items.AddRange(New System.Windows.Forms.ListViewItem() {listViewItem1})
        Me.lstAll.LabelEdit = true
        Me.lstAll.Location = New System.Drawing.Point(6, 19)
        Me.lstAll.MultiSelect = false
        Me.lstAll.Name = "lstAll"
        Me.lstAll.Size = New System.Drawing.Size(1053, 192)
        Me.lstAll.TabIndex = 0
        Me.lstAll.UseCompatibleStateImageBehavior = false
        Me.lstAll.View = System.Windows.Forms.View.Details
        '
        'headAllNetworkName
        '
        Me.headAllNetworkName.Text = "Profile Name"
        Me.headAllNetworkName.Width = 100
        '
        'lstConnected
        '
        Me.lstConnected.AllowColumnReorder = true
        Me.lstConnected.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
                        Or System.Windows.Forms.AnchorStyles.Left)  _
                        Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lstConnected.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.headConnName, Me.headConnInterface, Me.headConnV4Status, Me.headConnV6Status, Me.headConnType})
        Me.lstConnected.FullRowSelect = true
        Me.lstConnected.GridLines = true
        Me.lstConnected.HideSelection = false
        Me.lstConnected.Items.AddRange(New System.Windows.Forms.ListViewItem() {listViewItem2})
        Me.lstConnected.Location = New System.Drawing.Point(6, 19)
        Me.lstConnected.MultiSelect = false
        Me.lstConnected.Name = "lstConnected"
        Me.lstConnected.Size = New System.Drawing.Size(1053, 246)
        Me.lstConnected.TabIndex = 0
        Me.lstConnected.UseCompatibleStateImageBehavior = false
        Me.lstConnected.View = System.Windows.Forms.View.Details
        '
        'headAllNetworkCategory
        '
        Me.headAllNetworkCategory.Text = "Category"
        '
        'headAllNetworkDesc
        '
        Me.headAllNetworkDesc.Text = "Description"
        Me.headAllNetworkDesc.Width = 70
        '
        'headAllNetworkManaged
        '
        Me.headAllNetworkManaged.Text = "Managed"
        '
        'headAllNetworkNameType
        '
        Me.headAllNetworkNameType.Text = "NameType"
        Me.headAllNetworkNameType.Width = 70
        '
        'headAllNetworkCategoryType
        '
        Me.headAllNetworkCategoryType.Text = "CategoryType"
        Me.headAllNetworkCategoryType.Width = 80
        '
        'headAllSignatureMac
        '
        Me.headAllSignatureMac.Text = "Signature Gateway Mac"
        Me.headAllSignatureMac.Width = 115
        '
        'headAllSignatureDesc
        '
        Me.headAllSignatureDesc.Text = "Signature Description"
        Me.headAllSignatureDesc.Width = 115
        '
        'headAllSignatureFirstNetwork
        '
        Me.headAllSignatureFirstNetwork.Text = "Signature FirstNetwork"
        Me.headAllSignatureFirstNetwork.Width = 120
        '
        'headAllSignatureDNS
        '
        Me.headAllSignatureDNS.Text = "Signature DNS Suffix"
        Me.headAllSignatureDNS.Width = 115
        '
        'headAllSignatureSource
        '
        Me.headAllSignatureSource.Text = "Signature Source"
        Me.headAllSignatureSource.Width = 100
        '
        'headConnName
        '
        Me.headConnName.Text = "Network Name"
        Me.headConnName.Width = 100
        '
        'headConnInterface
        '
        Me.headConnInterface.Text = "Interface Name"
        Me.headConnInterface.Width = 100
        '
        'headConnV4Status
        '
        Me.headConnV4Status.Text = "IPv4 Status"
        Me.headConnV4Status.Width = 100
        '
        'headConnV6Status
        '
        Me.headConnV6Status.Text = "IPv6 Status"
        Me.headConnV6Status.Width = 100
        '
        'headConnType
        '
        Me.headConnType.Text = "Network Type"
        Me.headConnType.Width = 100
        '
        'btnAllName
        '
        Me.btnAllName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllName.Location = New System.Drawing.Point(6, 217)
        Me.btnAllName.Name = "btnAllName"
        Me.btnAllName.Size = New System.Drawing.Size(85, 23)
        Me.btnAllName.TabIndex = 1
        Me.btnAllName.Text = "Change Name"
        Me.btnAllName.UseVisualStyleBackColor = true
        '
        'btnConnChangeType
        '
        Me.btnConnChangeType.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnConnChangeType.Location = New System.Drawing.Point(492, 271)
        Me.btnConnChangeType.Name = "btnConnChangeType"
        Me.btnConnChangeType.Size = New System.Drawing.Size(81, 23)
        Me.btnConnChangeType.TabIndex = 1
        Me.btnConnChangeType.Text = "Change Type"
        Me.btnConnChangeType.UseVisualStyleBackColor = true
        '
        'btnAllCategory
        '
        Me.btnAllCategory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllCategory.Location = New System.Drawing.Point(97, 217)
        Me.btnAllCategory.Name = "btnAllCategory"
        Me.btnAllCategory.Size = New System.Drawing.Size(99, 23)
        Me.btnAllCategory.TabIndex = 2
        Me.btnAllCategory.Text = "Change Category"
        Me.btnAllCategory.UseVisualStyleBackColor = true
        '
        'btnAllDescription
        '
        Me.btnAllDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllDescription.Location = New System.Drawing.Point(202, 217)
        Me.btnAllDescription.Name = "btnAllDescription"
        Me.btnAllDescription.Size = New System.Drawing.Size(110, 23)
        Me.btnAllDescription.TabIndex = 3
        Me.btnAllDescription.Text = "Change Description"
        Me.btnAllDescription.UseVisualStyleBackColor = true
        '
        'btnAllManaged
        '
        Me.btnAllManaged.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllManaged.Location = New System.Drawing.Point(318, 217)
        Me.btnAllManaged.Name = "btnAllManaged"
        Me.btnAllManaged.Size = New System.Drawing.Size(98, 23)
        Me.btnAllManaged.TabIndex = 4
        Me.btnAllManaged.Text = "Toggle Managed"
        Me.btnAllManaged.UseVisualStyleBackColor = true
        '
        'btnAllNameType
        '
        Me.btnAllNameType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllNameType.Location = New System.Drawing.Point(422, 217)
        Me.btnAllNameType.Name = "btnAllNameType"
        Me.btnAllNameType.Size = New System.Drawing.Size(109, 23)
        Me.btnAllNameType.TabIndex = 5
        Me.btnAllNameType.Text = "Change NameType"
        Me.btnAllNameType.UseVisualStyleBackColor = true
        '
        'btnAllCategoryType
        '
        Me.btnAllCategoryType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllCategoryType.Location = New System.Drawing.Point(537, 217)
        Me.btnAllCategoryType.Name = "btnAllCategoryType"
        Me.btnAllCategoryType.Size = New System.Drawing.Size(123, 23)
        Me.btnAllCategoryType.TabIndex = 6
        Me.btnAllCategoryType.Text = "Change CategoryType"
        Me.btnAllCategoryType.UseVisualStyleBackColor = true
        '
        'btnAllSignatureGateway
        '
        Me.btnAllSignatureGateway.Location = New System.Drawing.Point(6, 19)
        Me.btnAllSignatureGateway.Name = "btnAllSignatureGateway"
        Me.btnAllSignatureGateway.Size = New System.Drawing.Size(99, 23)
        Me.btnAllSignatureGateway.TabIndex = 7
        Me.btnAllSignatureGateway.Text = "Change Gateway"
        Me.btnAllSignatureGateway.UseVisualStyleBackColor = true
        '
        'grpAllSignature
        '
        Me.grpAllSignature.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.grpAllSignature.Controls.Add(Me.button3)
        Me.grpAllSignature.Controls.Add(Me.button2)
        Me.grpAllSignature.Controls.Add(Me.btnAllSignatureSource)
        Me.grpAllSignature.Controls.Add(Me.btnAllSignatureFirstNetwork)
        Me.grpAllSignature.Controls.Add(Me.btnAllSignatureDescription)
        Me.grpAllSignature.Controls.Add(Me.btnAllSignatureDNS)
        Me.grpAllSignature.Controls.Add(Me.btnAllSignatureGateway)
        Me.grpAllSignature.Location = New System.Drawing.Point(6, 246)
        Me.grpAllSignature.Name = "grpAllSignature"
        Me.grpAllSignature.Size = New System.Drawing.Size(1053, 48)
        Me.grpAllSignature.TabIndex = 8
        Me.grpAllSignature.TabStop = false
        Me.grpAllSignature.Text = "Signature:"
        '
        'btnAllSignatureDNS
        '
        Me.btnAllSignatureDNS.Location = New System.Drawing.Point(111, 19)
        Me.btnAllSignatureDNS.Name = "btnAllSignatureDNS"
        Me.btnAllSignatureDNS.Size = New System.Drawing.Size(109, 23)
        Me.btnAllSignatureDNS.TabIndex = 8
        Me.btnAllSignatureDNS.Text = "Change DNS Suffix"
        Me.btnAllSignatureDNS.UseVisualStyleBackColor = true
        '
        'btnAllSignatureDescription
        '
        Me.btnAllSignatureDescription.Location = New System.Drawing.Point(226, 19)
        Me.btnAllSignatureDescription.Name = "btnAllSignatureDescription"
        Me.btnAllSignatureDescription.Size = New System.Drawing.Size(110, 23)
        Me.btnAllSignatureDescription.TabIndex = 9
        Me.btnAllSignatureDescription.Text = "Change Description"
        Me.btnAllSignatureDescription.UseVisualStyleBackColor = true
        '
        'btnAllSignatureFirstNetwork
        '
        Me.btnAllSignatureFirstNetwork.Location = New System.Drawing.Point(342, 19)
        Me.btnAllSignatureFirstNetwork.Name = "btnAllSignatureFirstNetwork"
        Me.btnAllSignatureFirstNetwork.Size = New System.Drawing.Size(116, 23)
        Me.btnAllSignatureFirstNetwork.TabIndex = 10
        Me.btnAllSignatureFirstNetwork.Text = "Change FirstNetwork"
        Me.btnAllSignatureFirstNetwork.UseVisualStyleBackColor = true
        '
        'btnAllSignatureSource
        '
        Me.btnAllSignatureSource.Location = New System.Drawing.Point(464, 19)
        Me.btnAllSignatureSource.Name = "btnAllSignatureSource"
        Me.btnAllSignatureSource.Size = New System.Drawing.Size(91, 23)
        Me.btnAllSignatureSource.TabIndex = 11
        Me.btnAllSignatureSource.Text = "Change Source"
        Me.btnAllSignatureSource.UseVisualStyleBackColor = true
        '
        'button1
        '
        Me.button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.button1.Location = New System.Drawing.Point(666, 217)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(91, 23)
        Me.button1.TabIndex = 9
        Me.button1.Text = "Delete Network"
        Me.button1.UseVisualStyleBackColor = true
        '
        'button2
        '
        Me.button2.AutoSize = true
        Me.button2.Location = New System.Drawing.Point(561, 19)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(96, 23)
        Me.button2.TabIndex = 12
        Me.button2.Text = "Delete Signature"
        Me.button2.UseVisualStyleBackColor = true
        '
        'button3
        '
        Me.button3.BackColor = System.Drawing.SystemColors.Control
        Me.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button3.Location = New System.Drawing.Point(663, 19)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(148, 23)
        Me.button3.TabIndex = 13
        Me.button3.Text = "Delete Network & Signature"
        Me.button3.UseMnemonic = false
        Me.button3.UseVisualStyleBackColor = false
        '
        'NetEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1089, 630)
        Me.Controls.Add(Me.grpConnected)
        Me.Controls.Add(Me.grpAll)
        Me.Name = "NetEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NetEdit"
        Me.grpAll.ResumeLayout(false)
        Me.grpConnected.ResumeLayout(false)
        Me.grpAllSignature.ResumeLayout(false)
        Me.grpAllSignature.PerformLayout
        Me.ResumeLayout(false)
    End Sub
    Private timerDelayedScan As System.Windows.Forms.Timer
    Private headConnType As System.Windows.Forms.ColumnHeader
    Private headConnV6Status As System.Windows.Forms.ColumnHeader
    Private headConnV4Status As System.Windows.Forms.ColumnHeader
    Private headConnInterface As System.Windows.Forms.ColumnHeader
    Private headConnName As System.Windows.Forms.ColumnHeader
    Private lstConnected As System.Windows.Forms.ListView
    Private WithEvents btnConnChangeType As System.Windows.Forms.Button
    Private grpConnected As System.Windows.Forms.GroupBox
    Private headAllSignatureSource As System.Windows.Forms.ColumnHeader
    Private headAllSignatureFirstNetwork As System.Windows.Forms.ColumnHeader
    Private headAllSignatureDesc As System.Windows.Forms.ColumnHeader
    Private headAllSignatureDNS As System.Windows.Forms.ColumnHeader
    Private headAllSignatureMac As System.Windows.Forms.ColumnHeader
    Private headAllNetworkCategoryType As System.Windows.Forms.ColumnHeader
    Private headAllNetworkNameType As System.Windows.Forms.ColumnHeader
    Private headAllNetworkManaged As System.Windows.Forms.ColumnHeader
    Private headAllNetworkDesc As System.Windows.Forms.ColumnHeader
    Private headAllNetworkCategory As System.Windows.Forms.ColumnHeader
    Private headAllNetworkName As System.Windows.Forms.ColumnHeader
    Private lstAll As System.Windows.Forms.ListView
    Private WithEvents btnAllName As System.Windows.Forms.Button
    Private WithEvents btnAllCategory As System.Windows.Forms.Button
    Private WithEvents btnAllDescription As System.Windows.Forms.Button
    Private WithEvents btnAllManaged As System.Windows.Forms.Button
    Private WithEvents btnAllNameType As System.Windows.Forms.Button
    Private WithEvents btnAllCategoryType As System.Windows.Forms.Button
    Private WithEvents btnAllSignatureGateway As System.Windows.Forms.Button
    Private WithEvents btnAllSignatureDNS As System.Windows.Forms.Button
    Private WithEvents btnAllSignatureDescription As System.Windows.Forms.Button
    Private WithEvents btnAllSignatureFirstNetwork As System.Windows.Forms.Button
    Private WithEvents btnAllSignatureSource As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button3 As System.Windows.Forms.Button
    Private grpAllSignature As System.Windows.Forms.GroupBox
    Private WithEvents button1 As System.Windows.Forms.Button
    Private grpAll As System.Windows.Forms.GroupBox
End Class
