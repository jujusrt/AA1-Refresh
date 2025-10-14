using UnityEngine;
using UnityEngine.InputSystem;

public class TorretaController : MonoBehaviour
{
    [Header("Referencias")]
    public Transform torsoTorreta;  // parte que inclina en vertical (X)

    [Header("Sensibilidad")]
    public float sens = 2f;         // sensibilidad del ratón

    private float rotacionHorizontal = 0f;
    private float rotacionVertical = 0f;

    void Update()
    {
        Vector2 deltaMouse = Mouse.current.delta.ReadValue(); // delta del ratón

        rotacionHorizontal = deltaMouse.x * sens;   // giro base (Y)
        rotacionVertical -= deltaMouse.y * sens;   // pitch torso (X, invertido)

        transform.localEulerAngles += new Vector3(0f, rotacionHorizontal, 0f);    // base
        torsoTorreta.transform.localEulerAngles = new Vector3(rotacionVertical, 0f, 0f); // torso
    }
}
