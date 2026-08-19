
// [Summary] (By Wessel)
//
// This script is the center of all inputs,
// by turning them into events which is more performance friendly.
//
// Great tutorial explaining most of this amazing script!
// https://youtu.be/lclDl-NGUMg
// (Though at this stage it has been rewritten a few times*)
//

using System;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class InputService : ServiceBase
{
    // Changeable
    [Header("Required Asset")]
    [SerializeField] private InputActionAsset _playerControls;

    [Header("Required Map Reference")]
    [SerializeField] private string _actionMapName = "User";

    #region All Input Strings

    [Header("Required References")]
    [SerializeField] private string _mousePosition = "MousePosition";
    [SerializeField] private string _mouseDeltaName = "MouseDelta";
    [SerializeField] private string _leftMouseName = "LeftMouse";
    [SerializeField] private string _rightMouseName = "RightMouse";
    [SerializeField] private string _middleMouseName = "MiddleMouse";
    [SerializeField] private string _scrollWheelDeltaName = "ScrollWheelDelta";
    [SerializeField] private string _backspaceName = "Backspace";
    [SerializeField] private string _enterName = "Enter";
    [SerializeField] private string _deleteName = "Delete";
    [SerializeField] private string _leftArrowName = "LeftArrow";
    [SerializeField] private string _rightArrowName = "RightArrow";
    [SerializeField] private string _upArrowName = "UpArrow";
    [SerializeField] private string _downArrowName = "DownArrow";
    [SerializeField] private string _moveName = "Move";
    /*
    [SerializeField] private string _key0Name = "Key0";
    [SerializeField] private string _key1Name = "Key1";
    [SerializeField] private string _key2Name = "Key2";
    [SerializeField] private string _key3Name = "Key3";
    [SerializeField] private string _key4Name = "Key4";
    [SerializeField] private string _key5Name = "Key5";
    [SerializeField] private string _key6Name = "Key6";
    [SerializeField] private string _key7Name = "Key7";
    [SerializeField] private string _key8Name = "Key8";
    [SerializeField] private string _key9Name = "Key9";
    */
    [SerializeField] private string _keyXName = "KeyX";
    [SerializeField] private string _keyRName = "KeyR";
    [SerializeField] private string _keyIName = "KeyI";
    [SerializeField] private string _keyVName = "KeyV";
    [SerializeField] private string _keyBName = "KeyB";

    #endregion

    // |><>------------------------------------------------------------------------------------------------------<WB><|

    #region All Inputs

    private InputAction _onMousePositionInput;
    private InputAction _onLeftMouseInput;
    private InputAction _onRightMouseInput;
    private InputAction _onMiddleMouseInput;
    private InputAction _onMouseDeltaInput;
    private InputAction _onScrollWheelDeltaInput;
    private InputAction _onBackspaceInput;
    private InputAction _onEnterInput;
    private InputAction _onDeleteInput;
    private InputAction _onLeftArrowInput;
    private InputAction _onRightArrowInput;
    private InputAction _onUpArrowInput;
    private InputAction _onDownArrowInput;
    private InputAction _onMoveInput;
    /*
    private InputAction _onKey0Input;
    private InputAction _onKey1Input;
    private InputAction _onKey2Input;
    private InputAction _onKey3Input;
    private InputAction _onKey4Input;
    private InputAction _onKey5Input;
    private InputAction _onKey6Input;
    private InputAction _onKey7Input;
    private InputAction _onKey8Input;
    private InputAction _onKey9Input;
    */
    private InputAction _onKeyXInput;
    private InputAction _onKeyRInput;
    private InputAction _onKeyIInput;
    private InputAction _onKeyVInput;
    private InputAction _onKeyBInput;

    #endregion

    #region All Actions

    // Actions (on TextInput)
    public event Action<char> OnCharTyped;

    // Actions (on Started)
    public event Action OnLeftMouseStarted;
    public event Action OnRightMouseStarted;
    public event Action OnMiddleMouseStarted;
    public event Action OnBackspaceStarted;
    public event Action OnEnterStarted;
    public event Action OnDeleteStarted;
    public event Action OnLeftArrowStarted;
    public event Action OnRightArrowStarted;
    public event Action OnUpArrowStarted;
    public event Action OnDownArrowStarted;
    public event Action OnScrollWheelStarted;
    /*
    public event Action OnKey0Started;
    public event Action OnKey1Started;
    public event Action OnKey2Started;
    public event Action OnKey3Started;
    public event Action OnKey4Started;
    public event Action OnKey5Started;
    public event Action OnKey6Started;
    public event Action OnKey7Started;
    public event Action OnKey8Started;
    public event Action OnKey9Started;
    */
    public event Action OnKeyXStarted;
    public event Action OnKeyRStarted;
    public event Action OnKeyIStarted;
    public event Action OnKeyVStarted;
    public event Action OnKeyBStarted;

    // Actions (on Canceled)
    public event Action OnLeftMouseCanceled;
    public event Action OnRightMouseCanceled;
    public event Action OnMiddleMouseCanceled;
    public event Action OnBackspaceCanceled;
    public event Action OnEnterCanceled;
    public event Action OnDeleteCanceled;
    public event Action OnLeftArrowCanceled;
    public event Action OnRightArrowCanceled;
    public event Action OnUpArrowCanceled;
    public event Action OnDownArrowCanceled;
    public event Action OnMoveCanceled;
    /*
    public event Action OnKey0Canceled;
    public event Action OnKey1Canceled;
    public event Action OnKey2Canceled;
    public event Action OnKey3Canceled;
    public event Action OnKey4Canceled;
    public event Action OnKey5Canceled;
    public event Action OnKey6Canceled;
    public event Action OnKey7Canceled;
    public event Action OnKey8Canceled;
    public event Action OnKey9Canceled;
    */
    public event Action OnKeyXCanceled;
    public event Action OnKeyRCanceled;
    public event Action OnKeyICanceled;
    public event Action OnKeyVCanceled;
    public event Action OnKeyBCanceled;


    // Actions (on Performed)
    //public event Action<Vector2> OnMouseDeltaPerformed;
    //public event Action<Vector2> OnScrollWheelDeltaPerformed;
    public event Action<Vector2> OnMousePositionPerformed;
    public event Action<Vector2> OnMovePerformed;

    // Actions (Combined)
    //public event Action OnAnyMouseStarted;

    #endregion

    // |><>------------------------------------------------------------------------------------------------------<WB><|

    // Action Map
    private InputActionMap _actionMap;

    // |><>======================================================================================================<WB><|

    #region Initialize Service

    protected override void OnInitializeService()
    {
        _actionMap ??= _playerControls.FindActionMap(_actionMapName);

        AssignInputActions();
    }

    #endregion

    #region Activate Service

    protected override void OnActivateService()
    {
        RegisterInputActions();

        _actionMap.Enable();
    }

    #endregion

    #region Deactivate Service

    protected override void OnDeactivateService()
    {
        _actionMap.Disable();

        //UnregisterInputActions();
    }

    #endregion

    #region Assign Input Actions

    // Assigns the actions based on the given references.
    private void AssignInputActions()
    {
        _onMousePositionInput = _actionMap.FindAction(_mousePosition);
        _onLeftMouseInput = _actionMap.FindAction(_leftMouseName);
        _onRightMouseInput = _actionMap.FindAction(_rightMouseName);
        _onMiddleMouseInput = _actionMap.FindAction(_middleMouseName);
        _onMouseDeltaInput = _actionMap.FindAction(_mouseDeltaName);
        _onScrollWheelDeltaInput = _actionMap.FindAction(_scrollWheelDeltaName);
        _onBackspaceInput = _actionMap.FindAction(_backspaceName);
        _onEnterInput = _actionMap.FindAction(_enterName);
        _onDeleteInput = _actionMap.FindAction(_deleteName);
        _onLeftArrowInput = _actionMap.FindAction(_leftArrowName);
        _onRightArrowInput = _actionMap.FindAction(_rightArrowName);
        _onUpArrowInput = _actionMap.FindAction(_upArrowName);
        _onDownArrowInput = _actionMap.FindAction(_downArrowName);
        _onMoveInput = _actionMap.FindAction(_moveName);
        /*
        _onKey0Input = _actionMap.FindAction(_key0Name);
        _onKey1Input = _actionMap.FindAction(_key1Name);
        _onKey2Input = _actionMap.FindAction(_key2Name);
        _onKey3Input = _actionMap.FindAction(_key3Name);
        _onKey4Input = _actionMap.FindAction(_key4Name);
        _onKey5Input = _actionMap.FindAction(_key5Name);
        _onKey6Input = _actionMap.FindAction(_key6Name);
        _onKey7Input = _actionMap.FindAction(_key7Name);
        _onKey8Input = _actionMap.FindAction(_key8Name);
        _onKey9Input = _actionMap.FindAction(_key9Name);
        */
        _onKeyXInput = _actionMap.FindAction(_keyXName);
        _onKeyRInput = _actionMap.FindAction(_keyRName);
        _onKeyIInput = _actionMap.FindAction(_keyIName);
        _onKeyVInput = _actionMap.FindAction(_keyVName);
        _onKeyBInput = _actionMap.FindAction(_keyBName);

        // Expand Assignments..
    }

    #endregion

    #region Register Input Actions

    // Register the actions like a event.
    private void RegisterInputActions()
    {
        Keyboard.current.onTextInput += context => OnCharTyped?.Invoke(context);

        _onLeftMouseInput.started += context => OnLeftMouseStarted?.Invoke();
        _onRightMouseInput.started += context => OnRightMouseStarted?.Invoke();
        _onMiddleMouseInput.started += context => OnMiddleMouseStarted?.Invoke();
        _onBackspaceInput.started += context => OnBackspaceStarted?.Invoke();
        _onEnterInput.started += context => OnEnterStarted?.Invoke();
        _onDeleteInput.started += context => OnDeleteStarted?.Invoke();
        _onLeftArrowInput.started += context => OnLeftArrowStarted?.Invoke();
        _onRightArrowInput.started += context => OnRightArrowStarted?.Invoke();
        _onUpArrowInput.started += context => OnUpArrowStarted?.Invoke();
        _onDownArrowInput.started += context => OnDownArrowStarted?.Invoke();
        _onScrollWheelDeltaInput.started += context => OnScrollWheelStarted?.Invoke();
        /*
        _onKey0Input.started += context => OnKey0Started?.Invoke();
        _onKey1Input.started += context => OnKey1Started?.Invoke();
        _onKey2Input.started += context => OnKey2Started?.Invoke();
        _onKey3Input.started += context => OnKey3Started?.Invoke();
        _onKey4Input.started += context => OnKey4Started?.Invoke();
        _onKey5Input.started += context => OnKey5Started?.Invoke();
        _onKey6Input.started += context => OnKey6Started?.Invoke();
        _onKey7Input.started += context => OnKey7Started?.Invoke();
        _onKey8Input.started += context => OnKey8Started?.Invoke();
        _onKey9Input.started += context => OnKey9Started?.Invoke();
        */
        _onKeyXInput.started += context => OnKeyXStarted?.Invoke();
        _onKeyRInput.started += context => OnKeyRStarted?.Invoke();
        _onKeyIInput.started += context => OnKeyIStarted?.Invoke();
        _onKeyVInput.started += context => OnKeyVStarted?.Invoke();
        _onKeyBInput.started += context => OnKeyBStarted?.Invoke();

        _onLeftMouseInput.canceled += context => OnLeftMouseCanceled?.Invoke();
        _onRightMouseInput.canceled += context => OnRightMouseCanceled?.Invoke();
        _onMiddleMouseInput.canceled += context => OnMiddleMouseCanceled?.Invoke();
        _onBackspaceInput.canceled += context => OnBackspaceCanceled?.Invoke();
        _onEnterInput.canceled += context => OnEnterCanceled?.Invoke();
        _onDeleteInput.canceled += context => OnDeleteCanceled?.Invoke();
        _onLeftArrowInput.canceled += context => OnLeftArrowCanceled?.Invoke();
        _onRightArrowInput.canceled += context => OnRightArrowCanceled?.Invoke();
        _onUpArrowInput.canceled += context => OnUpArrowCanceled?.Invoke();
        _onDownArrowInput.canceled += context => OnDownArrowCanceled?.Invoke();
        _onMoveInput.canceled += context => OnMoveCanceled?.Invoke();
        /*
        _onKey0Input.canceled += context => OnKey0Canceled?.Invoke();
        _onKey1Input.canceled += context => OnKey1Canceled?.Invoke();
        _onKey2Input.canceled += context => OnKey2Canceled?.Invoke();
        _onKey3Input.canceled += context => OnKey3Canceled?.Invoke();
        _onKey4Input.canceled += context => OnKey4Canceled?.Invoke();
        _onKey5Input.canceled += context => OnKey5Canceled?.Invoke();
        _onKey6Input.canceled += context => OnKey6Canceled?.Invoke();
        _onKey7Input.canceled += context => OnKey7Canceled?.Invoke();
        _onKey8Input.canceled += context => OnKey8Canceled?.Invoke();
        _onKey9Input.canceled += context => OnKey9Canceled?.Invoke();
        */
        _onKeyXInput.canceled += context => OnKeyXCanceled?.Invoke();
        _onKeyRInput.canceled += context => OnKeyRCanceled?.Invoke();
        _onKeyIInput.canceled += context => OnKeyICanceled?.Invoke();
        _onKeyVInput.canceled += context => OnKeyVCanceled?.Invoke();
        _onKeyBInput.canceled += context => OnKeyBCanceled?.Invoke();

        //_onMouseDeltaInput.performed += context => OnMouseDeltaPerformed?.Invoke(context.ReadValue<Vector2>());
        //_onScrollWheelDeltaInput.performed += context => OnScrollWheelDeltaPerformed?.Invoke(context.ReadValue<Vector2>());
        _onMousePositionInput.performed += context => OnMousePositionPerformed?.Invoke(context.ReadValue<Vector2>());
        _onMoveInput.performed += context => OnMovePerformed?.Invoke(context.ReadValue<Vector2>());

        // Special Case Combined:
        //_onLeftMouseInput.started += context => OnAnyMouseStarted?.Invoke();
        //_onRightMouseInput.started += context => OnAnyMouseStarted?.Invoke();
        //_onMiddleMouseInput.started += context => OnAnyMouseStarted?.Invoke();

        // Expand Invokes..
    }

    #endregion
}