using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruits : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] PanelContlloler platecontllol;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        platecontllol = player.GetComponent<PanelContlloler>();
        rb = transform.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        platecontllol.set(this);    
    }
    public void fall()
    {
        rb.useGravity = true;
        transform.parent = null;
        rb.constraints = RigidbodyConstraints.None;
    }
}
