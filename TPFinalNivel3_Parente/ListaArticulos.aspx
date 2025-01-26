<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="TPFinalNivel3_Parente.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .table-hover tbody tr:first-child:hover {
            --bs-table-hover-bg: transparent !important;
            background-color: transparent !important;
            cursor: default;
        }

        .table-hover tbody tr {
            user-select: none;
        }

        .table {
            user-select: none;
        }
    </style>
    <h3 class="m-3"><u>Lista de Artículos</u></h3>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
    <div class="form-group container mt-3" style="display: flex;">
        <label class="mt-3">Buscar Nombre:</label>
        <asp:TextBox CssClass="col form-control m-2" runat="server" Text="" ID="txtBuscarNombre" 
            OnTextChanged="txtBuscarNombre_TextChanged" AutoPostBack="true"></asp:TextBox>
    </div>
    <div class="form-group container mt-3" style="display: flex;">
        <label class="mt-3">Buscar Por:</label>
        <asp:DropDownList runat="server" ID="dwlPropiedad" CssClass="col form-group m-2" OnSelectedIndexChanged="dwlPropiedad_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        <asp:DropDownList runat="server" ID="dwlParametro" CssClass="col form-group m-2"></asp:DropDownList>
        <asp:TextBox CssClass="col form-control m-2" runat="server"  id="txtBusquedaAvanzada" Enabled="false" Text=""></asp:TextBox>
    </div>
    <div class="form-group container" style="display: flex; justify-content: center;">
        <asp:Button runat="server" CssClass="btn btn-primary col-1 m-2" Text="🔍︎" Enabled="false" ID="btnBusquedaAvanzada" OnClick="btnBusquedaAvanzada_Click" />
        <asp:Button runat="server" CssClass="btn btn-primary col-1 m-2" Text="↻" ID="btnResetear" OnClick="btnResetear_Click" Enabled="false" />
    </div>

    <div class="container mt-3" style="flex-direction: row">
        <asp:DataGrid runat="server" ID="dgvArticulos" CssClass="table table-hover " AutoGenerateColumns="false"
         OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">

            <Columns>
                <asp:BoundColumn DataField="Codigo" HeaderText="Código"></asp:BoundColumn>
                <asp:BoundColumn DataField="Nombre" HeaderText="Nombre"></asp:BoundColumn>
                <asp:BoundColumn DataField="Precio" HeaderText="Precio"></asp:BoundColumn>
                <asp:BoundColumn DataField="Marca" HeaderText="Marca"></asp:BoundColumn>
                <asp:BoundColumn DataField="Categoria" HeaderText="Categoria"></asp:BoundColumn>
                <asp:ButtonColumn HeaderText="Seleccionar" Text="✏️" CommandName="Select"></asp:ButtonColumn>
            </Columns>

        </asp:DataGrid>
    </div>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
