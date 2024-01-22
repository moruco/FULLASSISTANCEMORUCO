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
    Public Class DETALLEEQUIPOesController
        Inherits System.Web.Mvc.Controller

        Private db As New FULLASSISTANCEEntities1

        ' GET: DETALLEEQUIPOes


        Public Function Volver() As ActionResult
            Return RedirectToAction("Index", "equipoes")

        End Function

        Function Index() As ActionResult
            If TempData.ContainsKey("TempDetalleEquipo") Then
                Dim TempDetalleEquipo As List(Of DETALLEEQUIPO) = TempData("TempDetalleEquipo")

                ' DETALLEEQUIPO = TempData("TempDetalleEquipo")

                Return View(TempDetalleEquipo)
            Else
                Return View(db.DETALLEEQUIPO.ToList())
            End If

        End Function

        Function ListarDetalleEquipo(Optional ByVal detalleEquipo As List(Of DETALLEEQUIPO) = Nothing) As ActionResult

            If detalleEquipo IsNot Nothing Then

                Return View(detalleEquipo)
            Else

                Return View(detalleEquipo)
            End If
        End Function
        ' GET: DETALLEEQUIPOes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim dETALLEEQUIPO As DETALLEEQUIPO = db.DETALLEEQUIPO.Find(id)
            If IsNothing(dETALLEEQUIPO) Then
                Return HttpNotFound()
            End If
            Return View(dETALLEEQUIPO)
        End Function

        ' GET: DETALLEEQUIPOes/Create
        Function Create() As ActionResult

            Return View()

        End Function

        Function Add(ByVal id As Integer?) As ActionResult

            ' adicionar nuevos pokemon al detalle
            TempData("idEquipo") = id


            Dim detalleEquipo As List(Of DETALLEEQUIPO) = db.DETALLEEQUIPO.Where(Function(e) e.Idequipo = id).ToList()
            TempData("TempDetalleEquipo") = detalleEquipo

            Return RedirectToAction("Index", "Pokemon")
        End Function

        ' POST: DETALLEEQUIPOes/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Idequipo,Iddetalle,idpokemon")> ByVal dETALLEEQUIPO As DETALLEEQUIPO) As ActionResult
            If ModelState.IsValid Then
                db.DETALLEEQUIPO.Add(dETALLEEQUIPO)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(dETALLEEQUIPO)
        End Function

        ' GET: DETALLEEQUIPOes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim dETALLEEQUIPO As DETALLEEQUIPO = db.DETALLEEQUIPO.Find(id)
            If IsNothing(dETALLEEQUIPO) Then
                Return HttpNotFound()
            End If
            Return View(dETALLEEQUIPO)
        End Function

        ' POST: DETALLEEQUIPOes/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Idequipo,Iddetalle,idpokemon")> ByVal dETALLEEQUIPO As DETALLEEQUIPO) As ActionResult
            If ModelState.IsValid Then
                db.Entry(dETALLEEQUIPO).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(dETALLEEQUIPO)
        End Function

        ' GET: DETALLEEQUIPOes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim dETALLEEQUIPO As DETALLEEQUIPO = db.DETALLEEQUIPO.Find(id)
            If IsNothing(dETALLEEQUIPO) Then
                Return HttpNotFound()
            End If
            Return View(dETALLEEQUIPO)
        End Function

        ' POST: DETALLEEQUIPOes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim dETALLEEQUIPO As DETALLEEQUIPO = db.DETALLEEQUIPO.Find(id)
            db.DETALLEEQUIPO.Remove(dETALLEEQUIPO)
            db.SaveChanges()


            id = TempData("idEquipo")


            'Dim detaequipo As DETALLEEQUIPO = db.DETALLEEQUIPO.Select Of(Function(e) e.Idequipo = id)
            Dim detalleEquipoa As List(Of DETALLEEQUIPO) = db.DETALLEEQUIPO.Where(Function(e) e.Idequipo = id).ToList()
            'llarmar api para cargar prop adicionales 
            Dim pokemonCliente = New PokemonClient
            Dim resultadoPokemonApi As Pokemon
            For Each detalleequipopokemon As DETALLEEQUIPO In detalleEquipoa
                resultadoPokemonApi = pokemonCliente.GetPokemo(detalleequipopokemon.idpokemon)
                detalleequipopokemon.nombre = resultadoPokemonApi.Nombre
                detalleequipopokemon.tipo = resultadoPokemonApi.Types.FirstOrDefault().Type.Name
                'detalleequipopokemon.ataque = resultadoPokemonApi.Stats.
                detalleequipopokemon.ataque = Getvalor(resultadoPokemonApi, "attack")
                detalleequipopokemon.ataque_especial = Getvalor(resultadoPokemonApi, "special-attack")
                detalleequipopokemon.defensa = Getvalor(resultadoPokemonApi, "defense")
                detalleequipopokemon.defensa_especial = Getvalor(resultadoPokemonApi, "special-defense")
                detalleequipopokemon.puntovida = Getvalor(resultadoPokemonApi, "hp")
                detalleequipopokemon.velocidad = Getvalor(resultadoPokemonApi, "speed")

                detalleequipopokemon.imagen = resultadoPokemonApi.SpritesData.BackDefault

                ' llamar servicio  para trade datos de cada pokemon
            Next

            ' llenar los atackes  y defensas




            TempData("TempDetalleEquipo") = detalleEquipoa
            Return RedirectToAction("Index")
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

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
