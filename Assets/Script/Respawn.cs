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

     void OnDrawGizmos()
    {
        // Color de la línea
        Gizmos.color = Color.red;

        // Posición de la línea
        Vector3 posicionLinea = new Vector3(
            transform.position.x,
            alturaRespawn,
            transform.position.z
        );

        // Tamaño de la línea
        float tamaño = 5f;

        // Línea horizontal
        Gizmos.DrawLine(
            posicionLinea + Vector3.left * tamaño,
            posicionLinea + Vector3.right * tamaño
        );

        // Línea perpendicular para hacer una cruz
        Gizmos.DrawLine(
            posicionLinea + Vector3.forward * tamaño,
            posicionLinea + Vector3.back * tamaño
        );

        // Esfera en el centro
        Gizmos.DrawWireSphere(
            posicionLinea,
            0.2f
        );
    }
}