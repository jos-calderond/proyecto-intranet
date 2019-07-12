Imports slbaperbDll

Namespace Tipos

    Public Class oICOL4
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
        Public HORAS As String = ""
        Public CONTRATO As String = ""
        Public NOMBRET As String = ""
        Public APEMATT As String = ""
        Public APEPATT As String = ""
        Public MENJ35 As String = ""
        Public IMP As String = ""
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

        Friend Sub New(ByVal miICOL4CFType As ICOL4.CFType)
            IMP = miICOL4CFType.IMP
            NROCTA = miICOL4CFType.NROCTA
            CUOTA = miICOL4CFType.CUOTA
            IND4 = miICOL4CFType.IND4
            MOV_TIPO = miICOL4CFType.MOV_TIPO
            CAN2 = miICOL4CFType.CAN2
            VALORC = miICOL4CFType.VALORC
            SIGNO = miICOL4CFType.SIGNO
            GLOCOD = miICOL4CFType.GLOCOD
            NUMCOD = miICOL4CFType.NUMCOD
            LETCOD = miICOL4CFType.LETCOD
        End Sub

#End Region

#Region "Métodos privados"

        Private Function __callIspec(ByVal Ispec As ICOL4) As List(Of ICOL4.CFType)
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

        Public Function consultaMasiva(ByVal RUTFUN As String, ByVal PROCESO As String, ByVal MES As String, ByVal ANO As String, ByVal INST As String) As List(Of oICOL4)

            Dim miICOL4 As New ICOL4()
            Dim lista As New List(Of oICOL4)

            miICOL4.RUTFUN = RUTFUN
            miICOL4.PROCESO = PROCESO
            miICOL4.MES = MES
            miICOL4.ANO = ANO
            miICOL4.INST = INST
            miICOL4.ORQ = "T"

            For Each reg As ICOL4.CFType In Me.__callIspec(miICOL4)
                lista.Add(New oICOL4(reg))
            Next

            Return lista

        End Function

#End Region

    End Class

End Namespace

