Imports System.Web.Services
Imports System.Diagnostics
Imports System.Web.Services.Protocols
Imports System.Collections.Generic
Imports System.IO
Imports System.Configuration

<WebService([Namespace]:="http://ProexsiFirmaDigital/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
Public Class Service
  Inherits System.Web.Services.WebService
  Private NUM_VERSION As String = "1.0"
  Private Declare Auto Function SetProcessWorkingSetSze Lib "kernell32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

  Public Sub ClearMemory()
    Try
      Dim Mem As Process
      Mem = Process.GetCurrentProcess()
      'SetProcessWorkingSetSze(Mem.Handle, -1, -1)
      GC.Collect()
    Catch ex As Exception

    End Try
  End Sub
  Public Sub New()
  End Sub

  <WebMethod()> _
  Public Function ValidarDirectorio(ByVal Institucion As String, ByVal Sistema As String, ByVal TipDoc As String) As Configuracion
    Dim dao As New CodigoValidador()
    Try
      Return dao.Directorio(Institucion, Sistema, TipDoc)
    Catch ex As SoapException
      Throw ex
    Finally
      dao = Nothing
    End Try
  End Function

  <WebMethod()> _
  Public Function CodigoValidador(ByVal codigo As String, ByVal Tipo As String) As Configuracion
    Dim dao As New CodigoValidador()
    Try
      Return dao.DecCod_Clave(codigo, Tipo)
    Catch ex As SoapException
      Throw ex
    Finally
      dao = Nothing
    End Try
  End Function

  <WebMethod()> _
  Public Function testConn() As String
    Return ("WebService WS_Validador, versión: " + Me.NUM_VERSION)
  End Function

  Private Sub Service_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
    ClearMemory()
  End Sub
  Protected Overrides Sub Finalize()
    ClearMemory()
    MyBase.Finalize()
  End Sub
End Class