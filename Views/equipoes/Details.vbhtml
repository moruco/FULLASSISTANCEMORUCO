@ModelType FULLASSISTANCEMORUCO.equipo
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.idequipo }) |
    @Html.ActionLink("Back to List", "Index")
</p>
