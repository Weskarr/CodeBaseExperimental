using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlacementDisplacementData
{
    [SerializeField] private Vector3Int _tilePosition;
    [SerializeField] private List<Vector3Int> _directions;


    public Vector3Int TilePosition
    {
        get => _tilePosition;
        set => _tilePosition = value;
    }

    public List<Vector3Int> Directions
    {
        get => _directions;
        set => _directions = value;
    }
}