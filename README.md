# MenuBuilder_SupGameBox

## *Caution: This readme is not refined yet! Some of the instructions might be unclear!*

## Custom menu builder for Sup Game Box 400-in-1. Requires actual ROM image!

![image](https://github.com/user-attachments/assets/350e7039-5fad-4bdc-9d37-e84b9135eff1)

To successfully build the menu, you need to get some knowledge on how the unit works etc: [article](https://nyh-workshop.github.io/Custom-ROM-Sup-Game-Box-400in1/).

You also need these:
- [CC65](https://cc65.github.io/) installed and path set.
- Getting this [template menu](https://github.com/nyh-workshop/CustomMenu_Sup400in1).
- The [OneBusCalc](https://github.com/nyh-workshop/OneBusCalc) to calculate the OneBus registers for the system to jump to the appropriate address.
- and finally, this app.

Directions:
- Run this menu builder app. Supply the template menu folder link into the "Build Folder".
- Add NES games (**only Mapper 0 games supported now!**) inside by pressing **Add Item**. You can move items up and down in the list!
- With your OneBusCalc, determine the start PRG and CHR addresses. Make sure it is from **0x90000 onwards** because 0x80000-0x8FFFF is the custom menu code!
- Also, with the OneBusCalc, adjust the values of these "PRG and CHR Registers" accordingly. Once you are satisfied with it, click on "Generate Code".
- From the OneBusCalc, after "Generate Code", copy and paste the bottom output **without the square brackets** into the Menu Builder's "Config OneBus" entry box.
- Finally, press "Compile". When it is successful, go to the cmd and run "make". The make will compile the menu, and combine the apps into the main binary.
- Run this output_final.bin with an emulator such as EmuVT 1.36.
