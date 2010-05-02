name("Chapel")
mapfile("Chapel1.tmx")
battleTexture("test-battle-background")

east("Chapel2.js")
south("Graveyard1.js")

var churchgoer1 = newNPE()
churchgoer1.SetTexture("snake")

churchgoer1.SetPosition(14,11)

churchgoer1.SetInteractFunc(function(player){
	dialogue("Church is the place to be when you need some holyness in your day!")
})
	
addNPE(churchgoer1)

var churchgoer2 = newNPE()
churchgoer2.SetTexture("ghostie")

churchgoer2.SetPosition(7,12)

churchgoer2.SetInteractFunc(function(player){
	dialogue("Enjoy your time in the Lord's House ")
})
	
addNPE(churchgoer2)

var churchgoer3 = newNPE()
churchgoer3.SetTexture("test-npe")

churchgoer3.SetPosition(7,2)

churchgoer3.SetInteractFunc(function(player){
	dialogue("Some say you can solve problems just by visiting the church and talking to a priest |||| Who would have guessed?")
})
	
addNPE(churchgoer3)

var churchgoer4 = newNPE()
churchgoer4.SetTexture("snake")

churchgoer4.SetPosition(14,5)

churchgoer4.SetInteractFunc(function(player){
	dialogue("Be quiet young one, don't interupt the priest")
})
	
addNPE(churchgoer4)