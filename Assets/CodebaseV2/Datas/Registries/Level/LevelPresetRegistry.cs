using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelPresetRegistry", menuName = "Scriptable Objects/LevelPresetRegistry")]
public class LevelPresetRegistry : ScriptableObject
{
    [SerializeField] private List<LevelPreset> _presets = new();

    public List<LevelPreset> Presets => _presets;

    private Dictionary<string, LevelPreset> _presetDictionary;

    public void InitializeDictionaryFromList()
    {
        _presetDictionary = new Dictionary<string, LevelPreset>();

        foreach (var preset in _presets)
        {
            if (preset == null) continue;

            if (!_presetDictionary.ContainsKey(preset.LevelSaveFileName))
                _presetDictionary.Add(preset.LevelSaveFileName, preset);
        }
    }

    public LevelPreset GetLevelPresetByName(string name)
    {
        if (_presetDictionary == null)
            InitializeDictionaryFromList();

        _presetDictionary.TryGetValue(name, out var preset);
        return preset;
    }

    public LevelPreset GetLevelPresetByCount(int count)
    {
        if (count < 0 || count >= _presets.Count)
            return null;

        LevelPreset preset = _presets[count];
        return preset;
    }
}