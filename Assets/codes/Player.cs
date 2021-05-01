using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private float speed = 0f;
    private float turn_speed = 150f;
    private float max_turn_speed = 200f;
    public GameObject spaceship = null;
    public GameObject bullet = null;
    public GameObject cursor = null;
    public GameObject teleportLocation = null;
    

    // Start is called before the first frame update
    void Start()
    {
        this.spaceship = GameObject.Find("avaruusalus");
    }

    // Update is called once per frame
    void Update()
    {

        ShipMovement();

        

        
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

    void ShipMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            speed += 0.1f;

        }

        /*
        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Transform>().Rotate(new Vector3(0, 0, -1 * turn_speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Transform>().Rotate(new Vector3(0, 0, turn_speed * Time.deltaTime));
        }
        */

        if (Input.GetKey(KeyCode.S))
        {
            speed -= 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet_ = Instantiate(this.bullet, this.cursor.GetComponent<Transform>().position, Quaternion.identity);
            bullet_.name = "ammus";
            bullet_.transform.position += transform.up * Time.deltaTime * 100;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            float random_x = Random.Range(-20, 20);
            float random_y = Random.Range(-9, 9);
            transform.position = new Vector3(random_x, random_y);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            this.transform.position = this.teleportLocation.GetComponent<Transform>().position;
        }
        
        Vector3 spaceshipLocation = this.spaceship.transform.position;
        Vector3 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
        float angle = AngleBetweenTwoPoints(spaceshipLocation, mouseLocation);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(this.spaceship.transform.rotation.x, this.spaceship.transform.rotation.y, angle + 90), max_turn_speed * Time.deltaTime);

        transform.position += transform.up * Time.deltaTime * speed;
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

}
