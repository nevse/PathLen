# PathLen

Check file path length when copying project source file to other destination.

### Usage

`PathLen -p pathToProject -r PathToNewProjectLocation -m maxPathSize -i ignoreFolders`

#### Example

`PathLen -p C:\work\MyProject\\ -r c:\projects\xxx\Production\ReadyToSend\ -m 255 -i .vs obj_netFW`

Will check resulting file paths and print all wrong paths.
