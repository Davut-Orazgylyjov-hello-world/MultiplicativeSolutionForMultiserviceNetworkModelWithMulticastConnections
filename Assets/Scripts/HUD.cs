using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public enum TypeHUD
{
   L = 0,
   S = 1,
   Ps = 2,
   Ms = 3,
   LpS = 4,
   Sl = 5,
   PlS = 6,
}

public class HUD : MonoBehaviour
{
    // public TextMeshProUGUI l, s, pS, mS, lPs, sL, pLs;


    public static HUD hud;

    public TextMeshProUGUI[] infoHUD;

    private void Awake()
    {
        hud = this;
    }

    public void SetHUD(string info, TypeHUD type)
    {
        infoHUD[(int) type].text = info;
    }

}
