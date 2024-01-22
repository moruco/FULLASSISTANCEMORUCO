@ModelType IEnumerable(Of FULLASSISTANCEMORUCO.DETALLEEQUIPO)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Detalle del equipo Pokemon</h2>

<p>
    @*@Html.ActionLink("Adicionar", "Create")*@




    <a href="@Url.Action("Volver")" class="btn btn-primary">Volver</a>
    <h3>Habilidades del Equipo</h3>

    <div class="summary-box">
        <div>
            <label>Ataque Total: </label>
            <span id="ataqueTotal">@Model.Sum(Function(item) item.ataque)</span>
        </div>
        <div>
            <label>Ataque Especial Total: </label>
            <span id="ataqueEspecialTotal">@Model.Sum(Function(item) item.ataque_especial)</span>
        </div>
        <div>
            <label>Defensa Total: </label>
            <span id="defensaTotal">@Model.Sum(Function(item) item.defensa)</span>
        </div>
        <div>
            <label>Defensa Especial Total: </label>
            <span id="defensaEspecialTotal">@Model.Sum(Function(item) item.defensa_especial)</span>
        </div>
    </div>

</p>
<h3>Pokemones del Equipo</h3>
<table class="table">
    <tr>

        <th>
            Id Equipo
            @*@Html.DisplayNameFor(Function(model) model.Idequipo)*@
        </th>
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

                @Html.ActionLink("Agregar", "Add", New With {.id = item.Idequipo}, New With {.class = "btn btn-primary"})
                @Html.ActionLink("Quitar", "Delete", New With {.id = item.Iddetalle}, New With {.class = "btn btn-primary"})


            </td>
        </tr>
    Next

</table>

<style>
    .summary-box {
        border: 1px solid #ddd;
        padding: 10px;
        margin-top: 20px;
        border-radius: 5px;
    }

        .summary-box div {
            margin-bottom: 10px;
        }

    label {
        font-weight: bold;
        margin-right: 10px;
    }

    span {
        font-weight: normal;
    }
</style>