using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrashObject : MonoBehaviour, IInteractable
{
    public Rigidbody rb;
    public TypeOfTrash trashType;
    private Collider _col;
    private SoundsManager _sounds;

    private void Awake()
    {
        _sounds = SoundsManager.Instance;
        rb = GetComponent<Rigidbody>();
        _col = GetComponent<Collider>();
    }

    public void Interaction()
    {
        if (Interact.HasItem != true)
        {
            PlaySound(0);
            PlaySound(1);
            _col.enabled = !_col.enabled;
            Interact.HasItem = !Interact.HasItem;
            StartCoroutine("GetItem");
        }
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
                PlaySound(2);
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

    private void PlaySound(int index)
    {
        _sounds._SFXSource.pitch = Random.Range(0.8f, 1.2f);
        _sounds.AudioClip(_sounds._Sfx[index]);
    }

}
