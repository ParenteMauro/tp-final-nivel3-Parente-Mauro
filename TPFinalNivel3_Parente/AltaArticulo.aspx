<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaArticulo.aspx.cs" Inherits="TPFinalNivel3_Parente.AltaArticulo1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
       
    </style>
    <div class="container row m-3 border p-3" style="border-radius: 5px">
        <div class="container col-6">
            <div class="form-group ">
                <label class="form-check-inline">Código:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtCodigo"></asp:TextBox>
            </div>
            <div class="form-group mt-3">
                <label class="form-check-inline">Número:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNumero"></asp:TextBox>
            </div>
            <div class="form-group mt-3">
                <label class="form-check-inline">Descripción:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtDescripcion"></asp:TextBox>
            </div>
            <div class="form-group mt-3">
                <label class="form-check-inline">Marca:</label>
                <asp:DropDownList CssClass="form-control" runat="server" ID="dwlMarca"></asp:DropDownList>
            </div>
            <div class="form-group mt-3">
                <label class="form-check-inline">Categoría:</label>
                <asp:DropDownList CssClass="form-control" runat="server" ID="dwlCategoria"></asp:DropDownList>
            </div>
        </div>
        <div class="container col-6">
            <label class="form-check-inline">Imagen:</label>
            <asp:TextBox runat="server" CssClass="form-control" Text="sadsa"></asp:TextBox>
        </div>
        <div class="container mt-4">
            <asp:Button runat="server" Text="Agregar" ID="btnAgregar" CssClass="btn btn-success" OnClick="btnAgregar_Click" />
        </div>
    </div>
</asp:Content>

