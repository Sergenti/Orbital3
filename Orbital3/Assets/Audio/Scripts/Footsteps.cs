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
         
    }
    public void PlayFootsteps(Vector2 vector, PlayerStats stats){
        bool isNull = vector.magnitude < 0.1;
        AudioSource audio = GetComponent<AudioSource>();
        switch(stats.weightLevelIdx){
            case 0: if (isNull){if (!audio.isPlaying){audio.Play();}}
                    else {audio.Stop(); audio.clip = ftsp2; if(!audio.isPlaying){audio.Play();}}
                    break;
            case 1: if (isNull){audio.clip = ftsp3;if(!audio.isPlaying){audio.Play();}}
                    else {audio.clip = ftsp4; if(!audio.isPlaying){audio.Play();}}
                    break;
            case 2: if (isNull){audio.clip = ftsp5; if(!audio.isPlaying){audio.Play();}}
                    else {audio.clip = ftsp6; if(!audio.isPlaying){audio.Play();}}
                    break;
            case 3: if(isNull){audio.clip = ftsp7;if(!audio.isPlaying){audio.Play();}}
                    else {audio.clip = ftsp8; if(!audio.isPlaying){audio.Play();}}
                    break;
        }
    }
}
