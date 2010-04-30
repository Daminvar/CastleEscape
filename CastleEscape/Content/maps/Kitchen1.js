name("Kitchen")
mapfile("Kitchen1.tmx")
battleTexture("test-battle-background")
north("Kitchen2.js")
south("Hallway1.js")

var cook1 = newNPE()
var cook2 = newNPE()
var cook3 = newNPE()
var cook4 = newNPE()
var cook5 = newNPE()
var cook6 = newNPE()

cook1.SetPosition(17,5)
cook1.SetTexture("ghostie")
cook1.SetInteractFunc(function(player)
{
	dialogue("Oh, it's such a lovely day to work in the kitchens!|Everyone, chop chop!")
} )

cook2.SetPosition(3,3)
cook2.SetTexture("snake")
cook2.SetInteractFunc(function(player)
{
	dialogue("I'm on dish duty today...")
} )

cook3.SetPosition(13,13)
cook3.SetTexture("ghostie")
cook3.SetInteractFunc(function(player)
{
	if(getFlag("talked-to-head-chef"))
	{
		if(getFlag("herring-pie"))
		{
			dialogue("Thief! Scoundrel!||||You better enjoy that delicious pie!")
		}
		else
		{
			dialogue("An order of our best herring pie?|Coming right up, sir.|||May I inquire as to how you will be paying?||||...No money?! Out of my sight!")
			var angryWaiter = newEnemy("ghostie", "Angry Waiter", 120, 15, 4, 3, 45)
			battle(player, angryWaiter)
			setFlag("herring-pie")
			reloadMap()
		}
	}
	else
	{
		dialogue("Our specials today are lampreys and herring pie.")
	}
} )

cook4.SetPosition(14,8)
cook4.SetTexture("ghostie")
cook4.SetInteractFunc(function(player)
{
	dialogue("Chop chop chop chop chop|chop chop chop chop chop|chop chop chop chop chop|chop chop chop chop chop|OWWW! MY FINGER!!")
} )

cook5.SetPosition(1,7)
cook5.SetTexture("snake")
cook5.SetInteractFunc(function(player)
{
	dialogue("Is it Friday yet?")
} )

cook6.SetPosition(0,13)
cook6.SetTexture("test-npe")
cook6.SetInteractFunc(function(player)
{
	dialogue("Last night, I had a weird dream about a restaurant on the sea.|How silly is that?")
} )

addNPE(cook1)
addNPE(cook2)
addNPE(cook3)
addNPE(cook4)
addNPE(cook5)
addNPE(cook6)

var vegetable = newEnemy("snake", "Deadgetable", 90, 10, 2, 2, 20, null)
var salad = newEnemy("ghostie", "Evil Salad", 100, 9, 2, 3, 22, null)

addRandomEncounter(vegetable)
addRandomEncounter(salad)