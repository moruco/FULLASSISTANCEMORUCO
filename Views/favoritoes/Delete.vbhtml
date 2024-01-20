﻿@ModelType FULLASSISTANCEMORUCO.favorito
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
