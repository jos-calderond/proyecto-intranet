Imports slbaperbDll

Namespace Tipos

  Public Class oIMROL

#Region "Atributos públicos"
    Public CODOPCB As String = ""
    Public CODUSU As String = ""
    Public CODROL As String = ""
    Public CODSIS As String = ""
    Public MANT As String = ""
    Public MENSAJE As String = ""
    Public GLOCODUSU As String = ""
    Public PERMISO4 As String = ""
    Public CODOPC4 As String = ""
    Public PERMISO3 As String = ""
    Public CODOPC3 As String = ""
    Public PERMISO2 As String = ""
    Public CODOPC2 As String = ""
    Public PERMISO1 As String = ""
    Public CODOPC1 As String = ""
#End Region

#Region "Constructores"

    Sub New()
    End Sub

    Friend Sub New(ByVal miIMROLCFType As IMROL.CFType)
      PERMISO4 = miIMROLCFType.PERMISO4
      CODOPC4 = miIMROLCFType.CODOPC4
      PERMISO3 = miIMROLCFType.PERMISO3
      CODOPC3 = miIMROLCFType.CODOPC3
      PERMISO2 = miIMROLCFType.PERMISO2
      CODOPC2 = miIMROLCFType.CODOPC2
      PERMISO1 = miIMROLCFType.PERMISO1
      CODOPC1 = miIMROLCFType.CODOPC1
    End Sub
#End Region

#Region "Métodos privados"

    Private Function __callIspec(ByVal Ispec As IMROL) As List(Of IMROL.CFType)
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

    Public Function consultaMasiva(ByVal CODOPCB As String, ByVal CODUSU As String, ByVal CODROL As String, ByVal CODSIS As String, ByVal MANT As String) As List(Of oIMROL)

      Dim miIMROL As New IMROL()
      Dim lista As New List(Of oIMROL)

      miIMROL.CODOPCB = CODOPCB
      miIMROL.CODUSU = CODUSU
      miIMROL.CODROL = CODROL
      miIMROL.CODSIS = CODSIS
      miIMROL.MANT = MANT

      For Each reg As IMROL.CFType In Me.__callIspec(miIMROL)
        lista.Add(New oIMROL(reg))
      Next

      Return lista

    End Function

    Public Function cambioPermiso(ByVal CODOPCB As String, ByVal CODUSU As String, ByVal CODROL As String, ByVal CODSIS As String, ByVal PERMISO As String) As List(Of oIMROL)

      Dim miIMROL As New IMROL()
      Dim lista As New List(Of oIMROL)

      miIMROL.CODOPCB = CODOPCB
      miIMROL.CODUSU = CODUSU
      miIMROL.CODROL = CODROL
      miIMROL.CODSIS = CODSIS
      miIMROL.MANT = "CHG"
      miIMROL.PERMISO = PERMISO

      For Each reg As IMROL.CFType In Me.__callIspec(miIMROL)
        lista.Add(New oIMROL(reg))
      Next

      Return lista

    End Function


#End Region

  End Class

End Namespace

