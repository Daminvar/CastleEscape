#include "TextMenu.hh"

#include <cmath>
#include <string>
#include <vector>

#include <SFML/Graphics.hpp>

namespace CastleEscape {

TextMenu::TextMenu(const std::vector<std::string>& options,
		const sf::Font& font) {
	this->options = options;
	this->font = font;
	selectedOption = 0;
	defaultStretch = 1;
	canMove = false;
	isFinished = false;
	canPressZ = false;
}

bool TextMenu::IsFinished() {
	return isFinished;
}

void TextMenu::Restart() {
	isFinished = false;
}

uint TextMenu::GetSelectedOption() {
	return selectedOption;
}

void TextMenu::Update(const sf::Clock& clock, const sf::Input& input) {
	if (!isFinished) {
		selectedStretch = (float) (defaultStretch + std::sin(
				clock.GetElapsedTime() * 5));
		selectedStretch = 1 + selectedStretch / options[selectedOption].size();
	} else {
		canMove = false;
		selectedStretch = defaultStretch;
		return;
	}

	if (!input.IsKeyDown(sf::Key::Z))
		canPressZ = true;

	if (canPressZ && input.IsKeyDown(sf::Key::Z)) {
		isFinished = true;
		canPressZ = false;
		selectedStretch = defaultStretch;
	}

	if (!input.IsKeyDown(sf::Key::Up) && !input.IsKeyDown(sf::Key::Down))
		canMove = true;
	if (!canMove)
		return;
	if (input.IsKeyDown(sf::Key::Up)) {
		selectedOption = selectedOption > 0 ? selectedOption - 1
				: options.size() - 1;
		canMove = false;
	} else if (input.IsKeyDown(sf::Key::Down)) {
		selectedOption = (selectedOption + 1) % options.size();
		canMove = false;
	}
}

void TextMenu::Draw(sf::RenderWindow& window, int x, int y,
		const sf::Color& color) {
	for (uint i = 0; i < options.size(); i++) {
		sf::String item(options[i], font, font.GetCharacterSize());
		item.SetPosition(x, y + i * font.GetCharacterSize());
		item.SetColor(color);
		if (i == selectedOption)
			item.SetScaleX(selectedStretch);
		window.Draw(item);
	}
}

} // namespace CastleEscape
