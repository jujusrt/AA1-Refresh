using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform boquilla;
    public InputSystem_Actions input;
    public float bulletForce = 500f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.Player.Shoot.WasPressedThisFrame())
        {
            GameObject bullet = Instantiate(bulletPrefab, boquilla.position, boquilla.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(boquilla.forward * bulletForce);
            }
        }
    }
}
