using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMonitor : MonoBehaviour
{
    //animations
    Animation animations;

    //vitesse de déplacement
    public float vitesseMarche;
    public float vitesseCourse;
    public float vitesseTurn;

    //inputs
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;

    public Vector3 jumpspeed;
    CapsuleCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(inputFront))
        {
            transform.Translate(0, 0, vitesseMarche * Time.deltaTime);
            animations.Play("BasicMotions@Walk01");
        }

        if (Input.GetKey(inputBack))
        {
            transform.Translate(0, 0, - (vitesseMarche / 2) * Time.deltaTime);
            animations.Play("BasicMotions@Walk01");
        }

        if (Input.GetKey(inputLeft))
        {
            transform.Rotate(0, - vitesseTurn * Time.deltaTime, 0);
        }

        if (Input.GetKey(inputRight))
        {
            transform.Rotate(0, vitesseTurn * Time.deltaTime, 0);
        }

    }
}
