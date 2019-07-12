Imports System.Collections.Generic

Public Class MenuBuilder
  Shared items As Object = ConfigurationManager.GetSection("ItemDelMenu")
  Shared paginas As Object = ConfigurationManager.GetSection("PaginasDelMenu")
  Shared paginasPorItem As Object = ConfigurationManager.GetSection("PaginasPorItem")
  Shared titulosPaginas As Object = ConfigurationManager.GetSection("TitulosPagina")

  Shared Function RetrieveMenu() As String

    Dim menu As String = ""

    For Each item In items

      ' Closed menu by default
      menu = menu & "<li class=''><a href='./'>" & items(item)
      menu = menu & "<span style='font-size:16px;' class='pull-right hidden-xs showopacity fa fa-shield'></span></a>"
      menu = menu & "<ul class='nav nav-second-level collapse' aria-expanded='false' style='height: 0px;'>"

      For Each paginaPorItem In paginasPorItem
        If item = paginasPorItem(paginaPorItem) Then
          menu = menu & "<li><a href='./" & paginas(paginaPorItem) & "'>" & paginaPorItem & "</a></li>"
        End If
      Next
      menu = menu & "</ul>"
      menu = menu & "</li>"
    Next

    Return menu
  End Function

  Shared Function RetrieveOpenedTwoLevelMenu() As String

    Dim menu As String = ""

    For Each item In items

      ' Opened menu by default
      menu = menu & "<li class='active'><a href='./'>" & items(item)
      menu = menu & "<span style='font-size:16px;' class='pull-right hidden-xs showopacity fa fa-shield'></span></a>"
      menu = menu & "<ul class='nav nav-second-level collapse in' aria-expanded='true'>"

      For Each paginaPorItem In paginasPorItem
        If item = paginasPorItem(paginaPorItem) Then
          menu = menu & "<li><a href='./" & paginas(paginaPorItem) & "'>" & paginaPorItem & "</a></li>"
        End If
      Next

      menu = menu & "</ul>"
      menu = menu & "</li>"
    Next

    Return menu
  End Function

  ''' <summary>
  ''' 07/06/2019 croman: Creación.
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Shared Function RetrieveOpenedTwoLevelMenu(ByVal accesos As List(Of String)) As String

    Dim menu As String = ""

    For Each item In items

      ' Opened menu by default
      menu = menu & "<li class='active' ><a href='./'>" & items(item)
      menu = menu & "<span style='font-size:16px;' class='pull-right hidden-xs showopacity fa fa-shield'></span></a>"
      menu = menu & "<ul class='nav nav-second-level collapse in' aria-expanded='true'>"

      For Each paginaPorItem In paginasPorItem
        If item = paginasPorItem(paginaPorItem) Then
          If accesos.Contains(paginaPorItem) Then
            menu = menu & "<li><a href='./" & paginas(paginaPorItem) & "'>" & titulosPaginas(paginaPorItem) & "</a></li>"
          End If
        End If
      Next

      menu = menu & "</ul>"
      menu = menu & "</li>"
    Next

    Return menu
  End Function

  ''' <summary>
  ''' 28/06/2019 croman: Creación.
  ''' </summary>
  ''' <param name="accesos"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Shared Function RetrieveClosedTwoLevelMenu(ByVal accesos As List(Of String)) As String

    Dim menu As String = ""

    For Each item In items

      ' Closed menu by default
      menu = menu & "<li class='' ><a href='./'>" & items(item)
      menu = menu & "<span style='font-size:16px;' class='pull-right hidden-xs showopacity fa fa-shield'></span></a>"
      menu = menu & "<ul class='nav nav-second-level collapse' aria-expanded='false'>"

      For Each paginaPorItem In paginasPorItem
        If item = paginasPorItem(paginaPorItem) Then
          If accesos.Contains(paginaPorItem) Then
            menu = menu & "<li><a href='./" & paginas(paginaPorItem) & "'>" & titulosPaginas(paginaPorItem) & "</a></li>"
          End If
        End If
      Next

      menu = menu & "</ul>"
      menu = menu & "</li>"
    Next

    Return menu
  End Function

  Shared Function RetrieveOneLevelMenu() As String

    Dim menu As String = ""

    menu = "<ul class='nav nav-second-level' aria-expanded='true'>"
    ' One level
    For Each paginaPorItem In paginas
      menu = menu & "<li class='active'><a href='./" & paginas(paginaPorItem) & "'>" & paginaPorItem & "<span style='font-size:16px;' class='pull-right hidden-xs showopacity glyphicon glyphicon-asterisk'></span></a></li>"
    Next

    menu = menu & "</ul>"
    Return menu
  End Function
End Class