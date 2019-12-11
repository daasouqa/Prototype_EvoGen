using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class SeReproduire : Task
{
    public SeReproduire(string name) : base(name) {
        this.name = "Se Reproduire";
    }

    public float rotSpeed;

    public bool isWandering = false;
    public bool isRotatingLeft = false;
    public bool isRotatingRight = false;
    public bool isWalking = false;

    public GameObject partner;

    override public void exec(GameObject agent)
    {
        Creature me = agent.GetComponent<Creature>();

        if (partner == null) // Don't have any partner
        {
            Debug.Log(partner);
            // Find possible partners in sight
            List<GameObject> possiblePartners;

            if (agent.GetComponent<HerbivoreBrain>() != null)
            {
                possiblePartners = me.GetPercepts(agent, GameObject.FindGameObjectsWithTag("herbivore"));
                for (int i = 0; i < possiblePartners.Count; i++)
                {
                    if (possiblePartners[i] == agent)
                    {
                        possiblePartners.RemoveAt(i);
                    }
                }
            }
            else
            {
                possiblePartners = me.GetPercepts(agent, GameObject.FindGameObjectsWithTag("carnivore"));
                for (int i = 0; i < possiblePartners.Count; i++)
                {
                    if (possiblePartners[i] == agent)
                    {
                        possiblePartners.RemoveAt(i);
                    }
                }
            }

            if (possiblePartners.Count != 0)
            {
                int maxSimilarities = 0;
                GameObject bestPartner = possiblePartners[0];

                for (int i = 0; i < possiblePartners.Count; i++)
                {
                    if ((me.mSex == Creature.Sex.FEMALE && possiblePartners[i].GetComponent<Creature>().mSex == Creature.Sex.MALE) 
                        || (me.mSex == Creature.Sex.MALE && possiblePartners[i].GetComponent<Creature>().mSex == Creature.Sex.FEMALE))
                    {
                        int similarities = 0;
                        if (me.mBody.mBodyType == possiblePartners[i].GetComponent<Creature>().mBody.mBodyType) similarities++;
                        if (me.mHead.mActive == possiblePartners[i].GetComponent<Creature>().mHead.mActive) similarities++;
                        if (me.mHead.mPassive == possiblePartners[i].GetComponent<Creature>().mHead.mPassive) similarities++;
                        if (me.FrontLimb.mActive == possiblePartners[i].GetComponent<Creature>().FrontLimb.mActive) similarities++;
                        if (me.FrontLimb.mPassive == possiblePartners[i].GetComponent<Creature>().FrontLimb.mPassive) similarities++;
                        if (me.BackLimb.mActive == possiblePartners[i].GetComponent<Creature>().BackLimb.mActive) similarities++;
                        if (me.BackLimb.mPassive == possiblePartners[i].GetComponent<Creature>().BackLimb.mPassive) similarities++;

                        if (similarities > maxSimilarities)
                        {
                            maxSimilarities = similarities;
                            bestPartner = possiblePartners[i];
                        }
                    }
                }
                partner = bestPartner;
            }
            else
            {
                // Wander

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
                    agent.transform.Rotate(agent.transform.up * Time.deltaTime * -rotSpeed);
                }

                if (isWalking)
                {
                    agent.transform.position += agent.transform.forward * agent.GetComponent<Creature>().Speed * Time.deltaTime;
                }
            }
        } else
        {
            if (Vector3.Distance(agent.transform.position, partner.transform.position) <= 1.0f)
            {
                Debug.Log(partner);
                agent.GetComponent<Creature>().ReproductiveNeed = 100f;
                Game.CreateChild(agent, partner);
                partner = null;
            } else
            {
                agent.transform.position = Vector3.MoveTowards(agent.transform.position, partner.transform.position,
                    agent.GetComponent<Creature>().Speed * Time.deltaTime);
            }
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