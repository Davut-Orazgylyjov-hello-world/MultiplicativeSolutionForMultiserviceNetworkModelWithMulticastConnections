using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoUI : MonoBehaviour
{
    public Transform infoUITransform;
    public TextMeshProUGUI infoIdUI;
    
    
    public void SetPositionBetweenTwoTransformsUI(Transform a, Transform b)
    {
        var aPosition = a.localPosition;
        var bPosition = b.localPosition;
        
        infoUITransform.position = new Vector3(
            bPosition.x - aPosition.x,
            bPosition.y - aPosition.y,
            bPosition.z - aPosition.z);
    }

    public void UpdateInfoUI(string id)
    {
        infoIdUI.text = id;
    }
}
