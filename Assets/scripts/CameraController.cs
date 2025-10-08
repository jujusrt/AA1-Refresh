using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform pivot;
    public float sensitivity_horizontal = 1;
    public float sensitivity_vertical = 1;
    InputSystem_Actions input;
    void Start()
    {
        input = new InputSystem_Actions();
        input.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 look = input.Player.Look.ReadValue<Vector2>();

        Debug.Log(look);

        pivot.transform.localEulerAngles = pivot.transform.localEulerAngles
            + new Vector3(look.y * sensitivity_vertical, look.x * sensitivity_horizontal, 0)
            * Time.deltaTime;
    }
}