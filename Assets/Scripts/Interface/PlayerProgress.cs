using UnityEngine;

public static class PlayerProgress
{
    private static int playerScore = 0;

    public static int PlayerScore
    {
        get => playerScore;
        set
        {
            playerScore = value;
            // Optional: Add logic here if you need to perform actions whenever the score changes.
        }
    }

    public static void IncrementScore(int score)
    {
        if (score == 1) 
        {
            PlayerScore = 1;
        }
        else if (score == 2)
        {
            PlayerScore = 2;
        }
        Debug.Log("Player Score: " + PlayerScore);
    }

    // Add more methods if needed for different gameplay mechanics
}
