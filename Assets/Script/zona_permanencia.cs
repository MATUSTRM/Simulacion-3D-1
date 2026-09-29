using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class zona_permanencia : MonoBehaviour
{
    public float tiempo = 3;
    bool dentro;
    float tf;
    float peso;

    public TextMeshProUGUI meshpro;
    void Start()
    {
        tf = tiempo;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dentro)
        {
            return;
        }
        if (dentro)
        {
            tiempo -= Time.deltaTime;
        }

        if (tiempo <= 0)
        {
            meshpro.text = "Peso: "+ peso.ToString();
            tiempo = tf;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        dentro = true;
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb == null)
        {
            return;
        }
        peso = rb.mass;

    }

    void OnTriggerExit(Collider other)
    {
        dentro = false;
        tiempo = tf;
    }
}
