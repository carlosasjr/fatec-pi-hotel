using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Funcoes
/// </summary>
public class Funcoes
{
    public static int DSQuantidadesRegistros(DataSet ds)
    {
        return ds.Tables[0].Rows.Count;
    }

}