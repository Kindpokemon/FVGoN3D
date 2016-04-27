using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
public class AIController : MonoBehaviour {

	public string npcName;
	public string displayName;
	public float moveSpeed = 3.5f;

	Quaternion targetRotation;
	ReferenceList reflist;
	NavMeshAgent agent;
	Vector2 smoothDeltaPosition = Vector2.zero;
	Vector3 worldDeltaPosition;
	Vector2 velocity = Vector2.zero;
	Vector3 previousPosition;
	Animator anim;

	float distance;
	float maxDistance;
	public float normalDistance;
	public float runDistance;
	public float fleeDistance;
	public float runMult;
	public float crouchMult;

	public float normalHeight;
	public float crouchHeight;

	public GameObject target;
	public CapsuleCollider hideFinder;

	public bool shouldMove;
	public bool shouldCrouch;

	RaycastHit hit;

	public enum CurrentAI {
		Idle,
		Wander,
		Follow,
		Attack,
		Hide,
		SneakAttack,
		Flee,
		ShieldWall
	}
	public CurrentAI currentAI;
	public enum Aggression {
		Flee,
		Passive,
		Neutral,
		Aggressive
	}
	public Aggression aggression;
	public enum AttackStyle {
		None,
		Charge,
		Sneak,
		Block
	}
	public AttackStyle attackStyle;
	public enum DeathType{
		Die,
		Kneel,
		Invincible,
		Explode
	}
	public DeathType deathType;

	void Start ()
	{
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		reflist = GameObject.FindGameObjectWithTag ("reflist").GetComponent<ReferenceList>();
		// Don’t update position automatically
		agent.updatePosition = false;
		anim.applyRootMotion = false;
	}

	void Update ()
	{
		GetComponent<CapsuleCollider> ().center = new Vector3(GetComponent<CapsuleCollider> ().center.x,GetComponent<CapsuleCollider> ().height/2,GetComponent<CapsuleCollider> ().center.z);
		if (!Physics.Raycast (transform.position, Vector3.up, normalHeight, 8)) {
			if (target != null) {
				if (target.tag == "Player") {
					if (target.GetComponent<PlayerControl> ().anim.GetBool ("Crouching")) {
						if (target.GetComponent<PlayerControl> ().moving && target.GetComponent<PlayerControl> ().anim.GetBool ("Sprinting")) {
							shouldCrouch = false;
						} else {
							shouldCrouch = true;
						}
					} else {
						shouldCrouch = false;
					}
				} else if (target.tag == "NPC") {
					if (target.GetComponent<AIController> ().anim.GetBool ("Crouch")) {
						shouldCrouch = true;
					} else {
						shouldCrouch = false;
					}
				} else {
					shouldCrouch = false;
				}
			}
		}
		agent.stoppingDistance = maxDistance;
		if (currentAI == CurrentAI.Follow) {
			maxDistance = normalDistance;
			MovementCalc (target.transform.position, shouldCrouch);
		} else if (currentAI == CurrentAI.Hide) {
			if (HideAtSpot () != null) {
				agent.stoppingDistance = 0;
				if (HideAtSpot ().GetComponent<HidingSpotInfo> ().hideHeight < normalHeight) {
					MovementCalc (HideAtSpot ().transform.position, true);
				} else {
					MovementCalc (HideAtSpot ().transform.position, false);
				}
			} else {
				currentAI = CurrentAI.Flee;
			}
		} else if (currentAI == CurrentAI.Idle) {
			
		}
	}

	void OnAnimatorMove ()
	{
		// Update position to agent position
		Vector3 position = anim.rootPosition;
		position.y = agent.nextPosition.y;
		transform.position = position;
	}

	void MovementCalc(Vector3 targetPos, bool crouch){

		agent.destination = targetPos;
		worldDeltaPosition = agent.nextPosition - transform.position;
		if (crouch) {
			anim.SetBool ("Crouch", true);
		} else {
			anim.SetBool ("Crouch", false);
		}

		if (Vector3.Distance (new Vector3 (transform.position.x, 0, transform.position.z), new Vector3 (targetPos.x, 0, targetPos.z)) >= runDistance && !anim.GetBool("Crouch")) {
			anim.SetBool ("Sprint", true);
		} else {
			anim.SetBool ("Sprint", false);
		}

		if (anim.GetBool ("Sprint") == true) {
			agent.speed = moveSpeed * runMult;
		} else if (anim.GetBool ("Crouch") == true) {
			agent.speed = moveSpeed * crouchMult;
		} else {
			agent.speed = moveSpeed;
		}

		if (anim.GetBool ("Crouch") == true) {
			agent.height = crouchHeight;
			GetComponent<CapsuleCollider> ().height = crouchHeight;
		} else {
			agent.height = normalHeight;
			GetComponent<CapsuleCollider> ().height = normalHeight;
		}

		// Map 'worldDeltaPosition' to local space
		float dx = Vector3.Dot (transform.right, worldDeltaPosition);
		float dy = Vector3.Dot (transform.forward, worldDeltaPosition);
		Vector2 deltaPosition = new Vector2 (dx, dy);

		// Low-pass filter the deltaMove
		float smooth = Mathf.Min (1.0f, Time.deltaTime / 0.15f);
		smoothDeltaPosition = Vector2.Lerp (smoothDeltaPosition, deltaPosition, smooth);

		// Update velocity if time advances
		if (Time.deltaTime > 1e-5f)
			velocity = smoothDeltaPosition / Time.deltaTime;

		shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius && agent.remainingDistance > agent.stoppingDistance;
		// Update animation parameters
		if (shouldMove || Vector3.Distance (new Vector3 (transform.position.x, 0, transform.position.z), new Vector3 (targetPos.x, 0, targetPos.z)) > agent.remainingDistance) {
			if (Vector3.Distance (previousPosition, agent.nextPosition) != 0) {
				anim.SetFloat ("Y", 1f, 1f, Time.deltaTime * 10f);
			} else {
				anim.SetFloat ("Y", 0, 1f, Time.deltaTime * 10f);
			}
		} else {
			anim.SetFloat ("Y", 0, 1f, Time.deltaTime * 10f);
		}

		if (worldDeltaPosition.magnitude > agent.radius) {
			transform.position = agent.nextPosition - .9f * worldDeltaPosition;
		}
		previousPosition = agent.nextPosition;
	}

	GameObject HideAtSpot(){
		if (reflist.hidingSpots.Count > 0) {
			Transform tMin = null;
			float minDist = Mathf.Infinity;
			Vector3 currentPos = transform.position;
			foreach (Transform t in reflist.hidingSpots) {
				if (t.GetComponent<HidingSpotInfo> ().hideHeight >= crouchHeight || t.GetComponent<HidingSpotInfo> ().hideHeight >= normalHeight) {
					float dist = Vector3.Distance (t.position, currentPos);
					if (dist < minDist) {
						tMin = t;
						minDist = dist;
					}
				}
			}
			return tMin.gameObject;
		} else {
			return null;
		}
	}
}
