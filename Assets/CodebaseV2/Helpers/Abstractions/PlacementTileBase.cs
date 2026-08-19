using System;
using UnityEngine;

[Serializable]
public abstract class PlacementTileBase
{
    [SerializeField] private Vector3Int _placementOffset;

    // |><>------------------------------------------------------------------------------------------------------<WB><|

    // Getter.
    public Vector3Int PlacementOffset => _placementOffset;

    // |><>======================================================================================================<WB><|
}