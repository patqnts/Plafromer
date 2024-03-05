using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class DoorScript : MonoBehaviour
{
    public GameObject Finished;
    public HealthUIScript HealthUIScript;
    public int StageScore;
    public int orbCountReq;
    public Animator animator;
    public GameObject NotEnough;
    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if(player.orbCollected >= orbCountReq)
            {
                SetScore(StageScore);
                animator.SetTrigger("Yes");
                Invoke("ActivateFinished", 1.2f);
            }
            else
            {
                animator.SetTrigger("No");
                NotEnough.SetActive(true);
                Debug.Log("NOT ENOUGH POWER");
            }         
        }
    }
    void ActivateFinished()
    {
        // Set Finished object to active after the delay
        Time.timeScale = 0f;
        Finished.SetActive(true);
    }
    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void SetScore(int score)
    {
        PlayerProgress.IncrementScore(score);
        
    }

    public void RestartScene()
    {
        int savedHealth = PlayerPrefs.GetInt("PlayerHealth", 3);
        if (HealthUIScript != null && savedHealth <= 0)
        {
            SceneManager.LoadScene("Stage1");
        }
        else
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    public void MainMenuScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
