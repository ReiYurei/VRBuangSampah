using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public TypeOfTrash acceptedTrash;
    public GameScore gameScore;

    public float plusPoint;
    public float minusPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            TypeOfTrash typeOfTrash = other.GetComponent<TrashObject>().trashType;
            if(typeOfTrash == acceptedTrash)
            {
                gameScore.score += plusPoint;
            }
            else
            {
                gameScore.score += minusPoint * -1;
            }
            other.gameObject.SetActive(false);
        }
        
    }
}
