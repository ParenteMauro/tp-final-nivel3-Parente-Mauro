<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaArticulo.aspx.cs" Inherits="TPFinalNivel3_Parente.AltaArticulo1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

        function comprobarCampos() {

            const txtNombre = document.getElementById("txtNombre");
            const txtCodigo = document.getElementById("txtCodigo");
            const dwlMarca = document.getElementById("dwlMarca");
            const dwlCategoria = document.getElementById("dwlCategoria");
            const camposNecesarios = document.getElementById("camposNecesarios");
            const txtPrecio = document.getElementById("txtPrecio");
            const precioRegex = /^(\d+(\.\d{1,2})?)?$/;
            const precioAlert = document.getElementById("precioAlert");
            if (txtCodigo.value == "" || txtNombre.value == "" || dwlMarca.selectedIndex === 0 || dwlCategoria.selectedIndex === 0 ||
            (!precioRegex.test(txtPrecio.value)) ) {

                if (txtNombre.value == "")
                    txtNombre.classList.add("is-invalid");
                else
                    txtNombre.classList.remove("is-invalid");
                txtNombre.classList.add("is-valid");

                if (dwlMarca.selectedIndex === 0)
                    dwlMarca.classList.add("is-invalid");
                else
                    dwlMarca.classList.remove("is-invalid");
                dwlMarca.classList.add("is-valid")

                if (dwlCategoria.selectedIndex === 0)
                    dwlCategoria.classList.add("is-invalid");
                else
                    dwlCategoria.classList.remove("is-invalid");
                dwlCategoria.classList.add("is-valid")

                if (txtCodigo.value == "")
                    txtCodigo.classList.add("is-invalid");
                else
                    txtCodigo.classList.remove("is-invalid");
                txtCodigo.classList.add("is-valid");
                
                if (!precioRegex.test(txtPrecio.value)  ) {
                    txtPrecio.classList.add("is-invalid");
                    precioAlert.style.visibility = "visible";
                }
                else {
                    txtPrecio.classList.remove("is-invalid");
                    precioAlert.style.visibility = "visible: true";
                    txtPrecio.classList.add("is-valid")

                }

                camposNecesarios.style.color = "red";

                return false;
            }



            else
                return true;


        }



    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container row m-3 border p-3" style="border-radius: 5px">
        <div class="container col-6">
            <div class="form-group ">
                <label class="form-check-inline">Código:*</label>
                <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control" ID="txtCodigo"></asp:TextBox>
            </div>
            <div class="form-group mt-3">
                <label class="form-check-inline">Nombre:*</label>
                <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control" ID="txtNombre"></asp:TextBox>
            </div>

            <div class="form-group mt-3">
                <label class="sr-only" for="inlineFormInputGroupUsername2">Precio</label>
                <div class="input-group mb-2 mr-sm-2">
                    <div class="input-group-prepend">
                        <div class="input-group-text " style="color: green; background-color: lightgreen; user-select: none; border-color: green">$</div>
                    </div>
                    <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control" BorderColor="green" ID="txtPrecio"></asp:TextBox>

                </div>
                <p style="color: darkred; visibility:hidden;" id="precioAlert">El precio solo puede contener números y un punto</p>

            </div>
            <div class="form-group mt-3">
                <label class="form-check-inline">Descripción:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtDescripcion"></asp:TextBox>
            </div>
            <div class="form-group mt-3">
                <label class="form-check-inline">Marca:*</label>
                <asp:DropDownList CssClass="form-control" ClientIDMode="Static" runat="server" ID="dwlMarca"></asp:DropDownList>
            </div>
            <div class="form-group mt-3">
                <label class="form-check-inline">Categoría:*</label>
                <asp:DropDownList CssClass="form-control" ClientIDMode="Static" runat="server" ID="dwlCategoria"></asp:DropDownList>
            </div>
            <div style="text-align: right;" class="mt-3">
                <p id="camposNecesarios" style="color: lightgray">Los campos con * son necesarios</p>
            </div>
        </div>
        <div class="container col-6 " style="display: flex; justify-content: center; align-items: center;">

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

        <div class="container mt-4 col-6">
            <asp:Button runat="server" Text="Agregar" ID="btnAgregar" CssClass="btn btn-success" OnClientClick="return comprobarCampos()" OnClick="btnAgregar_Click"/>
            <asp:Button runat="server" Text="Eliminar" ID="btnEliminar" CssClass="btn btn-outline-danger" OnClientClick="return comprobarCampos()" OnClick="btnEliminar_Click" />
            <div style="display: flex; justify-content: center;" id="preguntaEliminar" runat="server">
                <label class="mt-2">¿Estás seguro de querer eliminar el Artículo?</label>
                <asp:Button Text="Si" ID="btnSeguroEliminar" CssClass="btn btn-danger m-1" runat="server" OnClick="btnSeguroEliminar_Click" />
                <asp:Button Text="NO" ID="btnCancelar" CssClass="btn btn-primary m-1" runat="server" OnClick="btnCancelar_Click" />
            </div>
        </div>
        <div class="col-6 mt-4" style="text-align: right">
        </div>
    </div>
</asp:Content>

