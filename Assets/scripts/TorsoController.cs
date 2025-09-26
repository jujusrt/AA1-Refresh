using UnityEngine;
using UnityEngine.InputSystem;

public class TorretaController : MonoBehaviour
{
    [Header("Referencias")] //variables
    public Transform torsoTorreta;        

    [Header("Sensibilidad")] //sensibilidad del movimiento de la torreta
    public float sens = 2f;

    private float rotacionHorizontal = 0f;
    private float rotacionVertical = 0f;

    void Update()
    {

        Vector2 deltaMouse = Mouse.current.delta.ReadValue();

        rotacionHorizontal = deltaMouse.x * sens;
        rotacionVertical -= deltaMouse.y * sens;

        transform.localEulerAngles += new Vector3(0f, rotacionHorizontal, 0f);  
        torsoTorreta.transform.localEulerAngles = new Vector3(rotacionVertical, 0f, 0f);

    }
}
