@ModelType IEnumerable(Of FULLASSISTANCEMORUCO.favorito)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Favoritos</h2>
<p>
    @*@Html.ActionLink("Nuevo", "Create", New With {.class = "btn btn-primary"})*@
    <a href="@Url.Action("Create")" class="btn btn-primary">Agregar</a>
    <a href="@Url.Action("Volver")" class="btn btn-primary">Volver</a>
</p>
<table class="table">

    <tr>
        <th>
            Id Pokemon
            @*@Html.DisplayNameFor(Function(model) model.idpokemon)*@
        </th>
        <th>
            Nombre
            @*@Html.DisplayNameFor(Function(model) model.nombre)*@
        </th>
        <th>
            Imagen
        </th>
        <th>
            Ataque
            @*@Html.DisplayNameFor(Function(model) model.ataque)*@
        </th>
        <th>
            Ataque_especial
            @*@Html.DisplayNameFor(Function(model) model.ataque_especial)*@
        </th>
        <th>
            Defensa
            @*@Html.DisplayNameFor(Function(model) model.defensa)*@
        </th>
        <th>
            Defensa Especial
            @*@Html.DisplayNameFor(Function(model) model.defensa_especial)*@
        </th>
        <th>
            Tipo
            @*@Html.DisplayNameFor(Function(model) model.tipo)*@
        </th>
        <th>
            Vida
            @*@Html.DisplayNameFor(Function(model) model.puntovida)*@
        </th>
        <th>
            Velocidad
            @*@Html.DisplayNameFor(Function(model) model.velocidad)*@
        </th>
        <th></th>
    </tr>


    @For Each item In Model
        @<tr>
            <!--<td>-->
            @*@Html.DisplayFor(Function(modelItem) item.idusuario)*@
            <!--</td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.idpokemon)
                <img src="@Html.DisplayFor(Function(modelItem) item.imagen)" alt="Imagen del Pokémon" />
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.fecha)
            </td>-->

            <td>
                @Html.DisplayFor(Function(modelItem) item.idpokemon)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.nombre)
            </td>

            <td>

                <img src="@Html.DisplayFor(Function(modelItem) item.imagen)" alt="Imagen del Pokémon" />
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
            <td>
                @*@Html.ActionLink("Edit", "Edit", New With {.id = item.idfavorito }) |*@
                @*@Html.ActionLink("Detalle", "Details", New With {.id = item.idfavorito}, New With {.class = "btn btn-primary"})*@
                @Html.ActionLink("Eliminar", "Delete", New With {.id = item.idfavorito}, New With {.class = "btn btn-primary"})
            </td>
        </tr>
    Next

</table>
