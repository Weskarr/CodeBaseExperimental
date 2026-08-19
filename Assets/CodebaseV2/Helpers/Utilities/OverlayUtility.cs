using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class OverlayUtility
{
    public static Transform CreateContainer
    (
        Transform parent,
        string name
    )
    {
        return GameObjectUtility.CreateContainer(parent, name);
    }

    public static GameObject CreateText
    (
        GameObject prefab,
        Transform parent,
        Vector3 position,
        string text
    )
    {
        if (prefab == null)
            return null;

        GameObject instance = GameObjectUtility.Create(prefab, parent);
        instance.transform.position = position;
        TextMeshProUGUI textComponent = instance.GetComponentInChildren<TextMeshProUGUI>();

        if (textComponent != null)
            textComponent.text = text;

        return instance;
    }

    public static GameObject CreateShape
    (
        GameObject prefab,
        Transform parent,
        Vector3 position
    )
    {
        if (prefab == null)
            return null;

        GameObject instance = GameObjectUtility.Create(prefab, parent);
        instance.transform.position = position;

        return instance;
    }

    public static GameObject CreateLine
    (
        GameObject prefab,
        Transform parent,
        Vector3 start,
        Vector3 end
    )
    {
        if (prefab == null)
            return null;

        GameObject instance = GameObjectUtility.Create(prefab, parent);
        LineRenderer line = instance.GetComponent<LineRenderer>();

        if (line != null)
        {
            line.positionCount = 2;
            line.SetPosition(0, start);
            line.SetPosition(1, end);
        }

        return instance;
    }

    public static GameObject CreatePointer
    (
        GameObject prefab,
        Transform parent,
        Vector3 start,
        Vector3 end
    )
    {
        if (prefab == null)
            return null;

        GameObject instance = GameObjectUtility.Create(prefab, parent);
        instance.transform.position = start;
        Vector3 direction = end - start;

        if (direction != Vector3.zero)
            instance.transform.rotation = Quaternion.LookRotation(direction);

        return instance;
    }

    public static void DestroyAll
    (
        List<GameObject> overlays
    )
    {
        if (overlays == null)
            return;

        for (int i = 0; i < overlays.Count; i++)
            GameObjectUtility.Destroy(overlays[i]);

        overlays.Clear();
    }
}