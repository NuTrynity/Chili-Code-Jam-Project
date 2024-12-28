using UnityEngine;

public class globalSounds : MonoBehaviour
{
    public GameObject beginningMusic;
    public AudioSource[] itemPickOpSounds;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        item.itemPickUp += PlayItemSound;
    }
    private void OnDisable()
    {
        item.itemPickUp += PlayItemSound;
    }
    public void PlayItemSound()
    {
        int randomSound = Random.Range(0, itemPickOpSounds.Length);
        itemPickOpSounds[randomSound].Play();
    }
    
}
