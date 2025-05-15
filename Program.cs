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

    }
    static void Sair()
    {

    }
}