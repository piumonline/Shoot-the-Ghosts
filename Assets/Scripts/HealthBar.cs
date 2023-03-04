using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Vector3 localScale;

    // Use this for initialization
    void Start()
    {
        localScale = transform.localScale;
    }
    
    //void Update()
    //{

    //    localScale.x = Sathan1.healthAmount;
    //    transform.localScale = localScale;

    //}

    private void FixedUpdate()
    {
        localScale.x = Sathan1.healthAmount;
        transform.localScale = localScale;
    }
}
