using Challenge.DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.BLL
{
    public class CarroBLL
    {
        private CarroDAO dao;

        public CarroBLL()
        {
            dao = new CarroDAO();
        }

        public void Adicionar(Carro model)
        {
            dao.Adicionar(model);
        }

        public void Atualizar(Carro model)
        {
            dao.Atualizar(model);
        }

        public void Deletar(int id)
        {
            dao.Deletar(id);
        }

        public Carro Buscar(int id)
        {
            return dao.Buscar(id);
        }

        public List<Carro> Listar()
        {
            return dao.Listar();
        }
    }
}
