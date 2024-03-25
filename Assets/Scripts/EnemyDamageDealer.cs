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
        
        if (canDealDamage && !hasDealDamage)
        {
            RaycastHit hit;
            int layerMask = 1 << 8;//selecting the 8th layer which is the "player" layer
            
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
            {
                if (hit.transform.TryGetComponent(out HealthSystem health))
                {
                    health.TakeDamage(weaponDamage);
                    hasDealDamage = true;

                }
                
            }
        }
    }

    public void StartDealDamage()
    {
        canDealDamage = true;
        hasDealDamage = false;
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
