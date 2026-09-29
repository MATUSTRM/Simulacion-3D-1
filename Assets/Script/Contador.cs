
using TMPro;
using UnityEngine;

public class Contador : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] Ordenar_objetos.objetos objeto;

    int cantidad;

    void Start()
    {
        mostrar_cantidad();
    }

    void OnTriggerEnter(Collider other)
    {
        object_type tipo = other.GetComponent<object_type>();

        if (tipo == null)
            return;

        if (tipo.objeto != objeto)
            return;

        agregar();
        mostrar_cantidad();
    }

    void OnTriggerExit(Collider other)
    {
        object_type tipo = other.GetComponent<object_type>();

        if (tipo == null)
            return;

        if (tipo.objeto != objeto)
            return;

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
