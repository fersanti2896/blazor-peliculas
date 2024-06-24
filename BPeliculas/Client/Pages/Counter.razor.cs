using BPeliculas.Shared.Entidades;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BPeliculas.Client.Pages {
    public partial class Counter {
        [Inject]
        ServiceSingleton singleton { get; set; } = null!;
        [Inject]
        ServiceTransient transient { get; set; } = null!;
        List<Pelicula> ListadoPeliculas() {
            return new List<Pelicula>() {
                new Pelicula { Titulo = "Planeta de los Simios 1", FechaLanzamiento = new DateTime(1969, 10, 11) },
                new Pelicula { Titulo = "Planeta de los Simios 2", FechaLanzamiento = new DateTime(1971, 10, 11) },
                new Pelicula { Titulo = "Planeta de los Simios 3", FechaLanzamiento = new DateTime(1974, 10, 11) }
            };
        }

        [Inject]
        protected IJSRuntime js { get; set; } = null!;

        IJSObjectReference modulo;

        private int currentCount = 0;
        private static int currentCountStatic = 0;

        [JSInvokable]
        public async Task incrementCount() {
            modulo = await js.InvokeAsync<IJSObjectReference>("import", "./js/Counter.js");
            await modulo.InvokeVoidAsync("mostrarAlerta", "Hola mundo");

            currentCount += 2;
            currentCountStatic = currentCount;
            singleton.Valor = currentCount;
            transient.Valor = currentCount;
            await js.InvokeVoidAsync("testPuntoNetStatic");
        }

        [JSInvokable]
        public static Task<int> getCurrentCount() {
            return Task.FromResult(currentCountStatic);
        }

        private async Task testInstanceJS() {
            await js.InvokeVoidAsync("testInstance", DotNetObjectReference.Create(this));
        }
    }
}
