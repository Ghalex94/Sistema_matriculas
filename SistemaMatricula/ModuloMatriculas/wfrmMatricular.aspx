<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmMatricular.aspx.cs" Inherits="SistemaMatricula.ModuloMatriculas.wfrmMatricular" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/estudiante.css" rel="stylesheet" />
    <table>
        <tr>
            <td style="height: 25px">
                &nbsp;</td>
            <td style="height: 25px">
                &nbsp;</td>
            <td style="height: 25px"></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px">
                <asp:Label ID="Label3" runat="server" Text="Ingrese SEMESTRE:"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="txtSemestre" runat="server"></asp:TextBox>
            </td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="height: 22px">
                <asp:Label ID="Label4" runat="server" Text="Ingrese CARRERA:"></asp:Label>
            </td>
            <td style="height: 22px">
                <asp:TextBox ID="txtCarrera" runat="server"></asp:TextBox>
            </td>
           
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
                <asp:LinkButton ID="lnkCancelar" runat="server">Cancelar</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
        </tr>
       
        </table>
    
    <asp:GridView ID="gvMatriculas" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="nombre_curso" HeaderText="CURSO" />
            <asp:BoundField DataField="semestre" HeaderText="SEMESTRE"></asp:BoundField>
            <asp:BoundField DataField="carrera" HeaderText="CARRERA"></asp:BoundField>
        </Columns>
    </asp:GridView>



</asp:Content>
