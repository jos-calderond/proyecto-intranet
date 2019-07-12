Imports slbaperbDll

Namespace Tipos
  Public Class oCTUSM

#Region "Atributos públicos"
    Public PRIORIDA_B As String = ""
    Public CODUSU As String = ""
    Public GLOUSU As String = ""
    Public PASSMAIL As String = ""
    Public EMAIL As String = ""
    Public PRIORIDAD As String = ""
#End Region

#Region "Constructores"

    Sub New()
    End Sub

    Friend Sub New(ByVal miCTUSMCFType As CTUSM.CFType)
      PASSMAIL = miCTUSMCFType.PASSMAIL
      EMAIL = miCTUSMCFType.EMAIL
      PRIORIDAD = miCTUSMCFType.PRIORIDAD
    End Sub

#End Region

#Region "Métodos privados"

    Private Function __callIspec(ByVal Ispec As CTUSM) As List(Of CTUSM.CFType)
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

    Public Function consultaMasiva(ByVal PRIORIDA_B, ByVal CODUSU) As List(Of oCTUSM)
      Dim miCTUSM As New CTUSM()
      Dim lista As New List(Of oCTUSM)
      miCTUSM.PRIORIDA_B = PRIORIDA_B
      miCTUSM.CODUSU = CODUSU
      For Each reg As CTUSM.CFType In Me.__callIspec(miCTUSM)
        lista.Add(New oCTUSM(reg))
      Next

      Return lista

    End Function

#End Region

  End Class

End Namespace

