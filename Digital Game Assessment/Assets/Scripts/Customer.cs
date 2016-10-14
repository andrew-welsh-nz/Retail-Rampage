using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour {

    public Transform[] path;
    public int currentPathPosition = 0;
    public float customerSpeed;
    public float movementPause;
    public Store store;

    Transform target;
    public bool canMove = true;
	
	// Update is called once per frame
	void Update () {
        if (currentPathPosition < this.path.Length)
        {
            if(target == null)
            {
                target = path[currentPathPosition];
                
            }

            MoveToPosition();
        }
	}

    void MoveToPosition()
    {
        if(canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, customerSpeed * Time.deltaTime);
            if (transform.position == target.position)
            {
                ++currentPathPosition;
                if (currentPathPosition < path.Length)
                {
                    target = path[currentPathPosition];
                }
            }
        }
    }
}
