using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;

public class SeNourir : Task
{
    public float rotSpeed;

    public bool isWandering = false;
    public bool isRotatingLeft = false;
    public bool isRotatingRight = false;
    public bool isWalking = false;

    public SeNourir(string name) : base(name) {
        this.name = "Se Nourir";
    }

    private void Start()
    {
        this.name = "Se nourrir";
    }

    public override void exec(GameObject agent)
    {
        //List<GameObject> foodNearby = new Creature().GetPercepts(agent, GameObject.FindGameObjectsWithTag("herbe"));

        GameObject[] food = GameObject.FindGameObjectsWithTag("herbe");

        if (food.Length != 0)
        {
            float minDist = Vector3.Distance(agent.transform.position, food[0].transform.position);
            GameObject closestFood = food[0];

            for (int i = 1; i < food.Length; i++)
            {
                if (Vector3.Distance(agent.transform.position, food[i].transform.position) < minDist)
                {
                    minDist = Vector3.Distance(agent.transform.position, food[i].transform.position);
                    closestFood = food[i];
                }
            }

            if (minDist <= Game.proximityDistance)
            {
                agent.GetComponent<Animation>().Play("attack01");
                agent.GetComponent<HerbivoreBrain>().Hunger += 1.0f;
            } else
            {
                agent.GetComponent<Animation>().Play("walk");

                Vector3 dir = closestFood.transform.position;

                agent.transform.rotation = Quaternion.LookRotation(dir);

                agent.transform.position = Vector3.MoveTowards(agent.transform.position, closestFood.transform.position,
                    agent.GetComponent<HerbivoreBrain>().Speed * Time.deltaTime);
            }
        }

    }

    IEnumerator Wander()
    {
        float rotTime = Random.Range(0, 3);
        float rotateWait = Random.Range(0, 3);
        float rotateLorI = Random.Range(1, 2);
        float walkWait = Random.Range(0, 4);
        float walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorI == 1)
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