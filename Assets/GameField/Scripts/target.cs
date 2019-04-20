﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {
  //---往復の動きに関するパラメータ---
  public float speed = .2f;
  public float size = 1;
  public bool moveX=true;
  public bool moveY=false;
  public bool moveZ=false;
  //-----------------------------------

  private Vector3 firstPos;
  private GameObject child; //表示消してもスクリプトを生かすために子を作ってる(いいやり方か知らんが)

  // Start is called before the first frame update
  void Start() {
    firstPos = this.transform.position;
    child = this.transform.GetChild(0).gameObject;
  }

  // Update is called once per frame
  void Update() {
    if (moveX) transform.position = new Vector3(firstPos.x + Mathf.Sin(Time.frameCount * speed) * size, transform.position.y, transform.position.z);
    if (moveY)transform.position = new Vector3(transform.position.x, firstPos.y + Mathf.Sin(Time.frameCount * speed)*size, transform.position.z);
    if (moveZ) transform.position = new Vector3(transform.position.x, transform.position.y, firstPos.z + Mathf.Sin(Time.frameCount * speed) * size);
  }

  //ターゲットに射撃が当たった時に呼び出す関数(引数：参照渡しでスコア)
  public void hitTarget(ref int score) {
    score += 100;
    child.SetActive(false);
    Invoke("activeTarget", Random.Range(3f,5f));
  }

  private void activeTarget() {
    child.SetActive(true);
  }
}