using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    
        private string[] isCheckedValue ={
        "isOpening",
        "isLiftClosing",
        "IsLoading"
    };
    Animator _liftAdmin;
    Animator _doorAdmin;
    public GameObject LiftAutomationGroup;
    public AnimateDoor animateDoor;
    public GameObject Door;
    public AudioSource soundFX;



    // Start is called before the first frame update
    void Start()
    {
        _liftAdmin = LiftAutomationGroup.GetComponent<Animator>(); 
        _doorAdmin = Door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Validation (string Loop=null){  
        
        for (int i = 0; i < isCheckedValue.Length; i++)
        {            
            if (_liftAdmin.GetBool (isCheckedValue[i])){
            Loop = Loop + $"===> Bool {isCheckedValue[i]} is True |";
            } else {
                Loop = Loop + $"===> Bool {isCheckedValue[i]} is False |";
            }
        }        
        Debug.Log ($"===> Final  {Loop}");        
    }

    private void OnTriggerEnter(Collider other) {

         Debug.Log ($"Lift - OnTrigger Door Testing. Enter object tag ---{other.tag} | Accessing {other.name} | collided with {other.gameObject.name}. ");
         Validation("Lift OnTrigger");
         if (other.tag==("Player")){
             //if (_liftAdmin.GetBool("IsLoading") == true) {StartCoroutine (OpenLift ()); 
             StartCoroutine (OpenLift ());
             

            Debug.Log("OnTrigger Lift rising");
        }   
        
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag==("Player")){
        Debug.Log("Outside Lift Trigger");
        
        }

    }
        
    IEnumerator OpenLift(){
        //_atliftRamp = true;        
        //_liftAdmin.Play("LiftRampLeave"); 
        _liftAdmin.SetBool ("IsLoading",true);
        if (soundFX) soundFX.Play();
        yield return new WaitForSeconds(3);
        if(soundFX) soundFX.Stop();
    }
 
}
