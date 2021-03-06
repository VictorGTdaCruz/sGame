﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDisc : MonoBehaviour {

    public float nonAggroSpeed,
                 aggroSpeed,
                 aggroRadius,
                 step,
                 shootSpeed,
                 distance;
    private float timeCounter,
                  angle;
    private GameObject player;
    private bool aggro;

	// Use this for initialization
	void Start () {
        aggro = false;
        angle = 0;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (!aggro )
        {
            FollowPlayer();
            CheckAggro();
        }
        else
        {
            CircleAroundPlayer();
            //Shoot();
        }
	}

    void FollowPlayer()
    {
        step = nonAggroSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }

    void CheckAggro()
    {
        float currentDistance = Mathf.Sqrt(Mathf.Pow((transform.position.x - player.transform.position.x), 2) +
                                           Mathf.Pow((transform.position.y - player.transform.position.y), 2) +
                                           Mathf.Pow((transform.position.z - player.transform.position.z), 2));
            
        if(Mathf.Abs(currentDistance) <= distance)
        {
            aggro = true;
        }
        else
        {
            aggro = false;
        }
    }

    void CircleAroundPlayer()
    {
        // timeCounter += Time.deltaTime;
        // float x = Mathf.Cos(timeCounter) * aggroRadius;
        //float y = Mathf.Sin(timeCounter) * aggroRadius;
        //float z = Mathf.Cos(timeCounter) * aggroRadius;
        // transform.position = new Vector3(player.transform.position.x + x,
        //                                player.transform.position.y,
        //                                player.transform.position.z + z); 

        angle += aggroSpeed * Time.deltaTime;

        Vector3 offset = new Vector3(Mathf.Sin(angle), 0,Mathf.Cos(angle)) * aggroRadius;
        transform.position = player.transform.position + offset;
    }

    void Shoot()
    {

    }
}
