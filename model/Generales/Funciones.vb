Imports Microsoft.VisualBasic
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports System.Text.RegularExpressions
Imports System.Text

Public Class Funciones

  Public Enum DateFormats
    AAAAMMDD = 1
    DDMMAAAA = 2
    AAAAMM = 3
  End Enum

  Public Const gSessionCaducadaForJscroll As String = "<script>$('#modalFinSesion').modal('show'); $('#modalFinSesion').on('hidden.bs.modal', function () { window.location = ('../Default.aspx'); });</script>"

  Public Const gSessionCaducadaForJsFunction As String = "$('#modalFinSesion').modal('show'); $('#modalFinSesion').on('hidden.bs.modal', function () { window.location = ('../Default.aspx'); });"

  ''' <summary>
  ''' '10/05/2019 creacion Pablo Cornejo 
  ''' </summary>
  ''' <param name="str"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function toRealString(ByVal str As String) As String
    If (str Is Nothing) Then
      Return str
    End If
    Dim nuevoStr As String = str
    If (nuevoStr.Length = 0) Then
      Return ""
    End If

    Dim caracteres = New List(Of String)
    caracteres.Add("á='")
    caracteres.Add("é=^")
    caracteres.Add("í=`")
    caracteres.Add("ó=~")
    caracteres.Add("ú={")
    caracteres.Add("ñ=ã")
    caracteres.Add("Á=Ñ")
    caracteres.Add("É=Å")
    caracteres.Add("Í=Ó")
    caracteres.Add("Ó=º")
    caracteres.Add("Ú=È")

    For Each caracter As String In caracteres
      nuevoStr = nuevoStr.Replace(caracter.Split("=")(1), caracter.Split("=")(0))
    Next
    nuevoStr = nuevoStr.Replace("\", "Ñ")
    Return nuevoStr
  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="hora"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function gMcpFormatTime(ByVal hora As String) As String
    Try

      If (hora.IndexOf(":") = -1) Then
        Return ""
      End If

      hora = Regex.Replace(hora, ":", "")

      Return hora

    Catch ex As Exception
      Return ""
    End Try
  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="source"></param>
  ''' <param name="firstString"></param>
  ''' <param name="secondString"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function gGetStringBetween2Strings(ByVal source As String, ByVal firstString As String, ByVal secondString As String) As String
    Try
      Dim startIndex As Integer = source.IndexOf(firstString) + firstString.Length
      Dim endIndex As Integer = source.IndexOf(secondString)

      Return source.Substring(startIndex, endIndex - (startIndex))
    Catch
      Return ""
    End Try
  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="str"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function gGetMd5(ByVal str As String) As String
    Dim md5Hash As MD5 = MD5.Create()
    Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str))
    Dim sBuilder As New StringBuilder()

    For i As Integer = 0 To data.Length - 1
      sBuilder.Append(data(i).ToString("x2"))
    Next i

    Return sBuilder.ToString()
  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="fecha"></param>
  ''' <param name="format"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function gMcpFormatDate(ByVal fecha As String, ByVal format As DateFormats) As String
    Try
      If (format = Nothing) Then
        Return ""
      End If

      If (Not format = Funciones.DateFormats.DDMMAAAA And Not format = Funciones.DateFormats.AAAAMMDD And Not format = Funciones.DateFormats.AAAAMM) Then
        Return ""
      End If

      If format = Funciones.DateFormats.AAAAMM Then
        fecha = "01/" & fecha
      End If

      fecha = gFormatDate(fecha)

      If fecha = "" Then
        Return ""
      End If

      Dim dia As String = fecha.Substring(0, 2)
      Dim mes As String = fecha.Substring(3, 2)
      Dim año As String = fecha.Substring(6, 4)

      Select Case (format)
        Case Funciones.DateFormats.DDMMAAAA
          fecha = ""
                    fecha = String.Concat(dia, "/", mes, "/", año)
        Case Funciones.DateFormats.AAAAMMDD
          fecha = ""
          fecha = String.Concat(año, mes, dia)
        Case Funciones.DateFormats.AAAAMM
          fecha = ""
          fecha = String.Concat(año, mes)
      End Select

      Return fecha
    Catch ex As Exception
      Return ""
    End Try

  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="periodo"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function gFormatPeriod(ByVal periodo As String) As String
    Try

      If (IsNumeric(periodo)) Then
        periodo = Trim(periodo)

        If (Not periodo.Length = 6) Then
          Return ""
        End If

        ' MMAAAA
        Dim mes As String = periodo.Substring(0, 2)
        Dim año As String = periodo.Substring(2, 4)

        Dim imes As Integer = Integer.Parse(mes)
        Dim iaño As Integer = Integer.Parse(año)

        If ((imes < 0 Or imes > 12) Or (iaño < 1990 Or iaño > 2099)) Then
          ' AAAAMM
          mes = periodo.Substring(4, 2)
          año = periodo.Substring(0, 4)

          imes = Integer.Parse(mes)
          iaño = Integer.Parse(año)

          If ((imes < 0 Or imes > 12) Or (iaño < 1990 Or iaño > 2099)) Then
            Return ""
          Else
            periodo = String.Concat(mes, "/", año)
            Return periodo
          End If
        Else
          periodo = String.Concat(mes, "/", año)

          Return periodo
        End If

      Else
        If (periodo.IndexOf("/") = -1) Then
          Return ""
        End If

        periodo = Regex.Replace(periodo, "/", "")
        periodo = gFormatPeriod(periodo)

        Return periodo
      End If
    Catch e As Exception
      Return ""

    End Try

  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="fecha"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function gFormatDate(ByVal fecha As String) As String
    Try

      If (IsNumeric(fecha)) Then
        fecha = Trim(fecha)

        If (Not fecha.Length = 8) Then
          If fecha.Length = 7 Then
            fecha = fecha.PadLeft(8, "0")
          Else
            Return ""
          End If
        End If
        ' DDMMAAAA
        Dim dia As String = fecha.Substring(0, 2)
        Dim mes As String = fecha.Substring(2, 2)
        Dim año As String = fecha.Substring(4, 4)

        Dim idia As Integer = Integer.Parse(dia)
        Dim imes As Integer = Integer.Parse(mes)
        Dim iaño As Integer = Integer.Parse(año)

        If ((idia < 0 Or idia > 31) Or (imes < 0 Or imes > 12) Or (iaño < 1700 Or iaño > 2099)) Then
          ' AAAAMMDD
          dia = fecha.Substring(6, 2)
          mes = fecha.Substring(4, 2)
          año = fecha.Substring(0, 4)

          idia = Integer.Parse(dia)
          imes = Integer.Parse(mes)
          iaño = Integer.Parse(año)

          If ((idia < 0 Or idia > 31) Or (imes < 0 Or imes > 12) Or (iaño < 1700 Or iaño > 2099)) Then
            Return ""
          Else
            fecha = String.Concat(dia, "/", mes, "/", año)
            Return fecha
          End If
        Else
          fecha = String.Concat(dia, "/", mes, "/", año)

          Return fecha
        End If

      Else
        If (fecha.IndexOf("/") = -1) Then
          Return ""
        End If

        fecha = Regex.Replace(fecha, "/", "")
        fecha = gFormatDate(fecha)

        Return fecha
      End If
    Catch e As Exception
      Return ""

    End Try

  End Function

  ''' <summary>
  '''  Substring seguro
  ''' </summary>
  ''' <param name="texto"></param>
  ''' <param name="indice"></param>
  ''' <param name="largo"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function gSafeSubstring(ByVal texto As String, ByVal indice As Integer, largo As Integer) As String
    Try
      If (texto.Length >= (indice + largo)) Then
        Return texto.Substring(indice, largo)
      Else
        If (texto.Length > indice) Then
          Return texto.Substring(indice)
        Else
          Return String.Empty
        End If
      End If
    Catch ex As Exception
      Return ""
    End Try
  End Function

  ''' <summary>
  '''  HHMMSSMS en HH:MM:SS:MS
  ''' </summary>
  ''' <param name="hora">HHMMSSMS</param>
  ''' <returns>HH:MM:SS</returns>
  ''' <remarks></remarks>
  Public Shared Function gFormatTime(ByVal hora As String) As String
    Try

      If (IsNumeric(hora)) Then

        hora = Trim(hora)

        If (Not hora.Length = 6) Then
          If hora.Length = 5 Then
            hora = hora.PadLeft(6, "0")
          Else
            If hora.Length = 7 Then
              hora = hora.PadLeft(8, "0")
            Else
              Return ""
            End If
          End If
        End If

        Select Case hora.Length
          Case 6
            Return hora.Substring(0, 2) & ":" & hora.Substring(2, 2) & ":" & hora.Substring(4, 2)
          Case 8
            Return hora.Substring(0, 2) & ":" & hora.Substring(2, 2) & ":" & hora.Substring(4, 2) & ":" & hora.Substring(6, 2)
          Case Else
            Return ""
        End Select

      Else
        If (hora.IndexOf(":") = -1) Then
          Return ""
        End If

        hora = Regex.Replace(hora, ":", "")
        hora = gFormatTime(hora)

        Return hora
      End If
    Catch ex As Exception
      Return ""
    End Try
  End Function

  ''' <summary>
  '''  remueve separador de miles
  ''' remplaza separador decimal de , a .
  ''' </summary>
  ''' <param name="value"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function gToSqlDecimal(ByVal value As String) As String

    value = Trim(value)
    If Not value = "" Then

      value = value.Replace(".", "")
      value = value.Replace(",", ".")
    Else
      value = "0"
    End If

    Return value

  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="hora"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function gHoraCerosIzq(ByVal hora As Integer) As String
    Try
      Dim strHora As String = hora.ToString()

      If hora = 0 Then
        Return ""
      End If

      If strHora.Length = 5 Then
        strHora = strHora.PadLeft(8, "0")
      End If

      If strHora.Length = 6 Then
        strHora = strHora.PadLeft(8, "0")
      End If

      If strHora.Length = 7 Then
        strHora = strHora.PadLeft(8, "0")
      End If

      Dim ms As String = strHora.Substring(6, 2)
      Dim ss As String = strHora.Substring(4, 2)
      Dim min As String = strHora.Substring(2, 2)
      Dim hh As String = strHora.Substring(0, 2)

      Return hh & ":" & min & ":" & ss & ":" & ms

    Catch ex As Exception
      Return ""
    End Try
  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="rut"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function gValidaRut(ByVal rut As String) As Boolean

    Dim validacion As Boolean = False

    Try

      rut = rut.ToUpper()
      rut = rut.Replace(".", "")
      rut = rut.Replace("-", "")
      Dim rutAux As Integer
      rutAux = Integer.Parse(rut.Substring(0, rut.Length - 1))

      Dim dv As String = rut.Substring(rut.Length - 1, 1)

      Dim Contador As Integer = 2
      Dim Acumulador As Integer = 0
      Dim Multiplo As Integer = 0
      Dim Digito As Integer = 0
      Dim RutDigito As String = ""

      While rutAux <> 0
        Multiplo = (rutAux Mod 10) * Contador
        Acumulador = Acumulador + Multiplo
        rutAux = rutAux \ 10
        Contador = Contador + 1
        If Contador = 8 Then
          Contador = 2
        End If
      End While
      Digito = 11 - (Acumulador Mod 11)
      RutDigito = CStr(Digito)
      If Digito = 10 Then RutDigito = "K"
      If Digito = 11 Then RutDigito = "0"

      If Digito = dv Then
        Return True
      Else
        Return False
      End If

    Catch es As Exception

      Return False

    End Try
    Return validacion

  End Function

  ''' <summary>
  ''' Reemplaza caracteres extraños del mapping.
  ''' </summary>
  ''' <param name="path"></param>
  ''' <remarks></remarks>
  Public Shared Sub gCleanMappingChars(ByVal path As String)

    Dim buffer As New StringBuilder()
    Dim converter As New slbaperbModel.StrMappingConverter()

    Using reader As IO.StreamReader = New IO.StreamReader(path)
      Dim line As String
      line = reader.ReadLine
      If Not line Is Nothing Then

        line = converter.fromMappingToString(line)

        buffer.AppendLine(line)
      End If
      Do While (Not line Is Nothing)
        line = reader.ReadLine
        If Not line Is Nothing Then

          line = converter.fromMappingToString(line)

          buffer.AppendLine(line)
        End If

      Loop
    End Using

    If Not buffer.ToString() = "" Then
      IO.File.WriteAllText(path, buffer.ToString(), Encoding.UTF8)
    End If

  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="cadena"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function glimpiarCadenaReporte(ByVal cadena As String) As String
    cadena = cadena.Replace("õ", "'")
    cadena = cadena.Replace("Õ", "'")
    cadena = cadena.Replace("Ñ", "&Ntilde;")
    cadena = cadena.Replace("Á", "&Aacute;")
    cadena = cadena.Replace("É", "&Eacute;")
    cadena = cadena.Replace("Í", "&Iacute;")
    cadena = cadena.Replace("Ó", "&Oacute;")
    cadena = cadena.Replace("Ú", "&Uacute;")
    cadena = cadena.Replace("À", "&Aacute;")
    cadena = cadena.Replace("È", "&Eacute;")
    cadena = cadena.Replace("Ì", "&Iacute;")
    cadena = cadena.Replace("Ò", "&Oacute;")
    cadena = cadena.Replace("Ù", "&Uacute;")
    cadena = cadena.Replace("ñ", "&ntilde;")
    Return cadena
  End Function

End Class