using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonUI : MonoBehaviour
{
    EmployeeController cont = new EmployeeController(maxEmployees: 5);

    public void NewEmployeeButton() {
        Debug.Log("clicked");
        // EmployeeSkill[] skills = {EmployeeSkill.Skill1};

        // string id = cont.CreateNewEmployee("Employee "+Random.Range(0f, 10f), 100, skills);
        // cont.LogAllEmployees();
        // cont.FireEmployee(id);
        // cont.LogAllEmployees();
    }
}
