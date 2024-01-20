
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports FULLASSISTANCEMORUCO

Public Class LoginController
    Inherits System.Web.Mvc.Controller
    Private db As New FULLASSISTANCEEntities1

    <HttpGet>
    Public Function Index() As ActionResult
        Return View()
    End Function

    <HttpPost>
    <ValidateAntiForgeryToken>
    Public Function Index(model As login) As ActionResult
        If ModelState.IsValid Then

            Dim usuarioEncontrado = db.usuario.FirstOrDefault(Function(u) u.correo = model.correo AndAlso u.contraseña = model.contraseña)


            If usuarioEncontrado IsNot Nothing Then
                ' Usuario encontrado, haz algo con él
                'Return Content("Usuario encontrado. ID: " & usuarioEncontrado.idusuario)
                TempData("idusuario") = usuarioEncontrado.idusuario
                Return RedirectToAction("Index", "usuarios")
            Else
                ' Usuario no encontrado
                Return Content("Usuario no encontrado.")
            End If
            '' Return Content($"Correo: {model.correo}, Contraseña: {model.contraseña}")
        End If

        ' Si llegamos aquí, significa que hubo un error de validación.

        ''  Return View(model)
    End Function
End Class