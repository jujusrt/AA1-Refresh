using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;   // Prefab de la bala (debe tener Rigidbody)
    public Transform boquilla;        // Punto de disparo (posición/rotación de salida)
    public InputSystem_Actions input; // Mapa de inputs (New Input System)
    public float bulletForce = 500f;  // Fuerza de salida de la bala

    void Start()
    {
        input = new InputSystem_Actions(); // inicializa el mapa de acciones
        input.Enable();                    // habilita las entradas
    }

    void Update()
    {
        // Dispara si se ha presionado esta frame la acción Shoot
        if (input.Player.Shoot.WasPressedThisFrame())
        {
            // Instancia la bala en la boquilla con su rotación
            GameObject bullet = Instantiate(bulletPrefab, boquilla.position, boquilla.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>(); // intenta obtener su Rigidbody

            if (rb != null)
            {
                // Aplica impulso hacia delante de la boquilla
                rb.AddForce(boquilla.forward * bulletForce);
            }
        }
    }
}
