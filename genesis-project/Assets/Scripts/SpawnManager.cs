using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject boxToGenerate;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("crearzombie", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void crearzombie()
    {
        Instantiate(boxToGenerate);
    }

}
