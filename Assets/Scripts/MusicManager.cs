using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public List<AudioClip> musicList; // lista de melodii
    public List<int> scoreThresholds; // lista de scoruri corespunzatoare melodiilor
    public AudioSource audioSource;

    private int currentScoreThresholdIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = musicList[0];
        audioSource.Play();
    }

    void Update()
    {
        int score = ScoreManager.Instance.score;

        // cautam scorul corespunzator pentru melodia curenta
        while (currentScoreThresholdIndex < scoreThresholds.Count && score >= scoreThresholds[currentScoreThresholdIndex])
        {
            currentScoreThresholdIndex++;
        }

        // daca indexul scorului corespunzator a fost schimbat, schimbam si melodia
        if (currentScoreThresholdIndex < musicList.Count && audioSource.clip != musicList[currentScoreThresholdIndex])
        {
            audioSource.clip = musicList[currentScoreThresholdIndex];
            audioSource.Play();
        }
    }
}
