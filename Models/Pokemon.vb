Imports Newtonsoft.Json

Public Class Pokemon
    ' Properties
    <JsonProperty("name")>
    Public Property Nombre As String

    '<JsonProperty("type")>
    'Public Property Tipo As String

    <JsonProperty("stats")>
    Public Property Stats As List(Of Stat)
    <JsonProperty("types")>
    Public Property Types As List(Of PokemonType)

    <JsonProperty("sprites")>
    Public Property SpritesData As Sprites


    ' Constructor
    Public Sub New()
        ' Default constructor
    End Sub

    ' Additional constructor with parameters
    'Public Sub New(nombre As String, tipo As String, ataqueFisico As Integer, ataqueEspecial As Integer, defensaFisica As Integer, defensaEspecial As Integer, stats As List(Of Stat))
    '    Me.Nombre = nombre
    '    Me.Tipo = tipo
    '    Me.Stats = stats
    'End Sub
End Class


Public Class Sprites
    <JsonProperty("back_default")>
    Public Property BackDefault As String
End Class
Public Class PokemonType
    <JsonProperty("slot")>
    Public Property Slot As Integer

    <JsonProperty("type")>
    Public Property Type As TypeDetails
End Class

Public Class TypeDetails
    <JsonProperty("name")>
    Public Property Name As String

    <JsonProperty("url")>
    Public Property Url As String
End Class

Public Class Stat
    <JsonProperty("base_stat")>
    Public Property BaseStat As Integer

    <JsonProperty("effort")>
    Public Property Effort As Integer

    <JsonProperty("stat")>
    Public Property StatInfo As StatInfo
End Class

Public Class StatInfo
    <JsonProperty("name")>
    Public Property Name As String

    <JsonProperty("url")>
    Public Property Url As String
End Class
