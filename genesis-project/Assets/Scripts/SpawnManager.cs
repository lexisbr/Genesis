using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject gridObject;

    public Vector2Int grid;
    public float y = 0;

    public float interval = 5;
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            Vector3 randomPos = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
            Instantiate(gridObject, randomPos, Quaternion.identity);
            //Instantiate(gridObject);
            timer -= interval;
        }
         }
        private void Start()
    {
      //  GenerateGrid(grid);
    }
    // Generates a 2D grid on the floor


}
