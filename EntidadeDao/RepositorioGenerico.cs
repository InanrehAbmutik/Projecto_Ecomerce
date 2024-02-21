using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadeDao.Infra;

namespace EntidadeDao
{
    public abstract class RepositorioGenerico<Entidade> : IGeneric<Entidade> where Entidade : class
    {
        private readonly Contexto db;
        public RepositorioGenerico(Contexto Contexto)
        {
            db = Contexto;
        }
        public int Adicionar(Entidade entidade)
        {
            try
            {
                db.Set<Entidade>().Add(entidade);
                return db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public int Editar(Entidade entidade)
        {
            try
            {
                db.Entry(entidade).State = EntityState.Modified;
                return db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int Eliminar(Entidade entidade)
        {
            try
            {
                db.Entry(entidade).State = EntityState.Deleted;
                return db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int Ocultar(Entidade Entidade)
        {
            try
            {
                db.Entry(Entidade).State = EntityState.Modified;
                return db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Entidade Pegar(int id)
        {
            try
            {
                return db.Set<Entidade>().Find(id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<Entidade> PegarTodos()
        {
            try
            {
                return db.Set<Entidade>().ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }

    public class ProdutoBll : RepositorioGenerico<Produto>, IProduto
    {
        public ProdutoBll(Contexto Contexto) : base(Contexto)
        {
        }
    }
    public class CategoriaBll : RepositorioGenerico<CATEGORIA>, ICategoria
    {
        public CategoriaBll(Contexto Contexto) : base(Contexto)
        {
        }
    }
    public class FornecedorBll : RepositorioGenerico<Fornecedor>, IFornecedor
    {
        public FornecedorBll(Contexto Contexto) : base(Contexto)
        {
        }
    }
    public class LojaBll : RepositorioGenerico<Loja>, ILoja
    {
        public LojaBll(Contexto Contexto) : base(Contexto)
        {
        }
    }
    public class DetalheBll : RepositorioGenerico<DETALHE_COMPRA>, IDetalhe
    {
        public DetalheBll(Contexto Contexto) : base(Contexto)
        {
        }
    }
    public class ProvinciaBll : RepositorioGenerico<PROVINCIA>, IProvincia
    {
        public ProvinciaBll(Contexto Contexto) : base(Contexto)
        {
        }
    }
    public class DepartamentoBll : RepositorioGenerico<DEPARTAMENTO>, IDepartamento
    {
        public DepartamentoBll(Contexto Contexto) : base(Contexto)
        {
        }
    }
    public class DistritoBll : RepositorioGenerico<DISTRITO>, IDistrito
    {
        public DistritoBll(Contexto Contexto) : base(Contexto)
        {
        }
    }
    public class CarritoBll : RepositorioGenerico<CARRITO>, ICarrito
    {
        public CarritoBll(Contexto Contexto) : base(Contexto)
        {
        }
    }
}
