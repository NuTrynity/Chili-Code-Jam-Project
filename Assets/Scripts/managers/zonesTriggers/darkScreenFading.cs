using UnityEngine;
using UnityEngine.UI;

public class darkScreenFading : MonoBehaviour
{
    private Image im;
    public float fadingSpeed;
    public bool setOffWhen0;
    public bool setOffWhen1;
    private void Start()
    {
        im = GetComponent<Image>();
    }
    private void Update()
    {
        im.color += new Color(0, 0, 0, fadingSpeed) * Time.deltaTime;
        if(setOffWhen0 == true && im.color == new Color(0, 0, 0, 0))
        {
            gameObject.SetActive(false);
        }
        if (setOffWhen1 == true && im.color == new Color(0, 0, 0, 255))
        {
            gameObject.SetActive(false);
        }
    }
}
