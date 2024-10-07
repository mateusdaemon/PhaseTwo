using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using UnityEngine;

public class AnalyticsManager : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        await UnityServices.InitializeAsync();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
