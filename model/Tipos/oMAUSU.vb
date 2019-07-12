Imports slbaperbDll

Namespace Tipos

  ''' <summary>
  ''' 09/05/2019 pcornejo: Creación.
  ''' </summary>
  ''' <remarks></remarks>
  Public Class oMAUSU

#Region "Propiedades públicas"

    Private __usuario As String = ""

    Public rut As String = ""
    Public nombre As String = ""
    Public apellidoMaterno As String = ""
    Public apellidoPaterno As String = ""
    Public estado As String = ""
    Public fechaPassword As String = ""
    Public password As String = ""
    Public iniciales As String = ""
    Public correo As String = ""
    Public codigoSistema As String = ""
    Public unidad As String = ""

#End Region

#Region "Constructores"

    Public Sub New(ByVal usuario As String)
      Me.__usuario = usuario.Replace(".", "").PadLeft(10, " ")

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Ispec"></param>
    ''' <remarks></remarks>
    Private Sub __IspecToModel(ByVal Ispec As MAUSU)

      Me.rut = Ispec.RUT.Trim
      Me.nombre = Ispec.NOMBRES
      Me.apellidoMaterno = Ispec.APEMAT
      Me.apellidoPaterno = Ispec.APEPAT
      Me.estado = Ispec.ESTADO
      Me.fechaPassword = Ispec.FECPASS
      Me.password = Ispec.PASS
      Me.iniciales = Ispec.INICIALES
      Me.correo = Ispec.CORREO
      Me.codigoSistema = Ispec.CODSIS
      Me.unidad = Ispec.UNIDAD
    End Sub

#End Region

#Region "Propiedades públicas"

    Public ReadOnly Property usuario() As String
      Get
        Return Me.__usuario
      End Get
    End Property

#End Region

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function __ModelToIspec() As MAUSU
      Dim Ispec As New MAUSU()
      Ispec.RUT = Me.rut.Replace(".", "").PadLeft(10, " ").ToUpper()
      Ispec.NOMBRES = Me.nombre.ToUpper()
      Ispec.APEMAT = Me.apellidoMaterno.ToUpper()
      Ispec.APEPAT = Me.apellidoPaterno.ToUpper()
      Ispec.ESTADO = Me.estado.ToUpper()
      Ispec.FECPASS = Me.fechaPassword
      If Me.password.Trim = "" Then
        Ispec.PASS = ""
      Else
        Ispec.PASS = Funciones.gGetMd5(Me.password)
      End If
      ''Ispec.PASS = Funciones.gGetMd5(Me.password)
      Ispec.INICIALES = Me.iniciales.ToUpper()
      Ispec.CORREO = Me.correo.ToUpper()
      Ispec.CODSIS = Me.codigoSistema.ToUpper()
      Ispec.UNIDAD = Me.unidad.ToUpper()
      Return Ispec

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="rut"></param>
    ''' <remarks></remarks>
    Public Sub consultar(ByVal codsis As String, ByVal rut As String)
      Dim Ispec As New MAUSU()
      Ispec.MANT = "INQ"
      Ispec.RUT = rut.Replace(".", "").PadLeft(10, " ")
      Ispec.CODSIS = codsis

      __IspecToModel(Me.__callIspec(Ispec))

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub agregar()
      Dim Ispec As MAUSU = Me.__ModelToIspec
      Ispec.MANT = "ADD"

      Me.__IspecToModel(Me.__callIspec(Ispec))

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub modificar()
      Dim Ispec As MAUSU = Me.__ModelToIspec
      Ispec.MANT = "CHG"

      Me.__IspecToModel(Me.__callIspec(Ispec))
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="rut"></param>
    ''' <remarks></remarks>
    Public Sub borrar(ByVal codsis As String, ByVal rut As String)
      Dim Ispec As New MAUSU()
      Ispec.MANT = "DEL"
      Ispec.RUT = rut.Replace(".", "").PadLeft(10, " ")
      Ispec.CODSIS = codsis

      Me.__callIspec(Ispec)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Ispec"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function __callIspec(ByVal Ispec As MAUSU) As MAUSU
      Try
        Ispec.CODUSU = Me.usuario
        Return Ispec.CallIspec()
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