Imports slbaperbDll

Namespace Tipos
  ''' <summary>
  ''' 30/05/2019 rtorreblanca: Creación.
  ''' </summary>
  ''' <remarks></remarks>
  Public Class oICLIC

#Region "Atributos públicos"

    Public FECINI As String = ""
    Public RUTFUN As String = ""
    Public VAMENU As String = ""
    Public MENJ35 As String = ""
    Public VIGENCIA As String = ""
    Public FECTER_LIC As String = ""
    Public NRODIA_LIC As String = ""
    Public FECACC_LIC As String = ""
    Public FECRESL As String = ""
    Public RESSAL As String = ""
    Public NUMLIC As String = ""
    Public GLODIRECC As String = ""
    Public FECINI_LIC As String = ""

#End Region

#Region "Constructores"

    Sub New()
    End Sub

    Friend Sub New(ByVal miICLICCFType As ICLIC.CFType)

      FECTER_LIC = miICLICCFType.FECTER_LIC
      NRODIA_LIC = miICLICCFType.NRODIA_LIC
      FECACC_LIC = miICLICCFType.FECACC_LIC
      FECRESL = miICLICCFType.FECRESL
      RESSAL = miICLICCFType.RESSAL
      NUMLIC = miICLICCFType.NUMLIC
      GLODIRECC = miICLICCFType.GLODIRECC
      FECINI_LIC = miICLICCFType.FECINI_LIC

    End Sub

#End Region

#Region "Métodos privados"

    Private Function __callIspec(ByVal Ispec As ICLIC) As List(Of ICLIC.CFType)

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

    Public Function consultaMasiva(ByVal RUTFUN As String, ByVal FECINI As String) As List(Of oICLIC)

      Dim miICLIC As New ICLIC()
      Dim lista As New List(Of oICLIC)

      miICLIC.FECINI = FECINI
      miICLIC.RUTFUN = RUTFUN
      miICLIC.VAMENU = VAMENU

      For Each reg As ICLIC.CFType In Me.__callIspec(miICLIC)
        lista.Add(New oICLIC(reg))
      Next

      Return lista

    End Function

#End Region

  End Class

End Namespace

