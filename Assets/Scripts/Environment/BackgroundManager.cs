using System;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Transform backgroundPrefab;
    [SerializeField] private float backgroundSize = 3;
    [SerializeField] private float size = 20f;
    [SerializeField] private float speed = 1f;
    
    private List<Transform> _backgrounds;

    private void Awake()
    {
        _backgrounds = new List<Transform>();
    }

    private void Start()
    {
        for (var i = 0; i < backgroundSize; i++)
        {
            var temp = Instantiate(backgroundPrefab, parent);
            temp.position = new Vector3(parent.position.x + (i * size), parent.position.y, parent.position.z);
            _backgrounds.Add(temp);
        }
    }

    private void Update()
    {
        for (var i = 0; i < backgroundSize; i++)
        {
            var bg = _backgrounds[i];
            bg.Translate(Vector3.left * speed * Time.deltaTime);
            if (!(Mathf.Abs(Vector3.Distance(Vector3.left * size, bg.position)) < 0.001f)) continue;
            var nextIndex = (i + 2) %_backgrounds.Count; 
            var lastBg = _backgrounds[nextIndex];
            bg.position = new Vector3(lastBg.position.x + size, parent.position.y, parent.position.z);
        }
    }
}
