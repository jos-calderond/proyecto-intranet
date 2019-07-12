Imports System.Collections.Generic
Imports slbaperbModel
Imports System.Web.Script.Serialization

''' <summary>
''' 05/06/2019 jCalderon: Creación.
''' </summary>
''' <remarks></remarks>
Partial Class sCertificados
  Inherits System.Web.UI.Page

  Private __js As New JavaScriptSerializer

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    Try
      ' Control de acceso.
      Dim caller As String = HttpContext.Current.Request.ServerVariables("HTTP_REFERER")

      If caller Is Nothing Then

        Throw New Exception("Acceso no autorizado.")
        Exit Sub

      Else

        If Not caller.Contains("/pages/frm") Then
          Throw New Exception("Acceso no autorizado.")

          Exit Sub

        End If

      End If

      ' Control de sesión
      If Session("Usuario.Rut") Is Nothing Then
        Throw New TimeoutException(Funciones.gSessionCaducadaForJsFunction)
      End If

      Dim accion = Request.QueryString("accion")

      Select Case accion

        Case "consultar"

          Dim rut = Session("Usuario.Rut")
          Dim numero = Request.QueryString("numero")
          Dim tipo As String = String.Empty

          Select Case numero

            Case 1
              tipo = "CAL"
            Case 2
              tipo = "ARI"
            Case 3
              tipo = "L19"
            Case 4
              tipo = "CFU"
            Case 5
              tipo = "CFA"

            Case Else

          End Select
          Dim ano As String = Date.Now.Year
          Dim reg As New Tipos.oICERW()
          reg.consultar(rut, ano)
          Dim estado_p As String : Dim tipoContrato_p As String : Dim codigoArea_p As String : Dim tipoPago As String : Dim fecha_p As String : Dim codContrato As String = String.Empty
          Dim resultado As String = String.Empty

          estado_p = reg.ESTA_P
          tipoContrato_p = reg.TCONTRA_P
          codigoArea_p = reg.CODAREA_P
          fecha_p = reg.FINICON_P
          tipoPago = reg.TIPPAGO_P
          codContrato = reg.TIPOCON_P

          If estado_p = "VIGENTE" Then
            If tipo = "CAL" Or tipo = "ARI" Then
              If tipoContrato_p <> "INDEFINIDO" And tipoContrato_p <> "FIJO" Then
                GoTo salto
              End If
            ElseIf tipo = "L19" Then
              If codigoArea_p = "EDU" Then
                If codContrato <> "CO" And codContrato <> "PL" Then
                  GoTo salto
                End If
                If tipoPago <> "E" Then
                  GoTo salto
                End If
              Else
                GoTo salto
              End If
            ElseIf tipo = "CFU" And codigoArea_p = "SAL" Then
              GoTo salto
            End If
          Else
            resultado = "1"
          End If

salto:
          resultado += resultado

          If resultado = "1" Then
            Response.Write(__js.Serialize(resultado))
          Else
            Response.Write(__js.Serialize(reg))
          End If

        Case "consultaAnos"

          Dim rut As String = Session("Usuario.Rut")
          Dim actual As String = Date.Now.Year
          actual += 1
          Dim mes As String = Date.Now.Month
          Dim anoini As String = ""
          Dim lista As New List(Of String)

          Dim reg As New Tipos.oIMESL()
          reg.aniIni(rut, actual)
          anoini = reg.ANOINI
          If anoini = 0 Then
            anoini = actual
          End If

          Dim institucion As String = "2"
          Dim ano As Integer = anoini

          While ano <> actual

            Dim datos As List(Of Tipos.oIMESL) = New Tipos.oIMESL().consultarLista(rut, ano, institucion)

            For i As Integer = 0 To datos.Count - 1

              If datos.Item(i).NUMMES <> 0 Then
                If lista.Count = 0 Then
                  lista.Add(ano.ToString())
                Else

                  For x As Integer = 0 To lista.Count - 1
                    If lista.Item(x) <> ano Then
                      lista.Add(ano.ToString())
                    End If
                  Next
                End If
              End If
            Next
            ano += 1
          End While

          If lista.Count = 0 Then
            lista.Add(Date.Now.Year)
          End If

          Response.Write(__js.Serialize(lista))

        Case "consultaMeses"

          Dim rut As String = Session("Usuario.Rut")
          Dim ano As String = Request.QueryString("ano")
          Dim lista As New List(Of String)
          Dim institucion As String = "2"

          Dim datos As List(Of Tipos.oIMESL) = New Tipos.oIMESL().consultarLista(rut, ano, institucion)

          For i As Integer = 0 To datos.Count - 1

            If datos.Item(i).GLOSAMES.ToString() <> String.Empty Then
              If lista.Count = 0 Then
                lista.Add(datos.Item(i).GLOSAMES.ToString())
              Else
                For x As Integer = 0 To lista.Count - 1
                  If lista.Item(x) <> datos.Item(i).GLOSAMES Then
                    lista.Add(datos.Item(i).GLOSAMES.ToString())
                  End If
                Next
              End If
            End If
          Next


          If lista.Count = 0 Then
            lista.Add("")
          End If

          Response.Write(__js.Serialize(lista))

      End Select

    Catch ex0 As TimeoutException

      Dim err As New Dictionary(Of String, Exception)
      err.Add("timeouterror", New Exception(ex0.Message.Replace(vbLf, " ").Replace(vbCr, " ")))
      Response.Write(__js.Serialize(err))

    Catch ex As Exception

      Dim err As New Dictionary(Of String, Exception)
      err.Add("error", New Exception(ex.Message.Replace(vbLf, " ").Replace(vbCr, " ")))
      Response.Write(__js.Serialize(err))

    End Try

  End Sub

End Class