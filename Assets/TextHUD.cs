using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextHUD : MonoBehaviour
{
    public TextMeshProUGUI textUI;
   
    public void SetInfo(string info)
    {
        textUI.text = info;
    }
}
