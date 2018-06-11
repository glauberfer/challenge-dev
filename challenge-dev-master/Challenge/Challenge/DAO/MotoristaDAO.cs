using Dapper;
using Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Challenge.DAO
{
    public class MotoristaDAO
    {
        private SqlConnection conn;
        private string con;

        public MotoristaDAO()
        {
            con = Config.Connection;
        }

        public void Adicionar(Motorista model)
        {
            using (conn = new SqlConnection(con))
            {
                conn.Execute(@"insert into Motoristas 
                        (PrimeiroNome, UltimoNome, Endereco, EnderecoMaps, DataCadastro, DataExclusao) values
                        (@PrimeiroNome, @UltimoNome, @Endereco, @EnderecoMaps, GetDate(), null)", model);
            }
        }

        public void Atualizar(Motorista model)
        {
            using (conn = new SqlConnection(con))
            {
                conn.Execute(@"update Motoristas set 
                                PrimeiroNome = @PrimeiroNome,
                                UltimoNome = @UltimoNome,
                                Endereco = @Endereco
                                EnderecoMaps = @EnderecoMaps
                                where id = @ID", 
                                new { ID = model.ID,
                                    PrimeiroNome = model.PrimeiroNome,
                                    UltimoNome = model.UltimoNome,
                                    Endereco = model.Endereco,
                                    EnderecoMaps = model.EnderecoMaps
                                 });
            }
        }

        public void Deletar(int id)
        {
            using (conn = new SqlConnection(con))
            {
                conn.Execute("update Motoristas set DataExclusao = GetDate() where id = @ID", new { ID = id });
            }
        }

        public Motorista Buscar(int id)
        {
            using (conn = new SqlConnection(con))
            {
                var motorista = conn.Query<Motorista>("select * from Motoristas where id = @ID", new { ID = id }).FirstOrDefault();

                motorista.Carros = new CarroDAO().Listar().Where(m => m.MotoristaID == motorista.ID).ToList();

                return motorista;
            }
        }

        public List<Motorista> Listar()
        {
            using (conn = new SqlConnection(con))
            {
                return conn.Query<Motorista>("select * from Motoristas where DataExclusao is null order by PrimeiroNome").ToList();
            }
        }
    }
}
