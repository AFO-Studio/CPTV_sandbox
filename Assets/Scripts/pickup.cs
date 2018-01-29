using UnityEngine;
using UnityEngine.UI;

public class pickup : MonoBehaviour
{
    public GameObject Prompt;
    public GameObject pickupPrompt;
    public Text pickUp_text;

    [SerializeField]
    private GameObject Sword;

    public bool SwordEquiped = false;

    // Use this for initialization
    void Start()
    {
        Prompt.SetActive(false);
        pickupPrompt.SetActive(false);
       
    }

    private void Update()
    {
        if(Sword.activeSelf == true && Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Sword.SetActive(false);
        }

        if (SwordEquiped == true && Sword.activeSelf == false && Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Sword.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Medkit")
        {
            Prompt.SetActive(true);
            pickupPrompt.SetActive(true);
            pickUp_text.text = "" + col.gameObject.tag + "";

            if (Input.GetKey(KeyCode.E))
            {
                PlayerStats healthScript = FindObjectOfType<PlayerStats>();
                healthScript.addHealthMedkit();
                Destroy(col.gameObject);

                Prompt.SetActive(false);
                pickupPrompt.SetActive(false);
            }
        }
      
        if (col.gameObject.tag == "Bandage")
            {
                Prompt.SetActive(true);
                pickupPrompt.SetActive(true);
                pickUp_text.text = "" + col.gameObject.tag + "";

            if (Input.GetKey(KeyCode.E))
            {
                PlayerStats healthScript = FindObjectOfType<PlayerStats>();
                healthScript.addHealthBandage();
                Destroy(col.gameObject);
                Prompt.SetActive(false);
                pickupPrompt.SetActive(false);
            }
        }
        if (col.gameObject.tag == "Sword")
        {
            Prompt.SetActive(true);
            pickupPrompt.SetActive(true);
            pickUp_text.text = "" + col.gameObject.tag + "";

            if (Input.GetKey(KeyCode.E))
            {

                Destroy(col.gameObject);
                Sword.SetActive(true);
                Prompt.SetActive(false);
                SwordEquiped = true;
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
        
    

