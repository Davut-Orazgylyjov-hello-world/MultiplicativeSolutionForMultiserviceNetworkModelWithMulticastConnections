using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkInformation : MonoBehaviour
{
    public static NetworkInformation netInfo;
    
    public int l;
    public int s;


    private void Awake()
    {
        netInfo = this;
    }

    public void SetL(int num)
    {
        l = num;
        HUD.hud.SetHUD($"L = [{num}]", TypeHUD.L);
    }

    public void SetS(int num)
    {
        s = num;
        HUD.hud.SetHUD($"S = [{num}]", TypeHUD.S);
    }
}
