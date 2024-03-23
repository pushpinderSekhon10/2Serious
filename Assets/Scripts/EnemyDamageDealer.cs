using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    bool canDealDamage;
    bool hasDealDamage;

    [SerializeField] float weaponLength;
    [SerializeField] float weaponDamage;
    // Start is called before the first frame update
    void Start()
    {
        canDealDamage = false;
        hasDealDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("in here");
        if (canDealDamage && !hasDealDamage)
        {
            RaycastHit hit;
            int layerMask = 1 << 8;
            
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                print("enemy has done damage");
                hasDealDamage = true;
            }
        }
    }

    public void StartDealDamage()
    {
        canDealDamage = false;
        hasDealDamage = true;
    }

    public void EndDealDamage()
    {
        canDealDamage = false;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
}
