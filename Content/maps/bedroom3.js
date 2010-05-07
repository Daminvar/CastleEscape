
name("Servants' Room")
mapfile("bedroom3.tmx")
battleTexture("bedroom-bg") //TODO

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

var servant = newEnemy("ghostie", "Fanatic Servant", 100, 50, 10, 10, 30, null)
var lazyGuard = newEnemy("ghostie", "Lazy Guard", 200, 60, 10, 5, 80, null)
addRandomEncounter(servant)
addRandomEncounter(lazyGuard)