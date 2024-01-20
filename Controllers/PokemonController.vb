Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports FULLASSISTANCEMORUCO

Public Class PokemonController
    Inherits System.Web.Mvc.Controller
    Dim idEquipo As Integer
    Dim pokemonCliente As PokemonClient
    Private db As New FULLASSISTANCEEntities1

    Function Index() As ActionResult
        Dim pokemonCliente = New PokemonClient
        If (TempData("TempTipoPokemon") = "Favoritos") Then
            TempData("TempTipoPokemon") = "Favoritos"
            'traer alista de favoritos para selecionar  los registros 
            Dim listaFavorito = TempData("TempdetalleFavorito")
            Dim resultadoPokemonApi = pokemonCliente.GetPokemonList(0, 20)



            If IsNothing(listaFavorito) OrElse listaFavorito.Count = 0 Then


            Else

                ' Create a list to store the indices of items to be removed
                Dim indicesToRemove As New List(Of Integer)
                For i = 0 To resultadoPokemonApi.Results.Count - 1
                    Dim itemREsul As Results = resultadoPokemonApi.Results(i)


                    For Each itemFavorito As favorito In listaFavorito
                        If itemFavorito.idpokemon.ToString().Equals(ExtraerId(itemREsul.Url)) Then
                            ' Mark the index to be removed
                            indicesToRemove.Add(i)
                        End If

                        TempData("idUsuario") = itemFavorito.idusuario
                    Next
                Next

                ' Remove items in reverse order to avoid index issues
                indicesToRemove.Reverse()
                For Each indice In indicesToRemove
                    resultadoPokemonApi.Results.RemoveAt(indice)
                Next


            End If



            Return View(resultadoPokemonApi)
            ' mostrar pokemones favoritos
        Else
            ' mostrar detalle pokemones de equipo
            ' recibe el id del equipo 
            If TempData.ContainsKey("idEquipo") Then
                idEquipo = TempData("idEquipo")
                'con el id traer el detalle  y quitar los nro de poken que trajera el pokemon cliente

            End If
            TempData("idEquipo") = idEquipo
            Return View(pokemonCliente.GetPokemonList(0, 20))

        End If



    End Function




    Function Create() As ActionResult
        Console.WriteLine("")


    End Function

    <HttpPost>
    Function Index(model As PokeApiResponse, selectedPokemons As String()) As ActionResult
        If ModelState.IsValid Then
            Dim detalleequipo As New DETALLEEQUIPO
            'TempData("TempTipoPokemon") = "Favoritos"
            If (TempData("TempTipoPokemon") = "Favoritos") Then
                ' guardar favoritos
                Dim Favorito As New favorito
                For Each item In selectedPokemons
                    'detalleequipo.Idequipo = equipo.idequipo
                    Favorito.idusuario = TempData("idUsuario")
                    Favorito.idpokemon = ExtraerId(item)
                    Favorito.fecha = DateTime.Now
                    db.favorito.Add(Favorito)
                    db.SaveChanges()


                Next

                TempData("idUsuario") = Favorito.idusuario
                Return RedirectToAction("Index", "Favoritoes")
            Else

                Dim equipo As New equipo
                equipo.idusuario = TempData("idUsuario")
                If TempData.ContainsKey("idEquipo") Then
                    idEquipo = TempData("idEquipo")
                End If
                If idEquipo > 0 Then

                Else
                    'guarda un equipo nuevo 

                    equipo.descripcion = "equipo malditango"
                    equipo.baja = False
                    equipo.fecha = DateTime.Now
                    db.equipo.Add(equipo)
                    db.SaveChanges()
                    idEquipo = equipo.idequipo
                End If

                For Each item In selectedPokemons
                    'detalleequipo.Idequipo = equipo.idequipo
                    detalleequipo.Idequipo = idEquipo
                    detalleequipo.idpokemon = ExtraerId(item)
                    db.DETALLEEQUIPO.Add(detalleequipo)
                    db.SaveChanges()
                Next

                TempData("idEquipo") = idEquipo


                Dim ldetalleequipo As List(Of DETALLEEQUIPO) = db.DETALLEEQUIPO.Where(Function(e) e.Idequipo = idEquipo).ToList()

                If IsNothing(ldetalleequipo) OrElse ldetalleequipo.Count = 0 Then
                    TempData("idEquipo") = idEquipo
                    Return RedirectToAction("Index", "Pokemon")
                End If
                If ldetalleequipo.Count > 0 Then
                    ' muestra los pokemones que se guardaron 
                    TempData("TempDetalleEquipo") = ldetalleequipo
                    Return RedirectToAction("Index", "DETALLEEQUIPOes")
                End If


                Return RedirectToAction("Index", "equipoes")
            End If
        End If

    End Function

    Function ExtraerId(pokemonUrl As String) As String

        Dim match = Regex.Match(pokemonUrl, "/(\d+)/$")

        ' Check if the match is successful
        If match.Success Then
            ' Extract the numeric part from the match
            Return match.Groups(1).Value
        Else
            Return "Not Found"
        End If
    End Function

End Class
