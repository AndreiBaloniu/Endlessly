using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGradientColor : MonoBehaviour
{
    public float timeToChangeGradient = 5f;

    private Gradient gradient;
    private GradientColorKey[] colorKey;
    private GradientAlphaKey[] alphaKey;

    private LineRenderer lineRenderer;
    private float timer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        gradient = new Gradient();

        SetRandomGradient();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToChangeGradient)
        {
            SetRandomGradient();
            timer = 0f;
        }
    }

    void SetRandomGradient()
    {
        colorKey = new GradientColorKey[5];
        alphaKey = new GradientAlphaKey[5];

        for (int i = 0; i < 5; i++)
        {
            colorKey[i].color = new Color(Random.value, Random.value, Random.value);
            colorKey[i].time = i * 0.25f;

            alphaKey[i].alpha = 1f;
            alphaKey[i].time = i * 0.25f;
        }

        gradient.SetKeys(colorKey, alphaKey);
        lineRenderer.colorGradient = gradient;
    }
}
