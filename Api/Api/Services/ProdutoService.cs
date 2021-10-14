using Api.Context;
using Api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Api.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppBdContext _context;

        public ProdutoService(AppBdContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetProduto(string codBarras)
        {

            var produto = await _context.Produtos.FirstOrDefaultAsync(c => c.CODBARRAS == codBarras);
            return produto;

        }

        public async Task<IEnumerable<Produto>> GetProdutos(int pagina)
        {            

            try
            {
                return await _context.Produtos.ToPagedListAsync(pagina, 10);
            }
            catch (Exception)
            {

                throw;
            }

           
        }
    }
}
