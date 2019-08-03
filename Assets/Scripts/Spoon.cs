using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoon : MonoBehaviour
{
	public GameObject ball;
	public LayerMask hitLayers;
	public float hoverHeight = 1.8f;
	public float growthRate = 1.1f;

	private bool isScooping = false;
	private Vector3 lastPosition;

	[SerializeField]
	private float turnSpeed = 1.5f;
	[SerializeField]
	private float rotationMargin = 1f;

	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if ( Input.GetMouseButtonDown( 0 ) ){
			isScooping = true;

			ball.SetActive( true );
		}

		if ( Input.GetMouseButtonUp( 0 ) )
		{
			ball.transform.localScale = Vector3.one;
			ball.SetActive( false );

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

		if ( isScooping )
		{
			float positionDelta = Vector3.Distance( transform.position, lastPosition );
			ball.transform.localScale = ball.transform.localScale * ( 1 + (growthRate * positionDelta * Time.deltaTime));
		}

		RotateTowards( lastPosition );

		lastPosition = transform.position;
    }

	public void RotateTowards( Vector3 position )
	{
		Vector3 facing = position - transform.position;
		if ( facing.magnitude < rotationMargin )
		{
			return;
		}

		transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.LookRotation( facing ), turnSpeed * Time.deltaTime );
		transform.eulerAngles = new Vector3( 0, transform.eulerAngles.y, 0 );
	}
}
