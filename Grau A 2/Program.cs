using System;
using System.IO;

namespace Grau_A
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menu = true;
            //Le os produtos
            int pCodigo; string pNome; int pPreco;

            string[] pLines = System.IO.File.ReadAllLines("produto.txt");
            Produto[] produtos = new Produto[pLines.Length];

            for (int i = 0; i < pLines.Length; i++)
            {
                for (int y = 0; y < pLines[i].Split(",").Length; y++)
                {
                    pCodigo = int.Parse(pLines[i].Split(",")[0]);
                    pNome = pLines[i].Split(",")[1];
                    pPreco = int.Parse(pLines[i].Split(",")[2]);
                    produtos[i] = new Produto(pCodigo, pNome, pPreco);
                }
            }
            int qNumero; string qTipo; float qPreco;

            //Le os quartos
            string[] qLines = System.IO.File.ReadAllLines("quarto.txt");
            Quarto[] quartos = new Quarto[qLines.Length];
            
            for (int i = 0; i < qLines.Length; i++)
            {
                for (int y = 0; y < qLines[i].Split(",").Length; y++)
                {
                    qNumero = int.Parse(qLines[i].Split(",")[0]);
                    qTipo = qLines[i].Split(",")[1];
                    qPreco = float.Parse(qLines[i].Split(",")[2]);
                    quartos[i] = new Quarto(qNumero, qTipo, qPreco);
                }
            }
            //Le as reservas
            int rDataIni; int rDataFinal; string rCliente; int rQuarto;

            string[] rLines = System.IO.File.ReadAllLines("reserva.txt");
            Reserva[] reservas = new Reserva[rLines.Length];

            for (int i = 0; i < rLines.Length; i++)
            {
                for (int y = 0; y < rLines[i].Split(",").Length; y++)
                {
                    rDataIni = int.Parse(rLines[i].Split(",")[0]);
                    rDataFinal = int.Parse(rLines[i].Split(",")[1]);
                    rCliente = rLines[i].Split(",")[2];
                    rQuarto = int.Parse(rLines[i].Split(",")[3]);
                    for (int j = 0; j < quartos.Length; j++)
                    {
                        if (quartos[j].numero == rQuarto)
                        {
                            reservas[i] = new Reserva(rDataIni, rDataFinal, rCliente, quartos[j]);
                        }
                    }
                }
            }
            //Le a pousada
            string pouNome; string pouContato;
            string[] pouLines = System.IO.File.ReadAllLines("pousada.txt");

            pouNome = pouLines[0].Split(",")[0];
            pouContato = pouLines[0].Split(",")[1];
            Pousada pousada = new Pousada(pouNome, pouContato, quartos, produtos, reservas);
            
            int escolha;
            while (menu)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("");
                Console.WriteLine("1 - Consultar Disponibilidade");
                Console.WriteLine("2 - Consultar Reserva");
                Console.WriteLine("3 - Realizar Reserva");
                Console.WriteLine("4 - Cancelar Reserva");
                Console.WriteLine("5 - Realizar Check-In");
                Console.WriteLine("6 - Realizar Check-Out");
                Console.WriteLine("7 - Registrar Consumo");
                Console.WriteLine("8 - Salvar");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("");
                Console.WriteLine("Insira a opção desejada: ");
                escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        int dataEscolha;
                        int quartoEscolha;
                        System.Console.WriteLine("Insira a data desejada: ");
                        dataEscolha = int.Parse(Console.ReadLine());
                        System.Console.WriteLine("Insira o quarto desejado: ");
                        quartoEscolha = int.Parse(Console.ReadLine());

                        pousada.consultaDisponivel(dataEscolha, quartoEscolha);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        int dataEscolha2;
                        int quartoEscolha2;
                        string clienteEscolha2;
                        System.Console.WriteLine("Insira a data desejada: ");
                        dataEscolha2 = int.Parse(Console.ReadLine());
                        System.Console.WriteLine("Insira o nome do cliente: ");
                        clienteEscolha2 = Console.ReadLine();
                        System.Console.WriteLine("Insira oquarto desejado: ");
                        quartoEscolha2 = int.Parse(Console.ReadLine());

                        pousada.consultaReserva(dataEscolha2, clienteEscolha2, quartoEscolha2, true);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        int dataInicioEsc;
                        int dataFimEsc;
                        string clienteEscolha3;
                        int quartoEscolha3;

                        System.Console.WriteLine("Insira a data inical desejada: ");
                        dataInicioEsc = int.Parse(Console.ReadLine());
                        System.Console.WriteLine("Insira a data final desejada: ");
                        dataFimEsc = int.Parse(Console.ReadLine());
                        System.Console.WriteLine("Insira o nome do cliente: ");
                        clienteEscolha3 = Console.ReadLine();
                        System.Console.WriteLine("Insira oquarto desejado: ");
                        quartoEscolha3 = int.Parse(Console.ReadLine());

                        pousada.realizaReserva(clienteEscolha3, quartoEscolha3, dataInicioEsc, dataFimEsc);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        string clienteEscolha4;
                        System.Console.WriteLine("Insira o nome do cliente: ");
                        clienteEscolha4 = Console.ReadLine();

                        pousada.cancelaReserva(clienteEscolha4);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        string clienteEscolha5;
                        System.Console.WriteLine("Insira o nome do cliente: ");
                        clienteEscolha5 = Console.ReadLine();

                        pousada.realizaCheckIn(clienteEscolha5);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        string clienteEscolha6;
                        System.Console.WriteLine("Insira o nome do cliente: ");
                        clienteEscolha6 = Console.ReadLine();

                        pousada.realizaCheckOut(clienteEscolha6);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7:
                        string clienteEscolha7;
                        System.Console.WriteLine("Insira o nome do cliente: ");
                        clienteEscolha7 = Console.ReadLine();

                        pousada.registrarConsumo(clienteEscolha7);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 8:
                        pousada.serializar();
                        System.Console.WriteLine("Pousada Salva!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 0:
                        menu = false;
                        break;
                    default:
                        System.Console.WriteLine("Insira uma opção valida.");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                }
            }
        }
    }
}
