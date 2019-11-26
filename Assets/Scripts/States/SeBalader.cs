
using System.Collections;
using UnityEngine;
using UnityEditor;

public class SeBalader : Task
{
    public float moveSpeed;
    public float rotSpeed;

    public bool isWandering = false;
    public bool isRotatingLeft = false;
    public bool isRotatingRight = false;
    public bool isWalking = false;


    public SeBalader(string name) : base(name) {
        this.name = "Se Balader";
    }

    private void Start()
    {
        moveSpeed = 3.0f;
        rotSpeed = 10.0f;
    }

    override public void exec(GameObject agent)
    {
        //Se Balader

        if (isWandering == false)
        {
            this.StartCoroutine(Wander());
        }

        if (isRotatingRight)
        {
            agent.transform.Rotate(agent.transform.up * Time.deltaTime * rotSpeed);
        }

        if (isRotatingLeft)
        {
            agent.transform.Rotate(agent.transform.up * Time.deltaTime * - rotSpeed);
        }

        if (isWalking)
        {
            agent.transform.position += agent.transform.forward * moveSpeed * Time.deltaTime;
        }

    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLorI = Random.Range(1, 2);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if(rotateLorI == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorI == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }

        isWandering = false;
    }
}