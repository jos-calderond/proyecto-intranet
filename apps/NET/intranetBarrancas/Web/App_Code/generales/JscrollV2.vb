Imports Microsoft.VisualBasic
Imports System.Collections.Generic

''' <summary>
''' JScrollV2 - Infinite Scrolling / Lazy Loading
''' rev.18 Trunk
''' </summary>
''' <remarks></remarks>
Public Class JScrollV2

#Region "Atributos privados"

  Private Const HTML_START As String = "<div id=""jscroll-responsive-table""><table class=""jscroll-table table table-striped table-bordered table-hover dataTable no-footer dtr-inline tablesorter"" border=""0"" style=""width:100%;table-layout:fixed;"" role=""grid"">"
  Private Const HTML_END As String = "</table></div>"
  Private Const HTML_TH_ESSELECCIONMULTIPLE As String = "<th style=""width:10px;text-align:center; word-wrap: break-word; white-space: pre-wrap;""><input type=""checkbox"" class=""px-checkbox"" onchange=""__jscroll_checkuncheckall(this);"" /></th>"
  Private Const HTML_TD_ESSELECCIONMULTIPLE As String = "<td subgrid=""0"" data-title=""Seleccionar"" style=""width:10px;text-align:center; word-wrap: break-word; white-space: pre-wrap; vertical-align:middle;"" class=""selection""><input type=""checkbox"" class=""px-checkbox"" /></td>"
  Private Const JSCRIPT_OPEN_TAG As String = "<script type='text/javascript'>"
  Private Const JSCRIPT_CLOSE_TAG As String = "</script>"
  Private Const JSCRIPT_REORGANIZE_SCRIPT As String = "__jscroll_reorganize_table"

  Private __Request As HttpRequest
  Private __CallerPage As String = ""
  Private __Accion As String = ""
  Private __Target As String = ""
  Private __EsSeleccionMultiple As Boolean = False
  Private __EsModal As Boolean = False
  Private __Nombre As String = ""
  Private __Secuencia As Integer = 1
  Private __AutoTrigger As Boolean = False
  Private __EsCarga As Boolean = False

  ''' <summary>
  ''' Parámetros que recibirá función javascript tablesorter() cuando la grilla sea de selección múltiple.
  ''' </summary>
  ''' <remarks></remarks>
  Private __SmTsParams As String = ""

  ''' <summary>
  ''' Parámetros que recibirá función javascript tablesorter() cuando la grilla sea sin selección múltiple.
  ''' En script javascript se debe setear una variable ejemplo:
  '''    var tablesorter_parametros1 = { headers: { 1: { sorter: 'digit'}} };
  ''' Significa que ordenará la columna 1 según número.
  '''    var tablesorter_parametros1 = { headers: { 4: { sorter: 'uk-date'}} };
  ''' Significa que ordenará la columna 4 según fecha dd/MM/yyyyy.
  ''' Luego se entrega el valor del nombre de la variable en objeto javascript "link":
  '''    link.tsparams = 'tablesorter_parametros1'; 
  ''' El índice de la columna empieza en 0 aunque la columna esté invisible.
  ''' </summary>
  ''' <remarks></remarks>
  Private __TsParams As String = ""

  Private __Js As New Script.Serialization.JavaScriptSerializer

#End Region

#Region "Atributos públicos"

  Public AddSequenceField As Boolean = False
  Public Data As Object = Nothing
  Public Fields As New List(Of myField)
  Public RowConfiguration As myRow
  Public SkipDuplicatedFirstRow As Boolean = True

#End Region

  ''' <summary>
  ''' Retorna el nombre identificatorio de la grilla.
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property ScrollName As String
    Get
      Return __Nombre

    End Get
  End Property

  ''' <summary>
  ''' Retorna función javascript que se ejecuta luego de obtener set de datos con objeto javascript jscroll.
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private ReadOnly Property __AfterLoadScript As String
    Get
      Return JSCRIPT_OPEN_TAG & JSCRIPT_REORGANIZE_SCRIPT & "('" & __Nombre & "', " & IIf(__EsSeleccionMultiple, 1, 0) & ", " & IIf(__AutoTrigger, 1, 0) & ", " & IIf(__TsParams = "", "''", __TsParams) & ", " & IIf(__SmTsParams = "", "''", __SmTsParams) & ");" & JSCRIPT_CLOSE_TAG
    End Get
  End Property

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetMyGrid() As String
    Try

      __Js.MaxJsonLength = 50000000
      Dim _serializedRow As Object() = DirectCast(__Js.DeserializeObject(__Js.Serialize(Data)), Object())

      If _serializedRow.Length = 0 And __EsCarga = True Then
        Return "No hay datos"

      End If
      If (_serializedRow.Length = 0 Or _serializedRow.Length = 1) And __EsCarga = False Then
        Return "No hay más datos"

      End If

      Dim rowObject As New Object
      Dim grid As New StringBuilder()

      grid.Append(HTML_START)
      If (__EsCarga) Then

        ' Pone los botones.
        grid.AppendLine(__GetButtons())
        ' Pone los títulos.
        grid.AppendLine(myRow.HEAD_START)
        grid.AppendLine(myRow.HEAD_ROW_START)
        If __EsSeleccionMultiple Then
          grid.AppendLine(HTML_TH_ESSELECCIONMULTIPLE)
        End If
        For Each field As myField In RowConfiguration.Fields
          If Not field.JustForLink Then
            grid.AppendLine(field.ThHtml)
          End If
        Next
        grid.AppendLine(myRow.HEAD_ROW_END)
        grid.AppendLine(myRow.HEAD_END)
      End If

      ' Registros.
      grid.AppendLine(myRow.BODY_START)
      For i As Integer = 0 To _serializedRow.Length - 1

        If (i = 0 And __EsCarga = False And SkipDuplicatedFirstRow) Then
          Continue For
        End If

        rowObject = _serializedRow(i)
        grid.AppendLine(RowConfiguration.Tr(__Secuencia))

        If __EsSeleccionMultiple Then
          grid.AppendLine(HTML_TD_ESSELECCIONMULTIPLE)
        End If

        ' Campos
        For Each field As myField In RowConfiguration.Fields
          ' Si es un campo customizado.
          If Not field.CustomFieldFunction = Nothing Then
            field.Value = field.CustomFieldFunction(rowObject, __Secuencia)

            If Not field.JustForLink Then
              grid.AppendLine(field.TdHtml())
            End If

          Else
            If Not field.FieldFunction = Nothing Then
              field.Value = field.FieldFunction(rowObject(field.Name), __Secuencia)
            Else
              Try
                field.Value = rowObject(field.Name)
              Catch ex As KeyNotFoundException
                field.Value = ex.Message
              End Try
            End If
            If Trim(field.Value).Length = 0 Then
              field.Value = ""
            End If

            If Not field.JustForLink Then
              grid.AppendLine(field.TdHtml())
            End If

          End If
        Next

        grid.Append(__SubGrid(rowObject, __Secuencia))

        grid.AppendLine(myRow.BODY_ROW_END)

        __Secuencia = __Secuencia + 1
      Next
      grid.AppendLine(myRow.BODY_END)
      grid.AppendLine(HTML_END)

      ' Link time
      If (_serializedRow.Length > 0) Then
        rowObject = _serializedRow(_serializedRow.Length - 1)

        grid.AppendLine(__GenerateLink(rowObject))

      End If
      Return grid.ToString() & __AfterLoadScript

    Catch ex As Exception
      Return ex.Message
    End Try

  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="RowObject"></param>
  ''' <param name="Secuencia"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function __SubGrid(ByVal RowObject As Object, ByVal Secuencia As Integer) As String

    If RowConfiguration.Fields.FindAll(Function(d) d.ToSubgrid = True And d.JustForLink = False).Count = 0 Then
      Return ""
    End If

    Dim grid As New StringBuilder()
    Dim colspan As Integer = RowConfiguration.Fields.FindAll(Function(d) d.IsVisible = True And d.JustForLink = False).Count + IIf(__EsSeleccionMultiple, 1, 0)

    grid.Append("<tr id=""subgrid_" & __Nombre & "_" & Secuencia & """ class=""jscroll-subgrid-tr"" style=""display:none;cursor:pointer;"" ondblclick=""javascript: __jscroll_show_subgrid('" & __Nombre & "', '" & Secuencia & "');"">")

    grid.Append("<td class=""jscroll-subgrid-td"" colspan='" & colspan & "'>")

    grid.AppendLine("<table class=""jscroll-subgrid-table table table-striped table-bordered table-hover dataTable no-footer dtr-inline"" border=""0"" role=""grid"">")

    For Each field As myField In RowConfiguration.Fields.FindAll(Function(d) d.ToSubgrid = True And d.JustForLink = False)
      grid.AppendLine("<tr class=""jscroll-subgrid-table-tr"" role=""row"" style=""cursor: pointer;""><td class=""jscroll-subgrid-table-td""><b>" & field.Title & "</b></td><td class=""jscroll-subgrid-table-td"" style=""width:80%;"">" & field.Value & "</td></tr>")

    Next

    grid.Append("</table>")

    grid.AppendLine("</td></tr>")

    Return grid.ToString()

  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="lastRowObject"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function __GenerateLink(ByVal lastRowObject As Object) As String
    Dim link As New StringBuilder()
    Dim atLeastOnIncluded As Boolean = False

    link.Append("<a id=""jscroll_" & __Nombre & "_alink"" href=""" & __CallerPage & "?")
    link.Append("scrollname=" & __Nombre & "&")
    link.Append("accion=" & __Accion & "&")
    link.Append("secuencia=" & __Secuencia & "&")
    link.Append("target=" & __Target & "&")
    link.Append("escarga=0&")
    link.Append("esmodal=" & IIf(__EsModal, 1, 0) & "&")
    link.Append("esseleccionmultiple=" & IIf(__EsSeleccionMultiple, 1, 0) & "&")
    link.Append("autotrigger=" & IIf(__AutoTrigger, 1, 0) & "&")
    link.Append("tsparams=" & __TsParams & "&")
    link.Append("smtsparams=" & __SmTsParams & "&")

    For Each field As myField In RowConfiguration.Fields
      If field.ToIncludeInLink Or field.JustForLink Then
        link.Append("&" & IIf(field.LinkAlias = "", field.Name, field.LinkAlias) & "=" & HttpUtility.UrlEncode(field.Value))
        atLeastOnIncluded = True

      End If
    Next

    link.Append(""">Siguiente >></a>")

    If Not atLeastOnIncluded Then
      link.Clear()

    End If

    Return link.ToString()

  End Function

#Region "Constructores"

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="request"></param>
  ''' <param name="callerPage"></param>
  ''' <remarks></remarks>
  Public Sub New(ByVal request As HttpRequest, ByVal callerPage As String)
    __Request = request
    __CallerPage = callerPage

    __Accion = __Request.QueryString("accion")
    __Target = __Request.QueryString("target")
    __EsCarga = __GetQueryString("escarga", __EsCarga)
    __Nombre = __GetQueryString("scrollname", __Nombre)
    __EsModal = __GetQueryString("esmodal", __EsModal)
    __EsSeleccionMultiple = __GetQueryString("esseleccionmultiple", __EsSeleccionMultiple)
    __AutoTrigger = __GetQueryString("autotrigger", __AutoTrigger)
    __Secuencia = __GetQueryString("secuencia", __Secuencia)
    __TsParams = __GetQueryString("tsparams", __TsParams)
    __SmTsParams = __GetQueryString("smtsparams", __SmTsParams)

  End Sub

#End Region

#Region "Funciones públicas"

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="QueryStringName"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetQueryString(ByVal QueryStringName As String) As String
    Return __GetQueryString(QueryStringName, "")
  End Function

#End Region

#Region "Funciones privadas"

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function __GetButtons() As String
    Dim buttonsHtml As New StringBuilder()
    buttonsHtml.AppendLine("<div class=""dt-buttons"" style=""width: 100%; margin: 0 auto;"">")
    buttonsHtml.AppendLine("  <div style=""float:left;"">")
    buttonsHtml.AppendLine("    <i onclick=""javascript: __jscroll_button_handler('" & __Nombre & "', 'excel');"" tabindex=""0"" title=""Exportar a Excel"" class=""fa fa-file-excel-o"" style=""font-size:30px;color:green;cursor:pointer;""></i>")
    buttonsHtml.AppendLine("  </div>")
    buttonsHtml.AppendLine("  <div style=""float:right;"">")
    buttonsHtml.AppendLine("    <input type=""text"" id=""" & __Nombre & "_Filter" & """ name=""" & __Nombre & "_Filter" & """ onkeyup=""__jscroll_filter('" & __Nombre & "','" & __Nombre & "_Filter" & "')"" placeholder=""Buscar texto..""  class=""form-control"">")
    buttonsHtml.AppendLine("  </div>")
    buttonsHtml.AppendLine("</div>")
    Return buttonsHtml.ToString()
  End Function

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="QueryStringName"></param>
  ''' <param name="DefaultValue"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function __GetQueryString(ByVal QueryStringName As String, ByVal DefaultValue As Object) As String
    If (__Request.QueryString(QueryStringName)) = Nothing Then
      Return DefaultValue
    Else
      Return __Request.QueryString(QueryStringName).ToString()
    End If

  End Function

#End Region

#Region "Funciones compartidas"

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Shared Function JSCRIPT(Optional ByVal version As Integer = 0) As String
    Dim jscripts As New StringBuilder()

    jscripts.AppendLine("<link href=""../css/jscroll/style.css?v=" & version & """ rel=""stylesheet"" />")
    jscripts.AppendLine("<script src=""../js/jscroll/tableExport-custom/tableExport.js?v=" & version & """ type=""text/javascript""></script>")
    jscripts.AppendLine("<script src=""../js/jscroll/tableExport-custom/jquery.base64.js?v=" & version & """ type=""text/javascript""></script>")
    jscripts.AppendLine("<script src=""../js/jscroll/tableExport-custom/jspdf/libs/sprintf.js?v=" & version & """ type=""text/javascript""></script>")
    jscripts.AppendLine("<script src=""../js/jscroll/tableExport-custom/jspdf/jspdf.js?v=" & version & """ type=""text/javascript""></script>")
    jscripts.AppendLine("<script src=""../js/jscroll/tableExport-custom/jspdf/libs/base64.js?v=" & version & """ type=""text/javascript""></script>")
    jscripts.AppendLine("<script src=""../js/jscroll/jquery.jscroll.min.js?v=" & version & """ type=""text/javascript""></script>")
    jscripts.AppendLine("<script src=""../js/jscroll/jscroll.client.min.js?v=" & version & """ type=""text/javascript""></script>")
    jscripts.AppendLine("<script src=""../js/jscroll/jquery.tablesorter.js?v=" & version & """ type=""text/javascript""></script>")
    Return jscripts.ToString()
  End Function

#End Region

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <remarks></remarks>
  Public Class myField

    Const COL_WIDTH As Integer = 0

    Const TD_START As String = "<td subgrid=""0"" class=""jscroll-td"" data-title=""##title##"" is-text=""##istext##"" align=""##alignment##"">"
    Const TD_END As String = "</td>"
    Const TH_START As String = "<th class=""jscroll-th"" width=""##width##%"" is-text=""##istext##"">"
    Const TH_END As String = "</th>"
    Const HIDDEN_TD_START As String = "<td subgrid=""0"" class=""jscroll-td"" style=""display:none;"">"
    Const HIDDEN_TH_START As String = "<th class=""jscroll-th"" style=""display:none;"">"

    Public Name As String = ""
    Public Value As String = ""
    Public Title As String = ""
    Public IsVisible As Boolean = True
    Public ToIncludeInLink As Boolean = False
    Public JustForLink As Boolean = False
    Public LinkAlias As String = ""
    Public ToSubgrid As Boolean = False
    Public IsText As Boolean = True

    Private __Width As Integer = 0
    Private __Alignment As FieldAlignment = FieldAlignment.Left

    Public Enum FieldAlignment
      Left = 0
      Right = 1
      Center = 2
    End Enum

    ''' <summary>
    ''' Maneja la alineación del contenido del campo.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Alignment As FieldAlignment
      Get
        Return __Alignment
      End Get
      Set(value As FieldAlignment)
        __Alignment = value
      End Set
    End Property

    ''' <summary>
    ''' Maneja el ancho de la columna. %.
    ''' </summary>
    ''' <value>Valor entero [0-100]. En 0 el ancho de la columna es proporcional a la cantidad de columnas.</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Width As Integer
      Get
        Return __Width
      End Get
      Set(value As Integer)
        If value > 100 Then
          value = 100
        End If
        If value < 0 Then
          value = 0
        End If
        If value = 0 Then
          value = COL_WIDTH
        End If

        __Width = value
      End Set
    End Property

    ''' <summary>
    ''' Ej.: Convierte el valor del campo en fecha.
    ''' Function(fieldValue As String, rowSequence As Integer) As String
    '''   Return Funciones.gFormatDate(fieldValue)
    ''' End Function
    ''' </summary>
    ''' <remarks></remarks>
    Public FieldFunction As Func(Of String, Integer, String) = Nothing

    ''' <summary>
    ''' Ej.: Convierte el valor del campo en fecha.
    ''' Function(rowDataObject As Object, rowSequence As Integer) As String
    '''  Return Funciones.gFormatDate(rowDataObject("CUALQUIER_CAMPO_DE_LA_FILA"))
    ''' End Function
    ''' </summary>
    ''' <remarks></remarks>
    Public CustomFieldFunction As Func(Of Object, String, String) = Nothing

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ObjectAttributeName"></param>
    ''' <param name="TitleName"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal ObjectAttributeName As String, ByVal TitleName As String)
      Name = ObjectAttributeName
      Title = TitleName
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TdHtml() As String
      Get
        Dim text As String = ""

        If IsVisible Then
          text = TD_START.Replace("##title##", Title) & Value & TD_END
        Else
          text = HIDDEN_TD_START & Value & TD_END
        End If
        If IsText Then
          text = text.Replace("##istext##", "true")
        Else
          text = text.Replace("##istext##", "false")
        End If

        Select Case Me.Alignment
          Case FieldAlignment.Left
            text = text.Replace("##alignment##", "left")
          Case FieldAlignment.Right
            text = text.Replace("##alignment##", "right")
          Case FieldAlignment.Center
            text = text.Replace("##alignment##", "center")
        End Select

        Return text
      End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ThHtml() As String
      Get
        Dim text As String = ""
        If IsVisible Then
          text = TH_START & Title & TH_END
        Else
          text = HIDDEN_TH_START & Title & TH_END
        End If
        If IsText Then
          text = text.Replace("##istext##", "true")
        Else
          text = text.Replace("##istext##", "false")
        End If
        text = text.Replace("##width##", Me.Width.ToString)
        Return text
      End Get
    End Property

  End Class

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <remarks></remarks>
  Public Class myRow

    Friend Const HEAD_START As String = "<thead class=""jscroll-thead"">"
    Friend Const HEAD_ROW_START As String = "<tr class=""jscroll-thead-tr"" role=""row"">"
    Friend Const HEAD_ROW_END As String = "</tr>"
    Friend Const HEAD_END As String = "</thead>"
    Friend Const BODY_START As String = "<tbody class=""jscroll-tbody"">"
    Friend Const BODY_ROW_START As String = "<tr class=""jscroll-tr"">"
    Friend Const BODY_ROW_END As String = "</tr>"
    Friend Const BODY_END As String = "</tbody>"

    Private __Request As HttpRequest = Nothing
    Private __Nombre As String = ""

    Public Fields As New List(Of myField)

    Public OnDblclickJsFunction As String = ""
    Public OnDblclickJsTarget As String = ""
    Public OnDeleteJsFunction As String = ""

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="request"></param>
    ''' <remarks></remarks>
    Sub New(ByVal request As HttpRequest)
      __Request = request
      __Nombre = __GetQueryString("scrollname", __Nombre)

      OnDblclickJsTarget = __Request.QueryString("target")

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Secuencia"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property Tr(ByVal Secuencia As Integer) As String
      Get
        Dim jsRow As String = "<tr"
        If Not __Nombre = "" Then
          jsRow = jsRow & " id='grid_" & __Nombre & "_" & Secuencia.ToString() & "'"
        End If
        If Not OnDblclickJsFunction = "" Then
          jsRow = jsRow & " ondblclick=""javascript: __jscroll_execute_dblclick_function(this, '" & OnDblclickJsFunction & "', "
          If Not OnDblclickJsTarget = "" Then
            jsRow = jsRow & "'" & OnDblclickJsTarget + "');"""
          Else
            jsRow = jsRow & "null);"""
          End If
        End If
        jsRow = jsRow & " class=""jscroll-tr"" onclick=""javascript: __jscroll_show_subgrid('" & __Nombre & "', '" & Secuencia & "');"">"

        Return jsRow
      End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="QueryStringName"></param>
    ''' <param name="DefaultValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function __GetQueryString(ByVal QueryStringName As String, ByVal DefaultValue As Object) As String
      If (__Request.QueryString(QueryStringName)) = Nothing Then
        Return DefaultValue
      Else
        Return __Request.QueryString(QueryStringName).ToString()
      End If

    End Function
  End Class

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <remarks></remarks>
  Public Class myEditLink
    Private __jsFunction As String = ""

    Sub New(ByVal jsFunction As String)
      __jsFunction = jsFunction
    End Sub

    Public ReadOnly Property HTML As String
      Get
        Return "<span class=""glyphicon glyphicon-edit fa-w-18 fa-2x"" style=""color:green; cursor:pointer;"" onclick=""__jscroll_execute_dblclick_function(this.parentElement.parentElement, '" & __jsFunction & "', this);"" title=""Editar""></span>"
      End Get
    End Property
  End Class

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <remarks></remarks>
  Public Class myDeleteLink
    Private __jsFunction As String = ""

    Sub New(ByVal jsFunction As String)
      __jsFunction = jsFunction
    End Sub

    Public ReadOnly Property HTML As String
      Get
        Return "<span class=""glyphicon glyphicon-trash fa-w-18 fa-2x"" style=""color:red; cursor:pointer;"" onclick=""__jscroll_execute_delete_function(this.parentElement.parentElement, '" & __jsFunction & "', this);"" title=""Eliminar""></span>"
      End Get
    End Property
  End Class

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <remarks></remarks>
  Public Class aLink
    Private __jsFunction As String = ""
    Private __icon As String = ""
    Private __title As String = ""
    Private __color As String = ""

    Sub New(ByVal jsFunction As String, ByVal icon As String, ByVal title As String, ByVal color As String)
      __jsFunction = jsFunction
      __icon = icon
      __title = title
      __color = color
    End Sub

    Public ReadOnly Property HTML As String
      Get
        Return "<span class=""" & __icon & " fa-w-18 fa-2x"" style=""color:" & __color & "; cursor:pointer;"" onclick=""__jscroll_execute_dblclick_function(this.parentElement.parentElement, '" & __jsFunction & "', this);"" title=""" & __title & """></span>"
      End Get
    End Property
  End Class

End Class