#ifndef SCRIPTABLEMAP_HH
#define SCRIPTABLEMAP_HH

#include <memory>
#include <string>

#include <boost/ptr_container/ptr_vector.hpp>
#include <lua.hpp>

#include "NPE.hh"
#include "TMXMap.hh"

namespace CastleEscape {

class ScriptableMap {
public:
	enum Directions {
		North, South, East, West
	};

	ScriptableMap();
	virtual ~ScriptableMap();
	int GetMapWidth();
	int GetMapHeight();
	int GetTileSize();
	std::string GetMapName();
	//sf::Image* GetBattleBackground(); //TODO
	void LoadMap(std::string filename);
	void ReloadMap();
	bool ChangeMap(Directions direction);

protected:
	TMXMap tmxMap;
	boost::ptr_vector<NPE> NPEs;

private:
	std::string scriptFilename;
	std::string tmxMapFilename;
	std::string mapName;
	std::auto_ptr<lua_State> state;

	void parseScriptFile(std::string filename);
	void loadMapAndScript(std::string filename);

	void addNPE(NPE* npe);
};

} // namespace CastleEscape

#endif // SCRIPTABLEMAP_HH
