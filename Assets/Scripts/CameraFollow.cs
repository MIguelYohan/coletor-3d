
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform bola;

    public Vector3 distancia = new Vector3(0, 5, -8);

    public float suavidade = 5f;

    void LateUpdate()
    {
        if (bola == null) return;

        Vector3 posicaoDesejada = bola.position + distancia;

        transform.position = Vector3.Lerp(
            transform.position,
            posicaoDesejada,
            suavidade * Time.deltaTime
        );

        transform.LookAt(bola);
    }
}
