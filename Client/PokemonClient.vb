Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class PokemonClient
    Private ReadOnly baseUrl As String = "https://pokeapi.co/api/v2/pokemon"


    Public Function GetPokemonList(offset As Integer, limit As Integer) As PokeApiResponse

        Dim apiUrl As String = $"{baseUrl}?offset={offset}&limit={limit}"

        Using httpClient As New HttpClient()
            ' Send the GET request
            Dim response As HttpResponseMessage = httpClient.GetAsync(apiUrl).Result

            If response.IsSuccessStatusCode Then
                ' Read and deserialize the response content
                Dim jsonContent As String = response.Content.ReadAsStringAsync().Result
                Dim pokeApiResponse As PokeApiResponse = JsonConvert.DeserializeObject(Of PokeApiResponse)(jsonContent)
                Return pokeApiResponse
            Else
                ' Handle error response (optional)
                Throw New Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}")
            End If
        End Using
    End Function


    Public Function GetPokemo(pokemonurl As String) As Pokemon
        'Dim apiUrl As String = pokemonurl

        Dim apiUrl As String = baseUrl + "/" + pokemonurl

        Using httpClient As New HttpClient()
            ' Send the GET request
            Dim response As HttpResponseMessage = httpClient.GetAsync(apiUrl).Result

            If response.IsSuccessStatusCode Then
                ' Read and deserialize the response content
                Dim jsonContent As String = response.Content.ReadAsStringAsync().Result
                Dim pokemonApiResponse As Pokemon = JsonConvert.DeserializeObject(Of Pokemon)(jsonContent)
                Return pokemonApiResponse
            Else
                ' Handle error response (optional)
                Throw New Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}")
            End If
        End Using
    End Function


    Public Async Function GetPokemonListAsync(offset As Integer, limit As Integer) As Task(Of PokeApiResponse)
        Dim apiUrl As String = $"{baseUrl}?offset={offset}&limit={limit}"

        Using httpClient As New HttpClient()
            ' Send the GET request
            Dim response As HttpResponseMessage = Await httpClient.GetAsync(apiUrl)

            If response.IsSuccessStatusCode Then
                ' Read and deserialize the response content
                Dim jsonContent As String = Await response.Content.ReadAsStringAsync()
                Dim pokeApiResponse As PokeApiResponse = JsonConvert.DeserializeObject(Of PokeApiResponse)(jsonContent)
                Return pokeApiResponse
            Else
                ' Handle error response (optional)
                Throw New Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}")
            End If
        End Using
    End Function

End Class

