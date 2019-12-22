using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Movimentação ciclica.
/// Só funciona caso o objeto tenha 2 filhos.
/// </summary>
public class Cyclic : MonoBehaviour
{
    
    public float movespeed = 3f;

    GameObject[] childs;

    Vector3[] startPositions;

    
    bool[] surpassedPosition;


    private void Start() {
        SetChilds();
        SetStartPositions();
        SetSurpassedPositions();
    }

    void SetSurpassedPositions() {
        surpassedPosition = new bool[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            surpassedPosition[i] = false;
    }

    void SetStartPositions() {
        startPositions = new Vector3[transform.childCount];

        for (int i = 0; i < transform.childCount; i++) {
            startPositions[i] = childs[i].transform.position;
        }
    }

    void SetChilds() {
        childs = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++) {
            childs[i] = transform.GetChild(i).gameObject;
        }
    }


    private void FixedUpdate() {
        if (Game.CanMove())
            Move();
    }


    void Move() {
        foreach (GameObject go in childs) {
            go.transform.position += Vector3.down * movespeed * Time.deltaTime;
        }
        AdjustPositions();
    }

    void AdjustPositions() {

        for (int i = 1; i < transform.childCount; i++) { 
            if (childs[i].transform.position.y < startPositions[0].y && !surpassedPosition[i]) {
                surpassedPosition[i] = true;
                childs[i - 1].transform.position = startPositions[transform.childCount - 1];
            }
        }
        if (childs[0].transform.position.y < startPositions[0].y && surpassedPosition[transform.childCount - 1]){
            for (int i = 1; i < transform.childCount; i++) {
                surpassedPosition[i] = false;
                childs[i].transform.position = startPositions[i];
            }    
        }
        

    }
}
