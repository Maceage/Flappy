using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{ 
    public LogicScript logic;
    
    // Start is called before the first frame update
    public void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.AddScore(1);            
        }
    }
}
