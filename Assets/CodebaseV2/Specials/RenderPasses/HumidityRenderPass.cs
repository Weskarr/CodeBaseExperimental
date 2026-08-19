using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.RenderGraphModule.Util;
using UnityEngine.Rendering.Universal;

public class HumidityRenderPass : ScriptableRenderPass
{
    private readonly Material material;

    // |><>======================================================================================================<WB><|

    #region Constructor

    public HumidityRenderPass(Material material, RenderPassEvent when)
    {
        this.material = material;

        // Run this effect after the standard post-processing stack.
        renderPassEvent = when;
    }

    #endregion

    #region Render Commands

    // Records the render commands for this frame
    public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
    {
        // Bail out if no material is configured.
        if (material == null)
            return;

        // Get access to the camera's current color texture.
        UniversalResourceData resourceData = frameData.Get<UniversalResourceData>();
        TextureHandle source = resourceData.cameraColor;

        // Make sure the texture is valid.
        if (!source.IsValid())
            return;

        // Create a temporary texture matching the source.
        TextureDesc descriptor = renderGraph.GetTextureDesc(source);
        descriptor.name = "Humidity Temporary Texture";
        TextureHandle destination = renderGraph.CreateTexture(descriptor);

        // Apply the humidity effect via a blit pass.
        renderGraph.AddBlitPass
        (
            new RenderGraphUtils.BlitMaterialParameters(source, destination, material, 0),
            "Humidity Effect"
        );

        // Replace the camera color with our processed result, yay!
        resourceData.cameraColor = destination;
    }

    #endregion

    // |><>------------------------------------------------------------------------------------------------------<WB><|
}
