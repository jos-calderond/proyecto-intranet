Imports slbaperbDll

Namespace Tipos

  ''' <summary>
  ''' 31/05/2019 jcalderón: Creación.
  ''' </summary>
  ''' <remarks></remarks>
  Public Class oICOLI

#Region "Atributos públicos"

    Public TIPO As String = ""
    Public DIA_TRABAJ As String = ""
    Public COD_D As String = ""
    Public COD_B As String = ""
    Public COD_H As String = ""
    Public TIPFUN As String = ""
    Public RUTFUN As String = ""
    Public TIPOLIQ As String = ""
    Public MES As String = ""
    Public ANO As String = ""
    Public INST As String = ""
    Public NROBIE As String = ""
    Public FECTERVIG As String = ""
    Public FINGSE As String = ""
    Public SUEL_BASE2 As String = ""
    Public SIGNO_SB2 As String = ""
    Public SUEL_BASE1 As String = ""
    Public SUEL_BASE As String = ""
    Public SIGNO_SB As String = ""
    Public VAL_PAGO As String = ""
    Public SIGNO_PA As String = ""
    Public TOT_DESV As String = ""
    Public SIGNO_DV As String = ""
    Public TOT_DESL As String = ""
    Public SIGNO_DL As String = ""
    Public SIGNO_SB1 As String = ""
    Public TOT_HAB As String = ""
    Public SIGNO_TH As String = ""
    Public GLOCCOSTO As String = ""
    Public CCOSTO As String = ""
    Public HORAS As String = ""
    Public NIVEL As String = ""
    Public CAT As String = ""
    Public GLOPLANTA As String = ""
    Public POR_IS As String = ""
    Public GLO_IS As String = ""
    Public CODISA As String = ""
    Public MONPLA As String = ""
    Public COPLAN As String = ""
    Public VAL_AFP As String = ""
    Public GLO_AFP As String = ""
    Public CODAFP As String = ""
    Public VAL_IMPON As String = ""
    Public SIGNO_VI As String = ""
    Public GLOGRADO As String = ""
    Public CODGRADO As String = ""
    Public CODPLANTA As String = ""
    Public NOMBRET As String = ""
    Public APEMATT As String = ""
    Public APEPATT As String = ""
    Public GLO_MES As String = ""
    Public VALDV As String = ""
    Public SIGNO_D As String = ""
    Public NOMDV As String = ""
    Public VALDL As String = ""
    Public SIGNO_B As String = ""
    Public NOMDL As String = ""
    Public VALHAB As String = ""
    Public SIGNO_H As String = ""
    Public NOMHAB As String = ""

#End Region

