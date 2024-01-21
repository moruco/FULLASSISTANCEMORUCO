@ModelType FULLASSISTANCEMORUCO.login

@Code
    ViewData("Title") = "LOGIN"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>LOGIN</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.LabelFor(Function(model) model.correo, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.correo, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.correo, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.contraseña, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.contraseña, New With {.htmlAttributes = New With {.class = "form-control", .type = "password"}})
                @Html.ValidationMessageFor(Function(model) model.contraseña, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Login" class="btn btn-default" />
            </div>
        </div>
    </div>  End Using

<div>
  
</div>
