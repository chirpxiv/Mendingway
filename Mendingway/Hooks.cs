using System.Collections.Generic;

using Dalamud.Hooking;

using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace Mendingway; 

internal static class Hooks {
	// Signatures
		
	private const string UpdateNpcNameSig = "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 4C 89 44 24 ?? 57 41 54 41 55 41 56 41 57 48 83 EC 20 48 8B 74 24 ??";
		
	// Delegates & Hooks
		
	public unsafe delegate nint UpdateNpcNameDelegate(nint a1, RaptureAtkModule.NamePlateInfo* a2, nint a3, nint a4, Character* a5, int a6, uint a7);
	public static Hook<UpdateNpcNameDelegate> UpdateNpcNameHook = null!;
		
	// UpdateNpcName

	private readonly static Dictionary<uint, (string name, string title)> NpcMap = new() {
		{ 1037791, ("Vendingway", "《Junkmonger》") },
		{ 1037792, ("Mendingway", "《Mender》") },
		{ 1045243, ("Vendingway", "《Junkmonger》") },
		{ 1045258, ("Mendingway", "《Mender》") },
		{ 1045256, ("Supplyingway", "《Material Supplier》") }
	};

	private unsafe static nint UpdateNpcNameDetour(nint a1, RaptureAtkModule.NamePlateInfo* a2, nint a3, nint a4, Character* a5, int a6, uint a7) {
		var exec = UpdateNpcNameHook.Original(a1, a2, a3, a4, a5, a6, a7);
			
		if (a5 != null && NpcMap.TryGetValue(a5->GameObject.DataID, out var values)) {
			a2->Name.SetString(values.name);
			a2->Title.SetString(values.title);
			a2->DisplayTitle.SetString(values.title);
		}

		return exec;
	}
		
	// Init & Dispose
		
	internal unsafe static void Init() {
		UpdateNpcNameHook = Services.Interop.HookFromSignature<UpdateNpcNameDelegate>(UpdateNpcNameSig, UpdateNpcNameDetour);
		UpdateNpcNameHook.Enable();
	}

	internal static void Dispose() {
		UpdateNpcNameHook.Disable();
		UpdateNpcNameHook.Dispose();
	}
}
