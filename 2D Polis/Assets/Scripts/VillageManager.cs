using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public VillagerTask RequestCitizenTask() {
        VillagerTarget target1 = new VillagerTarget {
            loc = new Vector2(10, 10),
            duration = 3f,
            callWhenReach = false,
            callWhenDone = false,
            dist = .33f
        };
        VillagerTarget target2 = new VillagerTarget {
            loc = new Vector2(0, 0),
            duration = 1f,
            callWhenReach = false,
            callWhenDone = false,
            dist = .33f
        };
        Queue<VillagerTarget> q = new Queue<VillagerTarget>();
        q.Enqueue(target1);
        q.Enqueue(target2);
        return new VillagerTask { targets = q, isNecessary = false };
    }
}
