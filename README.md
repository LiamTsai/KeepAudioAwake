# KeepAudioAwake

A tiny Windows tray app that plays continuous digital silence, so your audio output never goes idle.

[繁體中文說明](#繁體中文)

## The problem

When audio goes to a monitor or TV over HDMI / DisplayPort (or to some USB / Bluetooth devices), the output goes idle after a short silence. When a new sound starts, the device needs 1–3 seconds to wake up again, so:

- the first seconds of a YouTube video or a game are missing
- short notification sounds are not heard at all

## How it works

KeepAudioAwake loops a buffer of pure digital silence (all zeros, 48 kHz / 16-bit stereo) on the default playback device. The stream is never idle, so the device stays awake. It does not change any system setting; quit the app and everything is back to normal.

## Usage

1. Download `KeepAudioAwake.exe` from [Releases](../../releases) and run it (no installation needed).
2. A dot appears in the notification area (it may be hidden under `^`):
   - 🟢 green: playing silence (ON)
   - ⚪ gray: stopped (OFF)
3. Left-click the dot to toggle. Right-click → **Exit** to quit.

It starts in the ON state. To run it at login, put a shortcut to the exe in the Startup folder (press `Win+R`, type `shell:startup`).

## Side effects

- While ON, Windows treats audio as playing and may not enter **automatic sleep**. The display still turns off as usual. Toggle it OFF when you want the PC to sleep on its own.
- Some speakers may have a faint constant hiss, because their amplifier no longer powers down.
- CPU usage is negligible.

## Build from source

Requires only Windows with .NET Framework 4.x (built in to Windows 10/11):

```powershell
.\build.ps1
```

## License

[MIT](LICENSE)

---

## 繁體中文

一個很小的 Windows 工作列程式，持續送出數位靜音，讓音訊輸出不會進入閒置。

### 解決什麼問題

聲音經 HDMI／DisplayPort 傳到螢幕或電視（或某些 USB／藍牙裝置）時，安靜一陣子輸出就會進入閒置。新的聲音開始時，裝置要 1～3 秒才能重新啟動，所以：

- YouTube 或遊戲開頭幾秒沒聲音
- 右下角通知音這種短音效完全聽不到

### 原理

在預設播放裝置上循環播放一段完全靜音（數位全零，48 kHz／16-bit 立體聲），音訊串流一直不中斷，裝置就不會閒置。不修改任何系統設定，關掉程式就恢復原狀。

### 使用方式

1. 從 [Releases](../../releases) 下載 `KeepAudioAwake.exe`，點兩下執行，不用安裝。
2. 右下角會出現一個圓點（可能收在「^」裡面）：
   - 🟢 綠色：正在送出靜音（開）
   - ⚪ 灰色：已停止（關）
3. 左鍵點一下切換開／關，右鍵 →「結束」關閉程式。

啟動時預設為開啟。想開機自動執行，把 exe 的捷徑放進「啟動」資料夾（按 `Win+R` 輸入 `shell:startup`）。

### 副作用

- 開啟時 Windows 會認為正在播放聲音，可能不會**自動睡眠**；螢幕仍會照常關閉。需要電腦自動睡眠時，切換成關閉即可。
- 少數喇叭的擴大機不再關閉，可能聽得到很輕微的底噪。
- CPU 使用量可忽略。

### 自行編譯

只需要 Windows 內建的 .NET Framework 4.x：

```powershell
.\build.ps1
```

### 授權

[MIT](LICENSE)
