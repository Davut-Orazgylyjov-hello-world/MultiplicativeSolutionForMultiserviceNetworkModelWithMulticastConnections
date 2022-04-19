using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SourceInformation : MonoBehaviour
{
    public InfoUI infoUI;
    
    public void SetInfoUI(string info)
    {
        infoUI.UpdateInfoUI(info);
    }
}
