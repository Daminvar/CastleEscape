
mapfile("testmap.tmx")

east("testmap2.js")

var bob = newNPE()
bob.SetTexture("test-npe");

if (getFlag("talked-to-bob")) {
	bob.SetPosition(5, 5)
} else {
	System.Console.WriteLine("blah")
	bob.SetPosition(12, 11)
}

bob.SetInteractFunc(function() {
	if (getFlag("talked-to-bob")) {
		dialogue("I have nothing more to say to you.")
	} else {
		dialogue("Hi, it's nice to meet you.")
	}
})

addNPE(bob)
