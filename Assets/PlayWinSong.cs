using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWinSong : MonoBehaviour
{
    [SerializeField] private AudioSource WinSound;

    // Start is called before the first frame update
    void Start()
    {
        //Joue le bruitage de succès de partie
        WinSound.Play();
    }

}
