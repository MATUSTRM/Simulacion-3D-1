using TMPro;
using UnityEngine;

public class Contador : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    int cantidad;


    void Start()
    {
        mostrar_cantidad();
    }
    void OnTriggerEnter(Collider other)
    {
        agregar();
        mostrar_cantidad();
    }

    void OnTriggerExit(Collider other)
    {
        descontar();
        mostrar_cantidad();
    }
    public void agregar()
    {
        cantidad++;
    }

    public void descontar()
    {
        cantidad--;
    }

    public void mostrar_cantidad()
    {
        text.text = cantidad.ToString();
    }
}
