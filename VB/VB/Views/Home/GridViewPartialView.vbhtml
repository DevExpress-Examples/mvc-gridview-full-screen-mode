    @* DXCOMMENT: Configure GridView *@
    @Html.DevExpress().GridView(Sub(settings)
                                     settings.Name = "GridView"
                                     settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartialView"}

                                     settings.KeyFieldName = "ID"
                                     settings.Columns.Add("ID")
                                     settings.Columns.Add("Text")
                                     settings.Columns.Add("Quantity")
                                     settings.Columns.Add("Price")

                                     settings.ClientSideEvents.Init = "OnInit"
                                     settings.ClientSideEvents.EndCallback = "OnEndCallback"

                                     settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
                                     settings.Settings.VerticalScrollBarMode = ScrollBarMode.Visible

                                     settings.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords

                                     'Unbound Columns
                                     settings.Columns.Add(
                                          Sub(unboundColumn)
                                              unboundColumn.FieldName = "UniqueFieldName"
                                              unboundColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
                                          End Sub)
                                     'Unbound Column Calculating
                                     settings.CustomUnboundColumnData =
                                          Sub(sender, e)
                                              If (e.Column.FieldName = "UniqueFieldName") Then
                                                  Dim quantity = Convert.ToInt32(e.GetListSourceFieldValue("Quantity"))
                                                  Dim price = CType(e.GetListSourceFieldValue("Price"), Decimal)

                                                  e.Value = quantity * price
                                              End If
                                          End Sub
                                 End Sub).Bind(Model).GetHtml()
