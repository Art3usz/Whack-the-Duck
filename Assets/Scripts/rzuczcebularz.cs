using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class rzuczcebularz : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject cebularz;
    public static rzuczcebularz rzuczceb;
  
    void Start()
    {
        if (rzuczceb != null)
            Destroy(gameObject);
        else
            rzuczceb = this;
    }
    public void rzucCebularz()
    {

        Vector3 screenPoint = Input.mousePosition;
        Vector3 pozycja = Camera.main.ScreenToWorldPoint(screenPoint);
        pozycja.z = 0;
        if (GamaManager.gamaManager.maxCeb > 0)
        {
            Destroy(Instantiate(cebularz, pozycja, new quaternion()), 5f);
            GamaManager.gamaManager.maxCeb--;
        }
    }
}
