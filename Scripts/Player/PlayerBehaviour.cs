using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rigidBody;                  //Variable storing the rigidbody component of the player asset
    public Camera mainCamera;
    private float ForceModifier = 1.0f;
    private Vector2 ForceConstraints = new Vector2(30.0f,30.0f);
    public AudioClip deathSound;

    IEnumerator DoDeath()
    {
        // freezes the player, plays death animation & sound, then resets the scene after short delay.
        rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        AudioSource.PlayClipAtPoint(deathSound,transform.position);
        

        yield return new WaitForSeconds(0.75f);// reload the level in 2 seconds
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //float horizInput = Input.GetAxis("Horizontal"); // -1, 0, or 1 depending on user input
        //float vertInput = Input.GetAxis("Vertical"); // -1, 0, or 1 depending on user input
        Vector2 MovementForce = (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * ForceModifier);

        
        rigidBody.AddForce((MovementForce), ForceMode2D.Force);



        //rigidBody.SetRotation(Vector2.Angle(mousePos,transform.position));
        //Debug.Log("transform: " + transform.position + "mouse:" + mousePos + ", Diff:" + Vector2.Angle(transform.position, mousePos));



    }
    // FixedUpdate updated once every physics collision check or something similar.
    private void FixedUpdate()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.rigidbody.tag == "Death")
    //    {
    //        StartCoroutine(DoDeath());//kill player
    //    }
    //}
}
