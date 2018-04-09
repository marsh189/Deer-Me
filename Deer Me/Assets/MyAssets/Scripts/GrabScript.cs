using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class GrabScript : MonoBehaviour {
    public Transform player;
    private Rigidbody2D rBody;
    private bool grabbed;
    public GameObject grabObj;
    public GameObject carryPoint;
    private bool canGrab = false;
    public GameObject Player;
    private float scaleX;
    private float scaleY;
    private float scaleZ;
    private PlatformerCharacter2D pScript;
    public string tagName;

	public RuntimeAnimatorController woodAnim;

	public GameObject Icon;
	public float maxSize;
	Vector3 temp = new Vector3 (1, 1, 1);
	public bool isMax;

    public GameObject Torch;
    public RuntimeAnimatorController normalAnims;
    public RuntimeAnimatorController torchAnims;

	// Use this for initialization
	void Start () {
        grabbed = false;
        pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformerCharacter2D>();
        SpriteRenderer spr = carryPoint.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!transform.parent.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().hasTorch)
        {
            if (Input.GetButtonDown("Grab") && grabbed)
            {
                Debug.Log("trying to drop");
                transform.parent.GetComponent<Animator>().SetTrigger("isThrowing");
                GameObject droppedObj = new GameObject("Dropped Thing");
                Icon.GetComponent<SpriteRenderer>().sprite = null; 
                Icon.SetActive(false);
                carryPoint.SetActive(true);
                droppedObj.AddComponent<SpriteRenderer>().sprite = carryPoint.GetComponent<SpriteRenderer>().sprite;
                droppedObj.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                droppedObj.AddComponent<Rigidbody2D>();
                droppedObj.gameObject.tag = tagName;
                if (tagName == "Metal")
                {
                    droppedObj.gameObject.layer = 0;
                }
                if (droppedObj.gameObject.tag == "Grabbable")
                {
                    droppedObj.AddComponent<Animator>().runtimeAnimatorController = woodAnim as RuntimeAnimatorController;
                    droppedObj.AddComponent<BreakingWood>();
                }

                droppedObj.transform.position = Player.transform.position;
                if (pScript.m_FacingRight)
                {
                    droppedObj.GetComponent<Rigidbody2D>().velocity = (new Vector2(3f, 3f));
                }
                else
                {
                    droppedObj.GetComponent<Rigidbody2D>().velocity = (new Vector2(-3f, 3f));
                }
                IEnumerator co = DelayedEffects(droppedObj);
                StartCoroutine(co);
                carryPoint.GetComponent<SpriteRenderer>().sprite = null;
                grabbed = false;


            }
            else if (Input.GetButtonDown("Grab") && !grabbed && canGrab)
            {
                if (grabObj.tag == "Torch")
                {
                    if (grabObj.GetComponent<TreeTorch>().hasTorch)
                    {
                        transform.parent.GetComponent<Animator>().runtimeAnimatorController = torchAnims as RuntimeAnimatorController;
                        transform.parent.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().hasTorch = true;
                        grabObj.GetComponent<TreeTorch>().torch.SetActive(false);
                        Torch.SetActive(true);
                    }
                }
                else
                {
                    tagName = grabObj.gameObject.tag;
                    carryPoint.GetComponent<SpriteRenderer>().sprite = grabObj.gameObject.GetComponent<SpriteRenderer>().sprite;
                    carryPoint.transform.localScale = new Vector3(grabObj.transform.localScale.x * (1 / 0.3833752f), grabObj.transform.localScale.y * (1 / 0.3833752f), grabObj.transform.localScale.z * (1 / 0.3833752f));
                    scaleX = grabObj.transform.localScale.x;
                    scaleY = grabObj.transform.localScale.y;
                    scaleZ = grabObj.transform.localScale.z;
                    Destroy(grabObj.gameObject);
                    carryPoint.SetActive(false);
                    Icon.GetComponent<SpriteRenderer>().sprite = carryPoint.GetComponent<SpriteRenderer>().sprite; 
                    Icon.SetActive(true);
                    Icon.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                    grabbed = true;
                    grabObj = null;
                    transform.parent.GetComponent<Animator>().SetTrigger("isPickingUp");
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Grab") && grabObj.tag == "Torch" && !grabObj.GetComponent<TreeTorch>().hasTorch)
            {
                transform.parent.GetComponent<Animator>().runtimeAnimatorController = normalAnims as RuntimeAnimatorController;
                transform.parent.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().hasTorch = false;
                grabObj.GetComponent<TreeTorch>().torch.SetActive(true);
                Torch.SetActive(false);
            }
        }
            
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Grabbable" || col.gameObject.tag == "buttonLog" || col.gameObject.tag == "Metal" || col.gameObject.tag == "Torch")
        {
            grabObj = col.gameObject;
            canGrab = true;

        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        grabObj = null;
        canGrab = false;
    }
    IEnumerator DelayedEffects(GameObject droppedObj)
    {
        if(droppedObj.gameObject.tag == "Grabbable")
        {
            droppedObj.layer = 8;
        }
        if(droppedObj.gameObject.tag == "Metal")
        {
            droppedObj.layer = LayerMask.NameToLayer("Default");
        }
        yield return new WaitForSeconds(0.7f);
        droppedObj.AddComponent<PolygonCollider2D>();
        droppedObj.AddComponent<freezeZ>();
        droppedObj.layer = 8;
        yield return null;
    }
}
