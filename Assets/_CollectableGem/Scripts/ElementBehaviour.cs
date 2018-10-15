using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementBehaviour : MonoBehaviour
{
	[Header("References")]
	public GameObject gemVisuals;
	public GameObject collectedParticleSystem;
	//public CircleCollider2D gemCollider2D;
    public SphereCollider gemCollider3D;

    private float durationOfCollectedParticleSystem;

    void Start()
    {
        durationOfCollectedParticleSystem = collectedParticleSystem.GetComponent<ParticleSystem>().main.duration;
    } //end OnEnable

 //   void OnEnable()
	//{
	//	durationOfCollectedParticleSystem = collectedParticleSystem.GetComponent<ParticleSystem>().main.duration;
	//} //end OnEnable

	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Player")) {
            //col.gameObject.GetComponent<>
            ElementCollected ();

		}

	} //end OnTriggerEnter

	void ElementCollected()
	{
		gemCollider3D.enabled = false;
		gemVisuals.SetActive (false);
		collectedParticleSystem.SetActive (true);
		Invoke ("DeactivateElement", durationOfCollectedParticleSystem);
	} //end ElementCollected

	void DeactivateElement()
	{
        //if (gameObject.tag == "Pickup")
        //{
        //    gameObject.SetActive (false);
        //}
        //else
        //{
            Destroy(gameObject);
        //}
    } //end DeactivateElement
} //end ElementBehavior class
