<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TPFinalNivel3_Parente.LogIn" %>

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
    <div class="container mt-3 divLogIn" style="width: 50%">
        <h3>Log In</h3>
        <div style="width: 80%">
            <label style="justify-content: left">Email:</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail"></asp:TextBox>
            <label>Contraseña:</label>

            <asp:TextBox runat="server" CssClass="form-control" ID="txtPass"></asp:TextBox>
        </div>
        <asp:Button runat="server" CssClass="btn btn-light mt-3" Text="Registrarse" ID="btnRegistrarse" OnClick="btnLogIn_Click"></asp:Button>
        <asp:Label CssClass="mt-3" ID="txtIngresoFallido" runat="server"></asp:Label>
    </div>
</asp:Content>
