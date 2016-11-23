using UnityEngine;
using System.Collections;

public class EnemyIA : MonoBehaviour {

	public Transform target;
	public float moveSpeed = 3;
	public float rotationSpeed = 3;
	public float distance = 5f;
	public bool Enabled = false;
	public bool Detect = false;
	private Transform myTransform;


	void Awake()
	{
		myTransform = this.GetComponent<Transform>();
	}


	void Start()
	{
		target = GameObject.FindWithTag("Player").transform;
	}


	void Update()
	{
		if (Enabled)
		{
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
			RaycastHit info;
			Debug.DrawRay(transform.position, transform.forward * distance, Color.red, 0.1f);
			if (Physics.Raycast(transform.position, transform.forward, out info, distance))
			{
				if (info.collider.tag == "Player")
				{
					Detect = true;
				}
				else
				{
					Detect = false;
				}
			}
			else
			{
				Detect = false;
			}
		}
		if (Enabled && Detect)
		{
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Enabled = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			Enabled = false;
		}
	}
}
