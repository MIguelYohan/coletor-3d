
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 7f;

    private Rigidbody rb;
    private bool noChao = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame &&
            noChao)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            noChao = false;
        }
    }

    void FixedUpdate()
    {
        if (Keyboard.current == null) return;

        float x = 0;
        float z = 0;

        if (Keyboard.current.aKey.isPressed) x--;
        if (Keyboard.current.dKey.isPressed) x++;
        if (Keyboard.current.wKey.isPressed) z++;
        if (Keyboard.current.sKey.isPressed) z--;

        Vector3 movimento = new Vector3(x, 0, z).normalized;

        Vector3 velocidadeAtual = rb.linearVelocity;

        rb.linearVelocity = new Vector3(
            movimento.x * velocidade,
            velocidadeAtual.y,
            movimento.z * velocidade
        );
    }

    void OnCollisionStay(Collision collision)
    {
        noChao = true;
    }

    void OnCollisionExit(Collision collision)
    {
        noChao = false;
    }
}
