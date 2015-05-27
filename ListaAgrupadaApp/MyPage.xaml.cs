using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ListaAgrupadaApp
{
	public partial class MyPage : ContentPage
	{
		private List<Livro> _livros;
		public MyPage ()
		{
			InitializeComponent ();

			this._livros = new List<Livro> ();
			this._livros.Add (new Livro { Nome = "Iracema",  Autor = "Josée Alencar" });
			this._livros.Add (new Livro { Nome = "O Guarani", Autor = "Josée Alencar" });
			this._livros.Add (new Livro { Nome = "Animais em Extinçã", Autor = "Marcelo Mirisola" });
			this._livros.Add (new Livro { Nome = "Como Desaparecer Completamente", Autor = "Andrée Leones" });
			this._livros.Add (new Livro { Nome = "O Diáio de um Mago", Autor = "Paulo Coelho" });
			this._livros.Add (new Livro { Nome = "Brida", Autor = "Paulo Coelho" });
			this._livros.Add (new Livro { Nome = "O Alquimista", Autor = "Paulo Coelho" });
			this._livros.Add (new Livro { Nome = "No Buraco", Autor = "Tony Bellotto" });
			this._livros.Add (new Livro { Nome = "Mentes Perigosas", Autor = "Ana Beatriz Barbosa Silva" });
			this._livros.Add (new Livro { Nome = "O Tigre Na Sombra", Autor = "Lya Luft" });
			this._livros.Add (new Livro { Nome = "O Lado Fatal", Autor = "Lya Luft" });
			this._livros.Add (new Livro { Nome = "O Crepúculo do Macho", Autor = "Fernando Gabeira" });
			this._livros.Add (new Livro { Nome = "O Xangôe Baker Street", Autor = "Jôoares" });
			this._livros.Add (new Livro { Nome = "As Esganadas", Autor = "Jôoares" });
			this._livros.Add (new Livro { Nome = "Mar Morto", Autor = "Jorge Amado" });
			this._livros.Add (new Livro { Nome = "Memóias de um Sargento de Milíias", Autor = "Manuel Antôio de Almeida" });
			this._livros.Add (new Livro { Nome = "Estorvo", Autor = "Chico Buarque" });
			this._livros.Add (new Livro { Nome = "O Mundo Nã éhato", Autor = "Caetano Veloso" });
			this._livros.Add (new Livro { Nome = "Triâgulo no Ponto", Autor = "Eros Grau" });
			this._livros.Add (new Livro { Nome = "A Paixã Segundo G.H.", Autor = "Clarice Lispector" });
			this._livros.Add (new Livro { Nome = "O Inverno das Fadas", Autor = "Carolina Munhó" });
			this._livros.Add (new Livro { Nome = "O Dia Mastroianni", Autor = "Joã Paulo Cuenca" });
			this._livros.Add (new Livro { Nome = "A Vida Sabe o Que Faz", Autor = "Zibia Gasparetto" });
			this._livros.Add (new Livro { Nome = "A Escrava Isaura", Autor = "Bernardo Guimarãs" });
			this._livros.Add (new Livro { Nome = "Farewell", Autor = "Carlos Drummond de Andrade" });
			this._livros.Add (new Livro { Nome = "Rosinha, Minha Canoa", Autor = "Joséauro de Vasconcelos" });
			this._livros.Add (new Livro { Nome = "Obra Completa", Autor = "J. G. de Araúo Jorge" });
			this._livros.Add (new Livro { Nome = "Guia-Mapa de Gabriel Arcanjo", Autor = "Néida Piñn" });

			this.busca.TextChanged += Busca_TextChanged;

			this.lista.ItemsSource = this.Listar ();
		}

		private void Busca_TextChanged (object sender, TextChangedEventArgs e)
		{
			this.lista.ItemsSource = this.Listar (this.busca.Text);
		}

		public IEnumerable<Group<string, Livro>> Listar(string filtro = "")
		{
			IEnumerable<Livro> livrosFiltrados = this._livros;
			if(!string.IsNullOrEmpty(filtro))
				livrosFiltrados = this._livros.Where (l => (l.Nome.ToLower().Contains(filtro.ToLower())) || l.Autor.ToLower().Contains(filtro.ToLower()));

			return from livro in livrosFiltrados
			       orderby livro.Autor
			       group livro by livro.Autor into grupos
				select new Group<string, Livro> (grupos.Key, grupos);
		}
	}
}
