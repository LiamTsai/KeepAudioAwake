// KeepAudioAwake — tray icon that plays continuous digital silence so HDMI/DP audio
// (e.g. monitor speakers) never goes idle and cuts off the first seconds of sound.
// 右下角圖示：點一下切換「持續送出靜音」開／關，讓 HDMI／DP 螢幕喇叭不進入閒置。
using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

static class KeepAudioAwake
{
    static NotifyIcon tray;
    static SoundPlayer player;
    static bool on;
    static Icon iconOn, iconOff;

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        player = new SoundPlayer(SilentWav(48000, 1));
        player.Load();
        iconOn = Dot(Color.LimeGreen);
        iconOff = Dot(Color.Gray);

        var menu = new ContextMenuStrip();
        menu.Items.Add("On / Off  開／關", null, (s, e) => Toggle());
        menu.Items.Add("Exit  結束", null, (s, e) => { player.Stop(); tray.Visible = false; Application.Exit(); });

        tray = new NotifyIcon { ContextMenuStrip = menu, Visible = true };
        tray.MouseClick += (s, e) => { if (e.Button == MouseButtons.Left) Toggle(); };
        Toggle(); // 啟動後直接開啟
        Application.Run();
    }

    static void Toggle()
    {
        on = !on;
        if (on) player.PlayLooping(); else player.Stop();
        tray.Icon = on ? iconOn : iconOff;
        tray.Text = on ? "KeepAudioAwake: ON\n持續送出靜音：開" : "KeepAudioAwake: OFF\n持續送出靜音：關";
    }

    // 產生一段完全靜音（數位全零）的 16-bit 立體聲 WAV
    static MemoryStream SilentWav(int rate, int seconds)
    {
        int data = rate * 4 * seconds;
        var ms = new MemoryStream();
        var w = new BinaryWriter(ms);
        w.Write(new[] { 'R', 'I', 'F', 'F' }); w.Write(36 + data);
        w.Write(new[] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' }); w.Write(16);
        w.Write((short)1); w.Write((short)2); w.Write(rate); w.Write(rate * 4);
        w.Write((short)4); w.Write((short)16);
        w.Write(new[] { 'd', 'a', 't', 'a' }); w.Write(data);
        w.Write(new byte[data]);
        ms.Position = 0;
        return ms;
    }

    static Icon Dot(Color c)
    {
        var bmp = new Bitmap(16, 16);
        using (var g = Graphics.FromImage(bmp))
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var b = new SolidBrush(c)) g.FillEllipse(b, 2, 2, 12, 12);
        }
        return Icon.FromHandle(bmp.GetHicon());
    }
}
