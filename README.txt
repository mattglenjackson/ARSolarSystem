# How to set up this Repo for Git Version Control
## This is for terminal command setup if you cannot get GitHub dekstop to work.

## Setup
 - Download zip file (main branch) from repo and extract to where you want the project to be on your computer.
 - Open command terminal and change directory into extraction location (make sure you see folders called "Assets, Packages, ProjectSettings" inside the folder before continuing)

**All following commands are to be typed into windows terminal:**
 - Initialise git into the project folder by typing: `git init`  
- Set up the github remote location to the repository URL (this makes sure you push/pull to/from the right repo):
    `git remote add origin https://github.com/mattglenjackson/ARSolarSystem.git`
- Fetch all branches currently pushed to github: `git fetch origin`
- List all branches are available: `git branch -a` (this should match what is in github repo)

## Check Out Branch
- Check out an already existing branch: `git checkout <branch name>`
- Pull updates for current branch: `git pull`
## Create New Branch
- Creating a new branch of an already existing branch: 
-- Make sure you are already in existing branch you want to branch off:  `git checkout <existing branch name>`
-- pull updates to make sure it's up to date: `git pull`
- Create and switch to new branch: `git checkout -b <new branch name>`
- To verify you are on the correct branch type: `git status`
--This will display the current branch at the top of the status output.
## Make Commits and Push changes to GitHub
### It is super important to make sure you are in the correct branch before doing this.
 `git status` and swap branches if required.
- Add files to staging area: `git add .`  (this command adds all the changed files to staging area)
-- OR Specify individual files by using: `git add <file-name>`
- Make a commit: `git commit -m "Make a commit message"`

### If pushing for the first time to a new branch use:
    git push -u origin <branch name>

### else use
    git push origin <branch name>