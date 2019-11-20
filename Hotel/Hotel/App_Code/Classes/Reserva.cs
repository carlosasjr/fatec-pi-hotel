using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Reservares_id int(11) AI PK 
/*
 * htl_id int(11) 
pes_id int(11) 
res_previsao_chegada date
res_previsao_saida date
res_checkin date
res_checkout date
res_datainclusao date
res_dataalteracao date
res_datacancelamento date
res_motivo_cancelamento varchar(150)
res_observacoes text
res_valorliquido decimal (12,*/

/// </summary>

namespace Hotel.Classes
{
    public class Reserva
    {
        public Hotel hotel;
        public Hospede hospede;
        public int id;
        public DateTime previsaoChegada;
        public DateTime previsaoSaida;
        public DateTime checkin;
        public DateTime checkout;
        public DateTime dataInclusao;
        public DateTime dataAlteracao;
        public DateTime dataCancelamento;
        public string motivoCancelamento;
        public string observacoes;
        public decimal valorLiquido;


    }
}