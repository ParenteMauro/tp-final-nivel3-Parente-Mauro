<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3_Parente.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card-img-top {
            object-fit: contain; 
            width: 100%;
            height: 200px; 
            
        }
        
        .card-footer{
            display:flex;
            justify-content:center;
           
        }
    </style>
    <div class="container">
        <div class="row">
        <% foreach (dominio.Articulo articulo in (List<dominio.Articulo>)Session["ListaArticulos"])
            { %>
        <div class="card m-3 col-2" style="padding:0px; user-select: none;">
                <h5 class="card-title m-0  border-1" style="display:flex; justify-content:center;"><%:articulo.Nombre%></h5>
            <img src="<%: articulo.UrlImagen %>" class="card-img-top" alt="...">
         
            <div class="card-footer">
                <small>
                    <button class="btn btn-dark" runat="server" id="btnMas">Ver mas</button>
                </small>
            </div>
        </div>
        <%} %>
    </div>
    </div>
</asp:Content>
