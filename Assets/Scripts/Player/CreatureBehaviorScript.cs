using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureBehaviorScript : MonoBehaviour
{
    [SerializeField] public float speed = 10;
    [SerializeField] public GameObject child;
    [SerializeField] public float initialHealth = 1000;
    bool hasDescendant;

    public Player creature;
    public GameObject CharacterPrefab;

    public Image bar;
    public Image hungerBar;
    public Image reproductionBar;

    public GameObject GameOverCanvas;
    public GameObject characteristicsCanvas;
    public GameObject BodyTypeText;
    public GameObject HeadText;
    public GameObject FrontLimbText;
    public GameObject BackLimbText;

    public GameObject EatInteractionCanvas;
    public GameObject ReproductInteractionCanvas;

    private int nextUpdate = 1;

    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas.SetActive(false);
        characteristicsCanvas.SetActive(false);

        creature = new Player(100);
        hasDescendant = false;

        creature.Speed = 10.0f;
        creature.MaxHealth = 100f;
        creature.Hunger = 70.0f;
        creature.ReproductiveNeed = 70.0f;

        if (Game.playerType == Creature.CreatureType.HERBIVORE)
        {
            creature.mBody.mBodyType = Body.BodyType.peau_base;
            creature.mHead.mActive = Head.Active.Cornes;
            creature.mHead.mPassive = Head.Passive.Dents_base;
            creature.FrontLimb.mActive = Limb.Active.Pattes_saut;
            creature.FrontLimb.mPassive = Limb.Passive.Pattes_base;
            creature.BackLimb.mActive = Limb.Active.Pattes_saut;
            creature.BackLimb.mPassive = Limb.Passive.Pattes_base;

            creature.mCreatureType = Creature.CreatureType.HERBIVORE;
        } else
        {
            creature.mBody.mBodyType = Body.BodyType.peau_base;
            creature.mHead.mActive = Head.Active.crocs;
            creature.mHead.mPassive = Head.Passive.Dents_base;
            creature.FrontLimb.mActive = Limb.Active.Pattes_saut;
            creature.FrontLimb.mPassive = Limb.Passive.Pattes_base;
            creature.BackLimb.mActive = Limb.Active.Pattes_saut;
            creature.BackLimb.mPassive = Limb.Passive.Pattes_base;

            creature.mCreatureType = Creature.CreatureType.CARNIVORE;
        }

        creature.mSex = Game.playerSex;

        Debug.Log("Sex = " + creature.mSex + "\nType = " + creature.mCreatureType);
    }

    void CheckValues()
    {
        if (creature.CurrentHealth > creature.MaxHealth)
        {
            creature.CurrentHealth = creature.MaxHealth;
        }

        if (creature.Hunger > 100f)
        {
            creature.Hunger = 100f;
        }

        if (creature.ReproductiveNeed > 100f)
        {
            creature.ReproductiveNeed = 100f;
        }

        if (creature.Hunger <= 0)
        {
            creature.Hunger = 0;
            creature.CurrentHealth -= 0.05f;
        }

        if (creature.ReproductiveNeed <= 0)
        {
            creature.ReproductiveNeed = 0;
            creature.CurrentHealth -= 0.05f;
        }

        if (creature.CurrentHealth <= 0)
        {
            GameOverCanvas.SetActive(true);
            Time.timeScale = 0;
            
        }
    }

    void FillCharacteristicsCanvas()
    {
        BodyTypeText.GetComponent<TMPro.TextMeshProUGUI>().SetText("Body type: " + this.creature.mBody.mBodyType.ToString());
        HeadText.GetComponent<TMPro.TextMeshProUGUI>().SetText("Head: (A) " + this.creature.mHead.mActive.ToString()
            + " (P) " + this.creature.mHead.mPassive.ToString());
        FrontLimbText.GetComponent<TMPro.TextMeshProUGUI>().SetText("Front limbs: (A) " + this.creature.FrontLimb.mActive.ToString()
            + " (P) " + this.creature.FrontLimb.mPassive.ToString());
        BackLimbText.GetComponent<TMPro.TextMeshProUGUI>().SetText("Back limbs: (A) " + this.creature.BackLimb.mActive.ToString()
            + " (P) " + this.creature.BackLimb.mPassive.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        CheckValues();
        FillCharacteristicsCanvas();

        if (Game.isPaused)
        {
            characteristicsCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            characteristicsCanvas.SetActive(false);
            Time.timeScale = 1;

            Move();
            Reproduct();
            Eat();

            bar.fillAmount = this.creature.CurrentHealth / this.creature.MaxHealth;
            hungerBar.fillAmount = this.creature.Hunger / 100f;
            reproductionBar.fillAmount = this.creature.ReproductiveNeed / 100f;

            // Decrementing player needs every turn
            creature.Hunger -= Game.HungerDecrementationPerUpdate;
            creature.ReproductiveNeed -= Game.ReproductiveNeedDecrementationPerUpdate;
        }
    }


    private void Eat()
    {
        List<GameObject> foodNearby = creature.GetFoodNearby(gameObject, GameObject.FindObjectsOfType<GameObject>());
        GameObject closestFood = null;

        if (foodNearby.Count != 0)
        {
            float minDistFood = Vector3.Distance(gameObject.transform.position, foodNearby[0].transform.position);
            closestFood = foodNearby[0];

            foreach (GameObject go in foodNearby)
            {
                if (Vector3.Distance(gameObject.transform.position, go.transform.position) < minDistFood)
                {
                    minDistFood = Vector3.Distance(gameObject.transform.position, go.transform.position);
                    closestFood = go;
                }
            }

            if (creature.mCreatureType == Creature.CreatureType.CARNIVORE)
            {
                if (minDistFood <= 3.0f)
                {
                    EatInteractionCanvas.SetActive(true);
                }
                else
                {
                    EatInteractionCanvas.SetActive(false);
                }
            }
            else
            {
                if (minDistFood <= Game.proximityDistance)
                {
                    EatInteractionCanvas.SetActive(true);
                }
                else
                {
                    EatInteractionCanvas.SetActive(false);
                }
            }
        }

        if (EatInteractionCanvas.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) // Eat
            {
                GetComponent<Animation>().Play("attack03");
                Debug.Log("MIAM MIAM");
                if (closestFood.GetComponent<Creature>() != null)
                {
                    closestFood.GetComponent<HerbivoreBrain>().CurrentHealth = 0.0f;
                }

                creature.Hunger += 10f;
                creature.CurrentHealth += 20f;
            }
        }
        else
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                GetComponent<Animation>().Play("run");
            }
            else
            {
                GetComponent<Animation>().Play("idle01");
            }

        }
    }

    private void Reproduct()
    {
        List<GameObject> creaturesNearby = creature.GetPossiblePartnersInSight(gameObject);
        GameObject closestCreature = null;
        if (creaturesNearby.Count != 0)
        {
            float minDistCreature = Vector3.Distance(gameObject.transform.position, creaturesNearby[0].transform.position);
            closestCreature = creaturesNearby[0];

            foreach (GameObject go in creaturesNearby)
            {
                if (go.GetComponent<Creature>().mCreatureType == creature.mCreatureType
                    && Vector3.Distance(gameObject.transform.position, go.transform.position) < minDistCreature)
                {
                    minDistCreature = Vector3.Distance(gameObject.transform.position, go.transform.position);
                    closestCreature = go;
                }
            }

            if (minDistCreature <= Game.proximityDistance && closestCreature != null
                /*&& creature.ReproductiveNeed <= Game.minReproductionNeed*/)
            {
                ReproductInteractionCanvas.SetActive(true);
            }
            else
            {
                ReproductInteractionCanvas.SetActive(false);
            }
        }

        if (ReproductInteractionCanvas.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl)) //Reproduct
            {
                Game.CreateChildPlayer(gameObject, closestCreature);
                creature.ReproductiveNeed = 100f;
            }
        }
    }

    private void Move()
    {
        //GetComponent<Animation>().Play("run");
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * creature.Speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * creature.Speed);
    }

    private void DisableParent()
    {
        Destroy(transform.GetChild(0).gameObject);
        hasDescendant = true;
        gameObject.GetComponent<CreatureBehaviorScript>().enabled = false;
    }

}
