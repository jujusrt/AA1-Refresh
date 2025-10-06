using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    [SerializeField] private Transform[] rutaPuntos;
    [SerializeField] private float velocidadMovimiento = 3f;

    private int puntoActual = 0;

    void Update()
    {
        if (rutaPuntos.Length == 0) return;

        Transform destino = rutaPuntos[puntoActual];
        transform.position = Vector3.MoveTowards(transform.position, destino.position, velocidadMovimiento * Time.deltaTime);

        if (Vector3.Distance(transform.position, destino.position) <= 0.1f)
        {
            puntoActual++;
            if (puntoActual >= rutaPuntos.Length)
            {
                puntoActual = 0;
            }
        }
    }
}