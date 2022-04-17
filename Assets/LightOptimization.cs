using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOptimization : MonoBehaviour
{

    private Light _light;
    
    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    private void Start()
    {
        OptimizeLight();
    }

    private void OptimizeLight()
    {
        _light.enabled = Optimization.optimization.light;
    }
}
