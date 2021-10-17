using System;

namespace Grau_A
{
    public class Produto
    {
        public int codigo{get; set;}
        public string nome{get; set;}
        public float preco{get; set;}

        public Produto(int codigo, string nome, float preco)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.preco = preco;
        }
    }
}