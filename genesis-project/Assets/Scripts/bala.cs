using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;




public class bala : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<golpe>();

    }

    // Update is called once per frame
    void Update()
    {
        float hp = TopDownMovement.dir;
        if (hp == 1)
        {
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);

        }
        else
        if (hp ==2)
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);


        }
        //transform.position+=-transform.right * velocidad * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            source.play();
           other.GetComponent<Enemigo>().TomarDaño(daño);
            Destroy(gameObject);
        }

    }
}
