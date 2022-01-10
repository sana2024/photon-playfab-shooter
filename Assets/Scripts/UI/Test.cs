using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Alerts alert = new Alerts();
        StartCoroutine(alert.CreateNewAlert("The scene has started"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
