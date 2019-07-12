Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Serialization

' Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la siguiente línea.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebService
  Inherits System.Web.Services.WebService

  Private __js As JavaScriptSerializer
  Private __dic As Dictionary(Of String, String)
  Private __cf As Dictionary(Of String, List(Of Dictionary(Of String, String)))
  Private __activex As String = ConfigurationManager.AppSettings("activex")



  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="ORQ"></param>
  ''' <param name="CODOPC_B"></param>
  ''' <param name="CODROL_B"></param>
  ''' <param name="CODSIS"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function CMOXR(ByVal ORQ As String,
                                  ByVal CODOPC_B As String,
                                  ByVal CODROL_B As String,
                                  ByVal CODSIS As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing
    Dim cfSize As Integer = 9

    Try

      Dim y As Integer = 0
      Dim sw As Boolean = True

      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      __cf = New Dictionary(Of String, List(Of Dictionary(Of String, String)))

      __cf.Add("__PARAMETERS__", New List(Of Dictionary(Of String, String)))
      __cf.Add("__COPYFROM__", New List(Of Dictionary(Of String, String)))

      While sw

        sdicISPEC_In = CreateObject("Scripting.Dictionary")
        sdicISPEC_Out = CreateObject("Scripting.Dictionary")

        sdicISPEC_In.Item("CODOPC_B") = IIf(CODOPC_B = "", 0, CODOPC_B)
        sdicISPEC_In.Item("CODROL_B") = IIf(CODROL_B = "", 0, CODROL_B)
        sdicISPEC_In.Item("CODSIS") = CODSIS

        objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "CMOXR", swError, strError)

        If swError <> 0 Then
          Throw New Exception(strError)
        End If

        Dim aux As String = ""

        For i As Integer = 0 To cfSize 'Máximo Copyfrom

          If Len(i.ToString) = 1 Then
            aux = "0" & i
          Else
            aux = i
          End If

          __dic = New Dictionary(Of String, String)

          If (Not y = 0 And i = 0) Or (sdicISPEC_Out("CODOPC__AT_" & aux) = "0") Then
            Continue For
          End If

          __dic.Add("CODOPC", sdicISPEC_Out("CODOPC__AT_" & aux))
          __dic.Add("CODPADRE", sdicISPEC_Out("CODPADRE__AT_" & aux))
          __dic.Add("DESCRIP", sdicISPEC_Out("DESCRIP__AT_" & aux))
          __dic.Add("FORMU", sdicISPEC_Out("FORMU__AT_" & aux))
          __dic.Add("ICONO", sdicISPEC_Out("ICONO__AT_" & aux))
          __dic.Add("ORDEN", sdicISPEC_Out("ORDEN__AT_" & aux))

          __cf("__COPYFROM__").Add(__dic)
        Next

        CODOPC_B = sdicISPEC_Out.Item("CODOPC_B")
        CODROL_B = sdicISPEC_Out.Item("CODROL_B")

        If sdicISPEC_Out.Item("MENJ35") = "HAY MAS DATOS" And ORQ = "T" Then
          sw = True
        Else
          sw = False
        End If

        y = y + 1
      End While

      __dic = New Dictionary(Of String, String)

      __dic.Add("CODOPC_B", CODOPC_B)
      __dic.Add("CODROL_B", CODROL_B)

      __cf("__PARAMETERS__").Add(__dic)

      __js = New JavaScriptSerializer

      Return __js.Serialize(__cf)

    Catch ex As Exception
      Return ErrorHandler.ErrorAsJson(ex)
    Finally
    End Try

  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="ORQ"></param>
  ''' <param name="CODOPC_B"></param>
  ''' <param name="CODUSU"></param>
  ''' <param name="ROL"></param>
  ''' <param name="CODSIS"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function CMOXU(ByVal ORQ As String,
                                  ByVal CODOPC_B As String,
                                  ByVal CODUSU As String,
                                  ByVal ROL As String,
                                  ByVal CODSIS As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing
    Dim cfSize As Integer = 9

    Try

      Dim y As Integer = 0
      Dim sw As Boolean = True

      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      __cf = New Dictionary(Of String, List(Of Dictionary(Of String, String)))

      __cf.Add("__PARAMETERS__", New List(Of Dictionary(Of String, String)))
      __cf.Add("__COPYFROM__", New List(Of Dictionary(Of String, String)))

      While sw

        sdicISPEC_In = CreateObject("Scripting.Dictionary")
        sdicISPEC_Out = CreateObject("Scripting.Dictionary")

        sdicISPEC_In.Item("CODOPC_B") = IIf(CODOPC_B = "", 0, CODOPC_B)
        sdicISPEC_In.Item("CODUSU") = CODUSU
        sdicISPEC_In.Item("ROL") = IIf(ROL = "", 0, ROL)
        sdicISPEC_In.Item("CODSIS") = CODSIS

        objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "CMOXU", swError, strError)

        If swError <> 0 Then
          Throw New Exception(strError)
        End If

        Dim aux As String = ""

        For i As Integer = 0 To cfSize 'Máximo Copyfrom

          If Len(i.ToString) = 1 Then
            aux = "0" & i
          Else
            aux = i
          End If

          __dic = New Dictionary(Of String, String)

          If (Not y = 0 And i = 0) Or (sdicISPEC_Out("CODOPC__AT_" & aux) = "0") Then
            Continue For
          End If

          __dic.Add("CODOPC", sdicISPEC_Out("CODOPC__AT_" & aux))
          __dic.Add("CODPADRE", sdicISPEC_Out("CODPADRE__AT_" & aux))
          __dic.Add("DESCRIP", sdicISPEC_Out("DESCRIP__AT_" & aux))
          __dic.Add("FORMU", sdicISPEC_Out("FORMU__AT_" & aux))
          __dic.Add("ICONO", sdicISPEC_Out("ICONO__AT_" & aux))
          __dic.Add("ORDEN", sdicISPEC_Out("ORDEN__AT_" & aux))

          __cf("__COPYFROM__").Add(__dic)
        Next

        CODOPC_B = sdicISPEC_Out.Item("CODOPC_B")
        CODUSU = sdicISPEC_Out.Item("CODUSU")
        ROL = sdicISPEC_Out.Item("ROL")

        If sdicISPEC_Out.Item("MENJ35") = "HAY MAS DATOS" And ORQ = "T" Then
          sw = True
        Else
          sw = False
        End If

        y = y + 1
      End While

      __dic = New Dictionary(Of String, String)

      __dic.Add("CODOPC_B", CODOPC_B)
      __dic.Add("CODUSU", CODUSU)
      __dic.Add("ROL", ROL)

      __cf("__PARAMETERS__").Add(__dic)

      __js = New JavaScriptSerializer

      Return __js.Serialize(__cf)

    Catch ex As Exception
      Return ErrorHandler.ErrorAsJson(ex)
    Finally
    End Try

  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="ACCESO1"></param>
  ''' <param name="ACCESO2"></param>
  ''' <param name="ACCESO3"></param>
  ''' <param name="ACCESO4"></param>
  ''' <param name="CODUSU"></param>
  ''' <param name="MANT"></param>
  ''' <param name="OPCION1"></param>
  ''' <param name="OPCION2"></param>
  ''' <param name="OPCION3"></param>
  ''' <param name="OPCION4"></param>
  ''' <param name="OPCIONB"></param>
  ''' <param name="SISTEMA"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function MAOPM(ByVal ACCESO1 As String,
                                  ByVal ACCESO2 As String,
                                  ByVal ACCESO3 As String,
                                  ByVal ACCESO4 As String,
                                  ByVal CODUSU As String,
                                  ByVal MANT As String,
                                  ByVal OPCION1 As String,
                                  ByVal OPCION2 As String,
                                  ByVal OPCION3 As String,
                                  ByVal OPCION4 As String,
                                  ByVal OPCIONB As String,
                                  ByVal SISTEMA As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing

    Try

      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)
      sdicISPEC_In = CreateObject("Scripting.Dictionary")
      sdicISPEC_Out = CreateObject("Scripting.Dictionary")

      sdicISPEC_In.Item("ACCESO1") = ACCESO1
      sdicISPEC_In.Item("ACCESO2") = ACCESO2
      sdicISPEC_In.Item("ACCESO3") = ACCESO3
      sdicISPEC_In.Item("ACCESO4") = ACCESO4
      sdicISPEC_In.Item("CODUSU") = CODUSU
      sdicISPEC_In.Item("MANT") = MANT
      sdicISPEC_In.Item("OPCION1") = OPCION1
      sdicISPEC_In.Item("OPCION2") = OPCION2
      sdicISPEC_In.Item("OPCION3") = OPCION3
      sdicISPEC_In.Item("OPCION4") = OPCION4
      sdicISPEC_In.Item("OPCIONB") = OPCIONB
      sdicISPEC_In.Item("SISTEMA") = SISTEMA

      objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "MAOPM", swError, strError)

      If swError <> 0 Then
        Throw New Exception(strError)
      End If

      __dic = New Dictionary(Of String, String)

      __dic.Add("ACCESO1", sdicISPEC_Out("ACCESO1"))
      __dic.Add("ACCESO2", sdicISPEC_Out("ACCESO2"))
      __dic.Add("ACCESO3", sdicISPEC_Out("ACCESO3"))
      __dic.Add("ACCESO4", sdicISPEC_Out("ACCESO4"))
      __dic.Add("CODUSU", sdicISPEC_Out("CODUSU"))
      __dic.Add("MANT", sdicISPEC_Out("MANT"))
      __dic.Add("OPCION1", sdicISPEC_Out("OPCION1"))
      __dic.Add("OPCION2", sdicISPEC_Out("OPCION2"))
      __dic.Add("OPCION3", sdicISPEC_Out("OPCION3"))
      __dic.Add("OPCION4", sdicISPEC_Out("OPCION4"))
      __dic.Add("OPCIONB", sdicISPEC_Out("OPCIONB"))
      __dic.Add("SISTEMA", sdicISPEC_Out("SISTEMA"))

      __js = New JavaScriptSerializer

      Return __js.Serialize(__dic)

    Catch ex As Exception
      Return ErrorHandler.ErrorAsJson(ex)
    Finally
    End Try

  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="APEMAT"></param>
  ''' <param name="APEPAT"></param>
  ''' <param name="CODUSU"></param>
  ''' <param name="CORREO"></param>
  ''' <param name="ESTADO"></param>
  ''' <param name="FECPASS"></param>
  ''' <param name="INICIALES"></param>
  ''' <param name="MANT"></param>
  ''' <param name="NOMBRES"></param>
  ''' <param name="PASS"></param>
  ''' <param name="RUT"></param>
  ''' <param name="CODSIS"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function MAUSU(ByVal APEMAT As String,
                                  ByVal APEPAT As String,
                                  ByVal CODUSU As String,
                                  ByVal CORREO As String,
                                  ByVal ESTADO As String,
                                  ByVal FECPASS As String,
                                  ByVal INICIALES As String,
                                  ByVal MANT As String,
                                  ByVal NOMBRES As String,
                                  ByVal PASS As String,
                                  ByVal RUT As String,
                                  ByVal CODSIS As String,
                                  ByVal UNIDAD As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing

    Try

      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)
      sdicISPEC_In = CreateObject("Scripting.Dictionary")
      sdicISPEC_Out = CreateObject("Scripting.Dictionary")

      sdicISPEC_In.Item("APEMAT") = APEMAT
      sdicISPEC_In.Item("APEPAT") = APEPAT
      sdicISPEC_In.Item("CODUSU") = CODUSU
      sdicISPEC_In.Item("CORREO") = CORREO
      sdicISPEC_In.Item("ESTADO") = ESTADO
      sdicISPEC_In.Item("FECPASS") = IIf(FECPASS = "", 0, FECPASS)
      sdicISPEC_In.Item("INICIALES") = INICIALES
      sdicISPEC_In.Item("MANT") = MANT
      sdicISPEC_In.Item("NOMBRES") = NOMBRES
      sdicISPEC_In.Item("PASS") = PASS
      sdicISPEC_In.Item("RUT") = RUT
      sdicISPEC_In.Item("CODSIS") = CODSIS
      sdicISPEC_In.Item("UNIDAD") = UNIDAD

      objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "MAUSU", swError, strError)

      If swError <> 0 Then
        Throw New Exception(strError)
      End If

      __dic = New Dictionary(Of String, String)

      __dic.Add("APEMAT", sdicISPEC_Out("APEMAT"))
      __dic.Add("APEPAT", sdicISPEC_Out("APEPAT"))
      __dic.Add("CODUSU", sdicISPEC_Out("CODUSU"))
      __dic.Add("CORREO", sdicISPEC_Out("CORREO"))
      __dic.Add("ESTADO", sdicISPEC_Out("ESTADO"))
      __dic.Add("FECPASS", sdicISPEC_Out("FECPASS"))
      __dic.Add("INICIALES", sdicISPEC_Out("INICIALES"))
      __dic.Add("MANT", sdicISPEC_Out("MANT"))
      __dic.Add("NOMBRES", sdicISPEC_Out("NOMBRES"))
      __dic.Add("PASS", sdicISPEC_Out("PASS"))
      __dic.Add("RUT", sdicISPEC_Out("RUT"))
      __dic.Add("UNIDAD", sdicISPEC_Out("UNIDAD"))

      __js = New JavaScriptSerializer

      Return __js.Serialize(__dic)

    Catch ex As Exception
      Return ErrorHandler.ErrorAsJson(ex)
    Finally
    End Try

  End Function

  ''' <summary>
  ''' 06/05/2019 rtorreblanca: Creación.
  ''' </summary>
  ''' <param name="ORQ"></param>
  ''' <param name="TIPORDEN"></param>
  ''' <param name="TIPREG_B"></param>
  ''' <param name="ALFA01_B"></param>
  ''' <param name="ALFA02_B"></param>
  ''' <param name="CODIGO_B"></param>
  ''' <param name="DESCRI_B"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function CONTA(ByVal ORQ As String,
                                 ByVal TIPORDEN As String,
                                 ByVal TIPREG_B As String,
                                 ByVal ALFA01_B As String,
                                 ByVal ALFA02_B As String,
                                 ByVal CODIGO_B As String,
                                 ByVal DESCRI_B As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing
    Dim cfSize As Integer = 19

    Try
      Dim y As Integer = 0
      Dim sw As Boolean = True

      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      __cf = New Dictionary(Of String, List(Of Dictionary(Of String, String)))
      __cf.Add("__PARAMETERS__", New List(Of Dictionary(Of String, String)))
      __cf.Add("__COPYFROM__", New List(Of Dictionary(Of String, String)))

      While sw
        sdicISPEC_In = CreateObject("Scripting.Dictionary")
        sdicISPEC_Out = CreateObject("Scripting.Dictionary")

        sdicISPEC_In.Item("ALFA01_B") = ALFA01_B
        sdicISPEC_In.Item("ALFA02_B") = ALFA02_B
        sdicISPEC_In.Item("CODIGO_B") = CODIGO_B
        sdicISPEC_In.Item("DESCRI_B") = DESCRI_B
        sdicISPEC_In.Item("TIPORDEN") = TIPORDEN
        sdicISPEC_In.Item("TIPREG_B") = TIPREG_B

        objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "CONTA", swError, strError)

        If swError <> 0 Then Throw New Exception(strError)

        Dim aux As String = ""

        For i As Integer = 0 To cfSize
          If Len(i.ToString) = 1 Then
            aux = "0" & i
          Else
            aux = i
          End If

          __dic = New Dictionary(Of String, String)

          If (Not y = 0 And i = 0) Or (sdicISPEC_Out("CODIGO__AT_" & aux) = "") Then
            Continue For
          End If

          __dic.Add("ALFA01", sdicISPEC_Out("ALFA01__AT_" & aux))
          __dic.Add("ALFA02", sdicISPEC_Out("ALFA02__AT_" & aux))
          __dic.Add("CODIGO", sdicISPEC_Out("CODIGO__AT_" & aux))
          __dic.Add("DESCRI", sdicISPEC_Out("DESCRI__AT_" & aux))

          __cf("__COPYFROM__").Add(__dic)
        Next

        ALFA01_B = sdicISPEC_Out.Item("ALFA01_B")
        ALFA02_B = sdicISPEC_Out.Item("ALFA02_B")
        CODIGO_B = sdicISPEC_Out.Item("CODIGO_B")
        DESCRI_B = sdicISPEC_Out.Item("DESCRI_B")
        TIPORDEN = sdicISPEC_Out.Item("TIPORDEN")
        TIPREG_B = sdicISPEC_Out.Item("TIPREG_B")

        If sdicISPEC_Out.Item("MENSAJE") = "EXISTE MAS INFORMACION" And ORQ = "T" Then
          sw = True
        Else
          sw = False
        End If
        y = y + 1

      End While

      __dic = New Dictionary(Of String, String)

      __dic.Add("ALFA01_B", ALFA01_B)
      __dic.Add("ALFA02_B", ALFA02_B)
      __dic.Add("CODIGO_B", CODIGO_B)
      __dic.Add("DESCRI_B", DESCRI_B)
      __dic.Add("TIPORDEN", TIPORDEN)

      __cf("__PARAMETERS__").Add(__dic)

      __js = New JavaScriptSerializer

      Return __js.Serialize(__cf)

    Catch ex As Exception
      Return ErrorHandler.ErrorAsJson(ex)
    Finally
    End Try
  End Function

  ''' <summary>
  ''' 17/05/2019 jcalderon: Creación
  ''' </summary>
  ''' <param name="APEMAT"></param>
  ''' <param name="APEPAT"></param>
  ''' <param name="CODUSU"></param>
  ''' <param name="MANT"></param>
  ''' <param name="NOMBRES"></param>
  ''' <param name="OPCION"></param>
  ''' <param name="PASSCONFIR"></param>
  ''' <param name="PASSNEW"></param>
  ''' <param name="PASSWORD"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function MTUSU(ByVal APEMAT As String,
                        ByVal APEPAT As String,
                        ByVal CODUSU As String,
                        ByVal MANT As String,
                        ByVal NOMBRES As String,
                        ByVal OPCION As String,
                        ByVal PASSCONFIR As String,
                        ByVal PASSNEW As String,
                        ByVal PASSWORD As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing

    Try

      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)
      sdicISPEC_In = CreateObject("Scripting.Dictionary")
      sdicISPEC_Out = CreateObject("Scripting.Dictionary")

      sdicISPEC_In.Item("APEMAT") = APEMAT
      sdicISPEC_In.Item("APEPAT") = APEPAT
      sdicISPEC_In.Item("CODUSU") = CODUSU
      sdicISPEC_In.Item("MANT") = MANT
      sdicISPEC_In.Item("NOMBRES") = NOMBRES
      sdicISPEC_In.Item("OPCION") = OPCION
      sdicISPEC_In.Item("PASSCONFIR") = PASSCONFIR
      sdicISPEC_In.Item("PASSNEW") = PASSNEW
      sdicISPEC_In.Item("PASSWORD") = PASSWORD

      objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "MTUSU", swError, strError)

      If swError <> 0 Then
        Throw New Exception(strError)
      End If

      __dic = New Dictionary(Of String, String)

      __dic.Add("APEMAT", sdicISPEC_Out("APEMAT"))
      __dic.Add("APEPAT", sdicISPEC_Out("APEPAT"))
      __dic.Add("CODUSU", sdicISPEC_Out("CODUSU"))
      __dic.Add("FECNAC", sdicISPEC_Out("FECNAC"))
      __dic.Add("MANT", sdicISPEC_Out("MANT"))
      __dic.Add("NOMBRES", sdicISPEC_Out("NOMBRES"))
      __dic.Add("OPCION", sdicISPEC_Out("OPCION"))
      __dic.Add("PASSCONFIR", sdicISPEC_Out("PASSCONFIR"))
      __dic.Add("PASSNEW", sdicISPEC_Out("PASSNEW"))
      __dic.Add("PASSWORD", sdicISPEC_Out("PASSWORD"))
      __dic.Add("PASW_ACTIV", sdicISPEC_Out("PASW_ACTIV"))
      __dic.Add("VIGENTE", sdicISPEC_Out("VIGENTE"))

      __js = New JavaScriptSerializer

      Return __js.Serialize(__dic)

    Catch ex As Exception
      Return ErrorHandler.ErrorAsJson(ex)
    Finally
    End Try

  End Function

  ''' <summary>
  ''' 17/05/2019 jcalderon: Creación
  ''' </summary>
  ''' <param name="ORQ"></param>
  ''' <param name="CODOPC_C"></param>
  ''' <param name="CODROL_C"></param>
  ''' <param name="CODSIS_C"></param>
  ''' <param name="CODUSU_C"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function CTURO(ByVal ORQ As String,
                        ByVal CODOPC_C As String,
                        ByVal CODROL_C As String,
                        ByVal CODSIS_C As String,
                        ByVal CODUSU_C As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing
    Dim cfSize As Integer = 20

    Try

      Dim y As Integer = 0
      Dim sw As Boolean = True

      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      __cf = New Dictionary(Of String, List(Of Dictionary(Of String, String)))

      __cf.Add("__PARAMETERS__", New List(Of Dictionary(Of String, String)))
      __cf.Add("__COPYFROM__", New List(Of Dictionary(Of String, String)))

      While sw

        sdicISPEC_In = CreateObject("Scripting.Dictionary")
        sdicISPEC_Out = CreateObject("Scripting.Dictionary")

        sdicISPEC_In.Item("CODOPC_C") = IIf(CODOPC_C = "", 0, CODOPC_C)
        sdicISPEC_In.Item("CODROL_C") = CODROL_C
        sdicISPEC_In.Item("CODSIS_C") = CODSIS_C
        sdicISPEC_In.Item("CODUSU_C") = CODUSU_C

        objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "CTURO", swError, strError)

        If swError <> 0 Then
          Throw New Exception(strError)
        End If

        Dim aux As String = ""

        For i As Integer = 0 To cfSize 'Máximo Copyfrom

          If Len(i.ToString) = 1 Then
            aux = "0" & i
          Else
            aux = i
          End If

          __dic = New Dictionary(Of String, String)
          'CAMPO ES EL ID DEL ISPACE
          If (Not y = 0 And i = 0) Or (sdicISPEC_Out("CODOPC__AT_" & aux) = "0") Then
            Continue For
          End If

          __dic.Add("CODOPC", sdicISPEC_Out("CODOPC__AT_" & aux))
          __dic.Add("CODROL", sdicISPEC_Out("CODROL__AT_" & aux))
          __dic.Add("CODSIS", sdicISPEC_Out("CODSIS__AT_" & aux))
          __dic.Add("CODUSU", sdicISPEC_Out("CODUSU__AT_" & aux))
          __dic.Add("PERMISO", sdicISPEC_Out("PERMISO__AT_" & aux))


          __cf("__COPYFROM__").Add(__dic)
        Next

        CODOPC_C = sdicISPEC_Out.Item("CODOPC_C")
        CODROL_C = sdicISPEC_Out.Item("CODROL_C")
        CODSIS_C = sdicISPEC_Out.Item("CODSIS_C")
        CODUSU_C = sdicISPEC_Out.Item("CODUSU_C")

        If sdicISPEC_Out.Item("MENSAJE") = "Hay Datos" And ORQ = "T" Then
          sw = True
        Else
          sw = False
        End If

        y = y + 1
      End While

      __dic = New Dictionary(Of String, String)

      __dic.Add("CODOPC_C", CODOPC_C)
      __dic.Add("CODROL_C", CODROL_C)
      __dic.Add("CODSIS_C", CODSIS_C)
      __dic.Add("CODUSU_C", CODUSU_C)

      __cf("__PARAMETERS__").Add(__dic)

      __js = New JavaScriptSerializer

      Return __js.Serialize(__cf)

    Catch ex As Exception
      Return ErrorHandler.ErrorAsJson(ex)
    Finally
    End Try

  End Function

  ''' <summary>
  ''' 29/05/2019 jcalderon: Creación.
  ''' </summary>
  ''' <param name="USUARIO"></param>
  ''' <param name="TELEFO_FUN"></param>
  ''' <param name="COMUNA_FUN"></param>
  ''' <param name="ACLARA_FUN"></param>
  ''' <param name="NCALLE_FUN"></param>
  ''' <param name="CALLE_FUN"></param>
  ''' <param name="MAIL_PER"></param>
  ''' <param name="NOMBRE_CON"></param>
  ''' <param name="TELEFO_CON"></param>
  ''' <param name="ACTIVO"></param>
  ''' <param name="MEDPAG"></param>
  ''' <param name="CTACTE"></param>
  ''' <param name="CODBANCO"></param>
  ''' <param name="RUTFUN"></param>
  ''' <param name="VAMENU"></param>
  ''' <param name="MANT"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function IANTP(ByVal USUARIO As String,
                         ByVal TELEFO_FUN As String,
                         ByVal COMUNA_FUN As String,
                         ByVal ACLARA_FUN As String,
                         ByVal NCALLE_FUN As String,
                         ByVal CALLE_FUN As String,
                         ByVal MAIL_PER As String,
                         ByVal NOMBRE_CON As String,
                         ByVal TELEFO_CON As String,
                         ByVal ACTIVO As String,
                         ByVal MEDPAG As String,
                         ByVal CTACTE As String,
                         ByVal CODBANCO As String,
                         ByVal RUTFUN As String,
                         ByVal VAMENU As String,
                         ByVal MANT As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing

    Try
      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      sdicISPEC_In = CreateObject("Scripting.Dictionary")
      sdicISPEC_Out = CreateObject("Scripting.Dictionary")

      sdicISPEC_In.Item("USUARIO") = USUARIO
      sdicISPEC_In.Item("TELEFO_FUN") = TELEFO_FUN
      sdicISPEC_In.Item("COMUNA_FUN") = COMUNA_FUN
      sdicISPEC_In.Item("ACLARA_FUN") = ACLARA_FUN
      sdicISPEC_In.Item("NCALLE_FUN") = NCALLE_FUN
      sdicISPEC_In.Item("CALLE_FUN") = CALLE_FUN
      sdicISPEC_In.Item("MAIL_PER") = MAIL_PER
      sdicISPEC_In.Item("NOMBRE_CON") = NOMBRE_CON
      sdicISPEC_In.Item("TELEFO_CON") = TELEFO_CON
      sdicISPEC_In.Item("ACTIVO") = ACTIVO
      sdicISPEC_In.Item("MEDPAG") = MEDPAG
      sdicISPEC_In.Item("CTACTE") = CTACTE
      sdicISPEC_In.Item("CODBANCO") = CODBANCO
      sdicISPEC_In.Item("RUTFUN") = RUTFUN
      sdicISPEC_In.Item("VAMENU") = VAMENU
      sdicISPEC_In.Item("MANT") = MANT
      objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "IANTP", swError, strError)
      If swError <> 0 Then
        Throw New Exception(strError)
      End If
      __dic = New Dictionary(Of String, String)
      __dic.Add("USUARIO", sdicISPEC_Out("USUARIO"))
      __dic.Add("TELEFO_FUN", sdicISPEC_Out("TELEFO_FUN"))
      __dic.Add("COMUNA_FUN", sdicISPEC_Out("COMUNA_FUN"))
      __dic.Add("ACLARA_FUN", sdicISPEC_Out("ACLARA_FUN"))
      __dic.Add("NCALLE_FUN", sdicISPEC_Out("NCALLE_FUN"))
      __dic.Add("CALLE_FUN", sdicISPEC_Out("CALLE_FUN"))
      __dic.Add("MAIL_PER", sdicISPEC_Out("MAIL_PER"))
      __dic.Add("NOMBRE_CON", sdicISPEC_Out("NOMBRE_CON"))
      __dic.Add("TELEFO_CON", sdicISPEC_Out("TELEFO_CON"))
      __dic.Add("ACTIVO", sdicISPEC_Out("ACTIVO"))
      __dic.Add("MEDPAG", sdicISPEC_Out("MEDPAG"))
      __dic.Add("CTACTE", sdicISPEC_Out("CTACTE"))
      __dic.Add("CODBANCO", sdicISPEC_Out("CODBANCO"))
      __dic.Add("RUTFUN", sdicISPEC_Out("RUTFUN"))
      __dic.Add("VAMENU", sdicISPEC_Out("VAMENU"))
      __dic.Add("MANT", sdicISPEC_Out("MANT"))
      __dic.Add("GESCOLARI", sdicISPEC_Out("GESCOLARI"))
      __dic.Add("ESCOLARI", sdicISPEC_Out("ESCOLARI"))
      __dic.Add("OBSERVA", sdicISPEC_Out("OBSERVA"))
      __dic.Add("FINGGA_FUN", sdicISPEC_Out("FINGGA_FUN"))
      __dic.Add("FINGCA_FUN", sdicISPEC_Out("FINGCA_FUN"))
      __dic.Add("FINGSE_FUN", sdicISPEC_Out("FINGSE_FUN"))
      __dic.Add("FADMPU_FUN", sdicISPEC_Out("FADMPU_FUN"))
      __dic.Add("FSERES_FUN", sdicISPEC_Out("FSERES_FUN"))
      __dic.Add("FEC1AFP", sdicISPEC_Out("FEC1AFP"))
      __dic.Add("TIPPOLI", sdicISPEC_Out("TIPPOLI"))
      __dic.Add("NROPOL2", sdicISPEC_Out("NROPOL2"))
      __dic.Add("NROPOL", sdicISPEC_Out("NROPOL"))
      __dic.Add("NROBIE_FUN", sdicISPEC_Out("NROBIE_FUN"))
      __dic.Add("FECBIE_FUN", sdicISPEC_Out("FECBIE_FUN"))
      __dic.Add("GHORARIO", sdicISPEC_Out("GHORARIO"))
      __dic.Add("GLOPROFE", sdicISPEC_Out("GLOPROFE"))
      __dic.Add("CODPROFE", sdicISPEC_Out("CODPROFE"))
      __dic.Add("HORARIO", sdicISPEC_Out("HORARIO"))
      __dic.Add("GCODISA", sdicISPEC_Out("GCODISA"))
      __dic.Add("CODISA", sdicISPEC_Out("CODISA"))
      __dic.Add("MARCA_TAR", sdicISPEC_Out("MARCA_TAR"))
      __dic.Add("GCODAFP", sdicISPEC_Out("GCODAFP"))
      __dic.Add("CODAFP", sdicISPEC_Out("CODAFP"))
      __dic.Add("GLOESTCIV", sdicISPEC_Out("GLOESTCIV"))
      __dic.Add("ESTCIV_FUN", sdicISPEC_Out("ESTCIV_FUN"))
      __dic.Add("GLOSEXO", sdicISPEC_Out("GLOSEXO"))
      __dic.Add("SEXO", sdicISPEC_Out("SEXO"))
      __dic.Add("FECNAC_FUN", sdicISPEC_Out("FECNAC_FUN"))
      __dic.Add("APEMAT_FUN", sdicISPEC_Out("APEMAT_FUN"))
      __dic.Add("APEPAT_FUN", sdicISPEC_Out("APEPAT_FUN"))
      __dic.Add("NOMBRE_FUN", sdicISPEC_Out("NOMBRE_FUN"))
      __dic.Add("GLOMEDPAG", sdicISPEC_Out("GLOMEDPAG"))
      __dic.Add("GLOCODBAN", sdicISPEC_Out("GLOCODBAN"))
      __js = New JavaScriptSerializer
      Return __js.Serialize(__dic)
    Catch ex As Exception
      Return ErrorHandler.ErrorAsJson(ex)
    Finally
    End Try
  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="CODUSU"></param>
  ''' <param name="EMAIL"></param>
  ''' <param name="MANT"></param>
  ''' <param name="OPCION"></param>
  ''' <param name="PASSMAIL"></param>
  ''' <param name="PRIORIDAD"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function IIMTU(ByVal PRIORIDAD As String,
                        ByVal EMAIL As String,
                        ByVal CODUSU As String,
                        ByVal OPCION As String,
                        ByVal MANT As String,
                        ByVal PASSMAIL As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing

    Try

      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)
      sdicISPEC_In = CreateObject("Scripting.Dictionary")
      sdicISPEC_Out = CreateObject("Scripting.Dictionary")

      sdicISPEC_In.Item("CODUSU") = CODUSU
      sdicISPEC_In.Item("EMAIL") = EMAIL
      sdicISPEC_In.Item("MANT") = MANT
      sdicISPEC_In.Item("OPCION") = OPCION
      sdicISPEC_In.Item("PASSMAIL") = PASSMAIL
      sdicISPEC_In.Item("PRIORIDAD") = PRIORIDAD

      objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "IIMTU", swError, strError)

      If swError <> 0 Then
        Throw New Exception(strError)
      End If

      __dic = New Dictionary(Of String, String)

      __dic.Add("CODUSU", sdicISPEC_Out("CODUSU"))
      __dic.Add("EMAIL", sdicISPEC_Out("EMAIL"))
      __dic.Add("MANT", sdicISPEC_Out("MANT"))
      __dic.Add("OPCION", sdicISPEC_Out("OPCION"))
      __dic.Add("PASSMAIL", sdicISPEC_Out("PASSMAIL"))
      __dic.Add("PRIORIDAD", sdicISPEC_Out("PRIORIDAD"))

      __js = New JavaScriptSerializer

      Return __js.Serialize(__dic)

    Catch ex As Exception
      Return ErrorHandler.ErrorAsJson(ex)
    Finally
    End Try

  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="ORQ"></param>
  ''' <param name="PRIORIDA_B"></param>
  ''' <param name="CODUSU"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function IICTU(ByVal ORQ As String,
                        ByVal PRIORIDA_B As String,
                        ByVal CODUSU As String) As String

    Dim objLINC_Conexion = Nothing

    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing
    Dim cfSize As Integer = 9

    Try

      Dim y As Integer = 0
      Dim sw As Boolean = True
      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      __cf = New Dictionary(Of String, List(Of Dictionary(Of String, String)))

      __cf.Add("__PARAMETERS__", New List(Of Dictionary(Of String, String)))
      __cf.Add("__COPYFROM__", New List(Of Dictionary(Of String, String)))

      While sw

        sdicISPEC_In = CreateObject("Scripting.Dictionary")
        sdicISPEC_Out = CreateObject("Scripting.Dictionary")
        sdicISPEC_In.Item("PRIORIDA_B") = PRIORIDA_B
        sdicISPEC_In.Item("CODUSU") = CODUSU

        objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "IICTU", swError, strError)

        If swError <> 0 Then
          Throw New Exception(strError)
        End If

        Dim aux As String = ""

        For i As Integer = 0 To cfSize '
          If Len(i.ToString) = 1 Then
            aux = "0" & i
          Else
            aux = i
          End If

          __dic = New Dictionary(Of String, String)

          If (Not y = 0 And i = 0) Or ((sdicISPEC_Out("PASSMAIL__AT_" & aux) = "" Or sdicISPEC_Out("PASSMAIL__AT_" & aux) = "0") And (sdicISPEC_Out("EMAIL__AT_" & aux) = "" Or sdicISPEC_Out("EMAIL__AT_" & aux) = "0") And (sdicISPEC_Out("PRIORIDAD__AT_" & aux) = "" Or sdicISPEC_Out("PRIORIDAD__AT_" & aux) = "0")) Then
            Continue For
          End If

          __dic.Add("PASSMAIL", sdicISPEC_Out.Item("PASSMAIL__AT_" & aux))
          __dic.Add("EMAIL", sdicISPEC_Out.Item("EMAIL__AT_" & aux))
          __dic.Add("PRIORIDAD", sdicISPEC_Out.Item("PRIORIDAD__AT_" & aux))

          __cf("__COPYFROM__").Add(__dic)
        Next

        PRIORIDA_B = sdicISPEC_Out.Item("PRIORIDA_B")
        CODUSU = sdicISPEC_Out.Item("CODUSU")

        If sdicISPEC_Out.Item("MENJ35") = "HAY MAS DATOS" And ORQ = "T" Then
          sw = True
        Else
          sw = False
        End If
        y = y + 1
      End While

      __dic = New Dictionary(Of String, String)
      __dic.Add("PRIORIDA_B", PRIORIDA_B)
      __dic.Add("CODUSU", CODUSU)

      __cf("__PARAMETERS__").Add(__dic)

      __js = New JavaScriptSerializer

      Return __js.Serialize(__cf)

    Catch ex As Exception

      Return ErrorHandler.ErrorAsJson(ex)

    Finally

    End Try

  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="ORQ"></param>
  ''' <param name="CODOPCB"></param>
  ''' <param name="CODUSU"></param>
  ''' <param name="CODROL"></param>
  ''' <param name="CODSIS"></param>
  ''' <param name="MANT"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function IMROL(ByVal ORQ As String,
                                             ByVal CODOPCB As String,
                                             ByVal CODUSU As String,
                                             ByVal CODROL As String,
                                             ByVal CODSIS As String,
                                             ByVal MANT As String,
                                             ByVal PERMISO As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing
    Dim cfSize As Integer = 19

    Try

      Dim y As Integer = 0
      Dim sw As Boolean = True

      Dim swError As String = ""
      Dim strError As String = ""
      Dim aux As String = ""

      objLINC_Conexion = CreateObject(__activex)

      __cf = New Dictionary(Of String, List(Of Dictionary(Of String, String)))

      __cf.Add("__PARAMETERS__", New List(Of Dictionary(Of String, String)))

      __cf.Add("__COPYFROM__", New List(Of Dictionary(Of String, String)))

      While sw

        sdicISPEC_In = CreateObject("Scripting.Dictionary")
        sdicISPEC_Out = CreateObject("Scripting.Dictionary")

        sdicISPEC_In.Item("CODOPCB") = CODOPCB
        sdicISPEC_In.Item("CODUSU") = CODUSU
        sdicISPEC_In.Item("CODROL") = CODROL
        sdicISPEC_In.Item("CODSIS") = CODSIS
        sdicISPEC_In.Item("MANT") = MANT

        If Not MANT = "INQ" Then

          If PERMISO = "" Then
            Throw New Exception("No hay opciones que actualizar.")

          Else

            Dim cont As Integer = 1

            Dim z = 1
            Dim x = 1
            For i As Integer = 0 To cfSize - 1
              
              aux = cont.ToString().PadLeft(2, "0")

              If Len(z.ToString) = 1 Then
                aux = "0" & z
              Else
                aux = z
              End If

              sdicISPEC_In.Item("CODOPC1__AT_" & aux) = CODOPCB
              sdicISPEC_In.Item("PERMISO1__AT_" & aux) = PERMISO

              If (z = cfSize) Then

                objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "IMROL", swError, strError)

                If swError <> 0 Then
                  Throw New Exception(strError)
                End If

                sdicISPEC_In = CreateObject("Scripting.Dictionary")
                sdicISPEC_Out = CreateObject("Scripting.Dictionary")

                sdicISPEC_In.Item("CODOPCB") = CODOPCB
                sdicISPEC_In.Item("CODUSU") = CODUSU
                sdicISPEC_In.Item("CODROL") = CODROL
                sdicISPEC_In.Item("CODSIS") = CODSIS
                sdicISPEC_In.Item("MANT") = MANT

                z = 0

              End If

              z += 1
              x += 1

            Next

          End If

          sdicISPEC_In.Item("MANT") = "INQ"

        End If

        objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "IMROL", swError, strError)

        If swError <> 0 Then
          Throw New Exception(strError)
        End If

        For i As Integer = 0 To cfSize '
          If Len(i.ToString) = 1 Then
            aux = "0" & i
          Else
            aux = i
          End If

          __dic = New Dictionary(Of String, String)

          If (Not y = 0 And i = 0) Or ((sdicISPEC_Out("PERMISO4__AT_" & aux) = "" Or sdicISPEC_Out("PERMISO4__AT_" & aux) = "0") And (sdicISPEC_Out("CODOPC4__AT_" & aux) = "" Or sdicISPEC_Out("CODOPC4__AT_" & aux) = "0") And (sdicISPEC_Out("PERMISO3__AT_" & aux) = "" Or sdicISPEC_Out("PERMISO3__AT_" & aux) = "0") And (sdicISPEC_Out("CODOPC3__AT_" & aux) = "" Or sdicISPEC_Out("CODOPC3__AT_" & aux) = "0") And (sdicISPEC_Out("PERMISO2__AT_" & aux) = "" Or sdicISPEC_Out("PERMISO2__AT_" & aux) = "0") And (sdicISPEC_Out("CODOPC2__AT_" & aux) = "" Or sdicISPEC_Out("CODOPC2__AT_" & aux) = "0") And (sdicISPEC_Out("PERMISO1__AT_" & aux) = "" Or sdicISPEC_Out("PERMISO1__AT_" & aux) = "0") And (sdicISPEC_Out("CODOPC1__AT_" & aux) = "" Or sdicISPEC_Out("CODOPC1__AT_" & aux) = "0")) Then
            Continue For
          End If

          __dic.Add("PERMISO4", sdicISPEC_Out.Item("PERMISO4__AT_" & aux))
          __dic.Add("CODOPC4", sdicISPEC_Out.Item("CODOPC4__AT_" & aux))
          __dic.Add("PERMISO3", sdicISPEC_Out.Item("PERMISO3__AT_" & aux))
          __dic.Add("CODOPC3", sdicISPEC_Out.Item("CODOPC3__AT_" & aux))
          __dic.Add("PERMISO2", sdicISPEC_Out.Item("PERMISO2__AT_" & aux))
          __dic.Add("CODOPC2", sdicISPEC_Out.Item("CODOPC2__AT_" & aux))
          __dic.Add("PERMISO1", sdicISPEC_Out.Item("PERMISO1__AT_" & aux))
          __dic.Add("CODOPC1", sdicISPEC_Out.Item("CODOPC1__AT_" & aux))
          __cf("__COPYFROM__").Add(__dic)

        Next

        CODOPCB = sdicISPEC_Out.Item("CODOPCB")
        CODUSU = sdicISPEC_Out.Item("CODUSU")
        CODROL = sdicISPEC_Out.Item("CODROL")
        CODSIS = sdicISPEC_Out.Item("CODSIS")
        MANT = sdicISPEC_Out.Item("MANT")

        If sdicISPEC_Out.Item("MENSAJE") = "HAY MAS DATOS" And ORQ = "T" Then
          sw = True
        Else
          sw = False
        End If
        y = y + 1
      End While

      __dic = New Dictionary(Of String, String)
      __dic.Add("CODOPCB", CODOPCB)
      __dic.Add("CODUSU", CODUSU)
      __dic.Add("CODROL", CODROL)
      __dic.Add("CODSIS", CODSIS)
      __dic.Add("MANT", MANT)

      __cf("__PARAMETERS__").Add(__dic)

      __js = New JavaScriptSerializer

      Return __js.Serialize(__cf)

    Catch ex As Exception

      Return ErrorHandler.ErrorAsJson(ex)

    Finally

    End Try

  End Function

  ''' <summary>
  ''' 30/05/2019 rtorreblanca: Creación.
  ''' </summary>
  ''' <param name="RUTFUN"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function ICFUN(ByVal RUTFUN As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing

    Try

      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      sdicISPEC_In = CreateObject("Scripting.Dictionary")
      sdicISPEC_Out = CreateObject("Scripting.Dictionary")
      sdicISPEC_In.Item("RUTFUN") = RUTFUN

      objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "ICFUN", swError, strError)

      If swError <> 0 Then
        Throw New Exception(strError)
      End If

      __dic = New Dictionary(Of String, String)

      __dic.Add("RUTFUN", sdicISPEC_Out("RUTFUN"))
      __dic.Add("MATMIL", sdicISPEC_Out("MATMIL"))
      __dic.Add("GLORAMA", sdicISPEC_Out("GLORAMA"))
      __dic.Add("GLOMIL", sdicISPEC_Out("GLOMIL"))
      __dic.Add("ANOMIL", sdicISPEC_Out("ANOMIL"))
      __dic.Add("CANMIL", sdicISPEC_Out("CANMIL"))
      __dic.Add("GLOISAPRE", sdicISPEC_Out("GLOISAPRE"))
      __dic.Add("GLOCAJA", sdicISPEC_Out("GLOCAJA"))
      __dic.Add("GLOAFP", sdicISPEC_Out("GLOAFP"))
      __dic.Add("FINGGA", sdicISPEC_Out("FINGGA"))
      __dic.Add("FINGES", sdicISPEC_Out("FINGES"))
      __dic.Add("GLOHORAR", sdicISPEC_Out("GLOHORAR"))
      __dic.Add("GLOJORTRA", sdicISPEC_Out("GLOJORTRA"))
      __dic.Add("GLOESCALAF", sdicISPEC_Out("GLOESCALAF"))
      __dic.Add("GLOFUNCION", sdicISPEC_Out("GLOFUNCION"))
      __dic.Add("GLOUBILAB", sdicISPEC_Out("GLOUBILAB"))
      __dic.Add("GLOPROFE", sdicISPEC_Out("GLOPROFE"))
      __dic.Add("GLOCALJUR", sdicISPEC_Out("GLOCALJUR"))
      __dic.Add("GLOGRADO", sdicISPEC_Out("GLOGRADO"))
      __dic.Add("GLOPLANTA", sdicISPEC_Out("GLOPLANTA"))
      __dic.Add("GLOSECCION", sdicISPEC_Out("GLOSECCION"))
      __dic.Add("CODSECCION", sdicISPEC_Out("CODSECCION"))
      __dic.Add("GLODEPTO", sdicISPEC_Out("GLODEPTO"))
      __dic.Add("CODDEPTO", sdicISPEC_Out("CODDEPTO"))
      __dic.Add("GLODIRECC", sdicISPEC_Out("GLODIRECC"))
      __dic.Add("CODDIRECC", sdicISPEC_Out("CODDIRECC"))
      __dic.Add("GLOAREA", sdicISPEC_Out("GLOAREA"))
      __dic.Add("CODAREA", sdicISPEC_Out("CODAREA"))
      __dic.Add("FINGSE_FUN", sdicISPEC_Out("FINGSE_FUN"))
      __dic.Add("FECDEC", sdicISPEC_Out("FECDEC"))
      __dic.Add("NUMDEC_PRO", sdicISPEC_Out("NUMDEC_PRO"))
      __dic.Add("GLOCCOSTO", sdicISPEC_Out("GLOCCOSTO"))
      __dic.Add("TELEFONO", sdicISPEC_Out("TELEFONO"))
      __dic.Add("ESTCIV", sdicISPEC_Out("ESTCIV"))
      __dic.Add("SEXO", sdicISPEC_Out("SEXO"))
      __dic.Add("FECNAC", sdicISPEC_Out("FECNAC"))
      __dic.Add("COMUNA", sdicISPEC_Out("COMUNA"))
      __dic.Add("ACLARA", sdicISPEC_Out("ACLARA"))
      __dic.Add("NCALLE", sdicISPEC_Out("NCALLE"))
      __dic.Add("CALLE", sdicISPEC_Out("CALLE"))
      __dic.Add("NOMBRE", sdicISPEC_Out("NOMBRE"))
      __dic.Add("APEMAT", sdicISPEC_Out("APEMAT"))
      __dic.Add("APEPAT", sdicISPEC_Out("APEPAT"))
      __dic.Add("INDVIG", sdicISPEC_Out("INDVIG"))

      __js = New JavaScriptSerializer

      Return __js.Serialize(__dic)

    Catch ex As Exception
      Return ErrorHandler.ErrorAsJson(ex)
    Finally

    End Try

  End Function

  ''' <summary>
  ''' 30/05/2019 jcalderon: Creacion
  ''' </summary>
  ''' <param name="ORQ"></param>
  ''' <param name="INST"></param>
  ''' <param name="ANO"></param>
  ''' <param name="RUTFUN"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function IMESL(ByVal ORQ As String,
                        ByVal INST As String,
                        ByVal ANO As String,
                        ByVal RUTFUN As String,
                        ByVal ANOINI As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing
    Dim cfSize As Integer = 11

    Try

      Dim y As Integer = 0
      Dim sw As Boolean = True
      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      __cf = New Dictionary(Of String, List(Of Dictionary(Of String, String)))
      __cf.Add("__PARAMETERS__", New List(Of Dictionary(Of String, String)))
      __cf.Add("__COPYFROM__", New List(Of Dictionary(Of String, String)))

      While sw

        sdicISPEC_In = CreateObject("Scripting.Dictionary")
        sdicISPEC_Out = CreateObject("Scripting.Dictionary")

        sdicISPEC_In.Item("INST") = INST
        sdicISPEC_In.Item("ANO") = ANO
        sdicISPEC_In.Item("RUTFUN") = RUTFUN
        sdicISPEC_In.Item("ANOINI") = ANOINI

        objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "IMESL", swError, strError)

        If swError <> 0 Then
          Throw New Exception(strError)
        End If

        Dim aux As String = ""

        For i As Integer = 0 To cfSize '
          If Len(i.ToString) = 1 Then
            aux = "0" & i
          Else
            aux = i
          End If

          __dic = New Dictionary(Of String, String)

          If (Not y = 0 And i = 0) Or ((sdicISPEC_Out("GLOSAMES__AT_" & aux) = "" Or sdicISPEC_Out("GLOSAMES__AT_" & aux) = "0") And (sdicISPEC_Out("NUMMES__AT_" & aux) = "" Or sdicISPEC_Out("NUMMES__AT_" & aux) = "0") And (sdicISPEC_Out("ANOINI__AT_" & aux) = "" Or sdicISPEC_Out("ANOINI__AT_" & aux) = "0") And (sdicISPEC_Out("ANO__AT_" & aux) = "" Or sdicISPEC_Out("ANO__AT_" & aux) = "0")) Then
            Continue For
          End If

          __dic.Add("GLOSAMES", sdicISPEC_Out.Item("GLOSAMES__AT_" & aux))
          __dic.Add("NUMMES", sdicISPEC_Out.Item("NUMMES__AT_" & aux))
          __dic.Add("ANOINI", sdicISPEC_Out.Item("ANOINI__AT_" & aux))
          __dic.Add("ANO", sdicISPEC_Out.Item("ANO__AT_" & aux))
          __cf("__COPYFROM__").Add(__dic)
        Next

        INST = sdicISPEC_Out.Item("INST")
        ANO = sdicISPEC_Out.Item("ANO")
        RUTFUN = sdicISPEC_Out.Item("RUTFUN")
        ANOINI = sdicISPEC_Out.Item("ANOINI")

        If sdicISPEC_Out.Item("MENJ35") = "HAY MAS DATOS" And ORQ = "T" Then
          sw = True
        Else
          sw = False
        End If
        y = y + 1
      End While

      __dic = New Dictionary(Of String, String)
      __dic.Add("INST", INST)
      __dic.Add("ANO", ANO)
      __dic.Add("RUTFUN", RUTFUN)
      __dic.Add("ANOINI", ANOINI)

      __cf("__PARAMETERS__").Add(__dic)

      __js = New JavaScriptSerializer

      Return __js.Serialize(__cf)
    Catch ex As Exception
      Return ErrorHandler.ErrorAsJson(ex)

    Finally

    End Try

  End Function

  ''' <summary>
  ''' 30/05/2019 rtorreblanca: Creación
  ''' </summary>
  ''' <param name="ORQ"></param>
  ''' <param name="FECINI"></param>
  ''' <param name="RUTFUN"></param>
  ''' <param name="VAMENU"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function ICLIC(ByVal ORQ As String,
                        ByVal FECINI As String,
                        ByVal RUTFUN As String,
                        ByVal VAMENU As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing
    Dim cfSize As Integer = 9

    Try

      Dim y As Integer = 0
      Dim sw As Boolean = True

      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      __cf = New Dictionary(Of String, List(Of Dictionary(Of String, String)))
      __cf.Add("__PARAMETERS__", New List(Of Dictionary(Of String, String)))
      __cf.Add("__COPYFROM__", New List(Of Dictionary(Of String, String)))

      While sw

        sdicISPEC_In = CreateObject("Scripting.Dictionary")
        sdicISPEC_Out = CreateObject("Scripting.Dictionary")

        sdicISPEC_In.Item("FECINI") = FECINI
        sdicISPEC_In.Item("RUTFUN") = RUTFUN
        sdicISPEC_In.Item("VAMENU") = VAMENU

        objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "ICLIC", swError, strError)

        If swError <> 0 Then
          Throw New Exception(strError)
        End If

        Dim aux As String = ""

        For i As Integer = 0 To cfSize '
          If Len(i.ToString) = 1 Then
            aux = "0" & i
          Else
            aux = i
          End If

          __dic = New Dictionary(Of String, String)

          If (Not y = 0 And i = 0) Or ((sdicISPEC_Out("FECTER_LIC__AT_" & aux) = "" Or sdicISPEC_Out("FECTER_LIC__AT_" & aux) = "0") And (sdicISPEC_Out("NRODIA_LIC__AT_" & aux) = "" Or sdicISPEC_Out("NRODIA_LIC__AT_" & aux) = "0") And (sdicISPEC_Out("FECACC_LIC__AT_" & aux) = "" Or sdicISPEC_Out("FECACC_LIC__AT_" & aux) = "0") And (sdicISPEC_Out("FECRESL__AT_" & aux) = "" Or sdicISPEC_Out("FECRESL__AT_" & aux) = "0") And (sdicISPEC_Out("RESSAL__AT_" & aux) = "" Or sdicISPEC_Out("RESSAL__AT_" & aux) = "0") And (sdicISPEC_Out("NUMLIC__AT_" & aux) = "" Or sdicISPEC_Out("NUMLIC__AT_" & aux) = "0") And (sdicISPEC_Out("GLODIRECC__AT_" & aux) = "" Or sdicISPEC_Out("GLODIRECC__AT_" & aux) = "0") And (sdicISPEC_Out("FECINI_LIC__AT_" & aux) = "" Or sdicISPEC_Out("FECINI_LIC__AT_" & aux) = "0")) Then
            Continue For
          End If

          __dic.Add("FECTER_LIC", sdicISPEC_Out.Item("FECTER_LIC__AT_" & aux))
          __dic.Add("NRODIA_LIC", sdicISPEC_Out.Item("NRODIA_LIC__AT_" & aux))
          __dic.Add("FECACC_LIC", sdicISPEC_Out.Item("FECACC_LIC__AT_" & aux))
          __dic.Add("FECRESL", sdicISPEC_Out.Item("FECRESL__AT_" & aux))
          __dic.Add("RESSAL", sdicISPEC_Out.Item("RESSAL__AT_" & aux))
          __dic.Add("NUMLIC", sdicISPEC_Out.Item("NUMLIC__AT_" & aux))
          __dic.Add("GLODIRECC", sdicISPEC_Out.Item("GLODIRECC__AT_" & aux))
          __dic.Add("FECINI_LIC", sdicISPEC_Out.Item("FECINI_LIC__AT_" & aux))
          __cf("__COPYFROM__").Add(__dic)
        Next

        FECINI = sdicISPEC_Out.Item("FECINI")
        RUTFUN = sdicISPEC_Out.Item("RUTFUN")
        VAMENU = sdicISPEC_Out.Item("VAMENU")

        If sdicISPEC_Out.Item("MENJ35") = "HAY MAS DATOS" And ORQ = "T" Then
          sw = True
        Else
          sw = False
        End If
        y = y + 1

      End While

      __dic = New Dictionary(Of String, String)

      __dic.Add("FECINI", FECINI)
      __dic.Add("RUTFUN", RUTFUN)
      __dic.Add("VAMENU", VAMENU)
      __cf("__PARAMETERS__").Add(__dic)

      __js = New JavaScriptSerializer

      Return __js.Serialize(__cf)

    Catch ex As Exception
      Return ErrorHandler.ErrorAsJson(ex)
    Finally

    End Try

  End Function

  ''' <summary>
  ''' 31/05/2019 rtorreblanca: Creación.
  ''' </summary>
  ''' <param name="VALPROMCOT"></param>
  ''' <param name="VALPROMLIQ"></param>
  ''' <param name="VALRECIBIR"></param>
  ''' <param name="VALSUBSID"></param>
  ''' <param name="VALCOTIZA"></param>
  ''' <param name="ANO_AVISO"></param>
  ''' <param name="CODUSU"></param>
  ''' <param name="NUM_AVISO"></param>
  ''' <param name="CODAREA"></param>
  ''' <param name="FECANTECED"></param>
  ''' <param name="FEC_AVISO"></param>
  ''' <param name="FECANT_LIC"></param>
  ''' <param name="TIPLIC"></param>
  ''' <param name="ESTLIC"></param>
  ''' <param name="FECRECLIC"></param>
  ''' <param name="FECTER_CON"></param>
  ''' <param name="FECINI_CON"></param>
  ''' <param name="PRI_AMP"></param>
  ''' <param name="OBSER2"></param>
  ''' <param name="OBSER1"></param>
  ''' <param name="PERREMUN"></param>
  ''' <param name="VALREMB"></param>
  ''' <param name="OBSERV_LIC"></param>
  ''' <param name="ESPECI"></param>
  ''' <param name="DIAGNO_LIC"></param>
  ''' <param name="FECRESL"></param>
  ''' <param name="CODDIAG"></param>
  ''' <param name="TIPSUB"></param>
  ''' <param name="CODEST"></param>
  ''' <param name="ACLARAM"></param>
  ''' <param name="CORRELA"></param>
  ''' <param name="RESSSAL"></param>
  ''' <param name="SERVSAL"></param>
  ''' <param name="COMUNAM"></param>
  ''' <param name="NUMEROM"></param>
  ''' <param name="CALLEM"></param>
  ''' <param name="RUTHIJ"></param>
  ''' <param name="RUTMED"></param>
  ''' <param name="APEMATM"></param>
  ''' <param name="FONOMED"></param>
  ''' <param name="APEPATM"></param>
  ''' <param name="NOMMED_LIC"></param>
  ''' <param name="MESCON"></param>
  ''' <param name="FECNAC"></param>
  ''' <param name="FECACC_LIC"></param>
  ''' <param name="NRODIA_LIC"></param>
  ''' <param name="NUMLIC_DV"></param>
  ''' <param name="NUMLIC_LIC"></param>
  ''' <param name="TIPMED"></param>
  ''' <param name="ACLARA_LIC"></param>
  ''' <param name="FONO_LIC"></param>
  ''' <param name="COMUNA_LIC"></param>
  ''' <param name="NCALLE_LIC"></param>
  ''' <param name="CALLE_LIC"></param>
  ''' <param name="CODOCU"></param>
  ''' <param name="ACTLAB"></param>
  ''' <param name="CODJORNADA"></param>
  ''' <param name="CODLICEN"></param>
  ''' <param name="FECEMI"></param>
  ''' <param name="FECINI_LIC"></param>
  ''' <param name="RUTFUN"></param>
  ''' <param name="VACLICF"></param>
  ''' <param name="VASILIC"></param>
  ''' <param name="VAANLIC"></param>
  ''' <param name="VAULLIC"></param>
  ''' <param name="VAMENU"></param>
  ''' <param name="MANT"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function INLI3(ByVal VALPROMCOT As String,
                         ByVal VALPROMLIQ As String,
                         ByVal VALRECIBIR As String,
                         ByVal VALSUBSID As String,
                         ByVal VALCOTIZA As String,
                         ByVal ANO_AVISO As String,
                         ByVal CODUSU As String,
                         ByVal NUM_AVISO As String,
                         ByVal CODAREA As String,
                         ByVal FECANTECED As String,
                         ByVal FEC_AVISO As String,
                         ByVal FECANT_LIC As String,
                         ByVal TIPLIC As String,
                         ByVal ESTLIC As String,
                         ByVal FECRECLIC As String,
                         ByVal FECTER_CON As String,
                         ByVal FECINI_CON As String,
                         ByVal PRI_AMP As String,
                         ByVal OBSER2 As String,
                         ByVal OBSER1 As String,
                         ByVal PERREMUN As String,
                         ByVal VALREMB As String,
                         ByVal OBSERV_LIC As String,
                         ByVal ESPECI As String,
                         ByVal DIAGNO_LIC As String,
                         ByVal FECRESL As String,
                         ByVal CODDIAG As String,
                         ByVal TIPSUB As String,
                         ByVal CODEST As String,
                         ByVal ACLARAM As String,
                         ByVal CORRELA As String,
                         ByVal RESSSAL As String,
                         ByVal SERVSAL As String,
                         ByVal COMUNAM As String,
                         ByVal NUMEROM As String,
                         ByVal CALLEM As String,
                         ByVal RUTHIJ As String,
                         ByVal RUTMED As String,
                         ByVal APEMATM As String,
                         ByVal FONOMED As String,
                         ByVal APEPATM As String,
                         ByVal NOMMED_LIC As String,
                         ByVal MESCON As String,
                         ByVal FECNAC As String,
                         ByVal FECACC_LIC As String,
                         ByVal NRODIA_LIC As String,
                         ByVal NUMLIC_DV As String,
                         ByVal NUMLIC_LIC As String,
                         ByVal TIPMED As String,
                         ByVal ACLARA_LIC As String,
                         ByVal FONO_LIC As String,
                         ByVal COMUNA_LIC As String,
                         ByVal NCALLE_LIC As String,
                         ByVal CALLE_LIC As String,
                         ByVal CODOCU As String,
                         ByVal ACTLAB As String,
                         ByVal CODJORNADA As String,
                         ByVal CODLICEN As String,
                         ByVal FECEMI As String,
                         ByVal FECINI_LIC As String,
                         ByVal RUTFUN As String,
                         ByVal VACLICF As String,
                         ByVal VASILIC As String,
                         ByVal VAANLIC As String,
                         ByVal VAULLIC As String,
                         ByVal VAMENU As String,
                         ByVal MANT As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing

    Try

      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      sdicISPEC_In = CreateObject("Scripting.Dictionary")
      sdicISPEC_Out = CreateObject("Scripting.Dictionary")

      sdicISPEC_In.Item("VALPROMCOT") = VALPROMCOT
      sdicISPEC_In.Item("VALPROMLIQ") = VALPROMLIQ
      sdicISPEC_In.Item("VALRECIBIR") = VALRECIBIR
      sdicISPEC_In.Item("VALSUBSID") = VALSUBSID
      sdicISPEC_In.Item("VALCOTIZA") = VALCOTIZA
      sdicISPEC_In.Item("ANO_AVISO") = ANO_AVISO
      sdicISPEC_In.Item("CODUSU") = CODUSU
      sdicISPEC_In.Item("NUM_AVISO") = NUM_AVISO
      sdicISPEC_In.Item("CODAREA") = CODAREA
      sdicISPEC_In.Item("FECANTECED") = FECANTECED
      sdicISPEC_In.Item("FEC_AVISO") = FEC_AVISO
      sdicISPEC_In.Item("FECANT_LIC") = FECANT_LIC
      sdicISPEC_In.Item("TIPLIC") = TIPLIC
      sdicISPEC_In.Item("ESTLIC") = ESTLIC
      sdicISPEC_In.Item("FECRECLIC") = FECRECLIC
      sdicISPEC_In.Item("FECTER_CON") = FECTER_CON
      sdicISPEC_In.Item("FECINI_CON") = FECINI_CON
      sdicISPEC_In.Item("PRI_AMP") = PRI_AMP
      sdicISPEC_In.Item("OBSER2") = OBSER2
      sdicISPEC_In.Item("OBSER1") = OBSER1
      sdicISPEC_In.Item("PERREMUN") = PERREMUN
      sdicISPEC_In.Item("VALREMB") = VALREMB
      sdicISPEC_In.Item("OBSERV_LIC") = OBSERV_LIC
      sdicISPEC_In.Item("ESPECI") = ESPECI
      sdicISPEC_In.Item("DIAGNO_LIC") = DIAGNO_LIC
      sdicISPEC_In.Item("FECRESL") = FECRESL
      sdicISPEC_In.Item("CODDIAG") = CODDIAG
      sdicISPEC_In.Item("TIPSUB") = TIPSUB
      sdicISPEC_In.Item("CODEST") = CODEST
      sdicISPEC_In.Item("ACLARAM") = ACLARAM
      sdicISPEC_In.Item("CORRELA") = CORRELA
      sdicISPEC_In.Item("RESSSAL") = RESSSAL
      sdicISPEC_In.Item("SERVSAL") = SERVSAL
      sdicISPEC_In.Item("COMUNAM") = COMUNAM
      sdicISPEC_In.Item("NUMEROM") = NUMEROM
      sdicISPEC_In.Item("CALLEM") = CALLEM
      sdicISPEC_In.Item("RUTHIJ") = RUTHIJ
      sdicISPEC_In.Item("RUTMED") = RUTMED
      sdicISPEC_In.Item("APEMATM") = APEMATM
      sdicISPEC_In.Item("FONOMED") = FONOMED
      sdicISPEC_In.Item("APEPATM") = APEPATM
      sdicISPEC_In.Item("NOMMED_LIC") = NOMMED_LIC
      sdicISPEC_In.Item("MESCON") = MESCON
      sdicISPEC_In.Item("FECNAC") = FECNAC
      sdicISPEC_In.Item("FECACC_LIC") = FECACC_LIC
      sdicISPEC_In.Item("NRODIA_LIC") = NRODIA_LIC
      sdicISPEC_In.Item("NUMLIC_DV") = NUMLIC_DV
      sdicISPEC_In.Item("NUMLIC_LIC") = NUMLIC_LIC
      sdicISPEC_In.Item("TIPMED") = TIPMED
      sdicISPEC_In.Item("ACLARA_LIC") = ACLARA_LIC
      sdicISPEC_In.Item("FONO_LIC") = FONO_LIC
      sdicISPEC_In.Item("COMUNA_LIC") = COMUNA_LIC
      sdicISPEC_In.Item("NCALLE_LIC") = NCALLE_LIC
      sdicISPEC_In.Item("CALLE_LIC") = CALLE_LIC
      sdicISPEC_In.Item("CODOCU") = CODOCU
      sdicISPEC_In.Item("ACTLAB") = ACTLAB
      sdicISPEC_In.Item("CODJORNADA") = CODJORNADA
      sdicISPEC_In.Item("CODLICEN") = CODLICEN
      sdicISPEC_In.Item("FECEMI") = FECEMI
      sdicISPEC_In.Item("FECINI_LIC") = FECINI_LIC
      sdicISPEC_In.Item("RUTFUN") = RUTFUN
      sdicISPEC_In.Item("VACLICF") = VACLICF
      sdicISPEC_In.Item("VASILIC") = VASILIC
      sdicISPEC_In.Item("VAANLIC") = VAANLIC
      sdicISPEC_In.Item("VAULLIC") = VAULLIC
      sdicISPEC_In.Item("VAMENU") = VAMENU
      sdicISPEC_In.Item("MANT") = MANT

      objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "INLI3", swError, strError)

      If swError <> 0 Then
        Throw New Exception(strError)
      End If

      __dic = New Dictionary(Of String, String)

      __dic.Add("VALPROMCOT", sdicISPEC_Out("VALPROMCOT"))
      __dic.Add("VALPROMLIQ", sdicISPEC_Out("VALPROMLIQ"))
      __dic.Add("VALRECIBIR", sdicISPEC_Out("VALRECIBIR"))
      __dic.Add("VALSUBSID", sdicISPEC_Out("VALSUBSID"))
      __dic.Add("VALCOTIZA", sdicISPEC_Out("VALCOTIZA"))
      __dic.Add("ANO_AVISO", sdicISPEC_Out("ANO_AVISO"))
      __dic.Add("CODUSU", sdicISPEC_Out("CODUSU"))
      __dic.Add("NUM_AVISO", sdicISPEC_Out("NUM_AVISO"))
      __dic.Add("CODAREA", sdicISPEC_Out("CODAREA"))
      __dic.Add("FECANTECED", sdicISPEC_Out("FECANTECED"))
      __dic.Add("FEC_AVISO", sdicISPEC_Out("FEC_AVISO"))
      __dic.Add("FECANT_LIC", sdicISPEC_Out("FECANT_LIC"))
      __dic.Add("TIPLIC", sdicISPEC_Out("TIPLIC"))
      __dic.Add("ESTLIC", sdicISPEC_Out("ESTLIC"))
      __dic.Add("FECRECLIC", sdicISPEC_Out("FECRECLIC"))
      __dic.Add("FECTER_CON", sdicISPEC_Out("FECTER_CON"))
      __dic.Add("FECINI_CON", sdicISPEC_Out("FECINI_CON"))
      __dic.Add("PRI_AMP", sdicISPEC_Out("PRI_AMP"))
      __dic.Add("OBSER2", sdicISPEC_Out("OBSER2"))
      __dic.Add("OBSER1", sdicISPEC_Out("OBSER1"))
      __dic.Add("PERREMUN", sdicISPEC_Out("PERREMUN"))
      __dic.Add("VALREMB", sdicISPEC_Out("VALREMB"))
      __dic.Add("OBSERV_LIC", sdicISPEC_Out("OBSERV_LIC"))
      __dic.Add("ESPECI", sdicISPEC_Out("ESPECI"))
      __dic.Add("DIAGNO_LIC", sdicISPEC_Out("DIAGNO_LIC"))
      __dic.Add("FECRESL", sdicISPEC_Out("FECRESL"))
      __dic.Add("CODDIAG", sdicISPEC_Out("CODDIAG"))
      __dic.Add("TIPSUB", sdicISPEC_Out("TIPSUB"))
      __dic.Add("CODEST", sdicISPEC_Out("CODEST"))
      __dic.Add("ACLARAM", sdicISPEC_Out("ACLARAM"))
      __dic.Add("CORRELA", sdicISPEC_Out("CORRELA"))
      __dic.Add("RESSSAL", sdicISPEC_Out("RESSSAL"))
      __dic.Add("SERVSAL", sdicISPEC_Out("SERVSAL"))
      __dic.Add("COMUNAM", sdicISPEC_Out("COMUNAM"))
      __dic.Add("NUMEROM", sdicISPEC_Out("NUMEROM"))
      __dic.Add("CALLEM", sdicISPEC_Out("CALLEM"))
      __dic.Add("RUTHIJ", sdicISPEC_Out("RUTHIJ"))
      __dic.Add("RUTMED", sdicISPEC_Out("RUTMED"))
      __dic.Add("APEMATM", sdicISPEC_Out("APEMATM"))
      __dic.Add("FONOMED", sdicISPEC_Out("FONOMED"))
      __dic.Add("APEPATM", sdicISPEC_Out("APEPATM"))
      __dic.Add("NOMMED_LIC", sdicISPEC_Out("NOMMED_LIC"))
      __dic.Add("MESCON", sdicISPEC_Out("MESCON"))
      __dic.Add("FECNAC", sdicISPEC_Out("FECNAC"))
      __dic.Add("FECACC_LIC", sdicISPEC_Out("FECACC_LIC"))
      __dic.Add("NRODIA_LIC", sdicISPEC_Out("NRODIA_LIC"))
      __dic.Add("NUMLIC_DV", sdicISPEC_Out("NUMLIC_DV"))
      __dic.Add("NUMLIC_LIC", sdicISPEC_Out("NUMLIC_LIC"))
      __dic.Add("TIPMED", sdicISPEC_Out("TIPMED"))
      __dic.Add("ACLARA_LIC", sdicISPEC_Out("ACLARA_LIC"))
      __dic.Add("FONO_LIC", sdicISPEC_Out("FONO_LIC"))
      __dic.Add("COMUNA_LIC", sdicISPEC_Out("COMUNA_LIC"))
      __dic.Add("NCALLE_LIC", sdicISPEC_Out("NCALLE_LIC"))
      __dic.Add("CALLE_LIC", sdicISPEC_Out("CALLE_LIC"))
      __dic.Add("CODOCU", sdicISPEC_Out("CODOCU"))
      __dic.Add("ACTLAB", sdicISPEC_Out("ACTLAB"))
      __dic.Add("CODJORNADA", sdicISPEC_Out("CODJORNADA"))
      __dic.Add("CODLICEN", sdicISPEC_Out("CODLICEN"))
      __dic.Add("FECEMI", sdicISPEC_Out("FECEMI"))
      __dic.Add("FECINI_LIC", sdicISPEC_Out("FECINI_LIC"))
      __dic.Add("RUTFUN", sdicISPEC_Out("RUTFUN"))
      __dic.Add("VACLICF", sdicISPEC_Out("VACLICF"))
      __dic.Add("VASILIC", sdicISPEC_Out("VASILIC"))
      __dic.Add("VAANLIC", sdicISPEC_Out("VAANLIC"))
      __dic.Add("VAULLIC", sdicISPEC_Out("VAULLIC"))
      __dic.Add("VAMENU", sdicISPEC_Out("VAMENU"))
      __dic.Add("MANT", sdicISPEC_Out("MANT"))
      __dic.Add("GLOFUN", sdicISPEC_Out("GLOFUN"))
      __dic.Add("CODFUN", sdicISPEC_Out("CODFUN"))
      __dic.Add("CCOSMAIL", sdicISPEC_Out("CCOSMAIL"))
      __dic.Add("GESTLIC", sdicISPEC_Out("GESTLIC"))
      __dic.Add("GLOCOS", sdicISPEC_Out("GLOCOS"))
      __dic.Add("CCOSTO", sdicISPEC_Out("CCOSTO"))
      __dic.Add("VALH48", sdicISPEC_Out("VALH48"))
      __dic.Add("CON_TIP", sdicISPEC_Out("CON_TIP"))
      __dic.Add("TIPCON", sdicISPEC_Out("TIPCON"))
      __dic.Add("FEC1AFP", sdicISPEC_Out("FEC1AFP"))
      __dic.Add("GCODISA", sdicISPEC_Out("GCODISA"))
      __dic.Add("GTIPSUB", sdicISPEC_Out("GTIPSUB"))
      __dic.Add("GCODEST", sdicISPEC_Out("GCODEST"))
      __dic.Add("DIASAPAGO", sdicISPEC_Out("DIASAPAGO"))
      __dic.Add("NRODIA_PAG", sdicISPEC_Out("NRODIA_PAG"))
      __dic.Add("NRODIA_AUT", sdicISPEC_Out("NRODIA_AUT"))
      __dic.Add("GTIPMED", sdicISPEC_Out("GTIPMED"))
      __dic.Add("GCODOCU", sdicISPEC_Out("GCODOCU"))
      __dic.Add("GACTLAB", sdicISPEC_Out("GACTLAB"))
      __dic.Add("GLOJORNA", sdicISPEC_Out("GLOJORNA"))
      __dic.Add("GLOTIPLIC", sdicISPEC_Out("GLOTIPLIC"))
      __dic.Add("FINGSE_FUN", sdicISPEC_Out("FINGSE_FUN"))
      __dic.Add("FECTER_LIC", sdicISPEC_Out("FECTER_LIC"))
      __dic.Add("GLONOMBRE", sdicISPEC_Out("GLONOMBRE"))

      __js = New JavaScriptSerializer

      Return __js.Serialize(__dic)

    Catch ex As Exception
      Return ErrorHandler.ErrorAsJson(ex)
    Finally

    End Try

  End Function

  ''' <summary>
  ''' 05/06/2019 jcalderon: Creación 
  ''' </summary>
  ''' <param name="ORQ"></param>
  ''' <param name="ANO"></param>
  ''' <param name="COD_D"></param>
  ''' <param name="COD_B"></param>
  ''' <param name="COD_H"></param>
  ''' <param name="DIA_TRABAJ"></param>
  ''' <param name="INST"></param>
  ''' <param name="MES"></param>
  ''' <param name="RUTFUN"></param>
  ''' <param name="TIPFUN"></param>
  ''' <param name="TIPO"></param>
  ''' <param name="TIPOLIQ"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function ICOLI(ByVal ORQ As String,
                        ByVal ANO As String,
                        ByVal COD_D As String,
                        ByVal COD_B As String,
                        ByVal COD_H As String,
                        ByVal DIA_TRABAJ As String,
                        ByVal INST As String,
                        ByVal MES As String,
                        ByVal RUTFUN As String,
                        ByVal TIPFUN As String,
                        ByVal TIPO As String,
                        ByVal TIPOLIQ As String) As String

    Dim APEMATT As String = ""
    Dim APEPATT As String = ""
    Dim CAT As String = ""
    Dim CCOSTO As String = ""
    Dim CODAFP As String = ""
    Dim CODGRADO As String = ""
    Dim CODISA As String = ""
    Dim CODPLANTA As String = ""
    Dim COPLAN As String = ""
    Dim FECTERVIG As String = ""
    Dim FINGSE As String = ""
    Dim GLO_AFP As String = ""
    Dim GLO_IS As String = ""
    Dim GLO_MES As String = ""
    Dim GLOCCOSTO As String = ""
    Dim GLOGRADO As String = ""
    Dim GLOPLANTA As String = ""
    Dim HORAS As String = ""
    Dim MONPLA As String = ""
    Dim NIVEL As String = ""
    Dim NOMBRET As String = ""
    Dim NOMDL As String = ""
    Dim NOMDV As String = ""
    Dim NOMHAB As String = ""
    Dim NROBIE As String = ""
    Dim POR_IS As String = ""
    Dim SIGNO_B As String = ""
    Dim SIGNO_D As String = ""
    Dim SIGNO_DL As String = ""
    Dim SIGNO_DV As String = ""
    Dim SIGNO_H As String = ""
    Dim SIGNO_PA As String = ""
    Dim SIGNO_SB As String = ""
    Dim SIGNO_SB1 As String = ""
    Dim SIGNO_SB2 As String = ""
    Dim SIGNO_TH As String = ""
    Dim SIGNO_VI As String = ""
    Dim SUEL_BASE As String = ""
    Dim SUEL_BASE1 As String = ""
    Dim SUEL_BASE2 As String = ""
    Dim TOT_DESL As String = ""
    Dim TOT_DESV As String = ""
    Dim TOT_HAB As String = ""
    Dim VAL_AFP As String = ""
    Dim VAL_IMPON As String = ""
    Dim VAL_PAGO As String = ""


    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing
    Dim cfSize As Integer = 4

    Try
      Dim y As Integer = 0
      Dim sw As Boolean = True
      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      __cf = New Dictionary(Of String, List(Of Dictionary(Of String, String)))
      __cf.Add("__PARAMETERS__", New List(Of Dictionary(Of String, String)))
      __cf.Add("__COPYFROM__", New List(Of Dictionary(Of String, String)))

      While sw
        sdicISPEC_In = CreateObject("Scripting.Dictionary")
        sdicISPEC_Out = CreateObject("Scripting.Dictionary")
        sdicISPEC_In.Item("TIPO") = TIPO
        sdicISPEC_In.Item("DIA_TRABAJ") = DIA_TRABAJ
        sdicISPEC_In.Item("COD_D") = COD_D
        sdicISPEC_In.Item("COD_B") = COD_B
        sdicISPEC_In.Item("COD_H") = COD_H
        sdicISPEC_In.Item("TIPFUN") = TIPFUN
        sdicISPEC_In.Item("RUTFUN") = RUTFUN
        sdicISPEC_In.Item("TIPOLIQ") = TIPOLIQ
        sdicISPEC_In.Item("MES") = MES
        sdicISPEC_In.Item("ANO") = ANO
        sdicISPEC_In.Item("INST") = INST

        objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "ICOLI", swError, strError)

        If swError <> 0 Then
          Throw New Exception(strError)
        End If

        Dim aux As String = ""

        For i As Integer = 0 To cfSize '
          If Len(i.ToString) = 1 Then
            aux = "0" & i
          Else
            aux = i
          End If

          __dic = New Dictionary(Of String, String)

          If (Not y = 0 And i = 0) Or ((sdicISPEC_Out("VALDV__AT_" & aux) = "" Or sdicISPEC_Out("VALDV__AT_" & aux) = "0") And (sdicISPEC_Out("SIGNO_D__AT_" & aux) = "" Or sdicISPEC_Out("SIGNO_D__AT_" & aux) = "0") And (sdicISPEC_Out("NOMDV__AT_" & aux) = "" Or sdicISPEC_Out("NOMDV__AT_" & aux) = "0") And (sdicISPEC_Out("VALDL__AT_" & aux) = "" Or sdicISPEC_Out("VALDL__AT_" & aux) = "0") And (sdicISPEC_Out("SIGNO_B__AT_" & aux) = "" Or sdicISPEC_Out("SIGNO_B__AT_" & aux) = "0") And (sdicISPEC_Out("NOMDL__AT_" & aux) = "" Or sdicISPEC_Out("NOMDL__AT_" & aux) = "0") And (sdicISPEC_Out("VALHAB__AT_" & aux) = "" Or sdicISPEC_Out("VALHAB__AT_" & aux) = "0") And (sdicISPEC_Out("SIGNO_H__AT_" & aux) = "" Or sdicISPEC_Out("SIGNO_H__AT_" & aux) = "0") And (sdicISPEC_Out("NOMHAB__AT_" & aux) = "" Or sdicISPEC_Out("NOMHAB__AT_" & aux) = "0")) Then
            Continue For
          End If

          __dic.Add("VALDV", sdicISPEC_Out.Item("VALDV__AT_" & aux))
          __dic.Add("SIGNO_D", sdicISPEC_Out.Item("SIGNO_D__AT_" & aux))
          __dic.Add("NOMDV", sdicISPEC_Out.Item("NOMDV__AT_" & aux))
          __dic.Add("VALDL", sdicISPEC_Out.Item("VALDL__AT_" & aux))
          __dic.Add("SIGNO_B", sdicISPEC_Out.Item("SIGNO_B__AT_" & aux))
          __dic.Add("NOMDL", sdicISPEC_Out.Item("NOMDL__AT_" & aux))
          __dic.Add("VALHAB", sdicISPEC_Out.Item("VALHAB__AT_" & aux))
          __dic.Add("SIGNO_H", sdicISPEC_Out.Item("SIGNO_H__AT_" & aux))
          __dic.Add("NOMHAB", sdicISPEC_Out.Item("NOMHAB__AT_" & aux))

          __cf("__COPYFROM__").Add(__dic)

        Next

        TIPO = sdicISPEC_Out.Item("TIPO")
        DIA_TRABAJ = sdicISPEC_Out.Item("DIA_TRABAJ")
        COD_D = sdicISPEC_Out.Item("COD_D")
        COD_B = sdicISPEC_Out.Item("COD_B")
        COD_H = sdicISPEC_Out.Item("COD_H")
        TIPFUN = sdicISPEC_Out.Item("TIPFUN")
        RUTFUN = sdicISPEC_Out.Item("RUTFUN")
        TIPOLIQ = sdicISPEC_Out.Item("TIPOLIQ")
        MES = sdicISPEC_Out.Item("MES")
        ANO = sdicISPEC_Out.Item("ANO")
        INST = sdicISPEC_Out.Item("INST")
        APEMATT = sdicISPEC_Out.Item("APEMATT")
        APEPATT = sdicISPEC_Out.Item("APEPATT")
        CAT = sdicISPEC_Out.Item("CAT")
        CCOSTO = sdicISPEC_Out.Item("CCOSTO")
        COD_B = sdicISPEC_Out.Item("COD_B")
        COD_D = sdicISPEC_Out.Item("COD_D")
        COD_H = sdicISPEC_Out.Item("COD_H")
        CODAFP = sdicISPEC_Out.Item("CODAFP")
        CODGRADO = sdicISPEC_Out.Item("CODGRADO")
        CODISA = sdicISPEC_Out.Item("CODISA")
        CODPLANTA = sdicISPEC_Out.Item("CODPLANTA")
        COPLAN = sdicISPEC_Out.Item("COPLAN")
        DIA_TRABAJ = sdicISPEC_Out.Item("DIA_TRABAJ")
        FECTERVIG = sdicISPEC_Out.Item("FECTERVIG")
        FINGSE = sdicISPEC_Out.Item("FINGSE")
        GLO_AFP = sdicISPEC_Out.Item("GLO_AFP")
        GLO_IS = sdicISPEC_Out.Item("GLO_IS")
        GLO_MES = sdicISPEC_Out.Item("GLO_MES")
        GLOCCOSTO = sdicISPEC_Out.Item("GLOCCOSTO")
        GLOGRADO = sdicISPEC_Out.Item("GLOGRADO")
        GLOPLANTA = sdicISPEC_Out.Item("GLOPLANTA")
        HORAS = sdicISPEC_Out.Item("HORAS")
        INST = sdicISPEC_Out.Item("INST")
        MES = sdicISPEC_Out.Item("MES")
        MONPLA = sdicISPEC_Out.Item("MONPLA")
        NIVEL = sdicISPEC_Out.Item("NIVEL")
        NOMBRET = sdicISPEC_Out.Item("NOMBRET")
        NOMDL = sdicISPEC_Out.Item("NOMDL")
        NOMDV = sdicISPEC_Out.Item("NOMDV")
        NOMHAB = sdicISPEC_Out.Item("NOMHAB")
        NROBIE = sdicISPEC_Out.Item("NROBIE")
        POR_IS = sdicISPEC_Out.Item("POR_IS")
        RUTFUN = sdicISPEC_Out.Item("RUTFUN")
        SIGNO_B = sdicISPEC_Out.Item("SIGNO_B")
        SIGNO_D = sdicISPEC_Out.Item("SIGNO_D")
        SIGNO_DL = sdicISPEC_Out.Item("SIGNO_DL")
        SIGNO_DV = sdicISPEC_Out.Item("SIGNO_DV")
        SIGNO_H = sdicISPEC_Out.Item("SIGNO_H")
        SIGNO_PA = sdicISPEC_Out.Item("SIGNO_PA")
        SIGNO_SB = sdicISPEC_Out.Item("SIGNO_SB")
        SIGNO_SB1 = sdicISPEC_Out.Item("SIGNO_SB1")
        SIGNO_SB2 = sdicISPEC_Out.Item("SIGNO_SB2")
        SIGNO_TH = sdicISPEC_Out.Item("SIGNO_TH")
        SIGNO_VI = sdicISPEC_Out.Item("SIGNO_VI")
        SUEL_BASE = sdicISPEC_Out.Item("SUEL_BASE")
        SUEL_BASE1 = sdicISPEC_Out.Item("SUEL_BASE1")
        SUEL_BASE2 = sdicISPEC_Out.Item("SUEL_BASE2")
        TOT_DESL = sdicISPEC_Out.Item("TOT_DESL")
        TOT_DESV = sdicISPEC_Out.Item("TOT_DESV")
        TOT_HAB = sdicISPEC_Out.Item("TOT_HAB")
        VAL_AFP = sdicISPEC_Out.Item("VAL_AFP")
        VAL_IMPON = sdicISPEC_Out.Item("VAL_IMPON")
        VAL_PAGO = sdicISPEC_Out.Item("VAL_PAGO")

        If sdicISPEC_Out.Item("MENJ35") = "HAY MAS DATOS" And ORQ = "T" Then
          sw = True
        Else
          sw = False
        End If
        y = y + 1
      End While

      __dic = New Dictionary(Of String, String)
      __dic.Add("TIPO", TIPO)
      __dic.Add("DIA_TRABAJ", DIA_TRABAJ)
      __dic.Add("COD_D", COD_D)
      __dic.Add("COD_B", COD_B)
      __dic.Add("COD_H", COD_H)
      __dic.Add("TIPFUN", TIPFUN)
      __dic.Add("RUTFUN", RUTFUN)
      __dic.Add("TIPOLIQ", TIPOLIQ)
      __dic.Add("MES", MES)
      __dic.Add("ANO", ANO)
      __dic.Add("INST", INST)
      __dic.Add("APEMATT", APEMATT)
      __dic.Add("APEPATT", APEPATT)
      __dic.Add("CAT", CAT)
      __dic.Add("CCOSTO", CCOSTO)
      __dic.Add("CODAFP", CODAFP)
      __dic.Add("CODGRADO", CODGRADO)
      __dic.Add("CODISA", CODISA)
      __dic.Add("CODPLANTA", CODPLANTA)
      __dic.Add("COPLAN", COPLAN)
      __dic.Add("FECTERVIG", FECTERVIG)
      __dic.Add("FINGSE", FINGSE)
      __dic.Add("GLO_AFP", GLO_AFP)
      __dic.Add("GLO_IS", GLO_IS)
      __dic.Add("GLO_MES", GLO_MES)
      __dic.Add("GLOCCOSTO", GLOCCOSTO)
      __dic.Add("GLOGRADO", GLOGRADO)
      __dic.Add("GLOPLANTA", GLOPLANTA)
      __dic.Add("HORAS", HORAS)
      __dic.Add("MONPLA", MONPLA)
      __dic.Add("NIVEL", NIVEL)
      __dic.Add("NOMBRET", NOMBRET)
      __dic.Add("NOMDL", NOMDL)
      __dic.Add("NOMDV", NOMDV)
      __dic.Add("NOMHAB", NOMHAB)
      __dic.Add("NROBIE", NROBIE)
      __dic.Add("POR_IS", POR_IS)
      __dic.Add("SIGNO_B", SIGNO_B)
      __dic.Add("SIGNO_D", SIGNO_D)
      __dic.Add("SIGNO_DL", SIGNO_DL)
      __dic.Add("SIGNO_DV", SIGNO_DV)
      __dic.Add("SIGNO_H", SIGNO_H)
      __dic.Add("SIGNO_PA", SIGNO_PA)
      __dic.Add("SIGNO_SB", SIGNO_SB)
      __dic.Add("SIGNO_SB1", SIGNO_SB1)
      __dic.Add("SIGNO_SB2", SIGNO_SB2)
      __dic.Add("SIGNO_TH", SIGNO_TH)
      __dic.Add("SIGNO_VI", SIGNO_VI)
      __dic.Add("SUEL_BASE", SUEL_BASE)
      __dic.Add("SUEL_BASE1", SUEL_BASE1)
      __dic.Add("SUEL_BASE2", SUEL_BASE2)
      __dic.Add("TOT_DESL", TOT_DESL)
      __dic.Add("TOT_DESV", TOT_DESV)
      __dic.Add("TOT_HAB", TOT_HAB)
      __dic.Add("VAL_AFP", VAL_AFP)
      __dic.Add("VAL_IMPON", VAL_IMPON)
      __dic.Add("VAL_PAGO", VAL_PAGO)

      __cf("__PARAMETERS__").Add(__dic)

      __js = New JavaScriptSerializer

      Return __js.Serialize(__cf)

    Catch ex As Exception

      Return ErrorHandler.ErrorAsJson(ex)

    Finally

    End Try

  End Function

  ''' <summary>
  ''' 07/06/2019 jcalderon: Creación
  ''' </summary>
  ''' <param name="ORQ"></param>
  ''' <param name="PRIORIDA_B"></param>
  ''' <param name="CODUSU"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function CTUSM(ByVal ORQ As String,
                        ByVal PRIORIDA_B As String,
                        ByVal CODUSU As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing
    Dim cfSize As Integer = 9

    Try

      Dim y As Integer = 0
      Dim sw As Boolean = True
      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      __cf = New Dictionary(Of String, List(Of Dictionary(Of String, String)))
      __cf.Add("__PARAMETERS__", New List(Of Dictionary(Of String, String)))
      __cf.Add("__COPYFROM__", New List(Of Dictionary(Of String, String)))

      While sw

        sdicISPEC_In = CreateObject("Scripting.Dictionary")
        sdicISPEC_Out = CreateObject("Scripting.Dictionary")
        sdicISPEC_In.Item("PRIORIDA_B") = PRIORIDA_B
        sdicISPEC_In.Item("CODUSU") = CODUSU

        objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "CTUSM", swError, strError)

        If swError <> 0 Then
          Throw New Exception(strError)
        End If

        Dim aux As String = ""

        For i As Integer = 0 To cfSize '

          If Len(i.ToString) = 1 Then
            aux = "0" & i
          Else
            aux = i
          End If

          __dic = New Dictionary(Of String, String)

          If (Not y = 0 And i = 0) Or ((sdicISPEC_Out("PASSMAIL__AT_" & aux) = "" Or sdicISPEC_Out("PASSMAIL__AT_" & aux) = "0") And (sdicISPEC_Out("EMAIL__AT_" & aux) = "" Or sdicISPEC_Out("EMAIL__AT_" & aux) = "0") And (sdicISPEC_Out("PRIORIDAD__AT_" & aux) = "" Or sdicISPEC_Out("PRIORIDAD__AT_" & aux) = "0")) Then
            Continue For
          End If

          __dic.Add("PASSMAIL", sdicISPEC_Out.Item("PASSMAIL__AT_" & aux))
          __dic.Add("EMAIL", sdicISPEC_Out.Item("EMAIL__AT_" & aux))
          __dic.Add("PRIORIDAD", sdicISPEC_Out.Item("PRIORIDAD__AT_" & aux))
          __cf("__COPYFROM__").Add(__dic)
        Next

        PRIORIDA_B = sdicISPEC_Out.Item("PRIORIDA_B")
        CODUSU = sdicISPEC_Out.Item("CODUSU")

        If sdicISPEC_Out.Item("MENJ35") = "HAY MAS DATOS" And ORQ = "T" Then
          sw = True
        Else
          sw = False
        End If
        y = y + 1
      End While

      __dic = New Dictionary(Of String, String)
      __dic.Add("PRIORIDA_B", PRIORIDA_B)
      __dic.Add("CODUSU", CODUSU)
      __cf("__PARAMETERS__").Add(__dic)

      __js = New JavaScriptSerializer

      Return __js.Serialize(__cf)

    Catch ex As Exception

      Return ErrorHandler.ErrorAsJson(ex)

    Finally

    End Try

  End Function

  ''' <summary>
  ''' 11/06/2019 jcalderón:Creación
  ''' </summary>
  ''' <param name="ORQ"></param>
  ''' <param name="INDMAT"></param>
  ''' <param name="NUMSEC"></param>
  ''' <param name="MONTO"></param>
  ''' <param name="FECENV"></param>
  ''' <param name="FECING"></param>
  ''' <param name="NUMLIC"></param>
  ''' <param name="FECLIC"></param>
  ''' <param name="TIPFUN"></param>
  ''' <param name="RUTFUN"></param>
  ''' <param name="VAMENU"></param>
  ''' <param name="MAINT"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function CINLI(ByVal ORQ As String,
                          ByVal INDMAT As String,
                          ByVal NUMSEC As String,
                          ByVal MONTO As String,
                          ByVal FECENV As String,
                          ByVal FECING As String,
                          ByVal NUMLIC As String,
                          ByVal FECLIC As String,
                          ByVal TIPFUN As String,
                          ByVal RUTFUN As String,
                          ByVal VAMENU As String,
                          ByVal MAINT As String) As String

    Dim CODAFP As String = ""
    Dim CODISA As String = ""
    Dim DIASNO1 As String = ""
    Dim DIASNO2 As String = ""
    Dim DIASNO3 As String = ""
    Dim DIASNO4 As String = ""
    Dim DIASNO5 As String = ""
    Dim DIASNO6 As String = ""
    Dim ESTLIB As String = ""
    Dim ESTLIB1 As String = ""
    Dim FECISA As String = ""
    Dim FECREC As String = ""
    Dim FINGSE_FUN As String = ""
    Dim FONDES1 As String = ""
    Dim FONDES2 As String = ""
    Dim FONDES3 As String = ""
    Dim FONDES4 As String = ""
    Dim FONDES5 As String = ""
    Dim FONDES6 As String = ""
    Dim FONPEN1 As String = ""
    Dim FONPEN2 As String = ""
    Dim FONPEN3 As String = ""
    Dim FONPEN4 As String = ""
    Dim FONPEN5 As String = ""
    Dim FONPEN6 As String = ""
    Dim FONREG1 As String = ""
    Dim FONREG2 As String = ""
    Dim FONREG3 As String = ""
    Dim FONREG4 As String = ""
    Dim FONREG5 As String = ""
    Dim FONREG6 As String = ""
    Dim FONSAL1 As String = ""
    Dim FONSAL2 As String = ""
    Dim FONSAL3 As String = ""
    Dim FONSAL4 As String = ""
    Dim FONSAL5 As String = ""
    Dim FONSAL6 As String = ""
    Dim GLOESTADO As String = ""
    Dim GLOMES1 As String = ""
    Dim GLOMES2 As String = ""
    Dim GLOMES3 As String = ""
    Dim GLOMES4 As String = ""
    Dim GLOMES5 As String = ""
    Dim GLOMES6 As String = ""
    Dim GLONOMAFP As String = ""
    Dim GLONOMBRE As String = ""
    Dim GLONOMISA As String = ""
    Dim IMPUNI1 As String = ""
    Dim IMPUNI2 As String = ""
    Dim IMPUNI3 As String = ""
    Dim IMPUNI4 As String = ""
    Dim IMPUNI5 As String = ""
    Dim IMPUNI6 As String = ""
    Dim LEYSOC1 As String = ""
    Dim LEYSOC2 As String = ""
    Dim LEYSOC3 As String = ""
    Dim LEYSOC4 As String = ""
    Dim LEYSOC5 As String = ""
    Dim LEYSOC6 As String = ""
    Dim MONDEV As String = ""
    Dim NDSPAG As String = ""
    Dim NPROC1 As String = ""
    Dim NPROC2 As String = ""
    Dim NPROC3 As String = ""
    Dim NPROC4 As String = ""
    Dim NPROC5 As String = ""
    Dim NPROC6 As String = ""
    Dim NUMDOC As String = ""
    Dim PFONDES1 As String = ""
    Dim PFONDES2 As String = ""
    Dim PFONDES3 As String = ""
    Dim PFONDES4 As String = ""
    Dim PFONDES5 As String = ""
    Dim PFONDES6 As String = ""
    Dim PFONREG1 As String = ""
    Dim PFONREG2 As String = ""
    Dim PFONREG3 As String = ""
    Dim PFONREG4 As String = ""
    Dim PFONREG5 As String = ""
    Dim PFONREG6 As String = ""
    Dim REMNET1 As String = ""
    Dim REMNET2 As String = ""
    Dim REMNET3 As String = ""
    Dim REMNET4 As String = ""
    Dim REMNET5 As String = ""
    Dim REMNET6 As String = ""
    Dim RENIMP1 As String = ""
    Dim RENIMP2 As String = ""
    Dim RENIMP3 As String = ""
    Dim RENIMP4 As String = ""
    Dim RENIMP5 As String = ""
    Dim RENIMP6 As String = ""
    Dim TOTDIA As String = ""


    Dim objLINC_Conexion = Nothing

    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing

    Dim cfSize As Integer = 4

    Try

      Dim y As Integer = 0
      Dim sw As Boolean = True
      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      __cf = New Dictionary(Of String, List(Of Dictionary(Of String, String)))
      __cf.Add("__PARAMETERS__", New List(Of Dictionary(Of String, String)))
      __cf.Add("__COPYFROM__", New List(Of Dictionary(Of String, String)))

      While sw

        sdicISPEC_In = CreateObject("Scripting.Dictionary")
        sdicISPEC_Out = CreateObject("Scripting.Dictionary")
        sdicISPEC_In.Item("INDMAT") = INDMAT
        sdicISPEC_In.Item("NUMSEC") = NUMSEC
        sdicISPEC_In.Item("MONTO") = MONTO
        sdicISPEC_In.Item("FECENV") = FECENV
        sdicISPEC_In.Item("FECING") = FECING
        sdicISPEC_In.Item("NUMLIC") = NUMLIC
        sdicISPEC_In.Item("FECLIC") = FECLIC
        sdicISPEC_In.Item("TIPFUN") = TIPFUN
        sdicISPEC_In.Item("RUTFUN") = RUTFUN
        sdicISPEC_In.Item("VAMENU") = VAMENU
        sdicISPEC_In.Item("MAINT") = MAINT

        objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "CINLI", swError, strError)

        If swError <> 0 Then
          Throw New Exception(strError)
        End If

        Dim aux As String = ""

        For i As Integer = 0 To cfSize '
          If Len(i.ToString) = 1 Then
            aux = "0" & i
          Else
            aux = i
          End If

          __dic = New Dictionary(Of String, String)

          If (Not y = 0 And i = 0) Or ((sdicISPEC_Out("NDSPAG__AT_" & aux) = "" Or sdicISPEC_Out("NDSPAG__AT_" & aux) = "0") And (sdicISPEC_Out("NUMDOC__AT_" & aux) = "" Or sdicISPEC_Out("NUMDOC__AT_" & aux) = "0") And (sdicISPEC_Out("MONDEV__AT_" & aux) = "" Or sdicISPEC_Out("MONDEV__AT_" & aux) = "0") And (sdicISPEC_Out("FECREC__AT_" & aux) = "" Or sdicISPEC_Out("FECREC__AT_" & aux) = "0")) Then
            Continue For
          End If

          __dic.Add("NDSPAG", sdicISPEC_Out.Item("NDSPAG__AT_" & aux))
          __dic.Add("NUMDOC", sdicISPEC_Out.Item("NUMDOC__AT_" & aux))
          __dic.Add("MONDEV", sdicISPEC_Out.Item("MONDEV__AT_" & aux))
          __dic.Add("FECREC", sdicISPEC_Out.Item("FECREC__AT_" & aux))
          __cf("__COPYFROM__").Add(__dic)
        Next

        INDMAT = sdicISPEC_Out.Item("INDMAT")
        NUMSEC = sdicISPEC_Out.Item("NUMSEC")
        MONTO = sdicISPEC_Out.Item("MONTO")
        FECENV = sdicISPEC_Out.Item("FECENV")
        FECING = sdicISPEC_Out.Item("FECING")
        NUMLIC = sdicISPEC_Out.Item("NUMLIC")
        FECLIC = sdicISPEC_Out.Item("FECLIC")
        TIPFUN = sdicISPEC_Out.Item("TIPFUN")
        RUTFUN = sdicISPEC_Out.Item("RUTFUN")
        VAMENU = sdicISPEC_Out.Item("VAMENU")
        MAINT = sdicISPEC_Out.Item("MAINT")
        CODAFP = sdicISPEC_Out.Item("CODAFP")
        CODISA = sdicISPEC_Out.Item("CODISA")
        DIASNO1 = sdicISPEC_Out.Item("DIASNO1")
        DIASNO2 = sdicISPEC_Out.Item("DIASNO2")
        DIASNO3 = sdicISPEC_Out.Item("DIASNO3")
        DIASNO4 = sdicISPEC_Out.Item("DIASNO4")
        DIASNO5 = sdicISPEC_Out.Item("DIASNO5")
        DIASNO6 = sdicISPEC_Out.Item("DIASNO6")
        ESTLIB = sdicISPEC_Out.Item("ESTLIB")
        ESTLIB1 = sdicISPEC_Out.Item("ESTLIB1")
        FECISA = sdicISPEC_Out.Item("FECISA")
        FECREC = sdicISPEC_Out.Item("FECREC")
        FINGSE_FUN = sdicISPEC_Out.Item("FINGSE_FUN")
        FONDES1 = sdicISPEC_Out.Item("FONDES1")
        FONDES2 = sdicISPEC_Out.Item("FONDES2")
        FONDES3 = sdicISPEC_Out.Item("FONDES3")
        FONDES4 = sdicISPEC_Out.Item("FONDES4")
        FONDES5 = sdicISPEC_Out.Item("FONDES5")
        FONDES6 = sdicISPEC_Out.Item("FONDES6")
        FONPEN1 = sdicISPEC_Out.Item("FONPEN1")
        FONPEN2 = sdicISPEC_Out.Item("FONPEN2")
        FONPEN3 = sdicISPEC_Out.Item("FONPEN3")
        FONPEN4 = sdicISPEC_Out.Item("FONPEN4")
        FONPEN5 = sdicISPEC_Out.Item("FONPEN5")
        FONPEN6 = sdicISPEC_Out.Item("FONPEN6")
        FONREG1 = sdicISPEC_Out.Item("FONREG1")
        FONREG2 = sdicISPEC_Out.Item("FONREG2")
        FONREG3 = sdicISPEC_Out.Item("FONREG3")
        FONREG4 = sdicISPEC_Out.Item("FONREG4")
        FONREG5 = sdicISPEC_Out.Item("FONREG5")
        FONREG6 = sdicISPEC_Out.Item("FONREG6")
        FONSAL1 = sdicISPEC_Out.Item("FONSAL1")
        FONSAL2 = sdicISPEC_Out.Item("FONSAL2")
        FONSAL3 = sdicISPEC_Out.Item("FONSAL3")
        FONSAL4 = sdicISPEC_Out.Item("FONSAL4")
        FONSAL5 = sdicISPEC_Out.Item("FONSAL5")
        FONSAL6 = sdicISPEC_Out.Item("FONSAL6")
        GLOESTADO = sdicISPEC_Out.Item("GLOESTADO")
        GLOMES1 = sdicISPEC_Out.Item("GLOMES1")
        GLOMES2 = sdicISPEC_Out.Item("GLOMES2")
        GLOMES3 = sdicISPEC_Out.Item("GLOMES3")
        GLOMES4 = sdicISPEC_Out.Item("GLOMES4")
        GLOMES5 = sdicISPEC_Out.Item("GLOMES5")
        GLOMES6 = sdicISPEC_Out.Item("GLOMES6")
        GLONOMAFP = sdicISPEC_Out.Item("GLONOMAFP")
        GLONOMBRE = sdicISPEC_Out.Item("GLONOMBRE")
        GLONOMISA = sdicISPEC_Out.Item("GLONOMISA")
        IMPUNI1 = sdicISPEC_Out.Item("IMPUNI1")
        IMPUNI2 = sdicISPEC_Out.Item("IMPUNI2")
        IMPUNI3 = sdicISPEC_Out.Item("IMPUNI3")
        IMPUNI4 = sdicISPEC_Out.Item("IMPUNI4")
        IMPUNI5 = sdicISPEC_Out.Item("IMPUNI5")
        IMPUNI6 = sdicISPEC_Out.Item("IMPUNI6")
        LEYSOC1 = sdicISPEC_Out.Item("LEYSOC1")
        LEYSOC2 = sdicISPEC_Out.Item("LEYSOC2")
        LEYSOC3 = sdicISPEC_Out.Item("LEYSOC3")
        LEYSOC4 = sdicISPEC_Out.Item("LEYSOC4")
        LEYSOC5 = sdicISPEC_Out.Item("LEYSOC5")
        LEYSOC6 = sdicISPEC_Out.Item("LEYSOC6")
        MONDEV = sdicISPEC_Out.Item("MONDEV")
        NDSPAG = sdicISPEC_Out.Item("NDSPAG")
        NPROC1 = sdicISPEC_Out.Item("NPROC1")
        NPROC2 = sdicISPEC_Out.Item("NPROC2")
        NPROC3 = sdicISPEC_Out.Item("NPROC3")
        NPROC4 = sdicISPEC_Out.Item("NPROC4")
        NPROC5 = sdicISPEC_Out.Item("NPROC5")
        NPROC6 = sdicISPEC_Out.Item("NPROC6")
        NUMDOC = sdicISPEC_Out.Item("NUMDOC")
        PFONDES1 = sdicISPEC_Out.Item("PFONDES1")
        PFONDES2 = sdicISPEC_Out.Item("PFONDES2")
        PFONDES3 = sdicISPEC_Out.Item("PFONDES3")
        PFONDES4 = sdicISPEC_Out.Item("PFONDES4")
        PFONDES5 = sdicISPEC_Out.Item("PFONDES5")
        PFONDES6 = sdicISPEC_Out.Item("PFONDES6")
        PFONREG1 = sdicISPEC_Out.Item("PFONREG1")
        PFONREG2 = sdicISPEC_Out.Item("PFONREG2")
        PFONREG3 = sdicISPEC_Out.Item("PFONREG3")
        PFONREG4 = sdicISPEC_Out.Item("PFONREG4")
        PFONREG5 = sdicISPEC_Out.Item("PFONREG5")
        PFONREG6 = sdicISPEC_Out.Item("PFONREG6")
        REMNET1 = sdicISPEC_Out.Item("REMNET1")
        REMNET2 = sdicISPEC_Out.Item("REMNET2")
        REMNET3 = sdicISPEC_Out.Item("REMNET3")
        REMNET4 = sdicISPEC_Out.Item("REMNET4")
        REMNET5 = sdicISPEC_Out.Item("REMNET5")
        REMNET6 = sdicISPEC_Out.Item("REMNET6")
        RENIMP1 = sdicISPEC_Out.Item("RENIMP1")
        RENIMP2 = sdicISPEC_Out.Item("RENIMP2")
        RENIMP3 = sdicISPEC_Out.Item("RENIMP3")
        RENIMP4 = sdicISPEC_Out.Item("RENIMP4")
        RENIMP5 = sdicISPEC_Out.Item("RENIMP5")
        RENIMP6 = sdicISPEC_Out.Item("RENIMP6")
        TOTDIA = sdicISPEC_Out.Item("TOTDIA")


        If sdicISPEC_Out.Item("MENJ35") = "HAY MAS DATOS" And ORQ = "T" Then
          sw = True
        Else
          sw = False
        End If
        y = y + 1
      End While

      __dic = New Dictionary(Of String, String)
      __dic.Add("INDMAT", INDMAT)
      __dic.Add("NUMSEC", NUMSEC)
      __dic.Add("MONTO", MONTO)
      __dic.Add("FECENV", FECENV)
      __dic.Add("FECING", FECING)
      __dic.Add("NUMLIC", NUMLIC)
      __dic.Add("FECLIC", FECLIC)
      __dic.Add("TIPFUN", TIPFUN)
      __dic.Add("RUTFUN", RUTFUN)
      __dic.Add("VAMENU", VAMENU)
      __dic.Add("MAINT", MAINT)
      __dic.Add("CODAFP", CODAFP)
      __dic.Add("CODISA", CODISA)
      __dic.Add("DIASNO1", DIASNO1)
      __dic.Add("DIASNO2", DIASNO2)
      __dic.Add("DIASNO3", DIASNO3)
      __dic.Add("DIASNO4", DIASNO4)
      __dic.Add("DIASNO5", DIASNO5)
      __dic.Add("DIASNO6", DIASNO6)
      __dic.Add("ESTLIB", ESTLIB)
      __dic.Add("ESTLIB1", ESTLIB1)
      __dic.Add("FECISA", FECISA)
      __dic.Add("FECREC", FECREC)
      __dic.Add("FINGSE_FUN", FINGSE_FUN)
      __dic.Add("FONDES1", FONDES1)
      __dic.Add("FONDES2", FONDES2)
      __dic.Add("FONDES3", FONDES3)
      __dic.Add("FONDES4", FONDES4)
      __dic.Add("FONDES5", FONDES5)
      __dic.Add("FONDES6", FONDES6)
      __dic.Add("FONPEN1", FONPEN1)
      __dic.Add("FONPEN2", FONPEN2)
      __dic.Add("FONPEN3", FONPEN3)
      __dic.Add("FONPEN4", FONPEN4)
      __dic.Add("FONPEN5", FONPEN5)
      __dic.Add("FONPEN6", FONPEN6)
      __dic.Add("FONREG1", FONREG1)
      __dic.Add("FONREG2", FONREG2)
      __dic.Add("FONREG3", FONREG3)
      __dic.Add("FONREG4", FONREG4)
      __dic.Add("FONREG5", FONREG5)
      __dic.Add("FONREG6", FONREG6)
      __dic.Add("FONSAL1", FONSAL1)
      __dic.Add("FONSAL2", FONSAL2)
      __dic.Add("FONSAL3", FONSAL3)
      __dic.Add("FONSAL4", FONSAL4)
      __dic.Add("FONSAL5", FONSAL5)
      __dic.Add("FONSAL6", FONSAL6)
      __dic.Add("GLOESTADO", GLOESTADO)
      __dic.Add("GLOMES1", GLOMES1)
      __dic.Add("GLOMES2", GLOMES2)
      __dic.Add("GLOMES3", GLOMES3)
      __dic.Add("GLOMES4", GLOMES4)
      __dic.Add("GLOMES5", GLOMES5)
      __dic.Add("GLOMES6", GLOMES6)
      __dic.Add("GLONOMAFP", GLONOMAFP)
      __dic.Add("GLONOMBRE", GLONOMBRE)
      __dic.Add("GLONOMISA", GLONOMISA)
      __dic.Add("IMPUNI1", IMPUNI1)
      __dic.Add("IMPUNI2", IMPUNI2)
      __dic.Add("IMPUNI3", IMPUNI3)
      __dic.Add("IMPUNI4", IMPUNI4)
      __dic.Add("IMPUNI5", IMPUNI5)
      __dic.Add("IMPUNI6", IMPUNI6)
      __dic.Add("LEYSOC1", LEYSOC1)
      __dic.Add("LEYSOC2", LEYSOC2)
      __dic.Add("LEYSOC3", LEYSOC3)
      __dic.Add("LEYSOC4", LEYSOC4)
      __dic.Add("LEYSOC5", LEYSOC5)
      __dic.Add("LEYSOC6", LEYSOC6)
      __dic.Add("MONDEV", MONDEV)
      __dic.Add("NDSPAG", NDSPAG)
      __dic.Add("NPROC1", NPROC1)
      __dic.Add("NPROC2", NPROC2)
      __dic.Add("NPROC3", NPROC3)
      __dic.Add("NPROC4", NPROC4)
      __dic.Add("NPROC5", NPROC5)
      __dic.Add("NPROC6", NPROC6)
      __dic.Add("NUMDOC", NUMDOC)
      __dic.Add("PFONDES1", PFONDES1)
      __dic.Add("PFONDES2", PFONDES2)
      __dic.Add("PFONDES3", PFONDES3)
      __dic.Add("PFONDES4", PFONDES4)
      __dic.Add("PFONDES5", PFONDES5)
      __dic.Add("PFONDES6", PFONDES6)
      __dic.Add("PFONREG1", PFONREG1)
      __dic.Add("PFONREG2", PFONREG2)
      __dic.Add("PFONREG3", PFONREG3)
      __dic.Add("PFONREG4", PFONREG4)
      __dic.Add("PFONREG5", PFONREG5)
      __dic.Add("PFONREG6", PFONREG6)
      __dic.Add("REMNET1", REMNET1)
      __dic.Add("REMNET2", REMNET2)
      __dic.Add("REMNET3", REMNET3)
      __dic.Add("REMNET4", REMNET4)
      __dic.Add("REMNET5", REMNET5)
      __dic.Add("REMNET6", REMNET6)
      __dic.Add("RENIMP1", RENIMP1)
      __dic.Add("RENIMP2", RENIMP2)
      __dic.Add("RENIMP3", RENIMP3)
      __dic.Add("RENIMP4", RENIMP4)
      __dic.Add("RENIMP5", RENIMP5)
      __dic.Add("RENIMP6", RENIMP6)
      __dic.Add("TOTDIA", TOTDIA)

      __cf("__PARAMETERS__").Add(__dic)

      __js = New JavaScriptSerializer

      Return __js.Serialize(__cf)

    Catch ex As Exception

      Return ErrorHandler.ErrorAsJson(ex)

    Finally

    End Try

  End Function

  ''' <summary>
  ''' 13/06/2019 jcalderon:creacion
  ''' </summary>
  ''' <param name="ORQ"></param>
  ''' <param name="TIPO"></param>
  ''' <param name="NUMBAS"></param>
  ''' <param name="TIPBAS"></param>
  ''' <param name="TIPFUN"></param>
  ''' <param name="RUTFUN"></param>
  ''' <param name="PROCESO"></param>
  ''' <param name="MES"></param>
  ''' <param name="ANO"></param>
  ''' <param name="INST"></param>
  ''' <param name="VAMENU"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function ICOL2(ByVal ORQ As String,
                                             ByVal TIPO As String,
                                             ByVal NUMBAS As String,
                                             ByVal TIPBAS As String,
                                             ByVal TIPFUN As String,
                                             ByVal RUTFUN As String,
                                             ByVal PROCESO As String,
                                             ByVal MES As String,
                                             ByVal ANO As String,
                                             ByVal INST As String,
                                             ByVal VAMENU As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing
    Dim cfSize As Integer = 19

    Try

      Dim y As Integer = 0
      Dim sw As Boolean = True
      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      __cf = New Dictionary(Of String, List(Of Dictionary(Of String, String)))
      __cf.Add("__PARAMETERS__", New List(Of Dictionary(Of String, String)))
      __cf.Add("__COPYFROM__", New List(Of Dictionary(Of String, String)))

      While sw

        sdicISPEC_In = CreateObject("Scripting.Dictionary")
        sdicISPEC_Out = CreateObject("Scripting.Dictionary")
        sdicISPEC_In.Item("TIPO") = TIPO
        sdicISPEC_In.Item("NUMBAS") = NUMBAS
        sdicISPEC_In.Item("TIPBAS") = TIPBAS
        sdicISPEC_In.Item("TIPFUN") = TIPFUN
        sdicISPEC_In.Item("RUTFUN") = RUTFUN
        sdicISPEC_In.Item("PROCESO") = PROCESO
        sdicISPEC_In.Item("MES") = MES
        sdicISPEC_In.Item("ANO") = ANO
        sdicISPEC_In.Item("INST") = INST
        sdicISPEC_In.Item("VAMENU") = VAMENU

        objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "ICOL2", swError, strError)

        If swError <> 0 Then
          Throw New Exception(strError)
        End If

        Dim aux As String = ""

        For i As Integer = 0 To cfSize '
          If Len(i.ToString) = 1 Then
            aux = "0" & i
          Else
            aux = i
          End If

          __dic = New Dictionary(Of String, String)

          If (Not y = 0 And i = 0) Or ((sdicISPEC_Out("NROCTA__AT_" & aux) = "" Or sdicISPEC_Out("NROCTA__AT_" & aux) = "0") And (sdicISPEC_Out("CUOTA__AT_" & aux) = "" Or sdicISPEC_Out("CUOTA__AT_" & aux) = "0") And (sdicISPEC_Out("IND4__AT_" & aux) = "" Or sdicISPEC_Out("IND4__AT_" & aux) = "0") And (sdicISPEC_Out("MOV_TIPO__AT_" & aux) = "" Or sdicISPEC_Out("MOV_TIPO__AT_" & aux) = "0") And (sdicISPEC_Out("CAN2__AT_" & aux) = "" Or sdicISPEC_Out("CAN2__AT_" & aux) = "0") And (sdicISPEC_Out("VALORC__AT_" & aux) = "" Or sdicISPEC_Out("VALORC__AT_" & aux) = "0") And (sdicISPEC_Out("SIGNO__AT_" & aux) = "" Or sdicISPEC_Out("SIGNO__AT_" & aux) = "0") And (sdicISPEC_Out("GLOCOD__AT_" & aux) = "" Or sdicISPEC_Out("GLOCOD__AT_" & aux) = "0") And (sdicISPEC_Out("NUMCOD__AT_" & aux) = "" Or sdicISPEC_Out("NUMCOD__AT_" & aux) = "0") And (sdicISPEC_Out("LETCOD__AT_" & aux) = "" Or sdicISPEC_Out("LETCOD__AT_" & aux) = "0")) Then
            Continue For
          End If

          __dic.Add("NROCTA", sdicISPEC_Out.Item("NROCTA__AT_" & aux))
          __dic.Add("CUOTA", sdicISPEC_Out.Item("CUOTA__AT_" & aux))
          __dic.Add("IND4", sdicISPEC_Out.Item("IND4__AT_" & aux))
          __dic.Add("MOV_TIPO", sdicISPEC_Out.Item("MOV_TIPO__AT_" & aux))
          __dic.Add("CAN2", sdicISPEC_Out.Item("CAN2__AT_" & aux))
          __dic.Add("VALORC", sdicISPEC_Out.Item("VALORC__AT_" & aux))
          __dic.Add("SIGNO", sdicISPEC_Out.Item("SIGNO__AT_" & aux))
          __dic.Add("GLOCOD", sdicISPEC_Out.Item("GLOCOD__AT_" & aux))
          __dic.Add("NUMCOD", sdicISPEC_Out.Item("NUMCOD__AT_" & aux))
          __dic.Add("LETCOD", sdicISPEC_Out.Item("LETCOD__AT_" & aux))
          __cf("__COPYFROM__").Add(__dic)
        Next

        TIPO = sdicISPEC_Out.Item("TIPO")
        NUMBAS = sdicISPEC_Out.Item("NUMBAS")
        TIPBAS = sdicISPEC_Out.Item("TIPBAS")
        TIPFUN = sdicISPEC_Out.Item("TIPFUN")
        RUTFUN = sdicISPEC_Out.Item("RUTFUN")
        PROCESO = sdicISPEC_Out.Item("PROCESO")
        MES = sdicISPEC_Out.Item("MES")
        ANO = sdicISPEC_Out.Item("ANO")
        INST = sdicISPEC_Out.Item("INST")
        VAMENU = sdicISPEC_Out.Item("VAMENU")
        If sdicISPEC_Out.Item("MENJ35") = "HAY MAS DATOS" And ORQ = "T" Then
          sw = True
        Else
          sw = False
        End If
        y = y + 1
      End While

      __dic = New Dictionary(Of String, String)
      __dic.Add("TIPO", TIPO)
      __dic.Add("NUMBAS", NUMBAS)
      __dic.Add("TIPBAS", TIPBAS)
      __dic.Add("TIPFUN", TIPFUN)
      __dic.Add("RUTFUN", RUTFUN)
      __dic.Add("PROCESO", PROCESO)
      __dic.Add("MES", MES)
      __dic.Add("ANO", ANO)
      __dic.Add("INST", INST)
      __dic.Add("VAMENU", VAMENU)

      __cf("__PARAMETERS__").Add(__dic)

      __js = New JavaScriptSerializer

      Return __js.Serialize(__cf)

    Catch ex As Exception

      Return ErrorHandler.ErrorAsJson(ex)

    Finally

    End Try

  End Function

  ''' <summary>
  ''' 13/06/2019 jcalderon:Creacion
  ''' </summary>
  ''' <param name="ORQ"></param>
  ''' <param name="TIPO"></param>
  ''' <param name="NUMBAS"></param>
  ''' <param name="TIPBAS"></param>
  ''' <param name="TIPFUN"></param>
  ''' <param name="RUTFUN"></param>
  ''' <param name="PROCESO"></param>
  ''' <param name="MES"></param>
  ''' <param name="ANO"></param>
  ''' <param name="INST"></param>
  ''' <param name="VAMENU"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function ICOL4(ByVal ORQ As String,
                                                ByVal TIPO As String,
                                                ByVal NUMBAS As String,
                                                ByVal TIPBAS As String,
                                                ByVal TIPFUN As String,
                                                ByVal RUTFUN As String,
                                                ByVal PROCESO As String,
                                                ByVal MES As String,
                                                ByVal ANO As String,
                                                ByVal INST As String,
                                                ByVal VAMENU As String) As String

    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing
    Dim cfSize As Integer = 19

    Try

      Dim y As Integer = 0
      Dim sw As Boolean = True
      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      __cf = New Dictionary(Of String, List(Of Dictionary(Of String, String)))
      __cf.Add("__PARAMETERS__", New List(Of Dictionary(Of String, String)))
      __cf.Add("__COPYFROM__", New List(Of Dictionary(Of String, String)))

      While sw

        sdicISPEC_In = CreateObject("Scripting.Dictionary")
        sdicISPEC_Out = CreateObject("Scripting.Dictionary")
        sdicISPEC_In.Item("TIPO") = TIPO
        sdicISPEC_In.Item("NUMBAS") = NUMBAS
        sdicISPEC_In.Item("TIPBAS") = TIPBAS
        sdicISPEC_In.Item("TIPFUN") = TIPFUN
        sdicISPEC_In.Item("RUTFUN") = RUTFUN
        sdicISPEC_In.Item("PROCESO") = PROCESO
        sdicISPEC_In.Item("MES") = MES
        sdicISPEC_In.Item("ANO") = ANO
        sdicISPEC_In.Item("INST") = INST
        sdicISPEC_In.Item("VAMENU") = VAMENU

        objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "ICOL4", swError, strError)

        If swError <> 0 Then
          Throw New Exception(strError)
        End If
        Dim aux As String = ""
        For i As Integer = 0 To cfSize '
          If Len(i.ToString) = 1 Then
            aux = "0" & i
          Else
            aux = i
          End If

          __dic = New Dictionary(Of String, String)

          If (Not y = 0 And i = 0) Or ((sdicISPEC_Out("IMP__AT_" & aux) = "" Or sdicISPEC_Out("IMP__AT_" & aux) = "0") And (sdicISPEC_Out("NROCTA__AT_" & aux) = "" Or sdicISPEC_Out("NROCTA__AT_" & aux) = "0") And (sdicISPEC_Out("CUOTA__AT_" & aux) = "" Or sdicISPEC_Out("CUOTA__AT_" & aux) = "0") And (sdicISPEC_Out("IND4__AT_" & aux) = "" Or sdicISPEC_Out("IND4__AT_" & aux) = "0") And (sdicISPEC_Out("MOV_TIPO__AT_" & aux) = "" Or sdicISPEC_Out("MOV_TIPO__AT_" & aux) = "0") And (sdicISPEC_Out("CAN2__AT_" & aux) = "" Or sdicISPEC_Out("CAN2__AT_" & aux) = "0") And (sdicISPEC_Out("VALORC__AT_" & aux) = "" Or sdicISPEC_Out("VALORC__AT_" & aux) = "0") And (sdicISPEC_Out("SIGNO__AT_" & aux) = "" Or sdicISPEC_Out("SIGNO__AT_" & aux) = "0") And (sdicISPEC_Out("GLOCOD__AT_" & aux) = "" Or sdicISPEC_Out("GLOCOD__AT_" & aux) = "0") And (sdicISPEC_Out("NUMCOD__AT_" & aux) = "" Or sdicISPEC_Out("NUMCOD__AT_" & aux) = "0") And (sdicISPEC_Out("LETCOD__AT_" & aux) = "" Or sdicISPEC_Out("LETCOD__AT_" & aux) = "0")) Then
            Continue For
          End If

          __dic.Add("IMP", sdicISPEC_Out.Item("IMP__AT_" & aux))
          __dic.Add("NROCTA", sdicISPEC_Out.Item("NROCTA__AT_" & aux))
          __dic.Add("CUOTA", sdicISPEC_Out.Item("CUOTA__AT_" & aux))
          __dic.Add("IND4", sdicISPEC_Out.Item("IND4__AT_" & aux))
          __dic.Add("MOV_TIPO", sdicISPEC_Out.Item("MOV_TIPO__AT_" & aux))
          __dic.Add("CAN2", sdicISPEC_Out.Item("CAN2__AT_" & aux))
          __dic.Add("VALORC", sdicISPEC_Out.Item("VALORC__AT_" & aux))
          __dic.Add("SIGNO", sdicISPEC_Out.Item("SIGNO__AT_" & aux))
          __dic.Add("GLOCOD", sdicISPEC_Out.Item("GLOCOD__AT_" & aux))
          __dic.Add("NUMCOD", sdicISPEC_Out.Item("NUMCOD__AT_" & aux))
          __dic.Add("LETCOD", sdicISPEC_Out.Item("LETCOD__AT_" & aux))
          __cf("__COPYFROM__").Add(__dic)
        Next

        TIPO = sdicISPEC_Out.Item("TIPO")
        NUMBAS = sdicISPEC_Out.Item("NUMBAS")
        TIPBAS = sdicISPEC_Out.Item("TIPBAS")
        TIPFUN = sdicISPEC_Out.Item("TIPFUN")
        RUTFUN = sdicISPEC_Out.Item("RUTFUN")
        PROCESO = sdicISPEC_Out.Item("PROCESO")
        MES = sdicISPEC_Out.Item("MES")
        ANO = sdicISPEC_Out.Item("ANO")
        INST = sdicISPEC_Out.Item("INST")
        VAMENU = sdicISPEC_Out.Item("VAMENU")

        If sdicISPEC_Out.Item("MENJ35") = "HAY MAS DATOS" And ORQ = "T" Then
          sw = True
        Else
          sw = False
        End If
        y = y + 1
      End While

      __dic = New Dictionary(Of String, String)
      __dic.Add("TIPO", TIPO)
      __dic.Add("NUMBAS", NUMBAS)
      __dic.Add("TIPBAS", TIPBAS)
      __dic.Add("TIPFUN", TIPFUN)
      __dic.Add("RUTFUN", RUTFUN)
      __dic.Add("PROCESO", PROCESO)
      __dic.Add("MES", MES)
      __dic.Add("ANO", ANO)
      __dic.Add("INST", INST)
      __dic.Add("VAMENU", VAMENU)

      __cf("__PARAMETERS__").Add(__dic)

      __js = New JavaScriptSerializer

      Return __js.Serialize(__cf)

    Catch ex As Exception

      Return ErrorHandler.ErrorAsJson(ex)

    Finally

    End Try

  End Function

  ''' <summary>
  ''' 18/06/2018 jcalderon:Creacion
  ''' </summary>
  ''' <param name="ORQ"></param>
  ''' <param name="CARGOJEFE"></param>
  ''' <param name="NUMCERT"></param>
  ''' <param name="NOMBREJEF"></param>
  ''' <param name="CARGOFUN"></param>
  ''' <param name="MESREM"></param>
  ''' <param name="ANOREM"></param>
  ''' <param name="SEXO"></param>
  ''' <param name="APEMATFUN"></param>
  ''' <param name="APEPATFUN"></param>
  ''' <param name="NOMBREFUN"></param>
  ''' <param name="ANO_C"></param>
  ''' <param name="SECMOV_C"></param>
  ''' <param name="SECUN_C"></param>
  ''' <param name="RUTFUN_C"></param>
  ''' <param name="TIPOCER_C"></param>
  ''' <param name="MANT"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <WebMethod()> _
  Public Function ICERW(ByVal ORQ As String,
                                                ByVal CARGOJEFE As String,
                                                ByVal NUMCERT As String,
                                                ByVal NOMBREJEF As String,
                                                ByVal CARGOFUN As String,
                                                ByVal MESREM As String,
                                                ByVal ANOREM As String,
                                                ByVal SEXO As String,
                                                ByVal APEMATFUN As String,
                                                ByVal APEPATFUN As String,
                                                ByVal NOMBREFUN As String,
                                                ByVal ANO_C As String,
                                                ByVal SECMOV_C As String,
                                                ByVal SECUN_C As String,
                                                ByVal RUTFUN_C As String,
                                                ByVal TIPOCER_C As String,
                                                ByVal MANT As String,
                                                ByVal VARIOS_P As String,
                                                ByVal CODAREA_P As String,
                                                ByVal ESTA_P As String,
                                                ByVal TCONTRA_P As String,
                                                ByVal TIPOCON_P As String,
                                                ByVal TIPPAGO_P As String,
                                                ByVal CCOSTO_P As String,
                                                ByVal FTERCON_P As String,
                                                ByVal FINICON_P As String,
                                                ByVal SEC_MOV_P As String,
                                                ByVal SEC_CON_P As String,
                                                ByVal GCCOSTO_P As String,
                                                ByVal TIPOFUN_P As String,
                                                ByVal FINGCORP As String,
                                                ByVal FINGSER As String,
                                                ByVal NUMBIE As String,
                                                ByVal VARIOS As String,
                                                ByVal CENTROCOST As String,
                                                ByVal TIPOFUN As String,
                                                ByVal TIPO_PAGO As String,
                                                ByVal TCONTRA As String,
                                                ByVal ESTA As String,
                                                ByVal TIPOCON As String,
                                                ByVal FECTERCON As String,
                                                ByVal FECINICON As String) As String


    Dim objLINC_Conexion = Nothing
    Dim sdicISPEC_In = Nothing
    Dim sdicISPEC_Out = Nothing

    Dim cfSize As Integer = 3

    Try
      Dim y As Integer = 0
      Dim sw As Boolean = True
      Dim swError As String = ""
      Dim strError As String = ""

      objLINC_Conexion = CreateObject(__activex)

      __cf = New Dictionary(Of String, List(Of Dictionary(Of String, String)))
      __cf.Add("__PARAMETERS__", New List(Of Dictionary(Of String, String)))
      __cf.Add("__COPYFROM__", New List(Of Dictionary(Of String, String)))

      While sw
        sdicISPEC_In = CreateObject("Scripting.Dictionary")
        sdicISPEC_Out = CreateObject("Scripting.Dictionary")
        sdicISPEC_In.Item("CARGOJEFE") = CARGOJEFE
        sdicISPEC_In.Item("NUMCERT") = NUMCERT
        sdicISPEC_In.Item("NOMBREJEF") = NOMBREJEF
        sdicISPEC_In.Item("CARGOFUN") = CARGOFUN
        sdicISPEC_In.Item("MESREM") = MESREM
        sdicISPEC_In.Item("ANOREM") = ANOREM
        sdicISPEC_In.Item("SEXO") = SEXO
        sdicISPEC_In.Item("APEMATFUN") = APEMATFUN
        sdicISPEC_In.Item("APEPATFUN") = APEPATFUN
        sdicISPEC_In.Item("NOMBREFUN") = NOMBREFUN
        sdicISPEC_In.Item("ANO_C") = ANO_C
        sdicISPEC_In.Item("SECMOV_C") = SECMOV_C
        sdicISPEC_In.Item("SECUN_C") = SECUN_C
        sdicISPEC_In.Item("RUTFUN_C") = RUTFUN_C
        sdicISPEC_In.Item("TIPOCER_C") = TIPOCER_C
        sdicISPEC_In.Item("MANT") = MANT
        sdicISPEC_In.Item("VARIOS_P") = VARIOS_P
        sdicISPEC_In.Item("CODAREA_P") = CODAREA_P
        sdicISPEC_In.Item("ESTA_P") = ESTA_P
        sdicISPEC_In.Item("TCONTRA_P") = TCONTRA_P
        sdicISPEC_In.Item("TIPOCON_P") = TIPOCON_P
        sdicISPEC_In.Item("TIPPAGO_P") = TIPPAGO_P
        sdicISPEC_In.Item("CCOSTO_P") = CCOSTO_P
        sdicISPEC_In.Item("FTERCON_P") = FTERCON_P
        sdicISPEC_In.Item("FINICON_P") = FINICON_P
        sdicISPEC_In.Item("SEC_MOV_P") = SEC_MOV_P
        sdicISPEC_In.Item("SEC_CON_P") = SEC_CON_P
        sdicISPEC_In.Item("GCCOSTO_P") = GCCOSTO_P
        sdicISPEC_In.Item("TIPOFUN_P") = TIPOFUN_P
        sdicISPEC_In.Item("FINGCORP") = FINGCORP
        sdicISPEC_In.Item("FINGSER") = FINGSER
        sdicISPEC_In.Item("NUMBIE") = NUMBIE
        sdicISPEC_In.Item("VARIOS") = VARIOS
        sdicISPEC_In.Item("CENTROCOST") = CENTROCOST
        sdicISPEC_In.Item("TIPOFUN") = TIPOFUN
        sdicISPEC_In.Item("TIPO_PAGO") = TIPO_PAGO
        sdicISPEC_In.Item("TCONTRA") = TCONTRA
        sdicISPEC_In.Item("ESTA") = ESTA
        sdicISPEC_In.Item("TIPOCON") = TIPOCON
        sdicISPEC_In.Item("FECTERCON") = FECTERCON
        sdicISPEC_In.Item("FECINICON") = FECINICON

        objLINC_Conexion.Transmitir(sdicISPEC_In, sdicISPEC_Out, "ICERW", swError, strError)

        If swError <> 0 Then
          Throw New Exception(strError)
        End If

        Dim aux As String = ""

        For i As Integer = 0 To cfSize '
          If Len(i.ToString) = 1 Then
            aux = "0" & i
          Else
            aux = i
          End If
          __dic = New Dictionary(Of String, String)

          If (Not y = 0 And i = 0) Or ((sdicISPEC_Out("VARIOS__AT_" & aux) = "" Or sdicISPEC_Out("VARIOS__AT_" & aux) = "0") And (sdicISPEC_Out("CENTROCOST__AT_" & aux) = "" Or sdicISPEC_Out("CENTROCOST__AT_" & aux) = "0") And (sdicISPEC_Out("TIPOFUN__AT_" & aux) = "" Or sdicISPEC_Out("TIPOFUN__AT_" & aux) = "0") And (sdicISPEC_Out("TIPO_PAGO__AT_" & aux) = "" Or sdicISPEC_Out("TIPO_PAGO__AT_" & aux) = "0") And (sdicISPEC_Out("TCONTRA__AT_" & aux) = "" Or sdicISPEC_Out("TCONTRA__AT_" & aux) = "0") And (sdicISPEC_Out("ESTA__AT_" & aux) = "" Or sdicISPEC_Out("ESTA__AT_" & aux) = "0") And (sdicISPEC_Out("TIPOCON__AT_" & aux) = "" Or sdicISPEC_Out("TIPOCON__AT_" & aux) = "0") And (sdicISPEC_Out("FECTERCON__AT_" & aux) = "" Or sdicISPEC_Out("FECTERCON__AT_" & aux) = "0") And (sdicISPEC_Out("FECINICON__AT_" & aux) = "" Or sdicISPEC_Out("FECINICON__AT_" & aux) = "0")) Then
            Continue For
          End If

          __dic.Add("VARIOS", sdicISPEC_Out.Item("VARIOS__AT_" & aux))
          __dic.Add("CENTROCOST", sdicISPEC_Out.Item("CENTROCOST__AT_" & aux))
          __dic.Add("TIPOFUN", sdicISPEC_Out.Item("TIPOFUN__AT_" & aux))
          __dic.Add("TIPO_PAGO", sdicISPEC_Out.Item("TIPO_PAGO__AT_" & aux))
          __dic.Add("TCONTRA", sdicISPEC_Out.Item("TCONTRA__AT_" & aux))
          __dic.Add("ESTA", sdicISPEC_Out.Item("ESTA__AT_" & aux))
          __dic.Add("TIPOCON", sdicISPEC_Out.Item("TIPOCON__AT_" & aux))
          __dic.Add("FECTERCON", sdicISPEC_Out.Item("FECTERCON__AT_" & aux))
          __dic.Add("FECINICON", sdicISPEC_Out.Item("FECINICON__AT_" & aux))
          __cf("__COPYFROM__").Add(__dic)

        Next

        CARGOJEFE = sdicISPEC_Out.Item("CARGOJEFE")
        NUMCERT = sdicISPEC_Out.Item("NUMCERT")
        NOMBREJEF = sdicISPEC_Out.Item("NOMBREJEF")
        CARGOFUN = sdicISPEC_Out.Item("CARGOFUN")
        MESREM = sdicISPEC_Out.Item("MESREM")
        ANOREM = sdicISPEC_Out.Item("ANOREM")
        SEXO = sdicISPEC_Out.Item("SEXO")
        APEMATFUN = sdicISPEC_Out.Item("APEMATFUN")
        APEPATFUN = sdicISPEC_Out.Item("APEPATFUN")
        NOMBREFUN = sdicISPEC_Out.Item("NOMBREFUN")
        ANO_C = sdicISPEC_Out.Item("ANO_C")
        SECMOV_C = sdicISPEC_Out.Item("SECMOV_C")
        SECUN_C = sdicISPEC_Out.Item("SECUN_C")
        RUTFUN_C = sdicISPEC_Out.Item("RUTFUN_C")
        TIPOCER_C = sdicISPEC_Out.Item("TIPOCER_C")
        MANT = sdicISPEC_Out.Item("MANT")
        VARIOS_P = sdicISPEC_Out.Item("VARIOS_P")
        CODAREA_P = sdicISPEC_Out.Item("CODAREA_P")
        ESTA_P = sdicISPEC_Out.Item("ESTA_P")
        TCONTRA_P = sdicISPEC_Out.Item("TCONTRA_P")
        TIPOCON_P = sdicISPEC_Out.Item("TIPOCON_P")
        TIPPAGO_P = sdicISPEC_Out.Item("TIPPAGO_P")
        CCOSTO_P = sdicISPEC_Out.Item("CCOSTO_P")
        FTERCON_P = sdicISPEC_Out.Item("FTERCON_P")
        FINICON_P = sdicISPEC_Out.Item("FINICON_P")
        SEC_MOV_P = sdicISPEC_Out.Item("SEC_MOV_P")
        SEC_CON_P = sdicISPEC_Out.Item("SEC_CON_P")
        GCCOSTO_P = sdicISPEC_Out.Item("GCCOSTO_P")
        TIPOFUN_P = sdicISPEC_Out.Item("TIPOFUN_P")
        FINGCORP = sdicISPEC_Out.Item("FINGCORP")
        FINGSER = sdicISPEC_Out.Item("FINGSER")
        NUMBIE = sdicISPEC_Out.Item("NUMBIE")
        VARIOS = sdicISPEC_Out.Item("VARIOS")
        CENTROCOST = sdicISPEC_Out.Item("CENTROCOST")
        TIPOFUN = sdicISPEC_Out.Item("TIPOFUN")
        TIPO_PAGO = sdicISPEC_Out.Item("TIPO_PAGO")
        TCONTRA = sdicISPEC_Out.Item("TCONTRA")
        ESTA = sdicISPEC_Out.Item("ESTA")
        TIPOCON = sdicISPEC_Out.Item("TIPOCON")
        FECTERCON = sdicISPEC_Out.Item("FECTERCON")
        FECINICON = sdicISPEC_Out.Item("FECINICON")

        If sdicISPEC_Out.Item("MENJ35") = "HAY MAS DATOS" And ORQ = "T" Then
          sw = True
        Else
          sw = False
        End If
        y = y + 1

      End While

      __dic = New Dictionary(Of String, String)
      __dic.Add("CARGOJEFE", CARGOJEFE)
      __dic.Add("NUMCERT", NUMCERT)
      __dic.Add("NOMBREJEF", NOMBREJEF)
      __dic.Add("CARGOFUN", CARGOFUN)
      __dic.Add("MESREM", MESREM)
      __dic.Add("ANOREM", ANOREM)
      __dic.Add("SEXO", SEXO)
      __dic.Add("APEMATFUN", APEMATFUN)
      __dic.Add("APEPATFUN", APEPATFUN)
      __dic.Add("NOMBREFUN", NOMBREFUN)
      __dic.Add("ANO_C", ANO_C)
      __dic.Add("SECMOV_C", SECMOV_C)
      __dic.Add("SECUN_C", SECUN_C)
      __dic.Add("RUTFUN_C", RUTFUN_C)
      __dic.Add("TIPOCER_C", TIPOCER_C)
      __dic.Add("MANT", MANT)
      __dic.Add("VARIOS_P", VARIOS_P)
      __dic.Add("CODAREA_P", CODAREA_P)
      __dic.Add("ESTA_P", ESTA_P)
      __dic.Add("TCONTRA_P", TCONTRA_P)
      __dic.Add("TIPOCON_P", TIPOCON_P)
      __dic.Add("TIPPAGO_P", TIPPAGO_P)
      __dic.Add("CCOSTO_P", CCOSTO_P)
      __dic.Add("FTERCON_P", FTERCON_P)
      __dic.Add("FINICON_P", FINICON_P)
      __dic.Add("SEC_MOV_P", SEC_MOV_P)
      __dic.Add("SEC_CON_P", SEC_CON_P)
      __dic.Add("GCCOSTO_P", GCCOSTO_P)
      __dic.Add("TIPOFUN_P", TIPOFUN_P)
      __dic.Add("FINGCORP", FINGCORP)
      __dic.Add("FINGSER", FINGSER)
      __dic.Add("NUMBIE", NUMBIE)
      __dic.Add("VARIOS", VARIOS)
      __dic.Add("CENTROCOST", CENTROCOST)
      __dic.Add("TIPOFUN", TIPOFUN)
      __dic.Add("TIPO_PAGO", TIPO_PAGO)
      __dic.Add("TCONTRA", TCONTRA)
      __dic.Add("ESTA", ESTA)
      __dic.Add("TIPOCON", TIPOCON)
      __dic.Add("FECTERCON", FECTERCON)
      __dic.Add("FECINICON", FECINICON)

      __cf("__PARAMETERS__").Add(__dic)

      __js = New JavaScriptSerializer

      Return __js.Serialize(__cf)

    Catch ex As Exception

      Return ErrorHandler.ErrorAsJson(ex)

    Finally

    End Try

  End Function

End Class