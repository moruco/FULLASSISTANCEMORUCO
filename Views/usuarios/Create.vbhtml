@ModelType FULLASSISTANCEMORUCO.usuario
@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Registrar Nuevo Usuario</h2>
@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4></h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @*@Html.LabelFor(Function(model) model.correo, htmlAttributes:=New With {.class = "control-label col-md-2"})*@
            Correo
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.correo, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.correo, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            Contraseña
            @*@Html.LabelFor(Function(model) model.contraseña, htmlAttributes:=New With {.class = "control-label col-md-2"})*@
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.contraseña, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.contraseña, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            Repetir Contraseña
            @*@Html.LabelFor(Function(model) model.Repetircontraseña, htmlAttributes:=New With {.class = "control-label col-md-2"})*@
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Repetircontraseña, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Repetircontraseña, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group" style="margin-top: 10px;">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Registrar" class="btn btn-primary" />
            </div>
        </div>

    </div>
End Using

