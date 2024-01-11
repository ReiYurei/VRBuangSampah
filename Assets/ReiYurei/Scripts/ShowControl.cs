using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowControl : MonoBehaviour
{
    public GameObject controlPage;
    [SerializeField] bool pressed;
    [SerializeField] bool isShowingControl;

    void Start()
    {
        controlPage.SetActive(false);
        isShowingControl = false;
    }

    void Update()
    {
     if (Input.GetKeyDown(KeyCode.I) == true)
        {
            pressed = !pressed;
            ShowInfo(pressed);

        }

    }

    void ShowInfo(bool button)
    {
        switch (button)
        {
            case true:
                controlPage.SetActive(true);
                Time.timeScale = 0;
                break;
            case false:
                controlPage.SetActive(false);
                Time.timeScale = 1;
                break;
        }
    }
}
