using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBehaviorScript : MonoBehaviour
{
    [SerializeField] public float speed = 10;
    [SerializeField] public GameObject child;
    [SerializeField] public float initialHealth = 1000;
    bool hasDescendant;
    Player creature;

    private int nextUpdate = 1;

    // Start is called before the first frame update
    void Start()
    {
        //creature = new Creature(initialHealth);
        creature = new Player(100);
        hasDescendant = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Time.time >= nextUpdate)
        {
            creature.GrowOlder();
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
        }
    }

    private void Move()
    {
         transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }

   //private void OnTriggerEnter(Collider other)
   //{
   //    Debug.Log("Possible mate found!");
   //    reproduce();
   //}

    //private void reproduce()
    //{
    //    if (hasDescendant) return;
    //    CreateDescendant();
    //    DisableParent();
    //}

    //private void CreateDescendant()
    //{
    //    Vector3 newPosition = new Vector3(0, 0.6f, 0);
    //    Instantiate(child, newPosition, transform.rotation);
    //    child.GetComponent<CreatureBehaviorScript>().SetCreature(creature.Reproduce(new Creature(initialHealth)));       // TODO change this to the mate found
    //}

    private void DisableParent()
    {
        Destroy(transform.GetChild(0).gameObject);
        hasDescendant = true;
        gameObject.GetComponent<CreatureBehaviorScript>().enabled = false;
    }

}
