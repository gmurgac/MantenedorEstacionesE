<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="VerPuntos.aspx.cs" Inherits="EstacionesElectricasWeb.VerPuntos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

        <asp:DropDownList ID="tipoDdl" runat="server" AutoPostBack="true"
            OnSelectedIndexChanged="tipoDdl_SelectedIndexChanged"
            >
            <asp:ListItem Value="nulo" Selected="True" Text="--Seleccione--"></asp:ListItem>
            <asp:ListItem Value="dual" Text="Dual"></asp:ListItem>
            <asp:ListItem Value="electrico" Text="Electrico"></asp:ListItem>
            
        </asp:DropDownList>
    </div>

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
            onrowupdating="puntosGrid_RowUpdating"
           >
            <Columns>
              <asp:BoundField HeaderText="ID de Punto Carga" DataField="id" ReadOnly="true"  />
                
               
                <asp:TemplateField HeaderText="Tipo"  >
             <EditItemTemplate>
                 <asp:DropDownList ID="ddlTipo" runat="server">
                 </asp:DropDownList>
             </EditItemTemplate>
             <ItemTemplate>
                 <asp:Label ID="Label1" runat="server" Text='<%# Bind("idTipo") %>'></asp:Label>
             </ItemTemplate>
         </asp:TemplateField>
                <asp:TemplateField HeaderText="Estacion"  >
             <EditItemTemplate>
                 <asp:DropDownList ID="ddlDirEstacion" runat="server">
                 </asp:DropDownList>
             </EditItemTemplate>
             <ItemTemplate>
                 <asp:Label ID="Label2" runat="server" Text='<%# Bind("idEstacion") %>'></asp:Label>
             </ItemTemplate>
         </asp:TemplateField>
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
