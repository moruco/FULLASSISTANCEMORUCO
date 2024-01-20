@ModelType IEnumerable(Of FULLASSISTANCEMORUCO.DETALLEEQUIPO)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Index</h2>

<p>
    @*@Html.ActionLink("Adicionar", "Create")*@
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Idequipo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.idpokemon)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Idequipo)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.idpokemon)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Iddetalle }) |
            @Html.ActionLink("Agregar", "Add", New With {.id = item.Idequipo}) |
            @Html.ActionLink("Quitar", "Delete", New With {.id = item.Iddetalle})
        </td>
    </tr>
Next

</table>
