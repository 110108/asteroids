using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;

	private Rigidbody rb;

	void start ()
	{
		rb=(GetComponent<Rigidbody>());
//		rb.rotation = Quaternion.identity;
//		rb.velocity = (rb.rotation) * speed;
	//	Vector3 v3 = new Vector3(Input.GetAxis("Horizontal"),0.0f,Input.GetAxis("Vertical"));
		rb.velocity=(speed * (transform.TransformDirection(Vector3.forward)));
	}
}