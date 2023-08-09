using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{

    public AudioClip seekingAudioClip;
    public AudioClip pointGetAudioClip;
    public Transform player;
    private float timerDuration = 0.1f;
    private float timer;
    private int collectedCount = 0;
    private UnityEngine.Vector3 RandomNewPosition;


    //-Text Elements-
    //public TextMeshProUGUI uiText;
    public TextMeshPro scoreText;


    // Start is called before the first frame update
    void Start()
    {
        //audiocontrol = GetComponent<AudioSource>();
        //audiocontrol.loop = true;
        timer = timerDuration;
        scoreText.text = "Collected:\n0";
        


    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            AudioSource.PlayClipAtPoint(seekingAudioClip, transform.position);
            timer = timerDuration + (Mathf.Abs((transform.position - player.position).magnitude) * 0.04f);
            Debug.Log("Max dur: " + timer);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
            RandomNewPosition = new UnityEngine.Vector3(Random.Range(-9.0f,9.0f), Random.Range(-9.0f, 9.0f), 0.0f);
        {
            //Debug.Log("HIT!");
            //Debug.Log(coll.gameObject.transform.position);
            transform.SetPositionAndRotation((RandomNewPosition), transform.rotation);
            AudioSource.PlayClipAtPoint(pointGetAudioClip, transform.position);
            collectedCount += 1;
            scoreText.text = "Collected:\n" + collectedCount;
        }
    }
    
}
