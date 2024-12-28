using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class darkScreenFading : MonoBehaviour
{
    public Image darkScreen;
    public float delay;
    public float fadingSpeed;
    public float timer;
    public bool setInvisibleWhenEnter;

    private bool canStartFading;
    private void Start()
    {
        StartCoroutine(Timer());
        StartCoroutine(Delay());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canStartFading)
        {
            gameObject.SetActive(true);
            if (collision.gameObject.CompareTag("player"))
            {
                darkScreen.gameObject.SetActive(true);
                if (setInvisibleWhenEnter)
                {
                    darkScreen.color = new Color(0, 0, 0, 0);
                }
                else
                {
                    darkScreen.color = Color.black;
                }
            }
        }
    }
    private void Update()
    {
        if (canStartFading)
        {
            if (setInvisibleWhenEnter)
            {
                darkScreen.color += new Color(0, 0, 0, fadingSpeed) * Time.deltaTime;
            }
            else
            {
                darkScreen.color -= new Color(0, 0, 0, fadingSpeed) * Time.deltaTime;
            }
        }
    }
    private IEnumerator Timer()
    {
        float totaltime = timer + delay;
        yield return new WaitForSeconds(totaltime);
        darkScreen.gameObject.SetActive(false);
    }
    private IEnumerator Delay()
    {
        canStartFading = false;
        yield return new WaitForSeconds(delay);
        canStartFading = true;
    }
}
