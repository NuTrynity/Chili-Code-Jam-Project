using System.Collections;
using UnityEngine;

public class enemyAttackZone : MonoBehaviour
{
    public GameObject damageZone;
    public float attackSpeed;
    private float curAttackSpeed;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("player"))
        {
            if(curAttackSpeed <= 0)
            {
                StartCoroutine(Attack());
            }
        }
    }
    private void Update()
    {
        if(curAttackSpeed > 0)
        {
           curAttackSpeed -= 1 * Time.deltaTime;
        }
    }
    private IEnumerator Attack()
    {
        curAttackSpeed = attackSpeed;
        damageZone.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        damageZone.SetActive(false);
    }
}
