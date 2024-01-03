using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour, IInteractable
{
    public TypeOfTrash trashType;
    private SphereCollider _col;

    private void Awake()
    {
        _col = GetComponent<SphereCollider>();
    }

    public void Interaction()
    {
        if (Interact.HasItem != true)
        {
            _col.enabled = !_col.enabled;
            Interact.HasItem = !Interact.HasItem;
            StartCoroutine("GetItem");
        }
        else Debug.LogError("you have item!");
    }

    IEnumerator GetItem()
    {
        while (Interact.HasItem == true)
        {
            transform.position = Interact._HandHandle.position;
            transform.rotation = Interact._HandHandle.rotation;
            if (Input.GetKey(KeyCode.G))
            {
                _col.enabled = !_col.enabled;
                Interact.HasItem = !Interact.HasItem;
                StopCoroutine("GetItem");
            }

            yield return null;
        }
        yield break;
    }

}
