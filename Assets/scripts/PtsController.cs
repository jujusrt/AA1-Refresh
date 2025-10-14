using UnityEngine;
using TMPro;

public class PtsController : MonoBehaviour
{
    public static PtsController modificarPts; // acceso global a la instancia

    public TextMeshProUGUI ptsText; // referencia al texto UI
    private int ptsTotals = 0;      // acumulador de puntos

    void Start()
    {
        // patrón simple de singleton: si no existe, me asigno; si existe, me destruyo
        if (modificarPts == null)
        {
            modificarPts = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ModificarPts(int pts)
    {
        ptsTotals += pts; // sumo puntos
        ModificarPtsUI(); // refresco el texto
    }

    private void ModificarPtsUI()
    {
        if (ptsText != null)
        {
            ptsText.text = $"{ptsTotals}"; // pinto el total en la UI
        }
    }
}
