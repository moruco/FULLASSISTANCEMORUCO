Imports Newtonsoft.Json

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
