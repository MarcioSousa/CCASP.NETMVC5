using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastros
{
    public class FabricanteServico
    {
        private readonly FabricanteDAL fabricanteDAL = new FabricanteDAL();
        public IQueryable<Fabricante> ObterFabricantesClassificadasPorNome()
        {
            return fabricanteDAL.ObterFabricantesClassificadosPorNome();
        }
        public Fabricante ObterProdutoPorId(long id)
        {
            return fabricanteDAL.ObterFabricantePorId(id);
        }

        public void GravarFabricante(Fabricante fabricante)
        {
            fabricanteDAL.GravarFabricante(fabricante);
        }

        public Fabricante EliminarProdutoPorId(long id)
        {
            return fabricanteDAL.EliminarFabricantePorId(id);
        }
    }
}
