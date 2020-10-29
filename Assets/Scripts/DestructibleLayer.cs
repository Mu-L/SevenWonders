using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleLayer : MonoBehaviour
{
    //public GameObject obj;
    public float offsetX;
    public float offsetY;

    private Tilemap destructibleTilemap;
    private Rigidbody2D rb2d;

    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;
    private Vector3 pos4;
    private Vector3 pos5;
    private Vector3 pos6;
    private Vector3 pos7;
    private Vector3 pos8;


    // Start is called before the first frame update
    void Start()
    {
        destructibleTilemap = GetComponent<Tilemap>();
        rb2d = GetComponent<Rigidbody2D>();
        //rb2d.useFullKinematicContacts = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FunctionToGetRidOfTile()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int position = destructibleTilemap.WorldToCell(mousePos);
        destructibleTilemap.SetTile(position, null);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("JumpDust"))
        {
            Vector3 hitPos = other.gameObject.GetComponent<Collider2D>().bounds.ClosestPoint(other.transform.position);
            pos1 = new Vector3(hitPos.x + offsetX, hitPos.y, 0f);
            pos2 = new Vector3(hitPos.x - offsetX, hitPos.y, 0f);
            pos3 = new Vector3(hitPos.x, hitPos.y + offsetY, 0f);
            pos4 = new Vector3(hitPos.x, hitPos.y - offsetY, 0f);
            pos5 = new Vector3(hitPos.x + offsetX, hitPos.y + offsetY, 0f);
            pos6 = new Vector3(hitPos.x + offsetX, hitPos.y - offsetY, 0f);
            pos7 = new Vector3(hitPos.x - offsetX, hitPos.y + offsetY, 0f);
            pos8 = new Vector3(hitPos.x - offsetX, hitPos.y - offsetY, 0f);
            Vector3Int position = destructibleTilemap.WorldToCell(pos1);
            destructibleTilemap.SetTile(position, null);
            position = destructibleTilemap.WorldToCell(pos2);
            destructibleTilemap.SetTile(position, null);
            position = destructibleTilemap.WorldToCell(pos3);
            destructibleTilemap.SetTile(position, null);
            position = destructibleTilemap.WorldToCell(pos4);
            destructibleTilemap.SetTile(position, null);
            position = destructibleTilemap.WorldToCell(pos5);
            destructibleTilemap.SetTile(position, null);
            position = destructibleTilemap.WorldToCell(pos6);
            destructibleTilemap.SetTile(position, null);
            position = destructibleTilemap.WorldToCell(pos7);
            destructibleTilemap.SetTile(position, null);
            position = destructibleTilemap.WorldToCell(pos8);
            destructibleTilemap.SetTile(position, null);
            //Destroy(other.gameObject);

        }

        //if (other.gameObject.CompareTag("Bullet"))
        //{
        //    Vector3 hitPos = other.gameObject.GetComponent<Collider2D>().bounds.ClosestPoint(other.transform.position);
        //    pos1 = new Vector3(hitPos.x + offsetX, hitPos.y, 0f);
        //    pos2 = new Vector3(hitPos.x - offsetX, hitPos.y, 0f);
        //    pos3 = new Vector3(hitPos.x, hitPos.y + offsetY, 0f);
        //    pos4 = new Vector3(hitPos.x, hitPos.y - offsetY, 0f);
        //    pos5 = new Vector3(hitPos.x + offsetX, hitPos.y + offsetY, 0f);
        //    pos6 = new Vector3(hitPos.x + offsetX, hitPos.y - offsetY, 0f);
        //    pos7 = new Vector3(hitPos.x - offsetX, hitPos.y + offsetY, 0f);
        //    pos8 = new Vector3(hitPos.x - offsetX, hitPos.y - offsetY, 0f);
        //    Vector3Int position = destructibleTilemap.WorldToCell(pos1);
        //    destructibleTilemap.SetTile(position, null);
        //    position = destructibleTilemap.WorldToCell(pos2);
        //    destructibleTilemap.SetTile(position, null);
        //    position = destructibleTilemap.WorldToCell(pos3);
        //    destructibleTilemap.SetTile(position, null);
        //    position = destructibleTilemap.WorldToCell(pos4);
        //    destructibleTilemap.SetTile(position, null);
        //    position = destructibleTilemap.WorldToCell(pos5);
        //    destructibleTilemap.SetTile(position, null);
        //    position = destructibleTilemap.WorldToCell(pos6);
        //    destructibleTilemap.SetTile(position, null);
        //    position = destructibleTilemap.WorldToCell(pos7);
        //    destructibleTilemap.SetTile(position, null);
        //    position = destructibleTilemap.WorldToCell(pos8);
        //    destructibleTilemap.SetTile(position, null);
        //    Destroy(other.gameObject);

        //}
    }

    //void OnCollisionEnter2D(Collision2D other)
    //{

    //    if (other.gameObject.CompareTag("Bullet"))
    //    {
    //        Debug.Log("进入TileMap");
    //        Vector3 hitPos = Vector3.zero;
    //        foreach(ContactPoint2D hit in other.contacts)
    //        {
    //            Debug.Log("foreach");
    //            //hitPos.x = hit.point.x - 0.01f * hit.normal.x;
    //            //hitPos.y = hit.point.y - 0.01f * hit.normal.y;
    //            hitPos.x = hit.point.x + 0.5f;
    //            hitPos.y = hit.point.y;
    //            destructibleTilemap.SetTile(destructibleTilemap.WorldToCell(hitPos), null);
    //            //Instantiate(obj, hitPos, Quaternion.identity);
    //        }
    //        Destroy(other.gameObject);
    //    }
    //}
}
