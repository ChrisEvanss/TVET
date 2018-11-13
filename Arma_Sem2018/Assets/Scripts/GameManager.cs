using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> tiles = new List<GameObject>();

    float timerTotal;
    float timerCurrent;

    public int index;

    // Use this for initialization
    void Start()
    {
        timerTotal = 3;
        timerCurrent = timerTotal;
    }

    // Update is called once per frame
    void Update()
    {
        timerCurrent = Time.deltaTime;
        if (timerCurrent <= 0)
        {
            Instantiate(tiles[index], new Vector3(0, 5, 0), Quaternion.identity);
            timerCurrent = timerTotal;
            if (index < tiles.Count)
            {
                index++;
            }
        }

    }
}
