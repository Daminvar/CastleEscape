name("Kitchen")
mapfile("Kitchen3.tmx")
battleTexture("test-battle-background")
north("Kitchen4.js")
west("Kitchen2.js")

var cook1 = newNPE()
var cook2 = newNPE()
var cook3 = newNPE()
var headChef = newNPE()

cook1.SetPosition(4,6)
cook1.SetTexture("chef_front")
cook1.SetInteractFunc(function(player)
{
	dialogue("Finn: The master chef isn't letting anyone into storage today.|I think someone must have stolen something again...|||Jordan: (It actually wasn't me this time... Though I am pretty hungry.)")
} )

cook2.SetPosition(17,10)
cook2.SetTexture("chef_right")
cook2.SetInteractFunc(function(player)
{
	dialogue("Sans: Master chef is really picky. With all the criticism he gives, it's hard to imagine him hiring anyone!")
} )

cook3.SetPosition(14,9)
cook3.SetTexture("chef_left")
cook3.SetInteractFunc(function(player)
{
	dialogue("Ixel: The master chef is such a tyrant!|And his cooking sucks!|||Jordan: You might want to lower your voice.")
} )

if(getFlag("go-to-bedroom"))
{
	headChef.SetPosition(9,2)
}
else
{
	headChef.SetPosition(10,1)
}
headChef.SetTexture("headchef_front")

headChef.SetInteractFunc(function(player)
{
	if(getFlag("go-to-bedroom"))
	{
		dialogue("Sayech: Go on, get that spice! The lady cannot eat such a bland pie!")
	}
	else 
	{
		if(getFlag("herring-pie"))
		{
			dialogue("Sayech: Hm...||Jordan: (He just ate a slice of the pie!)||Sayech: This is... decent, I suppose.|But it is far too bland!|||Sayech: You must go into the storage room and get some cinnamon.|That should do the trick.|||Sayech: Then, deliver it to the lady in her chambers!")
			setFlag("go-to-bedroom")
			reloadMap()
		}
		else 
		{
			if(getFlag("talked-to-master-chef"))
			{
				dialogue("Sayech: Go on! The lady is waiting!")
			}
			else
			{
				dialogue("Sayech: No one is allowed in the storage room today!||||Sayech: Hm? Who are you?||Jordan: I'm... a new chef.||Sayech: Oh, that's YOU?|You're supposed to be delivering the lady her food! Why are you standing around here?!||Sayech: Quick, go make some herring pie. It is her favorite.||||Jordan: (I don't know how to cook herring pie! It's disgusting!!)|(Wait a second... where have I heard 'herring pie' before?)")
				setFlag("talked-to-master-chef")
				reloadMap()
			}
		}
	}
} )

addNPE(cook1)
addNPE(cook2)
addNPE(cook3)
addNPE(headChef)

var vegetable = newEnemy("snake", "Deadgetable", 90, 10, 2, 2, 20, null)
var salad = newEnemy("ghostie", "Evil Salad", 100, 9, 2, 3, 22, null)

addRandomEncounter(vegetable)
addRandomEncounter(salad)