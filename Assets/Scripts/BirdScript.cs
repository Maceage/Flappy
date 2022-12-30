using UnityEngine;

public class BirdScript : MonoBehaviour
{ 
    public Rigidbody2D birdRigidBody;
    public Animation birdAnimation;
    public float flapStrength;
    public float deadZoneCeiling;
    public float deadZoneFloor;
    public LogicScript logic;
    public bool birdIsAlive = true;
    
    // Start is called before the first frame update
    public void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    
    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            birdRigidBody.velocity = Vector2.up * flapStrength;            
        }

        float currentY = birdRigidBody.position.y;

        bool isBeyondCeiling = currentY > deadZoneCeiling;
        bool isBeyondFloor = currentY < deadZoneFloor;
        
        if (isBeyondCeiling || isBeyondFloor)
        {
            birdAnimation.Stop();
            
            logic.GameOver();
        }
    }

    private void OnCollisionEnter2D()
    {
        birdAnimation.Stop();
        
        logic.GameOver();
        
        birdIsAlive = false;
    }
}
