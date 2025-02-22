﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TPFinalNivel3_Parente.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            width: auto;
            height: auto;
        }

        .txtBlanco {
            color: snow;
        }

        .botonEstrella {
            font-size: 50px; 
            font-family: Arial, sans-serif; 
            background-color: transparent;
            justify-content: right;
            border: none;
            cursor: pointer;
            transition: all 0.3s ease;
            color: snow;
            user-select: none;
        }

            .botonEstrella:hover::before {
                content: "★"; 
                color: gold; 
            }

            .botonEstrella::before {
                content: "☆"; 
            }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container row m-3 border p-3" style="border-radius: 10px; padding: 0%; width: 50%; background-color: rgb(33, 37, 41)">
        <div class="container col " style="display: flex; justify-content: center; align-items: center;">

            <div class="container" style="display: flex; justify-content: center;">

                <asp:Image ImageUrl="" runat="server" ID="pbxImagen" Style="max-width: 100%; max-height: 400px;" CssClass=" mt-3 img-fluid" />

            </div>
        </div>
        <div class="container col-4 txtBlanco">
            <div class="form-group ">
                <label class="form-check-inline txtBlanco">Código:</label>
                <asp:Label runat="server" CssClass="form-label" ID="txtCodigo"></asp:Label>
            </div>
            <div class="form-group mt-3 ">
                <label class="form-check-inline ">Nombre:</label>
                <asp:Label runat="server" CssClass="form-label" ID="txtNombre"></asp:Label>
            </div>

            <div class="form-group mt-3">
                <label class="form-check-inline">Descripción:</label>
                <asp:Label runat="server" CssClass="form-label" ID="txtDescripcion"></asp:Label>
            </div>
            <div class="form-group mt-3">
                <label class="form-check-inline">Marca:</label>
                <asp:Label CssClass="form-label" runat="server" ID="txtMarca"></asp:Label>
            </div>
            <div class="form-group mt-3">
                <label class="form-check-inline">Categoría:</label>
                <asp:Label CssClass="form-label" runat="server" ID="txtCategoria"></asp:Label>
            </div>
            <div class="form-group mt-3">
                <label class="sr-only" for="inlineFormInputGroupUsername2">Precio</label>
                <div class="input-group mb-2 mr-sm-2">
                    <div class="input-group-prepend">
                        <div class="input-group-text " style="color: green; background-color: lightgreen; user-select: none; border-color: green">$</div>
                    </div>
                    <asp:Label runat="server" CssClass="form-label m-2 " BorderColor="green" ID="txtPrecio"></asp:Label>

                </div>
            </div>
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <div style="user-select:none; display:flex" >
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnFav" runat="server" CssClass="botonEstrella" OnClick="btnFav_Click" Text="☆" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <a href="Favoritos.aspx" class="btn btn-outline-secondary mt-3" style="max-height:40px; color:gold; border-color:gold">Ver Lista Favoritos</a>
            </div>


        </div>

    </div>
    <div >
        <a href="Default.aspx" class="btn btn-primary">Volver al Home </a>
    </div>

</asp:Content>
