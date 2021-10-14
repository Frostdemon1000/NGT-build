using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
 
//Right Click create empty
//Pull in front of character
//Rename GameObject to destination
//Turn off gravity in Rigidbody
//Parent the object with object itself
    
  public Transform theDest; 

  void OnMouseDown()
  {
      GetComponent<Rigidbody>().useGravity = false;
      this.transform.position = theDest.position;
      this.transform.parent = GameObject.Find("Destination").transform;
  }

  void OnMouseUp()
   {
       this.transform.parent = null;
       GetComponent<Rigidbody>().useGravity = true;
   }

}
