using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkipScanning : MonoBehaviour
{
    [SerializeField] private bool skipScanning;

    [SerializeField] private UnityEvent eventsOnScan;
    // Start is called before the first frame update
    void Start()
    {
        if (!skipScanning) return;
        eventsOnScan.Invoke();
    }
    
}
