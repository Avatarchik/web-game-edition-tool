#pragma strict

/*var distance_to_screen : float;
var pos_move : Vector3;

//This function move the object when we drag it with the mouse
function OnMouseDrag()
{
	//get the original distance between the camera and the object
	distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.localPosition).z;
	//transform mouse's position to 3D position in the scene
	pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
	//set the new position of the object
	transform.localPosition = new Vector3(pos_move.x, pos_move.y, pos_move.z);
}

//This function transform the scale of the object according to the position of the mouse scroll wheel
function Update()
{
    transform.localScale.x+=Input.GetAxis("Mouse ScrollWheel")* Time.deltaTime*20;
    if (transform.localScale.x < 15.0) {
    	transform.localScale.x = 15.0;
    } else if (transform.localScale.x > 60.0) {
    	transform.localScale.x = 60.0;
    }
    transform.localScale.y=transform.localScale.z=transform.localScale.x;
}

function Start () {

}*/
