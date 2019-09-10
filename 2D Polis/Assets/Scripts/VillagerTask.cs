using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VillagerTask {
    public Queue<VillagerTarget> targets;
    public bool isNecessary;

    public VillagerTarget GetNextTarget() {
        if(targets.Count > 0) {
            return targets.Dequeue();
        } else {
            return null;
        }
    }

    public bool GetIsNecessary() {
        return isNecessary;
    }
}

public class VillagerTarget {
    public Vector2 loc;
    public TileMono targetTile;
    public float duration;
    public bool callWhenReach;
    public bool callWhenDone;
    public float dist;
}
