using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlacementEntityData
{
    #region Highly Private Variables

    [SerializeField] private PlacementPreset _placementPreset;
    [SerializeField] private GameObject _placementInstance;
    [SerializeField] private Vector3Int _placementCenter;
    [SerializeField] private Quaternion _placementRotation;
    [SerializeField] private float _placementWaterStored;

    [SerializeField] private List<Vector3Int> _ownershipTiles;
    [SerializeField] private List<Vector3Int> _displacerTiles;
    [SerializeField] private List<Vector3Int> _collectorTiles;

    [SerializeField] private List<PlacementDisplacementData> _displacementTileData;

    #endregion

    #region Getters & Setters

    public PlacementPreset PlacementPreset
    {
        get => _placementPreset;
        set => _placementPreset = value;
    }

    public GameObject PlacementInstance
    {
        get => _placementInstance;
        set => _placementInstance = value;
    }

    public Vector3Int PlacementCenter
    {
        get => _placementCenter;
        set => _placementCenter = value;
    }

    public Quaternion PlacementRotation
    {
        get => _placementRotation;
        set => _placementRotation = value;
    }

    public List<Vector3Int> OwnershipTiles
    {
        get => _ownershipTiles;
        set => _ownershipTiles = value;
    }

    public List<Vector3Int> DisplacerTiles
    {
        get => _displacerTiles;
        set => _displacerTiles = value;
    }

    public List<Vector3Int> CollectorTiles
    {
        get => _collectorTiles;
        set => _collectorTiles = value;
    }

    public List<PlacementDisplacementData> DisplacementTileData
    {
        get => _displacementTileData;
        set => _displacementTileData = value;
    }

    public float WaterStored
    {
        get => _placementWaterStored;
        set => _placementWaterStored = value;
    }

    #endregion

    // ------------------------------------------------------------
}