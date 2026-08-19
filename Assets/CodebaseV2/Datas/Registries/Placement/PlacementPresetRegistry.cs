using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlacementPresetRegistry", menuName = "Scriptable Objects/PlacementPresetRegistry")]
public class PlacementPresetRegistry : ScriptableObject
{
    [SerializeField] private List<PlacementPreset> _presets = new();

    public List<PlacementPreset> Presets => _presets;

    private Dictionary<string, PlacementPreset> _presetDictionary;

    public void InitializeDictionaryFromList()
    {
        _presetDictionary = new Dictionary<string, PlacementPreset>();

        foreach (var preset in _presets)
        {
            if (preset == null) continue;

            if (!_presetDictionary.ContainsKey(preset.PlacementName))
                _presetDictionary.Add(preset.PlacementName, preset);
        }
    }

    public PlacementPreset GetPlacementPresetByName(string name)
    {
        if (_presetDictionary == null)
            InitializeDictionaryFromList();

        _presetDictionary.TryGetValue(name, out var preset);
        return preset;
    }
}