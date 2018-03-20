using _3DNesManager.Classes;
using _3DNesManager.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DNesManager
{
    public partial class MainForm : Form
    {
        string _3dnPath;
        string romPath;
        string[] roms;
        string[] nFiles;
        string passwd;
        string login;

        Remote3DNInfo[] loadedInfos;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists("paths.cfg"))
            {
                if (!ConfigurePaths())
                {
                    Application.Exit();
                    return;
                }
                
            }

            string[] lines = File.ReadAllLines("paths.cfg");

            if (lines == null || lines.Length != 2)
            {
                if(!ConfigurePaths())
                {
                    Application.Exit();
                    return;
                }
            }

            _3dnPath = lines[0];
            romPath = lines[1];

            roms = Directory.GetFiles(romPath, "*.nes");
            nFiles = Directory.GetFiles(_3dnPath, "*.3dn");

            RefreshRoms();
        }

        private void RefreshRoms()
        {
            lstRoms.BeginUpdate();
            lstRoms.Items.Clear();

            List<RomData> toQuery = new List<RomData>();

            foreach(var rom in roms)
            {
                string romName = Path.GetFileNameWithoutExtension(rom);
                var romData = RomTools.GetRomInfo(rom);
                var dbRom = DbManager.FindRom(romData);
                var nFile = nFiles.Any(rn => romName == Path.GetFileNameWithoutExtension(rn));
                var item = lstRoms.Items.Add(romName);
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");

                item.SubItems[4].Text = romData.PRGSHA;
                item.SubItems[5].Text = romData.CHRSHA;

                item.Tag = romData.PRGSHA + "_" + (romData.CHRSHA ?? "");

                if (dbRom == null)
                {
                    item.SubItems[1].Text = "?";
                    item.SubItems[2].Text = "?";
                    toQuery.Add(romData);
                }
                else
                {
                    item.SubItems[1].Text = dbRom.Name;
                    item.SubItems[2].Text = dbRom.PAL == Pal.Yes ? "PAL" : dbRom.PAL == Pal.Unknown ? "-" : "NTSC";
                }

                if(nFile)
                    item.SubItems[3].Text = "✓";
                else
                    item.SubItems[3].Text = "✘";
            }

            lstRoms.EndUpdate();

            if (toQuery.Count > 0)
                QueryUnknownRoms(toQuery);
        }

        private async void QueryUnknownRoms(List<RomData> ToQuery)
        {
            foreach (var romData in ToQuery)
            {
                var rom = await CommTools.GetRomInfo(romData);

                if(rom != null)
                    DbManager.AddRom(rom.Id, rom.Name, romData.PRGSHA, romData.CHRSHA, rom.PAL);

                string searchTag = romData.PRGSHA + "_" + (romData.CHRSHA ?? ""); ;


                var item = lstRoms.Items.Cast<ListViewItem>().Where(i => i.Tag.ToString() == searchTag).FirstOrDefault();

                if (item == null)
                    continue;


                var pal = rom?.PAL ?? Pal.Unknown;

                item.SubItems[1].Text = rom?.Name ?? "⊗";
                item.SubItems[2].Text = pal == Pal.Yes ? "PAL" : pal == Pal.Unknown ? "⊗" : "NTSC";
            }
        }

        private bool ConfigurePaths()
        {
            using (var pathRequest = new ConfigForm())
            {
                if (pathRequest.ShowDialog() != DialogResult.OK)
                    return false;

                using (var paths = new StreamWriter("paths.cfg"))
                {
                    paths.WriteLine(pathRequest._3DNPath);
                    paths.WriteLine(pathRequest.ROMPath);
                }
            }

            return true;
        }

        private void lstRoms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRoms.SelectedItems.Count == 0)
                Clear3DNList();
            else
            {
                var item = lstRoms.SelectedItems[0];
                var prg = item.SubItems[4].Text;
                var chr = item.SubItems[5].Text;

                Load3DNFiles(prg, chr);

            }
        }

        private async Task Load3DNFiles(string Prg, string Chr)
        {

            Clear3DNList();

            loadedInfos = await CommTools.ListRomFiles(Prg, Chr);

            foreach (var info in loadedInfos)
            {
                var item = lst3DN.Items.Add(info.Name);
                item.SubItems.Add(info.Exact ? "✓" : "✘");
                item.SubItems.Add(info.Official ? "✓" : "✘");
            }

        }

        private void Clear3DNList()
        {
            lst3DN.Items.Clear();
            prop3DN.SelectedObject = null;
        }

        private void lst3DN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst3DN.SelectedIndices == null || lst3DN.SelectedIndices.Count != 1)
                prop3DN.SelectedObject = null;
            else
                prop3DN.SelectedObject = loadedInfos[lst3DN.SelectedIndices[0]];
        }
        
        private void createAccountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (RegisterForm rg = new RegisterForm())
            {
                if (rg.ShowDialog() != DialogResult.OK)
                    return;

                login = rg.LoginName;
                passwd = rg.Password;
            }
        }

        private void startSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LoginForm lg = new LoginForm())
            {
                if (lg.ShowDialog() != DialogResult.OK)
                    return;

                login = lg.LoginName;
                passwd = lg.Password;
            }
        }
    }
}
