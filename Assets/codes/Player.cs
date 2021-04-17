using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private float speed = 0f;
    private float turn_speed = 150f;
    public GameObject spaceship = null;
    public GameObject bullet = null;
    public GameObject cursor = null;
    

    // Start is called before the first frame update
    void Start()
    {
        this.spaceship = GameObject.Find("avaruusalus");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            speed += 0.1f;

        }
        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Transform>().Rotate(new Vector3(0, 0, -1 * turn_speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Transform>().Rotate(new Vector3(0, 0, turn_speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            speed -= 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet_ = Instantiate(this.bullet, this.cursor.GetComponent<Transform>().position, Quaternion.identity);
            bullet_.name = "ammus";
            //bullet_.transform.position += transform.up * Time.deltaTime * (speed + 0.5f);
            bullet_.transform.position += transform.up * Time.deltaTime * 100;
            //bullet_.GetComponent<Rigidbody2D>().AddForce(this.GetComponent<Transform>().forward * (speed+10000f));
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            float random_x = Random.Range(-20, 20);
            float random_y = Random.Range(-9, 9);
            transform.position = new Vector3(random_x, random_y);
        }

        transform.position += transform.up * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("has collide2");
        if (other.tag == "Meteor")
        {
            Debug.Log("has collide");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }

}
