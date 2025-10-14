using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject targetTrencat; // prefab de la diana rota
    public GameObject target;        // prefab de la diana normal

    private Collider colliderTarget; // collider propio para detectar balas
    private bool destruit = false;   // semaforo
    private float cont = 0f;         // temporizador para respawn
    public int pts = 100;            // puntos que da al romperse

    void Start()
    {
        colliderTarget = GetComponent<Collider>(); // pillo el collider del propio objeto
    }

    void Update()
    {
        // Si está rota, cuenta hasta 3 segundos y la reponemos
        if (destruit)
        {
            cont += Time.deltaTime;
            if (cont >= 3f)
            {
                target.SetActive(true);     // vuelve a aparecer la diana normal
                colliderTarget.enabled = true; // reactivamos collider
                destruit = false;            // ya no está rota
                cont = 0f;                  // reseteo del timer
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Si la golpea un objeto con tag "Bala" y no estaba rota
        if (other.CompareTag("Bala") && !destruit)
        {
            target.SetActive(false);        // oculto la diana normal
            colliderTarget.enabled = false; // dejo de detectar mientras está rota
            Instantiate(targetTrencat, transform.position, targetTrencat.transform.rotation); // spawneo rota
            destruit = true;                // marco estado rota

            PtsController.modificarPts.ModificarPts(pts); // sumo puntos
        }
    }
}
