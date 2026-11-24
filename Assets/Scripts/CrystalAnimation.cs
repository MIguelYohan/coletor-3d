
using UnityEngine;

public class ColetavelAnimacao : MonoBehaviour
{
    public float altura = 1f;
    public float velocidadeSubida = 2f;
    public float velocidadeRotacao = 50f;

    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
        posicaoInicial.y += 1;
    }

    void Update()
    {
        // Movimento de subida e descida
        float movimento = Mathf.Sin(Time.time * velocidadeSubida) * altura;

        transform.position = posicaoInicial + Vector3.up * movimento;

        // Rotação lenta no eixo Y
        transform.Rotate(Vector3.up * velocidadeRotacao * Time.deltaTime);
    }
}
