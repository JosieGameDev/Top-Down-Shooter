using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="GameEvent", menuName="Create GameEvent")]
public class GameEvent : ScriptableObject
{
    List<GameEventListener> eventListeners = new List<GameEventListener>();

	public void Raise()
    {
        for (int i = 0; i < eventListeners.Count; i++)
            eventListeners[i].OnEventRaised();
    }

    public void AddListener(GameEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void RemoveListener(GameEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}


