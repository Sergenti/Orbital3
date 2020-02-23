using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruscenes : MonoBehaviour

{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}