Imports Microsoft.VisualBasic
Imports System.Configuration

Public Class Config

    Public Shared ReadOnly Property logCarpeta() As String
        Get
            Return ConfigurationManager.AppSettings("Log.Carpeta")
        End Get
    End Property

    Public Shared ReadOnly Property logExtension() As String
        Get
            Return ConfigurationManager.AppSettings("Log.Extension")
        End Get
    End Property

    Public Shared ReadOnly Property logNivel() As Integer
        Get
            Return Integer.Parse(ConfigurationManager.AppSettings("Log.Nivel"))
        End Get
    End Property

    Public Shared ReadOnly Property logPrefijo() As String
        Get
            Return ConfigurationManager.AppSettings("Log.Prefijo")
        End Get
    End Property

End Class
