using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixieScript : MonoBehaviour
{
	public const int PIXIE_FIRE_COOLDOWN = 75;

	[SerializeField] private Vector3 pixieOffsetFromPlayer = new Vector3(0, 0, 0);
	[SerializeField] private GameObject pixieBody = null;
	private GameObject player;

	private Vector3 bodyPos = new Vector3(0, 0, 0);
	private Vector3 pixieThrowVel = new Vector3(0, 0, 0);
	private bool beingThrown = false;
	private bool movingBackToPlayer = false;

	private float t = 0;
	private int fireCooldown = PIXIE_FIRE_COOLDOWN;

    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		pixieBody.transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));
    }
	
    void FixedUpdate()
	{
		if (fireCooldown > 0) fireCooldown--;
		else
		{
			if((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.F)) && !beingThrown)
			{
				beingThrown = true;
				pixieThrowVel = new Vector3(0.05f, 0, 0.5f);
				bodyPos = new Vector3(0, 0, 0);
				movingBackToPlayer = false;
				fireCooldown = PIXIE_FIRE_COOLDOWN;
			}
		}

		t += 0.075f;

		const float SLOWDOWN_SPEED = .05f;
		const float MOVE_BACK_TO_PLAYER_DIST = 8f;

		if (!beingThrown)
			bodyPos = new Vector3(0, Mathf.Cos(t) * .25f, Mathf.Sin(t));
		else if(!movingBackToPlayer)
		{
			Vector3 slowdown = -bodyPos.normalized;

			//circular is perp to direction of movement (to make it go in a circular path)
			Vector3 circular = Vector3.Cross(-bodyPos, new Vector3(0, 1, 0)).normalized;
			//bias circular toward the player
			pixieThrowVel += (circular + slowdown * 0.3f) * SLOWDOWN_SPEED;
			
			if(bodyPos.magnitude > MOVE_BACK_TO_PLAYER_DIST)
			{
				movingBackToPlayer = true;
			}

			bodyPos += pixieThrowVel;
		}
		else //move back to player
		{


			Vector3 slowdown = -bodyPos.normalized;
			pixieThrowVel += slowdown * SLOWDOWN_SPEED - pixieThrowVel * 0.025f;
			
			if(bodyPos.magnitude < 0.25f)
			{
				beingThrown = false;
				movingBackToPlayer = false;
				bodyPos = new Vector3(0, Mathf.Cos(t) * .25f, Mathf.Sin(t));
				pixieThrowVel = new Vector3(0, 0, 0);
			}

			bodyPos += pixieThrowVel;
		}
	}

	void Update()
	{
		transform.position = player.transform.position + pixieOffsetFromPlayer;
		pixieBody.transform.position = transform.position + bodyPos;
	}

}
