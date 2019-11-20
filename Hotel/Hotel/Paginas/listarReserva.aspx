<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/Principal.master" AutoEventWireup="true" CodeFile="listarReserva.aspx.cs" Inherits="Paginas_Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Se precisar, coloque os links para seus css aqui -->
    <!-- BootStrap já está na pagina master, então é só usar aqui... -->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Identificação da página, altere esses dados para a página correspondente. -->
        <section class="content-header">
            <h1>Reservas
            <small>Controle de Reservas</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="index.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Nova Reserva</li>
            </ol>
        </section>

        <section class="content">
            <asp:LinkButton ID="lbCadastrar" runat="server" CssClass="btn btn-primary" OnClick="lbCadastrar_Click">Nova Reserva</asp:LinkButton>
            <br />
            <br />
            <asp:GridView ID="gdvReserva" CssClass="table table-hover table-success tabela" runat="server" AutoGenerateColumns="false" OnRowCommand="gdvReserva_RowCommand" OnSelectedIndexChanged="gdvReserva_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Hospede" DataField="pes_nome" />
                    <asp:BoundField HeaderText="Entrada" DataField="res_previsao_chegada" />
                    <asp:BoundField HeaderText="Saída" DataField="res_previsao_saida" />
                    <asp:BoundField HeaderText="Check-In" DataField="res_checkin" />
                    <asp:BoundField HeaderText="Check-Out" DataField="res_checkout" />

                    <asp:TemplateField HeaderText="Ações">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbAlterar" runat="server" CssClass="btn btn-primary" ToolTip="Alterar" CommandName="Alterar" CommandArgument='<%# Bind("res_id") %>'><i class="fa fa-edit"></i></asp:LinkButton>
                            <asp:LinkButton ID="lbCheckin" runat="server" CssClass="btn btn-success" ToolTip="Check-in" CommandName="CheckIn" CommandArgument='<%# Bind("res_id") %>'><i class="fa fa-check"></i></asp:LinkButton>
                            <asp:LinkButton ID="lbCheckout" runat="server" CssClass="btn btn-microsoft" ToolTip="Check-out" CommandName="CheckOut" CommandArgument='<%# Bind("res_id") %>'><i class="fa fa-unlock"></i></asp:LinkButton>
                            <asp:LinkButton ID="lbCancelar" runat="server" CssClass="btn btn-danger" ToolTip="Cancelar" CommandName="Cancelar" CommandArgument='<%# Bind("res_id") %>'><i class="fa fa-times"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>



        </section>

    </div>

    <!-- Se precisar, coloque os links scripts js aqui -->
</asp:Content>

