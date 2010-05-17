
name("Store Room")
mapfile("armory1.tmx")
overworldMusic("armory-song")

north("HallWay4.js")
south("armory2.js")

var saveOrb = newNPE()
saveOrb.SetTexture("orb-of-saving")
saveOrb.SetPosition(18, 3)

saveOrb.SetInteractFunc(function(player) {
	save(player)
	dialogue("Game has been saved.")
})

addNPE(saveOrb)

var potionSeller = newNPE()
potionSeller.SetTexture("store-front")
potionSeller.SetPosition(6,3)

potionSeller.SetInteractFunc(function(player) {
	var items = [] //Create a Javascript array as such.
	
	items[0] = newItem("Major Health Potion", "Restores hp", 400, 0, 175)
	items[1] = newItem("Major Mana Potion" , "Restores mana", 0, 100, 150)
	items[2] = newItem("Major Mixture Potion", "Restores health and mana", 350, 75, 275)
	
	store(player, items) // Pushes on a store state. Parameters are the player and an array of items.
})

addNPE(potionSeller)
