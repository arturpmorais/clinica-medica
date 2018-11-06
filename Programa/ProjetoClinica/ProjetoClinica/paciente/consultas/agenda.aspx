<%@ Page Title="" Language="C#" MasterPageFile="~/paciente/Paciente.Master" AutoEventWireup="true" CodeBehind="agenda.aspx.cs" Inherits="ProjetoClinica.paciente.consultas.agenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PacienteContent" runat="server">
    <asp:Table id="Table1" runat="server"
        CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell>
                Row 0, Col 0
            </asp:TableCell>
            <asp:TableCell>
                Row 0, Col 1
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Row 1, Col 0
            </asp:TableCell>
            <asp:TableCell>
                Row 1, Col 1
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
