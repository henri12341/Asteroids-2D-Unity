using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteors : MonoBehaviour
{

    public List<GameObject> spawnItems = new List<GameObject>();
    float timer;
    int puoli = 1;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        int x = Random.Range(-20, 20);
        int kappale = Random.Range(0, spawnItems.Count);
        timer = timer - Time.deltaTime;

        if (timer < 0)
        {
            GameObject meteor = Instantiate(this.spawnItems[kappale], new Vector3(x, 9*puoli), Quaternion.identity);
            meteor.name = "meteor";
            timer = Random.Range(0, 3);
            puoli *= -1;
        }
        
    }
}
