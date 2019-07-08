<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="wfrmAlumnos.aspx.cs" Inherits="SistemaMatricula.ModuloMatriculas.wfrmAlumnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/estudiante.css" rel="stylesheet" />
    <table>
        <tr>
            <td style="height: 25px">
                &nbsp;</td>
            <td style="height: 25px">
                <asp:HiddenField ID="hdIdAlumno" Value="0" runat="server" />
            </td>
            <td style="height: 25px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 25px">
                <asp:Label ID="Label1" runat="server" Text="Ingrese DNI:"></asp:Label>
            </td>
            <td style="height: 25px">
                <asp:TextBox ID="txtDni" runat="server" MaxLength="8" ValidationGroup="form"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDni" ErrorMessage="Dni es obligatorio" ForeColor="Red" ValidationGroup="form"></asp:RequiredFieldValidator>
            </td>
            <td style="height: 25px"></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Ingrese NOMBRE;"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" ValidationGroup="form"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre" ErrorMessage="Nombre es obligatorio" ForeColor="Red" ValidationGroup="form"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px">
                <asp:Label ID="Label3" runat="server" Text="Ingrese APE. PATERNO;"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="txtApePaterno" runat="server" ValidationGroup="form"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Apellido paterno es obligatorio" ForeColor="Red" ControlToValidate="txtApePaterno" ValidationGroup="form"></asp:RequiredFieldValidator>
            </td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Ingrese APE. MATERNO;"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApeMaterno" runat="server" ValidationGroup="form"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Apellido materno es obligatorio" ForeColor="Red" ControlToValidate="txtApeMaterno" ValidationGroup="form"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Ingrese FEC.NACIMIENTO;"></asp:Label>
            </td>
            <td>
                <asp:Calendar ID="dpFechaNac" runat="server"></asp:Calendar>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Ingrese ESTADO CIVIL;"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="radioEstadoCivil" runat="server" ValidationGroup="form">
                    <asp:ListItem Value="S">Soltero</asp:ListItem>
                    <asp:ListItem Value="C">Casado</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="form" />
                <asp:LinkButton ID="lnkCancelar" runat="server" ValidationGroup="form" OnClick="lnkCancelar_Click">Cancelar</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="form" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    
    <asp:GridView ID="gvEstudiantes" runat="server" AutoGenerateColumns="False" OnRowCommand="gvEstudiantes_RowCommand">
        <Columns>
            <asp:BoundField DataField="dni" HeaderText="DNI" />
            <asp:BoundField DataField="nombre_estudiante" HeaderText="NOMBRE"></asp:BoundField>
            <asp:BoundField DataField="apellido_paterno" HeaderText="APE.PATERNO"></asp:BoundField>
            <asp:BoundField DataField="apellido_materno" HeaderText="APE.MATERNO"></asp:BoundField>
            <asp:TemplateField HeaderText="Editar">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="editar" CommandArgument='<%# Eval("id")%>'>EDITAR</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Eliminar">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" OnClientClick="return confirm('Desea eliminar al Alumno?');" runat="server" CommandName="eliminar" CommandArgument='<%# Eval("id")%>' >ELIMINAR</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>



</asp:Content>
