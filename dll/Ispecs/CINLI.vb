Imports System.Web.Script.Serialization

Public Class CINLI

    Public ORQ As String = ""
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
    Public CF As List(Of CFType)

    Private __js As JavaScriptSerializer
    Private __dic As Dictionary(Of String, Object)
    Public WebService As New WS.WebService

    Public Class CFType
        Public NDSPAG As String = ""
        Public NUMDOC As String = ""
        Public MONDEV As String = ""
        Public FECREC As String = ""
    End Class

    Sub New()
    End Sub

    Public Function CallIspec() As CINLI

        Dim ISPEC As String = WebService.CINLI(ORQ, INDMAT, NUMSEC, MONTO, FECENV, FECING, NUMLIC, FECLIC, TIPFUN, RUTFUN, VAMENU, MAINT)
        Dim CINLI As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

        __dic = TryCast(CINLI, Dictionary(Of String, Object))

        If (Not __dic Is Nothing) Then
            If (__dic.ContainsKey("ERROR")) Then
                Throw New WSException(__dic("ERROR")("Message"), "CINLI")
            End If
        End If
        If __dic.Count = 0 Then
            Throw New Exception("Error de conexion con el Webservice")
        End If

        Me.INDMAT = CINLI("__PARAMETERS__")(0)("INDMAT")
        Me.NUMSEC = CINLI("__PARAMETERS__")(0)("NUMSEC")
        Me.MONTO = CINLI("__PARAMETERS__")(0)("MONTO")
        Me.FECENV = CINLI("__PARAMETERS__")(0)("FECENV")
        Me.FECING = CINLI("__PARAMETERS__")(0)("FECING")
        Me.NUMLIC = CINLI("__PARAMETERS__")(0)("NUMLIC")
        Me.FECLIC = CINLI("__PARAMETERS__")(0)("FECLIC")
        Me.TIPFUN = CINLI("__PARAMETERS__")(0)("TIPFUN")
        Me.RUTFUN = CINLI("__PARAMETERS__")(0)("RUTFUN")
        Me.VAMENU = CINLI("__PARAMETERS__")(0)("VAMENU")
        Me.MAINT = CINLI("__PARAMETERS__")(0)("MAINT")

        Dim cftype As CINLI.CFType
        Me.CF = New List(Of CFType)

        For Each reg In CINLI("__COPYFROM__")
            cftype = New CINLI.CFType()
            cftype.NDSPAG = reg("NDSPAG")
            cftype.NUMDOC = reg("NUMDOC")
            cftype.MONDEV = reg("MONDEV")
            cftype.FECREC = reg("FECREC")
            Me.CF.Add(cftype)
        Next

        Return Me

    End Function

    Public Function CallIspecInquiry() As CINLI

        Dim ISPEC As String = WebService.CINLI(ORQ, INDMAT, NUMSEC, MONTO, FECENV, FECING, NUMLIC, FECLIC, TIPFUN, RUTFUN, VAMENU, MAINT)
        Dim CINLI As Object = New JavaScriptSerializer().DeserializeObject(ISPEC)

        __dic = TryCast(CINLI, Dictionary(Of String, Object))

        If (Not __dic Is Nothing) Then
            If (__dic.ContainsKey("ERROR")) Then
                Throw New WSException(__dic("ERROR")("Message"), "CINLI")
            End If
        End If

        If __dic.Count = 0 Then
            Throw New Exception("Error de conexion con el Webservice")
        End If

        Me.INDMAT = CINLI("__PARAMETERS__")(0)("INDMAT")
        Me.NUMSEC = CINLI("__PARAMETERS__")(0)("NUMSEC")
        Me.MONTO = CINLI("__PARAMETERS__")(0)("MONTO")
        Me.FECENV = CINLI("__PARAMETERS__")(0)("FECENV")
        Me.FECING = CINLI("__PARAMETERS__")(0)("FECING")
        Me.FECLIC = CINLI("__PARAMETERS__")(0)("FECLIC")
        Me.TIPFUN = CINLI("__PARAMETERS__")(0)("TIPFUN")
        Me.RUTFUN = CINLI("__PARAMETERS__")(0)("RUTFUN")
        Me.VAMENU = CINLI("__PARAMETERS__")(0)("VAMENU")
        Me.NPROC6 = CINLI("__PARAMETERS__")(0)("NPROC6")
        Me.PFONREG6 = CINLI("__PARAMETERS__")(0)("PFONREG6")
        Me.NPROC5 = CINLI("__PARAMETERS__")(0)("NPROC5")
        Me.PFONREG5 = CINLI("__PARAMETERS__")(0)("PFONREG5")
        Me.NPROC4 = CINLI("__PARAMETERS__")(0)("NPROC4")
        Me.PFONREG4 = CINLI("__PARAMETERS__")(0)("PFONREG4")
        Me.NPROC3 = CINLI("__PARAMETERS__")(0)("NPROC3")
        Me.PFONREG3 = CINLI("__PARAMETERS__")(0)("PFONREG3")
        Me.NPROC2 = CINLI("__PARAMETERS__")(0)("NPROC2")
        Me.PFONREG2 = CINLI("__PARAMETERS__")(0)("PFONREG2")
        Me.NPROC1 = CINLI("__PARAMETERS__")(0)("NPROC1")
        Me.PFONREG1 = CINLI("__PARAMETERS__")(0)("PFONREG1")
        Me.ESTLIB1 = CINLI("__PARAMETERS__")(0)("ESTLIB1")
        Me.ESTLIB = CINLI("__PARAMETERS__")(0)("ESTLIB")
        Me.REMNET6 = CINLI("__PARAMETERS__")(0)("REMNET6")
        Me.REMNET5 = CINLI("__PARAMETERS__")(0)("REMNET5")
        Me.REMNET4 = CINLI("__PARAMETERS__")(0)("REMNET4")
        Me.REMNET3 = CINLI("__PARAMETERS__")(0)("REMNET3")
        Me.REMNET2 = CINLI("__PARAMETERS__")(0)("REMNET2")
        Me.REMNET1 = CINLI("__PARAMETERS__")(0)("REMNET1")
        Me.IMPUNI6 = CINLI("__PARAMETERS__")(0)("IMPUNI6")
        Me.IMPUNI5 = CINLI("__PARAMETERS__")(0)("IMPUNI5")
        Me.IMPUNI4 = CINLI("__PARAMETERS__")(0)("IMPUNI4")
        Me.IMPUNI3 = CINLI("__PARAMETERS__")(0)("IMPUNI3")
        Me.IMPUNI2 = CINLI("__PARAMETERS__")(0)("IMPUNI2")
        Me.IMPUNI1 = CINLI("__PARAMETERS__")(0)("IMPUNI1")
        Me.LEYSOC6 = CINLI("__PARAMETERS__")(0)("LEYSOC6")
        Me.LEYSOC5 = CINLI("__PARAMETERS__")(0)("LEYSOC5")
        Me.LEYSOC4 = CINLI("__PARAMETERS__")(0)("LEYSOC4")
        Me.LEYSOC3 = CINLI("__PARAMETERS__")(0)("LEYSOC3")
        Me.LEYSOC2 = CINLI("__PARAMETERS__")(0)("LEYSOC2")
        Me.LEYSOC1 = CINLI("__PARAMETERS__")(0)("LEYSOC1")
        Me.FONREG6 = CINLI("__PARAMETERS__")(0)("FONREG6")
        Me.FONREG5 = CINLI("__PARAMETERS__")(0)("FONREG5")
        Me.FONREG4 = CINLI("__PARAMETERS__")(0)("FONREG4")
        Me.FONREG3 = CINLI("__PARAMETERS__")(0)("FONREG3")
        Me.FONREG2 = CINLI("__PARAMETERS__")(0)("FONREG2")
        Me.FONREG1 = CINLI("__PARAMETERS__")(0)("FONREG1")
        Me.FONSAL6 = CINLI("__PARAMETERS__")(0)("FONSAL6")
        Me.FONSAL5 = CINLI("__PARAMETERS__")(0)("FONSAL5")
        Me.FONSAL4 = CINLI("__PARAMETERS__")(0)("FONSAL4")
        Me.FONSAL3 = CINLI("__PARAMETERS__")(0)("FONSAL3")
        Me.FONSAL2 = CINLI("__PARAMETERS__")(0)("FONSAL2")
        Me.FONSAL1 = CINLI("__PARAMETERS__")(0)("FONSAL1")
        Me.FONDES6 = CINLI("__PARAMETERS__")(0)("FONDES6")
        Me.FONDES5 = CINLI("__PARAMETERS__")(0)("FONDES5")
        Me.FONDES4 = CINLI("__PARAMETERS__")(0)("FONDES4")
        Me.FONDES3 = CINLI("__PARAMETERS__")(0)("FONDES3")
        Me.FONDES2 = CINLI("__PARAMETERS__")(0)("FONDES2")
        Me.FONDES1 = CINLI("__PARAMETERS__")(0)("FONDES1")
        Me.FONPEN6 = CINLI("__PARAMETERS__")(0)("FONPEN6")
        Me.FONPEN5 = CINLI("__PARAMETERS__")(0)("FONPEN5")
        Me.FONPEN4 = CINLI("__PARAMETERS__")(0)("FONPEN4")
        Me.FONPEN3 = CINLI("__PARAMETERS__")(0)("FONPEN3")
        Me.FONPEN2 = CINLI("__PARAMETERS__")(0)("FONPEN2")
        Me.FONPEN1 = CINLI("__PARAMETERS__")(0)("FONPEN1")
        Me.RENIMP6 = CINLI("__PARAMETERS__")(0)("RENIMP6")
        Me.RENIMP5 = CINLI("__PARAMETERS__")(0)("RENIMP5")
        Me.RENIMP4 = CINLI("__PARAMETERS__")(0)("RENIMP4")
        Me.RENIMP3 = CINLI("__PARAMETERS__")(0)("RENIMP3")
        Me.RENIMP2 = CINLI("__PARAMETERS__")(0)("RENIMP2")
        Me.RENIMP1 = CINLI("__PARAMETERS__")(0)("RENIMP1")
        Me.FONSAL2 = CINLI("__PARAMETERS__")(0)("FONSAL2")
        Me.DIASNO6 = CINLI("__PARAMETERS__")(0)("DIASNO6")
        Me.PFONDES6 = CINLI("__PARAMETERS__")(0)("PFONDES6")
        Me.DIASNO5 = CINLI("__PARAMETERS__")(0)("DIASNO5")
        Me.PFONDES5 = CINLI("__PARAMETERS__")(0)("PFONDES5")
        Me.DIASNO4 = CINLI("__PARAMETERS__")(0)("DIASNO4")
        Me.PFONDES4 = CINLI("__PARAMETERS__")(0)("PFONDES4")
        Me.DIASNO3 = CINLI("__PARAMETERS__")(0)("DIASNO3")
        Me.PFONDES3 = CINLI("__PARAMETERS__")(0)("PFONDES3")
        Me.DIASNO2 = CINLI("__PARAMETERS__")(0)("DIASNO2")
        Me.PFONDES2 = CINLI("__PARAMETERS__")(0)("PFONDES2")
        Me.DIASNO1 = CINLI("__PARAMETERS__")(0)("DIASNO1")
        Me.PFONDES1 = CINLI("__PARAMETERS__")(0)("PFONDES1")
        Me.GLOMES6 = CINLI("__PARAMETERS__")(0)("GLOMES6")
        Me.GLOMES5 = CINLI("__PARAMETERS__")(0)("GLOMES5")
        Me.GLOMES4 = CINLI("__PARAMETERS__")(0)("GLOMES4")
        Me.GLOMES3 = CINLI("__PARAMETERS__")(0)("GLOMES3")
        Me.GLOMES2 = CINLI("__PARAMETERS__")(0)("GLOMES2")
        Me.GLOMES1 = CINLI("__PARAMETERS__")(0)("GLOMES1")
        Me.FONSAL2 = CINLI("__PARAMETERS__")(0)("FONSAL2")
        Me.FECISA = CINLI("__PARAMETERS__")(0)("FECISA")
        Me.FINGSE_FUN = CINLI("__PARAMETERS__")(0)("FINGSE_FUN")
        Me.GLONOMAFP = CINLI("__PARAMETERS__")(0)("GLONOMAFP")
        Me.CODAFP = CINLI("__PARAMETERS__")(0)("CODAFP")
        Me.GLONOMISA = CINLI("__PARAMETERS__")(0)("GLONOMISA")
        Me.CODISA = CINLI("__PARAMETERS__")(0)("CODISA")
        Me.TOTDIA = CINLI("__PARAMETERS__")(0)("TOTDIA")
        Me.GLONOMBRE = CINLI("__PARAMETERS__")(0)("GLONOMBRE")
        Me.GLOESTADO = CINLI("__PARAMETERS__")(0)("GLOESTADO")
        Me.NDSPAG = CINLI("__PARAMETERS__")(0)("NDSPAG")
        Me.NUMDOC = CINLI("__PARAMETERS__")(0)("NUMDOC")
        Me.MONDEV = CINLI("__PARAMETERS__")(0)("MONDEV")
        Me.FECREC = CINLI("__PARAMETERS__")(0)("FECREC")

        Return Me

    End Function

End Class

