<%@ Page Title="" Language="C#" MasterPageFile="~/Content/Master/Principal.master" AutoEventWireup="true" CodeFile="checkIn.aspx.cs" Inherits="Paginas_Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Se precisar, coloque os links para seus css aqui -->
    <!-- BootStrap já está na pagina master, então é só usar aqui... -->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Identificação da página, altere esses dados para a página correspondente. -->
        <section class="content-header">
            <h1>Check-In
            <small>Controle de Reserva</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="index.aspx"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Nova Reserva</li>
            </ol>
        </section>

        <section class="content">
            <!-- Seu conteúdo vai aqui -->
            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">Check-In</h3>

                    <div class="box-tools pull-right">
                        <asp:LinkButton ID="lbCheckIn" runat="server" CssClass="btn btn-facebook" OnClick="lbCheckIn_Click"><i class="fa fa-check-circle"></i> Check-In</asp:LinkButton>
                        <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    </div>
                </div>

                <div class="box-body">
                    <div class="row">
                        <div class="form-group">
                            <div class="col-6 col-sm-3">
                                <label for="txtID">Reserva Nº</label>
                                <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="form-group">
                            <div class="col-12 col-sm-6">
                                <label for="txtHospede">Hospede</label>
                                <asp:TextBox ID="txtHospede" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>

                            <div class="col-12 col-sm-3">
                                <label for="txtDataEntrada">Data Entrada</label>
                                <asp:TextBox ID="txtDataEntrada" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>

                            <div class="col-12 col-sm-3">
                                <label for="txtDataSaida">Data Saída</label>
                                <asp:TextBox ID="txtDataSaida" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <br />

                        <div class="form-group">
                            <div class="col-12 col-sm-12">
                                <label for="txtObservacoes">Observações</label>
                                <asp:TextBox ID="txtObservacoes" runat="server" CssClass="form-control" Enabled="false" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>



                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Apartamentos Reservados</h3>
                    </div>

                    <div class="box-body">
                        <div class="col-12 col-sm-12">
                            <asp:Label for="clbQuartosAdicionados" runat="server" Text="Quartos Adicionados:"></asp:Label>
                            <br />
                            <asp:CheckBoxList ID="clbQuartosAdicionados" runat="server" EnableTheming="False" Enabled="false" AutoPostBack="False"></asp:CheckBoxList>
                        </div>
                    </div>
                </div>
            </div>
        </section>

    </div>

    <!-- Se precisar, coloque os links scripts js aqui -->
</asp:Content>

