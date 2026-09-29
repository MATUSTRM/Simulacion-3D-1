
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ordenar_objetos : MonoBehaviour
{
    [System.Serializable]
    public class espacio
    {
        public Transform pos;
        public bool ocupado;
        public object_type obj;
    }
    public enum objetos
    {
        Manzana,
        pera,
        naranja,
        arma,
        plato,
        vaso
    }


    public objetos objeto;

    public List<espacio> espacios;
    public TextMeshProUGUI text_caja;
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
                    text_caja.text = other.GetComponent<object_type>().objeto +" No pertenece Aqui";
                else
                {
                    text_caja.text = "Bien Hecho!!";
                }
                    return;
            case objetos.naranja:

                if (tipo.objeto != objetos.naranja)
                    text_caja.text = other.GetComponent<object_type>().objeto +" No pertenece Aqui";
                else
                {
                    text_caja.text = "Bien Hecho!!";
                }   
                    return;

                

            case objetos.pera:

                if (tipo.objeto != objetos.pera)
                    text_caja.text = other.GetComponent<object_type>().objeto +" No pertenece Aqui";
                else
                {
                    text_caja.text = "Bien Hecho!!";
                }
                    return;

                

            case objetos.plato:

                if (tipo.objeto != objetos.plato)
                    text_caja.text = other.GetComponent<object_type>().objeto +" No pertenece Aqui";
                else
                {
                    text_caja.text = "Bien Hecho!!";
                }
                    return;

                

            case objetos.vaso:

                if (tipo.objeto != objetos.vaso)
                    text_caja.text = other.GetComponent<object_type>().objeto +" No pertenece Aqui";
                else
                {
                    text_caja.text = "Bien Hecho!!";
                }
                    return;

                

            case objetos.arma:

                if (tipo.objeto != objetos.arma)
                    text_caja.text = other.GetComponent<object_type>().objeto +" No pertenece Aqui";
                else
                {
                    text_caja.text = "Bien Hecho!!";
                }
                    return;

                
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
