using UnityEngine;
using TMPro;

public class PtsController : MonoBehaviour
{

    public static PtsController modificarPts;

    public TextMeshProUGUI ptsText;
    private int ptsTotals = 0;
    void Start()
    {
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
        ptsTotals += pts;
        ModificarPtsUI();
    }

    private void ModificarPtsUI()
    {
        if (ptsText != null)
        {
            ptsText.text = $"{ptsTotals}";
        }
    }
}