using System;
using Unity.Cinemachine;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelPreset", menuName = "Scriptable Objects/LevelPreset")]
public class LevelPreset : ScriptableObject
{
    [Header("Level Naming")]
    [SerializeField] private string _levelSaveFolderName = "FolderName";
    [SerializeField] private string _levelSaveFileName = "FileName";

    [Header("Level Size")]
    [SerializeField] private int _horizontalBaseTiles = 10;
    [SerializeField] private int _verticalBaseTileDepth = 10;

    [Header("Rain Settings")]
    [SerializeField] private int _secondsBeforeRain = 15;
    [SerializeField] private int _secondsOfRain = 30;
    [SerializeField, MinMaxRangeSlider(0f,1f)] private Vector2 _tileRainMinMax = new(0.25f, 0.5f);

    [Header("Ground Prefab")]
    [SerializeField] private GameObject _baseGroundPrefab = null;
    [SerializeField] private Material _baseGroundMaterial = null;
    [SerializeField] private Vector3 _baseGroundOffset = Vector3.zero;
    [SerializeField] private Vector3 _baseGroundScale = Vector3.one;

    #region Technical Restrictive Defaults

    // Horizontallity
    private int _horizontalTileBuffer = 1;

    // Verticallity
    private int _verticalGroundTileDepth = 1;
    private int _verticalRainfallTileDepth = 1;

    // Tile Sizes
    private float _horizontalTileSize = 1f;
    private float _verticalTileSize = 1f;

    #endregion

    #region Getter Properties

    public string LevelSaveFileName => _levelSaveFileName;

    public string LevelSaveFolderName => _levelSaveFolderName;

    public int SecondsBeforeRain => _secondsBeforeRain;

    public int SecondsOfRain => _secondsOfRain;

    public Vector2 TileRainAmountMinMax => _tileRainMinMax;

    public int HorizontalBaseTiles => _horizontalBaseTiles;

    public int HorizontalTileBuffer => _horizontalTileBuffer;

    public int VerticalBaseTileDepth => _verticalBaseTileDepth;

    public int VerticalGroundTileDepth => _verticalGroundTileDepth;

    public int VerticalRainfallTileDepth => _verticalRainfallTileDepth;

    public float HorizontalTileSize => _horizontalTileSize;

    public float VerticalTileSize => _verticalTileSize;

    public GameObject BaseGroundPrefab => _baseGroundPrefab;

    public Material BaseGroundMaterial => _baseGroundMaterial;

    public Vector3 BaseGroundOffset => _baseGroundOffset;

    public Vector3 BaseGroundScale => _baseGroundScale;

    #endregion

    #region Get Totals

    public int GetTotalHorizontalTiles()
    {
        int total = _horizontalBaseTiles;
        total += HorizontalTileBuffer;
        return total;
    }

    public int GetTotalVerticalTiles()
    {
        int total = _verticalBaseTileDepth;
        total += _verticalGroundTileDepth;
        total += _verticalRainfallTileDepth;
        return total;
    }

    public int GetTopOfGroundOffset()
    {
        return _verticalGroundTileDepth;
    }

    #endregion

    // ------------------------------------------------------------
}
