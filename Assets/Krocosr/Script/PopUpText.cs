using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    [SerializeField]
    private GameObject _textUI;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            _textUI.SetActive(true);
        }
        if (Interact.HasItem == true)
        {
            _textUI.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            _textUI.SetActive(false);
        }
    }
}
