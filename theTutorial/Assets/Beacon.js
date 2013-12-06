#pragma strict

var cube : GameObject;

function Start () {

} 

function Update () {

 

if(Input.GetButtonDown("Fire2"))

{

    print("new");

    Instantiate(cube,transform.position,transform.rotation);

}

}