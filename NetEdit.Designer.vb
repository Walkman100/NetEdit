﻿Partial Class NetEdit
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
        Me.toolStripBackup = New System.Windows.Forms.ToolStrip()
        Me.toolStripBtnBackup = New System.Windows.Forms.ToolStripDropDownButton()
        Me.toolStripBackupAllProfiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripBackupAllSignatures = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripBackupAllBoth = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripBackupSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnAllRefresh = New System.Windows.Forms.Button()
        Me.btnAllNetworkWizard = New System.Windows.Forms.Button()
        Me.btnAllLocationWizard = New System.Windows.Forms.Button()
        Me.btnAllDeleteProfile = New System.Windows.Forms.Button()
        Me.contextMenuStripSave = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.contextMenuStripSaveReg = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpAllSignature = New System.Windows.Forms.GroupBox()
        Me.btnAllDeleteBoth = New System.Windows.Forms.Button()
        Me.btnAllSignatureDelete = New System.Windows.Forms.Button()
        Me.btnAllSignatureSource = New System.Windows.Forms.Button()
        Me.btnAllSignatureFirstNetwork = New System.Windows.Forms.Button()
        Me.btnAllSignatureDescription = New System.Windows.Forms.Button()
        Me.btnAllSignatureDNS = New System.Windows.Forms.Button()
        Me.btnAllSignatureGateway = New System.Windows.Forms.Button()
        Me.btnAllCategoryType = New System.Windows.Forms.Button()
        Me.btnAllNameType = New System.Windows.Forms.Button()
        Me.btnAllManaged = New System.Windows.Forms.Button()
        Me.btnAllDescription = New System.Windows.Forms.Button()
        Me.btnAllCategory = New System.Windows.Forms.Button()
        Me.btnAllName = New System.Windows.Forms.Button()
        Me.lstAll = New System.Windows.Forms.ListView()
        Me.headAllNetworkName = New System.Windows.Forms.ColumnHeader()
        Me.headAllNetworkCategory = New System.Windows.Forms.ColumnHeader()
        Me.headAllNetworkDesc = New System.Windows.Forms.ColumnHeader()
        Me.headAllNetworkManaged = New System.Windows.Forms.ColumnHeader()
        Me.headAllNetworkNameType = New System.Windows.Forms.ColumnHeader()
        Me.headAllNetworkCategoryType = New System.Windows.Forms.ColumnHeader()
        Me.headAllSignatureMac = New System.Windows.Forms.ColumnHeader()
        Me.headAllSignatureDNS = New System.Windows.Forms.ColumnHeader()
        Me.headAllSignatureDesc = New System.Windows.Forms.ColumnHeader()
        Me.headAllSignatureFirstNetwork = New System.Windows.Forms.ColumnHeader()
        Me.headAllSignatureSource = New System.Windows.Forms.ColumnHeader()
        Me.grpConnected = New System.Windows.Forms.GroupBox()
        Me.btnConnRefresh = New System.Windows.Forms.Button()
        Me.btnConnChangeType = New System.Windows.Forms.Button()
        Me.lstConnected = New System.Windows.Forms.ListView()
        Me.headConnName = New System.Windows.Forms.ColumnHeader()
        Me.headConnInterface = New System.Windows.Forms.ColumnHeader()
        Me.headConnV4Status = New System.Windows.Forms.ColumnHeader()
        Me.headConnV6Status = New System.Windows.Forms.ColumnHeader()
        Me.headConnType = New System.Windows.Forms.ColumnHeader()
        Me.timerDelayedScan = New System.Windows.Forms.Timer(Me.components)
        Me.sfdBackup = New System.Windows.Forms.SaveFileDialog()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.grpAll.SuspendLayout
        Me.toolStripBackup.SuspendLayout
        Me.contextMenuStripSave.SuspendLayout
        Me.grpAllSignature.SuspendLayout
        Me.grpConnected.SuspendLayout
        Me.SuspendLayout
        '
        'grpAll
        '
        Me.grpAll.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
                        Or System.Windows.Forms.AnchorStyles.Left)  _
                        Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpAll.Controls.Add(Me.toolStripBackup)
        Me.grpAll.Controls.Add(Me.btnExit)
        Me.grpAll.Controls.Add(Me.btnAllRefresh)
        Me.grpAll.Controls.Add(Me.btnAllNetworkWizard)
        Me.grpAll.Controls.Add(Me.btnAllLocationWizard)
        Me.grpAll.Controls.Add(Me.btnAllDeleteProfile)
        Me.grpAll.Controls.Add(Me.grpAllSignature)
        Me.grpAll.Controls.Add(Me.btnAllCategoryType)
        Me.grpAll.Controls.Add(Me.btnAllNameType)
        Me.grpAll.Controls.Add(Me.btnAllManaged)
        Me.grpAll.Controls.Add(Me.btnAllDescription)
        Me.grpAll.Controls.Add(Me.btnAllCategory)
        Me.grpAll.Controls.Add(Me.btnAllName)
        Me.grpAll.Controls.Add(Me.lstAll)
        Me.grpAll.Location = New System.Drawing.Point(12, 318)
        Me.grpAll.Name = "grpAll"
        Me.grpAll.Size = New System.Drawing.Size(1112, 300)
        Me.grpAll.TabIndex = 1
        Me.grpAll.TabStop = false
        Me.grpAll.Text = "All Profiles:"
        '
        'toolStripBackup
        '
        Me.toolStripBackup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.toolStripBackup.CanOverflow = false
        Me.toolStripBackup.Dock = System.Windows.Forms.DockStyle.None
        Me.toolStripBackup.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStripBackup.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripBtnBackup})
        Me.toolStripBackup.Location = New System.Drawing.Point(830, 264)
        Me.toolStripBackup.Name = "toolStripBackup"
        Me.toolStripBackup.Size = New System.Drawing.Size(62, 25)
        Me.toolStripBackup.TabIndex = 13
        Me.toolStripBackup.Text = "toolStripBackup"
        '
        'toolStripBtnBackup
        '
        Me.toolStripBtnBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.toolStripBtnBackup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.toolStripBtnBackup.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripBackupAllProfiles, Me.toolStripBackupAllSignatures, Me.toolStripBackupAllBoth, Me.toolStripBackupSelected})
        Me.toolStripBtnBackup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolStripBtnBackup.Name = "toolStripBtnBackup"
        Me.toolStripBtnBackup.Size = New System.Drawing.Size(59, 22)
        Me.toolStripBtnBackup.Text = "Backup"
        '
        'toolStripBackupAllProfiles
        '
        Me.toolStripBackupAllProfiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.toolStripBackupAllProfiles.Name = "toolStripBackupAllProfiles"
        Me.toolStripBackupAllProfiles.Size = New System.Drawing.Size(243, 22)
        Me.toolStripBackupAllProfiles.Text = "Backup All Profiles"
        '
        'toolStripBackupAllSignatures
        '
        Me.toolStripBackupAllSignatures.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.toolStripBackupAllSignatures.Name = "toolStripBackupAllSignatures"
        Me.toolStripBackupAllSignatures.Size = New System.Drawing.Size(243, 22)
        Me.toolStripBackupAllSignatures.Text = "Backup All Signatures"
        '
        'toolStripBackupAllBoth
        '
        Me.toolStripBackupAllBoth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.toolStripBackupAllBoth.Name = "toolStripBackupAllBoth"
        Me.toolStripBackupAllBoth.Size = New System.Drawing.Size(243, 22)
        Me.toolStripBackupAllBoth.Text = "Backup All Profiles && Signatures"
        '
        'toolStripBackupSelected
        '
        Me.toolStripBackupSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.toolStripBackupSelected.Name = "toolStripBackupSelected"
        Me.toolStripBackupSelected.Size = New System.Drawing.Size(243, 22)
        Me.toolStripBackupSelected.Text = "Backup Selected"
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(979, 265)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = true
        '
        'btnAllRefresh
        '
        Me.btnAllRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllRefresh.Location = New System.Drawing.Point(898, 265)
        Me.btnAllRefresh.Name = "btnAllRefresh"
        Me.btnAllRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnAllRefresh.TabIndex = 11
        Me.btnAllRefresh.Text = "Refresh"
        Me.btnAllRefresh.UseVisualStyleBackColor = true
        '
        'btnAllNetworkWizard
        '
        Me.btnAllNetworkWizard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllNetworkWizard.Location = New System.Drawing.Point(915, 217)
        Me.btnAllNetworkWizard.Name = "btnAllNetworkWizard"
        Me.btnAllNetworkWizard.Size = New System.Drawing.Size(192, 23)
        Me.btnAllNetworkWizard.TabIndex = 9
        Me.btnAllNetworkWizard.Text = "Network Name & Properties Wizard..."
        Me.btnAllNetworkWizard.UseMnemonic = false
        Me.btnAllNetworkWizard.UseVisualStyleBackColor = true
        '
        'btnAllLocationWizard
        '
        Me.btnAllLocationWizard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllLocationWizard.BackColor = System.Drawing.SystemColors.Control
        Me.btnAllLocationWizard.Location = New System.Drawing.Point(763, 217)
        Me.btnAllLocationWizard.Name = "btnAllLocationWizard"
        Me.btnAllLocationWizard.Size = New System.Drawing.Size(146, 23)
        Me.btnAllLocationWizard.TabIndex = 8
        Me.btnAllLocationWizard.Text = "Network Location Wizard..."
        Me.btnAllLocationWizard.UseVisualStyleBackColor = true
        '
        'btnAllDeleteProfile
        '
        Me.btnAllDeleteProfile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllDeleteProfile.ContextMenuStrip = Me.contextMenuStripSave
        Me.btnAllDeleteProfile.Image = Global.NetEdit.Resources.mouse_right_click_8x
        Me.btnAllDeleteProfile.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnAllDeleteProfile.Location = New System.Drawing.Point(666, 217)
        Me.btnAllDeleteProfile.Name = "btnAllDeleteProfile"
        Me.btnAllDeleteProfile.Size = New System.Drawing.Size(91, 23)
        Me.btnAllDeleteProfile.TabIndex = 7
        Me.btnAllDeleteProfile.Text = "Delete Profile"
        Me.btnAllDeleteProfile.UseVisualStyleBackColor = true
        '
        'contextMenuStripSave
        '
        Me.contextMenuStripSave.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.contextMenuStripSaveReg})
        Me.contextMenuStripSave.Name = "contextMenuStripSave"
        Me.contextMenuStripSave.Size = New System.Drawing.Size(188, 26)
        Me.contextMenuStripSave.Text = "text?"
        '
        'contextMenuStripSaveReg
        '
        Me.contextMenuStripSaveReg.Image = Global.NetEdit.Resources.RegFile
        Me.contextMenuStripSaveReg.Name = "contextMenuStripSaveReg"
        Me.contextMenuStripSaveReg.Size = New System.Drawing.Size(187, 22)
        Me.contextMenuStripSaveReg.Text = "Save to Registry File..."
        '
        'grpAllSignature
        '
        Me.grpAllSignature.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.grpAllSignature.Controls.Add(Me.btnAllDeleteBoth)
        Me.grpAllSignature.Controls.Add(Me.btnAllSignatureDelete)
        Me.grpAllSignature.Controls.Add(Me.btnAllSignatureSource)
        Me.grpAllSignature.Controls.Add(Me.btnAllSignatureFirstNetwork)
        Me.grpAllSignature.Controls.Add(Me.btnAllSignatureDescription)
        Me.grpAllSignature.Controls.Add(Me.btnAllSignatureDNS)
        Me.grpAllSignature.Controls.Add(Me.btnAllSignatureGateway)
        Me.grpAllSignature.Location = New System.Drawing.Point(6, 246)
        Me.grpAllSignature.Name = "grpAllSignature"
        Me.grpAllSignature.Size = New System.Drawing.Size(817, 48)
        Me.grpAllSignature.TabIndex = 10
        Me.grpAllSignature.TabStop = false
        Me.grpAllSignature.Text = "Signature:"
        '
        'btnAllDeleteBoth
        '
        Me.btnAllDeleteBoth.BackColor = System.Drawing.SystemColors.Control
        Me.btnAllDeleteBoth.ContextMenuStrip = Me.contextMenuStripSave
        Me.btnAllDeleteBoth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAllDeleteBoth.Image = Global.NetEdit.Resources.mouse_right_click_8x
        Me.btnAllDeleteBoth.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnAllDeleteBoth.Location = New System.Drawing.Point(663, 19)
        Me.btnAllDeleteBoth.Name = "btnAllDeleteBoth"
        Me.btnAllDeleteBoth.Size = New System.Drawing.Size(148, 23)
        Me.btnAllDeleteBoth.TabIndex = 6
        Me.btnAllDeleteBoth.Text = "Delete Profile & Signature"
        Me.btnAllDeleteBoth.UseMnemonic = false
        Me.btnAllDeleteBoth.UseVisualStyleBackColor = false
        '
        'btnAllSignatureDelete
        '
        Me.btnAllSignatureDelete.AutoSize = true
        Me.btnAllSignatureDelete.ContextMenuStrip = Me.contextMenuStripSave
        Me.btnAllSignatureDelete.Image = Global.NetEdit.Resources.mouse_right_click_8x
        Me.btnAllSignatureDelete.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnAllSignatureDelete.Location = New System.Drawing.Point(561, 19)
        Me.btnAllSignatureDelete.Name = "btnAllSignatureDelete"
        Me.btnAllSignatureDelete.Size = New System.Drawing.Size(96, 23)
        Me.btnAllSignatureDelete.TabIndex = 5
        Me.btnAllSignatureDelete.Text = "Delete Signature"
        Me.btnAllSignatureDelete.UseVisualStyleBackColor = true
        '
        'btnAllSignatureSource
        '
        Me.btnAllSignatureSource.ContextMenuStrip = Me.contextMenuStripSave
        Me.btnAllSignatureSource.Image = Global.NetEdit.Resources.mouse_right_click_8x
        Me.btnAllSignatureSource.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnAllSignatureSource.Location = New System.Drawing.Point(464, 19)
        Me.btnAllSignatureSource.Name = "btnAllSignatureSource"
        Me.btnAllSignatureSource.Size = New System.Drawing.Size(91, 23)
        Me.btnAllSignatureSource.TabIndex = 4
        Me.btnAllSignatureSource.Text = "Change Source"
        Me.btnAllSignatureSource.UseVisualStyleBackColor = true
        '
        'btnAllSignatureFirstNetwork
        '
        Me.btnAllSignatureFirstNetwork.ContextMenuStrip = Me.contextMenuStripSave
        Me.btnAllSignatureFirstNetwork.Image = Global.NetEdit.Resources.mouse_right_click_8x
        Me.btnAllSignatureFirstNetwork.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnAllSignatureFirstNetwork.Location = New System.Drawing.Point(342, 19)
        Me.btnAllSignatureFirstNetwork.Name = "btnAllSignatureFirstNetwork"
        Me.btnAllSignatureFirstNetwork.Size = New System.Drawing.Size(116, 23)
        Me.btnAllSignatureFirstNetwork.TabIndex = 3
        Me.btnAllSignatureFirstNetwork.Text = "Change FirstNetwork"
        Me.btnAllSignatureFirstNetwork.UseVisualStyleBackColor = true
        '
        'btnAllSignatureDescription
        '
        Me.btnAllSignatureDescription.ContextMenuStrip = Me.contextMenuStripSave
        Me.btnAllSignatureDescription.Image = Global.NetEdit.Resources.mouse_right_click_8x
        Me.btnAllSignatureDescription.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnAllSignatureDescription.Location = New System.Drawing.Point(226, 19)
        Me.btnAllSignatureDescription.Name = "btnAllSignatureDescription"
        Me.btnAllSignatureDescription.Size = New System.Drawing.Size(110, 23)
        Me.btnAllSignatureDescription.TabIndex = 2
        Me.btnAllSignatureDescription.Text = "Change Description"
        Me.btnAllSignatureDescription.UseVisualStyleBackColor = true
        '
        'btnAllSignatureDNS
        '
        Me.btnAllSignatureDNS.ContextMenuStrip = Me.contextMenuStripSave
        Me.btnAllSignatureDNS.Image = Global.NetEdit.Resources.mouse_right_click_8x
        Me.btnAllSignatureDNS.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnAllSignatureDNS.Location = New System.Drawing.Point(111, 19)
        Me.btnAllSignatureDNS.Name = "btnAllSignatureDNS"
        Me.btnAllSignatureDNS.Size = New System.Drawing.Size(109, 23)
        Me.btnAllSignatureDNS.TabIndex = 1
        Me.btnAllSignatureDNS.Text = "Change DNS Suffix"
        Me.btnAllSignatureDNS.UseVisualStyleBackColor = true
        '
        'btnAllSignatureGateway
        '
        Me.btnAllSignatureGateway.ContextMenuStrip = Me.contextMenuStripSave
        Me.btnAllSignatureGateway.Image = Global.NetEdit.Resources.mouse_right_click_8x
        Me.btnAllSignatureGateway.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnAllSignatureGateway.Location = New System.Drawing.Point(6, 19)
        Me.btnAllSignatureGateway.Name = "btnAllSignatureGateway"
        Me.btnAllSignatureGateway.Size = New System.Drawing.Size(99, 23)
        Me.btnAllSignatureGateway.TabIndex = 0
        Me.btnAllSignatureGateway.Text = "Change Gateway"
        Me.btnAllSignatureGateway.UseVisualStyleBackColor = true
        '
        'btnAllCategoryType
        '
        Me.btnAllCategoryType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllCategoryType.ContextMenuStrip = Me.contextMenuStripSave
        Me.btnAllCategoryType.Image = Global.NetEdit.Resources.mouse_right_click_8x
        Me.btnAllCategoryType.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnAllCategoryType.Location = New System.Drawing.Point(537, 217)
        Me.btnAllCategoryType.Name = "btnAllCategoryType"
        Me.btnAllCategoryType.Size = New System.Drawing.Size(123, 23)
        Me.btnAllCategoryType.TabIndex = 6
        Me.btnAllCategoryType.Text = "Change CategoryType"
        Me.btnAllCategoryType.UseVisualStyleBackColor = true
        '
        'btnAllNameType
        '
        Me.btnAllNameType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllNameType.ContextMenuStrip = Me.contextMenuStripSave
        Me.btnAllNameType.Image = Global.NetEdit.Resources.mouse_right_click_8x
        Me.btnAllNameType.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnAllNameType.Location = New System.Drawing.Point(422, 217)
        Me.btnAllNameType.Name = "btnAllNameType"
        Me.btnAllNameType.Size = New System.Drawing.Size(109, 23)
        Me.btnAllNameType.TabIndex = 5
        Me.btnAllNameType.Text = "Change NameType"
        Me.btnAllNameType.UseVisualStyleBackColor = true
        '
        'btnAllManaged
        '
        Me.btnAllManaged.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllManaged.ContextMenuStrip = Me.contextMenuStripSave
        Me.btnAllManaged.Image = Global.NetEdit.Resources.mouse_right_click_8x
        Me.btnAllManaged.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnAllManaged.Location = New System.Drawing.Point(318, 217)
        Me.btnAllManaged.Name = "btnAllManaged"
        Me.btnAllManaged.Size = New System.Drawing.Size(98, 23)
        Me.btnAllManaged.TabIndex = 4
        Me.btnAllManaged.Text = "Toggle Managed"
        Me.btnAllManaged.UseVisualStyleBackColor = true
        '
        'btnAllDescription
        '
        Me.btnAllDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllDescription.ContextMenuStrip = Me.contextMenuStripSave
        Me.btnAllDescription.Image = Global.NetEdit.Resources.mouse_right_click_8x
        Me.btnAllDescription.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnAllDescription.Location = New System.Drawing.Point(202, 217)
        Me.btnAllDescription.Name = "btnAllDescription"
        Me.btnAllDescription.Size = New System.Drawing.Size(110, 23)
        Me.btnAllDescription.TabIndex = 3
        Me.btnAllDescription.Text = "Change Description"
        Me.btnAllDescription.UseVisualStyleBackColor = true
        '
        'btnAllCategory
        '
        Me.btnAllCategory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllCategory.ContextMenuStrip = Me.contextMenuStripSave
        Me.btnAllCategory.Image = Global.NetEdit.Resources.mouse_right_click_8x
        Me.btnAllCategory.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnAllCategory.Location = New System.Drawing.Point(97, 217)
        Me.btnAllCategory.Name = "btnAllCategory"
        Me.btnAllCategory.Size = New System.Drawing.Size(99, 23)
        Me.btnAllCategory.TabIndex = 2
        Me.btnAllCategory.Text = "Change Category"
        Me.btnAllCategory.UseVisualStyleBackColor = true
        '
        'btnAllName
        '
        Me.btnAllName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnAllName.ContextMenuStrip = Me.contextMenuStripSave
        Me.btnAllName.Image = Global.NetEdit.Resources.mouse_right_click_8x
        Me.btnAllName.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnAllName.Location = New System.Drawing.Point(6, 217)
        Me.btnAllName.Name = "btnAllName"
        Me.btnAllName.Size = New System.Drawing.Size(85, 23)
        Me.btnAllName.TabIndex = 1
        Me.btnAllName.Text = "Change Name"
        Me.btnAllName.UseVisualStyleBackColor = true
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
        Me.lstAll.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstAll.HideSelection = false
        listViewItem1.StateImageIndex = 0
        Me.lstAll.Items.AddRange(New System.Windows.Forms.ListViewItem() {listViewItem1})
        Me.lstAll.LabelEdit = true
        Me.lstAll.Location = New System.Drawing.Point(6, 19)
        Me.lstAll.MultiSelect = false
        Me.lstAll.Name = "lstAll"
        Me.lstAll.Size = New System.Drawing.Size(1100, 192)
        Me.lstAll.TabIndex = 0
        Me.lstAll.UseCompatibleStateImageBehavior = false
        Me.lstAll.View = System.Windows.Forms.View.Details
        '
        'headAllNetworkName
        '
        Me.headAllNetworkName.Text = "Profile Name"
        Me.headAllNetworkName.Width = 118
        '
        'headAllNetworkCategory
        '
        Me.headAllNetworkCategory.Text = "Category"
        '
        'headAllNetworkDesc
        '
        Me.headAllNetworkDesc.Text = "Description"
        Me.headAllNetworkDesc.Width = 96
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
        Me.headAllSignatureMac.Width = 146
        '
        'headAllSignatureDNS
        '
        Me.headAllSignatureDNS.Text = "Signature DNS Suffix"
        Me.headAllSignatureDNS.Width = 115
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
        'headAllSignatureSource
        '
        Me.headAllSignatureSource.Text = "Signature Source"
        Me.headAllSignatureSource.Width = 100
        '
        'grpConnected
        '
        Me.grpConnected.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
                        Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.grpConnected.Controls.Add(Me.btnConnRefresh)
        Me.grpConnected.Controls.Add(Me.btnConnChangeType)
        Me.grpConnected.Controls.Add(Me.lstConnected)
        Me.grpConnected.Location = New System.Drawing.Point(12, 12)
        Me.grpConnected.Name = "grpConnected"
        Me.grpConnected.Size = New System.Drawing.Size(1112, 300)
        Me.grpConnected.TabIndex = 0
        Me.grpConnected.TabStop = false
        Me.grpConnected.Text = "Connected Networks:"
        '
        'btnConnRefresh
        '
        Me.btnConnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnConnRefresh.Location = New System.Drawing.Point(478, 271)
        Me.btnConnRefresh.Name = "btnConnRefresh"
        Me.btnConnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnConnRefresh.TabIndex = 1
        Me.btnConnRefresh.Text = "Refresh"
        Me.btnConnRefresh.UseVisualStyleBackColor = true
        '
        'btnConnChangeType
        '
        Me.btnConnChangeType.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnConnChangeType.Location = New System.Drawing.Point(560, 271)
        Me.btnConnChangeType.Name = "btnConnChangeType"
        Me.btnConnChangeType.Size = New System.Drawing.Size(81, 23)
        Me.btnConnChangeType.TabIndex = 2
        Me.btnConnChangeType.Text = "Change Type"
        Me.btnConnChangeType.UseVisualStyleBackColor = true
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
        Me.lstConnected.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstConnected.HideSelection = false
        Me.lstConnected.Items.AddRange(New System.Windows.Forms.ListViewItem() {listViewItem2})
        Me.lstConnected.Location = New System.Drawing.Point(6, 19)
        Me.lstConnected.MultiSelect = false
        Me.lstConnected.Name = "lstConnected"
        Me.lstConnected.Size = New System.Drawing.Size(1100, 246)
        Me.lstConnected.TabIndex = 0
        Me.lstConnected.UseCompatibleStateImageBehavior = false
        Me.lstConnected.View = System.Windows.Forms.View.Details
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
        'timerDelayedScan
        '
        Me.timerDelayedScan.Interval = 50
        '
        'sfdBackup
        '
        Me.sfdBackup.DefaultExt = "reg"
        Me.sfdBackup.Filter = "Registry Entries|*.reg|All Files|*.*"
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblVersion.AutoSize = true
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblVersion.Location = New System.Drawing.Point(1112, 621)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(21, 9)
        Me.lblVersion.TabIndex = 2
        Me.lblVersion.Text = "1.0.0"
        '
        'NetEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(1136, 630)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.grpConnected)
        Me.Controls.Add(Me.grpAll)
        Me.Icon = Global.NetEdit.Resources.NetEdit
        Me.Name = "NetEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NetEdit"
        Me.grpAll.ResumeLayout(false)
        Me.grpAll.PerformLayout
        Me.toolStripBackup.ResumeLayout(false)
        Me.toolStripBackup.PerformLayout
        Me.contextMenuStripSave.ResumeLayout(false)
        Me.grpAllSignature.ResumeLayout(false)
        Me.grpAllSignature.PerformLayout
        Me.grpConnected.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout
    End Sub
    Private lblVersion As System.Windows.Forms.Label
    Private WithEvents contextMenuStripSaveReg As System.Windows.Forms.ToolStripMenuItem
    Private contextMenuStripSave As System.Windows.Forms.ContextMenuStrip
    Private WithEvents btnAllDeleteProfile As System.Windows.Forms.Button
    Private WithEvents toolStripBackupAllProfiles As System.Windows.Forms.ToolStripMenuItem
    Private sfdBackup As System.Windows.Forms.SaveFileDialog
    Private WithEvents toolStripBackupSelected As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripBackupAllBoth As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripBackupAllSignatures As System.Windows.Forms.ToolStripMenuItem
    Private toolStripBtnBackup As System.Windows.Forms.ToolStripDropDownButton
    Private toolStripBackup As System.Windows.Forms.ToolStrip
    Private WithEvents btnAllRefresh As System.Windows.Forms.Button
    Private WithEvents btnExit As System.Windows.Forms.Button
    Private WithEvents btnAllLocationWizard As System.Windows.Forms.Button
    Private WithEvents btnAllNetworkWizard As System.Windows.Forms.Button
    Private WithEvents btnConnRefresh As System.Windows.Forms.Button
    Private WithEvents timerDelayedScan As System.Windows.Forms.Timer
    Private WithEvents headConnType As System.Windows.Forms.ColumnHeader
    Private WithEvents headConnV6Status As System.Windows.Forms.ColumnHeader
    Private WithEvents headConnV4Status As System.Windows.Forms.ColumnHeader
    Private WithEvents headConnInterface As System.Windows.Forms.ColumnHeader
    Private WithEvents headConnName As System.Windows.Forms.ColumnHeader
    Private WithEvents lstConnected As System.Windows.Forms.ListView
    Private WithEvents btnConnChangeType As System.Windows.Forms.Button
    Private grpConnected As System.Windows.Forms.GroupBox
    Private WithEvents headAllSignatureSource As System.Windows.Forms.ColumnHeader
    Private WithEvents headAllSignatureFirstNetwork As System.Windows.Forms.ColumnHeader
    Private WithEvents headAllSignatureDesc As System.Windows.Forms.ColumnHeader
    Private WithEvents headAllSignatureDNS As System.Windows.Forms.ColumnHeader
    Private WithEvents headAllSignatureMac As System.Windows.Forms.ColumnHeader
    Private WithEvents headAllNetworkCategoryType As System.Windows.Forms.ColumnHeader
    Private WithEvents headAllNetworkNameType As System.Windows.Forms.ColumnHeader
    Private WithEvents headAllNetworkManaged As System.Windows.Forms.ColumnHeader
    Private WithEvents headAllNetworkDesc As System.Windows.Forms.ColumnHeader
    Private WithEvents headAllNetworkCategory As System.Windows.Forms.ColumnHeader
    Private WithEvents headAllNetworkName As System.Windows.Forms.ColumnHeader
    Private WithEvents lstAll As System.Windows.Forms.ListView
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
    Private WithEvents btnAllSignatureDelete As System.Windows.Forms.Button
    Private WithEvents btnAllDeleteBoth As System.Windows.Forms.Button
    Private grpAllSignature As System.Windows.Forms.GroupBox
    Private grpAll As System.Windows.Forms.GroupBox
End Class
