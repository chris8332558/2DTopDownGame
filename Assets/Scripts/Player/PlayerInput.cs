using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    public KeyCode attackKey = KeyCode.Mouse0;
    public Vector2 inputVector;

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        inputVector = new Vector2(horizontalInput, verticalInput);
	}
}
