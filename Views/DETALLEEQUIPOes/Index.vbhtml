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
        <th>
            @Html.DisplayNameFor(Function(model) model.nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ataque)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ataque_especial)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.defensa)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.defensa_especial)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.tipo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.puntovida)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.velocidad)
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
        @Html.DisplayFor(Function(modelItem) item.nombre)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.ataque)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.ataque_especial)
    </td>
    <td>
        @Html.DisplayFor(Function(model) item.defensa)
    </td>
    <td>
        @Html.DisplayFor(Function(model) item.defensa_especial)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.tipo)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.puntovida)
    </td>
    <td>
        @Html.DisplayFor(Function(modelItem) item.velocidad)
    </td>
    <td>
        @Html.ActionLink("Edit", "Edit", New With {.id = item.Iddetalle}) |
        @Html.ActionLink("Agregar", "Add", New With {.id = item.Idequipo}) |
        @Html.ActionLink("Quitar", "Delete", New With {.id = item.Iddetalle})
    </td>
</tr>
Next

</table>
