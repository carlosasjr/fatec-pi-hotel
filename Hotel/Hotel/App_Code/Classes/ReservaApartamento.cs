using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ResApartamento
/// </summary>

namespace Hotel.Classes
{
    public class ReservaApartamento
    {
        public Reserva reserva;
        public Hotel hotel;
        public Apartamento apartamento;
        public int id;
        public decimal valor;
        public string informacoes;
    }
}
