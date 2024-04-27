using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Events { ready, active, cooldown }

public class EventHandler : MonoBehaviour
{
    private Events currentEvent = Events.ready;

    [SerializeField] bool[] applyTimerToEvents = new bool[3];
    [SerializeField] float[] eventTimers = new float[3];
    [SerializeField] Events[] eventAfterTimer = new Events[3];

    // All scripts and behaviours for each event will be passed here
    [SerializeField] UnityEvent ready, active, cooldown;

    private float elapsedTime = 0;

    private Dictionary<Events, UnityEvent> events = new Dictionary<Events, UnityEvent>();

    private void Awake()
    {
        events.Add(Events.ready, ready);
        events.Add(Events.active, active);
        events.Add(Events.cooldown, cooldown);
    }

    private void FixedUpdate()
    {
        int _currentEvent = (int)currentEvent;

        events[currentEvent]?.Invoke();

        if (applyTimerToEvents[_currentEvent])
        {
            Timer(eventTimers[_currentEvent], eventAfterTimer[_currentEvent]);
        }
    }

    private void Timer(float time, Events nextEvent)
    {
        elapsedTime += Time.fixedDeltaTime;
        if (elapsedTime >= time)
        {
            elapsedTime = 0;
            SetEvent(nextEvent);
        }
    }   

    public void SetEvent(Events newEvent)
    {
        currentEvent = newEvent;

        elapsedTime = 0;
    }

    public void SubscribeTo(Events _event, UnityAction listener)
    {
        events[_event].AddListener(listener);
    }

    public void UnsubscribeFrom(Events _event, UnityAction listener)
    {
        events[_event].RemoveListener(listener);
    }
}
