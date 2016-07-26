using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados
{
    public class GeneralDataProvider : IDisposable
    {
        protected SqlConnection _GetConexao()
        {
            string conexao;

            if (File.Exists(@"Conexao.txt"))
            {
                conexao = File.ReadAllText(@"Conexao.txt");
            }
            else
            {
                conexao = "user id=sa;" +
                                           "password=12345;" +
                                           "server=(localdb)\\v11.0;" +
                                           "Trusted_Connection=yes;" +
                                           "database=Pilates; " +
                                           "connection timeout=30";
            }

            SqlConnection myConnection = new SqlConnection(conexao);

            return myConnection;
        }
        protected SqlCommand _GetCmd(SqlConnection myConnection)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConnection;

            return cmd;
        }

        public void Dispose()
        {
            
        }
    }
}
