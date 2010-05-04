#include "MainMenu.hh"

#include <string>
#include <vector>
using namespace std;

#include <SFML/Graphics.hpp>

#include "TextMenu.hh"

namespace CastleEscape {

MainMenu::MainMenu() {
	background.LoadFromFile("Content/main-menu-background.png");
	bgSprite.SetImage(background);

	sf::Font font;
	font.LoadFromFile("Content/fonts/diavlo-bold.otf");
	vector<string> options;
	options.push_back("New Game");
	options.push_back("Load Game");
	options.push_back("About");
	options.push_back("Quit");

	menu = new TextMenu(options, font);
}

MainMenu::~MainMenu() {
	delete menu;
}

void MainMenu::Pause() {
	// TODO
}

void MainMenu::Resume() {
	// TODO
}

void MainMenu::Update(const sf::Clock& clock, const sf::Input& input) {
	menu->Update(clock, input);
}

void MainMenu::Draw(sf::RenderWindow& window) {
	window.Draw(bgSprite);
	menu->Draw(window, 300, 300, sf::Color(0, 0, 0));
}

} // namespace CastleEscape
