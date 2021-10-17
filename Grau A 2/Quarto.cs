using System;

namespace Grau_A
{
    public class Quarto
    {
        public int numero{get; set;}
        public char categoria{get; set;} //(S/M/P)
        public float diaria{get; set;}
        public int[] consumo = {};
        public Quarto(int numero, string categoria, float diaria)
        {
            this.numero = numero;
            this.categoria = char.Parse(categoria);
            this.diaria = diaria;
        }
        public void addConsumo(int produto)
        {
            Array.Resize(ref consumo, consumo.Length + 1);
            consumo[consumo.GetUpperBound(0)] = produto;
        }
        public void listaConsumo()
        {
            for (int i = 0; i < consumo.Length; i++)
            {
                Console.WriteLine(consumo[i]);
            }
        }
        public void valorTotalConsumo(Produto[] produtos)
        {
            float consumoTotal = 0;

            for (int i = 0; i < produtos.Length; i++)
            {
                int codigoProduto = produtos[i].codigo; //Pega o codigo do produto.
                int indexProduto = Array.IndexOf(consumo, codigoProduto);//Buscar no array de consumo o cod do produto, se nao achar retorna -1.
                if (indexProduto != -1)//se achar ele é ! de -1.
                {
                    consumoTotal += produtos[i].preco;
                }
            }
            System.Console.WriteLine(consumoTotal);
        }
        public void limpaConsumo()
        {
            Array.Clear(this.consumo, 0, this.consumo.Length);
        }
    }
}