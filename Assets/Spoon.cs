using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		// update position to where mouse is
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		RaycastHit hitInfo;
		if (Physics.Raycast(ray, out hitInfo ) )
		{
			if (hitInfo.transform != transform )
			{
				transform.position = hitInfo.point;
			}
		}
    }
}
