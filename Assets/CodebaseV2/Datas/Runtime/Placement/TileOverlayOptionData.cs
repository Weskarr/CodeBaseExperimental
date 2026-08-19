
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TileOverlayOptionData
{
    public string OptionName;
    public OverlayTypeEnum Type;
    public Toggle Toggle;
    public bool IsEnabled;
    public List<GameObject> ActiveOverlays = new();

    // |><>======================================================================================================<WB><|

    #region Constructor

    public TileOverlayOptionData
    (
        string name,
        OverlayTypeEnum type,
        Toggle toggle
    )
    {
        OptionName = name;
        Type = type;
        Toggle = toggle;
    }

    #endregion

    // |><>------------------------------------------------------------------------------------------------------<WB><|
}