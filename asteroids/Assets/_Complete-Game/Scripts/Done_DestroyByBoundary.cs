using UnityEngine;
using System.Collections;

public class Done_DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit (Collider other) 
	{
		if(other.tag=="Boundary")
		{
			//pass
		}
		else
		{
			Destroy(other.gameObject);
		}
	}
}