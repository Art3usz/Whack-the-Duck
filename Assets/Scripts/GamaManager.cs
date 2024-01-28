using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour
{
    public static GamaManager gamaManager;
    public bool isGameStarted = false;
    public int nrLv = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (gamaManager != null)
            Destroy(this);
        else
        {
            gamaManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
