using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip victorySound, jumpSound, defeatSound, playerCollectSound, enemyCollectSound, damageSound;
    public static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        // Sons no resources
        victorySound = Resources.Load<AudioClip> ("victory");
        jumpSound = Resources.Load<AudioClip> ("jump");
        defeatSound = Resources.Load<AudioClip> ("defeat");
        playerCollectSound = Resources.Load<AudioClip> ("playerCollect");
        enemyCollectSound = Resources.Load<AudioClip> ("enemyCollect");
        damageSound = Resources.Load<AudioClip> ("damage");

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
        }else if(clip == "playerCollect"){
            audioSrc.PlayOneShot(playerCollectSound);
        }else if(clip == "enemyCollect"){
            audioSrc.PlayOneShot(enemyCollectSound, 1);
        }else if(clip == "damage"){
            audioSrc.PlayOneShot(damageSound);
        }
    }
}
