<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPFinalNivel3_Parente.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-img-top {
            object-fit: contain;
            width: 100%;
            height: 200px;
        }

        .card-footer {
            display: flex;
            justify-content: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="mt-3"> <u>Lista de Favoritos </u></h3>
    <div class="container"
        style="background-color: rgb(33, 37, 41); border-radius:10px"
        >
        <div class="row" style="justify-content:center;">

            <%if (Session["ListaFavoritos"] != null)
                        foreach (dominio.Articulo articulo in (List<dominio.Articulo>)Session["ListaFavoritos"])
                        { %>
            <div class="card m-3 col-2" style="padding: 0px; user-select: none;">
                <h5 class="card-title m-0  border-1" style="display: flex; justify-content: center;"><%:articulo.Nombre%></h5>
                <img src="<%: articulo.UrlImagen %>" class="card-img-top" alt="...">

                <div class="card-footer" style="background-color:mediumpurple">
                    <small>
                        <a href="Detalle.aspx?id=<%: articulo.Id %>" class="btn btn-dark">Ver más</a>
                    </small>
                </div>
            </div>
            <%} %>
        </div>
    </div>
</asp:Content>
