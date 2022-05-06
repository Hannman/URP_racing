using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGM_Commander : MonoBehaviour
{
    [Range(1, 500)]
    public int amountOfTime;

    void Start()
    {
        amountOfTime = 10;
    }
}
