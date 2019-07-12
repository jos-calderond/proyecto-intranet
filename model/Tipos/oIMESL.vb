Imports slbaperbDll

Namespace Tipos

    Public Class oIMESL
#Region "Atributos públicos"

        Public INST As String = ""
        Public ANO As String = ""
        Public RUTFUN As String = ""
        Public NOMBRE As String = ""
        Public APEMAT As String = ""
        Public APEPAT As String = ""
        Public ANOINI As String = ""
        Public GLOSAMES As String = ""
        Public NUMMES As String = ""

#End Region

#Region "Constructores"

        Sub New()

        End Sub

        Private Sub __IspecToModel(ByVal Ispec As IMESL)

            Me.ANOINI = Ispec.ANOINI

        End Sub

        Private Function __ModelToIspec() As IMESL

            Dim Ispec As New IMESL()

            Ispec.INST = Me.INST
            Ispec.ANO = Me.ANO
            Ispec.RUTFUN = Me.RUTFUN
            Ispec.NOMBRE = Me.NOMBRE
            Ispec.APEMAT = Me.APEMAT
            Ispec.APEPAT = Me.APEPAT
            Ispec.ANOINI = Me.ANOINI
            Ispec.GLOSAMES = Me.GLOSAMES
            Ispec.NUMMES = Me.NUMMES
            
            Return Ispec

        End Function

        Friend Sub New(ByVal miIMESLCFType As IMESL.CFType)
            GLOSAMES = miIMESLCFType.GLOSAMES
            NUMMES = miIMESLCFType.NUMMES

        End Sub

#End Region

#Region "Métodos privados"

        Private Function __callIspec(ByVal Ispec As IMESL) As List(Of IMESL.CFType)

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

        Private Function __callIspecInquiry(ByVal Ispec As IMESL) As IMESL
            Try
                Return Ispec.CallIspecInquiry()
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

        Public Function consultar(ByVal RUTFUN As String, ByVal ANO As String) As List(Of oIMESL)

            Dim miIMESL As New IMESL()
            Dim lista As New List(Of oIMESL)

            miIMESL.INST = "02"
            miIMESL.ANO = ANO
            miIMESL.RUTFUN = RUTFUN.Replace(".", "").PadLeft(10, " ")

            For Each reg As IMESL.CFType In Me.__callIspec(miIMESL)
                lista.Add(New oIMESL(reg))
            Next

            Return lista

        End Function

        Public Function consultarLista(ByVal RUTFUN As String, ByVal ANO As String, ByVal INSTITUCION As String) As List(Of oIMESL)

            Dim miIMESL As New IMESL()
            Dim lista As New List(Of oIMESL)

            miIMESL.INST = INSTITUCION.PadLeft(2, " ")
            miIMESL.ANO = ANO
            miIMESL.RUTFUN = RUTFUN.Replace(".", "").PadLeft(10, " ")

            For Each reg As IMESL.CFType In Me.__callIspec(miIMESL)
                lista.Add(New oIMESL(reg))
            Next

            Return lista

        End Function

        Public Sub aniIni(ByVal RUTFUN As String, ByVal ANO As String)

            Dim miIspec As New IMESL()
            miIspec.RUTFUN = RUTFUN
            miIspec.ANO = ANO
            miIspec.INST = "2"
            miIspec.ORQ = "INQ"

            __IspecToModel(Me.__callIspecInquiry(miIspec))

        End Sub

#End Region

    End Class

End Namespace

