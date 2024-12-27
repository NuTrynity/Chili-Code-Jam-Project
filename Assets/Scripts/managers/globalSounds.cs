using UnityEngine;

public class globalSounds : MonoBehaviour
{
    public AudioSource[] itemPickOpSounds;
    public AudioSource music;
    private void Awake()
    {
        item.itemPickUp += PlayItemSound;
    }
    public void PlayItemSound()
    {
        int randomSound = Random.Range(0, itemPickOpSounds.Length);
        itemPickOpSounds[randomSound].Play();
    }
    public void PlayMusic()
    {
        music.Play();
    }
    
}
