using TMPro;
using UnityEngine;

public class verificador_layer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    void Start()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.layer);
        //SI EL LAYER QUE SELECCIONE ES EL MISMO LAYER QUE TIENE EL GAMEOBJECT, DEBERIA SER CORRECTO :/
        if (gameObject.layer == other.gameObject.layer)
        {
            Debug.Log("CORRECTO");
            text.text = "CORRECTO";
        }
        else
        {
            Debug.Log("INCORRECTO");
            text.text = "INCORRECTO";
        }
    }

}
