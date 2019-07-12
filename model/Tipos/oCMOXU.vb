Imports slbaperbDll

Namespace Tipos

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <remarks></remarks>
  Public Class oCMOXU

    Public codigoOpcion As String = ""
    Public codigoPadre As String = ""
    Public descripcion As String = ""
    Public formulario As String = ""
    Public icono As String = ""
    Public orden As String = ""
    Public codigoSistema As String = ""

#Region "Constructores"
    Public Sub New()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="miCMOXUCFType"></param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal miCMOXUCFType As CMOXU.CFType)
      Me.codigoOpcion = miCMOXUCFType.CODOPC
      Me.codigoPadre = miCMOXUCFType.CODPADRE
      Me.descripcion = miCMOXUCFType.DESCRIP
      Me.formulario = miCMOXUCFType.FORMU
      Me.icono = miCMOXUCFType.ICONO
      Me.orden = miCMOXUCFType.ORDEN
    End Sub
#End Region

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="codsis"></param>
    ''' <param name="rut"></param>
    ''' <param name="rol"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function consultaPermisosUsuario(ByVal codsis As String, ByVal rut As String, ByVal rol As Integer) As List(Of oCMOXU)
      Dim miCMOXU As New CMOXU()

      miCMOXU.CODSIS = codsis
      miCMOXU.CODUSU = rut.Replace(".", "").PadLeft(10, " ")
      miCMOXU.ROL = rol

      Dim regs As List(Of CMOXU.CFType) = Me.__callIspec(miCMOXU)
      Dim regsTDLocal As New List(Of oCMOXU)

      For Each reg As CMOXU.CFType In regs
        regsTDLocal.Add(New oCMOXU(reg))
      Next

      Return regsTDLocal
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Ispec"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function __callIspec(ByVal Ispec As CMOXU) As List(Of CMOXU.CFType)
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
  End Class
End Namespace