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
    public TMP_Text shopHeader;
    public int numHealthIncreases = 0, numDamageIncreases = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        shopPanel.SetActive(false);

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
}
