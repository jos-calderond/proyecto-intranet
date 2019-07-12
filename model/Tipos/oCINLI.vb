Imports slbaperbDll

Namespace Tipos

    Public Class oCINLI

#Region "Atributos públicos"
        Public INDMAT As String = ""
        Public NUMSEC As String = ""
        Public MONTO As String = ""
        Public FECENV As String = ""
        Public FECING As String = ""
        Public NUMLIC As String = ""
        Public FECLIC As String = ""
        Public TIPFUN As String = ""
        Public RUTFUN As String = ""
        Public VAMENU As String = ""
        Public MAINT As String = ""
        Public NPROC6 As String = ""
        Public PFONREG6 As String = ""
        Public NPROC5 As String = ""
        Public PFONREG5 As String = ""
        Public NPROC4 As String = ""
        Public PFONREG4 As String = ""
        Public NPROC3 As String = ""
        Public PFONREG3 As String = ""
        Public NPROC2 As String = ""
        Public PFONREG2 As String = ""
        Public NPROC1 As String = ""
        Public PFONREG1 As String = ""
        Public ESTLIB1 As String = ""
        Public ESTLIB As String = ""
        Public REMNET6 As String = ""
        Public REMNET5 As String = ""
        Public REMNET4 As String = ""
        Public REMNET3 As String = ""
        Public REMNET2 As String = ""
        Public REMNET1 As String = ""
        Public IMPUNI6 As String = ""
        Public IMPUNI5 As String = ""
        Public IMPUNI4 As String = ""
        Public IMPUNI3 As String = ""
        Public IMPUNI2 As String = ""
        Public IMPUNI1 As String = ""
        Public LEYSOC6 As String = ""
        Public LEYSOC5 As String = ""
        Public LEYSOC4 As String = ""
        Public LEYSOC3 As String = ""
        Public LEYSOC2 As String = ""
        Public LEYSOC1 As String = ""
        Public FONREG6 As String = ""
        Public FONREG5 As String = ""
        Public FONREG4 As String = ""
        Public FONREG3 As String = ""
        Public FONREG2 As String = ""
        Public FONREG1 As String = ""
        Public FONSAL6 As String = ""
        Public FONSAL5 As String = ""
        Public FONSAL4 As String = ""
        Public FONSAL3 As String = ""
        Public FONSAL2 As String = ""
        Public FONSAL1 As String = ""
        Public FONDES6 As String = ""
        Public FONDES5 As String = ""
        Public FONDES4 As String = ""
        Public FONDES3 As String = ""
        Public FONDES2 As String = ""
        Public FONDES1 As String = ""
        Public FONPEN6 As String = ""
        Public FONPEN5 As String = ""
        Public FONPEN4 As String = ""
        Public FONPEN3 As String = ""
        Public FONPEN2 As String = ""
        Public FONPEN1 As String = ""
        Public RENIMP6 As String = ""
        Public RENIMP5 As String = ""
        Public RENIMP4 As String = ""
        Public RENIMP3 As String = ""
        Public RENIMP2 As String = ""
        Public RENIMP1 As String = ""
        Public DIASNO6 As String = ""
        Public PFONDES6 As String = ""
        Public DIASNO5 As String = ""
        Public PFONDES5 As String = ""
        Public DIASNO4 As String = ""
        Public PFONDES4 As String = ""
        Public DIASNO3 As String = ""
        Public PFONDES3 As String = ""
        Public DIASNO2 As String = ""
        Public PFONDES2 As String = ""
        Public DIASNO1 As String = ""
        Public PFONDES1 As String = ""
        Public GLOMES6 As String = ""
        Public GLOMES5 As String = ""
        Public GLOMES4 As String = ""
        Public GLOMES3 As String = ""
        Public GLOMES2 As String = ""
        Public GLOMES1 As String = ""
        Public FECISA As String = ""
        Public FINGSE_FUN As String = ""
        Public GLONOMAFP As String = ""
        Public CODAFP As String = ""
        Public GLONOMISA As String = ""
        Public CODISA As String = ""
        Public TOTDIA As String = ""
        Public GLONOMBRE As String = ""
        Public GLOESTADO As String = ""
        Public NDSPAG As String = ""
        Public NUMDOC As String = ""
        Public MONDEV As String = ""
        Public FECREC As String = ""
#End Region

