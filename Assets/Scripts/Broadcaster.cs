using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broadcaster : MonoBehaviour {
    public void Broadcast(String name, Boolean value)
    {
        BroadcastMessage(name,value);
    }
}
