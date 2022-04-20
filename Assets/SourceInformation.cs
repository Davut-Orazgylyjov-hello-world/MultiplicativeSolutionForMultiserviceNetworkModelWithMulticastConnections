using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SourceInformation : MonoBehaviour
{
    public InfoUI infoUI;
    public string nameSourceInformation;
    
    private Connection _motherConnection; 
    
    public void AddMotherConnection(Connection connection)
    {
        _motherConnection = connection;
    }
    
    public void SetInfoUI(string info)
    {
        infoUI.UpdateInfoUI(info);
        nameSourceInformation = info;
    }

    public Connection GetMotherConnectionSourceInformation()
    {
        return _motherConnection;
    }
}