#Region "Constructores"

        Sub New()
        End Sub

        Private Sub __IspecToModel(ByVal Ispec As CINLI)

            Me.INDMAT = Ispec.INDMAT
            Me.NUMSEC = Ispec.NUMSEC
            Me.MONTO = Ispec.MONTO
            Me.FECENV = Ispec.FECENV
            Me.FECING = Ispec.FECING
            Me.NUMLIC = Ispec.NUMLIC
            Me.FECLIC = Ispec.FECLIC
            Me.TIPFUN = Ispec.TIPFUN
            Me.RUTFUN = Ispec.RUTFUN
            Me.VAMENU = Ispec.VAMENU
            Me.MAINT = Ispec.MAINT
            Me.NPROC6 = Ispec.NPROC6
            Me.PFONREG6 = Ispec.PFONREG6
            Me.NPROC5 = Ispec.NPROC5
            Me.PFONREG5 = Ispec.PFONREG5
            Me.NPROC4 = Ispec.NPROC4
            Me.PFONREG4 = Ispec.PFONREG4
            Me.NPROC3 = Ispec.NPROC3
            Me.PFONREG3 = Ispec.PFONREG3
            Me.NPROC2 = Ispec.NPROC2
            Me.PFONREG2 = Ispec.PFONREG2
            Me.NPROC1 = Ispec.NPROC1
            Me.PFONREG1 = Ispec.PFONREG1
            Me.ESTLIB1 = Ispec.ESTLIB1
            Me.ESTLIB = Ispec.ESTLIB
            Me.REMNET6 = Ispec.REMNET6
            Me.REMNET5 = Ispec.REMNET5
            Me.REMNET4 = Ispec.REMNET4
            Me.REMNET3 = Ispec.REMNET3
            Me.REMNET2 = Ispec.REMNET2
            Me.REMNET1 = Ispec.REMNET1
            Me.IMPUNI6 = Ispec.IMPUNI6
            Me.IMPUNI5 = Ispec.IMPUNI5
            Me.IMPUNI4 = Ispec.IMPUNI4
            Me.IMPUNI3 = Ispec.IMPUNI3
            Me.IMPUNI2 = Ispec.IMPUNI2
            Me.IMPUNI1 = Ispec.IMPUNI1
            Me.LEYSOC6 = Ispec.LEYSOC6
            Me.LEYSOC5 = Ispec.LEYSOC5
            Me.LEYSOC4 = Ispec.LEYSOC4
            Me.LEYSOC3 = Ispec.LEYSOC3
            Me.LEYSOC2 = Ispec.LEYSOC2
            Me.LEYSOC1 = Ispec.LEYSOC1
            Me.FONREG6 = Ispec.FONREG6
            Me.FONREG5 = Ispec.FONREG5
            Me.FONREG4 = Ispec.FONREG4
            Me.FONREG3 = Ispec.FONREG3
            Me.FONREG2 = Ispec.FONREG2
            Me.FONREG1 = Ispec.FONREG1
            Me.FONSAL6 = Ispec.FONSAL6
            Me.FONSAL5 = Ispec.FONSAL5
            Me.FONSAL4 = Ispec.FONSAL4
            Me.FONSAL3 = Ispec.FONSAL3
            Me.FONSAL2 = Ispec.FONSAL2
            Me.FONSAL1 = Ispec.FONSAL1
            Me.FONDES6 = Ispec.FONDES6
            Me.FONDES5 = Ispec.FONDES5
            Me.FONDES4 = Ispec.FONDES4
            Me.FONDES3 = Ispec.FONDES3
            Me.FONDES2 = Ispec.FONDES2
            Me.FONDES1 = Ispec.FONDES1
            Me.FONPEN6 = Ispec.FONPEN6
            Me.FONPEN5 = Ispec.FONPEN5
            Me.FONPEN4 = Ispec.FONPEN4
            Me.FONPEN3 = Ispec.FONPEN3
            Me.FONPEN2 = Ispec.FONPEN2
            Me.FONPEN1 = Ispec.FONPEN1
            Me.RENIMP6 = Ispec.RENIMP6
            Me.RENIMP5 = Ispec.RENIMP5
            Me.RENIMP4 = Ispec.RENIMP4
            Me.RENIMP3 = Ispec.RENIMP3
            Me.RENIMP2 = Ispec.RENIMP2
            Me.RENIMP1 = Ispec.RENIMP1
            Me.DIASNO6 = Ispec.DIASNO6
            Me.PFONDES6 = Ispec.PFONDES6
            Me.DIASNO5 = Ispec.DIASNO5
            Me.PFONDES5 = Ispec.PFONDES5
            Me.DIASNO4 = Ispec.DIASNO4
            Me.PFONDES4 = Ispec.PFONDES4
            Me.DIASNO3 = Ispec.DIASNO3
            Me.PFONDES3 = Ispec.PFONDES3
            Me.DIASNO2 = Ispec.DIASNO2
            Me.PFONDES2 = Ispec.PFONDES2
            Me.DIASNO1 = Ispec.DIASNO1
            Me.PFONDES1 = Ispec.PFONDES1
            Me.GLOMES6 = Ispec.GLOMES6
            Me.GLOMES5 = Ispec.GLOMES5
            Me.GLOMES4 = Ispec.GLOMES4
            Me.GLOMES3 = Ispec.GLOMES3
            Me.GLOMES2 = Ispec.GLOMES2
            Me.GLOMES1 = Ispec.GLOMES1
            Me.FECISA = Ispec.FECISA
            Me.FINGSE_FUN = Ispec.FINGSE_FUN
            Me.GLONOMAFP = Ispec.GLONOMAFP
            Me.CODAFP = Ispec.CODAFP
            Me.GLONOMISA = Ispec.GLONOMISA
            Me.CODISA = Ispec.CODISA
            Me.TOTDIA = Ispec.TOTDIA
            Me.GLONOMBRE = Ispec.GLONOMBRE
            Me.GLOESTADO = Ispec.GLOESTADO
            Me.NDSPAG = Ispec.NDSPAG
            Me.NUMDOC = Ispec.NUMDOC
            Me.MONDEV = Ispec.MONDEV
            Me.FECREC = Ispec.FECREC
            
        End Sub

        

        Friend Sub New(ByVal miCINLICFType As CINLI.CFType)
            NDSPAG = miCINLICFType.NDSPAG
            NUMDOC = miCINLICFType.NUMDOC
            MONDEV = miCINLICFType.MONDEV
            FECREC = miCINLICFType.FECREC
        End Sub

