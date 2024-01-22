@ModelType FULLASSISTANCEMORUCO.PokeApiResponse
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
    Dim page As Integer = If(Request.QueryString("page"), 1)
    Dim pageSize As Integer = 20
    Dim totalPages = Math.Ceiling(Model.Count / pageSize)
End Code

<h1>Seleccionar Pokemones </h1>
@Using (Html.BeginForm(FormMethod.Post))
    @<div class="form-actions no-color">

        <input type="submit" value="Crear" class="btn btn-primary" />




        <Table Class="table">
            <tr>
                <th>
                    Nombre Pokemon
                </th>
                <th>
                </th>
                <th>
                    @*<input type="checkbox" id="selectAll" />*@
                </th>
                <th></th>
            </tr>
            @Code
                For Each result In Model.Results
                    @<tr>
                        <td>
                            @Html.DisplayFor(Function(model) result.Name)
                        </td>
                        <td>
                            @Html.DisplayFor(Function(model) result.Url)
                        </td>
                        <td>
                            <input type="checkbox" name="selectedPokemons" class="pokemonCheckbox" value="@result.Url" />
                        </td>
                        <td>
                        </td>
                    </tr>
                Next
            End Code
        </Table>

        <ul class="pagination">
            Paginas
            @Code
                For p = 1 To totalPages
                    @<li Class="@(If(p = page, "active", ""))">
                         @Html.ActionLink(p.ToString(), "Index", New With {.page = p})
                    </li>
                Next
            End Code
        </ul>

    </div>
End Using

<script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
@section Scripts {
    <script>
        $(document).ready(function () {
            // Select all checkboxes
            $("#selectAll").click(function () {
                $(".pokemonCheckbox").prop('checked', $(this).prop('checked'));
            });

            // Individual checkbox clicked
            $(".pokemonCheckbox").click(function () {
                // UpdateHiddenFields function if needed
            });
        });
    </script>
    }

    <script>
        //$(document).ready(function () {
        //    $("#selectAll").click(function () {
        //        $(".pokemonCheckbox").prop('checked', $(this).prop('checked'));
        //    });

        //    $(".pokemonCheckbox").click(function () {
        //    });

        //    $("form").submit(function () {
        //        $("input[type='submit']").prop('disabled', true);

        //        $("input[type='submit']").after('<img src="https://media.giphy.com/media/3oEjI6SIIHBdRxXI40/giphy.gif" alt="Cargando..." width="100" height="100" />');


        //        setTimeout(function () {
        //            $("form").unbind('submit').submit();
        //        }, 2000);
        //        return false;
        //    });
        //});
        $(document).ready(function () {
            $("#selectAll").click(function () {
                $(".pokemonCheckbox").prop('checked', $(this).prop('checked'));
            });

            $(".pokemonCheckbox").click(function () {
            });

            $("form").submit(function () {
                // Verificar si al menos un checkbox está seleccionado
                if ($(".pokemonCheckbox:checked").length === 0) {
                    alert("Por favor, selecciona al menos un Pokémon.");
                    return false; // Detener el envío del formulario
                }

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
<style>
    #loadingOverlay {
        display: none;
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(255, 255, 255, 0.7);
        z-index: 1000;
    }

    #loadingMessage {
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
    }
</style>
