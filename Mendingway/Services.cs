using Dalamud.IoC;
using Dalamud.Game;
using Dalamud.Plugin;

namespace Mendingway {
	internal class Services {
		[PluginService] internal static SigScanner SigScanner { get; set; } = null!;

		internal static void Init(DalamudPluginInterface dalamud) => dalamud.Create<Services>();
	}
}