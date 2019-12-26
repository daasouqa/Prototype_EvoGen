
using System.Collections;
using UnityEngine;
using UnityEditor;

public class SeBalader : Task
{
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
        rotSpeed = 15.0f;
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
            agent.GetComponent<Animation>().Play("walk");
        }

        if (isRotatingLeft)
        {
            agent.transform.Rotate(agent.transform.up * Time.deltaTime * - rotSpeed);
            agent.GetComponent<Animation>().Play("walk");
        }

        if (isWalking)
        {
            agent.GetComponent<Animation>().Play("run");
            if (agent.GetComponent<HerbivoreBrain>() != null)
            {
                agent.transform.position += agent.transform.forward * agent.GetComponent<HerbivoreBrain>().Speed * Time.deltaTime;
            } else
            {
                agent.transform.position += agent.transform.forward * agent.GetComponent<CarnivoreBrain>().Speed * Time.deltaTime;
            }
            
        } else
        {
            agent.GetComponent<Animation>().Play("idle01");
        }
    }

    IEnumerator Wander()
    {
        float rotTime = Random.Range(1, 3);
        float rotateWait = Random.Range(1, 4);
        float rotateLorI = Random.Range(1, 2);
        float walkWait = Random.Range(1, 4);
        float walkTime = Random.Range(1, 5);

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