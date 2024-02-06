using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;

internal class Connection
{
    private string ConnectionStringCorpore = "Data Source=berlim.fametro.com.br;Initial Catalog=Corpore;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    public SqlConnection ObterConexaoCorpore()
    {
        return new SqlConnection(ConnectionStringCorpore);
    }

    private string ConnectionString = "Data Source=04A-NTIC13;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public SqlConnection ObterConexao()
    {
        return new SqlConnection(ConnectionString);
    }
}
