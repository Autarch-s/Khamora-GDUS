using Khamora_GDUS.osint;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Khamora_GDUS
{
    public partial class General : Form
    {
        public General()
        {
            InitializeComponent();
        }
        private Functions functions;
        public delegate void Callback(ListBox g, object oo);
        public static string KhamoraPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Khamora");
        public static string FilesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Khamora\\Files");
        public string GDUSFilesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Khamora\\Files\\GDUS");

        private void General_Load(object sender, EventArgs e)
        {
            KeepAlive.Start();
            this.functions = new Functions();
            if (!Directory.Exists(KhamoraPath)) { Directory.CreateDirectory(KhamoraPath); }
            if (!Directory.Exists(FilesPath)) { Directory.CreateDirectory(FilesPath); }
            if (!Directory.Exists(GDUSFilesPath)) { Directory.CreateDirectory(GDUSFilesPath); }
        }
        public class WorkerArgs
        {
            public string username;
            public string query;
            public ListBox box;
        }
        public void AddToListBox(ListBox g, object oo)
        {
            if (!this.InvokeRequired)
            {
                if (string.IsNullOrEmpty(Conversions.ToString(oo)))
                    return;
                g.Items.Add(RuntimeHelpers.GetObjectValue(oo));
            }
            else
                this.Invoke((Delegate)new Callback(AddToListBox), (object)g, oo);
        }

        public class ConsoleLog
        {
            public static void Log(string s) => LogInfo = LogInfo + s + "\n";
            public static string LogInfo = "";

        }
        public List<string> myLines = new List<string>();

        private void GoogleWorkerv2_DoWork(object sender, DoWorkEventArgs e)
        {
            string pageSource = functions.GetPageSource("http://www.google.com/search?num=10000&q=\"" + UsernameBoxv2.Text + "\"");
            try
            {
                IEnumerator enumerator = new Regex("url\\?q=(.*?)&").Matches(pageSource).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    string str = Conversions.ToString(NewLateBinding.LateGet(NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(enumerator.Current), (System.Type)null, "groups", new object[1]
                    {
            (object) 1
                    }, (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Value", new object[0], (string[])null, (System.Type[])null, (bool[])null));
                    if (str.Contains($"instagram.com/")) { ConsoleLog.Log($"[+] Instagram | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"twitter.com/")) { ConsoleLog.Log($"[+] Twitter | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"reddit.com/user/")) { ConsoleLog.Log($"[+] Reddit | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"facebook.com/")) { ConsoleLog.Log($"[+] Facebook | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"wordpress.com")) { ConsoleLog.Log($"[+] Wordpress | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"youtube.com/")) { ConsoleLog.Log($"[+] Youtube | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"pinterest.com/")) { ConsoleLog.Log($"[+] Pinterest | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"github.com/")) { ConsoleLog.Log($"[+] Github | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"tumblr.com")) { ConsoleLog.Log($"[+] Tumblr | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"flickr.com/people/")) { ConsoleLog.Log($"[+] Flickr | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"plus.google.com/")) { ConsoleLog.Log($"[+] GooglePlus | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"blogspot.com")) { ConsoleLog.Log($"[+] Blogspot | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"steamcommunity.com/id/")) { ConsoleLog.Log($"[+] Steam | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"vimeo.com/")) { ConsoleLog.Log($"[+] Vimeo | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"soundcloud.com/")) { ConsoleLog.Log($"[+] Soundcloud | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"disqus.com/")) { ConsoleLog.Log($"[+] Disqus | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"medium.com/@")) { ConsoleLog.Log($"[+] Medium | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"deviantart.com")) { ConsoleLog.Log($"[+] DeviantArt | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"vk.com/")) { ConsoleLog.Log($"[+] VK | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"about.me/")) { ConsoleLog.Log($"[+] About.me | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"imgur.com/user/")) { ConsoleLog.Log($"[+] Imgur | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"flipboard.com/@")) { ConsoleLog.Log($"[+] Flipboard | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"slideshare.net/")) { ConsoleLog.Log($"[+] Slideshare | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"fotolog.com/")) { ConsoleLog.Log($"[+] Fotolog | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"open.spotify.com/user/")) { ConsoleLog.Log($"[+] Spotify | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"mixcloud.com/")) { ConsoleLog.Log($"[+] Mixcloud | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"scribd.com/")) { ConsoleLog.Log($"[+] Scribd | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"badoo.com/en/")) { ConsoleLog.Log($"[+] Badoo | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"patreon.com/")) { ConsoleLog.Log($"[+] Patreon | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"bitbucket.org/")) { ConsoleLog.Log($"[+] BitBucket | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"dailymotion.com/")) { ConsoleLog.Log($"[+] DailyMotion | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"etsy.com/shop/")) { ConsoleLog.Log($"[+] Etst | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"cash.me/")) { ConsoleLog.Log($"[+] Cash.me | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"behance.net/")) { ConsoleLog.Log($"[+] Behance | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"goodreads.com/")) { ConsoleLog.Log($"[+] Goodreads | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"instructables.com/member/")) { ConsoleLog.Log($"[+] Instructables | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"keybase.io/")) { ConsoleLog.Log($"[+] Keybase | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"kongregate.com/members/")) { ConsoleLog.Log($"[+] Kongregate | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"livejournal.com/")) { ConsoleLog.Log($"[+] Livejournal | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"angel.co/")) { ConsoleLog.Log($"[+] Angel.co | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"last.fm/user/")) { ConsoleLog.Log($"[+] last.fm | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"dribbble.com/")) { ConsoleLog.Log($"[+] Dribbble | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"codeacademy.com/")) { ConsoleLog.Log($"[+] Codeacademy | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"gravatar.com/")) { ConsoleLog.Log($"[+] Gravatar | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"pastebin.com/u/")) { ConsoleLog.Log($"[+] Pastebin | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"foursquare.com/")) { ConsoleLog.Log($"[+] Reddit | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"roblox.com/user.aspx?username=")) { ConsoleLog.Log($"[+] Roblox | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"gumroad.com/")) { ConsoleLog.Log($"[+] Gumroad | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"user.newgrounds.com")) { ConsoleLog.Log($"[+] Newgrounds | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"wattpad.com/user/")) { ConsoleLog.Log($"[+] Wattpad | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"canva.com/")) { ConsoleLog.Log($"[+] Canva | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"creativemarket.com/")) { ConsoleLog.Log($"[+] CreativeMarket | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"trakt.tv/users/")) { ConsoleLog.Log($"[+] Trakt.tv | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"500px.com/")) { ConsoleLog.Log($"[+] 500px | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"buzzfeed.com/")) { ConsoleLog.Log($"[+] Buzzfeed | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"tripadvisor/members/")) { ConsoleLog.Log($"[+] Tripadvisor | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"hubpages.com")) { ConsoleLog.Log($"[+] Hubpages | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"contently.com")) { ConsoleLog.Log($"[+] Contently | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"houzz.com/user/")) { ConsoleLog.Log($"[+] Houzz | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"blip.fm/")) { ConsoleLog.Log($"[+] Blip.fm | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"wikipedia.org/wiki/user:")) { ConsoleLog.Log($"[+] Wikipedia | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"news.ycombinator.com/user?id=")) { ConsoleLog.Log($"[+] YCombinator | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"codementor.io/")) { ConsoleLog.Log($"[+] Codementor | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"reverbnation.com/")) { ConsoleLog.Log($"[+] ReverbNation | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"designspiration.com/")) { ConsoleLog.Log($"[+] Designspiration | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"bandcamp.com/")) { ConsoleLog.Log($"[+] Bandcamp | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"colourlovers.com/lovers/")) { ConsoleLog.Log($"[+] Colourlovors | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"ifttt.com/u/")) { ConsoleLog.Log($"[+] Ifttt | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"ebay.com/usr/")) { ConsoleLog.Log($"[+] Ebay | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"slack.com")) { ConsoleLog.Log($"[+] Slack | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"okcupid.com/profile/")) { ConsoleLog.Log($"[+] OKCupid | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"trip.skyscanner.com/user/")) { ConsoleLog.Log($"[+] Skyscanner | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"ello.com/")) { ConsoleLog.Log($"[+] Ello | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"tracky.com/user/")) { ConsoleLog.Log($"[+] Tracky | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"tripit.com/people/#/profile/basic-info")) { ConsoleLog.Log($"[+] Tripit | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"basecamphq.com/login")) { ConsoleLog.Log($"[+] Basecamp | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"interwebz.cc/forum/profile/")) { ConsoleLog.Log($"[+] Interwebz | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"www.guru.com/freelancers/")) { ConsoleLog.Log($"[+] Guru | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"cracked.to/")) { ConsoleLog.Log($"[+] Cracked.to | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"community.cloudflare.com/u/")) { ConsoleLog.Log($"[+] cloudflare | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"www.minecraftforum.net/members/")) { ConsoleLog.Log($"[+] minecraftforums | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"skins-minecraft.net/skins/boys/")) { ConsoleLog.Log($"[+] mcskins | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"skins-minecraft.net/skins/girls/")) { ConsoleLog.Log($"[+] mcskins | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"minecraft-statistic.net/en/player/")) { ConsoleLog.Log($"[+] minestats | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"namemc.com/profile/")) { ConsoleLog.Log($"[+] namemc | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"www.planetminecraft.com/member/")) { ConsoleLog.Log($"[+] planetminecraft | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"www.freelancer.co.ke/u/")) { ConsoleLog.Log($"[+] freelancer | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"codepen.io/")) { ConsoleLog.Log($"[+] codepen.io | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"www.identityrpg.com/community/profile/")) { ConsoleLog.Log($"[+] identityrpg | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"ffs.gg/members/")) { ConsoleLog.Log($"[+] ffs.gg | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"onetap.com/members/")) { ConsoleLog.Log($"[+] Onetap | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"crazyshit.com/profile/")) { ConsoleLog.Log($"[+] Crazyshit | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"twitch.tv/")) { ConsoleLog.Log($"[+] Twitch | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"cash.app/$")) { ConsoleLog.Log($"[+] Cashapp | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                    if (str.Contains($"paypal.me/")) { ConsoleLog.Log($"[+] Paypal | Found! | {(object)WebUtility.HtmlDecode(str)}\r\n"); }
                }
            }
            finally
            {
                MessageBox.Show($"Search Finished on Username: {UsernameBoxv2.Text}");
                //OutputBoxv2.Lines = myLines.ToArray
            }
        }

        private void GoogleWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            WorkerArgs workerArgs = (WorkerArgs)e.Argument;
            string pageSource = functions.GetPageSource("http://www.google.com/search?num=10000&q=\"" + workerArgs.query + "\"");
            try
            {
                IEnumerator enumerator = new Regex("url\\?q=(.*?)&").Matches(pageSource).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    string str = Conversions.ToString(NewLateBinding.LateGet(NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(enumerator.Current), (System.Type)null, "groups", new object[1]
                    {
            (object) 1
                    }, (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Value", new object[0], (string[])null, (System.Type[])null, (bool[])null));
                    //Console.WriteLine(str);
                    if (!str.Contains("googleusercontent") && !str.Contains("/settings/ads"))
                        AddToListBox(workerArgs.box, (object)WebUtility.HtmlDecode(str));
                }
            }
            finally
            {
                MessageBox.Show($"Search Finished on Username: {workerArgs.query}");

            }
        }

        private void SearchButtonv1_Click(object sender, EventArgs e) { OutputBoxv1.Items.Clear(); GoogleWorker.RunWorkerAsync(new WorkerArgs() { username = UsernameBoxv1.Text, query = UsernameBoxv1.Text, box = OutputBoxv1 }); }
        private void OutputBoxv1_DoubleClick(object sender, EventArgs e) => Process.Start($"{OutputBoxv1.SelectedItem.ToString()}");

        private void KeepAlive_Tick(object sender, EventArgs e)
        {
            OutputBoxv2.Text = ConsoleLog.LogInfo;
        }

        private void SearchButtonv2_Click(object sender, EventArgs e)
        {
            GoogleWorkerv2.RunWorkerAsync();
        }

        private void SaveToFileButtonv1_Click(object sender, EventArgs e)
        {
            string sPath = $"{GDUSFilesPath}\\{UsernameBoxv1.Text}.txt";
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);

            foreach (var item in OutputBoxv1.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }
            SaveFile.ToString();
            SaveFile.Close();
        }

        private void ClearOutputV2_Click(object sender, EventArgs e)
        {
            ConsoleLog.LogInfo = "";
            this.OutputBoxv2.Clear();
        }

        private void SaveToClipBoardv1_Click(object sender, EventArgs e)
        {
            string s1 = "";
            foreach (object item in OutputBoxv1.Items) s1 += item.ToString() + "\r\n";
            Clipboard.SetText(s1);
        }

        private void SaveToClipBoardv2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(OutputBoxv2.Text);
        }
        private void SaveToFileButtonv2_Click(object sender, EventArgs e) =>File.WriteAllText($"{GDUSFilesPath}\\{UsernameBoxv2.Text}.txt", OutputBoxv2.Text);

        private void ClearOutputV1_Click(object sender, EventArgs e)
        {
            OutputBoxv1.Items.Clear();
        }
    }
}
