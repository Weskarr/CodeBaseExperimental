//using LevelSystem;
using System.Collections.Generic;
using UnityEngine;

public static class RuntimeUtility
{
    /*
    public static PlacementTypeData GetOrCreatePlacementTypeRuntime
    (
        LevelDispatcher levelDispatcher,
        LevelBlackboard levelBlackboard,
        string name
    )
    {
        List<PlacementTypeData> datas = levelBlackboard.GetPlacementTypeDatas;
        PlacementPresetRegistry registry = levelBlackboard.GetPlacementPresetRegistry;

        for (int i = 0; i < datas.Count; i++)
        {
            if (datas[i].placementName == name)
                return datas[i];
        }

        PlacementPreset _preset = registry.GetPlacementPresetByName(name);

        if (_preset == null)
        {
            Debug.LogError("Unable to find preset by name, can't create runtime data!");
            return null;
        }

        PlacementTypeData newData = new()
        {
            placementName = name,
            placedCount = 0,
            maxAllowed = _preset.PlacementStartMaxAllowed,
            storageMultiplier = _preset.PlacementStartMultiplier
        };

        levelDispatcher.AddPlacementTypeData(newData);

        return newData;
    }
    */
}
