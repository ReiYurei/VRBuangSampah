using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public static Transform _HandHandle;

    protected static bool _hasItem;
    public static bool HasItem { get { return _hasItem; } set { _hasItem = value; } }

    private void Awake()
    {
        _HandHandle = GetComponentInChildren<Transform>().Find("ItemHolder");
        _hasItem = false;
    }

    private void OnTriggerStay(Collider other)
    {
        //IF OBJECT HAVE INTERACATABLE INTERFACE, IT UPDATE
        if (other.gameObject.TryGetComponent(out IInteractable interactObj))
        {
            if (Input.GetKey(KeyCode.E))
            {
                interactObj.Interaction();
            }
        }
    }
}
