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
    </style>
    <div class="container mt-3">
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
</asp:Content>
