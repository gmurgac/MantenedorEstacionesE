<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="VerPuntos.aspx.cs" Inherits="EstacionesElectricasWeb.VerPuntos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mt-5">
        <asp:gridview ID="puntosGrid"
            AutoGenerateColumns="false"
            EmptyDataText="No hay Puntos de carga registrados" CssClass="table table-hover"
            OnRowCommand="puntosGrid_RowCommand"
            runat="server"
            DataKeyNames="id"
            AutoGenerateEditButton="True"
            onrowediting="puntosGrid_RowEditing"
            onrowcancelingedit="puntosGrid_RowCancelingEdit" 
            onrowupdating="puntosGrid_RowUpdating">
            <Columns>
                <asp:BoundField HeaderText="ID de Punto Carga" DataField="id" />
                <asp:BoundField HeaderText="Tipo" DataField="tipo" />
                <asp:BoundField HeaderText="Estacion" DataField="idEstacion" />
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
