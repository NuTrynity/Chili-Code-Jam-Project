using System.Collections;
using UnityEngine;

public class harpoon : MonoBehaviour
{
    private GameObject new_bolt;
    public GameObject boltPrefab;
    public Transform firePoint;
    public float cooldown = 2f;
    public player_properties pp;

    private bool reloaded = true;
    private bool startedReload = false;

    public AudioSource[] shootSounds;
    private void OnEnable()
    {
        startedReload = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (reloaded)
            {
                ShootBolt();

            }
            if (pp.bolts > 0 && reloaded == false && startedReload == false)
            {
                StartCoroutine(StartCooldown(cooldown));
            }
        }
    }

    private void ShootBolt()
    {
        new_bolt = Instantiate(boltPrefab, firePoint.position, firePoint.rotation);
        new_bolt.GetComponentInChildren<Rigidbody2D>().simulated = true;
        StartCoroutine(AddColider());
        new_bolt.AddComponent<BoxCollider2D>();
        StartCoroutine(SetBoltAsItem());

        
        boltPrefab.SetActive(false);
        pp.bolts--;
        reloaded = false;

        int randomSound = Random.Range(0, shootSounds.Length);
        shootSounds[randomSound].Play();
    }
    private IEnumerator SetBoltAsItem()
    {
        bolt bolt = new_bolt.GetComponent<bolt>();
        yield return new WaitForSeconds(0.8f);
        if(bolt.dealedDamage == false)
        {
            bolt.dealedDamage = true;
            new_bolt.GetComponent<item>().pickUpAble = true;
        }
    }
    private IEnumerator AddColider()
    {
        yield return new WaitForSeconds(0.1f);
    }
    private IEnumerator StartCooldown(float cooldown_timer)
    {
        startedReload = true;
        yield return new WaitForSeconds(cooldown_timer);
        reloaded = true;
        startedReload = false;
        boltPrefab.SetActive(true);
    }
}
