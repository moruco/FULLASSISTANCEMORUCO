@ModelType IEnumerable(Of FULLASSISTANCEMORUCO.usuario)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Menu Usuario</h2>

<p>

</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.correo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.contraseña)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.fecha)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>

                <input value="@Html.DisplayFor(Function(modelItem) item.correo)" readonly/>
            </td>
            <td>
                <input type="password" value="@Html.DisplayFor(Function(modelItem) item.contraseña)" readonly />
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.fecha)
            </td>
            <td>
                @*@Html.ActionLink("Edit", "Edit", New With {.id = item.idusuario}) |*@
                @*@Html.ActionLink("Details", "Details", New With {.id = item.idusuario}) |*@
                @*@Html.ActionLink("Delete", "Delete", New With {.id = item.idusuario})|*@
                @Html.ActionLink("Favoritos", "Favoritos", New With {.id = item.idusuario}, New With {.class = "btn btn-primary"})
                @Html.ActionLink("Equipos", "Equipos", New With {.id = item.idusuario}, New With {.class = "btn btn-primary"})
            </td>
        </tr>
    Next

</table>
