Option Explicit On
Option Strict On
Option Compare Binary
Option Infer On

Public Partial Class NetEdit
    Public Sub New()
        Me.InitializeComponent()
        
        If WalkmanLib.IsAdmin Then
            Me.Text = "[Admin] " & Me.Text
        End If
        
        If Environment.OSVersion.Version.Major >= 6 And Environment.OSVersion.Version.Minor >= 2 Then
            ' hide wizard buttons on Win8+
            btnAllLocationWizard.Visible = False
            btnAllNetworkWizard.Visible = False
        End If
        
        timerDelayedScan.Start()
    End Sub
    
    Sub timerDelayedScan_Tick() Handles timerDelayedScan.Tick
        timerDelayedScan.Stop()
        
        lstConnectedSelectionUpdated()  ' These make sure the buttons start disabled
        lstAllSelectionUpdated()
        
        PopulateNetworkList()
        PopulateProfileList()
        
    End Sub
    
    ' =================== Connected Networks ===================
    
    Structure ActiveNetworkProfile
        Property InterfaceIndex() As Integer
        Property Name() As String
        Property InterfaceAlias() As String
        Property IPv4Connectivity() As String
        Property IPv6Connectivity() As String
        Property NetworkCategory() As String
    End Structure
    
    Sub lstConnectedSelectionUpdated() Handles lstConnected.SelectedIndexChanged
        If lstConnected.SelectedIndices.Count = 0 Then
            btnConnChangeType.Enabled = False
        Else
            btnConnChangeType.Enabled = True
        End If
    End Sub
    
    ' ------------------- Read -------------------
    
    Function PowerShellPath() As String
        If Environment.Is64BitOperatingSystem And Not Environment.Is64BitProcess Then
            Return "C:\Windows\Sysnative\WindowsPowerShell\v1.0\powershell.exe"
        Else
            Return "C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe"
        End If
    End Function
    
    Function ProcessLineContents(line As String) As String
        If line.Contains(":") Then
            Dim seperatorIndex = line.IndexOf(":") + 1
            
            line = line.Substring(seperatorIndex)
            line = line.Trim()
            Return line
        Else
            Return "Error: """ & line & """ doesn't contain seperator!"
        End If
    End Function
    
    Function GetNetworks() As List(Of ActiveNetworkProfile)
        Dim PowerShellFunctionError As String = ""
        Dim PowerShellFunctionExitCode As Integer
        Dim PowerShellFunctionOutput As String
        
        Try
            PowerShellFunctionOutput = WalkmanLib.RunAndGetOutput(PowerShellPath, "Get-NetConnectionProfile", False, PowerShellFunctionError, PowerShellFunctionExitCode)
            
            If PowerShellFunctionExitCode <> 0 Then Throw New Exception("powershell.exe: " & PowerShellFunctionError)
            
            Dim returnProfiles As New List(Of ActiveNetworkProfile)
            Dim tmpProfile As ActiveNetworkProfile = New ActiveNetworkProfile
            
            For Each line As String In PowerShellFunctionOutput.Split(Chr(13)) 'Chr(13): Carriage Return (10 is Line Feed)
                line = line.Trim()
                
                If     line.StartsWith("Name",             True, Nothing) Then
                    tmpProfile.Name =                 ProcessLineContents(line)
                ElseIf line.StartsWith("InterfaceAlias",   True, Nothing) Then
                    tmpProfile.InterfaceAlias =       ProcessLineContents(line)
                ElseIf line.StartsWith("InterfaceIndex",   True, Nothing) Then
                    tmpProfile.InterfaceIndex = CType(ProcessLineContents(line), Integer)
                ElseIf line.StartsWith("NetworkCategory",  True, Nothing) Then
                    tmpProfile.NetworkCategory =      ProcessLineContents(line)
                ElseIf line.StartsWith("IPv4Connectivity", True, Nothing) Then
                    tmpProfile.IPv4Connectivity =     ProcessLineContents(line)
                ElseIf line.StartsWith("IPv6Connectivity", True, Nothing) Then
                    tmpProfile.IPv6Connectivity =     ProcessLineContents(line)
                ElseIf line = ""
                    returnProfiles.Add(tmpProfile)
                    tmpProfile = New ActiveNetworkProfile
                End If
            Next
            
            Return returnProfiles
        Catch ex As Exception
            WalkmanLib.ErrorDialog(ex)
            
            Return New List(Of ActiveNetworkProfile)
        End Try
    End Function
    
    Sub PopulateNetworkList() Handles btnConnRefresh.Click
        
        lstConnected.Items.Clear()
        
        Dim tmpListViewItem As ListViewItem
        For Each connectedNetwork In GetNetworks()
            tmpListViewItem = New ListViewItem(New String() {connectedNetwork.Name, connectedNetwork.InterfaceAlias, _
                connectedNetwork.IPv4Connectivity, connectedNetwork.IPv6Connectivity, connectedNetwork.NetworkCategory})
            
            tmpListViewItem.Tag = connectedNetwork.InterfaceIndex
            
            lstConnected.Items.Add(tmpListViewItem)
        Next
        
        lstConnected.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        
        lstConnectedSelectionUpdated()
    End Sub
    
    ' ------------------- Write -------------------
    
    Sub btnConnChangeType_Click() Handles btnConnChangeType.Click, lstConnected.DoubleClick
        If lstConnected.SelectedIndices.Count <> 0 Then
            
            If lstConnected.SelectedItems.Item(0).SubItems.Item(4).Text = "Private" Then
                NetworkTypeSelector.SelectedNetworkType = NetworkCategory.Private
            Else
                NetworkTypeSelector.SelectedNetworkType = NetworkCategory.Public
            End If
            
            If NetworkTypeSelector.ShowDialog() = DialogResult.OK Then
                Dim currentNetworkIndex As Integer = DirectCast(lstConnected.SelectedItems.Item(0).Tag, Integer)
                
                Dim PowerShellFunctionError As String = ""
                Dim PowerShellFunctionExitCode As Integer
                Dim PowerShellFunctionOutput As String
                
                Try
                    Dim PowerShellArgs = "Set-NetConnectionProfile -InterfaceIndex " & currentNetworkIndex & " -NetworkCategory " & NetworkTypeSelector.SelectedNetworkType.ToString
                    
                    PowerShellFunctionOutput = WalkmanLib.RunAndGetOutput(PowerShellPath, PowerShellArgs, False, PowerShellFunctionError, PowerShellFunctionExitCode)
                    
                    If PowerShellFunctionExitCode <> 0 Then
                        If PowerShellFunctionError.Contains("PermissionDenied") Then
                            If MsgBox("Permission Denied! Either run " & My.Application.Info.AssemblyName & " as an administrator or run the PowerShell command as administrator." & vbNewLine & vbNewLine & _
                                "Attempt to launch PowerShell as administrator?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Permission Denied") = MsgBoxResult.Yes Then
                                
                                ' apparently you can't run programs in Sysnative as administrator...
                                'WalkmanLib.RunAsAdmin(PowerShellPath, PowerShellArgs)
                                WalkmanLib.RunAsAdmin("cmd.exe", "/c " & PowerShellPath & " " & PowerShellArgs)
                                
                                ' sleep the thread to delay the list update
                                Threading.Thread.Sleep(500)
                            End If
                        Else
                            Throw New Exception("powershell.exe: " & PowerShellFunctionError)
                        End If
                    End If
                Catch ex As Exception
                    WalkmanLib.ErrorDialog(ex)
                End Try
                
                PopulateNetworkList()
            End If
        End If
    End Sub
    
    ' =================== All Profiles ===================
    
    Structure NetworkProfile
        ''' <summary>REG_SZ</summary>
        Property ProfileGuid() As String
        ''' <summary>REG_SZ</summary>
        Property ProfileName() As String
        ''' <summary>REG_DWORD</summary>
        Property Category() As Integer
        ''' <summary>REG_SZ</summary>
        Property Description() As String
        ''' <summary>REG_DWORD</summary>
        Property Managed() As Integer
        ''' <summary>REG_DWORD</summary>
        Property NameType() As Integer
        ''' <summary>REG_DWORD</summary>
        Property CategoryType() As Integer
        ''' <summary>REG_BINARY</summary>
        Property SignatureDefaultGatewayMac() As Byte()
        ''' <summary>REG_SZ</summary>
        Property SignatureDNSSuffix() As String
        ''' <summary>REG_SZ</summary>
        Property SignatureDescription() As String
        ''' <summary>REG_SZ</summary>
        Property SignatureFirstNetwork() As String
        ''' <summary>REG_DWORD</summary>
        Property SignatureSource() As Integer
        ''' <summary>Keyname of the profile's signature</summary>
        Property SignatureKey() As String
    End Structure
    
    Sub lstAllSelectionUpdated() Handles lstAll.SelectedIndexChanged
        Dim enableButtons As Boolean = (lstAll.SelectedIndices.Count <> 0)
        
        btnAllName.Enabled = enableButtons
        btnAllCategory.Enabled = enableButtons
        btnAllDescription.Enabled = enableButtons
        btnAllManaged.Enabled = False 'enableButtons
        btnAllNameType.Enabled = enableButtons
        btnAllCategoryType.Enabled = False 'enableButtons
        btnAllDeleteNetwork.Enabled = enableButtons
        btnAllLocationWizard.Enabled = enableButtons
        btnAllNetworkWizard.Enabled = enableButtons
        btnAllSignatureGateway.Enabled = False 'enableButtons
        btnAllSignatureDNS.Enabled = enableButtons
        btnAllSignatureDescription.Enabled = enableButtons
        btnAllSignatureFirstNetwork.Enabled = enableButtons
        btnAllSignatureSource.Enabled = False 'enableButtons
        btnAllSignatureDelete.Enabled = enableButtons
        btnAllDeleteBoth.Enabled = enableButtons
    End Sub
    
    ' ------------------- Read -------------------
    
    Function GetNativeKey() As Win32.RegistryKey
        ' thanks to https://stackoverflow.com/a/13232372/2999220
        Dim localKey As Win32.RegistryKey
        
        If Environment.Is64BitOperatingSystem Then
            localKey = Win32.RegistryKey.OpenBaseKey(Win32.RegistryHive.LocalMachine, Win32.RegistryView.Registry64)
        Else
            localKey = Win32.RegistryKey.OpenBaseKey(Win32.RegistryHive.LocalMachine, Win32.RegistryView.Registry32)
        End If
        
        Return localKey
    End Function
    
    Const ProfileRegPath As String = "SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Profiles\"
    Const SignatureRegPath As String = "SOFTWARE\Microsoft\Windows NT\CurrentVersion\NetworkList\Signatures\"
    
    Function GetProfiles() As List(Of NetworkProfile)
        Dim localKey = GetNativeKey()
        
        ' this fails if not running as admin... not sure how best to handle that
        localKey = localKey.OpenSubKey(ProfileRegPath)
        
        If localKey Is Nothing Then
            MsgBox("Error loading registry key!", MsgBoxStyle.Critical)
            Return New List(Of NetworkProfile)
        End If
        
        Dim returnProfiles As New List(Of NetworkProfile)
        Dim tmpProfile As NetworkProfile = New NetworkProfile
        
        Try
            For Each subKeyName As String In localKey.GetSubKeyNames
                Dim tmpKey = localKey.OpenSubKey(subKeyName)
                
                tmpProfile.ProfileGuid = tmpKey.Name.Substring(tmpKey.Name.LastIndexOf("\") +1)
                
                If tmpKey.GetValue("ProfileName")  IsNot Nothing Then tmpProfile.ProfileName =             tmpKey.GetValue("ProfileName").ToString
                If tmpKey.GetValue("Category")     IsNot Nothing Then tmpProfile.Category =     DirectCast(tmpKey.GetValue("Category"), Integer)
                If tmpKey.GetValue("Description")  IsNot Nothing Then tmpProfile.Description =             tmpKey.GetValue("Description").ToString
                If tmpKey.GetValue("Managed")      IsNot Nothing Then tmpProfile.Managed =      DirectCast(tmpKey.GetValue("Managed"), Integer)
                If tmpKey.GetValue("NameType")     IsNot Nothing Then tmpProfile.NameType =     DirectCast(tmpKey.GetValue("NameType"), Integer)
                If tmpKey.GetValue("CategoryType") IsNot Nothing Then tmpProfile.CategoryType = DirectCast(tmpKey.GetValue("CategoryType"), Integer) Else tmpProfile.CategoryType = -1
                
                returnProfiles.Add(tmpProfile)
                tmpProfile = New NetworkProfile
            Next
        Catch ex As Exception
            WalkmanLib.ErrorDialog(ex)
        End Try
        
        Return returnProfiles
    End Function
    
    Function GetProfileSignatures() As List(Of NetworkProfile)
        Dim localKeyRoot = GetNativeKey()
        
        localKeyRoot = localKeyRoot.OpenSubKey(SignatureRegPath)
        
        If localKeyRoot Is Nothing Then
            MsgBox("Error loading registry key!", MsgBoxStyle.Critical)
            Return New List(Of NetworkProfile)
        End If
        
        Dim returnProfiles As New List(Of NetworkProfile)
        Dim tmpProfile As NetworkProfile = New NetworkProfile
        
        Try
            Dim localKey As Win32.RegistryKey = localKeyRoot.OpenSubKey("Unmanaged")
            
            For Each subKeyName As String In localKey.GetSubKeyNames
                Dim tmpKey = localKey.OpenSubKey(subKeyName)
                
                tmpProfile.SignatureKey = tmpKey.Name.Substring(tmpKey.Name.LastIndexOf("\") +1)
                tmpProfile.ProfileGuid = tmpKey.GetValue("ProfileGuid").ToString
                
                If tmpKey.GetValue("DefaultGatewayMac") IsNot Nothing Then tmpProfile.SignatureDefaultGatewayMac = DirectCast(tmpKey.GetValue("DefaultGatewayMac"), Byte())
                If tmpKey.GetValue("Description")       IsNot Nothing Then tmpProfile.SignatureDescription =       tmpKey.GetValue("Description").ToString
                If tmpKey.GetValue("DnsSuffix")         IsNot Nothing Then tmpProfile.SignatureDNSSuffix =         tmpKey.GetValue("DnsSuffix").ToString
                If tmpKey.GetValue("FirstNetwork")      IsNot Nothing Then tmpProfile.SignatureFirstNetwork =      tmpKey.GetValue("FirstNetwork").ToString
                If tmpKey.GetValue("Source")            IsNot Nothing Then tmpProfile.SignatureSource = DirectCast(tmpKey.GetValue("Source"), Integer)
                
                returnProfiles.Add(tmpProfile)
                tmpProfile = New NetworkProfile
            Next
            
            localKey = localKeyRoot.OpenSubKey("Managed")
            
            For Each subKeyName As String In localKey.GetSubKeyNames
                Dim tmpKey = localKey.OpenSubKey(subKeyName)
                
                tmpProfile.SignatureKey = tmpKey.Name.Substring(tmpKey.Name.LastIndexOf("\") +1)
                tmpProfile.ProfileGuid = tmpKey.GetValue("ProfileGuid").ToString
                
                If tmpKey.GetValue("DefaultGatewayMac") IsNot Nothing Then tmpProfile.SignatureDefaultGatewayMac = DirectCast(tmpKey.GetValue("DefaultGatewayMac"), Byte())
                If tmpKey.GetValue("Description")       IsNot Nothing Then tmpProfile.SignatureDescription =       tmpKey.GetValue("Description").ToString
                If tmpKey.GetValue("DnsSuffix")         IsNot Nothing Then tmpProfile.SignatureDNSSuffix =         tmpKey.GetValue("DnsSuffix").ToString
                If tmpKey.GetValue("FirstNetwork")      IsNot Nothing Then tmpProfile.SignatureFirstNetwork =      tmpKey.GetValue("FirstNetwork").ToString
                If tmpKey.GetValue("Source")            IsNot Nothing Then tmpProfile.SignatureSource = DirectCast(tmpKey.GetValue("Source"), Integer)
                
                returnProfiles.Add(tmpProfile)
                tmpProfile = New NetworkProfile
            Next
        Catch ex As Exception
            WalkmanLib.ErrorDialog(ex)
        End Try
        
        Return returnProfiles
    End Function
    
    Sub PopulateProfileList() Handles btnAllRefresh.Click
        
        lstAll.Items.Clear()
        
        Dim tmpListViewItem As ListViewItem
        For Each profile In GetProfiles()
            Dim profileCategory As String
            Select Case profile.Category
                Case 0: profileCategory = "Public"
                Case 1: profileCategory = "Home"
                Case 2: profileCategory = "Work/Domain"
                Case Else: profileCategory = profile.Category.ToString()
            End Select
            
            Dim profileManaged As String
            Select Case profile.Managed
                Case 0: profileManaged = "No"
                Case 1: profileManaged = "Yes"
                Case Else: profileManaged = profile.Managed.ToString()
            End Select
            
            Dim profileNameType As String
            Select Case profile.NameType
                Case 6: profileNameType = "Wired Network"
                Case 23: profileNameType = "VPN"
                Case 71: profileNameType = "Wireless Network"
                Case 243: profileNameType = "Mobile Broadband"
                Case Else: profileNameType = profile.NameType.ToString()
            End Select
            
            tmpListViewItem = New ListViewItem(New String() {profile.ProfileName, profileCategory, profile.Description, profileManaged, profileNameType, IIf(profile.CategoryType = -1, "", profile.CategoryType).ToString(), _
                "", "", "", "", "", ""})
            
            tmpListViewItem.Tag = profile.ProfileGuid
            
            lstAll.Items.Add(tmpListViewItem)
        Next
        
        lstAll.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        
        lstAllSelectionUpdated()
        
        Dim assignedSignature As Boolean
        For Each profile In GetProfileSignatures()
            assignedSignature = False
            
            For Each itemProfile As ListViewItem In lstAll.Items
                If itemProfile.Tag.ToString() = profile.ProfileGuid Then
                    
                    itemProfile.SubItems.Item(6).Text = BitConverter.ToString(profile.SignatureDefaultGatewayMac).Replace("-", ":")
                    itemProfile.SubItems.Item(7).Text = profile.SignatureDNSSuffix
                    itemProfile.SubItems.Item(8).Text = profile.SignatureDescription
                    itemProfile.SubItems.Item(9).Text = profile.SignatureFirstNetwork
                    itemProfile.SubItems.Item(10).Text = profile.SignatureSource.ToString()
                    itemProfile.SubItems.Item(11).Text = profile.SignatureKey
                    
                    assignedSignature = True
                    Exit For
                End If
            Next
            
            If assignedSignature = False Then ' no profile with the same GUID, add a new entry
                tmpListViewItem = New ListViewItem(New String() {"", "", "", "", "", "", _
                    BitConverter.ToString(profile.SignatureDefaultGatewayMac).Replace("-", ":"), profile.SignatureDNSSuffix, profile.SignatureDescription, _
                    profile.SignatureFirstNetwork, profile.SignatureSource.ToString(), profile.SignatureKey})
                
                tmpListViewItem.Tag = profile.ProfileGuid
                
                lstAll.Items.Add(tmpListViewItem)
            End If
        Next
        
        lstAll.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
        
        lstAllSelectionUpdated()
    End Sub
    
    ' ------------------- Write -------------------
    
    Sub SetKey(keyPath As String, value As String, data As Object)
        Try
            Dim localKey = GetNativeKey()
            localKey = localKey.OpenSubKey(keyPath, True)
            localKey.SetValue(value, data)
            
            ' this uses 32-bit registry on 64-bit windows, we need 64-bit registry on 64-bit windows
            'Win32.Registry.SetValue(keyPath, value, data)
        Catch ex As UnauthorizedAccessException
            If MsgBox("Permission Denied! Either run " & My.Application.Info.AssemblyName & " as an administrator or run the system registry editor." & vbNewLine & vbNewLine & _
                "Attempt to launch a system tool as administrator?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Permission Denied") = MsgBoxResult.Yes Then
                
                WalkmanLib.RunAsAdmin("reg.exe", "ADD """ & keyPath & """ /v """ & value & """ /d """ & data.ToString() & """ /f ")
                
                ' sleep the thread to delay a list update
                Threading.Thread.Sleep(100)
            End If
        Catch ex As Exception
            WalkmanLib.ErrorDialog(ex)
        End Try
        
        PopulateProfileList()
    End Sub
    
    Sub DeleteKey(keyPath As String)
        Dim localKey = GetNativeKey()
        
        localKey.DeleteSubKey(keyPath)
        
        PopulateProfileList()
    End Sub
    
    Sub lstAll_AfterLabelEdit(sender As Object, e As LabelEditEventArgs) Handles lstAll.AfterLabelEdit
        SetKey(ProfileRegPath & lstAll.Items.Item(e.Item).Tag.ToString, "ProfileName", e.Label)
    End Sub
    
    Sub btnAllName_Click() Handles btnAllName.Click
        If lstAll.SelectedIndices.Count <> 0 Then
            Dim response = InputBox("Enter new name:", "Set Profile Name", lstAll.SelectedItems.Item(0).Text)
            If response <> "" Then
                SetKey(ProfileRegPath & lstAll.SelectedItems.Item(0).Tag.ToString, "ProfileName", response)
            End If
        End If
    End Sub
    
    Sub btnAllCategory_Click() Handles btnAllCategory.Click
        If lstAll.SelectedIndices.Count <> 0 Then
            If lstAll.SelectedItems.Item(0).SubItems.Item(1).Text = "Home" Then
                NetworkTypeSelector.SelectedNetworkType = NetworkCategory.Private
            Else
                NetworkTypeSelector.SelectedNetworkType = NetworkCategory.Public
            End If
            
            If NetworkTypeSelector.ShowDialog() = DialogResult.OK Then
                
                Dim profileCategory As Integer
                Select Case NetworkTypeSelector.SelectedNetworkType
                    Case NetworkCategory.Public: profileCategory = 0
                    Case NetworkCategory.Private: profileCategory = 1
                End Select
                
                SetKey(ProfileRegPath & lstAll.SelectedItems.Item(0).Tag.ToString, "Category", profileCategory)
            End If
        End If
    End Sub
    
    Sub btnAllDescription_Click() Handles btnAllDescription.Click
        If lstAll.SelectedIndices.Count <> 0 Then
            Dim response = InputBox("Enter new description:", "Set Profile Description", lstAll.SelectedItems.Item(0).SubItems.Item(2).Text)
            If response <> "" Then
                SetKey(ProfileRegPath & lstAll.SelectedItems.Item(0).Tag.ToString, "Description", response)
            End If
        End If
    End Sub
    
    Sub btnAllManaged_Click() Handles btnAllManaged.Click
        
    End Sub
    
    Sub btnAllNameType_Click() Handles btnAllNameType.Click
        If lstAll.SelectedIndices.Count <> 0 Then
            Select Case lstAll.SelectedItems.Item(0).SubItems.Item(4).Text
                Case "Wired Network"
                    NameTypeSelector.SelectedNameType = 6
                Case "VPN"
                    NameTypeSelector.SelectedNameType = 23
                Case "Wireless Network"
                    NameTypeSelector.SelectedNameType = 71
                Case "Mobile Broadband"
                    NameTypeSelector.SelectedNameType = 243
                Case Else
                    NameTypeSelector.SelectedNameType = CType(lstAll.SelectedItems.Item(0).SubItems.Item(4).Text, Integer)
            End Select
            
            If NameTypeSelector.ShowDialog() = DialogResult.OK Then
                SetKey(ProfileRegPath & lstAll.SelectedItems.Item(0).Tag.ToString, "NameType", NameTypeSelector.SelectedNameType)
            End If
        End If
    End Sub
    
    Sub btnAllCategoryType_Click() Handles btnAllCategoryType.Click
        
    End Sub
    
    
    Function GetSignatureManagedString(inputItem As ListViewItem) As String
        If inputItem.SubItems.Item(3).Text = "Yes" Then
            Return "Managed\"
        ElseIf inputItem.SubItems.Item(3).Text = "No" Then
            Return "Unmanaged\"
        Else ' no network associated with signature, have to search for signature
            
            Dim localKeyRoot = GetNativeKey()
            localKeyRoot = localKeyRoot.OpenSubKey(SignatureRegPath)
            
            Dim localKey As Win32.RegistryKey = localKeyRoot.OpenSubKey("Unmanaged")
            For Each subKeyName As String In localKey.GetSubKeyNames
                Dim tmpKey = localKey.OpenSubKey(subKeyName)
                
                If tmpKey.Name.Substring(tmpKey.Name.LastIndexOf("\") +1) = inputItem.SubItems.Item(11).Text Then
                    Return "Unmanaged\"   ' found the SignatureKey in the Unmanaged signatures list
                End If
            Next
            
            localKey = localKeyRoot.OpenSubKey("Managed")
            For Each subKeyName As String In localKey.GetSubKeyNames
                Dim tmpKey = localKey.OpenSubKey(subKeyName)
                
                If tmpKey.Name.Substring(tmpKey.Name.LastIndexOf("\") +1) = inputItem.SubItems.Item(11).Text Then
                    Return "Managed\"   ' found the SignatureKey in the Managed signatures list
                End If
            Next
            
            Throw New Exception("Signature not found in either of the Unmanaged or Managed signatures!")
        End If
    End Function
    
    Sub btnAllSignatureGateway_Click() Handles btnAllSignatureGateway.Click
        
    End Sub
    
    Sub btnAllSignatureDNS_Click() Handles btnAllSignatureDNS.Click
        If lstAll.SelectedIndices.Count <> 0 Then
            Dim response = InputBox("Enter DNS suffix:", "Set Signature's DNS Suffix", lstAll.SelectedItems.Item(0).SubItems.Item(7).Text)
            If response <> "" Then
                SetKey(SignatureRegPath & GetSignatureManagedString(lstAll.SelectedItems.Item(0)) & lstAll.SelectedItems.Item(0).SubItems.Item(11).Text, "DnsSuffix", response)
            End If
        End If
    End Sub
    
    Sub btnAllSignatureDescription_Click() Handles btnAllSignatureDescription.Click
        If lstAll.SelectedIndices.Count <> 0 Then
            Dim response = InputBox("Enter Description:", "Set Signature's Description", lstAll.SelectedItems.Item(0).SubItems.Item(8).Text)
            If response <> "" Then
                SetKey(SignatureRegPath & GetSignatureManagedString(lstAll.SelectedItems.Item(0)) & lstAll.SelectedItems.Item(0).SubItems.Item(11).Text, "Description", response)
            End If
        End If
    End Sub
    
    Sub btnAllSignatureFirstNetwork_Click() Handles btnAllSignatureFirstNetwork.Click
        If lstAll.SelectedIndices.Count <> 0 Then
            Dim response = InputBox("Enter FirstNetwork name:", "Set Signature's FirstNetwork name", lstAll.SelectedItems.Item(0).SubItems.Item(9).Text)
            If response <> "" Then
                SetKey(SignatureRegPath & GetSignatureManagedString(lstAll.SelectedItems.Item(0)) & lstAll.SelectedItems.Item(0).SubItems.Item(11).Text, "FirstNetwork", response)
            End If
        End If
    End Sub
    
    Sub btnAllSignatureSource_Click() Handles btnAllSignatureSource.Click
        
    End Sub
    
    
    Sub btnAllSignatureDelete_Click() Handles btnAllSignatureDelete.Click
        If lstAll.SelectedIndices.Count <> 0 Then
            If MsgBox("Are you sure you want to delete the selected signature? This cannot be undone, and if a profile was assigned to it that profile will not be reassigned if it is detected again.", _
              MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Deleting a Network Signature") = MsgBoxResult.Yes Then
                
                DeleteKey(SignatureRegPath & GetSignatureManagedString(lstAll.SelectedItems.Item(0)) & lstAll.SelectedItems.Item(0).SubItems.Item(11).Text)
            End If
        End If
    End Sub
    
    Sub btnAllDeleteNetwork_Click() Handles btnAllDeleteNetwork.Click
        If lstAll.SelectedIndices.Count <> 0 Then
            If MsgBox("Are you sure you want to delete network """ & lstAll.SelectedItems.Item(0).Text & """? This cannot be undone, but if it matches a signature then Windows will re-create it.", _
              MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Deleting a Network Profile") = MsgBoxResult.Yes Then
                DeleteKey(ProfileRegPath & lstAll.SelectedItems.Item(0).Tag.ToString)
            End If
        End If
    End Sub
    
    Sub btnAllDeleteBoth_Click() Handles btnAllDeleteBoth.Click
        If lstAll.SelectedIndices.Count <> 0 Then
            If MsgBox("Are you sure you want to delete network """ & lstAll.SelectedItems.Item(0).Text & """ and it's signature? This cannot be undone, but both will be re-created by Windows if encountered again.", _
              MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Deleting a Network Profile & Signature") = MsgBoxResult.Yes Then
                
                Dim signatureFullPath As String = GetSignatureManagedString(lstAll.SelectedItems.Item(0)) & lstAll.SelectedItems.Item(0).SubItems.Item(11).Text
                ' have to get the signature path before deleting the profile as DeleteKey() refreshes the list
                
                DeleteKey(ProfileRegPath & lstAll.SelectedItems.Item(0).Tag.ToString)
                DeleteKey(SignatureRegPath & signatureFullPath)
            End If
        End If
    End Sub
    
    Sub btnAllLocationWizard_Click() Handles btnAllLocationWizard.Click
        If lstAll.SelectedIndices.Count <> 0 Then
            Process.Start("C:\Windows\system32\rundll32.exe", "pnidui.dll,NwCategoryWiz " & lstAll.SelectedItems.Item(0).Tag.ToString())
        End If
    End Sub
    
    Sub btnAllNetworkWizard_Click() Handles btnAllNetworkWizard.Click
        If lstAll.SelectedIndices.Count <> 0 Then
            Process.Start("C:\Windows\system32\rundll32.exe", "pnidui.dll,NwCategoryWiz " & lstAll.SelectedItems.Item(0).Tag.ToString() & " 1")
        End If
    End Sub
    
    Sub btnExit_Click() Handles btnExit.Click
        Application.Exit()
    End Sub
End Class
