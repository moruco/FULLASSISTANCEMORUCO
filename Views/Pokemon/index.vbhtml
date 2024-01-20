@ModelType FULLASSISTANCEMORUCO.PokeApiResponse
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<h1>Colla</h1>

@Using (Html.BeginForm(FormMethod.Post))




    @<div class="form-actions no-color">
    <input type="submit" value="Create" class="btn btn-default" />


    <Table Class="table">
        <tr>
            <th>
                Nombre Pokemon
            </th>
            <th>
            </th>
            <th>
                <input type="checkbox" id="selectAll" />
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

</div>
            End Using






