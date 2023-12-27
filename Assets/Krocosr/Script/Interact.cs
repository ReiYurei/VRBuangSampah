using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    [SerializeField]
    private GameObject _textUI;   

    public static Transform _HandHandle;
    private static bool _hasItem;
    public static bool HasItem { get { return _hasItem; } set { _hasItem = value; } }

    private void Awake()
    {
        _HandHandle = GetComponentInChildren<Transform>().Find("Holder");
        HasItem = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            _textUI.SetActive(true);
            Debug.LogWarning("item Approach");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IInteractable interactObj))
        {
            if (Input.GetKey(KeyCode.E)) interactObj.Interaction();
        }
        else if(HasItem == true)
        {
            _textUI.SetActive(false);
        }
    }
}
