using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private bool seesEnemy = false;

    private void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        RaycastHit2D light = Physics2D.Raycast(transform.position, direction);

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

        if (light.collider != null)
        {
            seesEnemy = light.collider.CompareTag("Enemy");
        }
        Vector2 mouseDir = mousePos - transform.position;
        if (seesEnemy)
        {
            Debug.Log("I see the enemy!");
        }

        Debug.DrawRay(transform.position, mouseDir, Color.red);
    }
}
