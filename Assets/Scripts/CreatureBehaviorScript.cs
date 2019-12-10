using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBehaviorScript : MonoBehaviour
{
    [SerializeField] public float speed = 10;
    Head head;
    Body body;
    Limb limbBack;
    Limb limbFront;

    // Start is called before the first frame update
    void Start()
    {
        head = new Head();
        body = new Body();
        limbBack = new Limb();
        limbFront = new Limb();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
         transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Possible mate found!");
    }
}
