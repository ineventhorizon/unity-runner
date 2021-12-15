using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class RoadManager : MonoBehaviour
{   
    //add singleton
    [SerializeField] private GameObject myRoad;
    [SerializeField] private Vector3 myPos;
    [SerializeField] private GameObject finalRoad;
    [SerializeField] private Transform parent;
    [SerializeField] private List<GameObject> objects;
    [SerializeField] private bool isInitialized = false;
    private GameObject final;

    [Button]
    void createRoad()
    {
        //Vector3 newPos;
        objects.Add(Instantiate(myRoad, myPos, Quaternion.identity, parent));
        myPos = myPos + new Vector3(myRoad.transform.localScale.x, 0, 0);
        final.transform.position = new Vector3(myRoad.transform.localScale.x + final.transform.position.x, 0, 0);
    }
    
    [Button]
    void deleteRoad()
    {
        if (myPos.x == myRoad.transform.localScale.x) {
            Debug.Log("There isn't anything to remove.");
            return;
        }
        else
        {
            DestroyImmediate(objects[objects.Count - 1]);
            objects.RemoveAt(objects.Count - 1);
            myPos = myPos - new Vector3(1*myRoad.transform.localScale.x, 0, 0);
            final.transform.position = new Vector3(final.transform.position.x - myRoad.transform.localScale.x , 0, 0);
            //delete
        }
    }

    [Button]
    void initRoad()
    {
        if (!isInitialized)
        {
            objects.Add(Instantiate(myRoad, myPos, Quaternion.identity, parent));
            myPos = myPos + new Vector3(myRoad.transform.localScale.x, 0, 0);
            objects.Add(final = Instantiate(finalRoad, myPos, Quaternion.identity, parent));
            isInitialized = true;
        }
        else
        {
            Debug.Log("Already Initialized");
        }
    }
}
