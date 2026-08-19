using UnityEngine;

public static class UnityExtensions
{
    public static void SafeDestroy(this Object obj)
    {
        if (obj == null)
            return;

#if UNITY_EDITOR
        if (!Application.isPlaying)
            Object.DestroyImmediate(obj);
        else
            Object.Destroy(obj);
#else
        Object.Destroy(obj);
#endif
    }

    public static void ToggleGameObject(this GameObject gameObject)
    {
        if (gameObject == null)
            return;

        gameObject.SetActive(!gameObject.activeSelf);
    }

    public static void ToggleRenderer(this Renderer renderer)
    {
        if (renderer == null)
            return;

        renderer.enabled = !renderer.enabled;
    }

    public static void SafeDestroyChildren(this Transform transform)
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
            transform.GetChild(i).gameObject.SafeDestroy();
    }

    public static void ResetLocal(this Transform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }
}
