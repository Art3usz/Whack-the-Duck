using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GamaManager : MonoBehaviour
{
    public static GamaManager gamaManager;
    public TextMeshProUGUI textUratowanekaczki, textCebularze, endText;
    public GameObject duck, endpanel;
    public bool isGameStarted = false;
    public int nrLv = 0, happyducks = 0, maxCeb = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (gamaManager != null)
            Destroy(this);
        else
        {
            gamaManager = this;
        }
        maxCeb = (1 + nrLv) * 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted) return;
        GameObject[] ducks = GameObject.FindGameObjectsWithTag("duck");
        if (ducks.Length < 1)
        {
            nrLv++;
            maxCeb = (1 + nrLv) * 10;
            for (int i = 0; i < nrLv + 1 && i < 15; i++)
            {
                StartGame();
            }
        }

        textUratowanekaczki.text = "Nakarmoniono " + happyducks + " kaczek";

        textCebularze.text = "Zostało " + maxCeb + " cebularzy";
        GameObject[] Ceb = GameObject.FindGameObjectsWithTag("ceb");
        if (ducks.Length > (Ceb.Length + maxCeb))
        {
            isGameStarted = false;
            MenuManager.menuManager.DeactivateAll();
            endpanel.SetActive(true);
            // endText.text = "Nakarmoniono " + happyducks + " kaczek";
            foreach (GameObject d in ducks)
            {
                Destroy(d);
            }
            nrLv = 0; happyducks = 0; maxCeb = (1 + nrLv) * 10;

        }

    }
    public void StartGame()
    {
        isGameStarted = true;
        Instantiate(duck, new Vector3(Random.Range(-7f, 7f), Random.Range(-5f, -1f), 0f), new Quaternion());
    }
}
