using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Refs (asumo que la cámara es hija del pivot)")]
    public Transform pivot;      // Empty en el centro de la pistola
    public Transform cam;        // Main Camera (hija del pivot)

    [Header("Sensibilidad")]
    public float sensHoriz = 100f;  // A/D (yaw)
    public float sensVert = 100f;  // W/S (pitch)


    // Tu mapa del New Input System (ya lo tenías)
    public InputSystem_Actions input;

    // Estados internos
    float yaw;         // rotación Y (horizontal)
    float pitch;       // rotación X (vertical)
    float distActual;  // distancia usada (Z local negativa)
    float distObjetivo;

    void Start()
    {
        // Inicializa input y toma la rotación inicial del pivot
        input = new InputSystem_Actions();
        input.Enable();

        Vector3 e = pivot.localEulerAngles;
        yaw = e.y;
        pitch = e.x;
    }

    void Update()
    {
        // WASD desde la action "Move" (x=A/D, y=W/S)
        Vector2 move = input.Player.Move.ReadValue<Vector2>();

        // Suma de rotaciones con sensibilidad y deltaTime
        yaw += move.x * sensHoriz * Time.deltaTime;
        pitch -= move.y * sensVert * Time.deltaTime;

        // Aplica la rotación al pivot (la cámara orbita por ser hija)
        pivot.localRotation = Quaternion.Euler(pitch, yaw, 0f);
    }

    void LateUpdate()
    {
        // Posicionado de cámara tras rotar el pivot
        if (!cam || !pivot)
        {
            return;
        }
        else
        {
            distActual = distObjetivo;
        }

        // Cámara en -Z local y mirando al pivot
        cam.localPosition = new Vector3(0f, 0f, -distActual);
        cam.LookAt(pivot.position, Vector3.up);
    }
}

