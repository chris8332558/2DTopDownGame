using UnityEngine.Events;

public static class GamePlayEvents
{
    static public UnityEvent EnemyDie = new UnityEvent(); 
    static public UnityEvent PlayerLevelUp = new UnityEvent();
    static public UnityEvent<float> PlayerAddExp = new UnityEvent<float>();
}
