# COAL CAR STUDIO PROGRAMMING TEST

### BRIEF

- You are tasked with creating a basic VR level editor. You have a week to deliver this test but you should spend no more than three to four hours on this. You will be evaluated on your project organization and architecture, code structure and documentation, and general completeness of the requirements.

### REQUIREMENTS

- Ability to spawn, delete, place, rotate objects
- Save and load levels from a file
- A way to locomote around the level
- VR support running at an acceptable framerate for the platform. If you do not have a VR headset, you can use the simulator for testing

### DELIVERABLE

- Link to a repository with commented code
- A build of your project with a readme explaining how to use your level editor.

# Anthony Ruffalo Programming Test Submission

### Brief

- This project was made in Unity 2021.3.3f1 with the starting point of Unity's VR template
- It was developed and tested using an Oculus Quest. In the current build, all controls are for any XR system, using the right hand. Other systems haven't been tested, but have been tested to work on the Oculus Touch controllers. Files are stored as JSONs in a folder called Saves, and 3 can be stored at a time.

### Controls

- Depending on the current state, the controls vary slightly. All will be provided here.

#### Neutral

- The standard state of the game
- Right Trigger - Spawning Mode
- Right Grip - Grab Mode
- Right Secondary - Delete
- Right Primary - Save Menu

#### Spawning Mode

- The state while spawning an object
- Right Trigger - Spawn
- Right Grip - Cycle Object

#### Grab Mode

- The state while holding an object
- Right Trigger - Place
- Right Grip - Cycle Control option

#### Save Menu

- The state while the save menu is up
- Right Trigger - Press Button

# My experience

The week since you gave me this project has been an interesting one. Between getting a bad cold and hardware issues, I ended up getting started a few days later than intented. However, that didn't kill my passion and once I got to work I wanted to make sure it was the best I could do.

Once I got a work enviorment set up, I started this project by listing out the requirments on paper. This served as a visual reminder without needing the pdf always up, and a place to jot down notes and other thoughts as the project went on. It also helped map out the plan for everything.

The first feature I worked on was the Raycaster and the LineRenderer that follows it. While the Raycaster wasn't too hard to implement and make use of throughout the project, the LineRenderer caused a few issues. From not following to being offset or becoming offset while moving, it was a hassle to get right. I felt it was an important feature to have to visualize what the player would select and where they are placing items.

Next was spawning the items. This wasn't too difficult, just upon an event you would spawn an object in the world. While in the spawn mode, you could cycle between a Cube, Sphere, and Capsule. I felt it was important to show some variety and would help make the spawner a little more modular. It also helped limit the number of buttons required as I wasn't sure the best way to use both hands and swap control between the two without a hassle.

After spawning in objects, I moved onto deleting, moving, and rotating objects. Deleting was pretty simple as it is making use of Unity's Destroy command and removing the item from the ongoing item list. Grabbing items was a little more difficult, mostly in deciding if the item should snap to the player's hand or not. However, considering I was about 6 hours in at this point, I decided to just lock the item to the hand where it is, and remove from the hand when I place it. You can also move it forward or backwards with the control stick to adjust the distance, and cycling through the options allows you to rotate the object along its axisis. You can also rotate your hand, but this gives a little bit of finer control.

Locomotion was next and initally I was going to use a form of teleportation, however it felt off and the LineRenderer was becoming very offset. I eventually settled on a basic control stick movement. I kept it slower to reduce sim sickness, however there currently isn't the ability to turn so the movement may be off from your facing direction.

Finally, I worked on saving and loading. This probably took the longest out of everything. I haven't really worked with saving and loading in Unity too much myself, and the primary way wasn't working for what I needed. After some research I found I very useful plugin on the assest store that would allow me to save a list of PrefabIndexs, positions, and rotations of object. Once I learned how to use it and read and write the data, it was pretty easy from there to convert the rest of the project to account for this and the save and load works pretty well.

# What could I improve

With some more time and resources I think I could make this better. Firstly, I would probably try and utilize some better UI. The menu follows your head a little too tightly, the text to display your current option is still pretty big and hinders your vision. I would probably want a visual (images) indicatior or selector for the object around the hands or at a space you can reach. Better UI and menus would also allow for some more functionality between saving, loading, and selecting levels, as well as expand the number of levels you can store.

I would also want to improve the locomotion. Having the movement follow your headset better would improve the playablity and having the option for teleporting would help further reduce the sim sickness.

I also would like to take more time fine tuning the moving and rotating objects to give more control and intuitiveness of the experiance, as currently if you adjust too much the axisis don't continue to line up.

I could probably go on with changes I could make with infinite time and infinite resources. However, I wanted to showcase what I could do and also talk about what I was thinking afterwards. I know this took longer than you anticipated. I went into it knowing I would be taking some extra time, but I also wanted to make sure what I was doing was right, and it worked well. Admittedly, I was probably a little bit of a perfectionist at the beginning, but I wanted to make it a success and was always thinking ahead to reduce the need to refactor later.

I thank you guys for taking the time to interview me and to offer this test so I can prove myself. I look forward to hearing from you guys soon, and if all goes well working alongside you and the team. I wish you the best of luck in this search, and have a great day.
