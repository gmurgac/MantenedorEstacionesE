<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistrarPunto.aspx.cs" Inherits="EstacionesElectricasWeb.RegistrarPunto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

     <div class="card">
        <div class="card-body">
            <div class="form-group">
                <label for="idPunto">ID de Punto de carga</label>
                <asp:textbox ID="idPunto" runat="server"></asp:textbox>
                <asp:requiredfieldvalidator ControlToValidate="idPunto"
                    CssClass="text-danger"
                    runat="server" errormessage="Id no valido"></asp:requiredfieldvalidator>
            </div>
            <div class="form-group">
                <label for="tipoRbl">Tipo punto de carga</label>
                <asp:RadioButtonList ID="tipoRbl" runat="server">
                    <asp:ListItem Value="Dual" Selected="False" Text="Dual"></asp:ListItem>
                    <asp:ListItem Value="Electrico" Selected="True" Text="Electrico"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <label for="estacionesDdl">Estacion pertenece</label>
                <asp:DropDownList ID="estacionesDdl" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <br />

            <asp:button ID="registrarPuntoBtn" runat="server" text="Registrar" CssClass="btn-dark"
                OnClick="ingresarBtn_click"
                />
        </div>
    </div>
</asp:Content>
