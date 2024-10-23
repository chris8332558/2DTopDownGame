using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    public KeyCode attackKey = KeyCode.Mouse0;
    public KeyCode Ability1Key = KeyCode.Alpha1;
    public KeyCode Ability2Key = KeyCode.Alpha2;
    public KeyCode Ability3Key = KeyCode.Alpha3;
    public KeyCode Ability4Key = KeyCode.Alpha4;
    public KeyCode AbilityUseKey = KeyCode.Space;
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
