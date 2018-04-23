@ModelType System.Collections.IEnumerable
<script type="text/javascript">
    function OnInit(s, e) {
        AdjustSize();
        ASPxClientUtils.AttachEventToElement(window, "resize", function (evt) {
            AdjustSize();
        });
    }
    functionOnEndCallback(s, e) {
        AdjustSize();
    }
    function AdjustSize() {
        var height = document.documentElement.clientHeight;
        grid.SetHeight(height);
    }
</script>
@Html.Partial("TypedListDataBindingPartial", Model)