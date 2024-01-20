@ModelType FULLASSISTANCEMORUCO.usuario
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

<div>
    <h4>usuario</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.correo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.correo)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.contraseña)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.contraseña)
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
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.idusuario }) |
    @Html.ActionLink("Back to List", "Index")
</p>
