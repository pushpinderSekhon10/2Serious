using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DemoPlayerBehaviour : ResourceManager
{
    CharacterController controller;
    public float moveSpeed = 0.5f;
    Vector3 movePos;

    public TMP_Text displayDamage, displayScore, displayHealth, displayHealthCapacity;

    public GameObject shopPanel;
    public TMP_Text shopHeader;
    public int numHealthIncreases = 0, numDamageIncreases = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        shopPanel.SetActive(false);

        score = 0;
        xpPoints = 0;
        healthCapacity = 100;
        currentHealth = healthCapacity;
        currentDamage = 25;

        displayDamage.text = currentDamage.ToString();
        displayScore.text = score.ToString();
        displayHealth.text = currentHealth.ToString();
        displayHealthCapacity.text = healthCapacity.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        movePos.x = Input.GetAxis("Horizontal") * moveSpeed;
        movePos.z = Input.GetAxis("Vertical") * moveSpeed;
        controller.Move(movePos);

        if (Input.GetKeyDown(KeyCode.Return)) {
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
            displayScore.text = score.ToString();
        }
        else if (collision.gameObject.tag == "XPSource") {
            this.updateXP(XPSourceBehaviour.value);
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("ProximityCoin")) {
            this.updateScore(ProximityCoinBehaviour.value);
            displayScore.text = score.ToString();
        }
    }

    void ToggleShopPanel() {
        shopPanel.SetActive(!shopPanel.activeSelf);
        shopHeader.text = "Quick Purchase Menu";
    }
}
