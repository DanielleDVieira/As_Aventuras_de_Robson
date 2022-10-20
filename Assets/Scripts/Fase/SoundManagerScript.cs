using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip victorySound, jumpSound, defeatSound;
    public static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        victorySound = Resources.Load<AudioClip> ("victory");
        jumpSound = Resources.Load<AudioClip> ("jump");
        defeatSound = Resources.Load<AudioClip> ("defeat");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        if(clip == "victory"){
            audioSrc.PlayOneShot(victorySound);
        }else if(clip == "jump"){
            audioSrc.PlayOneShot(jumpSound);
        }else if(clip == "defeat"){
            audioSrc.PlayOneShot(defeatSound);
        }
    }
}
