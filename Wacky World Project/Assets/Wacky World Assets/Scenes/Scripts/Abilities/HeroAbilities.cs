using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAbilities : MonoBehaviour
{
    [SerializeField]
    private Ability ability;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ability != null) 
            ability.Use();
    }

    public void AddAbility(Type type)
    {
        if (!type.IsSubclassOf(typeof(Ability))) return;

        ability = gameObject.AddComponent(type) as Ability;
    }

    public void RemoveAbility(Type type)
    {
        if (!type.IsSubclassOf(typeof(Ability))) return;
        Component component = GetComponent(type);
        if (component) Destroy(component);
        if (type == ability.GetType()) ability = null;

    }
}
