name("Kitchen")
mapfile("Kitchen4.tmx")
battleTexture("restaurant-kitchen")
south("Kitchen3.js")

var treasure1 = newNPE()
var treasure2 = newNPE()
var treasure3 = newNPE()

treasure1.SetPosition(14,6)
treasure1.SetTexture("treasure")
treasure1.SetInteractFunc(function(player)
{
	if(!getFlag("got-treasure1"))
	{
		dialogue("The chest contained Cinnamon!")
		var cinnamon = newItem("Cinnamon", "Spicy cinnamon of excellent quality.", 10, 15, 45)
		player.AddItem(cinnamon)
		setFlag("got-treasure1")
		reloadMap()
	}
} )

treasure2.SetPosition(6,9)
treasure2.SetTexture("treasure")
treasure2.SetInteractFunc(function(player)
{
	if(!getFlag("got-treasure2"))
	{
		dialogue("The chest contained Water!")
		var water = newItem("Water", "A refreshing jug of clean water.", 20, 15, 20)
		player.AddItem(water)
		setFlag("got-treasure2")
		reloadMap()
	}
} )

treasure3.SetPosition(6,3)
treasure3.SetTexture("treasure")
treasure3.SetInteractFunc(function(player)
{
	if(!getFlag("got-treasure3"))
	{
		dialogue("The chest contained Bread!")
		var bread = newItem("Bread", "A fresh loaf of delicious white bread.", 45, 15, 30)
		player.AddItem(bread)
		setFlag("got-treasure3")
		reloadMap()
	}
} )

if(!getFlag("got-treasure1"))
{
	addNPE(treasure1)
}

if(!getFlag("got-treasure2"))
{
	addNPE(treasure2)
}

if(!getFlag("got-treasure3"))
{
	addNPE(treasure3)
}

var saveOrb = newNPE()
saveOrb.SetTexture("orb-of-saving")
saveOrb.SetPosition(13, 7)

saveOrb.SetInteractFunc(function(player) {
	save(player) // Saves the game. Try to use this function only with the orb of saving.
	dialogue("Game has been saved.")
})

addNPE(saveOrb)

var vegetable = newEnemy("deadgetable_battle", "Deadgetable", 90, 10, 2, 2, 20, null)
var salad = newEnemy("salad_battle", "Evil Salad", 100, 9, 2, 3, 22, null)

addRandomEncounter(vegetable)
addRandomEncounter(salad)