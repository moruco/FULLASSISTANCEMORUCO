






@ModelType FULLASSISTANCEMORUCO.PokeApiResponse
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"

    ' Pagination parameters
    Dim page As Integer = If(Request.QueryString("page"), 1)
    Dim pageSize As Integer = 20

    ' Determine the total number of pages
    Dim totalPages = Math.Ceiling(Model.Count / pageSize)

    ' Define the starting index based on the current page
    'Dim startIndex = (page - 1) * pageSize

    ' Define the ending index based on the current page
    'Dim endIndex = Math.Min(startIndex + pageSize - 1, Model.Count - 1)
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
   
    <ul class="pagination">
        @Code 
                For p = 1 To totalPages
        @<li Class="@(If(p = page, "active", ""))"> 
    @Html.ActionLink(p.ToString(), "Index", New With {.page = p})   </li>
            Next
        End Code
    </ul>

</div>
End Using


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

end section