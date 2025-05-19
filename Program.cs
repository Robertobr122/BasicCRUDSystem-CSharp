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
            Thread.Sleep(3000);
            Console.Clear();
            ListarOpcoes();

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
        Console.Clear();
        System.Console.WriteLine("Carregando...");
        Thread.Sleep(3000);
        Console.Clear();

        System.Console.WriteLine("--- Lista Atualizada de cadastros ---");
        System.Console.WriteLine("Selecione uma opção:\n1) Ver Lista\n2) Voltar");
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
            Thread.Sleep(3000);
            Console.Clear();

            ListarOpcoes();
        }
        else
        {
            if (eventos.Count == 0)
            {
                Console.Clear();
                System.Console.WriteLine("Não existe eventos cadastrado!");
                Thread.Sleep(2000);
                Console.Clear();

                System.Console.WriteLine("Retornando para o menu principal...");
                Thread.Sleep(2000);
                Console.Clear();

                ListarOpcoes();

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
                ListarOpcoes();

            }
        }
        
    }

    static void Atualizar()
    {
        System.Console.WriteLine("Qual evento você deseja atualizar: ");
        System.Console.WriteLine("-------------------\n");

        Console.Clear();
        System.Console.WriteLine("Carregando...");
        Thread.Sleep(3000);
        Console.Clear();

        System.Console.WriteLine("--- Menu para Atualizar Cadastro ---");
        System.Console.WriteLine("Selecione uma opção:\n1) Atualizar Cadastro\n2) Voltar");
        string opcaoSelecionada = Console.ReadLine();

        while (!int.TryParse(opcaoSelecionada, out int selecao))
        {
            Console.Clear();
            System.Console.WriteLine("Selecione uma opção entre [ 1 ] ou [ 2 ]");
            Thread.Sleep(2000);

            Atualizar();
        }

        int opcaoSelecionada2 = int.Parse(opcaoSelecionada);

        while (opcaoSelecionada2 > 2 || opcaoSelecionada2 < 1)
        {
            Console.Clear();
            System.Console.WriteLine("Selecione uma opção entre [ 1 ] ou [ 2 ]");
            Thread.Sleep(2000);

            Atualizar();
        }

        if (opcaoSelecionada2 == 2)
        {
            Console.Clear();
            System.Console.WriteLine("Voltando para o menu principal...");
            Thread.Sleep(2000);

            Console.Clear();
            System.Console.WriteLine("Carregando...");
            Thread.Sleep(3000);
            Console.Clear();

            ListarOpcoes();
        }
        else
        {
            if (eventos.Count == 0)
            {
                Console.Clear();
                System.Console.WriteLine("Não existe eventos cadastrado!");
                Thread.Sleep(2000);
                Console.Clear();

                System.Console.WriteLine("Retornando para o menu principal...");
                Thread.Sleep(2000);
                Console.Clear();

                ListarOpcoes();

            }
            else
            {
                Console.Clear();
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

                System.Console.WriteLine("Selecione a posição do evento que deseja atualizar: (ex: 2)");
                string indiceAtualizar = Console.ReadLine();


                while (!int.TryParse(indiceAtualizar, out int indice) || indice < 1 || indice > eventos.Count)
                {
                    Console.Clear();
                    System.Console.WriteLine("Posição inválida. Retornando para o menu Atualizar");
                    Thread.Sleep(2000);
                    Atualizar();
                    return;
                }

                Thread.Sleep(2000);
                Console.Clear();
                int indice2 = int.Parse(indiceAtualizar);
                int indiceReal = indice2 - 1;
                var evento2 = eventos[indiceReal];

                System.Console.WriteLine("Digite os novos dados do evento: \nATENÇÃO: Se quiser manter os valores atuais pressione ENTER");

                System.Console.WriteLine($"Nome atual: {evento2["nomeEvento"]}");
                string novoNome = Console.ReadLine();
                if (!string.IsNullOrEmpty(novoNome))
                {
                    evento2["nomeEvento"] = novoNome;
                }

                System.Console.WriteLine($"Data Atual: {evento2["dataEvento"]}");
                string novaData = Console.ReadLine();
                if (!string.IsNullOrEmpty(novaData))
                {
                    DateTime dataConvertida;
                    while (!DateTime.TryParse(novaData, out dataConvertida) || dataConvertida <= DateTime.Now)
                    {
                        Console.Write("Data inválida. Digite novamente:\n ATENÇÃO: A data deve ser maior que a data atual e deve seguir a estrutura DD/MM/AA");
                        novaData = Console.ReadLine();
                    }
                    evento2["dataEvento"] = dataConvertida.ToString("dd/MM/yyyy");
                }

                System.Console.WriteLine($"Local Atual: {evento2["enderecoEvento"]}");
                string novoEndereco = Console.ReadLine();
                if (!string.IsNullOrEmpty(novoEndereco))
                {
                    evento2["enderecoEvento"] = novoEndereco;
                }

                System.Console.WriteLine("Dados Atualizados com Sucesso!");
                Thread.Sleep(2000);
                Console.Clear();

                ListarOpcoes();
                return;
            }
        }
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
                Thread.Sleep(2000);
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

            System.Console.WriteLine("Voltando o menu principal");
            Thread.Sleep(2000);
            ListarOpcoes();
            return;

        }


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