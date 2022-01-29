using System;

namespace dio.mangas
{
    class Program
    {
        static MangasRepositorio repositorio = new MangasRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarMangas();
						break;
					case "2":
						InserirMangas();
						break;
					case "3":
						AtualizarMangas();
						break;
					case "4":
						ExcluirMangas();
						break;
					case "5":
						VisualizarMangas();
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

        private static void ExcluirMangas()
		{
			Console.Write("Digite o id do manga: ");
			int indiceMangas = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceMangas);
		}

        private static void VisualizarMangas()
		{
			Console.Write("Digite o id do manga: ");
			int indiceMangas = int.Parse(Console.ReadLine());

			var mangas = repositorio.RetornaPorId(indiceMangas);

			Console.WriteLine(mangas);
		}


         private static void ListarMangas()
		{
			Console.WriteLine("Listar Mangás");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum manga cadastrado.");
				return;
			}

			foreach (var mangas in lista)
			{
                var excluido = mangas.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", mangas.retornaId(), mangas.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

         private static void AtualizarMangas()
		{
			Console.Write("Digite o id da série: ");
			int indiceMangas = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do manga: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do manga: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do manga: ");
			string entradaDescricao = Console.ReadLine();

			Mangas atualizaMangas = new Mangas(id: indiceMangas,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceMangas, atualizaMangas);
		}

         private static void InserirMangas()
		{
			Console.WriteLine("Inserir novo manga");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Manga: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Manga: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Manga: ");
			string entradaDescricao = Console.ReadLine();

			Mangas novoMangas = new Mangas(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoMangas);
		}



        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Mangás ao seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar mangás");
			Console.WriteLine("2- Inserir novo manga");
			Console.WriteLine("3- Atualizar manga");
			Console.WriteLine("4- Excluir manga");
			Console.WriteLine("5- Visualizar manga");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
