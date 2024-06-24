using BPeliculas.Shared.Entidades;

namespace BPeliculas.Client.Pages {
    public partial class Index {
        List<Pelicula> ListadoPeliculas() {
            return new List<Pelicula>() {
                new Pelicula { Titulo = "Volver al Futuro 1", FechaLanzamiento = new DateTime(1980, 10, 11) },
                new Pelicula { Titulo = "Volver al Futuro 2", FechaLanzamiento = new DateTime(1986, 10, 11) },
                new Pelicula { Titulo = "Volver al Futuro 3", FechaLanzamiento = new DateTime(1990, 10, 11) }
            };
        }
    }
}
