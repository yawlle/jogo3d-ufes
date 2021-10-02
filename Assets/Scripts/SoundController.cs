using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public AudioSource audioSourceMusicaDeFundo;
    public AudioClip[] musicasDeFundo;
    // Start is called before the first frame update
    void Start()
    {
        int IndexDaMusicaDeFundo = Random.Range(0, musicasDeFundo.Length);
        AudioClip musicaDeFundoDessaFase = musicasDeFundo[IndexDaMusicaDeFundo];
        audioSourceMusicaDeFundo.clip = musicaDeFundoDessaFase;
        audioSourceMusicaDeFundo.loop = true;
        audioSourceMusicaDeFundo.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}