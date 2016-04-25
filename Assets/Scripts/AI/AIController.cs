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

	public enum CurrentAI {
		Idle,
		Wander,
		Follow,
		Attack,
		Hide,
		SneakAttack,
		Flee
	}
	public CurrentAI currentAI;
	public enum Aggression {
		Flee,
		Passive,
		Neutral,
		Aggressive
	}
	public Aggression aggression;

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
		agent.stoppingDistance = maxDistance;

		if (currentAI == CurrentAI.Follow) {
			maxDistance = normalDistance;
			MovementCalc (target.transform.position);
		} else if (currentAI == CurrentAI.Hide) {
			if (HideAtSpot () != null) {
				agent.stoppingDistance = 0;
				MovementCalc (HideAtSpot ().transform.position);
			} else {
				currentAI = CurrentAI.Flee;
			}
		}
	}

	void OnAnimatorMove ()
	{
		// Update position to agent position
		Vector3 position = anim.rootPosition;
		position.y = agent.nextPosition.y;
		transform.position = position;
	}

	void MovementCalc(Vector3 targetPos){
		agent.destination = targetPos;
		worldDeltaPosition = agent.nextPosition - transform.position;

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
		Debug.Log(Vector3.Distance(previousPosition,agent.nextPosition));
		if (shouldMove || Vector3.Distance (new Vector3 (transform.position.x, 0, transform.position.z), new Vector3 (targetPos.x, 0, targetPos.z)) > agent.remainingDistance) {
			if (Vector3.Distance (previousPosition, agent.nextPosition) != 0) {
				anim.SetFloat ("Y", 1f, 1f, Time.deltaTime * 10f);
			} else {
				anim.SetFloat ("Y", 0, 1f, Time.deltaTime * 10f);
			}
		} else {
			anim.SetFloat ("Y", 0, 1f, Time.deltaTime * 10f);
		}

		if (Vector3.Distance (new Vector3 (transform.position.x, 0, transform.position.z), new Vector3 (targetPos.x, 0, targetPos.z)) >= runDistance) {
			anim.SetBool ("Sprint", true);
		} else {
			agent.speed = moveSpeed;
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
		} else {
			agent.height = hei
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
				float dist = Vector3.Distance (t.position, currentPos);
				if (dist < minDist) {
					tMin = t;
					minDist = dist;
				}
			}
			return tMin.gameObject;
		} else {
			return null;
		}
	}
}
