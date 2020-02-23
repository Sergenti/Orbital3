using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruscenes : MonoBehaviour
{
    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }
}
