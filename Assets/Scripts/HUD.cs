using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;


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

    //public InfoHUD[] infoLpS, infoPs, infoSl;
    public InfoGroup[] infoGroups;
    public GameObject prefabInfoGroups;
    public Transform spawnSourceInfo;
    
    public int _numSourceSl = 0;

    private void Awake()
    {
        hud = this;
    }

    public void NewInfoGroups()
    {
        for (int i = 0; i < infoGroups.Length; i++)
        {
            if (infoGroups[i] == null)
                break;

            Destroy(infoGroups[i].gameObject);
            infoGroups[i] = null;
        }

        for (int i = 0; i < NetworkInformation.netInfo.s; i++)
        {
            infoGroups[i] = Instantiate(prefabInfoGroups, spawnSourceInfo).GetComponent<InfoGroup>();
        }
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


        for (int i = 0; i < infoGroups.Length; i++)
        {
            if(infoGroups[i]==null)
                break;
            
            infoGroups[i].RemoveInfo(TypeHUD.LpS);
     
            infoGroups[i].RemoveInfo(TypeHUD.Ps);
        }
        


        for (int i = 0; i < lPs.Length; i++)
        {
            if (lPs[i] == next)
            {
                //show all LpS
                infoGroups[numS-1].SetInfo(TypeHUD.LpS,$"L^{numP}_{numS} = [{showLpS}]");

                showPs += " " + numP +" ";
                
                Debug.Log($"L^{numP}_{numS} = [{showLpS}]");
                numP++;
            }
            
            if (lPs[i] == end)
            {
                //show all Ps
                infoGroups[numS-1].SetInfo(TypeHUD.Ps,$"P{numS} = [{showPs}]");
                // infoPs[numS-1].NextSource();
                showPs = "";
                
                numP = 1;
                numS++;
                // infoLpS[numS-1].NextSource();
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
        infoGroups[_numSourceSl].SetInfo(TypeHUD.Sl,sL);
    }

    public void RemoveOldSl()
    {
        _numSourceSl = 0;
    }

    public void NextSourceSl()
    {
        _numSourceSl++;
    }
}
