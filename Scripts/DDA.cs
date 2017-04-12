using UnityEngine;
using System.Collections;

public class DDA : MonoBehaviour {

    public int deaths=0;
    public float time=0, timeJ=0;
    bool change = true;//mode deveria ser um enum, size tbm
    public int mode=0; //-1:bored, 0:focused, 1=:stressed
    public int size = 0;//-1:small, 0:normal, 1:large
    public float ver=0;//ddaTipo deveria ser um enum
    public int ddaTipo = 0;//0:emotivo + perfomance; 1:emotivo; 2:perfomance

	// Update is called once per frame
	void Update () {
	
	}

    public void Kill() {
        this.deaths++;
    }

    public void Resetd() {
        this.deaths = 0;
        this.change = true;
    }

    public void TimeClear(){
        if (change)
        {
            if (Time.fixedTime - time>40) {
                this.timeJ = Time.fixedTime - time;
                this.time = Time.fixedTime;
                this.change = false;
            }
        }
    }

    public void Verify() {
        if (ver > 20)
        {
            this.mode += 1;
        }
        else if (ver < -20)
        {
            this.mode -=1;
        }
        this.ver = 0;
    }

    public int CheckMode() {
        return mode;
    }

    public void Upd(float x) {
        this.ver += x;
    }
    public void Zerar() {
        this.ver = 0;
    }
    public int GetDeath()
    {
        return deaths;
    }
    public int GetSize()
    {
        return size;
    }

    public int GetDDA()
    {
        return ddaTipo;
    }

    public void SetSize(int newSize)
    {
        size = newSize;
    }

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
