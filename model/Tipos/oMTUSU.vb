Imports slbaperbDll
Namespace Tipos

  Public Class oMTUSU

#Region "Propiedades públicas"

    Public PASSCONFIR As String = ""
    Public PASSNEW As String = ""
    Public PASSWORD As String = ""
    Public NOMBRES As String = ""
    Public APEMAT As String = ""
    Public APEPAT As String = ""
    Public CODUSU As String = ""
    Public OPCION As String = ""
    Public MANT As String = ""
    Public PASW_ACTIV As String = ""
    Public VIGENTE As String = ""
    Public FECNAC As String = ""

#End Region

#Region "Constructores"

    Public Sub New()
    End Sub

    Private Sub __IspecToModel(ByVal Ispec As MTUSU)

      Me.PASSCONFIR = Ispec.PASSCONFIR
      Me.PASSNEW = Ispec.PASSNEW
      Me.PASSWORD = Ispec.PASSWORD
      Me.NOMBRES = Ispec.NOMBRES
      Me.APEMAT = Ispec.APEMAT
      Me.APEPAT = Ispec.APEPAT
      Me.CODUSU = Ispec.CODUSU
      Me.OPCION = Ispec.OPCION
      Me.MANT = Ispec.MANT
      Me.VIGENTE = Ispec.VIGENTE
      Me.FECNAC = Ispec.FECNAC
    End Sub

#End Region

#Region "Propiedades públicas"

#End Region

    Private Function __ModelToIspec() As MTUSU

      Dim Ispec As New MTUSU()

      Ispec.PASSCONFIR = Me.PASSCONFIR
      Ispec.PASSNEW = Me.PASSNEW
      Ispec.PASSWORD = Me.PASSWORD
      Ispec.NOMBRES = Me.NOMBRES
      Ispec.APEMAT = Me.APEMAT
      Ispec.APEPAT = Me.APEPAT
      Ispec.CODUSU = Me.CODUSU
      Ispec.OPCION = Me.OPCION
      Ispec.MANT = Me.MANT
      Ispec.PASW_ACTIV = Me.PASW_ACTIV
      Ispec.VIGENTE = Me.VIGENTE
      Ispec.FECNAC = Me.FECNAC
      Return Ispec

    End Function

    Public Sub consultar(CODUSU)

      Dim Ispec As New MTUSU()

      Ispec.MANT = "INQ"
      Ispec.CODUSU = CODUSU


      __IspecToModel(Me.__callIspec(Ispec))

    End Sub

    Public Sub consultarCredenciales(CODUSU, PASSWORD)

      Dim Ispec As New MTUSU()

      Ispec.PASSWORD = PASSWORD
      Ispec.CODUSU = CODUSU
      Ispec.MANT = "INQ"

      __IspecToModel(Me.__callIspec(Ispec))

    End Sub

    

    Public Sub agregar()

      Dim Ispec As MTUSU = Me.__ModelToIspec
      Ispec.MANT = "ADD"
      Me.__IspecToModel(Me.__callIspec(Ispec))

    End Sub

    Public Sub modificar()

      Dim Ispec As MTUSU = Me.__ModelToIspec

      Ispec.PASSCONFIR = PASSCONFIR
      Ispec.PASSNEW = PASSNEW
      Ispec.PASSWORD = PASSWORD
      Ispec.NOMBRES = NOMBRES
      Ispec.APEMAT = APEMAT
      Ispec.APEPAT = APEPAT
      Ispec.CODUSU = CODUSU
      Ispec.OPCION = OPCION
      Ispec.MANT = "INQ"

      Me.__IspecToModel(Me.__callIspec(Ispec))

    End Sub

    Public Sub modificarPassword(CODUSU, OPCION, PASSCONFIR, PASSNEW, PASSWORD)

      Dim Ispec As MTUSU = Me.__ModelToIspec

      Ispec.PASSCONFIR = PASSCONFIR
      Ispec.PASSNEW = PASSNEW
      Ispec.PASSWORD = PASSWORD
      Ispec.CODUSU = CODUSU
      Ispec.OPCION = OPCION
      Ispec.MANT = "INQ"

      Me.__IspecToModel(Me.__callIspec(Ispec))

    End Sub

    Public Sub borrar(PASSCONFIR, PASSNEW, PASSWORD, NOMBRES, APEMAT, APEPAT, CODUSU, OPCION, MANT)

      Dim Ispec As New MTUSU()

      Ispec.MANT = "DEL"
      Ispec.PASSCONFIR = PASSCONFIR
      Ispec.PASSNEW = PASSNEW
      Ispec.PASSWORD = PASSWORD
      Ispec.NOMBRES = NOMBRES
      Ispec.APEMAT = APEMAT
      Ispec.APEPAT = APEPAT
      Ispec.CODUSU = CODUSU
      Ispec.OPCION = OPCION
      Ispec.MANT = MANT

      Me.__callIspec(Ispec)

    End Sub

    Private Function __callIspec(ByVal Ispec As MTUSU) As MTUSU

      Try
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

