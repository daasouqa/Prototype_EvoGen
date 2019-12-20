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

    public GameObject characteristicsCanvas;
    public GameObject BodyTypeText;
    public GameObject HeadText;
    public GameObject FrontLimbText;
    public GameObject BackLimbText;

    private int nextUpdate = 1;

    // Start is called before the first frame update
    void Start()
    {

        characteristicsCanvas.SetActive(false);

        creature = new Player(100);
        hasDescendant = false;

        creature.MaxHealth = 100f;
        creature.Hunger = 100f;
        creature.ReproductiveNeed = 100f;

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
    }

    // Update is called once per frame
    void Update()
    {
        BodyTypeText.GetComponent<TMPro.TextMeshProUGUI>().SetText("Body type: " + this.creature.mBody.mBodyType.ToString());
        HeadText.GetComponent<TMPro.TextMeshProUGUI>().SetText("Head: (A) " + this.creature.mHead.mActive.ToString()
            + " (P) " + this.creature.mHead.mPassive.ToString());
        FrontLimbText.GetComponent<TMPro.TextMeshProUGUI>().SetText("Front limbs: (A) " + this.creature.FrontLimb.mActive.ToString()
            + " (P) " + this.creature.FrontLimb.mPassive.ToString());
        BackLimbText.GetComponent<TMPro.TextMeshProUGUI>().SetText("Back limbs: (A) " + this.creature.BackLimb.mActive.ToString()
            + " (P) " + this.creature.BackLimb.mPassive.ToString());

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
            if (Time.time >= nextUpdate)
            {
                //creature.GrowOlder();
                nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            }

            bar.fillAmount = this.creature.CurrentHealth / this.creature.MaxHealth;
            hungerBar.fillAmount = this.creature.Hunger / 100f;
            reproductionBar.fillAmount = this.creature.ReproductiveNeed / 100f;
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
