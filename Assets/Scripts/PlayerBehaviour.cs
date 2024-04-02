using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : ResourceManager
{
    CharacterController controller;
    //public float moveSpeed = 0.5f;
    //Vector3 movePos;

    public GameObject shopPanel;
    public GameObject statsPanel;
    public TMP_Text shopHeader, displayScore, displayHealth, displayDamage;
    public int numHealthIncreases = 0, numDamageIncreases = 0;
    public HealthSystem healthSystem;
    public GameObject player_character;
    public DamageDealer damageDealer;
    public GameObject player_weapon;

    public static Boolean bossKilled = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        shopPanel.SetActive(false);
        statsPanel.SetActive(false);

        healthSystem = player_character.GetComponent<HealthSystem>();
        damageDealer = player_weapon.GetComponent<DamageDealer>();

        //score = 0;
        //xpPoints = 0;
        //healthCapacity = 100;
        //currentHealth = 70;
        //currentDamage = 25;

    }

    // Update is called once per frame
    void Update()
    {
        //movePos.x = Input.GetAxis("Horizontal") * moveSpeed;
        //movePos.z = Input.GetAxis("Vertical") * moveSpeed;
        //controller.Move(movePos);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ToggleShopPanel();
            numDamageIncreases = 0;
            numHealthIncreases = 0;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TogglePlayerStats();
            numDamageIncreases = 0;
            numHealthIncreases = 0;
        }

        if (statsPanel.activeSelf) {
            UpdatePlayerStats();
        }

        if (bossKilled) {
            if (SceneManager.GetActiveScene().name == "showcase")
            {
                SceneManager.LoadScene("Level 2");
                return;//CHANGE SCENE LOADED HERE TO LEVEL 2 OF GAME
            }
/*            else if (SceneManager.GetActiveScene().name == "Level 2") 
            {

                SceneManager.LoadScene("Level 3"); //CHANGE SCENE LOADED HERE TO LEVEL 3 OF GAME
            }*/
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CollisionCoin")
        {
            this.updateScore(CollisionCoinBehaviour.value);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("ProximityCoin"))
        {
            this.updateScore(ProximityCoinBehaviour.value);
        }
        else if (other.CompareTag("XPSource")) {
            this.updateXP(XPSourceBehaviour.value);
        }
    }

    void ToggleShopPanel()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
        shopHeader.text = "Quick Purchase Menu";
    }

    void TogglePlayerStats()
    {
        statsPanel.SetActive(!statsPanel.activeSelf);
    }

    void UpdatePlayerStats() {
        displayHealth.text = healthSystem.health.ToString();
        displayDamage.text = damageDealer.weaponDamage.ToString();
        displayScore.text = score.ToString();
    }
}
