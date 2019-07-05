<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfrmCursos.aspx.cs" Inherits="SistemaMatricula.ModuloMatriculas.wfrmAlumnos" %>
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
                <asp:Label ID="Label2" runat="server" Text="Ingrese CURSO;"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombreCurso" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre" ErrorMessage="Nombre es obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
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
            <td>
                <asp:Label ID="Label4" runat="server" Text="Ingrese CARRERA:"></asp:Label>
            </td>
            <td>
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
    
    <asp:GridView ID="gvCursos" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="curso" HeaderText="CURSO" />
            <asp:BoundField DataField="semestre" HeaderText="SEMESTRE"></asp:BoundField>
            <asp:BoundField DataField="carrera" HeaderText="CARRERA"></asp:BoundField>
        </Columns>
    </asp:GridView>



</asp:Content>
