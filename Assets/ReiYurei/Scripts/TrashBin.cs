using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public TypeOfTrash acceptedTrash;
    public GameScore gameScore;

    public float plusPoint;
    public float minusPoint;
    private void Awake()
    {
        gameScore = GameObject.Find("Score").GetComponent<GameScore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            SoundsManager.Instance._SFXSource.pitch = 1;
            TypeOfTrash typeOfTrash = other.GetComponent<TrashObject>().trashType;
            if(typeOfTrash == acceptedTrash)
            {
                
                SoundsManager.Instance.AudioClip(SoundsManager.Instance._Sfx[3]);
                gameScore.score += plusPoint;
            }
            else
            {
                SoundsManager.Instance.AudioClip(SoundsManager.Instance._Sfx[4]);
                gameScore.score += minusPoint * -1;
            }
            other.gameObject.SetActive(false);
        }
        
    }
}
