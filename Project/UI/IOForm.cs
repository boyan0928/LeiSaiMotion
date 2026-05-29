using Project.DLL;

using System;

using System.Collections.Generic;

using System.Drawing;

using System.Linq;

using System.Windows.Forms;



namespace Project.UI

{

    public partial class IOForm : Form

    {

        private const int tileWidth = 36;

        private const int labelHeight = 14;

        private const int tileHeight = 36;

        private const int margin = 3;

        private const int titleSafeOffset = 22;

        private const int panelSpacing = 1;



        private static readonly Dictionary<ushort, Dictionary<int, int>> cardOutputStates

            = new Dictionary<ushort, Dictionary<int, int>>();



        private readonly IO io = new IO();

        private readonly Dictionary<int, int> outputStates = new Dictionary<int, int>();

        private readonly Timer refreshTimer = new Timer();



        public IOForm(ushort cardNo)

        {

            io.CardNo = cardNo;

            InitializeComponent();



            refreshTimer.Interval = 100;

            refreshTimer.Tick += RefreshTimer_Tick;

            refreshTimer.Start();



            CreateInControls(48);

            CreateOutControls(32);



            Resize += (s, e) =>

            {

                SaveOutputStates();

                CreateInControls(48);

                CreateOutControls(32);

            };

        }



        private Dictionary<int, int> GetCardOutputCache()

        {

            if (!cardOutputStates.ContainsKey(io.CardNo))

                cardOutputStates[io.CardNo] = new Dictionary<int, int>();

            return cardOutputStates[io.CardNo];

        }



        private void SaveOutputStates()

        {

            outputStates.Clear();

            Dictionary<int, int> cache = GetCardOutputCache();



            foreach (Button btn in groupBox2.Controls.OfType<Button>())

            {

                if (!btn.Name.StartsWith("Out_")) continue;

                string suffix = btn.Name.Substring(4);

                int idx;

                if (!int.TryParse(suffix, out idx)) continue;



                int state = GetButtonUiState(btn);

                outputStates[idx] = state;

                cache[idx] = state;

            }

        }



        private static int GetButtonUiState(Button btn)

        {

            return btn.Tag is int ? (int)btn.Tag : 0;

        }



        private int ReadOutputStateFromHardware(int displayIndex)

        {

            try

            {
                int hw = IODLL.ReadOutput(io.CardNo, displayIndex);

                return IODLL.HardwareToUiState(hw);

            }

            catch

            {

                return -1;

            }

        }



        private int GetOutputState(int displayIndex)

        {

            if (outputStates.ContainsKey(displayIndex))

                return outputStates[displayIndex];



            Dictionary<int, int> cache = GetCardOutputCache();

            if (cache.ContainsKey(displayIndex))

                return cache[displayIndex];



            int hwState = ReadOutputStateFromHardware(displayIndex);

            if (hwState >= 0)

            {

                cache[displayIndex] = hwState;

                return hwState;

            }



            return 0;

        }



        private void RefreshTimer_Tick(object sender, EventArgs e)

        {

            RefreshInputs();

            RefreshOutputs();

        }



        private void RefreshInputs()

        {

            foreach (Panel item in groupBox1.Controls.OfType<Panel>())

            {

                if (!item.Name.StartsWith("IN_Panel_")) continue;



                string suffix = item.Name.Substring(9);

                int idx;

                if (!int.TryParse(suffix, out idx)) continue;



                PictureBox pb = item.Controls.OfType<PictureBox>().FirstOrDefault();

                if (pb == null) continue;



                try

                {
                    int val = IODLL.ReadInput(io.CardNo, idx);

                    Image img = val == 0 ? Properties.Resources.io1 : Properties.Resources.io;

                    if (pb.Image != img)

                        pb.Image = img;

                }

                catch

                {

                }

            }

        }



        private void RefreshOutputs()

        {

            Dictionary<int, int> cache = GetCardOutputCache();



            foreach (Button btn in groupBox2.Controls.OfType<Button>())

            {

                if (!btn.Name.StartsWith("Out_")) continue;



                string suffix = btn.Name.Substring(4);

                int idx;

                if (!int.TryParse(suffix, out idx)) continue;



                int hwState = ReadOutputStateFromHardware(idx);

                if (hwState < 0) continue;



                cache[idx] = hwState;

                if (GetButtonUiState(btn) == hwState) continue;



                btn.Tag = hwState;

                try

                {

                    btn.Image = hwState == 1 ? Properties.Resources.io1 : Properties.Resources.io;

                }

                catch

                {

                }

            }

        }



        private void CreateInControls(int count)

