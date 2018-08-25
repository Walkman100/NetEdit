Option Explicit On
Option Strict On
Option Compare Binary
Option Infer On

Public Enum NetworkCategory
    [Private]
    [Public]
End Enum

Public Partial Class NetworkTypeSelector
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
