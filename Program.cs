using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Security.AccessControl;

class ProjetoCrudEventos
{

    static List<Dictionary<string, string>> eventos = new List<Dictionary<string, string>>();
    static void Main(string[] args)
    {
        ListarOpcoes();
    }

    static void ListarOpcoes()
    {
        System.Console.WriteLine("Selecione a opção que deseja: \n\n-------------------------\n");
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

    }

    static void Listar()
    {

    }

    static void Atualizar()
    {

    }
    static void Deletar()
    {
        Console.Clear();
        System.Console.WriteLine("Carregando...");
        Thread.Sleep(3000);
        Console.Clear();

        System.Console.WriteLine("--- Menu para Deletar Eventos ---");
        System.Console.WriteLine("Selecione uma opção:\n1) Deletar Evento\n2) Voltar");
        string opcaoSelecionada = Console.ReadLine();

        while (!int.TryParse(opcaoSelecionada, out int selecao))
        {
            Console.Clear();
            System.Console.WriteLine("Selecione uma opção entre [ 1 ] ou [ 2 ]");
            Thread.Sleep(2000);

            Listar();
        }

        int opcaoSelecionada2 = int.Parse(opcaoSelecionada);

        while (opcaoSelecionada2 > 2 || opcaoSelecionada2 < 1)
        {
            Console.Clear();
            System.Console.WriteLine("Selecione uma opção entre [ 1 ] ou [ 2 ]");
            Thread.Sleep(2000);

            Listar();
        }

        if (opcaoSelecionada2 == 2)
        {
            Console.Clear();
            System.Console.WriteLine("Voltando para o menu principal...");
            Thread.Sleep(2000);

            Console.Clear();
            System.Console.WriteLine("Carregando...");
            Thread.Sleep(2000);
            Console.Clear();

            ListarOpcoes();
            return;
        }
        else
        {
            if (eventos.Count == 0)
            {
                System.Console.WriteLine("Nenhum evento cadastrado. Voltando para o menu deletar");
                Deletar();
                return;
            }
            else
            {
                for (int i = 0; i < eventos.Count; i++)
                {
                    var evento = eventos[i];

                    string nome = evento["nomeEvento"];
                    string data = evento["dataEvento"];
                    string local = evento["enderecoEvento"];

                    System.Console.WriteLine($"\n{i + 1}º Evento Cadastrado: ");
                    System.Console.WriteLine("-------------------");
                    System.Console.WriteLine($"nome: {nome}");
                    System.Console.WriteLine($"data: {data}");
                    System.Console.WriteLine($"local: {local}");
                    System.Console.WriteLine("-------------------\n");
                }
            }

            System.Console.WriteLine("Qual opção você deseja deleta: \nATENÇÃO: Selecione a posição, ex: 2.");
            string indiceDeletar = Console.ReadLine();

            if (!int.TryParse(indiceDeletar, out int indice) || indice < 1 || indice > eventos.Count)
            {
                System.Console.WriteLine("Numero inválido, retornando para o menu deletar");
                Deletar();
                return;
            }

            int indiceReal = indice - 1;
            var evento2 = eventos[indiceReal];

            Console.WriteLine($"\nTem certeza que deseja excluir o evento \"{evento2["nomeEvento"]}\"? digite s ou n");
            string confirmacao = Console.ReadLine().Trim().ToLower();

            if (confirmacao == "s")
            {
                eventos.RemoveAt(indiceReal);
                Console.WriteLine("Evento excluído!");
            }
            else
            {
                Console.WriteLine("Exclusão cancelada.");
            }

            Thread.Sleep(3000);
        }


    }

    static void Sair()
    {

    }
}