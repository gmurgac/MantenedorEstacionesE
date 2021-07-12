<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="VerEstaciones.aspx.cs" Inherits="EstacionesElectricasWeb.VerEstaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mt-5">
        <asp:gridview ID="estacionesGrid"
            AutoGenerateColumns="false"
            EmptyDataText="No hay Estaciones registradas" CssClass="table table-hover"
            OnRowCommand="estacionesGrid_RowCommand"
            runat="server">
            <Columns>
                <asp:BoundField HeaderText="ID de Estacion" DataField="id" />
                <asp:BoundField HeaderText="Direccion" DataField="direccion" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Eliminar registro"
                            CssClass="btn btn-danger"
                            CommandName="eliminar"
                            CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:gridview>
    </div>

</asp:Content>
