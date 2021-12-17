using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectable : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] List<GameObject> stack;
    [SerializeField] Vector3 offset;
    [SerializeField] List<Vector3> positions;
    private int count = 2;
    private bool isEmpty = true;
    private Vector3 currentPos;
    // starting value for the Lerp
    static float t = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (!isEmpty)
        {
            currentPos = player.position;
            currentPos.z = Mathf.Clamp(Mathf.Lerp(stack[0].transform.localPosition.z, currentPos.z, 0.8f)
                , -0.3f, 0.3f);
            stack[0].transform.localPosition = new Vector3(0, 0,currentPos.z);

            for (int i = 1; i < stack.Count; i++)
            {
                currentPos = stack[i].transform.localPosition;
                currentPos.z = Mathf.Lerp(stack[i - 1].transform.localPosition.z, currentPos.z, 0.9f);
                stack[i].transform.localPosition = new Vector3(i*1, 0, currentPos.z);
            }


        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            isEmpty = false;
            collision.gameObject.transform.position = transform.TransformPoint(Vector3.right * count);
            stack.Add(collision.gameObject);
            collision.gameObject.transform.SetParent(transform);
            count++;
        }
        
    }
}
