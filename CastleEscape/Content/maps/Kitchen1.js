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
cook1.SetTexture("chef_left")
cook1.SetInteractFunc(function(player)
{
	dialogue("Jerol: Oh, it's such a lovely day to work in the kitchens!|Everyone, chop chop!")
} )

cook2.SetPosition(3,3)
cook2.SetTexture("waiter_front")
cook2.SetInteractFunc(function(player)
{
	dialogue("Filun: I'm on dish duty today...")
} )

cook3.SetPosition(13,13)
cook3.SetTexture("waiter_left")
cook3.SetInteractFunc(function(player)
{
	if(getFlag("talked-to-master-chef"))
	{
		if(getFlag("herring-pie"))
		{
			dialogue("Bodus: Thief! Scoundrel!||Jordan: ...||Bodus: You better enjoy that delicious pie!")
		}
		else
		{
			dialogue("Bodus: Our specials today are lampreys and herring pie.||Jordan: I'd like some herring pie, please.||Bodus: Coming right up, sir.|May I inquire as to how you will be paying?||Jordan: (Payment?! I'm not wasting gold on this stuff!)|Bodus: ...No money?! Out of my sight!")
			var angryWaiter = newEnemy("ghostie", "Angry Waiter", 120, 15, 4, 3, 45)
			battle(player, angryWaiter)
			setFlag("herring-pie")
			reloadMap()
		}
	}
	else
	{
		dialogue("Bodus: Our specials today are lampreys and herring pie.")
	}
} )

cook4.SetPosition(14,8)
cook4.SetTexture("chef_right")
cook4.SetInteractFunc(function(player)
{
	dialogue("Chip: Chop chop chop chop chop|chop chop chop chop chop|chop chop chop chop chop|chop chop chop chop chop|Chip: OWWW! MY FINGER!!||Jordan: (I hope he doesn't serve that fish...)")
} )

cook5.SetPosition(1,7)
cook5.SetTexture("waiter_front")
cook5.SetInteractFunc(function(player)
{
	dialogue("Ridel: Is it Friday yet?")
} )

cook6.SetPosition(0,13)
cook6.SetTexture("waiter_right")
cook6.SetInteractFunc(function(player)
{
	dialogue("Ijnas: Last night, I had a weird dream about a restaurant on the sea.|How silly is that?")
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