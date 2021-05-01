using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float speed = 30f;
    private float time = 0f;
    private float max_time = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, GameObject.Find("avaruusalus").transform.eulerAngles.y, transform.eulerAngles.z);
        this.transform.rotation = GameObject.Find("avaruusalus").transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = GameObject.Find("avaruusalus").transform.rotation;
        transform.position += transform.up * Time.deltaTime * speed;
        time += Time.deltaTime;

        if (time > max_time)
        {
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("has collide2");
        if (other.tag == "Meteor")
        {
            Debug.Log("has collide");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
