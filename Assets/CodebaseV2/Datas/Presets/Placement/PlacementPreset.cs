using UnityEngine;

[CreateAssetMenu(fileName = "PlacementPreset", menuName = "Scriptable Objects/PlacementPreset")]
public class PlacementPreset : ScriptableObject
{
    [Header("Placement Name")]
    [SerializeField] private string _placementName;

    [Header("Placement Interface")]
    [SerializeField] private Sprite _placementBarSprite;

    [Header("Placement Prefabs")]
    [SerializeField] private GameObject _placementPrefab;
    [SerializeField] private GameObject _blueprintPrefab;

    [Header("Placement Runtime Start")]
    [SerializeField] private int _placementStartMaxAllowed = 1;
    [SerializeField] private float _placementStartMultiplier = 1.0f;

    [Header("Placement Capabilities")]
    [SerializeField] private float _waterStorageCapacity = 1.0f;

    [Header("Placement Origin")]
    [SerializeField] private Vector3 _placementGridOffset;
    [SerializeField] private Vector3 _placementOriginOffset;
    [SerializeField] private Vector3 _placementCubeprintOffset;
    [SerializeField] private float _placementRotationAmount;

    [Header("Placement Tiles")]
    [SerializeField] private OwnershipTileData[] _ownershipTiles;
    [SerializeField] private CollectorTileData[] _collectorTiles;
    [SerializeField] private DisplacerTileData[] _displacerTiles;

    #region Getter / Setter Properties

    public int PlacementStartMaxAllowed
    {
        get => _placementStartMaxAllowed;
        set => _placementStartMaxAllowed = value;
    }

    public float PlacementStartMultiplier
    {
        get => _placementStartMultiplier;
        set => _placementStartMultiplier = value;
    }

    public Sprite PlacementBarSprite
    {
        get => _placementBarSprite;
        set => _placementBarSprite = value;
    }

    public float WaterStorageCapacity
    {
        get => _waterStorageCapacity;
        set => _waterStorageCapacity = value;
    }

    public Vector3 PlacementGridOffset
    {
        get => _placementGridOffset;
        set => _placementGridOffset = value;
    }

    public Vector3 PlacementCubeprintOffset
    {
        get => _placementCubeprintOffset;
        set => _placementCubeprintOffset = value;
    }

    public string PlacementName
    {
        get => _placementName;
        set => _placementName = value;
    }

    public GameObject PlacementPrefab
    {
        get => _placementPrefab;
        set => _placementPrefab = value;
    }

    public GameObject BlueprintPrefab
    {
        get => _blueprintPrefab;
        set => _blueprintPrefab = value;
    }

    public Vector3 PlacementOriginOffset
    {
        get => _placementOriginOffset;
        set => _placementOriginOffset = value;
    }

    public float PlacementRotationAmount
    {
        get => _placementRotationAmount;
        set => _placementRotationAmount = value;
    }

    public OwnershipTileData[] OwnershipTiles
    {
        get => _ownershipTiles;
        set => _ownershipTiles = value;
    }

    public CollectorTileData[] CollectorTiles
    {
        get => _collectorTiles;
        set => _collectorTiles = value;
    }

    public DisplacerTileData[] DisplacerTiles
    {
        get => _displacerTiles;
        set => _displacerTiles = value;
    }

    #endregion

    // ------------------------------------------------------------
}