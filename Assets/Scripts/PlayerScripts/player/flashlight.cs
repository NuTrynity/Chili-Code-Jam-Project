using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GeneralMovement gm;
    public Transform Enemy;

    private bool seesEnemy = false;

    private void FixedUpdate()
    {
        RaycastHit2D light = Physics2D.Raycast(transform.position, Enemy.position - transform.position);

        if (light.collider != null)
        {
            if (light.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy in sight");
                seesEnemy = true;
            }
            else
            {
                Debug.Log("Enemy out of sight");
                seesEnemy = false;
            }
        }

        Debug.DrawRay(transform.position, Enemy.position - transform.position, Color.red);
    }
}
