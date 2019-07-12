Imports Microsoft.VisualBasic

Public Class Configuracion
    Private _WS_Respuesta As Integer
    Public Property WS_Respuesta() As Integer
        Get
            Return _WS_Respuesta
        End Get
        Set(ByVal value As Integer)
            _WS_Respuesta = value
        End Set
    End Property
    Private _WS_Codigo As String
    Public Property WS_Codigo() As String
        Get
            Return _WS_Codigo
        End Get
        Set(ByVal value As String)
            _WS_Codigo = value
        End Set
    End Property
    Private _WS_Institucion As String
    Public Property WS_Institucion() As String
        Get
            Return _WS_Institucion
        End Get
        Set(ByVal value As String)
            _WS_Institucion = value
        End Set
    End Property
    Private _WS_Sistema As String
    Public Property WS_Sistema() As String
        Get
            Return _WS_Sistema
        End Get
        Set(ByVal value As String)
            _WS_Sistema = value
        End Set
    End Property
    Private _WS_TipDoc As String
    Public Property WS_TipDoc() As String
        Get
            Return _WS_TipDoc
        End Get
        Set(ByVal value As String)
            _WS_TipDoc = value
        End Set
    End Property
    Private _WS_Error As String
    Public Property WS_Error() As String
        Get
            Return _WS_Error
        End Get
        Set(ByVal value As String)
            _WS_Error = value
        End Set
    End Property
End Class
