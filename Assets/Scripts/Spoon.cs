using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoon : MonoBehaviour
{
	public LayerMask hitLayers;

	public float hoverHeight = 1.8f;

	bool isScooping = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if ( Input.GetMouseButtonDown( 0 ) ){
			isScooping = true;
		}

		if ( Input.GetMouseButtonUp( 0 ) )
		{
			isScooping = false;
		}

		// update position to where mouse is
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
		RaycastHit hitInfo;
		if ( Physics.Raycast( ray, out hitInfo, Mathf.Infinity, hitLayers ) )
		{
			Cursor.visible = false;
			transform.position = new Vector3(hitInfo.point.x, isScooping ? hitInfo.point.y : hoverHeight, hitInfo.point.z);
		}
		else
		{
			Cursor.visible = true;
		}
    }
}
