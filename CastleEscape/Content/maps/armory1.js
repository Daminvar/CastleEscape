
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