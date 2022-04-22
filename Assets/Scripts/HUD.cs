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

    public InfoHUD infoLpS, infoPs, infoSl;

    private void Awake()
    {
        hud = this;
    }

    public void SetHUD(string info, TypeHUD type)
    {
        infoHUD[(int) type].text = info;
    }

    public void SetLpS(string lPs)
    {
        int numP = 1;
        int numS = 1;
           
        char next = '/';
        char end = ',';

        string showLpS = "";
        string showPs = "";


        infoLpS.RemoveOldListTextHUD();
        infoPs.RemoveOldListTextHUD();
        
        for (int i = 0; i < lPs.Length; i++)
        {
            if (lPs[i] == next)
            {
                //show all LpS
                infoLpS.SetCurrentSourceInfo($"L^{numP}_{numS} = [{showLpS}]");

                showPs += " " + numP +" ";
                
                Debug.Log($"L^{numP}_{numS} = [{showLpS}]");
                numP++;
            }
            
            if (lPs[i] == end)
            {
                //show all Ps
                infoPs.SetCurrentSourceInfo($"P{numS} = [{showPs}]");
                infoPs.NextSource();
                showPs = "";
                
                numP = 1;
                numS++;
                infoLpS.NextSource();
                continue;
            }

            if(lPs[i] != next && lPs[i] !=end)
                showLpS += lPs[i];
            else
            {
                showLpS = "";
            }
        }
    }

    public void SetSl(string sL)
    {
        infoSl.SetCurrentSourceInfo(sL);
    }

    public void RemoveOldSl()
    {
        infoSl.RemoveOldListTextHUD();
    }

    public void NextSourceSl()
    {
        infoSl.NextSource();
    }
}
