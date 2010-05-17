
name("Servants' Room")
mapfile("bedroom3.tmx")
overworldMusic("bedroom-song")
randomBattleMusic("regular-battle-song")
battleTexture("bedroom-bg")

north("bedroom2.js")
west("bedroom4.js")

var saveOrb = newNPE()
saveOrb.SetTexture("orb-of-saving")
saveOrb.SetPosition(18, 3)

saveOrb.SetInteractFunc(function(player) {
	save(player)
	dialogue("Game has been saved.")
})

addNPE(saveOrb)

var salesman = newNPE()
salesman.SetTexture("store-front")
salesman.SetPosition(9, 8)

salesman.SetInteractFunc(function(player) {
	var items = []
	items[0] = newItem("Peanut Butter", "High quality peanut butter", 150, 0, 100)
	items[1] = newItem("Mega Mead", "A magical bottle of delicious mead", 100, 100, 120)
	store(player, items)
})

addNPE(salesman)

var servant = newEnemy("soldier1_battle", "Fanatic Servant", 200, 55, 10, 8, 45, null)
var lazyGuard = newEnemy("soldier2_battle", "Lazy Guard", 210, 58, 10, 5, 53, null)
addRandomEncounter(servant)
addRandomEncounter(lazyGuard)