using UnityEngine;
using UnityEngine.AI;



public class MousePathFinding : MonoBehaviour {
    

    public Camera cam;

    public NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update () {
        //if the left mouse button is clicked it will cast a ray 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            //if the raycast hits then it will set the destination of the pathfinding to be the his point
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }



	}
}
