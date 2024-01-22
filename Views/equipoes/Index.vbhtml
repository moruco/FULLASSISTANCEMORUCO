@ModelType IEnumerable(Of FULLASSISTANCEMORUCO.equipo)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @<div class="form-horizontal">

    <h1>
        @*<label>equipo nombre  @TempData("descripcionequipo")</label>*@
    </h1>
    <div id="loadingMessage" style="display:none">
        Cargando equipo...
        <img src="https://media.giphy.com/media/3oEjI6SIIHBdRxXI40/giphy.gif" alt="Cargando..." width="100" height="100" />
    </div>
    <h2>Equipos </h2>
    <p>
        <a href="@Url.Action("Create")" class="btn btn-primary">Nuevo</a>
        <a href="@Url.Action("Volver")" class="btn btn-primary">Volver</a>
    </p>
    <table class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.idusuario)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.descripcion)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.baja)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.fecha)
            </th>
            <th></th>
        </tr>

        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.idusuario)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.descripcion)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.baja)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.fecha)
                </td>
                <td>
                    @Html.ActionLink("Editar", "Edit", New With {.id = item.idequipo}, New With {.class = "btn btn-primary"})
                    @If item.baja Then
                    Else
                        ' @Html.ActionLink("Detalle", "Details", New With {.id = item.idequipo}, New With {.onclick = "showLoadingMessage();", .class = "btn btn-primary"})

                        @Html.ActionLink("Detalle", "Details", New With {.id = item.idequipo, .descripcion = item.descripcion}, New With {.onclick = "showLoadingMessage();", .class = "btn btn-primary"})


                    End If
                    @Html.ActionLink("Delete", "Delete", New With {.id = item.idequipo}, New With {.class = "btn btn-primary"})
                </td>
            </tr>
        Next
    </table>
</div>

End Using
@section Scripts {
    <script>
        function showLoadingMessage() {
            document.getElementById('loadingMessage').style.display = 'block';
        }

        function hideLoadingMessage() {
            setTimeout(function () {
                document.getElementById('loadingMessage').style.display = 'none';
            }, 2000);
        }
    </script>

end section
