using ConsoleApp.Enum;
using System;
namespace ConsoleApp
{
    class Program
    {
        static Serie_Repositorio repositorio = new Serie_Repositorio();
        static void Main(String[] args)
        {
            string user = Usuario();

            while(user.ToUpper() != "S")
            {
                switch(user)
                {
                    case "1":
                        ListaSeries();
                        break;
                    case "2":
                        InsereSeries();
                        break;
                    case "3":
                       AtualizaSeries();
                        break;
                    case "4":
                      ExcluiSeries();
                        break;
                    case "5":
                      VisualizaSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                user = Usuario();
            }

            Console.WriteLine("Obrigado volte logo");
            Console.WriteLine();
        }

        private static void ListaSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach (var series in lista)
            {
                var excluido = series.retornaExcluido();
                
                Console.WriteLine("#ID {0}: . {1} {2}", series.retornaID(), series.retornaTitulo(), excluido ? "*Excluido*" : "");
            }
        }

        private static void InsereSeries()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}.{1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoID(),
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }
        private static void AtualizaSeries()
        {
            Console.Write("Digite o ID da série: ");
            int indicaSerie = int.Parse(Console.ReadLine());

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}{1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções a cima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSeries = new Series(id: indicaSerie,
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);

            repositorio.Atualiza(indicaSerie, atualizaSeries);
        }
        private static void ExcluiSeries()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indicaSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indicaSerie);
        }
        private static void VisualizaSeries()
        {
            Console.WriteLine("Digite o ID da série: ");
            int indicaSerie = int.Parse(Console.ReadLine());
            
            var serie = repositorio.retornaPorID(indicaSerie);
            Console.WriteLine(serie);
        }
        private static string Usuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindo");
            Console.WriteLine("Informe uma opção: ");
            Console.WriteLine("1. Listar séries");
            Console.WriteLine("2. Inserir uma nova série");
            Console.WriteLine("3. Atualizar séries");
            Console.WriteLine("4. Excluí série");
            Console.WriteLine("5. Visualizar série");
            Console.WriteLine("R: ");
            Console.WriteLine();
            Console.WriteLine("C. Limpar tela");
            Console.WriteLine("S. Sair");
            

            string Usuario = Console.ReadLine().ToString();
            Console.WriteLine();
            return Usuario;
        }
    }
}