using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{

    public GameObject prefabUIWindow;
    
    public Transform spawnUI;

    public GameObject visualSelected;

    public void OpenUIWindow()
    {
        GameObject windowUI = Instantiate(prefabUIWindow, spawnUI);
        windowUI.GetComponent<ConnectionUIWindow>().AddMotherConnection(this);
        

        NetworkManager.networkManager.TakeUIWindowConnection(windowUI);
        SelectedActive(true);
    }

    public void SelectedActive(bool active)
    {
        visualSelected.SetActive(active);
    }
}
