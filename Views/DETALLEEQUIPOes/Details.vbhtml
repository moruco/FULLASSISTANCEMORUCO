﻿@ModelType FULLASSISTANCEMORUCO.DETALLEEQUIPO
@Code
    ViewData("Title") = "Detallew"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Detalle Equipo</h2>

<div>
    <h4>Detalle del Equipo</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Idequipo)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Idequipo)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.idpokemon)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.idpokemon)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Iddetalle}) |
    @Html.ActionLink("Back to List", "Index")



</p>