#Region "Constructores"

    Sub New()
    End Sub

    Private Sub __IspecToModel(ByVal Ispec As ICOLI)

      Me.ANO = Ispec.ANO
      Me.COD_B = Ispec.COD_B
      Me.COD_D = Ispec.COD_D
      Me.COD_H = Ispec.COD_H
      Me.DIA_TRABAJ = Ispec.DIA_TRABAJ
      Me.INST = Ispec.INST
      Me.MES = Ispec.MES
      Me.RUTFUN = Ispec.RUTFUN
      Me.TIPFUN = Ispec.TIPFUN
      Me.TIPO = Ispec.TIPO
      Me.TIPOLIQ = Ispec.TIPOLIQ
      Me.APEMATT = Ispec.APEMATT
      Me.APEPATT = Ispec.APEPATT
      Me.CAT = Ispec.CAT
      Me.CCOSTO = Ispec.CCOSTO
      Me.CODAFP = Ispec.CODAFP
      Me.CODGRADO = Ispec.CODGRADO
      Me.CODISA = Ispec.CODISA
      Me.CODPLANTA = Ispec.CODPLANTA
      Me.COPLAN = Ispec.COPLAN
      Me.FECTERVIG = Ispec.FECTERVIG
      Me.FINGSE = Ispec.FINGSE
      Me.GLO_AFP = Ispec.GLO_AFP
      Me.GLO_IS = Ispec.GLO_IS
      Me.GLO_MES = Ispec.GLO_MES
      Me.GLOCCOSTO = Ispec.GLOCCOSTO
      Me.GLOGRADO = Ispec.GLOGRADO
      Me.GLOPLANTA = Ispec.GLOPLANTA
      Me.HORAS = Ispec.HORAS
      Me.MONPLA = Ispec.MONPLA
      Me.NIVEL = Ispec.NIVEL
      Me.NOMBRET = Ispec.NOMBRET
      Me.NOMDL = Ispec.NOMDL
      Me.NOMDV = Ispec.NOMDV
      Me.NOMHAB = Ispec.NOMHAB
      Me.NROBIE = Ispec.NROBIE
      Me.POR_IS = Ispec.POR_IS
      Me.SIGNO_B = Ispec.SIGNO_B
      Me.SIGNO_D = Ispec.SIGNO_D
      Me.SIGNO_DL = Ispec.SIGNO_DL
      Me.SIGNO_DV = Ispec.SIGNO_DV
      Me.SIGNO_H = Ispec.SIGNO_H
      Me.SIGNO_PA = Ispec.SIGNO_PA
      Me.SIGNO_SB = Ispec.SIGNO_SB
      Me.SIGNO_SB1 = Ispec.SIGNO_SB1
      Me.SIGNO_SB2 = Ispec.SIGNO_SB2
      Me.SIGNO_TH = Ispec.SIGNO_TH
      Me.SIGNO_VI = Ispec.SIGNO_VI
      Me.SUEL_BASE = Ispec.SUEL_BASE
      Me.SUEL_BASE1 = Ispec.SUEL_BASE1
      Me.SUEL_BASE2 = Ispec.SUEL_BASE2
      Me.TOT_DESL = Ispec.TOT_DESL
      Me.TOT_DESV = Ispec.TOT_DESV
      Me.TOT_HAB = Ispec.TOT_HAB
      Me.VAL_AFP = Ispec.VAL_AFP
      Me.VAL_IMPON = Ispec.VAL_IMPON
      Me.VAL_PAGO = Ispec.VAL_PAGO
      Me.VALDL = Ispec.VALDL
      Me.VALDV = Ispec.VALDV
      Me.VALHAB = Ispec.VALHAB

    End Sub


    Friend Sub New(ByVal miICOLICFType As ICOLI.CFType)

      VALDV = miICOLICFType.VALDV
      SIGNO_D = miICOLICFType.SIGNO_D
      NOMDV = miICOLICFType.NOMDV
      VALDL = miICOLICFType.VALDL
      SIGNO_B = miICOLICFType.SIGNO_B
      NOMDL = miICOLICFType.NOMDL
      VALHAB = miICOLICFType.VALHAB
      SIGNO_H = miICOLICFType.SIGNO_H
      NOMHAB = miICOLICFType.NOMHAB

    End Sub

#End Region

