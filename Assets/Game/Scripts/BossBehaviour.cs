using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] private float stoppingDistance;
    [SerializeField] private IntEventChannelSO onBossReachedPlayer;
    [SerializeField] private Animator animator;

    private bool playerFinished;
    private bool playerWon;
    private Vector3 playerPosition;
    private bool reachedEventSent;
    private void Update()
    {
        if (playerFinished)
        {
            FightPlayer();
        }
    }

    private void FightPlayer()
    {
       
        if (Vector3.Distance(transform.position, playerPosition) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * 10);   
        }
        else if(playerWon && !reachedEventSent)
        {
            onBossReachedPlayer.RaiseEvent(1);
            animator.SetBool("Fighting", true);
            animator.SetBool("Lost", true);
            Destroy(gameObject,1.5f);
            reachedEventSent = true;
        }
        else if(!reachedEventSent)
        {
            onBossReachedPlayer.RaiseEvent(0);
            animator.SetBool("Fighting", true);
            //win animation
            reachedEventSent = true;
        }
    }

    public void OnPlayerArrived(bool playerHasMoreIQ, Vector3 positionPlayer)
    {
        playerWon = playerHasMoreIQ;
        playerFinished = true;
        playerPosition = positionPlayer;
    }
}
