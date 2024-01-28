using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject[] menuParts;
    public static MenuManager menuManager;
    // Start is called before the first frame update
    void Start()
    {
        if (menuManager != null)
            Destroy(this);
        else
        {
            menuManager = this;
        }
    }
    public void DeactivateAll()
    {
        foreach (GameObject a in menuParts)
        {
            a.SetActive(false);
        }
    }
    public void Activate(GameObject gameObject)
    {

        gameObject.SetActive(true);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
