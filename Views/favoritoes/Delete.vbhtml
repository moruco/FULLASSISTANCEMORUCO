@ModelType FULLASSISTANCEMORUCO.favorito

@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h4>Favorito</h4>
<h3>¿Esta seguro de eliminar?</h3>
<div>
    
    @Using (Html.BeginForm(FormMethod.Post))
        @Html.AntiForgeryToken()
        @<div class="form-actions no-color">
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

            </dl>
            <input type="submit" value="Confirmar Eliminacion" class="btn btn-primary" />
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