#End Region

#Region "Métodos privados"

        Private Function __callIspec(ByVal Ispec As CINLI) As List(Of CINLI.CFType)
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
        Private Function __ModelToIspec() As CINLI

            Dim Ispec As New CINLI()

            Ispec.INDMAT = Me.INDMAT
            Ispec.NUMSEC = Me.NUMSEC
            Ispec.MONTO = Me.MONTO
            Ispec.FECENV = Me.FECENV
            Ispec.FECING = Me.FECING
            Ispec.NUMLIC = Me.NUMLIC
            Ispec.FECLIC = Me.FECLIC
            Ispec.TIPFUN = Me.TIPFUN
            Ispec.RUTFUN = Me.RUTFUN
            Ispec.VAMENU = Me.VAMENU
            Ispec.MAINT = Me.MAINT
            Ispec.NPROC6 = Me.NPROC6
            Ispec.PFONREG6 = Me.PFONREG6
            Ispec.NPROC5 = Me.NPROC5
            Ispec.PFONREG5 = Me.PFONREG5
            Ispec.NPROC4 = Me.NPROC4
            Ispec.PFONREG4 = Me.PFONREG4
            Ispec.NPROC3 = Me.NPROC3
            Ispec.PFONREG3 = Me.PFONREG3
            Ispec.NPROC2 = Me.NPROC2
            Ispec.PFONREG2 = Me.PFONREG2
            Ispec.NPROC1 = Me.NPROC1
            Ispec.PFONREG1 = Me.PFONREG1
            Ispec.ESTLIB1 = Me.ESTLIB1
            Ispec.ESTLIB = Me.ESTLIB
            Ispec.REMNET6 = Me.REMNET6
            Ispec.REMNET5 = Me.REMNET5
            Ispec.REMNET4 = Me.REMNET4
            Ispec.REMNET3 = Me.REMNET3
            Ispec.REMNET2 = Me.REMNET2
            Ispec.REMNET1 = Me.REMNET1
            Ispec.IMPUNI6 = Me.IMPUNI6
            Ispec.IMPUNI5 = Me.IMPUNI5
            Ispec.IMPUNI4 = Me.IMPUNI4
            Ispec.IMPUNI3 = Me.IMPUNI3
            Ispec.IMPUNI2 = Me.IMPUNI2
            Ispec.IMPUNI1 = Me.IMPUNI1
            Ispec.LEYSOC6 = Me.LEYSOC6
            Ispec.LEYSOC5 = Me.LEYSOC5
            Ispec.LEYSOC4 = Me.LEYSOC4
            Ispec.LEYSOC3 = Me.LEYSOC3
            Ispec.LEYSOC2 = Me.LEYSOC2
            Ispec.LEYSOC1 = Me.LEYSOC1
            Ispec.FONREG6 = Me.FONREG6
            Ispec.FONREG5 = Me.FONREG5
            Ispec.FONREG4 = Me.FONREG4
            Ispec.FONREG3 = Me.FONREG3
            Ispec.FONREG2 = Me.FONREG2
            Ispec.FONREG1 = Me.FONREG1
            Ispec.FONSAL6 = Me.FONSAL6
            Ispec.FONSAL5 = Me.FONSAL5
            Ispec.FONSAL4 = Me.FONSAL4
            Ispec.FONSAL3 = Me.FONSAL3
            Ispec.FONSAL2 = Me.FONSAL2
            Ispec.FONSAL1 = Me.FONSAL1
            Ispec.FONDES6 = Me.FONDES6
            Ispec.FONDES5 = Me.FONDES5
            Ispec.FONDES4 = Me.FONDES4
            Ispec.FONDES3 = Me.FONDES3
            Ispec.FONDES2 = Me.FONDES2
            Ispec.FONDES1 = Me.FONDES1
            Ispec.FONPEN6 = Me.FONPEN6
            Ispec.FONPEN5 = Me.FONPEN5
            Ispec.FONPEN4 = Me.FONPEN4
            Ispec.FONPEN3 = Me.FONPEN3
            Ispec.FONPEN2 = Me.FONPEN2
            Ispec.FONPEN1 = Me.FONPEN1
            Ispec.RENIMP6 = Me.RENIMP6
            Ispec.RENIMP5 = Me.RENIMP5
            Ispec.RENIMP4 = Me.RENIMP4
            Ispec.RENIMP3 = Me.RENIMP3
            Ispec.RENIMP2 = Me.RENIMP2
            Ispec.RENIMP1 = Me.RENIMP1
            Ispec.DIASNO6 = Me.DIASNO6
            Ispec.PFONDES6 = Me.PFONDES6
            Ispec.DIASNO5 = Me.DIASNO5
            Ispec.PFONDES5 = Me.PFONDES5
            Ispec.DIASNO4 = Me.DIASNO4
            Ispec.PFONDES4 = Me.PFONDES4
            Ispec.DIASNO3 = Me.DIASNO3
            Ispec.PFONDES3 = Me.PFONDES3
            Ispec.DIASNO2 = Me.DIASNO2
            Ispec.PFONDES2 = Me.PFONDES2
            Ispec.DIASNO1 = Me.DIASNO1
            Ispec.PFONDES1 = Me.PFONDES1
            Ispec.GLOMES6 = Me.GLOMES6
            Ispec.GLOMES5 = Me.GLOMES5
            Ispec.GLOMES4 = Me.GLOMES4
            Ispec.GLOMES3 = Me.GLOMES3
            Ispec.GLOMES2 = Me.GLOMES2
            Ispec.GLOMES1 = Me.GLOMES1
            Ispec.FECISA = Me.FECISA
            Ispec.FINGSE_FUN = Me.FINGSE_FUN
            Ispec.GLONOMAFP = Me.GLONOMAFP
            Ispec.CODAFP = Me.CODAFP
            Ispec.GLONOMISA = Me.GLONOMISA
            Ispec.CODISA = Me.CODISA
            Ispec.TOTDIA = Me.TOTDIA
            Ispec.GLONOMBRE = Me.GLONOMBRE
            Ispec.GLOESTADO = Me.GLOESTADO
            Ispec.NDSPAG = Me.NDSPAG
            Ispec.NUMDOC = Me.NUMDOC
            Ispec.MONDEV = Me.MONDEV
            Ispec.FECREC = Me.FECREC

            Return Ispec

        End Function
