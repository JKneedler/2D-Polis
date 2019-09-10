using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    public int startingVillagers;
    public GameObject villagerPrefab;
    public List<GameObject> villagers;
    public Services services;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0 ; i < startingVillagers; i++) {
            GameObject vill = (GameObject)Instantiate(villagerPrefab, new Vector3(0, 0, 0), villagerPrefab.transform.rotation);
            vill.GetComponent<Villager>().services = services;
            villagers.Add(vill);
        }
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
