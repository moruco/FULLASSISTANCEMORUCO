Imports Newtonsoft.Json

Public Class PokeApiResponse
    <JsonProperty("count")>
    Public Property Count As String
    <JsonProperty("next")>
    Public Property NextProperty As String

    <JsonProperty("previous")>
    Public Property Previous As String

    <JsonProperty("base_experience")>
    Public Property base_experience As String


    <JsonProperty("results")>
    Public Property Results As List(Of Results)
    Public ReadOnly Property Key As String
        Get
            Return Count ' Assuming Count is a unique identifier
        End Get
    End Property
End Class
