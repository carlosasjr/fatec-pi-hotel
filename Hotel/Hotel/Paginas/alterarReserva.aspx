<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/Principal.master" AutoEventWireup="true" CodeFile="alterarReserva.aspx.cs" Inherits="Paginas_Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Se precisar, coloque os links para seus css aqui -->
    <!-- BootStrap já está na pagina master, então é só usar aqui... -->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Identificação da página, altere esses dados para a página correspondente. -->
        <section class="content-header">
            <h1>Reserva
            <small>Controle de Reserva</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="index.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Alterar Reserva</li>
            </ol>
        </section>

        <section class="content">
            <div class="row">
                <div class="col-md-11">
                    <!-- DADOS PRINCIPAIS -->
                    <div class="box box-default">
                        <div class="box-header with-border">
                            <h3 class="box-title">Alterar Reserva</h3>

                            <div class="box-tools pull-right">
                                <asp:LinkButton ID="lbReservar" runat="server" CssClass="btn btn-facebook" OnClick="lbReservar_Click"><i class="fa fa-check-circle"></i>
                                        Efetivar Reserva
                                </asp:LinkButton>
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            </div>
                        </div>

                        <div class="box-body">
                            <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Visible="False"></asp:TextBox>

                            <div class="form-group">
                                <div class="col-12 col-sm-6">
                                    <label for="DdlHospede">Hospede</label>
                                    <asp:DropDownList ID="DdlHospede" runat="server" CssClass="form-control" AutoPostBack="False"></asp:DropDownList>
                                </div>

                                <div class="col-12 col-sm-3">
                                    <label for="txtDataEntrada">Data Entrada</label>
                                    <asp:TextBox ID="txtDataEntrada" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                </div>

                                <div class="col-12 col-sm-3">
                                    <label for="txtDataSaida">Data Saída</label>
                                    <asp:TextBox ID="txtDataSaida" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <br />

                            <div class="form-group">
                                <div class="col-12 col-sm-12">
                                    <label for="txtObservacoes">Observações</label>
                                    <asp:TextBox ID="txtObservacoes" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <br />


                        <div class="box box-default">
                            <div class="box-header with-border">
                                <h3 class="box-title">Adicionar Apartamentos</h3>

                                <div class="box-tools pull-right">
                                    <asp:LinkButton ID="LbFiltrarApartamentos" runat="server" CssClass="btn btn-danger" OnClick="LbFiltrarApartamentos_Click"><i class="fa fa-filter"></i>
                                      Filtrar Apartamentos
                                    </asp:LinkButton>
                                </div>
                            </div>

                            <div class="box-body">
                                <div class="col-12 col-sm-7">
                                    <asp:Label for="cblQuartosDisponiveis" runat="server" Text="Quartos Disponíveis:"></asp:Label>
                                    <br />
                                    <asp:CheckBoxList ID="cblQuartosDisponiveis" runat="server" EnableTheming="False" AutoPostBack="False"></asp:CheckBoxList>
                                    <asp:Label ID="txtDisponiveis" CssClass="info info-box-text bg-danger" runat="server" Visible="false"></asp:Label>
                                    <br />
                                    <asp:LinkButton ID="lbAdicionarQuarto" runat="server" CssClass="btn btn-primary" OnClick="lbAdicionarQuarto_Click"><i class="fa fa-plus"></i>
                                        Adicionar
                                    </asp:LinkButton>
                                    <br />
                                    <br />
                                </div>


                                <div class="col-12 col-sm-5">
                                    <asp:Label for="clbQuartosAdicionados" runat="server" Text="Quartos Adicionados:"></asp:Label>
                                    <br />
                                    <asp:CheckBoxList ID="clbQuartosAdicionados" runat="server" EnableTheming="False" AutoPostBack="False"></asp:CheckBoxList>
                                </div>
                            </div>
                        </div>
                        <!-- /.box-body -->


                    </div>

                     <asp:Label runat="server" CssClass="alert alert-danger" Visible="false" ID="lblMensagem"></asp:Label>
                    <!-- /.box box-default -->
                </div>
            </div>
        </section>

    </div>

    <!-- Se precisar, coloque os links scripts js aqui -->
</asp:Content>

