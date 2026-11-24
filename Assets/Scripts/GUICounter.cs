
using UnityEngine;
using TMPro;

public class GUICounter : MonoBehaviour
{
    public TMP_Text textoContador;
    public GameObject WinText;

    private bool venceu = false;

    void Update()
    {
        textoContador.text = "Cristais: " + Coleta.totalColetado;

        if (Coleta.totalColetado >= 6 && !venceu)
        {
            venceu = true;
            WinText.SetActive(true);

            // Pausa o jogo
            Time.timeScale = 0f;
        }
    }
}
