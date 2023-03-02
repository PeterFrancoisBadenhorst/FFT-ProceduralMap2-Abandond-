# Method Name
FindChunkType

# Description
Determines the ChunkType of a GameObject based on the types of its neighboring GameObjects.

# Parameters
chunk (NeighborStruct): A NeighborStruct object representing the neighboring GameObjects of the current GameObject.
Returns
A DirectionTypeEnum value representing the ChunkType of the current GameObject.

# Example Usage
```C#
Copy code
GameObject currentChunk = // get current GameObject
NeighborStruct neighborStruct = currentChunk.GetComponent<ChunkBehavior>().neighborStruct;
DirectionTypeEnum chunkType = FindChunkType(neighborStruct);
```
# Implementation Details
Check if the "Direction" field of the input "chunk" is not "Collapsed" or "Blank".
If it is not "Collapsed" or "Blank", create an empty string variable called "result".
Check each neighbor of the input "chunk" and append a character representing the neighbor's direction to the "result" string if it exists.
If the NorthNeighbor exists, append "N".
If the EastNeighbor exists, append "E".
If the SouthNeighbor exists, append "S".
If the WestNeighbor exists, append "W".
If the TopNeighbor exists, append "T".
If the BottomNeighbor exists, append "B".
Use the "Enum.Parse" method to convert the "result" string to a DirectionTypeEnum value.
If the "Direction" field of the input "chunk" is "Error", return "Error".
Otherwise, return the "Direction" field of the input "chunk".
Note: The DirectionTypeEnum enumeration type is not defined in this code snippet. It is assumed to be defined elsewhere.