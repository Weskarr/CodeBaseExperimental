using UnityEngine;

public static class TransformUtility
{
    public static Vector3 TransformPoint
    (
        Transform transform,
        Vector3 localPosition
    )
    {
        if (transform == null)
            return localPosition;

        return transform.TransformPoint(localPosition);
    }

    public static Vector3 TransformDirection
    (
        Transform transform,
        Vector3 localDirection
    )
    {
        if (transform == null)
            return localDirection;

        return transform.TransformDirection(localDirection);
    }

    public static Vector3Int TransformDirectionToGrid
    (
        Transform transform,
        Vector3 localDirection
    )
    {
        Vector3 worldDirection = TransformDirection(transform, localDirection);

        return Vector3Int.RoundToInt(worldDirection);
    }
}