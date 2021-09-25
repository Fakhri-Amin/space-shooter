using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(720, 1280, true);
    }
}
