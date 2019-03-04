Public Class HomeController
    Inherits System.Web.Mvc.Controller
    Public Function Index() As ActionResult
        If Session("TypedListModel") Is Nothing Then
            Session("TypedListModel") = InMemoryModel.GetTypedListModel()
        End If

        Return View(Session("TypedListModel"))
    End Function

    Public Function GridViewPartialView() As ActionResult
        Return PartialView(Session("TypedListModel"))
    End Function

End Class