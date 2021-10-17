using System;
using System.IO;

namespace Grau_A
{
    public class Pousada
    {
        public string nome { get; set; }
        public string contato { get; set; }

        public Quarto[] quartos;
        public Reserva[] reservas = { };
        public Produto[] produtos;

        public Pousada(string nome, string contato, Quarto[] quartos, Produto[] produtos, Reserva[] reservas)
        {
            this.nome = nome;
            this.contato = contato;
            this.quartos = quartos;
            this.reservas = reservas;
            this.produtos = produtos;
        }

        public void deserializar()
        {
            /*int pCodigo;
            string pNome;
            int pPreco;
            string[] lines = System.IO.File.ReadAllLines("produto.txt");
            //string[] dados;

            pCodigo = int.Parse(lines[0].Split(",")[1]);
            pNome = lines[1].Split(",")[2];
            pPreco = int.Parse(lines[2].Split(",")[3]);

            Produto produto0 = new Produto(pCodigo, pNome, pPreco);

            /* for (int i = 0; i < lines.Length; i++)
            {
                dados = lines[i].Split(',');
            }
            */

        }
        public void serializar()
        {
            //Salvar produtos
            StreamWriter arqProduto;
            arqProduto = File.CreateText("produto.txt");

            for (int i = 0; i < produtos.Length; i++)
            {
                arqProduto.Write($"{produtos[i].codigo},{produtos[i].nome},{produtos[i].preco}");
                arqProduto.WriteLine();
            }
            arqProduto.Close();

            //Salvar reservas
            StreamWriter arqReserva;
            arqReserva = File.CreateText("reserva.txt");

            for (int i = 0; i < reservas.Length; i++)
            {
                arqReserva.Write($"{reservas[i].diaInicio},{reservas[i].diaFim},{reservas[i].cliente},{quartos[i].numero},{reservas[i].status}");
                arqReserva.WriteLine();
            }
            arqReserva.Close();

            //Salvar quartos
            StreamWriter arqQuarto;
            arqQuarto = File.CreateText("quarto.txt");

            for (int i = 0; i < quartos.Length; i++)
            {
                arqQuarto.Write($"{quartos[i].numero},{quartos[i].categoria},{quartos[i].diaria}");
                arqQuarto.WriteLine();
            }
            arqQuarto.Close();

            //Salvar Pousada
            StreamWriter arqPousada;
            arqPousada = File.CreateText("pousada.txt");

            arqPousada.Write($"{nome},{contato}");
            arqPousada.WriteLine();

            arqPousada.Close();

        }
        public bool consultaDisponivel(int data, int quarto)
        {
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i].quarto.numero == quarto && reservas[i].diaInicio <= data && reservas[i].diaFim >= data) //Pega o numero dentro do quarto, dentro da reserva e consulta. 
                {
                    System.Console.WriteLine("Este quarto não está disponivel");
                    return false;
                }
            }
            System.Console.WriteLine("Este quarto está disponivel");
            return true;
        }
        public bool consultaReserva(int data, string cliente, int quarto, bool print)
        {
            int n = 0; // contador para checkar se nao existe nenhuma reserva.

            for (int i = 0; i < reservas.Length; i++)
            {
                if ((reservas[i].cliente == cliente || reservas[i].quarto.numero == quarto) && reservas[i].status == 'A' && reservas[i].diaInicio <= data && reservas[i].diaFim >= data)
                {
                    n++;
                    Console.WriteLine($"Nome: {cliente}\nData inicial: {reservas[i].diaInicio}\nData final: {reservas[i].diaFim}\nQuarto: {quarto}");
                }
            }
            if (n == 0)
            {
                if (print) //bool passada nos parâmetros
                {
                    Console.WriteLine("Reserva não encontrada");
                }
                return true;
            }
            return false;
        }
        public void realizaReserva(string cliente, int quarto, int dataIni, int dataFim)
        {
            bool clienteDisponivel = true;
            bool quartoDisponivel = true;
            for (int i = dataIni; i < dataFim; i++)
            {
                quartoDisponivel = consultaDisponivel(i, quarto);
                clienteDisponivel = consultaReserva(i, cliente, quarto, false);
            }
            if (quartoDisponivel && clienteDisponivel)
            {
                Array.Resize(ref reservas, reservas.Length + 1);
                Quarto objQuarto = Array.Find(quartos, p => p.numero == quarto); // Busca o quarto em base no numero do mesmo

                reservas[reservas.GetUpperBound(0)] = new Reserva(dataIni, dataFim, cliente, objQuarto);
                System.Console.WriteLine("Reserva realizada com sucesso");
            }else
            {
                System.Console.WriteLine("Reserva não realizada");
            }

        }
        public void cancelaReserva(string cliente)
        {
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i].cliente == cliente)
                {
                    reservas[i].status = 'C';
                    System.Console.WriteLine("Reserva cancelada com sucesso!");
                    return;
                }
            }
        }
        public void realizaCheckIn(string cliente)
        {
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i].cliente == cliente)
                {
                    System.Console.WriteLine("Check-In realizado com sucesso!");
                    reservas[i].status = 'I';
                    return;
                }
            }
            System.Console.WriteLine("Check-In não realizado.");
        }
        public void realizaCheckOut(string cliente)
        {
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i].cliente == cliente)
                {
                    System.Console.WriteLine("Check-Out realizado com sucesso!");
                    reservas[i].status = 'O';
                    return;
                }
            }
            System.Console.WriteLine("Check-Out não realizado.");
        }
        public void registrarConsumo(string cliente)
        {
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i].cliente.Equals(cliente) && reservas[i].status == 'I')
                {
                    int escolha;
                    for (int j = 0; j < produtos.Length; j++)
                    {
                        Console.WriteLine($"{produtos[j].codigo} {produtos[j].nome} {produtos[j].preco}");
                    }
                    Console.WriteLine("Informe qual produto você deseja: ");
                    escolha = int.Parse(Console.ReadLine());

                    for (int y = 0; y < produtos.Length; y++)
                    {
                        if (escolha.Equals(produtos[y].codigo))
                        {
                            for (int x = 0; x < reservas.Length; x++)
                            {
                                if (reservas[x].cliente == cliente)
                                {
                                    reservas[x].quarto.addConsumo(produtos[y].codigo);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}