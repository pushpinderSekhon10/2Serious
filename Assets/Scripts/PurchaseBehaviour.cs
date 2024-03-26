using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class PurchaseBehaviour : MonoBehaviour, IPointerClickHandler
{
    public PlayerBehaviour player;
    //public TMP_Text displayScore;

    // Start is called before the first frame update
    void Start()
    {
        GameObject characterObject = GameObject.FindWithTag("DemoPlayer");
        player = characterObject.GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void OnPointerClick(PointerEventData eventData);
}
