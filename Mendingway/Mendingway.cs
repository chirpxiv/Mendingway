using System.Diagnostics.CodeAnalysis;

using Dalamud.Plugin;

namespace Mendingway; 

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public sealed class Mendingway : IDalamudPlugin {
	public string Name => "Mendingway";
		
	public Mendingway(DalamudPluginInterface dalamud) {
		Services.Init(dalamud);
		Hooks.Init();
	}

	public void Dispose() {
		Hooks.Dispose();
	}
}
