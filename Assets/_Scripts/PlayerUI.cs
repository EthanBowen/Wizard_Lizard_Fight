using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public int ID = 0;
    private float x = 0;
    private float y = 0;
    private Camera UI_Camera = new Camera();
    public Player player;
    public HealthBar HP;
    public ManaBar MP;
    // Start is called before the first frame update
    void Start()
    {
        HP.CurrentPlayerHealth = player.maxHealth;
        MP.CurrentPlayerMana = player.maxMP;
        UI_Camera = GameObject.FindGameObjectWithTag("UI Camera").GetComponent<Camera>();
        ID = HP.ID;
        switch (ID)
        {
            case 1: //top left player
                x = 0.118f;
                y = .940f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
            case 2: //top right player
                x = 1 - 0.118f;
                y = .940f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
            case 3: //bottom left player
                x = 0.118f;
                y = 1 - .940f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
            case 4: //bottom right player
                x = 1 - 0.118f;
                y = 1 - .940f;
                this.transform.position = UI_Camera.ViewportToWorldPoint(new Vector3(x, y, 5f));
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        //HP.setSize();
      //  MP.setSize();
    }
}
