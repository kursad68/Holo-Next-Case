using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent OnBoxBarbage = new UnityEvent();
    public static UnityEvent isLevelFailed = new UnityEvent();
    public static UnityEvent isLevelFinish = new UnityEvent();

    public static Action<string, string> onAnimatorAction;
    public static Action<string> onAnimationPlay;
    public static Action<Transform> RockPiece;


    public static Func<GameManager> getGameManager;


}


  
 


