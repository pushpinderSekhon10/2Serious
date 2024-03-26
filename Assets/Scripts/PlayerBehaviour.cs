using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : ResourceManager
{
    CharacterController controller;
    public float moveSpeed = 0.5f;
    Vector3 movePos;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        score = 0;
        xpPoints = 0;
        healthCapacity = 100;
        currentHealth = healthCapacity;
        currentDamage = 25;

    }

    // Update is called once per frame
    void Update()
    {
        movePos.x = Input.GetAxis("Horizontal") * moveSpeed;
        movePos.z = Input.GetAxis("Vertical") * moveSpeed;
        controller.Move(movePos);

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    ToggleShopPanel();
        //}


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

    //void ToggleShopPanel() {
    //    if (SceneManager.GetActiveScene().name == "Market") {
    //        SceneManager.LoadScene("PurchaseMenu");
    //    } else if (SceneManager.GetActiveScene().name == "PurchaseMenu")
    //    {
    //        SceneManager.LoadScene("Market");
    //    }
    //}
}
