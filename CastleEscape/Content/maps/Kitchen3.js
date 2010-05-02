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
cook1.SetTexture("ghostie")
cook1.SetInteractFunc(function(player)
{
	dialogue("The head chef isn't letting anyone into storage today.|I think someone must have stolen something again...")
} )

cook2.SetPosition(17,10)
cook2.SetTexture("snake")
cook2.SetInteractFunc(function(player)
{
	dialogue("Head chef is really picky. With all the criticism he gives, it's hard to imagine him hiring anyone!")
} )

cook3.SetPosition(14,9)
cook3.SetTexture("ghostie")
cook3.SetInteractFunc(function(player)
{
	dialogue("The head chef is such a tyrant!|And his cooking sucks!|||What do you mean, he's right over there?")
} )

if(getFlag("go-to-storage"))
{
	headChef.SetPosition(9,2)
}
else
{
	headChef.SetPosition(10,1)
}
headChef.SetTexture("test-npe")

headChef.SetInteractFunc(function(player)
{
	if(getFlag("go-to-storage"))
	{
		dialogue("Go on, get that spice! The lady cannot eat such a bland pie!")
	}
	else 
	{
		if(getFlag("herring-pie"))
		{
			dialogue("Hm...||||This is... decent, I suppose.|But it is far too bland!|||You must go into the storage room and get some cinnamon.|That should do the trick.|||Then, deliver it to the lady in her chambers!")
			setFlag("go-to-storage")
			reloadMap()
		}
		else 
		{
			if(getFlag("talked-to-head-chef"))
			{
				dialogue("Go on! The lady is waiting!")
			}
			else
			{
				dialogue("No one is allowed in the storage room today!||||Hm? Who are you?||||Oh, you must be the new chef.|You're supposed to be delivering the lady her food! Why are you standing around here?!||Quick, go make some herring pie. It is her favorite.")
				setFlag("talked-to-head-chef")
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