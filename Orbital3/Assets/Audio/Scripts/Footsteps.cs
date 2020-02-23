using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Movement;

public class Footsteps : MonoBehaviour
{
    [SerializeField] private AudioClip ftsp1;
    [SerializeField] private AudioClip ftsp2;
    [SerializeField] private AudioClip ftsp3;
    [SerializeField] private AudioClip ftsp4;
    [SerializeField] private AudioClip ftsp5;
    [SerializeField] private AudioClip ftsp6;
    [SerializeField] private AudioClip ftsp7;
    [SerializeField] private AudioClip ftsp8;
    void Start() {
         AudioSource audio = GetComponent<AudioSource>();
    }
    public void PlayFootsteps(Vector2 vector, PlayerStats stats){
        bool isNull = vector.magnitude < 0.1;
        
        switch(stats.weightLevelIdx){
            case 0: if (isNull){if (!GetComponent<AudioSource>().isPlaying){GetComponent<AudioSource>().Play();}}
                    else {GetComponent<AudioSource>().clip = ftsp2; if(!GetComponent<AudioSource>().isPlaying){GetComponent<AudioSource>().Play();}}
                    break;
            case 1: if (isNull){GetComponent<AudioSource>().clip = ftsp3;if(!GetComponent<AudioSource>().isPlaying){GetComponent<AudioSource>().Play();}}
                    else {GetComponent<AudioSource>().clip = ftsp4; if(!GetComponent<AudioSource>().isPlaying){GetComponent<AudioSource>().Play();}}
                    break;
            case 2: if (isNull){GetComponent<AudioSource>().clip = ftsp5; if(!GetComponent<AudioSource>().isPlaying){GetComponent<AudioSource>().Play();}}
                    else {GetComponent<AudioSource>().clip = ftsp6; if(!GetComponent<AudioSource>().isPlaying){GetComponent<AudioSource>().Play();}}
                    break;
            case 3: if(isNull){GetComponent<AudioSource>().clip = ftsp7;if(!GetComponent<AudioSource>().isPlaying){GetComponent<AudioSource>().Play();}}
                    else {GetComponent<AudioSource>().clip = ftsp8; if(!GetComponent<AudioSource>().isPlaying){GetComponent<AudioSource>().Play();}}
                    break;
        }
    }
}
