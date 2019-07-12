Imports slbaperbDll

Namespace Tipos

  Public Class oIIMTU

#Region "Propiedades públicas"
    Public PRIORIDAD As Integer = 0
    Public EMAIL As String = ""
    Public CODUSU As String = ""
    Public OPCION As String = ""
    Public MANT As String = ""
    Public PASSMAIL As String = ""

#End Region

#Region "Constructores"
    Public Sub New()
    End Sub

    Private Sub __IspecToModel(ByVal Ispec As IIMTU)
      Me.PRIORIDAD = Ispec.PRIORIDAD
      Me.EMAIL = Ispec.EMAIL
      Me.CODUSU = Ispec.CODUSU
      Me.OPCION = Ispec.OPCION
      Me.MANT = Ispec.MANT
      Me.PASSMAIL = Ispec.PASSMAIL

    End Sub
#End Region

#Region "Propiedades públicas"
#End Region

    Private Function __ModelToIspec() As IIMTU
      Dim Ispec As New IIMTU()
      Ispec.PRIORIDAD = Me.PRIORIDAD
      Ispec.EMAIL = Me.EMAIL
      Ispec.CODUSU = Me.CODUSU
      Ispec.OPCION = Me.OPCION
      Ispec.MANT = Me.MANT
      Ispec.PASSMAIL = Me.PASSMAIL

      Return Ispec
    End Function

    Public Sub consultar(PRIORIDAD, EMAIL, CODUSU, OPCION, MANT, PASSMAIL)
      Dim Ispec As New IIMTU()
      Ispec.MANT = "INQ"
      Ispec.PRIORIDAD = PRIORIDAD
      Ispec.EMAIL = EMAIL
      Ispec.CODUSU = CODUSU
      Ispec.OPCION = OPCION
      Ispec.MANT = MANT
      Ispec.PASSMAIL = PASSMAIL

      __IspecToModel(Me.__callIspec(Ispec))
    End Sub

    Public Sub consultarCorreo(PRIORIDAD, CODUSU, MANT)
      Dim Ispec As New IIMTU()
      Ispec.MANT = "INQ"
      Ispec.PRIORIDAD = PRIORIDAD
      Ispec.CODUSU = CODUSU
      Ispec.MANT = MANT
      __IspecToModel(Me.__callIspec(Ispec))
    End Sub

    Public Sub agregar(PRIORIDAD, EMAIL, CODUSU, PASSMAIL)
      Dim Ispec As IIMTU = Me.__ModelToIspec
      Ispec.MANT = "ADD"
      Ispec.PRIORIDAD = PRIORIDAD
      Ispec.EMAIL = EMAIL
      Ispec.CODUSU = CODUSU
      Ispec.PASSMAIL = PASSMAIL
      Me.__IspecToModel(Me.__callIspec(Ispec))
    End Sub

    Public Sub modificar(PRIORIDAD, EMAIL, CODUSU, PASSMAIL)
      Dim Ispec As IIMTU = Me.__ModelToIspec
      Ispec.MANT = "CHG"
      Ispec.PRIORIDAD = PRIORIDAD
      Ispec.EMAIL = EMAIL
      Ispec.CODUSU = CODUSU
      Ispec.PASSMAIL = PASSMAIL
      Me.__IspecToModel(Me.__callIspec(Ispec))
    End Sub

    Public Sub borrar(PRIORIDAD, EMAIL, CODUSU, MANT, PASSMAIL)
      Dim Ispec As New IIMTU()
      Ispec.MANT = "DEL"
      Ispec.PRIORIDAD = PRIORIDAD
      Ispec.EMAIL = EMAIL
      Ispec.CODUSU = CODUSU
      Ispec.OPCION = OPCION
      Ispec.MANT = MANT
      Ispec.PASSMAIL = PASSMAIL
      Me.__callIspec(Ispec)
    End Sub

    Private Function __callIspec(ByVal Ispec As IIMTU) As IIMTU
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

