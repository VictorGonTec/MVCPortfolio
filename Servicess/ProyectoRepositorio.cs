using MiPortafolioWeb.Models;
using System.Collections.Generic;

namespace MiPortafolioWeb.Servicess
{
	public interface IProyectoRepositorio
	{
		IEnumerable<Proyecto> GetAll();
	}
	public class ProyectoRepositorio : IProyectoRepositorio
	{
		public IEnumerable<Proyecto> GetAll()
		{
			return proyectos.ToList();
		}

		List<Proyecto> proyectos = new List<Proyecto>()
		{
			new Proyecto()
			{
				Titulo="Agenda De Voz",
				Descripcion="Agenda que convierte vos a texto con soporte a varios idiomas",
				Url="",
				Image="Agenda.jpg"
			},
			new Proyecto()
			{
				Titulo="App Peliculas",
				Descripcion="App que permite visualizar peliculas en cines y estrenos",
				Url="",
				Image="pelicula.jpg"
			},
			new Proyecto()
			{
				Titulo="Golf-in-Danger-Space",
				Descripcion="videojuego de golf espacial Choque de Meteoritos",
				Url="",
				Image="golf.jpg"
			},
			new Proyecto()
			{
				Titulo="Ecommerce",
				Descripcion="Mini tienda online",
				Url="",
				Image="ecommerce.png"
			},
		};
	}
}
