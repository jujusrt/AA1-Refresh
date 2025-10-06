using UnityEngine;

public class TargetController : MonoBehaviour
{

    public GameObject targetTrencat;
    public GameObject target;

    private Collider colliderTarget;
    private bool destruit = false;
    private float cont = 0f;
    public int pts = 100;

    void Start()
    {
        colliderTarget = GetComponent<Collider>();
    }

    void Update()
    {
        if (destruit)
        {
            cont += Time.deltaTime;
            if (cont >= 3f)
            {
                target.SetActive(true);
                colliderTarget.enabled = true;
                destruit= false;
                cont = 0f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bala") && !destruit)
        {
            target.SetActive(false);
            colliderTarget.enabled = false;
            Instantiate(targetTrencat, transform.position, targetTrencat.transform.rotation);
            destruit = true;

            PtsController.modificarPts.ModificarPts(pts);
        }
    }
}
