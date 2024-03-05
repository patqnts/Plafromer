using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneScript : MonoBehaviour
{
    public HealthUIScript healthUIScript;

    private void Start()
    {
        PlayerPrefs.SetInt("PlayerHealth", 3);
    }
}
