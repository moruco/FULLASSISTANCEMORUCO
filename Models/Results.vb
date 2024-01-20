Imports Newtonsoft.Json

Public Class Results
    <JsonProperty("name")>
    Public Property Name As String
    <JsonProperty("url")>
    Public Property Url As String

    <JsonProperty("seleccionado")>
    Public Property Seleccionado As String

End Class
