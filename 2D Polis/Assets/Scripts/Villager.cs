using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    public Jobs curJob;
    public WorkableTile jobTile;
    public string villagerName;
    public VillagerTask curTask;
    public VillagerTarget curTarget;
    public float taskTimer;
    public float moveSpeed;
    public bool atTarget;
    public Services services;

    void Start()
    {
        GetNewTask();
    }


    void Update()
    {
        if(!atTarget) {
            transform.position = Vector2.MoveTowards(transform.position, curTarget.loc, moveSpeed * Time.deltaTime);
            atTarget = (Vector2.Distance(curTarget.loc, transform.position) <= curTarget.dist);
            if(atTarget) {
                GotToTarget();
            }
        } else if(atTarget && taskTimer > 0) {
            taskTimer -= Time.deltaTime;
        } else if(atTarget && taskTimer <= 0) {
            
        }
    }

    public void GetNewTask() {
        if(curJob == Jobs.Citizen) {
            curTask = services.villageService.RequestCitizenTask();
        } else {

        }
        curTarget = curTask.GetNextTarget();
        atTarget = false;
    }

    public void GotToTarget() {
        if(curTarget.callWhenReach && curTarget.targetTile != null) {
            curTarget.targetTile.ReachedTargetLocation();
        }
        taskTimer = curTarget.duration;
    }

    public void DoneAtTarget() {
        if(curTarget.callWhenDone) {
            curTarget.targetTile.DoneAtTargetLocation();
        }
        VillagerTarget nextTarget = curTask.GetNextTarget();
        if(nextTarget != null) {
            curTarget = nextTarget;
            atTarget = false;
        } else {
            GetNewTask();
        }
    }
}
