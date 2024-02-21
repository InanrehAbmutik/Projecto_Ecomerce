using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadeDao.Infra
{
    public interface IGeneric<Entity> where Entity : class
    {
        int Adicionar(Entity entidade);
        //Task AdicionarAsync(Entity entidade);
        int Editar(Entity Entidade);
        //Task EditarAsync(Entity Entidade);

        int Eliminar(Entity Entidade);
        int Ocultar(Entity Entidade);

        List<Entity> PegarTodos();

        Entity Pegar(int id);
    }

    public interface IProduto : IGeneric<Produto> { }
    public interface ICategoria : IGeneric<CATEGORIA> { }
    public interface ICarrito : IGeneric<CARRITO> { }
    public interface IDepartamento : IGeneric<DEPARTAMENTO> { }
    public interface IUsuario : IGeneric<USUARIO> { }
    public interface ILoja : IGeneric<Loja> { }
    public interface IFornecedor : IGeneric<Fornecedor> { }
    public interface IDistrito : IGeneric<DISTRITO> { }
    public interface IProvincia : IGeneric<PROVINCIA> { }
    public interface ICompra : IGeneric<COMPRA> { }
    public interface IDetalhe : IGeneric<DETALHE_COMPRA> { }
}
