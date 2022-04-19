using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class User : MonoBehaviour
{
    public InfoUI infoUI;
    
    public void SetInfoUI(string info)
    {
        infoUI.UpdateInfoUI(info);
    }
}
