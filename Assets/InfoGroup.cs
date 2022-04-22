using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoGroup : MonoBehaviour
{
    public InfoHUD infoLpS, infoPs, infoSl;

    public void SetInfo(TypeHUD typeHUD, string info)
    {
        switch (typeHUD)
        {
            case TypeHUD.LpS:
                infoLpS.SetCurrentSourceInfo(info);
                break;
            case TypeHUD.Ps:
                infoPs.SetCurrentSourceInfo(info);
                break;
            case TypeHUD.Sl:
                infoSl.SetCurrentSourceInfo(info);
                break;
            
        }
    }
    
    public void RemoveInfo(TypeHUD typeHUD)
    {
        switch (typeHUD)
        {
            case TypeHUD.LpS:
                infoLpS.RemoveOldListTextHUD();
                break;
            case TypeHUD.Ps:
                infoPs.RemoveOldListTextHUD();
                break;
            case TypeHUD.Sl:
                infoSl.RemoveOldListTextHUD();
                break;
        }
    }
}
