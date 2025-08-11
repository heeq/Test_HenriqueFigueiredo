using System.ComponentModel;

namespace ConsoleApp1
{

	class Arvore
	{
		public int Raiz { get; }
		public List<int> GalhosEsquerda { get; }
		public List<int> GalhosDireita { get; }

		public Arvore(List<int> itens)
		{
			if (itens == null || itens.Count == 0)
				throw new ArgumentException("A lista de itens não pode ser nula ou vazia.");

			Raiz = itens.Max();
			var pos = itens.IndexOf(Raiz);

			GalhosEsquerda = itens.Take(pos).OrderBy(x => x).ToList();
			GalhosDireita = itens.Skip(pos + 1).OrderByDescending(x => x).ToList();
		}
	}

	class Program
	{

		static void Main(string[] args) // program.exe x,y,z,w,h,...
		{
			int[] cenario1 = { 3, 2, 1, 6, 0, 5 };
			int[] cenario2 = { 7, 5, 13, 9, 1, 6, 4 };

			var lista = new List<int>(cenario1);

			if (args.Length > 0)
				GerarListaCenario(lista, args[0]);

			lista = lista.Distinct().ToList(); // não pode ter duplicidade

			if (lista.Count > 0)
				MostrarArvore(new Arvore(lista));
		}

		private static void GerarListaCenario(List<int> lista, string arg)
		{
			lista.Clear();
			var numeros = arg.Split(',');

			foreach (var x in numeros)
			{
				if (!int.TryParse(x, out int num))
				{
					lista.Clear();
					Console.WriteLine($"Cenario inválido! Ímpossível converter \"{x}\" em número.\n");
					return;
				}

				lista.Add(num);
			}
		}

		private static void MostrarArvore(Arvore arvore)
		{
			if (arvore == null) return;

			foreach (var item in arvore.GalhosEsquerda)
				Console.Write(item + " -> ");

			Console.Write(arvore.Raiz);

			foreach (var item in arvore.GalhosDireita)
				Console.Write(" <- " + item);

			Console.WriteLine();
		}
	}
}