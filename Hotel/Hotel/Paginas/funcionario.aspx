<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/Principal.master" AutoEventWireup="true" CodeFile="Funcionario.aspx.cs" Inherits="Paginas_Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Se precisar, coloque os links para seus css aqui -->
    <!-- BootStrap já está na pagina master, então é só usar aqui... -->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Identificação da página, altere esses dados para a página correspondente. -->
        <section class="content-header">
            <h1>Hotel
            <small>Cadastro Funcionário</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="index.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">
                Hotel<li>
            </ol>
        </section>

        <section class="content">
            <!-- Seu conteúdo vai aqui -->

            <div class="row">
                <div class="col-md-11">
                    <!-- DADOS PRINCIPAIS -->
                    <div class="box box-default">
                        <div class="box-header with-border">
                            <h3 class="box-title">Dados Principais</h3>

                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                            </div>
                        </div>

                        <div class="box-body">
                            <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Visible="False"></asp:TextBox>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-12 col-sm-4">
                                        <label for="txtnome">Nome</label>
                                        <asp:TextBox ID="txtnome" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-12 col-sm-4">
                                        <label for="txtemail">Email</label>
                                        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-12 col-sm-4">
                                        <label for="txtsenha">Senha</label>
                                        <asp:TextBox ID="txtsenha" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-12 col-sm-6">
                                        <label for="txttelefone">Telefone</label>
                                        <asp:TextBox ID="txttelefone" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="col-12 col-sm-6">
                                        <label for="txtcelular">Celular</label>
                                        <asp:TextBox ID="txtcelular" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-12 col-sm-6">
                                        <label for="txtcpf">CPF/CNPJ</label>
                                        <asp:TextBox ID="txtcpf" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-12 col-sm-6">
                                        <label for="txtrg">RG</label>
                                        <asp:TextBox ID="txtrg" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-12 col-sm-6">
                                        <label for="txtestadoCivil">Estado Civil</label>
                                        <asp:TextBox ID="txtestadocivil" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-12 col-sm-6">
                                       <label for="txtdatanasc">Nascimento</label> 
                                        <asp:TextBox ID="txtdatanasc" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <!-- /.box-body -->
                        </div>
                        <!-- /.box box-default -->
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <!-- ENDEREÇO -->
                            <div class="box box-default">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Endereço</h3>

                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                                    </div>
                                </div>

                                <div class="box-body">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-12 col-sm-8">
                                                <label for="txtendereco">Endereço</label>
                                                <asp:TextBox ID="txtendereco" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="col-12 col-sm-4">
                                                <label for="txtnumero">Número</label>
                                                <asp:TextBox ID="txtnumero" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="form-group">
                                                <div class="col-12 col-sm-6">
                                                    <label for="txtbairro">Bairro</label>
                                                    <asp:TextBox ID="txtbairro" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>

                                                <div class="col-12 col-sm-6">
                                                    <label for="txtcomplemento">Complemento</label>
                                                    <asp:TextBox ID="txtcomplemento" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-12 col-sm-4">
                                                    <label for="DdlUF">UF</label>
                                                    <asp:DropDownList ID="DdlUF" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlUF_SelectedIndexChanged"></asp:DropDownList>
                                                </div>

                                                <div class="col-12 col-sm-4">
                                                    <label for="ddlCidade">Cidade</label>
                                                    <asp:DropDownList ID="ddlCidade" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </div>
                                                <div class="col-12 col-sm-4">
                                                    <label for="txtcep">CEP</label>
                                                    <asp:TextBox ID="txtcep" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.box-body -->
                                </div>
                                <!-- /.box box-default -->

                            </div>
                            <asp:Button runat="server" ID="btnSalvar" CssClass="btn btn-primary" Text="Salvar" OnClick="btnSalvar_Click" />

                            <br />
                            <br />
                            <br />
                            <div class="col-12 col-sm-12">
                                <asp:Label runat="server" CssClass="alert alert-info" Visible="false" ID="lblMensagem"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

    </div>



    <!-- Se precisar, coloque os links scripts js aqui -->
</asp:Content>

