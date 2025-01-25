<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinalNivel3_Parente.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color: rgb(33, 37, 41); color: snow; border-radius:10px;" class="row mt-3 pb-3" >
        <hr />
        <div class="input-group">
        <div class="input-group-prepend">
            <asp:TextBox runat="server" CssClass="input-group-text" Enabled="false" style="user-select:none; background-color:lightgrey " Text="@"></asp:TextBox>
        </div>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail"></asp:TextBox>
      </div>
        <div class="col">
            <div class="form-group">
                <label>Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="form-group ">
                <label>Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
            </div>
        </div>
        <div class="col">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="container" style="display: flex; justify-content: center;">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <label class="form-check-inline">Imagen:</label>
                        <asp:TextBox runat="server" CssClass="form-control" Text="" ID="txtImagen" OnTextChanged="txtImagen_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:Image ImageUrl="https://png.pngtree.com/png-vector/20221109/ourmid/pngtree-no-image-available-icon-flatvector-illustration-graphic-available-coming-vector-png-image_40958834.jpg"
                            runat="server" ID="pbxImagen" Style="max-width: 100%; max-height: 400px;" CssClass="border p2 mt-3 img-fluid" />
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
        <div style="display:flex; justify-items:center; align-items:center; justify-content: space-around;">
        <asp:Button Text="Modificar" runat="server" CssClass="btn btn-dark border-light border-1"  ID="btnModificar" OnClick="btnModificar_Click" />
            </div>
    </div>
</asp:Content>
