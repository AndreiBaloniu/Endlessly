using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timeText; // referință la textul care afișează timpul
    public float totalTime = 0f; // timpul total alocat jocului

    private float remainingTime; // timpul rămas
    private bool isGameOver = false; // flag care indică dacă jocul s-a terminat

    private void Start()
    {
        remainingTime = totalTime;
        UpdateTimeText();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            remainingTime += Time.deltaTime;
            UpdateTimeText();

        }
    }

    private void UpdateTimeText()
    {
        timeText.text = "Time: " + Mathf.RoundToInt(remainingTime).ToString();
    }
}