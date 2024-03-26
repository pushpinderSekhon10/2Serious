using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ToggleShopPanel();
        }
    }

    void ToggleShopPanel()
    {
        if (SceneManager.GetActiveScene().name == "Market")
        {
            SceneManager.LoadScene("PurchaseMenu");
        }
        else if (SceneManager.GetActiveScene().name == "PurchaseMenu")
        {
            SceneManager.LoadScene("Market");
        }
    }
}
