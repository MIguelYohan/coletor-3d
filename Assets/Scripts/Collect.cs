using UnityEngine;
using System.Collections;

public class Coleta : MonoBehaviour
{
    public int quantidade = 1;
    public static int totalColetado = 0;

    public float tempoDesaparecer = 1f;

    private bool coletado = false;
    private Renderer[] renderers;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (coletado) return;

        if (other.CompareTag("Player"))
        {
            coletado = true;

            totalColetado += quantidade;

            foreach (Collider col in GetComponentsInChildren<Collider>())
                col.enabled = false;

            StartCoroutine(Desaparecer());
        }
    }

    IEnumerator Desaparecer()
    {
        Vector3 escalaOriginal = transform.localScale;
        float tempo = 0f;

        while (tempo < tempoDesaparecer)
        {
            tempo += Time.deltaTime;

            float progresso = Mathf.Clamp01(
                tempo / tempoDesaparecer
            );

            transform.localScale = Vector3.Lerp(
                escalaOriginal,
                Vector3.zero,
                progresso
            );

            yield return null;
        }

        Destroy(gameObject);
    }
}
