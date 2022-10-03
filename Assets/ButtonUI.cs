using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonUI : MonoBehaviour
{
    EmployeeController cont = new EmployeeController();

    public void NewEmployeeButton() {
        Debug.Log("clicked");
        EmployeeSkill[] skills = {EmployeeSkill.Skill1};

        Employee e = cont.createNewEmployee("Employee "+Random.Range(0f, 10f), 100, skills);
        
        Debug.Log(e.getName());
    }
}
