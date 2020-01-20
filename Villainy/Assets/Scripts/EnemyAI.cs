using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public BasicNodePath nodePath;
    public Enemy enemy;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        nodePath = GameObject.Find("/NodeManager").GetComponent<BasicNodePath>();
        target = nodePath.startNode.GetComponent<Node>().transform;
        Debug.Log(transform.position);
        Debug.Log(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target.transform.position)
        {
            float step = enemy.Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
        else
        {
            target = target.GetComponent<Node>().nextNode;
        }
    }
}
