using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickSetPosition : MonoBehaviour
{
    public Coroutine coroutine;
    public List<GameObject> Bullets = new List<GameObject>();
    public GameObject Bullet;
    

    void OnMouse()
    {
        Vector3 playerPos = coroutine.GetComponentInParent<Transform>().position;
        //move
        if (Input.GetMouseButtonDown(0))
        {
            //coroutine.Target = new Vector3(Input.mousePosition.x, playerPos.y, Input.mousePosition.y);
            //print("player position: " + playerPos);

            //Vector3 mPosition = new Vector3((int)Input.mousePosition.x, (int)Input.mousePosition.y, (int)Input.mousePosition.z);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Vector3 roundedOrigin = new Vector3(ray.origin.x, (int)ray.origin.y, ray.origin.z);
            //print("ray origin: " + ray.origin);


            //Vector3 cam = Camera.main.transform.position;            
            //print("original cam vector: " + cam);
            //print("Camera near clip plane: " + Camera.main.nearClipPlane);
            //cam.y -= Camera.main.nearClipPlane;
            //print("new cam vector: " + cam);

            //distance from camera to player's position
            //float distToPoint_y = Mathf.Abs(playerPos.y - ray.origin.y);
            //float distToPoint_y = Vector3.Distance(playerPos, ray.origin);
            //print("distance from camera to player's y position: " + distToPoint_y);

            RaycastHit hit;

            Physics.Raycast(ray, out hit);

            if (hit.collider.gameObject == gameObject && hit.collider.gameObject.name == "movementPlane")
            {
                //store the point on the ray where it intersects the player's position on the y-axis
                //Vector3 newPosition = ray.GetPoint(distToPoint_y);
                Vector3 newPosition = hit.point;
                newPosition.y = playerPos.y;
                //print("newPosition variable: " + newPosition);
                //newPosition.y = playerPos.y;
                //print("destination position: " + newPosition);
                coroutine.Target = newPosition;

            }
        }
        // shoot
        if(Input.GetMouseButtonDown(1))
        {
            Vector3 pos = new Vector3(0, 0, 0);
            Vector3 gunPos = GameObject.Find("Barrel").transform.position;
            print(gunPos);

            //instantiate bullet
            GameObject g = Instantiate(Bullet, gunPos, Quaternion.identity) as GameObject;
            Bullets.Add(g);
            g.name = "Bullet " + Bullets.Count;
        }
    }

    void Update()
    {
        OnMouse();
    }


    //void OnMouseDown()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    Vector3 playerPos = coroutine.GetComponentInParent<Transform>().position;

    //    //get the y position of the player
    //    //ray.GetPoint(Vector3.Distance(Camera.main.transform.position, playerPos));
    //    //distance from camera position to a point along y-axis
    //    float distToPoint_y = Vector3.Distance(Camera.main.transform.position, playerPos);
    //    print(distToPoint_y);

    //    coroutine.Target = ray.GetPoint(distToPoint_y);

    //    RaycastHit hit;

    //    //Physics.Raycast(ray, out hit, distToPoint_y);

    //    if (Physics.Raycast(ray, out hit, distToPoint_y) == false)
    //    {
    //        print("no hit");
    //        coroutine.Target = ray.GetPoint(distToPoint_y);
    //    }
    //}
}
