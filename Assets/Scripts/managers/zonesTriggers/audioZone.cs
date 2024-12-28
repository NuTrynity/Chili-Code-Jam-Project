using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class audioZone : MonoBehaviour
{
    public string tagToDetect;
    [Header("ON TRIGGER ENTER")]
    public AudioSource audioPlay;
    public float delayPlay;
    public bool setOffAfterEnterning;
    public GameObject activateObj;
    [Header("ON TRIGGER EXIT")]
    public AudioSource audioStop;
    public float delayStop;
    public bool setOffAfterExeting;
    public GameObject deActivateObj;

    public bool dontDestroyOnLoad;
    public UnityEvent eventOnEnter;
    
    public float eventDelay;
    private void Awake()
    {
        if(dontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagToDetect))
        {
            StartCoroutine(PlayWithDelay());
            StartCoroutine(EventWithDelay());
            if (setOffAfterEnterning)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagToDetect))
        {
            StartCoroutine(StopWithDelay());
            if(setOffAfterExeting)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
    private IEnumerator PlayWithDelay()
    {
        yield return new WaitForSeconds(delayPlay);
            if (audioPlay != null && audioPlay.isPlaying == false)
            {
                audioPlay.Play();
            }
            if(activateObj != null)
            {
                activateObj.SetActive(true);
            }
    }
    public void Stop()
    {
        StartCoroutine (StopWithDelay());
    }
    private IEnumerator StopWithDelay()
    {
        yield return new WaitForSeconds(delayPlay);
            if (audioStop != null)
            {
                audioStop.Pause();
            }
        if (deActivateObj != null)
        {
            deActivateObj.SetActive(false);
        }
    }
    private IEnumerator EventWithDelay()
    {
        yield return new WaitForSeconds(eventDelay);
        eventOnEnter.Invoke();
    }
}
