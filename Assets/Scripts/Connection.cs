using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{

    public GameObject prefabUIWindow;
    
    public Transform spawnUI;
    
    public void OpenUIWindow()
    {
        NetworkManager.networkManager.TakeUIWindowConnection(Instantiate(prefabUIWindow, spawnUI));
    }
}
