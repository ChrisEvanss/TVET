using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Purchase : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        GameManagement.instance.GivePurchase5();
    }
}
