using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthUIScript : MonoBehaviour
{
    public GameObject[] healthIcons;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            PlayerPrefs.SetInt("PlayerHealth", 3);
        }
        // Load health from PlayerPrefs when the scene starts
        int savedHealth = PlayerPrefs.GetInt("PlayerHealth", healthIcons.Length);
        UpdateHealthUI(savedHealth);
    }

    public void DecreaseHealth(int health)
    {
        if (healthIcons.Length > 0)
        {
            health = Mathf.Clamp(health, 0, healthIcons.Length - 1);

            GameObject healthIcon = healthIcons[health];

            if (healthIcon != null && healthIcon.activeSelf)
            {
                healthIcon.SetActive(false);

                // Save the updated health to PlayerPrefs
                PlayerPrefs.SetInt("PlayerHealth", health);

                // You may also want to save the scene index to reload it later
                PlayerPrefs.SetInt("LastLoadedScene", SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void UpdateHealthUI(int health)
    {
        if (healthIcons.Length > 0)
        {
            for (int i = 0; i < healthIcons.Length; i++)
            {
                if (i < health)
                {
                    healthIcons[i].SetActive(true);
                }
                else
                {
                    healthIcons[i].SetActive(false);
                }
            }
        }
    }

    public void SetHealth(int health)
    {
        if (healthIcons.Length > 0)
        {
            for (int i = 0; i < healthIcons.Length; i++)
            {
                if (i < health)
                {
                    healthIcons[i].SetActive(true);
                }
                else
                {
                    healthIcons[i].SetActive(false);
                }
            }
        }
    }
}
