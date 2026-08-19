using System.Collections.Generic;
using UnityEngine;

public static class RendererUtility
{
    public static List<Renderer> GetRenderers
    (
        Transform root
    )
    {
        List<Renderer> result = new();

        if (root == null)
            return result;

        Renderer[] renderers =
            root.GetComponentsInChildren<Renderer>(true);

        for (int i = 0; i < renderers.Length; i++)
            result.Add(renderers[i]);

        return result;
    }

    public static void SetMaterial
    (
        Renderer renderer,
        Material material
    )
    {
        if (renderer == null)
            return;

        renderer.material = material;
    }

    public static void SetMaterial
    (
        List<Renderer> renderers,
        Material material
    )
    {
        if (renderers == null)
            return;

        for (int i = 0; i < renderers.Count; i++)
            SetMaterial(renderers[i], material);
    }

    public static void SetMaterials
    (
        Renderer renderer,
        Material material
    )
    {
        if (renderer == null)
            return;

        Material[] materials = new Material[renderer.materials.Length];

        for (int i = 0; i < materials.Length; i++)
            materials[i] = material;

        renderer.materials = materials;
    }

    public static void SetMaterials
    (
        List<Renderer> renderers,
        Material material
    )
    {
        if (renderers == null)
            return;

        for (int i = 0; i < renderers.Count; i++)
            SetMaterials(renderers[i], material);
    }
}