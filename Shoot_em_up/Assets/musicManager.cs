using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    public static musicManager music;
    public AudioSource explosion;
    public AudioSource powerUps;
    public AudioSource PlayerHurt;
    private void Awake()
    {
        music = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayExplosion()
    {
        explosion.Play();
    }

    public void PlayPowerUps()
    {
        powerUps.Play();
    }
    public void PlayPlayerHurt()
    {
        PlayerHurt.Play();
    }
}
