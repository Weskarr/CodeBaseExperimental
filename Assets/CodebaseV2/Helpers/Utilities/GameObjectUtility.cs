using UnityEngine;

public static class GameObjectUtility
{
    public static GameObject Create
    (
        GameObject prefab,
        Transform parent = null
    )
    {
        if (prefab == null)
            return null;

        return Object.Instantiate(prefab, parent);
    }

    public static Transform CreateContainer
    (
        Transform parent,
        string name
    )
    {
        GameObject container = new(name);

        if (parent != null)
            container.transform.SetParent(parent, false);

        return container.transform;
    }

    public static void Destroy(GameObject gameObject)
    {
        if (gameObject != null)
            Object.Destroy(gameObject);
    }
}