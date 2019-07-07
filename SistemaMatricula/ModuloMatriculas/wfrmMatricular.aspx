<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmMatricular.aspx.cs" Inherits="SistemaMatricula.ModuloMatriculas.wfrmMatricular" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/estudiante.css" rel="stylesheet" />
    <table>
        <tr>
            <td style="height: 25px">
                </td>
            <td style="height: 25px">
                </td>
            <td style="height: 25px"></td>
        </tr>
        <tr>
            <td style="height: 10px">
                </td>
            <td style="height: 10px">
                </td>
            <td style="height: 10px"></td>
        </tr>
        <tr>
            <td style="height: 20px">
                <asp:Label ID="Label3" runat="server" Text="ALUMNO:"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:DropDownList ID="ddlAlumno" runat="server">
                </asp:DropDownList>
            </td>
            <td style="height: 20px"></td>

        </tr>
        <tr>
            <td style="height: 22px">
                <asp:Label ID="Label4" runat="server" Text="CURSO"></asp:Label>
            </td>
            <td style="height: 22px">
                <asp:DropDownList ID="ddlCurso" runat="server">
                </asp:DropDownList>
                <asp:TextBox ID="txtPrueba" runat="server"></asp:TextBox>
            </td>
           
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnMatricular" runat="server" OnClick="btnMatricular_Click" Text="MATRICULAR" />
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
