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
        var aPosition = a.position;
        var bPosition = b.position;

        infoUITransform.position = Vector3.Lerp(bPosition, aPosition, 0.5f);
    }

    public void UpdateInfoUI(string id)
    {
        infoIdUI.text = id;
    }
}
