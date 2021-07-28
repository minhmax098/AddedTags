using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TagHandler : MonoBehaviour
{
    public static TagHandler instance; 
    public static TagHandler Instance 
    { 
        get 
        { 
            if (instance == null)
            {
                instance = FindObjectOfType<TagHandler>(); 
            }
            return instance; 
        } 
    }

    public TextAsset textJson; 

    public List<GameObject> addedTags = new List<GameObject>(); 

    [System.Serializable]
    public class Point 
    {
        public Vector3 coordinate { get; set; } // tọa độ 
        public Vector3 direction { get; set; }  // hướng đi 
        public float angle { get; set; }     // góc 
        public Point (Vector3 coordinate, Vector3 direction)
        {
            this.coordinate = coordinate; 
            this.direction = direction; 
        }

    }

    [System.Serializable]
    public class Tag 
    {
        public string name { get; set; }
        public string description { get; set; }
        public Point point { get; set; }
        public Vector3 tag { get; set; }
        public Tag[] child { get; set; }
        public Tag (string name, string description, Point point, Vector3 tag, Tag[] child)
        {
            this.name = name; 
            this.description = description;
            this.point = point;
            this.tag = tag;
            this.child = child;
        }
    }

    [System.Serializable]
    public class Atlas 
    {
        public Tag[] tags; 
    }

    public Atlas atlas = new Atlas(); 

    // Start is called before the first frame update
    void Start()
    {
        initAtlas(); 
        // loadTags(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (addedTags.Count > 0)
        {
            OnMove(); 
        }
    }

    public void initAtlas()
    {
        atlas.tags = new Tag[]
        {
            new Tag(
                "Axial", 
                "", 
                new Point(
                    new Vector3(0.0f, 5.0f, 0.0f),
                    new vector3(0.0f, 0.0f, 359.9f)
                ), 
                new Vector3(0.0f, 5.5f, 0.0f), 
                new Tag[]{}
            ), 
            new Tag(
                "Appendicular", 
                "", 
                new Point(
                    new Vector3(-1.5f, 1.75f, 0.4f), 
                    new Vector3()
                )
            )
        }
    }
}
