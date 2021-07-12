<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistrarEstacion.aspx.cs" Inherits="EstacionesElectricasWeb.RegistrarEstacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card">
        <div class="card-body">
            <div class="form-group">
                <label for="idEstacion">ID de Estacion</label>
                <asp:textbox ID="idEstacion" runat="server" CssClass="form-control"></asp:textbox>
                <asp:requiredfieldvalidator ControlToValidate="idEstacion"
                    CssClass="text-danger"
                    runat="server" errormessage="Id no valido"></asp:requiredfieldvalidator>
            </div>
            <div class="form-group">
                <label for="dirEstacion">Direccion de Estacion</label>
                <asp:textbox ID="dirEstacion" runat="server"></asp:textbox>
                <asp:requiredfieldvalidator ControlToValidate="dirEstacion"
                    CssClass="text-danger"
                    runat="server" errormessage="Direccion no valido"></asp:requiredfieldvalidator>
            </div>
            <br />
            <asp:button ID="registrarEstBtn" runat="server" text="Registrar" CssClass="btn-dark"
                OnClick="ingresarBtn_click"
                />
        </div>
    </div>

</asp:Content>
