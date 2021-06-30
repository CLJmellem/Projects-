using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorioS = new SerieRepositorio();
		static FilmeRepositorio repositorioF = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
			int opcaoAux = 0;

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
					Console.WriteLine("Digite 1 para série e 2 para filme: ");
					opcaoAux = Convert.ToInt32(Console.ReadLine());
					if(opcaoAux == 1)
					{
						ListarSeries();
					}else if(opcaoAux == 2)
					{
						ListarFilme();
					} 
						break;

					case "2":
						Console.WriteLine("Digite 1 para série e 2 para filme: ");
						opcaoAux = Convert.ToInt32(Console.ReadLine());
					if(opcaoAux == 1)
					{
						InserirSerie();
					}else if(opcaoAux == 2)
					{
						InserirFilme();
					} 
						break;

					case "3":
						Console.WriteLine("Digite 1 para série e 2 para filme: ");
						opcaoAux = Convert.ToInt32(Console.ReadLine());
					if(opcaoAux == 1)
					{
						AtualizarSerie();
					}else if(opcaoAux == 2)
					{
						AtualizarFilme();
					} 
						break;

					case "4":
						Console.WriteLine("Digite 1 para série e 2 para filme: ");
						opcaoAux = Convert.ToInt32(Console.ReadLine());
					if(opcaoAux == 1)
					{
						ExcluirSerie();
					}else if(opcaoAux == 2)
					{
						ExcluirFilme();
					} 
						break;

					case "5":
						Console.WriteLine("Digite 1 para série e 2 para filme: ");
						opcaoAux = Convert.ToInt32(Console.ReadLine());
					if(opcaoAux == 1)
					{
						VisualizarSerie();
					}else if(opcaoAux == 2)
					{
						VisualizarFilme();
					} 
						break;

					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorioS.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorioS.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioS.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorioS.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorioS.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioS.Insere(novaSerie);
		}


		private static void ExcluirFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			repositorioF.Exclui(indiceFilme);
		}

        private static void VisualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = repositorioF.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
		}

        private static void AtualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioF.Atualiza(indiceFilme, atualizaFilme);
		}
        private static void ListarFilme()
		{
			Console.WriteLine("Listar filmes");

			var lista = repositorioF.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			foreach (var filme in lista)
			{
                var excluido = filme.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirFilme()
		{
			Console.WriteLine("Inserir novo filme");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme novoFilme = new Filme(id: repositorioF.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioF.Insere(novoFilme);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries/filme");
			Console.WriteLine("2- Inserir nova séries/filme");
			Console.WriteLine("3- Atualizar séries/filme");
			Console.WriteLine("4- Excluir séries/filme");
			Console.WriteLine("5- Visualizar séries/filme");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
