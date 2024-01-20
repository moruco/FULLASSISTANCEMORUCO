@ModelType FULLASSISTANCEMORUCO.usuario
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
