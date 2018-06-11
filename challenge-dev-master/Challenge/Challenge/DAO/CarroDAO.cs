using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Challenge.DAO
{
    public class CarroDAO
    {
        private SqlConnection conn;
        private string con;

        public CarroDAO()
        {
            con = Config.Connection;
        }
        
        public void Adicionar(Carro model)
        {
            using (conn = new SqlConnection(con))
            {
                conn.Execute(@"insert into Carros 
                        (MotoristaID, Modelo, Placa, Marca, DataCadastro, DataExclusao) values
                        (@MotoristaID, @Modelo, @Placa, @Marca, GetDate(), null)", model);
            }
        }

        public void Atualizar(Carro model)
        {
            using (conn = new SqlConnection(con))
            {
                conn.Execute(@"update Carros set 
                                Modelo = @Modelo,
                                Placa = @Placa,
                                Marca = @Marca
                                where id = @ID",
                                new
                                {
                                    ID = model.ID,
                                    Modelo = model.Modelo,
                                    Placa = model.Placa,
                                    Marca = model.Marca
                                });
            }
        }

        public void Deletar(int id)
        {
            using (conn = new SqlConnection(con))
            {
                conn.Execute("update Carros set DataExclusao = GetDate() where id = @ID", new { ID = id });
            }
        }

        public Carro Buscar(int id)
        {
            using (conn = new SqlConnection(con))
            {
                var carro = conn.Query<Carro>("select * from Carros where id = @ID", new { ID = id }).FirstOrDefault();

                carro.Motorista = new MotoristaDAO().Buscar(carro.MotoristaID);

                return carro;
            }
        }

        public List<Carro> Listar()
        {
            using (conn = new SqlConnection(con))
            {
                return conn.Query<Carro>("select * from Carros where DataExclusao is null").ToList();
            }
        }
    }
}
