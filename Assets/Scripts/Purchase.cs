using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Purchase : MonoBehaviour, IPointerClickHandler
{
    public DemoPlayerBehaviour player;
    //public TMP_Text displayScore;

    // Start is called before the first frame update
    void Start()
    {
        GameObject characterObject = GameObject.FindWithTag("DemoPlayer");
        player = characterObject.GetComponent<DemoPlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void OnPointerClick(PointerEventData eventData);
}
