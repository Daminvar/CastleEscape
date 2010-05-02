name("Kitchen")
mapfile("Kitchen4.tmx")
battleTexture("test-battle-background")
south("Kitchen3.js")

var treasure1 = newNPE()
var treasure2 = newNPE()
var treasure3 = newNPE()

treasure1.SetPosition(14,6)
treasure1.SetInteractFunc(function(player)
{
	if(getFlag("got-treasure1"))
	{
		dialogue("An empty treasure chest.")
	}
	else
	{
		dialogue("The chest contained Cinnamon!")
		player.AddItem("Cinnamon", "Spicy cinnamon of excellent quality", 10, 15, 45)
		setFlag("got-treasure1")
	}
} )

treasure2.SetPosition(6,9)
treasure2.SetInteractFunc(function(player)
{
	if(getFlag("got-treasure2"))
	{
		dialogue("An empty treasure chest.")
	}
	else
	{
		dialogue("The chest contained Water!")
		player.AddItem("Water", "A refreshing jug of clean water.", 20, 15, 20)\
		setFlag("got-treasure2")
	}
} )

treasure3.SetPosition(6,3)
treasure3.SetInteractFunc(function(player)
{
	if(getFlag("got-treasure3"))
	{
		dialogue("An empty treasure chest.")
	}
	else
	{
		dialogue("The chest contained Bread!")
		player.AddItem("Bread", "A homemade loaf of delicious white bread.", 45, 15, 30)
		setFlag("got-treasure3")
	}
} )

addNPE(treasure1)
addNPE(treasure2)
addNPE(treasure3)

var vegetable = newEnemy("snake", "Deadgetable", 90, 10, 2, 2, 20, null)
var salad = newEnemy("ghostie", "Evil Salad", 100, 9, 2, 3, 22, null)

addRandomEncounter(vegetable)
addRandomEncounter(salad)