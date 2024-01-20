@ModelType IEnumerable(Of FULLASSISTANCEMORUCO.equipo)
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
                @Html.ActionLink("Edit", "Edit", New With {.id = item.idequipo}) |

                @If item.baja Then

                Else

                    @Html.ActionLink("Details", "Details", New With {.id = item.idequipo})

                End If

                @Html.ActionLink("Delete", "Delete", New With {.id = item.idequipo})
            </td>
        </tr>
    Next

</table>
