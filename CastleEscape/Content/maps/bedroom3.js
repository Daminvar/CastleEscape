
name("Servants' Room")
mapfile("bedroom3.tmx")
battleTexture("test-battle-background") //TODO

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