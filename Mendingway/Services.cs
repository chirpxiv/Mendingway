using Dalamud.IoC;
using Dalamud.Game;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

namespace Mendingway {
	internal class Services {
		[PluginService] internal static ISigScanner SigScanner { get; set; } = null!;
		[PluginService] internal static IGameInteropProvider Interop { get; set; } = null!;

		internal static void Init(DalamudPluginInterface dalamud) => dalamud.Create<Services>();
	}
}
