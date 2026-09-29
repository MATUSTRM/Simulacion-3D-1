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
        public GameObject objetoGuardado;
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
    // Tutorial Manager
    public Tutorial_Manager tutorialManager;
    // Indica si esta caja ya contó un acierto
    public bool aciertoContado;
    void OnTriggerEnter(Collider other)
    {
        if (espacios == null || espacios.Count == 0)
            return;


        object_type tipo =
            other.GetComponent<object_type>();


        if (tipo == null)
            return;



        if (tipo.objeto != objeto)
        {
            text_caja.text =
                tipo.objeto + " No pertenece Aqui";

            return;
        }


        text_caja.text = "Bien Hecho!!";



        foreach (espacio espacio in espacios)
        {
            if (espacio.ocupado)
                continue;


            // Guardar información
            espacio.ocupado = true;
            espacio.obj = tipo;
            espacio.objetoGuardado = other.gameObject;


            // Mover objeto
            other.transform.position =
                espacio.pos.position;



            Rigidbody rb =
                other.GetComponent<Rigidbody>();


            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                rb.isKinematic = true;
            }

            if (tipo.is_tutorial)
            {
                tipo.guardado = true;


                if (tutorialManager != null)
                {
                    tutorialManager.SumarAcierto();
                }
            }



            return;
        }


        Debug.Log(
            "No hay espacios disponibles."
        );
    }

    void OnTriggerExit(Collider other)
    {
        object_type tipo =
            other.GetComponent<object_type>();


        if (tipo == null)
            return;


        foreach (espacio espacio in espacios)
        {
            if (espacio.objetoGuardado == other.gameObject)
            {


                espacio.ocupado = false;
                espacio.obj = null;
                espacio.objetoGuardado = null;


                
                if (tipo.is_tutorial && tipo.guardado)
                {
                    tipo.guardado = false;


                    if (tutorialManager != null)
                    {
                        tutorialManager.RestarAcierto();
                    }
                }


                
                Rigidbody rb =
                    other.GetComponent<Rigidbody>();


                if (rb != null)
                {
                    rb.isKinematic = false;
                }


                text_caja.text =
                    "Objeto retirado";


                return;
            }
        }
    }


    
    public void SacarObjeto(int numeroEspacio)
    {
        if (numeroEspacio < 0 ||
            numeroEspacio >= espacios.Count)
            return;


        espacio espacio =
            espacios[numeroEspacio];


        if (!espacio.ocupado ||
            espacio.objetoGuardado == null)
        {
            Debug.Log(
                "Este espacio está vacío."
            );

            return;
        }


        GameObject objetoGuardado =
            espacio.objetoGuardado;


        object_type tipo =
            objetoGuardado.GetComponent<object_type>();


        // -----------------------------------------------------
        // SACAR OBJETO
        // -----------------------------------------------------
        objetoGuardado.transform.position =
            transform.position +
            transform.forward * 2f;


        // -----------------------------------------------------
        // REACTIVAR FÍSICAS
        // -----------------------------------------------------
        Rigidbody rb =
            objetoGuardado.GetComponent<Rigidbody>();


        if (rb != null)
        {
            rb.isKinematic = false;

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }


        // -----------------------------------------------------
        // RESTAR AL TUTORIAL
        // -----------------------------------------------------
        if (tipo != null &&
            tipo.is_tutorial &&
            tipo.guardado)
        {
            tipo.guardado = false;


            if (tutorialManager != null)
            {
                tutorialManager.RestarAcierto();
            }
        }


        // -----------------------------------------------------
        // LIBERAR ESPACIO
        // -----------------------------------------------------
        espacio.ocupado = false;
        espacio.obj = null;
        espacio.objetoGuardado = null;


        text_caja.text =
            "Objeto retirado";


        Debug.Log(
            "Objeto retirado del espacio " +
            numeroEspacio
        );
    }
}
