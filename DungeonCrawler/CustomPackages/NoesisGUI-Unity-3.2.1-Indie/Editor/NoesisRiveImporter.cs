//#define DEBUG_IMPORTER

using System.IO;
using UnityEditor.AssetImporters;
using UnityEngine;

[ScriptedImporter(1, "riv")]
class NoesisRiveImporter : ScriptedImporter
{
    public override void OnImportAsset(AssetImportContext ctx)
    {
#if DEBUG_IMPORTER
            Debug.Log($"=> Import {ctx.assetPath}");
#endif

        NoesisRive rive = ScriptableObject.CreateInstance<NoesisRive>();
        rive.uri = ctx.assetPath;
        rive.content = File.ReadAllBytes(ctx.assetPath);

        ctx.AddObjectToAsset("Rive", rive);
        ctx.SetMainObject(rive);
    }
}
