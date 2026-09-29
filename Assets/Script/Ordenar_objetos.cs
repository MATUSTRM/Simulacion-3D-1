
using System.Collections.Generic;
using UnityEngine;

public class Ordenar_objetos : MonoBehaviour
{
    public enum objetos
    {
        Manzana,
        pera,
        naranja,
        arma,
        plato,
        vaso
    }

    [System.Serializable]
    public class espacio
    {
        public Transform pos;
        public bool ocupado;
        public object_type obj;
    }

    public objetos objeto;

    public List<espacio> espacios;

    void OnTriggerEnter(Collider other)
    {
        if (espacios == null || espacios.Count == 0)
        return;
        object_type tipo =
            other.GetComponent<object_type>();

        if (tipo == null)
            return;

        switch (objeto)
        {
            case objetos.Manzana:

                if (tipo.objeto != objetos.Manzana)
                    return;

                break;

            case objetos.naranja:

                if (tipo.objeto != objetos.naranja)
                    return;

                break;

            case objetos.pera:

                if (tipo.objeto != objetos.pera)
                    return;

                break;

            case objetos.plato:

                if (tipo.objeto != objetos.plato)
                    return;

                break;

            case objetos.vaso:

                if (tipo.objeto != objetos.vaso)
                    return;

                break;

            case objetos.arma:

                if (tipo.objeto != objetos.arma)
                    return;

                break;
        }

        foreach (espacio espacio in espacios)
        {
            if (espacio.ocupado)
                continue;

            espacio.ocupado = true;
            espacio.obj = tipo;

            other.transform.position =
                espacio.pos.position;

            Debug.Log(
                "Objeto guardado en: " +
                espacio.pos.name
            );

            Rigidbody rb =
                other.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.isKinematic = true;
            }

            return;
        }

        Debug.Log("No hay espacios disponibles.");
    }
}
