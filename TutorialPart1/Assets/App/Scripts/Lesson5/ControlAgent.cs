using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class ControlAgent : MonoBehaviour
{
    // List of agents
    // if click mouse Agent follwo to target posisiton 

    public List<NavMeshAgent> ListOfAgents;
    public GameObject Target;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void SetAgentsTarget()
    {
        Vector3 targerPosition = Target.transform.position;
        for (int i = 0; i < ListOfAgents.Count; i++)
        {
            var agent = ListOfAgents[i];
            // agent.Move(targerPosition);

            agent.SetDestination(targerPosition);
        }
    }
    
    private void SetAgentsTargetFromMouse()
    {
        var v3 = Input.mousePosition;
        v3.z = 10.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        RaycastHit hit;
        var raycast = Physics.Raycast(v3,  v3-Camera.main.transform.position , out hit);
        for (int i = 0; i < ListOfAgents.Count && raycast; i++)
        {
            var agent = ListOfAgents[i];
            // agent.Move(targerPosition);

            agent.SetDestination(hit.point);
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void SetFromTrigger( BaseEventData data)
    {
        Debug.Log("Entered");;
        PointerEventData fromBoxed = data as PointerEventData;
        var v3 =fromBoxed.pointerPressRaycast.worldPosition;
        for (int i = 0; i < ListOfAgents.Count; i++)
        {
            var agent = ListOfAgents[i];
            // agent.Move(targerPosition);

            agent.SetDestination(v3);
        }
    }



    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetMouseButton(0))
    //     {
    //         SetAgentsTargetFromMouse();
    //         // SetAgentsTarget();    
    //     }
    //     
    // }

    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     SetFromTrigger(eventData);
    // }
}
