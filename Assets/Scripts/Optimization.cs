using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Optimization : MonoBehaviour
{
    public static Optimization optimization;

    public int maxFPS = 60;
    
    public bool light;
   // public bool postEffects;
    


    private void Awake()
    {
        optimization = this;
    }


    private void Start()
    {
        SetFrameRate();
    }


    private void SetFrameRate()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = maxFPS;
    }
}
