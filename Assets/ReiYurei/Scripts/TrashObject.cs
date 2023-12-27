using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour, IInteractable
{
    public TypeOfTrash trashType;

    public void Interaction()
    {
        if (Interact.HasItem != true)
        {
            Interact.HasItem = true;
            Debug.Log("<color=blue>Item Getto</color>" + Interact.HasItem);
            StartCoroutine("GetItem");
        }
        else Debug.LogError("you have item!");
    }

    IEnumerator GetItem()
    {
        while (Interact.HasItem == true)
        {
            Debug.Log(Interact.HasItem);
            transform.position = Interact._HandHandle.position;
            yield return null;
        }
        yield break;
    }

}
