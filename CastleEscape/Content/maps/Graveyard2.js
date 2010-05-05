name("Graveyard")
mapfile("Graveyard2.tmx")
battleTexture("test-battle-background")

west("Graveyard1.js")

var grave1 = newNPE()
grave1.SetPosition(2, 9)

grave1.SetInteractFunc(function(player) {
	dialogue("Here lies Jimothy Fizweldt of House Caraldad. His life was virtuous and true. He will be forever missed.")
})

addNPE(grave1)

var grave2 = newNPE()
grave2.SetPosition(5, 8)

grave2.SetInteractFunc(function(player) {
	dialogue("Here lies the Great Minister Derel. May he find eternal happiness in the beyond.")
})

addNPE(grave2)

var grave3 = newNPE()
grave3.SetPosition(8, 3)

grave3.SetInteractFunc(function(player) {
	dialogue("Here lies Geravene Wilder. She will be forever missed.")
})

addNPE(grave3)

var grave4 = newNPE()
grave4.SetPosition(9, 10)

grave4.SetInteractFunc(function(player) {
	dialogue("Here lies Lucile Fisher, the first librarian of Euphor. Her contributions to preserving our history shall be remembered forever.")
})

addNPE(grave4)

var grave5 = newNPE()
grave5.SetPosition(12, 9)

grave5.SetInteractFunc(function(player) {
	dialogue("Here lies Justin Tyme. He died of oversleeping.")
})

addNPE(grave5)

var grave6 = newNPE()
grave6.SetPosition(13, 3)

grave6.SetInteractFunc(function(player) {
	dialogue("Here lies Jeannette Vaux, who died from eating too much mustard... We will miss her forever.")
})

addNPE(grave6)

var pierresGrave = newNPE()
pierresGrave.SetPosition(14, 5)

pierresGrave.SetInteractFunc(function(player) {
	dialogue("Here lies the Old King Pierre. His diplomatic skills saved Euphor from many an unnecessary battle. His contributions are great, and he shall be forever missed.")
	setFlag("pierre-grave-read")
})

addNPE(pierresGrave)

var markelsGrave = newNPE()
markelsGrave.SetPosition(17, 5)

markelsGrave.SetInteractFunc(function(player) {
	dialogue("Here lies the Old King Markel. His many conquests made Euphor as great as it is today. He will be forever missed.")
})

addNPE(markelsGrave)

function penguinText(player) {
	dialogue("May all kneel before the Penguin God Roni, who wrought the Earth from his mighty flippers.")
}

var penguinLeft = newNPE()
penguinLeft.SetPosition(15, 8)
penguinLeft.SetInteractFunc(penguinText)
addNPE(penguinLeft)

var penguinRight = newNPE()
penguinRight.SetPosition(16, 8)
penguinRight.SetInteractFunc(penguinText)
addNPE(penguinRight)

