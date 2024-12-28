using Pathfinding;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class target_manager : MonoBehaviour
{
    public AIDestinationSetter destinationSetter;
    public PatrolAI patrol_ai;
    private AIPath aipath;
    private HealthComponent hc;

    public float hide_time = 5f;
    public bool can_chase = true;
    public bool canScare = true;

    public AudioSource[] scareSounds;
    public AudioSource[] attackSounds;
    private void Awake() {
        patrol_ai.PatrolPoint();
        aipath = GetComponent<AIPath>();
        hc = GetComponent<HealthComponent>();
    }

    private void Update() {
        if (can_chase == false) {
            hide_time -= Time.deltaTime;
            if (hide_time <= 0) {
                can_chase = true;
                hide_time = 5f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("player") && can_chase == true) {
            int chanceToPlaye = Random.Range(0, 100);
            if (chanceToPlaye <= 15)
            {
                int randomSound = Random.Range(0, attackSounds.Length);
                attackSounds[randomSound].Play();
            }
            ChangeTarget(other.transform);
            patrol_ai.SetAggro(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("player"))
        {
            patrol_ai.PatrolPoint();
            patrol_ai.SetAggro(false);
        }
    }
    public void ScareAway()
    {
        if (canScare == true && hc.isDead == false)
        {
            StartCoroutine(Scare());
        }
    }
    private IEnumerator Scare()
    {
        can_chase = false;
        canScare = false;
        patrol_ai.PatrolPoint();
        patrol_ai.SetAggro(false);
        int randomSound = Random.Range(0, scareSounds.Length);
        scareSounds[randomSound].Play();
        aipath.maxSpeed *= 2;
        aipath.rotationSpeed *= 2;
        yield return new WaitForSeconds(0.5f);
        aipath.maxSpeed *= 0.5f;
        aipath.rotationSpeed *= 0.5f;
        yield return new WaitForSeconds(2f);
        canScare = true;
        can_chase = true;
    }

    public void ChangeTarget(Transform target) {
        destinationSetter.target = target;
    }
}
