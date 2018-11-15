<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [Model.cs](./CS/CS/Models/Model.cs) (VB: [Model.vb](./VB/Models/Model.vb))
* [Index.cshtml](./CS/CS/Views/Home/Index.cshtml)
* [TypedListDataBindingPartial.cshtml](./CS/CS/Views/Home/TypedListDataBindingPartial.cshtml)
* [_Layout.cshtml](./CS/CS/Views/Shared/_Layout.cshtml)
<!-- default file list end -->
# How to use the GridView extension in a Full Screen mode (100% browser Width and Height)


<p>This example is based on recommendations from the <a href="https://www.devexpress.com/Support/Center/p/E3940">E3940: How to use the ASPxPageControl control in a Full Screen mode (100% browser Width and Height)</a> Code Central example. </p><p>It illustrates how to use this technique in an ASP.NET MVC application and resize a DevExpress ASP.NET MVC extension (for example, GridView) to occupy the entire browser window (a Full Screen mode):</p><p>/Views/Shared/_Layout.cshtml:</p>

```css
body, html
{
    padding: 0;
    margin: 0;
}






```

<p>Main View: </p>

```js
<script type="text/javascript">
    function OnInit(s, e) {
        AdjustSize();
        ASPxClientUtils.AttachEventToElement(window, "resize", function (evt) {
            AdjustSize();
        });
    }
    function OnEndCallback(s, e) {
        AdjustSize();
    }
    function AdjustSize() {
        var height = document.documentElement.clientHeight;
        grid.SetHeight(height);
    }

</script>

@Html.Partial("TypedListDataBindingPartial", Model)



```

<p>PartialView: </p>

```cs
@Html.DevExpress().GridView(settings => {
    settings.Name = "grid";
    settings.ClientSideEvents.Init = "OnInit";
     settings.ClientSideEvents.EndCallback = "OnEndCallback";
    ...
    settings.Width = System.Web.UI.WebControls.Unit.Percentage(100);
    settings.Settings.ShowVerticalScrollBar = true;
    settings.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
}).Bind(Model).GetHtml()


```

<p><strong>See Also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/E1081">E1081: How to use the ASPxGridView control (with the enabled vertical scrollbar) in a Full Screen mode (100% browser Width and Height)</a><br />
<a href="https://www.devexpress.com/Support/Center/p/E3940">E3940: How to use the ASPxPageControl control in a Full Screen mode (100% browser Width and Height)</a></p>

<br/>


