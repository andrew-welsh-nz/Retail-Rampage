using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour {

    public Transform[] path;
    public int currentPathPosition = 0;
    public float customerSpeed;

    Transform target;
	
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
        transform.position = Vector3.MoveTowards(transform.position, target.position, customerSpeed * Time.deltaTime);
        if(transform.position == target.position)
        {
            ++currentPathPosition;
            target = path[currentPathPosition];
        }
    }
}
