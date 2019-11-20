<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/Principal.master" AutoEventWireup="true" CodeFile="mapaOcupacao.aspx.cs" Inherits="Paginas_Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Se precisar, coloque os links para seus css aqui -->
    <!-- BootStrap já está na pagina master, então é só usar aqui... -->
    <style type="text/css">
        .ap {
            margin: 0;
            padding: 0;
        }

        .lb {
            padding-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Identificação da página, altere esses dados para a página correspondente. -->
        <section class="content-header">
            <h1>Mapa de Ocupação
            <small>Control panel</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="index.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Mapa de Ocupação</li>
            </ol>
        </section>

        <section class="content">
            <!-- Seu conteúdo vai aqui -->

            <!-- Small boxes (Stat box) -->
            <div class="row">
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-aqua">
                        <div class="inner">
                            <h3><asp:Label ID="lbNovasReservas" runat="server" Text="0"></asp:Label></h3>

                            <p>Novas Reservas</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-bag"></i>
                        </div>
                        <a href="#" class="small-box-footer">Mais detalhes <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
                <!-- ./col -->
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-green">
                        <div class="inner">
                            <h3><asp:Label ID="lbTaxaOcupacao" runat="server" Text="0"></asp:Label><sup style="font-size: 20px">%</sup></h3>

                            <p>Taxa de Ocupação</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-stats-bars"></i>
                        </div>
                        <a href="#" class="small-box-footer">Mais detalhes <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
                <!-- ./col -->
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-yellow">
                        <div class="inner">
                            <h3><asp:Label ID="lbHospedes" runat="server" Text="0"></asp:Label></h3>

                            <p>Hospedes </p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-person-add"></i>
                        </div>
                        <a href="#" class="small-box-footer">Mais detalhes <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
                <!-- ./col -->
                <div class="col-lg-3 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-red">
                        <div class="inner">
                            <h3><asp:Label ID="lbCancelamentos" runat="server" Text="0"></asp:Label></h3>

                            <p>Cancelamentos</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-pie-graph"></i>
                        </div>
                        <a href="#" class="small-box-footer">Mais detalhes <i class="fa fa-arrow-circle-right"></i></a>
                    </div>
                </div>
                <!-- ./col -->
            </div>

            <div class="row">
                <div class="col-12 col-sm-2">
                    <div id="botoes">
                        <div class="btn-group-vertical">
                            <asp:LinkButton ID="lbDisponiveis" runat="server" CssClass="btn btn-primary btn-lg" OnClick="lbDisponiveis_Click">
                                    <i class="fa fa-thumbs-o-up"></i>
                                    Disponíveis
                            </asp:LinkButton>

                            <asp:LinkButton ID="lbCheckin" runat="server" CssClass="btn btn-primary  btn-lg" OnClick="lbCheckin_Click">
                                <i class="fa fa-bed"></i>
                                Ocupados
                            </asp:LinkButton>

                            <asp:LinkButton ID="lbSujo" runat="server" CssClass="btn btn-primary  btn-lg" OnClick="lbSujo_Click">
                                     <i class="fa fa-bookmark"></i>                                     
                                Sujos
                            </asp:LinkButton>

                            <asp:LinkButton ID="lbLimpo" runat="server" CssClass="btn btn-primary  btn-lg" OnClick="lbLimpo_Click">
                                  <i class="fa fa-bookmark-o"></i>
                               Limpos
                            </asp:LinkButton>

                            <asp:LinkButton ID="lbBloqueado" runat="server" CssClass="btn btn-primary  btn-lg" OnClick="lbBloqueado_Click">
                                  <i class="fa fa-calendar-times-o"></i>
                                Bloqueados
                            </asp:LinkButton>

                            <asp:LinkButton ID="lbReservados" runat="server" CssClass="btn btn-primary  btn-lg" OnClick="lbReservados_Click">
                                  <i class="fa fa-calendar-check-o"></i>
                                Reservados
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>

                <div class="col-12 col-sm-10">
                    <asp:Panel ID="panel1" runat="server">
                    </asp:Panel>
                </div>
            </div>

        </section>

    </div>

    <!-- Se precisar, coloque os links scripts js aqui -->
</asp:Content>

