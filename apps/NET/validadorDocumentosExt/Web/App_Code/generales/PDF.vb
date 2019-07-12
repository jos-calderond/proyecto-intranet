Imports System.Collections.Generic
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html
Imports System.Web.Script.Serialization
Imports System.Net

Public Class PDF
  Inherits System.Web.UI.Page

#Region "Atributos privados"

  Private __rutaMapping As String = ConfigurationManager.AppSettings("rutaMapping").ToString()
  Private __orientacion As String = ConfigurationManager.AppSettings("orientacion").ToString()
  Private __margen As String() = ConfigurationManager.AppSettings("margen").ToString().Split("|")
  Private __margenSuperior As Single = Utilities.MillimetersToPoints(Single.Parse(__margen(0).Substring(__margen(0).IndexOf("=") + 1)))
  Private __margenInferior As Single = Utilities.MillimetersToPoints(Single.Parse(__margen(1).Substring(__margen(1).IndexOf("=") + 1)))
  Private __margenIzquierdo As Single = Utilities.MillimetersToPoints(Single.Parse(__margen(2).Substring(__margen(2).IndexOf("=") + 1)))
  Private __margenDerecho As Single = Utilities.MillimetersToPoints(Single.Parse(__margen(3).Substring(__margen(3).IndexOf("=") + 1)))
  Private __archivoPdfBytes As Byte()
  Private __archivoPdfRuta As String
  Private __archivoPdfNombre As String

#End Region

#Region "Atributos públicos"

  Public Enum TamañoPagina
    LETTER = 1
    LEGAL = 2
    A4 = 3
    NOTE = 4
    POSTCARD = 5
  End Enum

#End Region

#Region "Propiedades públicas"

  Public ReadOnly Property NombreArchivoPDF As String
    Get
      Return Me.__archivoPdfNombre

    End Get
  End Property

  Public ReadOnly Property BytesArchivoPDF As Byte()
    Get
      Return Me.__archivoPdfBytes

    End Get
  End Property

  Public ReadOnly Property RutArchivoPDF As String
    Get
      Return Me.__archivoPdfRuta

    End Get
  End Property

#End Region

#Region "Constructores"

  Sub New(ByVal nombreArchivo As String)

    Me.__archivoPdfNombre = nombreArchivo

  End Sub

#End Region

#Region "Métodos públicos"

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="textoHTML"></param>
  ''' <param name="sizePageU"></param>
  ''' <remarks></remarks>
  Public Sub GenerarArchivo(ByVal textoHTML As String, Optional ByVal sizePageU As TamañoPagina = TamañoPagina.LETTER)

    __generar(textoHTML, sizePageU)

  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="textoHTML"></param>
  ''' <param name="sizePageU"></param>
  ''' <remarks></remarks>
  Public Sub ExportPDF(ByVal textoHTML As String, Optional ByVal sizePageU As TamañoPagina = TamañoPagina.LETTER)

    __generar(textoHTML, sizePageU)
    __desplegarPdf()

  End Sub

#End Region

#Region "Métodos privados"

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="textoHTML"></param>
  ''' <param name="sizePageU"></param>
  ''' <remarks></remarks>
  Private Sub __generar(ByVal textoHTML As String, ByVal sizePageU As String)

    Dim uploaded As Boolean = True

    'Try
    Dim rutaArchivoHTML As String = Path.Combine(__rutaMapping, Me.__archivoPdfNombre & ".html")
    Dim rutaArchivoPDF As String = Path.Combine(__rutaMapping, Me.__archivoPdfNombre & ".pdf")

    If File.Exists(rutaArchivoHTML) Then
      File.Delete(rutaArchivoHTML)
    End If

    If File.Exists(rutaArchivoPDF) Then
      File.Delete(rutaArchivoPDF)
    End If

    ' Crea archivo HTML para producir archivo PDF.

    Dim html = File.CreateText(rutaArchivoHTML)
    html.Close()
    Dim objWriter As System.IO.StreamWriter
    objWriter = My.Computer.FileSystem.OpenTextFileWriter(rutaArchivoHTML, True)
    objWriter.WriteLine(textoHTML)
    objWriter.Close()

    Dim pageS As iTextSharp.text.Rectangle = Nothing
    If (__orientacion.ToUpper = "LANSCAPE") Then
      Select Case sizePageU
        'TABLA DETALLE
        Case TamañoPagina.LETTER
          pageS = PageSize.LETTER.Rotate()
        Case TamañoPagina.LEGAL
          pageS = PageSize.LEGAL.Rotate()
        Case TamañoPagina.A4
          pageS = PageSize.A4.Rotate()
        Case TamañoPagina.NOTE
          pageS = PageSize.NOTE.Rotate()
        Case TamañoPagina.POSTCARD
          pageS = PageSize.POSTCARD.Rotate()
      End Select
    Else
      Select Case sizePageU
        'TABLA DETALLE
        Case TamañoPagina.LETTER
          pageS = PageSize.LETTER
        Case TamañoPagina.LEGAL
          pageS = PageSize.LEGAL
        Case TamañoPagina.A4
          pageS = PageSize.A4
        Case TamañoPagina.NOTE
          pageS = PageSize.NOTE
        Case TamañoPagina.POSTCARD
          pageS = PageSize.POSTCARD
      End Select
    End If

    Dim document = New Document(pageS, __margenIzquierdo, __margenDerecho, __margenSuperior, __margenInferior)
    Dim writer = PdfWriter.GetInstance(document, New FileStream(rutaArchivoPDF, FileMode.Create, FileAccess.Write, FileShare.None))

    document.Open()

    Try
      Dim contents As String = File.ReadAllText(rutaArchivoHTML)
      contents = contents.Replace("border-style: none", "border-width: 0")
      iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, New StringReader(contents))
    Catch ex As Exception
      document.Close()
      document.Dispose()

      Throw ex
    End Try

    writer.Flush()
    document.Close()

    ' Elimina archivo HTML utilizado para crear PDF.
    If File.Exists(rutaArchivoHTML) Then
      File.Delete(rutaArchivoHTML)
    End If

    ' Lee archivo PDF.
    Dim MyFileStream = New FileStream(rutaArchivoPDF, FileMode.Open, FileAccess.Read)
    Dim FileSize = MyFileStream.Length
    Dim Buffer() As Byte
    ReDim Preserve Buffer(CInt(FileSize - 1))
    MyFileStream.Read(Buffer, 0, CInt(FileSize - 1))
    MyFileStream.Close()

    ' Elimina archivo PDF luego de leer su contenido en Bytes

        'Me.__archivoPdfRuta = rutaArchivoPDF
    Me.__archivoPdfBytes = Buffer

  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub __desplegarPdf()
    With HttpContext.Current.Response
      .ClearContent()
      .ClearHeaders()
      .ContentType = "application/pdf"
      .AddHeader("Content-Length", Me.__archivoPdfBytes.Length.ToString)
      .AddHeader("Content-Disposition", "inline; filename=" & Me.__archivoPdfNombre & ".pdf")
      .BinaryWrite(Me.__archivoPdfBytes)
      .Flush()
      .Clear()
    End With
    HttpContext.Current.ApplicationInstance.CompleteRequest()
  End Sub

#End Region
End Class
