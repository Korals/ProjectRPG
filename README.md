# ProjectRPG
First attempt at creating a RPG game using C# and Angular

A simple RPG like game where you walk around, kill monsters, complete quests and level up.

#### **TODO:**

**Skills**
_**(All skills are available for players to use, but some have requirements to be met):**_
* [ ] _Hard coded skills (Melee, Ranged, Magic):_
* [ ] _Player picks 5 skils at creation (low level);_
* [ ] _Ability to get new skills:_
  * [ ] After boss kill;
  * [ ] After X levels (pick x extra);
  * [ ] Quest rewards;
* [ ] _Make so that skills are not the main way to fight (Cooldown, Cast time, Mana usage, Cast limit, etc.);_

**LevelUp system:**
* [ ] _Experience points:_
  * [ ] Get XP for kills;
  * [ ] Get XP for quests;
  * [ ] Xp to level 2 = 30 (Base Xp);
  * [ ] Increase by 1.15 (1.13 from level 50);
* [ ] _Skill level up:_
  * [ ] Skills level up the more you use them;
  * [ ] Skills have max level (20);
  * [ ] Max level skills do extra damage against certain enemies;
  * [ ] Need leveled up skills to get upgraded skills;

**Enemies:**
* [ ] _Figure out enemy stats (scaling with level)_
* [ ] _What skills do enemies use;_
* [ ] _Enemie item drops;_
* [ ] _What skills (Max level) do more damage against certain enemies;_
* [ ] _Add Boss monsters;_

**NPCs and Quests**
* [ ] _Add NPCs:_
  * [ ] Levels and stats;
  * [ ] Friendly;
  * [ ] Pretending to be friendly;
  * [ ] Hostile;
* [ ] _Add quests:_
  * [ ] _Kill quests:_
  * [ ] Quests to collect droped items;
  * [ ] Quests to kill **_X_** amount of monsters;
  * [ ] _Fetch quests:_
  * [ ] Kill monsters and collect items;
  * [ ] Go to a certain location and collect items;
  * [ ] "Take this 'item' and take it to 'NPC name' in 'location'" quests;
  * [ ] _Dungeon clearing quests:_
  * [ ] Kill **_X_** amount of enemies;
  * [ ] Kill the boss;
  * [ ] Collect items in dungeon;
  * [ ] _Random encounter (event) mini-quests;_

**Items:**
* [ ] _Items have quality rating:_
  * [ ] Junk => Useless random drop;
  * [ ] Quest => Only used to complete quests;
  * [ ] Common => Normal stats (2 basic);
  * [ ] Uncommon => Slightly increased stats;
  * [ ] Rare => Additional stat (extra basic);
  * [ ] Epic => Slightly increased stats + Additional stat (extra basic);
  * [ ] Legendary => Increased stats (More than before) + Increase to all Basic stats (in different proportions);
  * [ ] Relic => Have special properties, mainly dropped from high level bosses or given as a high level quest reward;
* [ ] _Player inventory:_
  * [ ] Bag slot expansions;
  * [ ] Additional bags for more slots (Maybe a Backpack item);
* [ ] _Items droped by enemies:_
  * [ ] Enemies drop everything on death;
  * [ ] Randomly get upgraded item;
