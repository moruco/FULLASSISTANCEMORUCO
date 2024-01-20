Imports Newtonsoft.Json

Public Class Pokemon
    ' Properties
    <JsonProperty("name")>
    Public Property Nombre As String

    <JsonProperty("type")>
    Public Property Tipo As String

    <JsonProperty("stats")>
    Public Property Stats As List(Of Stat)

    ' Constructor
    Public Sub New()
        ' Default constructor
    End Sub

    ' Additional constructor with parameters
    Public Sub New(nombre As String, tipo As String, ataqueFisico As Integer, ataqueEspecial As Integer, defensaFisica As Integer, defensaEspecial As Integer, stats As List(Of Stat))
        Me.Nombre = nombre
        Me.Tipo = tipo
        Me.Stats = stats
    End Sub
End Class
