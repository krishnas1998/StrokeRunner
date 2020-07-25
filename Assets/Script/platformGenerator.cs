using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformGenerator : MonoBehaviour {

	//for the genreration of the platforms 
	public GameObject thePlatform;
	public Transform generationPoint;

	//for the random spacing between the platforms
	public float distanceBetween;
	public float distanceBetweenMin;
	public float distanceBetweenMax;


	//for the height of the platforms 
	private float minHeight;
	private float maxHeight;
	public Transform maxHeightPoint;
	public float maxHeightChange;
	private float heightChange;


	//public GameObject[] thePlatforms;

	public objectPooler[] theObjectPools;
	private float[] platformWidths; 
	private int platformSelector;

	public float randomSpikeThreshold;
	public objectPooler spikePool;
	// Use this for initialization
	void Start () {
		platformWidths = new float[theObjectPools.Length];
		for (int i = 0; i < theObjectPools.Length; ++i) {
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.transform.position.x) {

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
			platformSelector = Random.Range (0,theObjectPools.Length);
			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} 
			else if (heightChange < minHeight) {
				heightChange = minHeight;
			}
			transform.position = new Vector3 (transform.position.x + distanceBetween + (platformWidths[platformSelector])/2, heightChange, transform.position.z);

			//Instantiate (thePlatforms[platformSelector], transform.position, transform.rotation);	

			GameObject newPlatform = theObjectPools[platformSelector].getPooledObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			if(Random.Range(0f,100f) < randomSpikeThreshold)
			{
				GameObject newSpike = spikePool.getPooledObject ();

				float spikeXPosition = Random.Range(-platformWidths[platformSelector]/2+5f,platformWidths[platformSelector]/2);
				 
				Vector3 spikePosition = new Vector3 (spikeXPosition, 0.5f, 0f);

				newSpike.transform.position = transform.position + spikePosition;
				newSpike.transform.rotation = transform.rotation;
				newSpike.SetActive (true);
			}

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector])/2, transform.position.y, transform.position.z);
			}
	}
}
