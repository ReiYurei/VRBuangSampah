using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiveTrashHandler : MonoBehaviour
{
    public static CollectiveTrashHandler Instance;
    [Tooltip("Prefab goes here")]
    public List<GameObject> _TrashObj;
    [Tooltip("Auto-generate Child Obj from Prefab")]
    public List<GameObject> _TrashList;

    public int _TotalTrash;
    public int _TrashLimit;
    private GameObject planeObj;
    private Transform _mapSize;
    private MeshFilter meshFilter;

    private void Awake()
    {
        Instance = this;
        _TrashList = new List<GameObject>();
        _mapSize = GameObject.FindWithTag("Plane").transform;
        planeObj = GameObject.FindGameObjectWithTag("Plane");
        meshFilter = GameObject.FindWithTag("Plane").GetComponent<MeshFilter>();
    }

    void Start()
    {
        GetChildObject();
        InitialRandomPosition();
    }

    private void Update()
    {
        CheckActiveObject();
        SetActiveHierarchy();
    }


    //Get All child component
    private void GetChildObject()
    {
        for (int i = 0; i < _TotalTrash; i++)
        {
            // Change from GetChild to Instantiate at start
            // Transform childObj = transform.GetChild(i);

            GameObject childObj = Instantiate(_TrashObj[Random.Range(0, _TrashObj.Count)], this.transform);
            childObj.name = "Trash \t" + i;

            _TrashList.Add(childObj);
            _TrashList[i].gameObject.SetActive(false);
        }
        if (_TrashLimit > transform.childCount) 
            _TrashLimit = transform.childCount;
    }


#region Randomizer
    private Vector2 randGenerator;
    private Vector2 RandomPosition()
    {
        return randGenerator = new Vector2(
                           Random.Range(-meshFilter.mesh.bounds.extents.x, meshFilter.mesh.bounds.extents.x) * planeObj.transform.localScale.x,
                           Random.Range(-meshFilter.mesh.bounds.extents.z, meshFilter.mesh.bounds.extents.z) * planeObj.transform.localScale.z
                                );
    }

    private void InitialRandomPosition()
    {
        Debug.Log(randGenerator);
        for (int i = 0; i < _TrashLimit; i++)
        {
            _TrashList[i].gameObject.SetActive(true);
            _TrashList[i].transform.SetSiblingIndex(i);
            _TrashList[i].transform.position = new Vector3(RandomPosition().x, _mapSize.position.y, RandomPosition().y);
            Debug.Log(randGenerator);

        }
    }
    private void SetRandomPosition()
    {
        var index = _TotalTrash - 1;
        _TrashList[index].gameObject.SetActive(true);
        _TrashList[index].transform.position = new Vector3(RandomPosition().x, _mapSize.position.y, RandomPosition().y);

        //Sort Last to First
        _TrashList[index].transform.SetAsFirstSibling();
        _TrashList.Insert(0, _TrashList[index]);
        _TrashList.RemoveAt(_TotalTrash);
        //Sort to Match
        _TrashList.Sort((b, a) => a.activeInHierarchy.CompareTo(b.activeInHierarchy));
    }

#endregion

    public void SetActiveHierarchy()
    {
        for (int i = 0; i < _TotalTrash; i++)
        {
            if (!_TrashList[i].gameObject.activeInHierarchy)
            {
                _TrashList[i].transform.SetSiblingIndex(i);
            }
        }
    }

    private void CheckActiveObject()
    {
        var activeObj = GetComponentsInChildren<TrashObject>().GetLength(0);
        if (activeObj < _TrashLimit)
        {
            SetRandomPosition();
        }
    }

    /* public GameObject GetPooledObject()
     {
         for (int i = 0; i < _TrashLimit; i++)
         {
             if (!_TrashList[i].gameObject.activeInHierarchy)
             {
                 return _TrashList[i];
             }
         }
         return null;
     }*/
}
