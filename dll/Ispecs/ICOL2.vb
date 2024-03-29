Imports System.Web.Script.Serialization

Public Class ICOL2

    Public ORQ As String = "T"
    Public TIPO As String = ""
    Public NUMBAS As String = ""
    Public TIPBAS As String = ""
    Public TIPFUN As String = ""
    Public RUTFUN As String = ""
    Public PROCESO As String = ""
    Public MES As String = ""
    Public ANO As String = ""
    Public INST As String = ""
    Public VAMENU As String = ""
    Public GLOEST As String = ""
    Public HORAS As String = ""
    Public CONTRATO As String = ""
    Public NOMBRET As String = ""
    Public APEMATT As String = ""
    Public APEPATT As String = ""
    Public MENJ35 As String = ""
    Public NROCTA As String = ""
    Public CUOTA As String = ""
    Public IND4 As String = ""
    Public MOV_TIPO As String = ""
    Public CAN2 As String = ""
    Public VALORC As String = ""
    Public SIGNO As String = ""
    Public GLOCOD As String = ""
    Public NUMCOD As String = ""
    Public LETCOD As String = ""

    Public CF As List(Of CFType)

    Private __js As JavaScriptSerializer

    Private __dic As Dictionary(Of String, Object)

    Public WebService As New WS.WebService

    Public Class CFType

        Public NROCTA As String = ""
        Public CUOTA As String = ""
        Public IND4 As String = ""
        Public MOV_TIPO As String = ""
        Public CAN2 As String = ""
        Public VALORC As String = ""
        Public SIGNO As String = ""
        Public GLOCOD As String = ""
        Public NUMCOD As String = ""
        Public LETCOD As String = ""

    End Class

    Sub New()
    End Sub

    Public Function CallIspec() As ICOL2

        Dim ISPEC As String = WebService.ICOL2(ORQ, TIPO, NUMBAS, TIPBAS, TIPFUN, RUTFUN, PROCESO, MES, ANO, INST, VAMENU)
        Dim ICOL2 As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

        __dic = TryCast(ICOL2, Dictionary(Of String, Object))

        If (Not __dic Is Nothing) Then
            If (__dic.ContainsKey("ERROR")) Then
                Throw New WSException(__dic("ERROR")("Message"), "ICOL2")
            End If
        End If

        If __dic.Count = 0 Then
            Throw New Exception("Error de conexion con el Webservice")
        End If

        Me.TIPO = ICOL2("__PARAMETERS__")(0)("TIPO")
        Me.NUMBAS = ICOL2("__PARAMETERS__")(0)("NUMBAS")
        Me.TIPBAS = ICOL2("__PARAMETERS__")(0)("TIPBAS")
        Me.TIPFUN = ICOL2("__PARAMETERS__")(0)("TIPFUN")
        Me.RUTFUN = ICOL2("__PARAMETERS__")(0)("RUTFUN")
        Me.PROCESO = ICOL2("__PARAMETERS__")(0)("PROCESO")
        Me.MES = ICOL2("__PARAMETERS__")(0)("MES")
        Me.ANO = ICOL2("__PARAMETERS__")(0)("ANO")
        Me.INST = ICOL2("__PARAMETERS__")(0)("INST")
        Me.VAMENU = ICOL2("__PARAMETERS__")(0)("VAMENU")

        Dim cftype As ICOL2.CFType

        Me.CF = New List(Of CFType)

        For Each reg In ICOL2("__COPYFROM__")
            cftype = New ICOL2.CFType()
            cftype.NROCTA = reg("NROCTA")
            cftype.CUOTA = reg("CUOTA")
            cftype.IND4 = reg("IND4")
            cftype.MOV_TIPO = reg("MOV_TIPO")
            cftype.CAN2 = reg("CAN2")
            cftype.VALORC = reg("VALORC")
            cftype.SIGNO = reg("SIGNO")
            cftype.GLOCOD = reg("GLOCOD")
            cftype.NUMCOD = reg("NUMCOD")
            cftype.LETCOD = reg("LETCOD")
            Me.CF.Add(cftype)
        Next

        Return Me

    End Function

End Class

