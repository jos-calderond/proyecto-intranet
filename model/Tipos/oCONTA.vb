Imports slbaperbDll

Namespace Tipos

  ''' <summary>
  ''' 08/05/2019 rtorreblanca: Creación.
  ''' </summary>
  ''' <remarks></remarks>
  Public Class oCONTA

#Region "Atributos públicos"

    Public codigo As String = ""
    Public descripcion As String = ""

#End Region

#Region "Constructores"

    Sub New()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="miCONTAFType"></param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal miCONTAFType As CONTA.CFType)
      Me.codigo = miCONTAFType.CODIGO
      Me.descripcion = miCONTAFType.DESCRI
    End Sub

#End Region

#Region "Métodos privados"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Ispec"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function __callIspec(ByVal Ispec As CONTA) As List(Of CONTA.CFType)
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

#End Region

#Region "Métodos públicos"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="tipreg"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function consultar(ByVal tipreg As String) As List(Of oCONTA)

      Dim miCONTA As New CONTA()
      miCONTA.CODIGO_B = ""
      miCONTA.TIPORDEN = "C"
      miCONTA.TIPREG_B = tipreg
      miCONTA.DESCRI_B = ""
      miCONTA.ALFA01_B = ""
      miCONTA.ALFA02_B = ""

      Dim lista As New List(Of oCONTA)
      For Each reg As CONTA.CFType In Me.__callIspec(miCONTA)
        lista.Add(New oCONTA(reg))
      Next
      Return lista

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="tipreg"></param>
    ''' <param name="tiporden"></param>
    ''' <param name="alfa2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function consultar(ByVal tipreg As String, ByVal tiporden As String, ByVal alfa2 As String) As List(Of oCONTA)

      Dim miCONTA As New CONTA()
      miCONTA.CODIGO_B = ""
      miCONTA.TIPORDEN = tiporden
      miCONTA.TIPREG_B = tipreg
      miCONTA.DESCRI_B = ""
      miCONTA.ALFA01_B = ""
      miCONTA.ALFA02_B = alfa2

      Dim lista As New List(Of oCONTA)
      For Each reg As CONTA.CFType In Me.__callIspec(miCONTA)
        lista.Add(New oCONTA(reg))
      Next
      Return lista

    End Function

#End Region

  End Class
End Namespace