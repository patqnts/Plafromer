using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.height,true);
    }
}
