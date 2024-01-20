@ModelType IEnumerable(Of FULLASSISTANCEMORUCO.favorito)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
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
            @Html.ActionLink("Edit", "Edit", New With {.id = item.idfavorito }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.idfavorito }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.idfavorito })
        </td>
    </tr>
Next

</table>
