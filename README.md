# 🎮 2D Top-Down RPG Game (Unity)

A 2D top-down RPG game developed using Unity, featuring player combat, enemy AI, weapon systems, and modular game architecture.

---

## 🚀 Demo

🎥 Gameplay Video: (add your video link here)  
📦 Download Build: (add Google Drive / itch.io link)

---

## 📌 Features

- 🧍 Player movement with stamina system
- ⚔️ Combat system (melee & ranged)
- 🔁 Combo attack system (Attack 1 → Attack 2)
- 👾 Enemy AI (chasing, attacking, taking damage)
- 🏹 Multiple weapons:
  - Sword (melee)
  - Bow (projectile)
  - Staff (magic)
- 💥 VFX system (hit effects, death effects)
- 🎒 Inventory & weapon switching
- 🧠 Modular architecture (Core / Gameplay / Systems)

---

## 🏗️ Project Structure
Assets/
├── Animations/
├── Materials/
├── Prefabs/
├── Scenes/
├── ScriptableObjects/
├── Scripts/
│ ├── Core/
│ ├── Gameplay/
│ │ ├── Player/
│ │ ├── Enemies/
│ │ ├── Weapons/
│ │ ├── Combat/
│ │ ├── Pickup/
│ ├── UI/
│ ├── Systems/
├── Sprites/
├── Tilemap/



---

## 🧠 Architecture Overview

The project follows a modular architecture:

- **Core Layer**
  - Managers (Game, Scene, Economy)
  - Input handling
- **Gameplay Layer**
  - Player, Enemies, Weapons, Combat
- **System Layer**
  - Camera, Animation, Effects
- **Data Layer**
  - ScriptableObjects for weapon configuration

---

## 🎮 Controls

| Action        | Key |
|--------------|-----|
| Move         | WASD |
| Attack       | Left Click |
| Switch Weapon| Q / E |
| Roll / Dodge | Space |

---

## 🛠️ Technologies

- Unity (2D URP)
- C#
- Unity Input System
- ScriptableObjects
- Animator / Blend Tree

---

## ⚙️ Setup & Run

### 1. Clone project
```bash
git clone https://github.com/Tekaismyname/2dTopDownRPG.git
