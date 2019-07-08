<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmCursos.aspx.cs" Inherits="SistemaMatricula.ModuloMatriculas.wfrmCursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/estudiante.css" rel="stylesheet" />
    <table>
        <tr>
            <td style="height: 25px">
                &nbsp;</td>
            <td style="height: 25px; width: 138px;">
                <asp:HiddenField ID="hdIdCurso" runat="server" Value="0" />
            </td>
            <td style="height: 25px"></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Ingrese CURSO;"></asp:Label>
            </td>
            <td style="width: 138px">
                <asp:TextBox ID="txtNombreCurso" runat="server" ValidationGroup="form"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombreCurso" ErrorMessage="Ingrese el nombre del curso" ForeColor="Red" ValidationGroup="form"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px">
                <asp:Label ID="Label3" runat="server" Text="Ingrese SEMESTRE:"></asp:Label>
            </td>
            <td style="height: 20px; width: 138px;">
                <asp:TextBox ID="txtSemestre" runat="server" ValidationGroup="form"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSemestre" ErrorMessage="Ingrese el número de semestre" ForeColor="Red" ValidationGroup="form"></asp:RequiredFieldValidator>
            </td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="height: 22px">
                <asp:Label ID="Label4" runat="server" Text="Ingrese CARRERA:"></asp:Label>
            </td>
            <td style="height: 22px; width: 138px;">
                <asp:TextBox ID="txtCarrera" runat="server" ValidationGroup="form"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCarrera" ErrorMessage="Ingrese la carrera(3 digitos)" ForeColor="Red" ValidationGroup="form"></asp:RequiredFieldValidator>
            </td>
           
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 138px">
                <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="form" />
                <asp:LinkButton ID="lnkCancelar" runat="server" OnClick="lnkCancelar_Click">Cancelar</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
        </tr>
       
        </table>
    
    <asp:GridView ID="gvCursos" runat="server" AutoGenerateColumns="False" OnRowCommand="gvCursos_RowCommand">
        <Columns>
            <asp:BoundField DataField="nombre_curso" HeaderText="CURSO" />
            <asp:BoundField DataField="semestre" HeaderText="SEMESTRE"></asp:BoundField>
            <asp:BoundField DataField="carrera" HeaderText="CARRERA"></asp:BoundField>
            <asp:TemplateField HeaderText="Editar">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="editar" CommandArgument='<%# Eval("id")%>'>EDITAR</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Eliminar">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" OnClientClick="return confirm('Desea eliminar el Curso?');" runat="server" CommandName="eliminar" CommandArgument='<%# Eval("id")%>' >ELIMINAR</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>



</asp:Content>
