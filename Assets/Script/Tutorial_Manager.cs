using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Tutorial_Manager : MonoBehaviour
{
    // Cantidad total de aciertos
    public int acertado = 0;
    public TextMeshProUGUI text_tutorial;
    // Cajas que participan en el tutorial
    public List<Ordenar_objetos> Cajas;
    public UnityEvent on_tutorial_complete;
    // Cantidad de aciertos necesarios
    public int objetivo = 3;

    // Indica si el tutorial ya terminó
    public bool Terminado;


    void Start()
    {
        actualizar_conteo();
    }

    // =========================================================
    // SUMAR UN ACIERTO
    // =========================================================
    public void SumarAcierto()
    {
        // Si el tutorial ya terminó, no hacemos nada
        if (Terminado)
        {
            Debug.Log("Ya terminaste el tutorial.");
            return;
        }


        acertado++;


        Debug.Log(
            "Tutorial: " +
            acertado +
            " / " +
            objetivo
        );


        // Comprobar si terminó
        if (acertado >= objetivo)
        {
            TutorialCompletado();
        }
        actualizar_conteo();
    }

    public void actualizar_conteo()
    {
        text_tutorial.text = acertado.ToString() +" / "+ objetivo.ToString();
    }
    // =========================================================
    // RESTAR UN ACIERTO
    // =========================================================
    public void RestarAcierto()
    {
        // Si el tutorial terminó, no modificamos el contador
        if (Terminado)
            return;


        acertado--;


        // Evitar números negativos
        if (acertado < 0)
            acertado = 0;

    }


    // =========================================================
    // TUTORIAL COMPLETADO
    // =========================================================
    void TutorialCompletado()
    {
        Debug.Log("¡Tutorial completado!");
        on_tutorial_complete.Invoke();
        Terminado = true;
    }
}
