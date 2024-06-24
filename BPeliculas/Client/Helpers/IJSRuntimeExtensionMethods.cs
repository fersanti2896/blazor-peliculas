using BPeliculas.Shared.Entidades;
using Microsoft.JSInterop;

namespace BPeliculas.Client.Helpers;

public static class IJSRuntimeExtensionMethods
{
    public static async ValueTask<bool> Confirm(this IJSRuntime js, string message)
    {
        return await js.InvokeAsync<bool>("confirm", message);
    }
}
