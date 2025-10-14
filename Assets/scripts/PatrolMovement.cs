using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    [SerializeField] private Transform[] rutaPuntos;      // puntos de la patrulla
    [SerializeField] private float velocidadMovimiento = 3f; // velocidad de desplazamiento

    private int puntoActual = 0; // índice del punto al que voy ahora

    void Update()
    {
        if (rutaPuntos.Length == 0) return; // si no hay puntos, no hago nada

        Transform destino = rutaPuntos[puntoActual]; // punto objetivo
        transform.position = Vector3.MoveTowards(
            transform.position,
            destino.position,
            velocidadMovimiento * Time.deltaTime
        );

        // cuando estoy suficientemente cerca, paso al siguiente
        if (Vector3.Distance(transform.position, destino.position) <= 0.1f)
        {
            puntoActual++;
            if (puntoActual >= rutaPuntos.Length)
            {
                puntoActual = 0; // vuelvo al inicio (patrulla cíclica)
            }
        }
    }
}
