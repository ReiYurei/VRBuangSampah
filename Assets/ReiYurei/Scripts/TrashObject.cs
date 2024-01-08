using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour, IInteractable
{
    public Rigidbody rb;
    public TypeOfTrash trashType;
    private Collider _col;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _col = GetComponent<Collider>();
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
            rb.velocity = new Vector3(0, 1, 0);
            transform.position = Interact._DropHandle.position;
            transform.rotation = Interact._DropHandle.rotation;
            if (Input.GetKey(KeyCode.G))
            {

                _col.enabled = !_col.enabled;
                Interact.HasItem = !Interact.HasItem;
                transform.position = Interact._DropHandle.position;
                transform.rotation = Interact._DropHandle.rotation;
                StopCoroutine("GetItem");
            }
            if (Input.GetKey(KeyCode.Q))
            {

                _col.enabled = !_col.enabled;
                Interact.HasItem = !Interact.HasItem;
                transform.position = Interact._DropHandle.position;
                transform.rotation = Interact._DropHandle.rotation;
                rb.AddRelativeForce(Vector3.forward * 15, ForceMode.Impulse);
                StopCoroutine("GetItem");
            }
            yield return null;
        }
        yield break;
    }

}
