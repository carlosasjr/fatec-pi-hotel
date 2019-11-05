<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/Principal.master" AutoEventWireup="true" CodeFile="listarHospede.aspx.cs" Inherits="Paginas_Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Se precisar, coloque os links para seus css aqui -->
    <!-- BootStrap já está na pagina master, então é só usar aqui... -->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Identificação da página, altere esses dados para a página correspondente. -->
        <section class="content-header">
            <h1>Hospedes
            <small>Controle de Hospedes</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="index.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Hospede</li>
            </ol>
        </section>

        <section class="content">
            <!-- Seu conteúdo vai aqui -->

            <asp:LinkButton ID="lbCadastrar" runat="server" CssClass="btn btn-primary" OnClick="lbCadastrar_Click">Cadastrar</asp:LinkButton>
            <br />
            <br />
            <asp:GridView ID="gdvHospede" CssClass="table table-hover table-success tabela" runat="server" AutoGenerateColumns="false" OnRowCommand="gdvHospede_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="pes_id" />
                    <asp:BoundField HeaderText="Nome" DataField="pes_nome" />
                    <asp:BoundField HeaderText="CPF/CNPJ" DataField="pes_cpf_cnpj" />

                    <asp:TemplateField HeaderText="Ações">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbAlterar" runat="server" CssClass="btn btn-dark" CommandName="Alterar" CommandArgument='<%# Bind("pes_id") %>'>Alterar</asp:LinkButton>
                            <asp:LinkButton ID="lbDeletar" runat="server" CssClass="btn btn-danger" CommandName="Deletar" CommandArgument='<%# Bind("pes_id") %>'>Deletar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </section>

    </div>

    <!-- Se precisar, coloque os links scripts js aqui -->
</asp:Content>

