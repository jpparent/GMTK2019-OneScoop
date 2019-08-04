using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		transform.localScale = Vector3.one;
    }

	private void OnTriggerEnter( Collider other )
	{
		if ( other.CompareTag( "Ball" ) )
		{
			transform.SetParent( other.transform );
		}
	}
}
