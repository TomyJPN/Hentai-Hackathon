using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {
  //---往復の動きに関するパラメータ---
  public float speed = .2f;
  public float size = 1;
  public bool moveX=true;
  public bool moveY=false;
  public bool moveZ=false;

  private float scale = 1;  //全体のスケール
  //-----------------------------------

  private GameObject parent;  
  private Vector3 firstPos;
  private GameObject child; //表示消してもスクリプトを生かすために子を作ってる(いいやり方か知らんが)

  // Start is called before the first frame update
  void Start() {
    //parent = this.transform.parent.parent.gameObject;
    firstPos = this.transform.localPosition;
    child = this.transform.GetChild(0).gameObject;
  }

  // Update is called once per frame
  void Update() {
    //scale = parent.transform.localScale.x;  //入れなくてよくなった
    float rev = size * scale; //補正
    if (moveX) transform.localPosition = new Vector3(firstPos.x + Mathf.Sin(Time.frameCount * speed) * rev, transform.localPosition.y , transform.localPosition.z);
    if (moveY)transform.localPosition = new Vector3(transform.localPosition.x, firstPos.y + Mathf.Sin(Time.frameCount * speed)*rev, transform.localPosition.z);
    if (moveZ) transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, firstPos.z + Mathf.Sin(Time.frameCount * speed) * rev);
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
