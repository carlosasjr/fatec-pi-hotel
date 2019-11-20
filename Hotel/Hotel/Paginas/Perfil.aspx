<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/Principal.master" AutoEventWireup="true" CodeFile="Perfil.aspx.cs" Inherits="Paginas_Default3" %>

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
            <small>Cadastro Perfil</small>
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
                                    <div class="col-12 col-sm-11">
                                        <label for="txtdescricao">Perfil</label>
                                        <asp:TextBox ID="txtdescricao" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <!-- /.box-body -->
                        </div>
                        <!-- /.box box-default -->
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <!-- PERMISSÕES -->
                            <div class="box box-default">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Permissões</h3>

                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                                    </div>
                                </div>

                                <div class="box-body">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-12 col-sm-4">
                                                <asp:CheckBox ID="chkcadastrarhotel" runat="server" CssClass="form-control" Text="Cadastrar Hotel"></asp:CheckBox>
                                            </div>

                                            <div class="col-12 col-sm-4">
                                                <asp:CheckBox ID="chkcadastrarperfil" runat="server" CssClass="form-control" Text="Cadastrar Perfil"></asp:CheckBox>
                                            </div>

                                            <div class="col-12 col-sm-4">
                                                <asp:CheckBox ID="chkcadastrarfuncionario" runat="server" CssClass="form-control" Text="Cadastrar Funcionário"></asp:CheckBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-12 col-sm-4">
                                                <asp:CheckBox ID="chknovareserva" runat="server" CssClass="form-control" Text="Nova Reserva"></asp:CheckBox>
                                            </div>

                                            <div class="col-12 col-sm-4">
                                                <asp:CheckBox ID="chkmapaocupacao" runat="server" CssClass="form-control" Text="Mapa de Ocupação"></asp:CheckBox>
                                            </div>

                                            <div class="col-12 col-sm-4">
                                                <asp:CheckBox ID="chkcadastrarcategoria" runat="server" CssClass="form-control" Text="Cadastrar Categoria"></asp:CheckBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-12 col-sm-4">
                                                <asp:CheckBox ID="chkcadastrartarifa" runat="server" CssClass="form-control" Text="Cadastrar Tarifa"></asp:CheckBox>
                                            </div>

                                            <div class="col-12 col-sm-4">
                                                <asp:CheckBox ID="chkcadastrarapartamento" runat="server" CssClass="form-control" Text="Cadastrar Apartamento"></asp:CheckBox>
                                            </div>

                                            <div class="col-12 col-sm-4">
                                                <asp:CheckBox ID="chkcadastrarhospede" runat="server" CssClass="form-control" Text="Cadastrar Hóspede"></asp:CheckBox>
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

