
name("Side Exit")
mapfile("armory2.tmx")
overworldMusic("armory-song")
battleTexture("armory-bg")

north("armory1.js")

var boss = newNPE()
boss.SetTexture("final-boss")
boss.SetPosition(11, 12)

boss.SetInteractFunc(function(player) {
	dialogue("Kristof: Ah it is you! I know not how you managed to escape from the dungeons, but I shall ensure that you shall never make it out of here. For Euphor!")
	var finalBoss = newEnemy("captain3_battle", "Kristof - Head Knight of Euphor", 600, 100, 12, 20, 0, null)
	battle(player, finalBoss, "final-boss-song")
	win()
})

addNPE(boss)
