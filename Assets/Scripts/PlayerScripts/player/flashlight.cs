using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GeneralMovement gm;

    private bool seesEnemy = false;

    private void FixedUpdate()
    {
        RaycastHit2D light = Physics2D.Raycast(transform.position, (Vector2)gm.GetMousePosition() - (Vector2)transform.position);
        transform.rotation = gm.LookAt(gm.GetMousePosition(), 360);

        if (light.collider != null)
        {
            seesEnemy = light.collider.CompareTag("Enemy");
        }
        
        Vector2 mouseDir = (Vector2)gm.GetMousePosition() - (Vector2)transform.position;
        if (seesEnemy)
        {
            Debug.Log("I see the enemy!");
        }

        Debug.DrawRay(transform.position, mouseDir, Color.red);
    }
}