#Region "Métodos privados"

    Private Function __callIspec(ByVal Ispec As ICOLI) As List(Of ICOLI.CFType)
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

    Private Function __ModelToIspec() As ICOLI

      Dim Ispec As New ICOLI()

      Ispec.ANO = Me.ANO
      Ispec.COD_B = Me.COD_B
      Ispec.COD_D = Me.COD_D
      Ispec.COD_H = Me.COD_H
      Ispec.DIA_TRABAJ = Me.DIA_TRABAJ
      Ispec.INST = Me.INST
      Ispec.MES = Me.MES
      Ispec.RUTFUN = Me.RUTFUN
      Ispec.TIPFUN = Me.TIPFUN
      Ispec.TIPO = Me.TIPO
      Ispec.TIPOLIQ = Me.TIPOLIQ
      Ispec.APEMATT = Me.APEMATT
      Ispec.APEPATT = Me.APEPATT
      Ispec.CAT = Me.CAT
      Ispec.CCOSTO = Me.CCOSTO
      Ispec.CODAFP = Me.CODAFP
      Ispec.CODGRADO = Me.CODGRADO
      Ispec.CODISA = Me.CODISA
      Ispec.CODPLANTA = Me.CODPLANTA
      Ispec.COPLAN = Me.COPLAN
      Ispec.FECTERVIG = Me.FECTERVIG
      Ispec.FINGSE = Me.FINGSE
      Ispec.GLO_AFP = Me.GLO_AFP
      Ispec.GLO_IS = Me.GLO_IS
      Ispec.GLO_MES = Me.GLO_MES
      Ispec.GLOCCOSTO = Me.GLOCCOSTO
      Ispec.GLOGRADO = Me.GLOGRADO
      Ispec.GLOPLANTA = Me.GLOPLANTA
      Ispec.HORAS = Me.HORAS
      Ispec.MONPLA = Me.MONPLA
      Ispec.NIVEL = Me.NIVEL
      Ispec.NOMBRET = Me.NOMBRET
      Ispec.NOMDL = Me.NOMDL
      Ispec.NOMDV = Me.NOMDV
      Ispec.NOMHAB = Me.NOMHAB
      Ispec.NROBIE = Me.NROBIE
      Ispec.POR_IS = Me.POR_IS
      Ispec.SIGNO_B = Me.SIGNO_B
      Ispec.SIGNO_D = Me.SIGNO_D
      Ispec.SIGNO_DL = Me.SIGNO_DL
      Ispec.SIGNO_DV = Me.SIGNO_DV
      Ispec.SIGNO_H = Me.SIGNO_H
      Ispec.SIGNO_PA = Me.SIGNO_PA
      Ispec.SIGNO_SB = Me.SIGNO_SB
      Ispec.SIGNO_SB1 = Me.SIGNO_SB1
      Ispec.SIGNO_SB2 = Me.SIGNO_SB2
      Ispec.SIGNO_TH = Me.SIGNO_TH
      Ispec.SIGNO_VI = Me.SIGNO_VI
      Ispec.SUEL_BASE = Me.SUEL_BASE
      Ispec.SUEL_BASE1 = Me.SUEL_BASE1
      Ispec.SUEL_BASE2 = Me.SUEL_BASE2
      Ispec.TOT_DESL = Me.TOT_DESL
      Ispec.TOT_DESV = Me.TOT_DESV
      Ispec.TOT_HAB = Me.TOT_HAB
      Ispec.VAL_AFP = Me.VAL_AFP
      Ispec.VAL_IMPON = Me.VAL_IMPON
      Ispec.VAL_PAGO = Me.VAL_PAGO
      Ispec.VALDL = Me.VALDL
      Ispec.VALDV = Me.VALDV
      Ispec.VALHAB = Me.VALHAB

      Return Ispec

    End Function

#Region "Métodos públicos"

    Public Function consultaMasiva(ByVal RUTFUN As String, ByVal INSTITUCION As String, ByVal TIPOLIQUIDACION As String, ByVal ANO As String, ByVal MES As String) As List(Of oICOLI)

      Dim miICOLI As New ICOLI()
      Dim lista As New List(Of oICOLI)

      miICOLI.RUTFUN = RUTFUN.Replace(".", "").PadLeft(10, " ")
      miICOLI.TIPOLIQ = TIPOLIQUIDACION
      miICOLI.MES = MES
      miICOLI.ANO = ANO
      miICOLI.INST = INSTITUCION

      For Each reg As ICOLI.CFType In Me.__callIspec(miICOLI)
        lista.Add(New oICOLI(reg))
      Next

      Return lista

    End Function

    Public Sub consultar(ByVal RUTFUN As String, ByVal INSTITUCION As String, ByVal TIPOLIQUIDACION As String, ByVal ANO As String, ByVal MES As String)

      Dim miIspec As New ICOLI()

      miIspec.RUTFUN = RUTFUN.Replace(".", "").PadLeft(10, " ")
      miIspec.INST = INSTITUCION
      miIspec.TIPOLIQ = TIPOLIQUIDACION
      miIspec.ANO = ANO
      miIspec.MES = MES

      __IspecToModel(Me.__callIspecInquiry(miIspec))

    End Sub

#End Region

    Private Function __callIspecInquiry(ByVal Ispec As ICOLI) As ICOLI
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
  End Class

End Namespace

