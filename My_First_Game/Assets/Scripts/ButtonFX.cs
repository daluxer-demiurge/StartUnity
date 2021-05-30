using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    public AudioSource gameFX;
    public AudioClip clickFX;
    
    public void ClickSound()
    {
        gameFX.PlayOneShot(clickFX);
    }
}
