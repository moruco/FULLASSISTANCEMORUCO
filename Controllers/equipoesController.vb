﻿Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports FULLASSISTANCEMORUCO

Namespace Controllers
    Public Class equipoesController
        Inherits System.Web.Mvc.Controller

        Private db As New FULLASSISTANCEEntities1

        ' GET: equipoes/Create
        Function Create() As ActionResult
            Dim Equipo As New equipo()
            Equipo.idusuario = TempData("idUsuario")
            ' aqui pasar el id del usuario y mostrar
            Return View(Equipo)
        End Function
        ' GET: equipoes
        Function Index() As ActionResult

            If TempData.ContainsKey("idusuario") Then
                Dim iidusuario As Integer = TempData("idUsuario")
                Dim Etquipo As List(Of equipo) = db.equipo.Where(Function(f) f.idusuario = iidusuario).ToList()
                TempData("idUsuario") = iidusuario

                Return View(Etquipo)
            Else
                Return View(Me)
            End If





            'If TempData.ContainsKey("TempEquipo") Then
            '    Dim TempEquipo As List(Of equipo) = TempData("TempEquipo")

            '    ' Your logic with tempDetaequipoList
            '    Return View(TempEquipo)
            'Else
            '    'TempData("idusuario") = id

            '    ''                Return View(TempEquipo)


            '    ''Return RedirectToAction("Index", "equipoes")
            'End If

        End Function

        ' GET: equipoes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            'Dim detaequipo As New DETALLEEQUIPO()
            'If IsNothing(id) Then
            '    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            'End If
            'Dim equipo As equipo = db.equipo.Find(id)
            'If IsNothing(equipo) Then
            '    Return HttpNotFound()
            'End If

            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            'Dim detaequipo As DETALLEEQUIPO = db.DETALLEEQUIPO.Select Of(Function(e) e.Idequipo = id)
            Dim detalleEquipo As List(Of DETALLEEQUIPO) = db.DETALLEEQUIPO.Where(Function(e) e.Idequipo = id).ToList()

            If IsNothing(detalleEquipo) OrElse detalleEquipo.Count = 0 Then
                TempData("idEquipo") = id
                Return RedirectToAction("Index", "Pokemon")
            End If
            If detalleEquipo.Count > 0 Then
                ' If no records are found, redirect to another controller's action
                TempData("TempDetalleEquipo") = detalleEquipo
                Return RedirectToAction("Index", "DETALLEEQUIPOes")
            End If


        End Function



        ' POST: equipoes/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="idequipo,idusuario,descripcion,baja,fecha")> ByVal equipo As equipo) As ActionResult
            If ModelState.IsValid Then
                db.equipo.Add(equipo)
                db.SaveChanges()

                TempData("idequipo") = equipo.idequipo

                Return RedirectToAction("Index", "Pokemon")

                'Return RedirectToAction("Index")
            End If
            Return View(equipo)
        End Function

        ' GET: equipoes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim equipo As equipo = db.equipo.Find(id)
            If IsNothing(equipo) Then
                Return HttpNotFound()
            End If
            Return View(equipo)
        End Function

        ' POST: equipoes/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        'más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="idequipo,idusuario,descripcion,baja,fecha")> ByVal equipo As equipo) As ActionResult
            If ModelState.IsValid Then
                db.Entry(equipo).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(equipo)
        End Function

        ' GET: equipoes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim equipo As equipo = db.equipo.Find(id)
            If IsNothing(equipo) Then
                Return HttpNotFound()
            End If
            Return View(equipo)
        End Function

        ' POST: equipoes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim equipo As equipo = db.equipo.Find(id)
            db.equipo.Remove(equipo)
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
