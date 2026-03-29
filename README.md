# 🎮 2D Top-Down RPG | Unity Game Project

A 2D top-down RPG game developed using Unity, featuring player combat, enemy AI, weapon systems, and modular game architecture.

---

## 🚀 Demo

### Gif Preview 

### Menu preview
<img width="1021" height="464" alt="image" src="https://github.com/user-attachments/assets/b4bec5fa-37e2-4226-bede-cb6579055acd" />

### Scene1 preview

<img width="1062" height="458" alt="image" src="https://github.com/user-attachments/assets/7728ef6e-bea1-4e67-8c5a-cd6ee552b871" />

### Boss fight

<img width="988" height="466" alt="image" src="https://github.com/user-attachments/assets/a2d83d7b-64d6-45bb-8693-443670fd37c1" />

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
Assets/ <br>
├── Animations/ <br>
├── Materials/ <br>
├── Prefabs/ <br>
├── Scenes/ <br>
├── ScriptableObjects/ <br>
├── Scripts/ <br>
│ ├── Core/ <br>
│ ├── Gameplay/ <br>
│ │ ├── Player/ <br>
│ │ ├── Enemies/ <br>
│ │ ├── Weapons/ <br>
│ │ ├── Combat/ <br>
│ │ ├── Pickup/ <br>
│ ├── UI/ <br>
│ ├── Systems/ <br>
├── Sprites/ <br>
├── Tilemap/ <br>



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
