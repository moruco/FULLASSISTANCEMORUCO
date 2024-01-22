@ModelType FULLASSISTANCEMORUCO.DETALLEEQUIPO
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h3>¿Esta seguro de eliminar?</h3>
<div>
    <h4>DETALLEEQUIPO</h4>
    @Using (Html.BeginForm(FormMethod.Post))
        @Html.AntiForgeryToken()
        @<div class="form-actions no-color">
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
            <input type="submit" value="Confirmar Elmiminacion" class="btn btn-primary" /> 
        </div>
    End Using
</div>
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
end section
