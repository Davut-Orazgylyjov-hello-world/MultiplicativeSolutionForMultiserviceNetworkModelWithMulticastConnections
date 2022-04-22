using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoHUD : MonoBehaviour
{
    public TextHUD[] listTextHUD;


    public GameObject prefabInfoText;

    public void RemoveOldListTextHUD()
    {
        for (int i = 0; i < listTextHUD.Length; i++)
        {
            if(listTextHUD[i] == null)
                return;
            
            Destroy(listTextHUD[i].gameObject);
            listTextHUD[i] = null;
        }
    }
    
    public void SetCurrentSourceInfo(string info)
    {
        for (int i = 0; i < listTextHUD.Length; i++)
        {
            if (listTextHUD[i] == null)
            {
                GameObject infoText = Instantiate(prefabInfoText, transform);
                listTextHUD[i] = infoText.GetComponent<TextHUD>();
                listTextHUD[i].SetInfo(info);

                return;
            }
        }
    }

    // public void NextSource()
    // {
    //     
    // }
}
