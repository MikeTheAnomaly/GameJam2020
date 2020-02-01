using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSocketController : Controllable
{
	public Wsserver server;
	public int indexMessage;

	private Vector3 joy1;
	public override Vector3 Joystick1()
	{
		joy1 = Vector3.zero;

		if (server.message[indexMessage] != "used")
		{
			if (server.message[indexMessage] == "left")
			{
				joy1.Set(-1, 0, 0);
			}
			if (server.message[indexMessage] == "right")
			{
				joy1.Set(1, 0, 0);
			}
			server.message[indexMessage] = "used";
		}
		
		return joy1;
	}

	public override bool InputA()
	{
		throw new System.NotImplementedException();
	}

	public override bool InputB()
	{
		throw new System.NotImplementedException();
	}

	public override bool InputX()
	{
		throw new System.NotImplementedException();
	}

	public override bool InputY()
	{
		throw new System.NotImplementedException();
	}
}
