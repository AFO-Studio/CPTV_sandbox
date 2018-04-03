using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public GameObject Prompt;
    public GameObject pickupPrompt;
    public Text pickUp_text;

    [SerializeField]
    private GameObject Sword;
    [SerializeField]
    private GameObject Shotgun;

    public bool SwordEquiped = false;
    public bool ShotgunEquiped = false;

    private GameObject player;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        player = GameController.Player;

        Prompt.SetActive(false);
        pickupPrompt.SetActive(false);
        anim = player.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(Sword.activeSelf == true && Input.GetAxis("Mouse ScrollWheel") < 0)
            Sword.SetActive(false);

        if (SwordEquiped == true && Sword.activeSelf == false && Input.GetAxis("Mouse ScrollWheel") > 0)
            Sword.SetActive(true);

        if (Shotgun.activeSelf == true && Input.GetAxis("Mouse ScrollWheel") < 0)
            Shotgun.SetActive(false);

        if (ShotgunEquiped == true && Shotgun.activeSelf == false && Input.GetAxis("Mouse ScrollWheel") > 0)
            Shotgun.SetActive(true);
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Medkit")
        {
            Prompt.SetActive(true);
            pickupPrompt.SetActive(true);
            pickUp_text.text = "" + col.gameObject.tag + "";
            anim.SetBool("PickUpItemInRange", true);

            if (Input.GetButtonDown("A") || Input.GetKeyDown(KeyCode.F))
            {
                PlayerStats healthScript = FindObjectOfType<PlayerStats>();
                anim.SetBool("PickUpItemInRange", false);
                healthScript.addHealthMedkit();
                Destroy(col.gameObject);

                Prompt.SetActive(false);
                pickupPrompt.SetActive(false);
            }
        }
        anim.SetBool("PickUpItemInRange", false);

        if (col.gameObject.tag == "Bandage")
            {
                Prompt.SetActive(true);
                pickupPrompt.SetActive(true);
                pickUp_text.text = "" + col.gameObject.tag + "";
            anim.SetBool("PickUpItemInRange", true);

            if (Input.GetButtonDown("A") || Input.GetKeyDown(KeyCode.F))
            {
                PlayerStats healthScript = FindObjectOfType<PlayerStats>();
                healthScript.addHealthBandage();
                Destroy(col.gameObject);
                Prompt.SetActive(false);
                pickupPrompt.SetActive(false);
                anim.SetBool("PickUpItemInRange", false);
            }
        }
        if (col.gameObject.tag == "Sword")
        {
            Prompt.SetActive(true);
            pickupPrompt.SetActive(true);
            pickUp_text.text = "" + col.gameObject.tag + "";
            anim.SetBool("PickUpItemInRange", true);

            if (Input.GetButtonDown("A") || Input.GetKeyDown(KeyCode.F))
            {
                anim.SetBool("PickUpItemInRange", false);
                Destroy(col.gameObject);
                Sword.SetActive(true);
                Prompt.SetActive(false);
                SwordEquiped = true;
                pickupPrompt.SetActive(false);
            }
        }
        if (col.gameObject.tag == "Shotgun")
        {
            Prompt.SetActive(true);
            pickupPrompt.SetActive(true);
            pickUp_text.text = "" + col.gameObject.tag + "";

            if (Input.GetButtonDown("A") || Input.GetKeyDown(KeyCode.F))
            {

                Destroy(col.gameObject);
                Shotgun.SetActive(true);
                Prompt.SetActive(false);
                ShotgunEquiped = true;
                pickupPrompt.SetActive(false);
            }
        }

    }

    private void OnTriggerExit(Collider col)
    {
        Prompt.SetActive(false);
        pickupPrompt.SetActive(false);
    }
}