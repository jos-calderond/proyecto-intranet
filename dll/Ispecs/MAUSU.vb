Imports System.Web.Script.Serialization

Public Class MAUSU
  Public APEMAT As String = ""
  Public APEPAT As String = ""
  Public CODUSU As String = ""
  Public CORREO As String = ""
  Public ESTADO As String = ""
  Public FECPASS As String = ""
  Public INICIALES As String = ""
  Public MANT As String = ""
  Public NOMBRES As String = ""
  Public PASS As String = ""
  Public RUT As String = ""
  Public CODSIS As String = ""
  Public UNIDAD As String = ""

  Private __js As JavaScriptSerializer
  Private __dic As Dictionary(Of String, Object)

  Public WebService As New WS.WebService

  Sub New()
  End Sub

  Public Function CallIspec() As MAUSU
    Dim ISPEC As String = WebService.MAUSU(APEMAT, APEPAT, CODUSU, CORREO, ESTADO, FECPASS, INICIALES, MANT, NOMBRES, PASS, RUT, CODSIS, UNIDAD)
    Dim mausu As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)
    __dic = TryCast(mausu, Dictionary(Of String, Object))
    If (Not __dic Is Nothing) Then
      If (__dic.ContainsKey("ERROR")) Then
        Throw New WSException(__dic("ERROR")("Message"), "MAUSU")

      End If
    End If

    If __dic.Count = 0 Then
      Throw New Exception("Error de conexion con el Webservice")
    End If

    Me.APEMAT = mausu("APEMAT")
    Me.APEPAT = mausu("APEPAT")
    Me.CODUSU = mausu("CODUSU")
    Me.CORREO = mausu("CORREO")
    Me.ESTADO = mausu("ESTADO")
    Me.FECPASS = mausu("FECPASS")
    Me.INICIALES = mausu("INICIALES")
    Me.MANT = mausu("MANT")
    Me.NOMBRES = mausu("NOMBRES")
    Me.PASS = mausu("PASS")
    Me.RUT = mausu("RUT")
    Me.UNIDAD = mausu("UNIDAD")

    Return Me
  End Function

End Class