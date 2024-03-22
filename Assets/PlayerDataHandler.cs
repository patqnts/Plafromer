using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    public static PlayerDataHandler Instance;
    // Start is called before the first frame update
    public int characterIndex;
    private PlayerController controller;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        controller = FindObjectOfType<PlayerController>();
        if(controller == null)
        {
            Debug.Log("Player not found");
        }
    }
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
