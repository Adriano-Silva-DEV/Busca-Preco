using Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IProdutoService
    {

        Task<IEnumerable<Produto>> GetProdutos(int pagina);

        Task<Produto> GetProduto(string codBarras);


    }
}
