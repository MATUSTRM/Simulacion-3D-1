using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordenar_objetos : MonoBehaviour
{
    public List<Transform> Orden_de_posiciones;
    int index;

    bool puedeOrdenar = true;


    void OnTriggerEnter(Collider other)
    {
        if (!puedeOrdenar)
            return;

        Debug.Log("INDEX ANTES: " + index);

        if (index >= Orden_de_posiciones.Count)
            return;

        puedeOrdenar = false;

        other.transform.position = Orden_de_posiciones[index].position;

        Debug.Log("Se colocó en posición: " + index);

        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        siguiente();

        StartCoroutine(EsperarSiguiente());
    }


    IEnumerator EsperarSiguiente()
    {
        yield return new WaitForFixedUpdate();

        puedeOrdenar = true;
    }


    public void siguiente()
    {
        index++;
    }
}