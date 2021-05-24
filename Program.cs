using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = getUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        listSeries();
                        break;
                    case "2":
                        insertSeries();
                        break;
                    case "3":
                        updateSeries();
                        break;
                    case "4":
                        deleteSeries();
                        break;
                    case "5":
                        showSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = getUserOption();
            }
        }

        private static void listSeries()
        {
            Console.WriteLine("Listar séries");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
            }

            foreach (var serie in list)
            {
                var deleted = serie.returnDelete();

                Console.WriteLine("#ID {0} : - {1} {2}", serie.returnId(), serie.returnTitle(), (deleted ? "Excluido" : ""));
            }
        }

        private static void insertSeries()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int genreIn = int.Parse(Console.ReadLine());
            Console.Write("Digite o título da série: ");
            string titleIn = Console.ReadLine();
            Console.Write("Digite o ano de ínicio da série: ");
            int yearIn = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição da série: ");
            string descriptionIn = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.nextId(),
                                        genre: (Genre)genreIn,
                                        title: titleIn,
                                        description: descriptionIn,
                                        year: yearIn);
            repository.Insert(newSerie);
        }

        private static void updateSeries()
        {
            Console.Write("Digite o id da série: ");
            int serieIndex = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int genreIn = int.Parse(Console.ReadLine());
            Console.Write("Digite o título da série: ");
            string titleIn = Console.ReadLine();
            Console.Write("Digite o ano de ínicio da série: ");
            int yearIn = int.Parse(Console.ReadLine());
            Console.Write("Digite a descrição da série: ");
            string descriptionIn = Console.ReadLine();

            Serie updatedSerie = new Serie(id: serieIndex,
                                        genre: (Genre)genreIn,
                                        title: titleIn,
                                        description: descriptionIn,
                                        year: yearIn);
            repository.Update(serieIndex, updatedSerie);
        }
        private static void deleteSeries()
        {
            Console.Write("Digite o id da série: ");
            int serieIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Tem certeza que deseja excluir?");
            Console.WriteLine(repository.ReturnById(serieIndex));
            Console.Write("'S' pra sim e 'N' para não: ");
            string answer = Console.ReadLine();

            if (answer.ToUpper().Substring(0, 1) == "S")
            {
                repository.Delete(serieIndex);
            }
        }

        private static void showSerie()
        {
            Console.Write("Digite o id da série: ");
            int serieIndex = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(serieIndex);

            Console.WriteLine(serie);
        }
        private static string getUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listas séries");
            Console.WriteLine("2- Inserir uma nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return userOption;
        }
    }
}
