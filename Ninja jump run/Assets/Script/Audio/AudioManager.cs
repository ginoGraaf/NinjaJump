using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource coin;
    [SerializeField] private AudioSource die;

    public static AudioManager Instance { get; set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PickUpCoin()
    {
        coin.Play();
    }
    public void Playjump()
    {
        jump.Play();
    }
    public void PlayHit()
    {
        die.Play();
    }
}
