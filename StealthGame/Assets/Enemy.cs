using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.AI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public NavMesh agent;

   public Transform player;

   public LayerMask whatIsGround, whatIsPlayer;
   
   // Patrolling
   public Vector3 walkpoint;
   private bool walkPointSet;
   public float walkPointRange;

   //Attacking 
   public float timeBetweenAttacks;
   private bool alreadyAttacked;

   //states

   public float sightRange, attackRange;
   public bool playerInSightRange, playerInAttackRange;

   private void Awake()
   {
      player = GameObject.FindWithTag("Player").transform;
      agent = GetComponent<NavMeshAgent>();
      
   }

   private void Update()
   {
      playerInSightRange = Physics.CheckCapsule(transform.position, sightRange, whatIsPlayer);
      playerInAttackRange = Physics.CheckCapsule(transform.position, attackRange, whatIsPlayer);
   }
}
