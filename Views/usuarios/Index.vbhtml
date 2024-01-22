@ModelType IEnumerable(Of FULLASSISTANCEMORUCO.usuario)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<h2>Menu Usuario</h2>
@Using (Html.BeginForm(FormMethod.Post))
    @Html.AntiForgeryToken()
    @<div class="form-actions no-color">
        <div id="mensajeCarga" style="display: none;">
            Cargando Favoritos...
            <img src="https://media.giphy.com/media/3oEjI6SIIHBdRxXI40/giphy.gif" alt="Cargando..." width="100" height="100" />
        </div>
        <p>
        </p>
        <table class="table">
            <tr>
                <th>
                    @Html.DisplayNameFor(Function(model) model.correo)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.contraseña)
                </th>
                <th>
                    @Html.DisplayNameFor(Function(model) model.fecha)
                </th>
                <th></th>
            </tr>

            @For Each item In Model
                @<tr>
                    <td>
                        <input value="@Html.DisplayFor(Function(modelItem) item.correo)" readonly />
                    </td>
                    <td>
                        <input type="password" value="@Html.DisplayFor(Function(modelItem) item.contraseña)" readonly />
                    </td>
                    <td>
                        @Html.DisplayFor(Function(modelItem) item.fecha)
                    </td>
                    <td>
                        @*@Html.ActionLink("Edit", "Edit", New With {.id = item.idusuario}) |*@
                        @*@Html.ActionLink("Details", "Details", New With {.id = item.idusuario}) |*@
                        @*@Html.ActionLink("Delete", "Delete", New With {.id = item.idusuario})|*@
                        @*@Html.ActionLink("Favoritos", "Favoritos", New With {.id = item.idusuario}, New With {.class = "btn btn-primary"})*@
                        @Html.ActionLink("Equipos", "Equipos", New With {.id = item.idusuario}, New With {.class = "btn btn-primary"})
                        <a href="#" class="btn btn-primary" onclick="mostrarMensajeCarga('@Url.Action("Favoritos", New With {.id = item.idusuario})')">Favoritos</a>
                    </td>
                </tr>
            Next
        </table>
    </div>
End Using

@section Scripts {
    <script>
        $(document).ready(function () {
            $("form").submit(function () {
                $("input[type='submit']").prop('disabled', true);
                $("input[type='submit']").after('<img src="https://media.giphy.com/media/3oEjI6SIIHBdRxXI40/giphy.gif" alt="Cargando..." width="100" height="100" />');
                setTimeout(function () {
                    $("form").unbind('submit').submit();
                }, 2000);
                return false;
            });
        });
    </script>
    <script>
        function mostrarMensajeCarga(url) {
            // Mostrar mensaje de carga
            $("#mensajeCarga").show();

            // Realizar redirección después de un breve período de tiempo (puedes ajustar el tiempo según tus necesidades)
            setTimeout(function () {
                window.location.href = url;
            }, 1000); // 1000 milisegundos = 1 segundo (ajusta según sea necesario)
        }
    </script>
end section