
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

var servant = newEnemy("soldier1_battle", "Fanatic Servant", 100, 50, 10, 10, 30, null)
var lazyGuard = newEnemy("soldier2_battle", "Lazy Guard", 200, 60, 10, 5, 80, null)
addRandomEncounter(servant)
addRandomEncounter(lazyGuard)