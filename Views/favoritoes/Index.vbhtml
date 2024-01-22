@ModelType IEnumerable(Of FULLASSISTANCEMORUCO.favorito)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Favoritos</h2>

<p>
    @*@Html.ActionLink("Nuevo", "Create", New With {.class = "btn btn-primary"})*@
    <a href="@Url.Action("Create")" class="btn btn-primary">Nuevo</a>
    <a href="@Url.Action("Volver")" class="btn btn-primary">Volver</a>
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.idusuario)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.idpokemon)
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
                @Html.DisplayFor(Function(modelItem) item.idpokemon)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.fecha)
            </td>
            <td>
                @*@Html.ActionLink("Edit", "Edit", New With {.id = item.idfavorito }) |*@


                @*@Html.ActionLink("Detalle", "Details", New With {.id = item.idfavorito}, New With {.class = "btn btn-primary"})*@
                @Html.ActionLink("Eliminar", "Delete", New With {.id = item.idfavorito}, New With {.class = "btn btn-primary"})
            </td>
        </tr>
    Next

</table>
