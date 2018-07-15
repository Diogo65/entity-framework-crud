using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoEntity();
            //RecuperarProdutos();
            //ExcluirProdutos();
            //RecuperarProdutos();
            AtualizarProduto();
        }

        private static void AtualizarProduto()
        {
            //incluir um produto
            GravarUsandoEntity();
            RecuperarProdutos();

            //atualizar produto
            //pegar o primeiro produto da tabela
            using (var repo = new LojaContext())
            {
                Produto primeiro = repo.Produtos.First();
                primeiro.Nome = "Cassino Royale - Editado";
                repo.SaveChanges();
            }
            RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            using(var repo = new LojaContext())
            {
                IList<Produto> produtos = repo.Produtos.ToList();
                foreach(var item in produtos)
                {
                    repo.Produtos.Remove(item);
                    repo.SaveChanges();
                }
            }
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new LojaContext())
            {
                IList<Produto> produtos = repo.Produtos.ToList();
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
                Console.ReadKey();
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var contexto = new LojaContext())
            {
                contexto.Produtos.Add(p);
                contexto.SaveChanges();
            }
        }
    }
}
