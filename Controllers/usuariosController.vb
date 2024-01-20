Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports FULLASSISTANCEMORUCO

Namespace Controllers
    Public Class usuariosController
        Inherits System.Web.Mvc.Controller

        Private db As New FULLASSISTANCEEntities1

        ' GET: usuarios
        Function Index() As ActionResult



            If TempData.ContainsKey("idUsuario") Then
                Dim iidusuario As Integer = TempData("idUsuario")


                Dim Usuario As List(Of usuario) = db.usuario.Where(Function(e) e.idusuario = iidusuario).ToList()
                ''Dim usuario As usuario = db.usuario.Find(iidusuario)

                '' ..Where(Function(f) f.idusuario = iidusuario).ToList()
                TempData("idUsuario") = iidusuario

                Return View(Usuario)

                '' Return View(db.usuario.ToList())

            Else
                Return View(Me)
            End If


        End Function


        Function Favoritos(ByVal id As Integer?) As ActionResult

            TempData("TempTipoPokemon") = "Favoritos"
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usuario As usuario = db.usuario.Find(id)
            'Dim favorito As favorito = db.favorito.Find(id)
            If IsNothing(usuario) Then
                Return HttpNotFound()
            End If
            ' preguntar en la base de datos si tiene equipos  ese usuario
            ' si tiene mostrar lista de equipos si no ir a pantalla de crear equipo
            Dim xfavorito As List(Of favorito) = db.favorito.Where(Function(e) e.idusuario = id).ToList()
            If IsNothing(xfavorito) OrElse xfavorito.Count = 0 Then
                'no existen fav mostrar la lista para sealeccionar favoritos
                TempData("TempIDequipo") = xfavorito
                TempData("idUsuario") = id
                Return RedirectToAction("Index", "Pokemon")
            End If
            If xfavorito.Count > 0 Then
                'mostrar los favoritos desde la db
                TempData("idUsuario") = id
                TempData("TempdetalleFavorito") = xfavorito
                Return RedirectToAction("Index", "Favoritoes")
            End If
        End Function

        Function Equipos(ByVal id As Integer?) As ActionResult
            TempData("TempTipoPokemon") = "Equipos"

            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usuario As usuario = db.usuario.Find(id)
            Dim favorito As favorito = db.favorito.Find(id)
            If IsNothing(usuario) Then
                Return HttpNotFound()
            End If
            Dim Equipo As List(Of equipo) = db.equipo.Where(Function(e) e.idusuario = id).ToList()
            If IsNothing(Equipo) OrElse Equipo.Count = 0 Then
                TempData("idusuario") = id
                Return RedirectToAction("Create", "equipoes")
            End If
            If Equipo.Count > 0 Then
                ' If no records are found, redirect to another controller's action
                TempData("TempEquipo") = Equipo
                Return RedirectToAction("Index", "equipoes")
            End If

        End Function





        ' GET: usuarios/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usuario As usuario = db.usuario.Find(id)
            If IsNothing(usuario) Then
                Return HttpNotFound()
            End If
            Return View(usuario)
        End Function

        ' GET: usuarios/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: usuarios/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="idusuario,correo,contraseña,fecha")> ByVal usuario As usuario) As ActionResult
            If ModelState.IsValid Then
                db.usuario.Add(usuario)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(usuario)
        End Function

        ' GET: usuarios/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usuario As usuario = db.usuario.Find(id)
            If IsNothing(usuario) Then
                Return HttpNotFound()
            End If
            Return View(usuario)
        End Function

        ' POST: usuarios/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="idusuario,correo,contraseña,fecha")> ByVal usuario As usuario) As ActionResult
            If ModelState.IsValid Then
                db.Entry(usuario).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(usuario)
        End Function

        ' GET: usuarios/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usuario As usuario = db.usuario.Find(id)
            If IsNothing(usuario) Then
                Return HttpNotFound()
            End If
            Return View(usuario)
        End Function

        ' POST: usuarios/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim usuario As usuario = db.usuario.Find(id)
            db.usuario.Remove(usuario)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
