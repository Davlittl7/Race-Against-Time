using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static InputManager instance;

    public bool MenuOpenCloseInput { get; private set;}

    private PlayerInput playerInput;
    private InputAction menuOpenCloseAction;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        playerInput = GetComponent<PlayerInput>();
        menuOpenCloseAction = playerInput.actions["MenuOpenClose"];
    }

    private void Update()
    {
        MenuOpenCloseInput = menuOpenCloseAction.WasPressedThisFrame();
    }
}
