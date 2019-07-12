Imports slbaperbDll

Namespace Tipos

  Public Class oCTURO

#Region "Atributos públicos"

    Public CODOPC_C As String = ""
    Public CODROL_C As String = ""
    Public CODUSU_C As String = ""
    Public CODSIS_C As String = ""
    Public MENSAJE As String = ""
    Public PERMISO As String = ""
    Public CODOPC As String = ""
    Public CODROL As String = ""
    Public CODUSU As String = ""
    Public CODSIS As String = ""

#End Region

#Region "Constructores"

    Sub New()
    End Sub

    Friend Sub New(ByVal miCTUROCFType As CTURO.CFType)
      PERMISO = miCTUROCFType.PERMISO
      CODOPC = miCTUROCFType.CODOPC
      CODROL = miCTUROCFType.CODROL
      CODUSU = miCTUROCFType.CODUSU
      CODSIS = miCTUROCFType.CODSIS

    End Sub

#End Region

#Region "Métodos privados"

    Private Function __callIspec(ByVal Ispec As CTURO) As List(Of CTURO.CFType)
      Try
        Return Ispec.CallIspec().CF
      Catch ex As MCPResponseException
        Throw New Exception(ex.getMessage)
      Catch ex As WSRequestException
        Throw New Exception(ex.getMessage())
      Catch ex As InvalidTokenException
        Throw New Exception(ex.getMessage())
      End Try

    End Function

#End Region

#Region "Métodos públicos"

    Public Function consultaMasiva(ByVal CODROL_C As String, ByVal CODUSU_C As String, ByVal CODSIS_C As String) As List(Of oCTURO)
      Dim miCTURO As New CTURO()
      Dim lista As New List(Of oCTURO)
      miCTURO.CODOPC_C = CODOPC_C
      miCTURO.CODROL_C = CODROL_C
      miCTURO.CODUSU_C = CODUSU_C
      miCTURO.CODSIS_C = CODSIS_C

      For Each reg As CTURO.CFType In Me.__callIspec(miCTURO)
        lista.Add(New oCTURO(reg))
      Next

      Return lista

    End Function

#End Region

  End Class

End Namespace

