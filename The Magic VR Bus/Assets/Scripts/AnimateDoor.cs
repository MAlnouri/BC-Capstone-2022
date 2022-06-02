using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDoor : MonoBehaviour
{
    
    #region Variables
    Animator _doorAdmin;
    public GameObject LiftAutomationGroup;
    Animator _liftAdmin;
    private Transform target;
    
    private string[] isCheckedValue ={
        "isOpening",
        "isLiftClosing",
        "IsLoading"
    };

    public bool isDebug = false;
    private bool _atliftRamp;
    private bool _isLiftTimerStarted = false;
    private int counter;
    private string isOpen;    
    private bool isOpening = false;
    private bool isClosing = false;       
    public AudioSource soundFX;
    
    #endregion  
    void Start()
    {
      _doorAdmin = this.transform.parent.GetComponent<Animator>();
      _liftAdmin = LiftAutomationGroup.GetComponent<Animator>();      
       if (isDebug) Debug.Log(" Just starting");
      target = GameObject.FindWithTag("Player").transform; 
      Validation ("Start");  
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
        
        if (isDebug) Debug.Log ($"OnTrigger Door Testing. Enter object tag ---{other.tag} | Accessing {other.name}. | collided with {other.gameObject.name}. ");        
        if (other.tag==("Player")){
            _atliftRamp = true;
            if (soundFX) soundFX.Play();
            _doorAdmin.SetBool ("isOpening", true);
            StartCoroutine (OpenLift ());
            if (isDebug) Debug.Log("OnTrigger Door Opening");
        }   
        if (isDebug)  Validation ("OnTriggerEnter"); 
    }
    
     private void OnTriggerExit(Collider other) {
        if (isDebug) Debug.Log ($"ontrigger Exit object tag ---{other.tag}");
         if (other.tag==("Player") && _atliftRamp){
            //_liftAdmin.SetBool ("isLiftClosing",true);
            if (isOpening==false) StartCoroutine (CloseDoor ());
            if (isDebug) Debug.Log("OnTrigger Door CLosing");
            _atliftRamp = false;
         }
        if (isDebug) Validation ("OnTriggerExit");  
         if (_liftAdmin.GetBool("isLiftClosing")==false) 
         {if (isDebug) Debug.Log("====++++>>>>Exit - It is false"); 
         }
         else  {
             if (isDebug)  Debug.Log("====++++>>>>Exit - It is true");            
         
         }

    }

    IEnumerator CloseDoor()
    {
        if (isDebug) Debug.Log($"CloseDoor - Started Coroutine at timestamp : {Time.time}.");

        //yield on a new YieldInstruction that waits for 3 seconds.
        if (soundFX) soundFX.Play();
        _liftAdmin.SetBool("isOpening", false);
        _liftAdmin.SetBool("IsLoading", false);
        //yield return new WaitForSeconds(3);

        _liftAdmin.SetBool("isLiftClosing", true);
        yield return new WaitForSeconds(3);
        _doorAdmin.SetBool("isOpening", false);
        _liftAdmin.SetBool("isLiftClosing", false);
        //After we have waited 5 seconds print the time again.
        if (_liftAdmin.GetBool("isLiftClosing") == true)
        {
            isOpen = "true";
        }
        else
        {
            isOpen = "false";
            //_liftAdmin.SetBool ("isLiftClosing",true);
        }
        if (isDebug) Debug.Log($"CloseDoor - Finished Coroutine at timestamp : {Time.time} and ramp closing is {isOpen}");
        
        if (soundFX) soundFX.Stop();

    }
    IEnumerator OpenLift (){
        if (isDebug) Debug.Log($"OpenLift - Started Coroutine at timestamp : {Time.time}.");       

        //yield on a new YieldInstruction that waits for 3 seconds.
        if (isOpening==false){
             isOpening = true;
             yield return new WaitForSeconds(3);
             _liftAdmin.Play("LiftRampOpening");            
            StartCoroutine (waitForAnimation());
            //Debug.Log ($"OpenLift - Here is the outout => {anim.length + anim.normalizedTime} for Layer {_liftAdmin.GetLayerIndex("Lift Layer")}.");
            yield return new WaitForSeconds(4);
            Debug.Log ("Done with this");
            if (soundFX) soundFX.Stop();
            isOpening = false;
        }
        //After we have waited 5 seconds print the time again.
       if (isDebug)  Debug.Log("OpenLift - Finished Coroutine at timestamp : " + Time.time);           
        
    }

    bool isPlaying(Animator anim, string stateName)
{
    if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        return true;
    else
        return false;
}

    private IEnumerator waitForAnimation()
    {
        while (isPlaying(_liftAdmin,"LiftRampOpening"))
            yield return null;

        Debug.Log ("Animation is done!");
    }

     // Update is called once per frame
    void Update()
    {
        if (_atliftRamp == true)
        {
            
        //     if (_doorAdmin != null)
        //     {
        //         _doorAdmin.Play("Base Layer.OpenRampDoor");
        //         this.isOpening=_doorAdmin.GetBool("isOpening");
        //     }
         }
    }

    #region filter
        //     public void ToggleDoor()
    // {
    //     if (isOpen)
    //         CloseDoor();
    //     else
    //         OpenDoor();
    // }


    //     public void OpenDoor()
    // {
    //     StopDoorAnims();
    //     isOpening = true;
    //     // _doorAdmin.SetBool("isOpening", true);

    //     // _doorAdmin.Play ("");

    //     // if (!isBackwards)
    //     //     StartCoroutine("ForwardDoor2");
    //     // else
    //     //     StartCoroutine("ReverseDoor2");

    //     // if (openSound != null)
    //     //     audioSource.PlayOneShot(openSound);
    //     isOpen = true;
    // }


    //     public void CloseDoor()
    // {
    //     // StopDoorAnims();
    //     // playedCloseSound = false;
    //     // isClosing = true;

    //     // if (!isBackwards)
    //     //     StartCoroutine("ReverseDoor2");
    //     // else
    //     //     StartCoroutine("ForwardDoor2");

    //     isOpen = false;
    // }

    // public void StopDoorAnims()
    // {
    //     // StopCoroutine("ForwardDoor2");
    //     // StopCoroutine("ReverseDoor2");
    // }
    
    #endregion
    
}
