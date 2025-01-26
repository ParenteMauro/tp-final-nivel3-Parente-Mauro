<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPFinalNivel3_Parente.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .divLogIn {
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
            background-color: rgb(33, 37, 41);
            color: snow;
            border-radius: 10px;
            min-height: 300px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3 divLogIn pb-2" style="width: 50%">
        <h3 class="mt-3">Registrarse</h3>
        <div style="width: 80%">
            <label style="justify-content: left">Email:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail"></asp:TextBox>
            

            <label>Contraseña:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtPass"></asp:TextBox>
            
            <hr />
            <h4>Opcionales</h4>
            <label style="justify-content: left">Nombre:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"></asp:TextBox>
            <label>Apellido:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido"></asp:TextBox>
        </div>
        
        <asp:Button runat="server" CssClass="btn btn-light mt-5" Text="Registrarse" ID="btnRegistro" OnClick="btnRegistro_Click"></asp:Button>
        <asp:Label CssClass="mt-3" ID="txtRegistroFallido" runat="server"></asp:Label>
    </div>
</asp:Content>
