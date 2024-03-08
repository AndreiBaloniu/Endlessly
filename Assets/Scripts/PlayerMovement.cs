using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
   public Transform targetCircle;
    public float rotationSpeed = 500f;

    public float respawnDelay = 2f;  // timpul de întârziere înainte de respawn
    public GameObject deathPanel;    // panoul de afișare a textului

    private bool isDead = false;     // verificăm dacă jucătorul este mort

    public GameObject pauseMenu;
    private bool isPaused;

    public GameObject startPanel;
    public float startPanelDuration = 3f;

    void Start()
    {
        isPaused = false;
        if(pauseMenu.activeSelf == true)
            {
                pauseMenu.SetActive(false);
            
            }
        startPanel.SetActive(true);
        Invoke("HideStartPanel", startPanelDuration);
    }

    void HideStartPanel()
    {
        startPanel.SetActive(false);
    }
    


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(targetCircle.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(targetCircle.position, Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
        if (isDead && Input.GetKeyDown(KeyCode.R)) // dacă jucătorul este mort și apasă tasta "R"
        {
            Time.timeScale = 1f; // reluăm jocul
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name); // reîncărcăm scena curentă
        }
        if (isDead && Input.GetKeyDown(KeyCode.Q)) // dacă jucătorul este mort și apasă tasta "Q"
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0f; // Pauzăm jocul
                pauseMenu.SetActive(true); // Activăm meniul de pauză
            }
            else
            {
                Time.timeScale = 1f; // Repornim jocul
                pauseMenu.SetActive(false); // Dezactivăm meniul de pauză
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("prefab"))
        {
            isDead = true;  // dacă jucătorul atinge obstacolul, jucătorul este mort
            Time.timeScale = 0f; // oprim jocul
            deathPanel.SetActive(true); // afișăm panoul de afișare a textului
        }
    }
}
