using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScript : MonoBehaviour
{
    public GameObject[] storyPanels; // An array to hold all the story panels
    private int currentPanelIndex = 0; // Index to track the current story panel

    void Start()
    {
        // Ensure that the first panel is active, and the others are inactive
        SetActivePanel(currentPanelIndex);
    }

    void Update()
    {
        // Check for input to proceed to the next panel
        if (Input.GetKeyDown(KeyCode.Space) && currentPanelIndex < storyPanels.Length - 1)
        {
            // Deactivate the current panel
            storyPanels[currentPanelIndex].SetActive(false);

            // Move to the next panel
            currentPanelIndex++;

            // Activate the next panel
            SetActivePanel(currentPanelIndex);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && currentPanelIndex == storyPanels.Length - 1)
        {

          
            // Deactivate the entire GameObject (this script is attached to)
            Destroy(gameObject);
        }
    }

    void SetActivePanel(int index)
    {
        // Ensure all panels are inactive
        for (int i = 0; i < storyPanels.Length; i++)
        {
            storyPanels[i].SetActive(false);
        }

        // Activate the specified panel
        storyPanels[index].SetActive(true);
    }
}
