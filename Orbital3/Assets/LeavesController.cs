using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesController : MonoBehaviour
{
    [SerializeField] private GameObject leavesEffect;
    public void InstantiateEffect(Vector3 position)
    {
        var instance = Instantiate(leavesEffect, position, Quaternion.identity);
        Destroy(instance, 2);
    }
}
