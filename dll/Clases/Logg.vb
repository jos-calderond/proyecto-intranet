Imports System.IO
Imports System.Diagnostics
Imports Microsoft.VisualBasic
Imports System

Public Class Logg
  Public Enum TipoMensaje
    DEBUG
    INFO
    WARNING
    LERROR
  End Enum

  Public Shared Sub e(ByVal strMensaje As String, ByVal objExcepcion As Exception, Optional ByVal objTraza As StackFrame = Nothing)
    Dim msg As String = strMensaje

    msg &= vbNewLine & objExcepcion.Message
    msg &= vbNewLine & objExcepcion.StackTrace

    __escribeLog(TipoMensaje.LERROR, msg, objTraza)
  End Sub

  Public Shared Sub e(ByVal strMensaje As String, Optional ByVal objTraza As StackFrame = Nothing)
    __escribeLog(TipoMensaje.LERROR, strMensaje, objTraza)
  End Sub

  Public Shared Sub w(ByVal strMensaje As String, Optional ByVal objTraza As StackFrame = Nothing)
    __escribeLog(TipoMensaje.WARNING, strMensaje, objTraza)
  End Sub

  Public Shared Sub i(ByVal strMensaje As String, Optional ByVal objTraza As StackFrame = Nothing)
    __escribeLog(TipoMensaje.INFO, strMensaje, objTraza)
  End Sub

  Public Shared Sub d(ByVal strMensaje As String, Optional ByVal objTraza As StackFrame = Nothing)
    __escribeLog(TipoMensaje.DEBUG, strMensaje, objTraza)
  End Sub

  Private Shared Sub __escribeLog(ByVal tipoMensaje As TipoMensaje, ByVal strMensaje As String, Optional ByVal objTraza As StackFrame = Nothing)
    If tipoMensaje >= Config.logNivel Then
      Dim objStream As Stream = Nothing
      Dim rutaLog As String = Config.logCarpeta & getFechaArchivo()

      If File.Exists(rutaLog) Then
        objStream = File.Open(rutaLog, FileMode.Append, FileAccess.Write)
      Else
        objStream = File.Create(rutaLog)
      End If

      Dim strLineaLog As String = String.Empty

      strLineaLog = Date.Now.ToString() & ";" & strMensaje

      If Not objTraza Is Nothing Then
        strLineaLog &= "/" & __getTraza(objTraza)
      End If

      Dim objStreamWriter As New StreamWriter(objStream)
      objStreamWriter.WriteLine(strLineaLog)
      objStreamWriter.Close()
      objStream.Close()
    End If
  End Sub

  Private Shared Function getFechaArchivo() As String
    Dim objFecha As Date = Date.Now
    Dim strCadena As String = String.Empty

    strCadena &= Config.logPrefijo & objFecha.Year

    If objFecha.Month < 10 Then
      strCadena &= "0"
    End If

    strCadena &= objFecha.Month

    If objFecha.Day < 10 Then
      strCadena &= "0"
    End If

    strCadena &= objFecha.Day

    strCadena &= Config.logExtension

    Return strCadena
  End Function

  Private Shared Function __getTraza(ByVal objTraza As StackFrame) As String
    Dim strTraza As String = String.Empty

    If Not objTraza Is Nothing Then
      Dim iPosicion As Integer = objTraza.GetFileName.LastIndexOf("\")

      If iPosicion < 0 Then
        strTraza = objTraza.GetFileName()
      Else
        strTraza = objTraza.GetFileName().Substring(iPosicion + 1)
      End If

      strTraza &= "::" & objTraza.GetFileLineNumber & " - "
    End If

    Return strTraza
  End Function
End Class