#Region "Métodos públicos"

        Public Function consultaMasiva(ByVal FECLIC As String, ByVal RUTFUN As String) As List(Of oCINLI)

            Dim miCINLI As New CINLI()
            Dim lista As New List(Of oCINLI)

            miCINLI.INDMAT = INDMAT
            miCINLI.NUMSEC = NUMSEC
            miCINLI.MONTO = MONTO
            miCINLI.FECENV = FECENV
            miCINLI.FECING = FECING
            miCINLI.NUMLIC = NUMLIC
            miCINLI.FECLIC = FECLIC
            miCINLI.TIPFUN = TIPFUN
            miCINLI.RUTFUN = RUTFUN
            miCINLI.VAMENU = VAMENU
            miCINLI.MAINT = MAINT

            For Each reg As CINLI.CFType In Me.__callIspec(miCINLI)
                lista.Add(New oCINLI(reg))
            Next

            Return lista

        End Function

        Public Sub consultar(ByVal FECLIC As String, ByVal RUTFUN As String)

            Dim miIspec As New CINLI()

            miIspec.RUTFUN = RUTFUN.Replace(".", "").PadLeft(10, " ")
            miIspec.FECLIC = FECLIC
            miIspec.MAINT = "INQ"
            
            __IspecToModel(Me.__callIspecInquiry(miIspec))

        End Sub


        Private Function __callIspecInquiry(ByVal Ispec As CINLI) As CINLI
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

    End Class

End Namespace

