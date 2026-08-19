using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HumidityRendererFeature : ScriptableRendererFeature
{
    [Header("Required Inputs")]
    [SerializeField] private Material _passMaterial;
    [SerializeField] private RenderPassEvent _passWhen;

    // |><>------------------------------------------------------------------------------------------------------<WB><|

    // The actual render pass that does the work.
    private HumidityRenderPass pass;

    // |><>======================================================================================================<WB><|

    #region Create

    // Called once when the renderer initializes.
    public override void Create()
    {
        pass = new HumidityRenderPass(_passMaterial, _passWhen);
    }

    #endregion

    #region Add

    // Called every frame to add our pass to the rendering queue.
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(pass);
    }

    #endregion

    // |><>------------------------------------------------------------------------------------------------------<WB><|
}