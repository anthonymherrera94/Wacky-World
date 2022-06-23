using UnityEngine;
using PlayerManagement;
using Movement;

public class ShakeGround : MonoBehaviour
{
    //TODO: This depends on player manager and groundable. It should not, these are two different systems.

    public PlayerManager playermanager;
    public Groundable heroGroundable;
    private Groundable myGround;
    private bool waiting;

    private void Start()
    {
        myGround = GetComponent<Groundable>();
        myGround.onGround.AddListener(GroundShake);
    }

    private void GroundShake()
    {
        if (heroGroundable.grounded)
        {
           DecreaseHealth();
            Invoke("ResetWait", 2);
        }
    }
    
    void DecreaseHealth()
    {
        if (waiting)
        {
            return;
        }
        waiting = true;
        playermanager.Health -= 1;
    }

    void ResetWait()
    {
        waiting = false;
    }
    
}
