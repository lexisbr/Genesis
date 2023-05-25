using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public Transform controladorDisparo;
        public GameObject bala;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
            Invoke("eliminar", 2f);
        }
    }
    private void Disparar()
    {
        GameObject go = Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation) as GameObject;
        Destroy(go, 1); //Destroy after 5 seconds.
        //Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }
    private void eliminar()
    {
       // Destroy(bala);
    }
}
