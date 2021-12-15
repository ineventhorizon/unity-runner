using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    private Vector3 movement;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        movement = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
        pos.z = Mathf.Clamp(pos.z, -2.5f, 2.5f); //returns min if z pos < min or returns max if z pos > max
        transform.position = pos;
        Debug.Log(movement);
        Move();
    }

    void Move()
    {
        //Debug.Log(this.transform.position);
        Vector3 newPos = Vector3.right + movement;
        transform.Translate(newPos * velocity * Time.deltaTime);
    }
}
