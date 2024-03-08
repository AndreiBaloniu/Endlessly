using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // referință la textul care arată scorul
    public int prefabValue = 10; // valoarea fiecărui prefab distrus

    public int score = 0; // scorul curent

    private int prefabCount = 0; // numărul de prefab-uri distruse

    public static ScoreManager instance; // instanța singleton

    public static ScoreManager Instance { get { return instance; } } // getter pentru instanță

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddPrefabDestroyed()
    {
        prefabCount++;
        score = prefabCount * prefabValue;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
