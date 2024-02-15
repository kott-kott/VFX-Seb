using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Burst : MonoBehaviour
{
    public GameObject telegraph;
    public ParticleSystem spellParticles;

    public Ray ray;
    public RaycastHit hit;
    public Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    
    void Update()
    {
        OnOffTelegraph();
    }


    void OnOffTelegraph()
    {
        if (Input.GetKey(KeyCode.E))
        {
            telegraph.SetActive(true); //activate GameObject
            FollowMouse();
        }
        
        if (Input.GetKeyUp(KeyCode.E))
        {
            telegraph.SetActive(false); //desactiver le game objet quand la touche et relevée 

            spellParticles.Play();
        }
    }

    void FollowMouse()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            transform.position = new Vector3(hit.point.x, startPos.y, hit.point.z);
            Debug.Log("hello");
        }
    }
}
