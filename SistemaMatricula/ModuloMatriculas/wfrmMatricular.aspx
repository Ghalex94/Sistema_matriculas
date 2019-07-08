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
    
    <asp:GridView ID="gvMatriculas" runat="server" AutoGenerateColumns="False" OnRowCommand="gvMatriculas_RowCommand">
        <Columns>
            <asp:BoundField DataField="nombre_estudiante" HeaderText="ESTUDIANTE" />
            <asp:BoundField DataField="nombre_curso" HeaderText="CURSO"></asp:BoundField>
            <asp:BoundField DataField="fecha_matricula" HeaderText="FECHA DE MATRICULA"></asp:BoundField>
            <asp:TemplateField HeaderText="ELIMINAR">
                <ItemTemplate>  
                    <asp:LinkButton ID="lbEliminar" OnClientClick="return confirm('Desea eliminar esta Matricula?');"  runat="server" CommandName="eliminar" CommandArgument='<%# Eval("id")%>'>ELIMINAR</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>



</asp:Content>
