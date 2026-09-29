using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float alturaRespawn = -10f;

    Vector3 posicionInicial;
    Quaternion rotacionInicial;

    Rigidbody rb;

    void Start()
    {
        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y < alturaRespawn)
        {
            RespawnObjeto();
        }
    }

    void RespawnObjeto()
    {
        transform.position = posicionInicial;
        transform.rotation = rotacionInicial;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}