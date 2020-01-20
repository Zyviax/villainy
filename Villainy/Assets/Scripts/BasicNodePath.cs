using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNodePath : MonoBehaviour
{
    public List<Transform> nodePath;
    public GameObject node;

    public Transform startNode;
    public Transform endNode;

    public void CreateNewNode()
    {
        Transform nextNode = Instantiate(node, endNode.position, Quaternion.identity).transform;
        nextNode.SetParent(this.transform);
        nextNode.name = "Node" + nodePath.Count;

        endNode.GetComponent<Node>().nextNode = nextNode.transform;

        nodePath.Add(nextNode.transform);
        endNode = nextNode;
    }
}
