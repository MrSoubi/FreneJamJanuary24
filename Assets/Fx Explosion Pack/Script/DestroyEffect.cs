using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

	public GameObject effect1;
	public GameObject effect2;
	public GameObject effect3;

	void Start ()
	{
		effect1.GetComponent<ParticleSystem>().Play();
		effect2.GetComponent<ParticleSystem>().Play();
		effect3.GetComponent<ParticleSystem>().Play();
	}
}
