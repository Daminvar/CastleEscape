#include "TextMenu.hh"

#include <cmath>
#include <string>
#include <vector>

#include <SFML/Graphics.hpp>

namespace CastleEscape {

TextMenu::TextMenu(const std::vector<std::string>& options,
		const sf::Font& font) {
	options_ = options;
	font_ = font;
	selectedOption_ = 0;
	defaultStretch_ = 1;
	canMove_ = false;
	isFinished_ = false;
	canPressZ_ = false;
}

bool TextMenu::IsFinished() {
	return isFinished_;
}

void TextMenu::Restart() {
	isFinished_ = false;
}

uint TextMenu::GetSelectedOption() {
	return selectedOption_;
}

void TextMenu::Update(const sf::Clock& clock, const sf::Input& input) {
	if (!isFinished_) {
		selectedStretch_ = (float) (defaultStretch_ + std::sin(
				clock.GetElapsedTime() * 5));
		selectedStretch_ = 1 + selectedStretch_ / options_[selectedOption_].size();
	} else {
		canMove_ = false;
		selectedStretch_ = defaultStretch_;
		return;
	}

	if (!input.IsKeyDown(sf::Key::Z))
		canPressZ_ = true;

	if (canPressZ_ && input.IsKeyDown(sf::Key::Z)) {
		isFinished_ = true;
		canPressZ_ = false;
		selectedStretch_ = defaultStretch_;
	}

	if (!input.IsKeyDown(sf::Key::Up) && !input.IsKeyDown(sf::Key::Down))
		canMove_ = true;
	if (!canMove_)
		return;
	if (input.IsKeyDown(sf::Key::Up)) {
		selectedOption_ = selectedOption_ > 0 ? selectedOption_ - 1
				: options_.size() - 1;
		canMove_ = false;
	} else if (input.IsKeyDown(sf::Key::Down)) {
		selectedOption_ = (selectedOption_ + 1) % options_.size();
		canMove_ = false;
	}
}

void TextMenu::Draw(sf::RenderWindow& window, int x, int y,
		const sf::Color& color) {
	for (uint i = 0; i < options_.size(); i++) {
		uint charSize = font_.GetCharacterSize();
		sf::String item(options_[i], font_, charSize);
		item.SetPosition(x, y + i * charSize);
		item.SetColor(color);
		if (i == selectedOption_)
			item.SetScaleX(selectedStretch_);
		window.Draw(item);
	}
}

} // namespace CastleEscape
