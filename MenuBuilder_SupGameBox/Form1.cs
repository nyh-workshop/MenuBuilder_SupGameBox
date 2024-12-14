using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using Microsoft.VisualBasic.FileIO;

namespace MenuBuilder_SupGameBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initListView1();
            //addTestItemsListView1();
        }

        public System.Windows.Forms.ToolTip tt_b1 = new System.Windows.Forms.ToolTip();
        public System.Windows.Forms.ToolTip tt_b2 = new System.Windows.Forms.ToolTip();
        public System.Windows.Forms.ToolTip tt_b3 = new System.Windows.Forms.ToolTip();
        public System.Windows.Forms.ToolTip tt_b4 = new System.Windows.Forms.ToolTip();

        enum GameProperties
        {
            TITLE = 0,
            MAPPER,
            CHR_SIZE,
            PRG_SIZE,
            STRT_CHR,
            STRT_PRG,
            RESET_VECTOR,
            NES_FILE,
            ONEBUS_REGS,
            HM_VM
        }

        private void initListView1()
        {
            listView1.View = View.Details;
            listView1.MultiSelect = false;
            listView1.Columns.Add("Title", 125, HorizontalAlignment.Left);
            listView1.Columns.Add("Mapper", 75, HorizontalAlignment.Left);
            listView1.Columns.Add("CHR size", 75, HorizontalAlignment.Left);
            listView1.Columns.Add("PRG size", 75, HorizontalAlignment.Left);
            listView1.Columns.Add("Start CHR", 75, HorizontalAlignment.Left);
            listView1.Columns.Add("Start PRG", 75, HorizontalAlignment.Left);
            listView1.Columns.Add("Reset Vector", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("NES file", 300, HorizontalAlignment.Left);
            listView1.Columns.Add("OneBus Registers", 500, HorizontalAlignment.Left);
            listView1.Columns.Add("HM/VM", 75, HorizontalAlignment.Left);
        }

        static class MyGlobals
        {
            public static string buildLocation;
        }

        private void addTestItemsListView1()
        {
            var abc = new ListViewItem();
            abc.Text = "Game1";
            abc.SubItems.Add("100");
            abc.SubItems.Add("200");
            abc.SubItems.Add("300");
            listView1.Items.Add(abc);

            var ghi = new ListViewItem();
            ghi.Text = "Game2";
            ghi.SubItems.Add("200");
            ghi.SubItems.Add("300");
            ghi.SubItems.Add("400");
            listView1.Items.Add(ghi);

            var jkl = new ListViewItem();
            jkl.Text = "Game3";
            jkl.SubItems.Add("400");
            jkl.SubItems.Add("500");
            jkl.SubItems.Add("600");
            listView1.Items.Add(jkl);
        }

        // Reference: https://stackoverflow.com/questions/59398402/listview-move-item-with-up-and-down-button-net-framework
        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            ListViewItem lvi = listView1.SelectedItems[0];

            int newIndex = lvi.Index - 1;

            if (newIndex < 0 || newIndex >= listView1.Items.Count) { return; }

            listView1.Items.Remove(lvi);
            listView1.Items.Insert(newIndex, lvi);
        }

        // Reference: https://stackoverflow.com/questions/59398402/listview-move-item-with-up-and-down-button-net-framework
        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            ListViewItem lvi = listView1.SelectedItems[0];

            int newIndex = lvi.Index + 1;

            if (newIndex < 0 || newIndex >= listView1.Items.Count) { return; }

            listView1.Items.Remove(lvi);
            listView1.Items.Insert(newIndex, lvi);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            ListViewItem lvi = listView1.SelectedItems[0];

            listView1.Items.Remove(lvi);
        }

        public bool checkNESheader(byte[] aHeader)
        {
            return ((aHeader[0] == 0x4E) &&
                         (aHeader[1] == 0x45) &&
                         (aHeader[2] == 0x53) &&
                         (aHeader[3] == 0x1A));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog d0 = new OpenFileDialog();
            d0.Filter = "NES files (.nes)|*.NES";
            DialogResult d0_result = d0.ShowDialog();

            if (d0_result == DialogResult.OK) // Test result.
            {
                const int NES_HEADER_SIZE = 16;
                int PRG_size_bytes = 0;
                int CHR_size_bytes = 0;
                int mapperNumber = 0;
                byte[] headerBuffer = new byte[NES_HEADER_SIZE];
                int offset = 0;
                int resetVector = 0;
                string fileName = d0.FileName;
                string title = Path.GetFileNameWithoutExtension(d0.FileName);
                string configText16 = " ";
                int nameTableArrangement = 0;
                try
                {
                    // Process if there is NES header!
                    using (BinaryReader brStream = new BinaryReader(new FileStream(fileName, FileMode.Open)))
                    {
                        // Read the first 16 bytes of the NES header and check:
                        brStream.Read(headerBuffer, 0, NES_HEADER_SIZE);

                        if (checkNESheader(headerBuffer))
                        {
                            // Process the remaining attributes of the NES file:
                            PRG_size_bytes = headerBuffer[4] * 16384;
                            CHR_size_bytes = headerBuffer[5] * 8192;
                            nameTableArrangement = headerBuffer[6] & 0x01;
                            mapperNumber = (headerBuffer[7] & 0xf0) | ((headerBuffer[6] & 0xf0) >> 4);

                            // Put an entry into the list:
                            ListViewItem appItem = new ListViewItem();

                            // Truncate to 16 upper-case characters in the menu title:
                            title = title.ToUpper();
                            if (title.Length > 16)
                                title = title.Substring(0, 16);

                            // Get reset vector here:
                            offset = NES_HEADER_SIZE + PRG_size_bytes - 4;
                            brStream.BaseStream.Seek(offset, 0);
                            byte[] resetVectorBytes = brStream.ReadBytes(2);
                            resetVector = resetVectorBytes[0] | (resetVectorBytes[1] << 8);

                            appItem.Text = title;
                            appItem.SubItems.Add(mapperNumber.ToString());
                            appItem.SubItems.Add(CHR_size_bytes.ToString());
                            appItem.SubItems.Add(PRG_size_bytes.ToString());
                            appItem.SubItems.Add("0x00000");
                            appItem.SubItems.Add("0x00000");
                            appItem.SubItems.Add("0x" + resetVector.ToString("X4"));

                            appItem.SubItems.Add(fileName);
                            appItem.SubItems.Add(configText16);
                            appItem.SubItems.Add(Convert.ToString(nameTableArrangement));
                            listView1.Items.Add(appItem);
                        }
                        else
                        {
                            MessageBox.Show("Oops! NES file not valid!", "Error");
                            //return;
                        }
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Oops! NES file open error!", "Error");
                    return;
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form2 f2 = new Form2();

            if (f2.ShowDialog(this) == DialogResult.OK)
            {
                listView1.SelectedItems[0].Text = f2.getTitleText();
            }

            f2.Dispose();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            // Compile the final binary file!
            // 1. Fill the configuration array, and then determine the locations.
            // 2. Generate bin file from this!
            string appListH_FileName = String.Format("{0}\\appList.h", MyGlobals.buildLocation);
            string appListC_FileName = String.Format("{0}\\appList.c", MyGlobals.buildLocation);
            string apps_FileName = String.Format("{0}\\apps.bin", MyGlobals.buildLocation);

            if (!Path.Exists(MyGlobals.buildLocation))
            {
                MessageBox.Show("Oops! Build path invalid!", "Error");
                return;
            }

            try
            {
                using (var writer = new StreamWriter(appListC_FileName, false))
                {
                    writer.WriteLine("#include \"appList.h\"");
                    writer.WriteLine("");

                    writer.WriteLine("// Menu Item Properties:");
                    writer.WriteLine("// From registers $4100-$410A, $2012-$201A:");
                    writer.WriteLine("// Note: $4106.0 selects the horizontal/vertical scrolling!");
                    writer.WriteLine("// These properties are arranged in this format:");
                    writer.WriteLine("//            $2012, $2013, $2014, $2015, $2016, $2017, $2018, $201A...");
                    writer.WriteLine("// ...cont'd  $4100, $4105, $4106, $4107, $4108, $4109, $410A, $410B");

                    // Add app properties:
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        writer.WriteLine(String.Format("const unsigned char appProperties_{0}[] = {{ {1} }};", i, listView1.Items[i].SubItems[8].Text));
                    }

                    // Add the list of menu item properties:
                    writer.WriteLine("const unsigned char* menuItemProperties[] = {");
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (i == listView1.Items.Count - 1)
                            writer.WriteLine("appProperties_" + i);
                        else
                            writer.WriteLine("appProperties_" + i + ",");
                    }
                    writer.WriteLine("};");

                    writer.WriteLine("");
                    writer.WriteLine("// Reset vectors:");

                    // Then reset vectors. Needed to open NES file and locate them manually!
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        string s0 = listView1.Items[i].SubItems[(int)GameProperties.RESET_VECTOR].Text.Substring(2);
                        int resetVector = Convert.ToInt32(s0, 16);
                        string rv_h = "0x" + (resetVector >> 8).ToString("X2");
                        string rv_l = "0x" + (resetVector & 0x00ff).ToString("X2");
                        writer.WriteLine(String.Format("const unsigned char appRstVct_{0}[] = {{ {1}, {2} }};", i, rv_l, rv_h));
                    }

                    // Add list of reset vectors:
                    writer.WriteLine("const unsigned char* resetVectors[] = {");
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (i == listView1.Items.Count - 1)
                            writer.WriteLine("appRstVct_" + i);
                        else
                            writer.WriteLine("appRstVct_" + i + ",");
                    }
                    writer.WriteLine("};");

                    writer.WriteLine("");
                    writer.WriteLine("// App titles:");
                    writer.WriteLine("const char emptyTitle[] = \"                \";");

                    // Finally, app titles:
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        writer.WriteLine(String.Format("const char appTitle_{0}[] = \"{1}\";", i, listView1.Items[i].Text));
                    }

                    // Add list of app titles:
                    writer.WriteLine("const char* appTitleList[] = {");
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (i == listView1.Items.Count - 1)
                            writer.WriteLine("appTitle_" + i);
                        else
                            writer.WriteLine("appTitle_" + i + ",");
                    }
                    writer.WriteLine("};");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Oops! Error when writing to AppList.c!", "Error");
                return;
            }

            try
            {
                using (var writer = new StreamWriter(appListH_FileName, false))
                {
                    writer.WriteLine("#ifndef APPLIST_H");
                    writer.WriteLine("#define APPLIST_H");
                    writer.WriteLine("");
                    writer.WriteLine("#define TOTAL_NUM_OF_APPS " + listView1.Items.Count);
                    writer.WriteLine("");

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        writer.WriteLine(String.Format("extern const unsigned char appProperties_{0}[];", i));
                    }
                    writer.WriteLine("extern const unsigned char* menuItemProperties[TOTAL_NUM_OF_APPS];");

                    writer.WriteLine("");

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        writer.WriteLine(String.Format("extern const unsigned char appRstVct_{0}[];", i));
                    }
                    writer.WriteLine("extern const unsigned char* resetVectors[TOTAL_NUM_OF_APPS];");

                    writer.WriteLine("");

                    writer.WriteLine("extern const char emptyTitle[];");
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        writer.WriteLine(String.Format("extern const char appTitle_{0}[];", i));
                    }
                    writer.WriteLine("extern const char* appTitleList[TOTAL_NUM_OF_APPS];");

                    writer.WriteLine("");
                    writer.WriteLine("#endif");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Oops! Error when writing to AppList.h!", "Error");
                return;
            }

            try
            {
                const int NES_HEADER_SIZE = 16;

                // Maximum amount of bytes for MMC3:
                byte[] CHR_total = new byte[262144];
                byte[] PRG_total = new byte[524288];

                // Create the empty bin file here:
                using (BinaryWriter bWriteStream = new BinaryWriter(new FileStream(apps_FileName, FileMode.OpenOrCreate)))
                {
                    byte emptyByte = 0x00;

                    bWriteStream.BaseStream.Seek(0, 0);

                    // Fill with 8 megabytes minimum:
                    for (int j = 0; j < 0x7fffff; j++)
                    {
                        bWriteStream.Write(emptyByte);
                    }
                }

                // Open the NES file first and copy its CHRs and PRGs:
                // SubItems 1: Mapper number.
                // SubItems 2-3: CHR size and PRG size.
                // SubItems 4-5: startCHR and startPRG.
                // SubItem 7: NES file path.
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    int mapper = Convert.ToInt32(listView1.Items[i].SubItems[(int)GameProperties.MAPPER].Text, 10);
                    int CHRsize = Convert.ToInt32(listView1.Items[i].SubItems[(int)GameProperties.CHR_SIZE].Text, 10);
                    int PRGsize = Convert.ToInt32(listView1.Items[i].SubItems[(int)GameProperties.PRG_SIZE].Text, 10);
                    int CHR_startAddr = Convert.ToInt32(listView1.Items[i].SubItems[(int)GameProperties.STRT_CHR].Text, 16);
                    int PRG_startAddr = Convert.ToInt32(listView1.Items[i].SubItems[(int)GameProperties.STRT_PRG].Text, 16);

                    using (BinaryReader bReadStream = new BinaryReader(new FileStream(listView1.Items[i].SubItems[7].Text, FileMode.Open)))
                    {
                        bReadStream.BaseStream.Seek(NES_HEADER_SIZE, 0);
                        bReadStream.Read(PRG_total, 0, PRGsize);
                        bReadStream.BaseStream.Seek(NES_HEADER_SIZE + PRGsize, 0);
                        bReadStream.Read(CHR_total, 0, CHRsize);
                    }

                    using (BinaryWriter bWriteStream = new BinaryWriter(new FileStream(apps_FileName, FileMode.Open)))
                    {
                        bWriteStream.BaseStream.Seek(0, 0);

                        // All the apps are at after physical address 0x90000!
                        if (CHR_startAddr < 0x90000 || PRG_startAddr < 0x90000)
                        {
                            MessageBox.Show("Oops! Addresses must be 0x90000 onwards!", "Error");
                            return;
                        }

                        int CHR_relative_location = CHR_startAddr - 0x90000;
                        int PRG_relative_location = PRG_startAddr - 0x90000;

                        bWriteStream.BaseStream.Seek(0, 0);
                        bWriteStream.BaseStream.Seek(CHR_relative_location, 0);
                        bWriteStream.Write(CHR_total, 0, CHRsize);
                        bWriteStream.BaseStream.Seek(0, 0);
                        bWriteStream.BaseStream.Seek(PRG_relative_location, 0);
                        bWriteStream.Write(PRG_total, 0, PRGsize);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Oops! Error when writing to App Binary!", "Error");
                return;
            }

            MessageBox.Show("Generate file success!", "Success!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            Form3 f3 = new Form3();

            f3.setTextBox(listView1.SelectedItems[0].SubItems[(int)GameProperties.ONEBUS_REGS].Text);

            if (f3.ShowDialog(this) == DialogResult.OK)
            {
                listView1.SelectedItems[0].SubItems[(int)GameProperties.ONEBUS_REGS].Text = f3.getConfig16Text();
            }

            f3.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            Form4 f4 = new Form4();

            f4.setTextBox(listView1.SelectedItems[0].SubItems[(int)GameProperties.STRT_CHR].Text, listView1.SelectedItems[0].SubItems[(int)GameProperties.STRT_PRG].Text);

            if (f4.ShowDialog(this) == DialogResult.OK)
            {
                listView1.SelectedItems[0].SubItems[(int)GameProperties.STRT_CHR].Text = f4.getStartCHRaddr();
                listView1.SelectedItems[0].SubItems[(int)GameProperties.STRT_PRG].Text = f4.getStartPRGaddr();
            }

            f4.Dispose();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f0 = new FolderBrowserDialog();
            f0.ShowNewFolderButton = true;
            DialogResult result = f0.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = f0.SelectedPath;
                MyGlobals.buildLocation = f0.SelectedPath;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog d0 = new OpenFileDialog();
            d0.Filter = "CSV files (.csv)|*.CSV";
            DialogResult d0_result = d0.ShowDialog();

            if (d0_result == DialogResult.OK)
            {
                listView1.Items.Clear();

                // Reference: http://www.csharphelper.com/howtos/howto_use_text_field_parser.html
                string[] delimiters = { ";" };
                using (TextFieldParser parser = FileSystem.OpenTextFieldParser(d0.FileName, delimiters))
                {
                    while (!parser.EndOfData)
                    {
                        try
                        {
                            string[]? fields = parser.ReadFields();
                            string[] tempOneBusArr = fields[8].Split(", ");
                            // Get the horz/vert mirroring bit here!
                            // On VT-02 specs this is reversed!
                            // int nt_arrange = Convert.ToInt32(tempOneBusArr[10], 16);
                            int nt_arrange = 0;

                            if (Convert.ToInt32(tempOneBusArr[10], 16) == 0)
                                nt_arrange = 1;
                            else
                                nt_arrange = 0;
                            ListViewItem lvi = listView1.Items.Add(fields[0].ToString());
                            for (int i = 1; i <= 8; i++)
                            {
                                lvi.SubItems.Add(fields[i].ToString());
                            }
                            lvi.SubItems.Add(nt_arrange.ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Oops! Error opening and reading CSV!", "Error");
                            return;
                        }
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Save list of games in CSV:
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV files (.csv)|*.CSV";
            saveFileDialog1.Title = "Save CSV";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        string strEntry = String.Format("{0}; {1}; {2}; {3}; {4}; {5}; {6}; {7}; {8}",
                            listView1.Items[i].SubItems[(int)GameProperties.TITLE].Text,
                            listView1.Items[i].SubItems[(int)GameProperties.MAPPER].Text,
                            listView1.Items[i].SubItems[(int)GameProperties.CHR_SIZE].Text,
                            listView1.Items[i].SubItems[(int)GameProperties.PRG_SIZE].Text,
                            listView1.Items[i].SubItems[(int)GameProperties.STRT_CHR].Text,
                            listView1.Items[i].SubItems[(int)GameProperties.STRT_PRG].Text,
                            listView1.Items[i].SubItems[(int)GameProperties.RESET_VECTOR].Text,
                            listView1.Items[i].SubItems[(int)GameProperties.NES_FILE].Text,
                            listView1.Items[i].SubItems[(int)GameProperties.ONEBUS_REGS].Text);

                        writer.WriteLine(strEntry);
                    }
                }
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            tt_b1.SetToolTip(button1, "Move Item Up");
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            tt_b4.SetToolTip(button4, "Move Item Down");
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            tt_b2.SetToolTip(button2, "Add item");
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            tt_b3.SetToolTip(button3, "Remove item");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Todo: Auto Populate OneBus games.
            // Todo: Also PhyROM_addr must advance!
            // Supported Mapper 0 and MMC3 only!
            // This needs also a free space bitmap.
            // Subitems 4 and 5: Start CHR and  Start PRG.
            const int MAPPER_0 = 0x00;
            const int MAPPER_MMC3 = 0x04;
            
            const int BANK_8KB_SIZE_BYTES = 0x2000;
            const int TOTAL_ROM_SIZE_BYTES = 0x800000;
            //const int TOTAL_8MB_ROM_SIZE_BYTES = 0x800000;

            const int NUM_OF_BITS = TOTAL_ROM_SIZE_BYTES / BANK_8KB_SIZE_BYTES;
            int START_CUSTOMROM_ADDR = 0x90000;

            bool[] freeSpaceBitmap = new bool[NUM_OF_BITS];
            Array.Fill(freeSpaceBitmap, false);

            try
            {
                // Check no. of items!
                if (listView1.Items.Count == 0)
                {
                    throw new ApplicationException("Oops! No games in list!");
                }

                foreach (ListViewItem i in listView1.Items)
                {
                    OneBusRegisters obr = default;

                    int PRG_size = Convert.ToInt32(i.SubItems[(int)GameProperties.PRG_SIZE].Text, 10);
                    int mapper = Convert.ToInt32(i.SubItems[(int)GameProperties.MAPPER].Text, 10);
                    int HMVM = Convert.ToInt32(i.SubItems[(int)GameProperties.HM_VM].Text, 10);
                    
                    // Check Mapper 0:
                    if (mapper == MAPPER_0)
                    {
                        // PRG:
                        // Check each empty space in the free space bitmap.
                        // It must have 4-bits with false.
                        // Mapper 0: Find the nearest 64k block. If found, fill in the last 32k inside the 64k block.
                        for (int j = 0; j < NUM_OF_BITS; j += 8)
                        {
                            // Equivalent to Python's freeSpaceBitmap[j+4:j+7] ->
                            var take4bits = freeSpaceBitmap.Skip(j + 4).Take(4);

                            bool[] bitsToCompare_NotFilledSpace = new bool[4];
                            Array.Fill(bitsToCompare_NotFilledSpace, false);

                            int adjAddrAlign = 0x0000;

                            if (take4bits.SequenceEqual(bitsToCompare_NotFilledSpace))
                            {
                                // Console.WriteLine("found one empty space for PRG {0}", g[i].gameName);
                                // Console.WriteLine("physical ROM address: {0:X} - {1:X}", (j + 4) * BANK_8KB_SIZE_BYTES, (j + 8) * BANK_8KB_SIZE_BYTES);
                                
                                switch(PRG_size)
                                {
                                    // 16K games are aligned to 0xC000-0xFFFF:
                                    case 0x4000:
                                        adjAddrAlign = ((j + 4) * BANK_8KB_SIZE_BYTES) + 0x4000 + START_CUSTOMROM_ADDR;
                                        break;
                                    // 32K games are aligned to 0x8000-0xFFFF:
                                    case 0x8000:
                                        adjAddrAlign = ((j + 4) * BANK_8KB_SIZE_BYTES) + START_CUSTOMROM_ADDR;
                                        break;
                                    default:
                                        // Todo: Raise exception here for non-standard sizes!
                                        break;
                                }
                                
                                // Fill the 4 bits and place the PRG within that address range.
                                bool[] filledSpaceBits = new bool[4];
                                Array.Fill(filledSpaceBits, true);
                                Array.Copy(filledSpaceBits, 0, freeSpaceBitmap, j + 4, 4);
                                // Set OneBus values here!
                                // After calculate stick this into the OneBus value! :D
                                i.SubItems[(int)GameProperties.STRT_PRG].Text = "0x" + (adjAddrAlign).ToString("X4");
                                CalcOneBus_PRG(ref obr, adjAddrAlign, mapper, HMVM, PRG_size);
                                break;
                            }
                        }
                        // CHR:
                        // Check each empty space in the free space bitmap.
                        // Mapper 0: Find the nearest 8k block. If found, fill in that one.
                        for (int j = 0; j < NUM_OF_BITS; j++)
                        {
                            var take1bit = freeSpaceBitmap[j];

                            if (take1bit == false)
                            {
                                // Console.WriteLine("found one empty space for CHR {0}", g[i].gameName);
                                // Console.WriteLine("physical ROM address: {0:X} - {1:X}", j * BANK_8KB_SIZE_BYTES, (j + 1) * BANK_8KB_SIZE_BYTES);
                                i.SubItems[(int)GameProperties.STRT_CHR].Text = "0x" + ((j * BANK_8KB_SIZE_BYTES) + START_CUSTOMROM_ADDR).ToString("X4");

                                freeSpaceBitmap[j] = true;
                                // Set OneBus values here!
                                CalcOneBus_CHR(ref obr, (j * BANK_8KB_SIZE_BYTES) + START_CUSTOMROM_ADDR, mapper);
                                break;
                            }
                        }

                        i.SubItems[(int)GameProperties.ONEBUS_REGS].Text = obr.ToString();
                    }
                    else
                    {
                        throw new ApplicationException("Mapper 0 games only supported!");
                    }
                }
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops! Error populating list!", "Error");
                return;
            };

        }

        public struct OneBusRegisters
        {
            public OneBusRegisters()
            {
                R2012 = 0;
                R2013 = 0;
                R2014 = 0;
                R2015 = 0;
                R2016 = 0;
                R2017 = 0;
                R2018 = 0;
                R201A = 0;
                R4100 = 0;
                R4105 = 0;
                R4106 = 0;
                R4107 = 0;
                R4108 = 0;
                R4109 = 0;
                R410A = 0;
                R410B = 0;
            }

            public int R2012 { set; get; }
            public int R2013 { set; get; }
            public int R2014 { set; get; }
            public int R2015 { set; get; }
            public int R2016 { set; get; }
            public int R2017 { set; get; }
            public int R2018 { set; get; }
            public int R201A { set; get; }
            public int R4100 { set; get; }
            public int R4105 { set; get; }
            public int R4106 { set; get; }
            public int R4107 { set; get; }
            public int R4108 { set; get; }
            public int R4109 { set; get; }
            public int R410A { set; get; }
            public int R410B { set; get; }

            public override readonly string ToString()
            {
                string rtnStr_2000 = String.Format("0x{0:X2}, 0x{1:X2}, 0x{2:X2}, 0x{3:X2}, 0x{4:X2}, 0x{5:X2}, 0x{6:X2}, 0x{7:X2}, ", R2012, R2013, R2014, R2015, R2016, R2017, R2018, R201A);
                string rtnStr_4000 = String.Format("0x{0:X2}, 0x{1:X2}, 0x{2:X2}, 0x{3:X2}, 0x{4:X2}, 0x{5:X2}, 0x{6:X2}, 0x{7:X2}", R4100, R4105, R4106, R4107, R4108, R4109, R410A, R410B);
                return rtnStr_2000 + rtnStr_4000;
            }
        }

        private static void CalcOneBus_PRG(ref OneBusRegisters a_Obr, int phyROM_Addr, int mapper, int a_HMVM, int aPRGsize)
        {
            // Mapper 0 covers 64KB at PRG.
            // All the banks started at 0x8000.
            if (mapper == 0x00)
            {
                a_Obr.R4100 = (phyROM_Addr / 0x200000) << 4;
                a_Obr.R410A = (phyROM_Addr & 0x1F0000) >> 13;
                if ((a_HMVM & 0x1) == 0)
                    a_Obr.R4106 |= 0x01;
                else
                    a_Obr.R4106 &= ~0x01;
                a_Obr.R4107 = 0x4;
                a_Obr.R4108 = 0x5;
                switch (aPRGsize)
                {
                    // 16k PRG:
                    case 0x4000:
                        a_Obr.R410A += 0x06;
                        a_Obr.R410B = 0x05;
                        break;
                    // 32k PRG:
                    case 0x8000:
                        a_Obr.R410A += 0x04;
                        a_Obr.R410B = 0x04;
                        break;
                    default:
                        // Todo: Raise exception here for non-standard sizes!
                        break;
                }                
            }
        }
        private static void CalcOneBus_CHR(ref OneBusRegisters a_Obr, int phyROM_Addr, int mapper)
        {
            if (mapper == 0x00)
            {
                a_Obr.R2018 = ((phyROM_Addr % 0x200000) / 0x40000) << 4;

                int upperNibble_2012_2017 = ((phyROM_Addr % 0x200000) % 0x40000) / 0x4000;
                int lowerNibble_2012_2017 = ((phyROM_Addr % 0x200000) % 0x40000) % 0x4000;

                if (lowerNibble_2012_2017 > 0)
                {
                    a_Obr.R2012 = 0x0c | (upperNibble_2012_2017 << 4);
                    a_Obr.R2013 = 0x0d | (upperNibble_2012_2017 << 4);
                    a_Obr.R2014 = 0x0e | (upperNibble_2012_2017 << 4);
                    a_Obr.R2015 = 0x0f | (upperNibble_2012_2017 << 4);
                    a_Obr.R2016 = 0x08 | (upperNibble_2012_2017 << 4);
                    a_Obr.R2017 = 0x0a | (upperNibble_2012_2017 << 4);
                }
                else
                {
                    a_Obr.R2012 = 0x04 | (upperNibble_2012_2017 << 4);
                    a_Obr.R2013 = 0x05 | (upperNibble_2012_2017 << 4);
                    a_Obr.R2014 = 0x06 | (upperNibble_2012_2017 << 4);
                    a_Obr.R2015 = 0x07 | (upperNibble_2012_2017 << 4);
                    a_Obr.R2016 = 0x00 | (upperNibble_2012_2017 << 4);
                    a_Obr.R2017 = 0x02 | (upperNibble_2012_2017 << 4);
                }
            }
        }
    }
}
