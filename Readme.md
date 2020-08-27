<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/VB/Controllers/HomeController.vb))
* [Model.cs](./CS/CS/Models/Model.cs) (VB: [Model.vb](./VB/VB/Models/Model.vb))
* [Index.cshtml](./CS/CS/Views/Home/Index.cshtml) (VB: [Index.vbhtml](./VB/VB/Views/Home/Index.vbhtml))
* [TypedListDataBindingPartial.cshtml](./CS/CS/Views/Home/TypedListDataBindingPartial.cshtml) (VB: [GridViewPartialView.vbhtml](./VB/VB/Views/Home/GridViewPartialView.vbhtml))
* [_Layout.cshtml](./CS/CS/Views/Shared/_Layout.cshtml) (VB: [_rootLayout.vbhtml](./VB/VB/Views/Shared/_rootLayout.vbhtml))
<!-- default file list end -->
# How to use the GridView extension in Full Screen mode (100% browser Width and Height)
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/100/)**
<!-- run online end -->


<p>This example is based on recommendations from the <a href="https://www.devexpress.com/Support/Center/p/E3940">E3940: How to use the ASPxPageControl control in Full Screen mode (100% browser Width and Height)</a> Code Central example. </p><p>It illustrates how to use this technique in an ASP.NET MVC application and resize a DevExpress ASP.NET MVC extension (for example, GridView) to occupy the entire browser window (Full Screen mode)

## Steps to implement

1) Remove paddings and margins for the "body" element, if you need the grid to fit the browser window without gaps
```css
body, html
{
    padding: 0;
    margin: 0;
}
```

2) Enable Vertical Scrolling in the grid using the [**GridViewSettings.Settings.VerticalScrollBarMode**](https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxGridSettings.VerticalScrollBarMode.property) property. In addition, handle the client-side [**MVCxClientGridView.Init**](https://documentation.devexpress.com/AspNet/DevExpress.Web.Scripts.ASPxClientControlBase.Init.event) and [**MVCxClientGridView.EndCallbacks**](https://documentation.devexpress.com/AspNet/DevExpress.Web.Scripts.ASPxClientGridView.EndCallback.event) events. 
```cs
@Html.DevExpress().GridView(settings => {
    settings.Name = "grid";
    settings.ClientSideEvents.Init = "OnInit";
    settings.ClientSideEvents.EndCallback = "OnEndCallback";
    ...
    settings.Width = System.Web.UI.WebControls.Unit.Percentage(100);
    settings.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
    settings.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
}).Bind(Model).GetHtml()
```
```vb
@Html.DevExpress().GridView(Sub(settings)
       settings.Name = "grid"
       settings.ClientSideEvents.Init = "OnInit"
       settings.ClientSideEvents.EndCallback = "OnEndCallback"                          
       settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
       settings.Settings.VerticalScrollBarMode = ScrollBarMode.Visible                  
       settings.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords                   
       ...
End Sub).Bind(Model).GetHtml()
```
3) Set control height on the client side with the [**MVCxClientGridView.SetHeight**](https://documentation.devexpress.com/AspNet/DevExpress.Web.Scripts.ASPxClientControl.SetHeight.method) method. Call this method in the client-side **Init** and **EndCallback** event handlers.

```js
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
```

<p><strong>See Also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/E1081">E1081: How to use the ASPxGridView control (with the enabled vertical scrollbar) in a Full Screen mode (100% browser Width and Height)</a><br />
<a href="https://www.devexpress.com/Support/Center/p/E3940">E3940: How to use the ASPxPageControl control in a Full Screen mode (100% browser Width and Height)</a></p>

<br/>


