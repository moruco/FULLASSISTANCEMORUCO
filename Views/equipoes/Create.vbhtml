﻿@ModelType FULLASSISTANCEMORUCO.equipo
@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Create</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>equipo</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
     <div class="form-group">

         @Html.LabelFor(Function(model) model.idusuario, htmlAttributes:=New With {.class = "control-label col-md-2", .style = "display: none;"})
         @*@Html.LabelFor(Function(model) model.idusuario, htmlAttributes:=New With {.class = "control-label col-md-2"})*@
         <div class="col-md-10">
             @Html.EditorFor(Function(model) model.idusuario, New With {.htmlAttributes = New With {.readonly = "readonly", .style = "display: none;"}})
             @*@Html.EditorFor(Function(model) model.idusuario, New With {.htmlAttributes = New With {.readonly = "readonly"}, .style = "display: none;"})*@
             @Html.ValidationMessageFor(Function(model) model.idusuario, "", New With {.class = "text-danger"})
         </div>
     </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.descripcion, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.descripcion, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.descripcion, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.baja, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                <div class="checkbox">
                    @Html.EditorFor(Function(model) model.baja)
                    @Html.ValidationMessageFor(Function(model) model.baja, "", New With {.class = "text-danger"})
                </div>
            </div>
        </div>
        @*<div class="form-group">
            @Html.LabelFor(Function(model) model.baja, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.baja,
                                                       New SelectList(New List(Of SelectListItem) From {
                                                          New SelectListItem With {.Value = "False", .Text = "False"},
                                                          New SelectListItem With {.Value = "True", .Text = "True"}
                                                       }, "Value", "Text"),
                                                       New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.baja, "", New With {.class = "text-danger"})
            </div>
        </div>*@






        <div class="form-group">
            @Html.LabelFor(Function(model) model.fecha, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.fecha, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.fecha, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10" style="margin-top: 10px;">
                <input type="submit" value="Guardar" class="btn btn-primary" />
            </div>
        </div>
    </div>  End Using

<div>


    <a href="@Url.Action("Index")" class="btn btn-primary" style="margin-top: 10px;">Volver</a>
</div>
