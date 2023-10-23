using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject planetPrefabs;
    float x_coor;
    float y_coor;
    float timeBetweenSpawn = 1.5f;
    public int totalSpawan = 0;
    Vector3 windowsSize;

    private void Start()
    {
        windowsSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        if(totalSpawan < 10)
        {
            timeBetweenSpawn -= Time.deltaTime;
            if(timeBetweenSpawn <= 0)
            {
                changePosition();
                planetSpawn();
                timeBetweenSpawn = 2f;
                totalSpawan++;
            }
        }
    }



    void planetSpawn()
    {
        GameObject planet = Instantiate(planetPrefabs, transform.position , Quaternion.identity);
    }

    void changePosition()
    {
        x_coor = Random.Range((float)(-windowsSize.x + 6.5), windowsSize.x - 2);
        y_coor = transform.position.y;
        transform.position = new Vector2(x_coor, y_coor);
    }
}
