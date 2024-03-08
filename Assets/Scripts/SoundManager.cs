using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> musicList; // lista de melodii
    public AudioSource audioSource;

    private int currentScore = 0;

    void Start()
    {
        currentScore = ScoreManager.Instance.score;
    }

    void Update()
    {
        int score = ScoreManager.Instance.score;
        if (score != currentScore)
        {
            currentScore = score;
            audioSource.PlayOneShot(musicList[0]);
        }
    }
}
