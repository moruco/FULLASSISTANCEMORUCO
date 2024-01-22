@ModelType FULLASSISTANCEMORUCO.favorito
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Eliminar</h2>

<h3>¿Esta seguro de eliminar?</h3>
<div>
    <h4>favorito</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.idusuario)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.idusuario)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.idpokemon)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.idpokemon)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.fecha)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.fecha)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Eliminar" class="btn btn-default" /> |
            @Html.ActionLink("Volver", "Index")
        </div>
    End Using
</div>
