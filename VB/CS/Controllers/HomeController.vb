Imports System.Web.Mvc
Imports CS.Models

Namespace CS.Controllers

    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            If Session("TypedListModel") Is Nothing Then Session("TypedListModel") = InMemoryModel.GetTypedListModel()
            Return View(Session("TypedListModel"))
        End Function

        Public Function TypedListDataBindingPartial() As ActionResult
            Return PartialView(Session("TypedListModel"))
        End Function
    End Class
End Namespace
