using UnityEngine;

public class s_bound : MonoBehaviour
{

    Collider col;
    Vector3 center;
    Vector3 size;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OutputData();
    }

    // Update is called once per frame
    void Update()
    {
        col = GetComponent<Collider>();
        center = col.bounds.center;
        size = col.bounds.size;
        
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(center,size);
    }
     void OutputData()
    {
        //Output to the console the center and size of the Collider volume
        Debug.Log("Collider Center : " + center);
        Debug.Log("Collider Size : " + size);
    }
}
