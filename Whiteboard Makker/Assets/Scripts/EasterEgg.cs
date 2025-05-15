using UnityEngine;
using System.Collections;



public class EasterEgg : MonoBehaviour
{
    [Header("Shake Detection Settings")]
    private float shakeDetectionThreshold = 36f; // Thresh
    private bool easterEggActivated = false; // One trick pony
    public GameObject Stickman; // Main obj
    public GameObject TwerkBootyStickman; // Anim obj
    private float twerkingTime = 7f; // 7/10

    void Update() // goes round and round
    {
        DetectShake(); // Check chack
        
        if (Input.GetKeyDown(KeyCode.T)) { // Casually debugging what up?
            if (easterEggActivated) return;
            else TriggerEasterEgg();
        }
    }

    void DetectShake()
    {
        Vector3 acceleration = Input.acceleration; // Get the cabrio
        if (easterEggActivated) return; // Is pony dead?
        else if (acceleration.sqrMagnitude >= shakeDetectionThreshold) TriggerEasterEgg(); // Does thing go wroom?           
    }

    void TriggerEasterEgg() // Shake shak
    {
        AudioManager.Instance.PlaySFX("EasterEgg"); // Go milo!!

        TwerkBootyStickman.transform.position = Stickman.transform.position; // avengers, assemble
        Stickman.SetActive(false); // bye bye baby
        TwerkBootyStickman.SetActive(true); // oh hello there

        StartCoroutine(RevertAfterSeconds(twerkingTime)); // take it home
        easterEggActivated = true; // no more tricks
    }

    private IEnumerator RevertAfterSeconds(float duration)
    {
        yield return new WaitForSeconds(duration); // hol up 
        
        Stickman.transform.position = TwerkBootyStickman.transform.position; // better together
        Stickman.SetActive(true); // back so soon
        TwerkBootyStickman.SetActive(false); // bay city rollers stop playing
    }
}

