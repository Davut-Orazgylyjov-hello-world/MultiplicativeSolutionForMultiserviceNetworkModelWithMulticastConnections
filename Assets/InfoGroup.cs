using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoGroup : MonoBehaviour
{
    public InfoHUD infoLpS, infoPs, infoSl;
    
    public string[] setInfoLps, setInfoPs, setInfoSl;

    public void SetInfo(TypeHUD typeHUD, string info)
    {
        switch (typeHUD)
        {
            case TypeHUD.LpS:
                infoLpS.SetCurrentSourceInfo(info);

                for (int i = 0; i < setInfoLps.Length; i++)
                    if (setInfoLps[i] == "")
                    {
                        setInfoLps[i] = info;
                        break;
                    }

                break;

            case TypeHUD.Ps:
                infoPs.SetCurrentSourceInfo(info);

                for (int i = 0; i < setInfoPs.Length; i++)
                    if (setInfoPs[i] == "")
                    {
                        setInfoPs[i] = info;
                        break;
                    }

                break;

            case TypeHUD.Sl:
                infoSl.SetCurrentSourceInfo(info);

                for (int i = 0; i < setInfoSl.Length; i++)
                    if (setInfoSl[i] == "")
                    {
                        setInfoSl[i] = info;
                        break;
                    }

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
