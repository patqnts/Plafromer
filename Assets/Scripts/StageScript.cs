using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadStage(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public Button stage1Button;
    public Button stage2Button;
    public Button stage3Button;

    private void Start()
    {
        UpdateStageButtonInteractability();

        if (stage2Button.interactable )
        {
            stage2Button.image.color = Color.white;

        }
        if (stage3Button.interactable)
        {
            stage3Button.image.color = Color.white;
        }
    }

    private void UpdateStageButtonInteractability()
    {
        // Stage 1 is always interactable
        stage1Button.interactable = true;

        // Stage 2 is interactable if the score is 1 or higher
        stage2Button.interactable = PlayerProgress.PlayerScore >= 1;

        // Stage 3 is interactable if the score is 2 or higher
        stage3Button.interactable = PlayerProgress.PlayerScore >= 2;
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
