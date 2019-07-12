Imports slbaperbDll

Namespace Tipos
    Public Class oICOL2

#Region "Atributos públicos"
        Public TIPO As String = ""
        Public NUMBAS As String = ""
        Public TIPBAS As String = ""
        Public TIPFUN As String = ""
        Public RUTFUN As String = ""
        Public PROCESO As String = ""
        Public MES As String = ""
        Public ANO As String = ""
        Public INST As String = ""
        Public VAMENU As String = ""
        Public GLOEST As String = ""
        Public HORA As String = ""
        Public CONTRATO As String = ""
        Public NOMBRET As String = ""
        Public APEMATT As String = ""
        Public APEPATT As String = ""
        Public MENJ35 As String = ""
        Public NROCTA As String = ""
        Public CUOTA As String = ""
        Public IND4 As String = ""
        Public MOV_TIPO As String = ""
        Public CAN2 As String = ""
        Public VALORC As String = ""
        Public SIGNO As String = ""
        Public GLOCOD As String = ""
        Public NUMCOD As String = ""
        Public LETCOD As String = ""

#End Region

#Region "Constructores"

        Sub New()
        End Sub

        Friend Sub New(ByVal miICOL2CFType As ICOL2.CFType)
            NROCTA = miICOL2CFType.NROCTA
            CUOTA = miICOL2CFType.CUOTA
            IND4 = miICOL2CFType.IND4
            MOV_TIPO = miICOL2CFType.MOV_TIPO
            CAN2 = miICOL2CFType.CAN2
            VALORC = miICOL2CFType.VALORC
            SIGNO = miICOL2CFType.SIGNO
            GLOCOD = miICOL2CFType.GLOCOD
            NUMCOD = miICOL2CFType.NUMCOD
            LETCOD = miICOL2CFType.LETCOD

        End Sub

#End Region

#Region "Métodos privados"

        Private Function __callIspec(ByVal Ispec As ICOL2) As List(Of ICOL2.CFType)
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

        Public Function consultaMasiva(ByVal RUTFUN As String, ByVal PROCESO As String, ByVal MES As String, ByVal ANO As String, ByVal INST As String) As List(Of oICOL2)

            Dim miICOL2 As New ICOL2()
            Dim lista As New List(Of oICOL2)

            miICOL2.RUTFUN = RUTFUN
            miICOL2.PROCESO = PROCESO
            miICOL2.MES = MES
            miICOL2.ANO = ANO
            miICOL2.INST = INST
            miICOL2.ORQ = "T"

            For Each reg As ICOL2.CFType In Me.__callIspec(miICOL2)
                lista.Add(New oICOL2(reg))
            Next

            Return lista

        End Function

#End Region

    End Class

End Namespace

