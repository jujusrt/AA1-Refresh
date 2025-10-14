using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public int pts = -500; // puntos a aplicar al chocar (negativo = resta)

    void OnCollisionEnter(Collision collision) // se llama al colisionar físicamente
    {
        // si lo que me golpea tiene el tag "Bala", modifico puntos
        if (collision.gameObject.CompareTag("Bala"))
        {
            PtsController.modificarPts.ModificarPts(pts); // aplica la penalización
        }
    }
}
