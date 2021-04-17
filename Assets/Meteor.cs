using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    private float x_speed;
    private float y_speed;
    private float turn_speed;

    // Start is called before the first frame update
    void Start()
    {
        x_speed = Random.Range(-10f, 10f);
        y_speed = Random.Range(-10f, 10f);
        turn_speed = Random.Range(-100f, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = new Vector3(x_speed, y_speed, 0);
        this.transform.position += temp * Time.deltaTime;
        //transform.position += transform.up * Time.deltaTime * x_speed;
        //transform.rotation = Quaternion.Euler(Vector3.forward * turn_speed);
        //this.GetComponent<Transform>().Rotate(new Vector3(0, 0, turn_speed * Time.deltaTime));

        if (this.transform.position.x < -20 || this.transform.position.x > 20)
        {
            this.x_speed *= -1;
        }
        if (this.transform.position.y > 10 || this.transform.position.y < -10)
        {
            this.y_speed *= -1;
        }
    }

}
