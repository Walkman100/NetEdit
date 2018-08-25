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
        
        timerDelayedScan.Start()
    End Sub
    
    Sub timerDelayedScan_Tick() Handles timerDelayedScan.Tick
        timerDelayedScan.Stop()
        
        lstAllSelectionUpdated()  ' These make sure the buttons start disabled
        lstConnectedSelectionUpdated()
        
        PopulateProfileList()
        
        PopulateNetworkList()
        
    End Sub
    
    ' =================== All Profiles ===================
    
    Structure NetworkProfile
        ''' <summary>REG_SZ</summary>
        Property ProfileGuid() As Guid
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
        Property SignatureDefaultGatewayMac() As String
        ''' <summary>REG_SZ</summary>
        Property SignatureDNSSuffix() As String
        ''' <summary>REG_SZ</summary>
        Property SignatureDescription() As String
        ''' <summary>REG_SZ</summary>
        Property SignatureFirstNetwork() As String
        ''' <summary>REG_DWORD</summary>
        Property SignatureSource() As String
    End Structure
    
    Sub lstAllSelectionUpdated() Handles lstAll.SelectedIndexChanged
        If lstAll.SelectedIndices.Count = 0 Then
            btnAllName.Enabled = False
            btnAllCategory.Enabled = False
            btnAllDescription.Enabled = False
            btnAllManaged.Enabled = False
            btnAllNameType.Enabled = False
            btnAllCategoryType.Enabled = False
            btnAllDeleteNetwork.Enabled = False
            btnAllSignatureGateway.Enabled = False
            btnAllSignatureDNS.Enabled = False
            btnAllSignatureDescription.Enabled = False
            btnAllSignatureFirstNetwork.Enabled = False
            btnAllSignatureSource.Enabled = False
            btnAllSignatureDelete.Enabled = False
            btnAllDeleteBoth.Enabled = False
        Else
            btnAllName.Enabled = True
            btnAllCategory.Enabled = True
            btnAllDescription.Enabled = True
            btnAllManaged.Enabled = True
            btnAllNameType.Enabled = True
            btnAllCategoryType.Enabled = True
            btnAllDeleteNetwork.Enabled = True
            btnAllSignatureGateway.Enabled = True
            btnAllSignatureDNS.Enabled = True
            btnAllSignatureDescription.Enabled = True
            btnAllSignatureFirstNetwork.Enabled = True
            btnAllSignatureSource.Enabled = True
            btnAllSignatureDelete.Enabled = True
            btnAllDeleteBoth.Enabled = True
        End If
    End Sub
    
    ' ------------------- Read -------------------
    
    Sub PopulateProfileList()
        
        lstAll.Items.Clear()
        
        GetProfiles
    End Sub
    
    Function GetProfiles() As NetworkProfile()
        
    End Function
    
    ' ------------------- Write -------------------
    
    Sub LstAll_AfterLabelEdit(sender As Object, e As LabelEditEventArgs)
        
    End Sub
    
    Sub btnAllName_Click() Handles btnAllName.Click
        
    End Sub
    
    Sub btnAllCategory_Click() Handles btnAllCategory.Click
        
    End Sub
    
    Sub btnAllDescription_Click() Handles btnAllDescription.Click
        
    End Sub
    
    Sub btnAllManaged_Click() Handles btnAllManaged.Click
        
    End Sub
    
    Sub btnAllNameType_Click() Handles btnAllNameType.Click
        
    End Sub
    
    Sub btnAllCategoryType_Click() Handles btnAllCategoryType.Click
        
    End Sub
    
    Sub btnAllDeleteNetwork_Click() Handles btnAllDeleteNetwork.Click
        
    End Sub
    
    Sub btnAllSignatureGateway_Click() Handles btnAllSignatureGateway.Click
        
    End Sub
    
    Sub btnAllSignatureDNS_Click() Handles btnAllSignatureDNS.Click
        
    End Sub
    
    Sub btnAllSignatureDescription_Click() Handles btnAllSignatureDescription.Click
        
    End Sub
    
    Sub btnAllSignatureFirstNetwork_Click() Handles btnAllSignatureFirstNetwork.Click
        
    End Sub
    
    Sub btnAllSignatureSource_Click() Handles btnAllSignatureSource.Click
        
    End Sub
    
    Sub btnAllSignatureDelete_Click() Handles btnAllSignatureDelete.Click
        
    End Sub
    
    Sub btnAllDeleteBoth_Click() Handles btnAllDeleteBoth.Click
        
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
    
    Function PowerShellPath() As String
        If Environment.Is64BitOperatingSystem And Not Environment.Is64BitProcess Then
            Return "C:\Windows\Sysnative\WindowsPowerShell\v1.0\powershell.exe"
        Else
            Return "C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe"
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
    
    Function ProcessLineContents(line As String) As String
        If line.Contains(":") Then
            Dim seperatorIndex = line.IndexOf(":") + 1
            
            line = line.Substring(seperatorIndex)
            line = line.Trim()
            Return line
        Else
            Return "Error: Line doesn't contain seperator!"
        End If
    End Function
    
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
End Class
