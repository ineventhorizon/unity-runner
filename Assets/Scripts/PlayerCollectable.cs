using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectable : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] List<GameObject> stack;
    [SerializeField] Vector3 offset;
    private int count = 2;
    private bool isEmpty = true;
    private Vector3 currentPos;
    private bool isCoroutineExecuting = false;
    float time = 0;
    // Update is called once per frame

    private void Start()
    {
        //StartCoroutine(Lerp(myNewvec, 3f));
    }
    void Update()
    {


        if (!isEmpty)
        {

            currentPos.z = Mathf.Lerp(stack[0].transform.localPosition.z, this.transform.position.z, 0.7f);
            stack[0].transform.localPosition = new Vector3(1, 0, currentPos.z);
            Vector3 myNewvec = new Vector3(1, 0, this.transform.localPosition.z);
            //isCoroutineExecuting = true;
            //StartCoroutine(Lerp(myNewvec, 3f));

            //Debug.Log(time);
            stack[0].transform.localPosition = Vector3.Lerp(stack[0].transform.localPosition, myNewvec, 0.5f);


            //stack[0].transform.position = new Vector3(2, 1, 4);

            //Debug.Log("current pos: " +currentPos+  " player: " + player.localPosition.z 
            //    + " first item world pos: " + stack[0].transform.position.z + " first item local pos: " + stack[0].transform.localPosition.z);

            for (int i = 1; i < stack.Count; i++)
            {
                currentPos = stack[i].transform.localPosition;
                currentPos.z = Mathf.Lerp(stack[i - 1].transform.localPosition.z, currentPos.z, 0.7f);
                stack[i].transform.localPosition = new Vector3((i + 1) * 1, 0, currentPos.z);
            }
            //stack[0].transform.localPosition = Vector3.right;
        }

    }

    IEnumerator Lerp(Vector3 targetPosition, float duration)
    {

        Debug.Log("STARTED");

        if (!isCoroutineExecuting || isEmpty) {
            Debug.Log("RETURNED NULL");
            yield return new WaitForSecondsRealtime(2);
        } else
        {
            Debug.Log("OK");
            float time = 0;
            Vector3 startPosition = stack[0].transform.localPosition;
            while (time < duration)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
                time += Time.deltaTime;
                Debug.Log(time);
                yield return null;
                Debug.Log(time);
            }
            stack[0].transform.localPosition = targetPosition;
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
