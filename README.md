# NoiseNotIncluded
An Oxygen Not Included biome noise editor and previewer.

## Development
### Remaining tasks (TODO)
- Mouse-over a preview to show a tooltip of the numeric value
- Be able to load a biome file and select the sub-biome.
- Use the elements of the biome file to render a preview on the TERMINATOR node.
- Use the elements of the biome file to render their bands and range at the bottom.
- Improve stability, fix major bugs
- Undo/Redo
- Copy/Paste
- Add Tests

### Known Bugs
- A cycle in the graph will freeze the program
- Some values are written even if they weren't included on load (using their defaults in ONI)
- Some float values get written at a very high precision (positions)
- Some float values get shifted to their internal representations (i.e. 0.8 becomes 0.800000012, 0.08 becomes 0.0799999982)
- ScaleBias doesn't appear to do anything at all

### Ideas
- Edit the biome file by drag/drop to rearrange elements in the band
- Resize the bands by mousing over the border between elements and dragging it like a slider/splitter
