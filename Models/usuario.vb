'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations

Partial Public Class usuario
    Public Property idusuario As Integer
    <Required(ErrorMessage:="El campo Correo es obligatorio.")>
    Public Property correo As String

    <Required(ErrorMessage:="El campo Contraseña es obligatorio.")>
    Public Property contraseña As String

    <Required(ErrorMessage:="El campo Repetir Contraseña es obligatorio.")>
    <Compare("contraseña", ErrorMessage:="Las contraseñas no coinciden.")>
    Public Property Repetircontraseña As String
    Public Property fecha As Nullable(Of Date)

End Class
