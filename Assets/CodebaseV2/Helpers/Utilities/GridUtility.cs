using UnityEngine;

public static class GridUtility
{
    private static readonly Vector3 GridBias = new(0.01f, 0.01f, 0.01f);

    public static Vector3Int WorldToGrid
    (
        Vector3 worldPosition
    )
    {
        return Vector3Int.FloorToInt(worldPosition + GridBias);
    }

    public static Vector3 GridToWorld
    (
        Vector3Int gridPosition
    )
    {
        return new Vector3(gridPosition.x, gridPosition.y, gridPosition.z);
    }

    public static Vector3 GridToWorldCenter
    (
        Vector3Int gridPosition,
        Vector3 centerOffset
    )
    {
        return GridToWorld(gridPosition) + centerOffset;
    }

    public static bool IsInsideChecker
    (
        Vector2Int position,
        Vector2Int gridSize
    )
    {
        return position.x >= 0 &&
            position.y >= 0 &&
            position.x < gridSize.x &&
            position.y < gridSize.y;
    }

    public static bool IsInsideBufferChecker
    (
        Vector3Int position,
        int maxX,
        int maxZ,
        int buffer
    )
    {
        return
            position.x < buffer ||
            position.z < buffer ||
            position.x >= maxX - buffer ||
            position.z >= maxZ - buffer;
    }

    public static Vector2Int WorldTo2DTile
    (
        Vector3Int position,
        Vector2Int gridSize,
        int bufferOffset
    )
    {
        return new Vector2Int
        (
            gridSize.x - 1 - (position.x - bufferOffset),
            gridSize.y - 1 - (position.z - bufferOffset)
        );
    }
}