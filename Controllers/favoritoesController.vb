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
    Public Class favoritoesController
        Inherits System.Web.Mvc.Controller

        Private db As New FULLASSISTANCEEntities1
        Dim id As Integer

        ' GET: favoritoes
        Public Function Volver() As ActionResult
            Return RedirectToAction("Index", "usuarios")
        End Function
        Function Index() As ActionResult
            If TempData.ContainsKey("idUsuario") Then
                id = TempData("idUsuario")
                Dim usuario As usuario = db.usuario.Find(id)
                If IsNothing(usuario) Then
                    Return HttpNotFound()
                End If
                ' preguntar en la base de datos si tiene equipos  ese usuario
                ' si tiene mostrar lista de equipos si no ir a pantalla de crear equipo
                Dim listaFavorito As List(Of favorito) = db.favorito.Where(Function(e) e.idusuario = id).ToList()
                If IsNothing(listaFavorito) OrElse listaFavorito.Count = 0 Then
                    Return RedirectToAction("Index", "Pokemon")
                End If
                If listaFavorito.Count > 0 Then

                    ' poner imagen del pokemon
                    For Each favoritoItem As favorito In listaFavorito
                        Dim pokemonCliente = New PokemonClient
                        Dim resultadoPokemonApi As Pokemon
                        resultadoPokemonApi = pokemonCliente.GetPokemo(favoritoItem.idpokemon)

                        favoritoItem.imagen = resultadoPokemonApi.SpritesData.BackDefault





                        favoritoItem.nombre = resultadoPokemonApi.Nombre
                        favoritoItem.tipo = resultadoPokemonApi.Types.FirstOrDefault().Type.Name
                        favoritoItem.ataque = Getvalor(resultadoPokemonApi, "attack")
                        favoritoItem.ataque_especial = Getvalor(resultadoPokemonApi, "special-attack")
                        favoritoItem.defensa = Getvalor(resultadoPokemonApi, "defense")
                        favoritoItem.defensa_especial = Getvalor(resultadoPokemonApi, "special-defense")
                        favoritoItem.puntovida = Getvalor(resultadoPokemonApi, "hp")
                        favoritoItem.velocidad = Getvalor(resultadoPokemonApi, "speed")



                        ' llamar servicio  para trade datos de cada pokemon



                        ' Aquí puedes acceder a las propiedades de cada elemento en el bucle
                        ' Ejemplo: favoritoItem.Propiedad

                        ' Puedes realizar acciones específicas con cada elemento dentro del bucle
                        ' ...

                    Next


                    TempData("idUsuario") = id
                    TempData("TempdetalleFavorito") = listaFavorito
                    Return View(listaFavorito)
                End If
            Else

            End If

        End Function

        Function Getvalor(pokemon As Pokemon, statName As String) As Integer
            Dim targetStatName As String = statName.ToLower()
            For Each stat In pokemon.Stats
                Dim currentStatName As String = stat.StatInfo.Name.ToLower()
                If currentStatName = targetStatName Then
                    Return stat.BaseStat
                End If
            Next
            Return 0
        End Function

        ' GET: favoritoes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim favorito As favorito = db.favorito.Find(id)
            If IsNothing(favorito) Then
                Return HttpNotFound()
            End If
            Return View(favorito)
        End Function

        ' GET: favoritoes/Create
        Function Create() As ActionResult

            Return RedirectToAction("Index", "Pokemon")
        End Function

        ' POST: favoritoes/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="idfavorito,idusuario,idpokemon,fecha")> ByVal favorito As favorito) As ActionResult
            If ModelState.IsValid Then
                db.favorito.Add(favorito)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(favorito)
        End Function

        ' GET: favoritoes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim favorito As favorito = db.favorito.Find(id)
            If IsNothing(favorito) Then
                Return HttpNotFound()
            End If
            Return View(favorito)
        End Function

        ' POST: favoritoes/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="idfavorito,idusuario,idpokemon,fecha")> ByVal favorito As favorito) As ActionResult
            If ModelState.IsValid Then
                db.Entry(favorito).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(favorito)
        End Function

        ' GET: favoritoes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim favorito As favorito = db.favorito.Find(id)
            If IsNothing(favorito) Then
                Return HttpNotFound()
            End If
            Return View(favorito)
        End Function

        ' POST: favoritoes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim favorito As favorito = db.favorito.Find(id)
            db.favorito.Remove(favorito)
            db.SaveChanges()


            Dim xfavorito As List(Of favorito) = db.favorito.Where(Function(e) e.idusuario = favorito.idusuario).ToList()
            If IsNothing(xfavorito) OrElse xfavorito.Count = 0 Then
                ' TempData("TempIDequipo") = xfavorito

                ' si ya no hay favoritos volver a la pantalla de usuarios
                TempData("idUsuario") = favorito.idusuario
                Return RedirectToAction("Index", "usuarios")
            End If
            If xfavorito.Count > 0 Then
                ' If no records are found, redirect to another controller's action
                TempData("TempdetalleFavorito") = xfavorito

                TempData("idUsuario") = favorito.idusuario
                Return RedirectToAction("Index")
                ''Return View(favorito)
            End If



        End Function





        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
