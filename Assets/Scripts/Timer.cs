using UnityEditor.Rendering;
using UnityEngine;

// Timer class that counts down from a given time
// Don't know how to make it function similarly to Godot's Timer class signals
public class Timer : MonoBehaviour
{
    public float timer = 5.0f;

    private bool timer_started = false;

    private void Update() {
        if (timer_started)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            TimerEnded();
            timer = 0;
        }
    }

    public void StartTimer(float time)
    {
        timer_started = true;
        time = timer;
    }

    void TimerEnded()
    {
        
        Debug.Log("Timer ended");
    }
}
