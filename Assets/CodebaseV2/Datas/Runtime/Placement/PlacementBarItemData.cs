
using UnityEngine;

[System.Serializable]
public class PlacementBarItemData
{
    public string Name => Preset.PlacementName;
    public Sprite Sprite => Preset.PlacementBarSprite;
    public int CurrentAmount => RuntimeData.placedCount;
    public int MaxAmount => RuntimeData.maxAllowed;

    // |><>------------------------------------------------------------------------------------------------------<WB><|

    public PlacementPreset Preset { get; private set; }
    public PlacementTypeData RuntimeData { get; private set; }

    // |><>======================================================================================================<WB><|

    public PlacementBarItemData(PlacementPreset preset, PlacementTypeData runtimeData)
    {
        Preset = preset;
        RuntimeData = runtimeData;
    }

    // |><>------------------------------------------------------------------------------------------------------<WB><|
}