Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Data
Imports System.Web.Services.Protocols
Imports System.Xml
Imports System.Drawing
Imports System.Net
Imports System.Configuration
Imports System.IO
Imports System.Net.Mime.MediaTypeNames

Public Class CodigoValidador
  Implements IDisposable
  Private Declare Auto Function SetProcessWorkingSetSze Lib "kernell32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean
  Public pSistema As String = ""
  Public swIns, swSis, swTid As Boolean
  Public Institucion, Sistema, TipoDoc As String
  Public sError As String

  Public Function DecCod_Clave(ByVal codigo As String, ByVal Tipo As String) As Configuracion
    Dim _Configuracion As New Configuracion
    Dim _Resultado As String
    Try
      _Resultado = Codificar_Clave(codigo, Tipo)
      _Configuracion.WS_Respuesta = 1
      If _Resultado = "NOK" Then
        _Configuracion.WS_Respuesta = 1
      Else
        _Configuracion.WS_Respuesta = 0
        _Configuracion.WS_Codigo = _Resultado
      End If

      Return _Configuracion
    Catch ex As Exception
      _Configuracion.WS_Respuesta = 1
      _Configuracion.WS_Error = ex.Message
    End Try
    Return _Configuracion
  End Function

  Public Function Codificar_Clave(ByVal codigo As String, ByVal tipo As String) As String
    Dim CodigoValidador = New CodigoValidador
    Dim Sec_a1, Sec_a2, Sec_a3, Sec_a4 As String
    Dim Sec_b1, Sec_b2, Sec_b3, Sec_b4 As String
    Dim _codigo As String
    Dim GrupoA, GrupoB As String
    Dim swCodigoValidador As Boolean = False
    Try
      _codigo = codigo.ToUpper.PadRight(26, " ")
      If tipo = "COD" Then
        Institucion = _codigo.Substring(0, 2)
        Sistema = _codigo.Substring(2, 3)
        TipoDoc = _codigo.Substring(5, 3)
        CodigoValidador.Valida_Directorio(Institucion, Sistema, TipoDoc)
        If CodigoValidador.swIns And _
           CodigoValidador.swSis And _
           CodigoValidador.swTid Then
          swCodigoValidador = True
        End If
      ElseIf tipo = "DEC" Then
        swCodigoValidador = True
      End If
      If swCodigoValidador Then
        Sec_a1 = _codigo.Substring(0, 2)
        Sec_a2 = _codigo.Substring(2, 3)
        Sec_a3 = _codigo.Substring(5, 4)
        Sec_a4 = _codigo.Substring(9, 4)

        Sec_b1 = _codigo.Substring(24, 2)
        Sec_b2 = _codigo.Substring(21, 3)
        Sec_b3 = _codigo.Substring(17, 4)
        Sec_b4 = _codigo.Substring(13, 4)
        _codigo = ""
        If tipo = "COD" Then
          GrupoB = Sec_b1 & Sec_b2 & Sec_b3 & Sec_b4
          GrupoA = Sec_a1 & Sec_a2 & Sec_a3 & Sec_a4
          _codigo = GrupoB & GrupoA
        ElseIf tipo = "DEC" Then
          GrupoB = Sec_b4 & Sec_b3 & Sec_b2 & Sec_b1
          GrupoA = Sec_a4 & Sec_a3 & Sec_a2 & Sec_a1
          _codigo = GrupoB & GrupoA
        End If
        Return _codigo
      Else
        Return "NOK"
      End If
    Catch ex As SoapException
      Return "NOK"
    End Try
  End Function

  Sub Valida_Directorio(ByRef Institucion As String, ByRef Sistema As String, ByRef TipoDoc As String)
    Dim _Configuracion As New Configuracion
    Try
      ' Create an instance of StreamReader to read from a file.

      Dim extArch = AppDomain.CurrentDomain.BaseDirectory & ConfigurationManager.ConnectionStrings("Archivo_Config").ConnectionString
      extArch = extArch.ToString.Substring(extArch.ToString.Length() - 4, 4)

      Dim nomArch = AppDomain.CurrentDomain.BaseDirectory & ConfigurationManager.ConnectionStrings("Archivo_Config").ConnectionString
      nomArch = nomArch.ToString.Substring(0, nomArch.ToString.Length() - 4)
      nomArch = nomArch & Institucion & extArch

      Dim sr As StreamReader = New StreamReader(nomArch.ToString)
      Dim line As String
      ' Read and display the lines from the file until the end 
      ' of the file is reached.
      swIns = False : swSis = False : swTid = False
      Do
        line = sr.ReadLine()
        If Not line Is Nothing Then
          If line.Substring(0, 3) = "INS" And line.Substring(3, 2) = Institucion Then
            Institucion = line.Substring(5, line.Length() - 5).ToUpper
            swIns = True
          End If
          If line.Substring(0, 3) = "SIS" And line.Substring(3, 3) = Sistema Then
            Sistema = line.Substring(6, line.Length() - 6).ToUpper
            swSis = True
          End If
          If line.Substring(0, 3) = "TID" And line.Substring(3, 3) = TipoDoc Then
            TipoDoc = line.Substring(6, line.Length() - 6).ToUpper
            swTid = True
          End If
          If line.Length = 0 Then

          End If
        End If
      Loop Until line Is Nothing
      sr.Close()
    Catch E As Exception
      sError = E.Message
    End Try
  End Sub
  Function Directorio(ByRef Institucion As String, ByRef Sistema As String, ByRef TipoDoc As String) As Configuracion
    Dim cont As Integer = 0
    Dim _Configuracion As New Configuracion
    Try
      Valida_Directorio(Institucion, Sistema, TipoDoc)

      If swIns And swSis And swTid Then
        _Configuracion.WS_Respuesta = 0
        _Configuracion.WS_Institucion = Institucion
        _Configuracion.WS_Sistema = Sistema
        _Configuracion.WS_TipDoc = TipoDoc
      Else
        _Configuracion.WS_Respuesta = 1
        _Configuracion.WS_Error = "No Existen Descripción para los valores ingresados"
      End If

    Catch E As Exception
      _Configuracion.WS_Respuesta = 1
      _Configuracion.WS_Error = E.Message
    End Try
    Return _Configuracion
  End Function

  Private disposedValue As Boolean = False        ' Para detectar llamadas redundantes
  ' IDisposable
  Protected Overridable Sub Dispose(ByVal disposing As Boolean)
    If Not Me.disposedValue Then
      If disposing Then
      End If
    End If
    Me.disposedValue = True
  End Sub
#Region " IDisposable Support "
  ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
  Public Sub Dispose() Implements IDisposable.Dispose
    ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
    Dispose(True)
    GC.SuppressFinalize(Me)
  End Sub
#End Region
End Class
