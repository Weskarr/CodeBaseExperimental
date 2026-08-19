using System;
using UnityEngine;

[Serializable]
public class DisplacerTileData : PlacementTileBase
{
    [SerializeField] private Vector3Int[] _displacementOffsets;

    public Vector3Int[] DisplacementOffsets
    {
        get => _displacementOffsets;
        set => _displacementOffsets = value;
    }
}
