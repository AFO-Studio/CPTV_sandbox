using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    [SerializeField]
    private float hpVal;
    [SerializeField]
    private float xpVal;

    private float lvlVal;

    [SerializeField]
    private float staminaVal;

    [SerializeField]
    private Text hpText;
    [SerializeField]
    private Text lvlText;
    [SerializeField]
    private Text xpText;


    //UI Sliders represent health
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private Slider staminaBar;
    [SerializeField]
    private Slider xpBar;

    [SerializeField]
    private float medkitVal = 20.0f;
    [SerializeField]
    private float bandageVal = 5.0f;

    private float maxHP = 100.0f;
    private float maxStamina = 100.0f;
    private float maxXP = 100;

    private float minHealth = 0f;
    private float minStamina = 0f;

    public float damage = 10.0f;
    [SerializeField]
    private float fatigue = 0.05f;
    [SerializeField]
    private float stamRegen = 0.05f;

    void Start ()
    {
        //Start with full health and stamina
        hpVal = 100;
        staminaVal = 100;

        //Starting Level
        lvlVal = 1;
	}

    private void FixedUpdate()
    {
        RefreshUI();
        StatCap();

        if (xpVal >= maxXP)
        {
            LevelUp();
        }
       
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            StaminaDrain();
        }
        else
        {
            StaminaGain();
        }
    }

    void RefreshUI()
    {
        healthBar.value = hpVal;
        staminaBar.value = staminaVal;
        xpBar.value = xpVal;
        xpBar.maxValue = maxXP;
        lvlText.text = "lvl " + lvlVal + "";
        hpText.text = "" + Mathf.Round(hpVal) + "";
        xpText.text = "" + Mathf.Round(xpVal) + " / " + maxXP + " xp";
    }
    

    void StaminaDrain()
    {
        staminaVal -= fatigue;
    }

    void StaminaGain()
    {
        staminaVal += stamRegen;
    }

    void LevelUp()
    {
        lvlVal++;
        maxXP = maxXP + maxXP;
        xpVal = 0;
    }
    void StatCap()
    {
        if (hpVal >= maxHP)
        {
            hpVal = 100;
        }
        if (staminaVal >= maxStamina)
        {
            staminaVal = 100;
        }
        if (hpVal <= minHealth)
        {
            hpVal = 0;
        }
        if (staminaVal <= minStamina)
        {
            staminaVal = 0;
        }
    }

    public void addHealthMedkit()
    {
        hpVal += medkitVal;
        xpVal += 5;

    }

    public void addXP()
    {
        xpVal += 0.3f;
    }


    public void addHealthBandage()
    { 
        hpVal += bandageVal;
    }


    public void minusHealth()
    {
        hpVal -= damage;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {

            minusHealth();
        }
    }

   private void OnTriggerExit(Collider col)
   {
       pickup DangerPrompt = FindObjectOfType<pickup>();
       DangerPrompt.pickUp_text.color = Color.black;
       DangerPrompt.pickupPrompt.SetActive(false);

   }

}

