Public Partial Class NetEdit
    Public Sub New()
        Me.InitializeComponent()
        
        timerDelayedScan.Start()
    End Sub
    
    Interface NetworkProfile
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
    End Interface
    
    Interface ActiveNetworkProfile
        Property InterfaceIndex() As Integer
        Property Name() As String
        Property InterfaceAlias() As String
        Property IPv4Connectivity() As String
        Property IPv6Connectivity() As String
        Property NetworkCategory() As String
    End Interface
    
    Sub timerDelayedScan_Tick() Handles timerDelayedScan.Tick
        timerDelayedScan.Stop()
        
        lstAllSelectionUpdated()
        lstConnectedSelectionUpdated()
        
        lstAll.Items.Clear()
        
        PopulateProfileList()
        
        lstConnected.Items.Clear()
        
        PopulateNetworkList()
        
    End Sub
    
    ' =================== UI Changing ===================
    
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
    
    Sub lstConnectedSelectionUpdated() Handles lstConnected.SelectedIndexChanged
        If lstConnected.SelectedIndices.Count = 0 Then
            btnConnChangeType.Enabled = False
        Else
            btnConnChangeType.Enabled = True
        End If
    End Sub
    
    ' =================== Data Changing ===================
    
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
    
    Sub btnConnChangeType_Click() Handles btnConnChangeType.Click
        
    End Sub
    
    Sub PopulateProfileList()
        GetProfiles
    End Sub
    
    Sub PopulateNetworkList()
        GetNetworks
    End Sub
    
    ' =================== Functions ===================
    
    Function GetProfiles()
        
    End Function
    
    Function GetNetworks()
        
    End Function
End Class
