Imports System
Imports System.Web.Mvc

Public Class HomeController
    Inherits Controller
    Public Function Index() As ActionResult
        If Session("TypedListModel") Is Nothing Then
            Session("TypedListModel") = InMemoryModel.GetTypedListModel()
        End If

        Return View(Session("TypedListModel"))
    End Function

    Public Function TypedListDataBindingPartial() As ActionResult
        Return PartialView(Session("TypedListModel"))
    End Function
End Class