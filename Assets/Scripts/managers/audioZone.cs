using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class audioZone : MonoBehaviour
{
    public string tagToDetect;
    public AudioSource audioPlay;
    public float delayPlay;
    public bool setOffAfterEnterning;
    public AudioSource audioStop;
    public float delayStop;
    public bool setOffAfterExeting;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagToDetect))
        {
            StartCoroutine(PlayWithDelay());
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
            if (audioPlay != null)
            {
                audioPlay.Play();
            }
    }
    private IEnumerator StopWithDelay()
    {
        yield return new WaitForSeconds(delayPlay);
            if (audioStop != null)
            {
                audioStop.Stop();
            }
    }
}
