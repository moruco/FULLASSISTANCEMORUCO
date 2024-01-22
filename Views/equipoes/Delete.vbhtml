@ModelType FULLASSISTANCEMORUCO.equipo
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2></h2>

<h3>¿Esta seguro de eliminar?</h3>
<div>
    <h4>equipo</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.idusuario)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.idusuario)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.descripcion)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.descripcion)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.baja)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.baja)
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
            <input type="submit" value="Delete" class="btn btn-primary" /> |
            <a href="@Url.Action("VolverEquipo")" class="btn btn-primary">Volver</a>
            @*@Html.ActionLink("Volver", "Index")*@
        </div>
    End Using
</div>