        {

            if (count <= 0) return;



            var toRemove = groupBox1.Controls.OfType<Control>()

                .Where(c => c.Name != null && c.Name.StartsWith("IN_Panel_")).ToList();

            foreach (var c in toRemove) groupBox1.Controls.Remove(c);



            int usableWidth = Math.Max(1, groupBox1.ClientSize.Width - margin * 2);

            int cols = Math.Max(1, usableWidth / (tileWidth + margin));

            int totalWidth = cols * tileWidth + (cols - 1) * margin;

            int startX = (groupBox1.ClientSize.Width - totalWidth) / 2;

            startX = Math.Max(margin, startX);



            for (int i = 0; i < count; i++)

            {

                int col = i % cols;

                int row = i / cols;

                int x = startX + col * (tileWidth + margin);

                int y = titleSafeOffset + row * (tileHeight + labelHeight + margin);



                Panel item = new Panel();

                item.Name = "IN_Panel_" + i;

                item.Size = new Size(tileWidth, labelHeight + tileHeight + panelSpacing);

                item.Location = new Point(x, y);



                Label lbl = new Label();

                lbl.Name = "IN_Label_" + i;

                lbl.Text = "IN-" + i;

                lbl.AutoSize = false;

                lbl.TextAlign = ContentAlignment.MiddleCenter;

                lbl.Size = new Size(tileWidth, labelHeight);

                lbl.Location = new Point(0, 0);

                lbl.Font = new Font(lbl.Font.FontFamily, 6.75f);



                PictureBox pb = new PictureBox();

                pb.Name = "IN_Picture_" + i;

                pb.Size = new Size(tileWidth, tileHeight);

                pb.Location = new Point(0, labelHeight + panelSpacing);

                pb.SizeMode = PictureBoxSizeMode.Zoom;

                try

                {

                    pb.Image = Properties.Resources.io;

                }

                catch

                {

                    pb.BackColor = Color.LightGray;

                }



                item.Controls.Add(lbl);

                item.Controls.Add(pb);

                groupBox1.Controls.Add(item);

            }

        }



        private void CreateOutControls(int count)

        {

            if (count <= 0) return;



            var toRemove = groupBox2.Controls.OfType<Control>()

                .Where(c => c.Name != null && c.Name.StartsWith("Out_")).ToList();

            foreach (var c in toRemove) groupBox2.Controls.Remove(c);



            int btnWidth = 70;

            int usableWidth = Math.Max(1, groupBox2.ClientSize.Width - margin * 2);

            int cols = Math.Max(1, usableWidth / (btnWidth + margin));

            int rows = (count + cols - 1) / cols;

            int availableHeight = groupBox2.ClientSize.Height - titleSafeOffset - margin;

            int spacing = 4;

            int btnHeight = (availableHeight - (rows - 1) * spacing) / rows;

            btnHeight = Math.Max(30, Math.Min(40, btnHeight));



            int totalWidth = cols * btnWidth + (cols - 1) * margin;

            int startX = (groupBox2.ClientSize.Width - totalWidth) / 2;

            startX = Math.Max(margin, startX);



            for (int i = 0; i < count; i++)

            {

                int col = i % cols;

                int row = i / cols;

                int x = startX + col * (btnWidth + margin);

                int y = titleSafeOffset + row * (btnHeight + spacing);



                int state = GetOutputState(i);



                Button btn = new Button();

                btn.Name = "Out_" + i;

                btn.Size = new Size(btnWidth, btnHeight);

                btn.Location = new Point(x, y);

                btn.Text = "Out-" + i;

                btn.TextAlign = ContentAlignment.MiddleCenter;

                btn.ImageAlign = ContentAlignment.MiddleLeft;

                btn.TextImageRelation = TextImageRelation.ImageBeforeText;

                btn.Font = new Font(btn.Font.FontFamily, 7);

                btn.UseVisualStyleBackColor = false;

                btn.BackColor = Color.White;

                btn.Tag = state;



                try

                {

                    btn.Image = state == 1 ? Properties.Resources.io1 : Properties.Resources.io;

                }

                catch

                {

                    btn.BackColor = Color.LightGray;

                }



                btn.Click += OutButton_Click;



                groupBox2.Controls.Add(btn);

            }

        }



        private void OutButton_Click(object sender, EventArgs e)

        {

            Button b = sender as Button;

            if (b == null) return;



            string suffix = b.Name.Substring(4);

            int outNo;

            if (!int.TryParse(suffix, out outNo)) return;



            int state = GetButtonUiState(b);

            Dictionary<int, int> cache = GetCardOutputCache();



            try

            {

                if (state == 0)

                {
                    ////////
                    IODLL.WriteOutput(io.CardNo, outNo, 0);

                    b.Image = Properties.Resources.io1;

                    b.Tag = 1;

                }

                else

                {
                    /////////
                    IODLL.WriteOutput(io.CardNo, outNo, 1);

                    b.Image = Properties.Resources.io;

                    b.Tag = 0;

                }



                int newState = GetButtonUiState(b);

                outputStates[outNo] = newState;

                cache[outNo] = newState;

            }

            catch (Exception ex)

            {

                MessageBox.Show("输出控制失败：" + ex.Message);

            }

        }



        protected override void OnFormClosing(FormClosingEventArgs e)

        {

            SaveOutputStates();

            refreshTimer.Stop();

            refreshTimer.Dispose();

            base.OnFormClosing(e);

        }

    }

}


