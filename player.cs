Vector3 playerPos = transform.position;
Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

Vector3 dir = mousePos - playerPos;
dir.Normalize();

Vector3 speedVec = dir * speed;

var vel = rb2d.velocity;
        vel.x = speedVec.x;
        vel.y = speedVec.y;
        rb2d.velocity = vel;
