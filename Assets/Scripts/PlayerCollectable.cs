using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectable : MonoBehaviour
{
    [SerializeField] Transform stackPlayer;
    [SerializeField] List<GameObject> stack;
    [SerializeField] Vector3 offset;
    [SerializeField] List<Vector3> positions;
    private int count = 1;
    private bool isEmpty = true;

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            collision.gameObject.transform.position = transform.position+ offset*count;
            stack.Add(collision.gameObject);
            collision.gameObject.transform.SetParent(transform);
            count++;
        }
        
    }
}
