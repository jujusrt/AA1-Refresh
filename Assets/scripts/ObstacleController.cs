using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public int pts = -500;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            PtsController.modificarPts.ModificarPts(pts);
        }
    }
}
