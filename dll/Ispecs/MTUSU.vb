Imports System.Web.Script.Serialization
''' <summary>
''' 05/06/2019 rtorreblanca: Creación.
''' </summary>
''' <remarks></remarks>
Public Class MTUSU

  Public PASSCONFIR As String = ""
  Public PASSNEW As String = ""
  Public PASSWORD As String = ""
  Public NOMBRES As String = ""
  Public APEMAT As String = ""
  Public APEPAT As String = ""
  Public CODUSU As String = ""
  Public OPCION As String = ""
  Public MANT As String = ""
  Public PASW_ACTIV As String = ""
  Public VIGENTE As String = ""
  Public FECNAC As String = ""

  Private __js As JavaScriptSerializer
  Private __dic As Dictionary(Of String, Object)

  Public WebService As New WS.WebService

  Sub New()
  End Sub

  Public Function CallIspec() As MTUSU

    Dim ISPEC As String = WebService.MTUSU(APEMAT, APEPAT, CODUSU, MANT, NOMBRES, OPCION, PASSCONFIR, PASSNEW, PASSWORD)
    Dim MTUSU As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

    __dic = TryCast(MTUSU, Dictionary(Of String, Object))

    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "MTUSU")
      End If
    End If

    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.PASSCONFIR = MTUSU("PASSCONFIR")
    Me.PASSNEW = MTUSU("PASSNEW")
    Me.PASSWORD = MTUSU("PASSWORD")
    Me.NOMBRES = MTUSU("NOMBRES")
    Me.APEMAT = MTUSU("APEMAT")
    Me.APEPAT = MTUSU("APEPAT")
    Me.CODUSU = MTUSU("CODUSU")
    Me.OPCION = MTUSU("OPCION")
    Me.MANT = MTUSU("MANT")
    Me.PASW_ACTIV = MTUSU("PASW_ACTIV")
    Me.VIGENTE = MTUSU("VIGENTE")
    Me.FECNAC = MTUSU("FECNAC")

    Return Me

  End Function

End Class

