﻿@ModelType IEnumerable(Of FULLASSISTANCEMORUCO.usuario)
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
            @Html.DisplayFor(Function(modelItem) item.correo)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.contraseña)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.fecha)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.idusuario}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.idusuario}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.idusuario})|
            @Html.ActionLink("Favoritos", "Favoritos", New With {.id = item.idusuario}) |
            @Html.ActionLink("Equipos", "Equipos", New With {.id = item.idusuario}) |
        </td>
    </tr>
Next

</table>
