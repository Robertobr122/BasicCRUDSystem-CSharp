using System;
using System.Diagnostics;
using System.Collections.Generic;

class ProjetoCrudEventos
{

    static List<Dictionary<string, string>> eventos = new List<Dictionary<string, string>>();
    static void Main(string[] args)
    {
        ListarOpcoes();
    }

    static void ListarOpcoes()
    {
        System.Console.WriteLine("Selecione a opção que deseja: \n-------------------------");
        System.Console.WriteLine("1) Cadastrar Evento \n2) Listar Eventos \n3) Atualizar Evento \n4) Deletar Evento \n5) Sair");
        string entrada = Console.ReadLine();



        if (!int.TryParse(entrada, out int selecao))
        {
            System.Console.WriteLine("\nDigite um valor Inteiro.\n\nRecarregando opções...");
            Thread.Sleep(3000);
            Console.Clear();
            ListarOpcoes();
            return;

        }

        switch (selecao)
        {
            case 1:
                Cadastrar();
                break;
            case 2:
                Listar();
                break;
            case 3:
                Atualizar();
                break;
            case 4:
                Deletar();
                break;
            case 5:
                Sair();
                break;
            default:
                System.Console.WriteLine("\nDigite um valor entre 1 e 5. \n\nRecarregando opções...");
                Thread.Sleep(3000);
                Console.Clear();
                ListarOpcoes();
                break;

        }
    }

    static void Cadastrar()
    {
        Console.Clear();
        System.Console.WriteLine("Carregando...");
        Thread.Sleep(3000);
        Console.Clear();

        System.Console.WriteLine("-----  Cadastro de Eventos  -----\n");
        System.Console.WriteLine("Selecione uma opção:\n1) Cadastrar Evento\n2) Voltar");
        string opcaoCadastro = Console.ReadLine();

        if (!int.TryParse(opcaoCadastro, out int selecaoCadastro))
        {
            Console.Clear();
            System.Console.WriteLine("Selecione a opção [ 1 ] ou [ 2 ]");
            Thread.Sleep(3000);
            Console.Clear();
            Cadastrar();
            return;
        }

        if (selecaoCadastro == 1)
        {
            Console.Clear();
            System.Console.Write("\nDigite o nome do evento: ");
            string nomeEvento = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nomeEvento))
            {
                Console.Clear();
                System.Console.Write("O nome não pode estar vazio!\nDigite novamente: ");
                nomeEvento = Console.ReadLine();
            }


            System.Console.Write("Digite a data do evento (ex: 25/12/2025): ");
            string dataEvento = Console.ReadLine();
            DateTime dataConvertida;

            while (!DateTime.TryParse(dataEvento, out dataConvertida) || dataConvertida <= DateTime.Now)
            {
                Console.Clear();

                if (!DateTime.TryParse(dataEvento, out _))
                {
                    System.Console.Write("Data invalida!\nA data deve ter o formato: DIA/MÊS/ANO, ex: 25/12/2025\nDigite Novamente: ");
                }
                else
                {
                    System.Console.Write("Data invalida!\nA data deve ser maior que a data atual\nDigite Novamente: ");
                }

                dataEvento = Console.ReadLine();

            }


            System.Console.Write("Digite o endereço do evento: ");
            string enderecoEvento = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(enderecoEvento))
            {
                Console.Clear();
                System.Console.Write("O endereço não pode estar vazia!\nDigite novamente: ");
                enderecoEvento = Console.ReadLine();
            }

            var evento = new Dictionary<string, string>
            {
                {"nomeEvento", nomeEvento},
                {"dataEvento", dataEvento},
                {"enderecoEvento", enderecoEvento}
            };

            eventos.Add(evento);
            System.Console.WriteLine("Cadastro realizado com sucessor!");

        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("Voltando para o menu inicial...");
            Thread.Sleep(3000);
            ListarOpcoes();
            return;
        }

    }
    static void Listar()
    {

    }

    static void Atualizar()
    {

    }
    static void Deletar()
    {

    }
    static void Sair()
    {
        Console.Clear();
        System.Console.WriteLine("\nCarregando...");
        Thread.Sleep(3000);
        Console.Clear();
        System.Console.WriteLine("Tem certeza que deseja finalizar o Sistema?\n");
        System.Console.WriteLine("Selecione uma opção: \n1) SIM \n2) NÃO\n");
        System.Console.WriteLine("ATENÇÃO: Caso selecione a opção [ 1 ], o sistema será finalizado e não ficará nada salvo por falta de integração com o bando de dados\n");

        string confirmarSaida = Console.ReadLine();

        if (!int.TryParse(confirmarSaida, out int confirmacao))
        {
            Console.Clear();
            System.Console.WriteLine("\nSelecione a opção [ 1 ] ou [ 2 ]");
            Thread.Sleep(3000);
            Sair();
            return;
        }

        if (confirmacao > 2 || confirmacao < 1)
        {
            Console.Clear();
            System.Console.WriteLine("\nSelecione a opção [ 1 ] ou [ 2 ]");
            Thread.Sleep(3000);
            Sair();
            return;

        }
        else if (confirmacao == 1)
        {
            Console.Clear();
            System.Console.WriteLine("\nEncerrando Sistema...\n");
            Thread.Sleep(3000);
            return;

        }
        else
        {
            Console.Clear();
            System.Console.WriteLine("\nVoltando para o menu inicial...");
            Thread.Sleep(3000);
            Console.Clear();
            ListarOpcoes();
            return;
        }
    }
}