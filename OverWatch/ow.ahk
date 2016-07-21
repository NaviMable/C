F1::



#Persistent
#KeyHistory, 0
#NoEnv
#HotKeyInterval 1
#MaxHotkeysPerInterval 127
#InstallKeybdHook
#UseHook
#SingleInstance, Force
SetKeyDelay,-1, 8
SetControlDelay, -1
SetMouseDelay, 0
SetWinDelay,-1
SendMode, InputThenPlay
SetBatchLines,-1
ListLines, Off

CoordMode, Mouse, Screen
PID := DllCall("GetCurrentProcessId")
Process, Priority, %PID%, Normal




ZeroX := 640
ZeroY := 360
CFovX := 220
CFovY := 300

ScanL := ZeroX - CFovX
ScanR := ZeroX + CFovX
ScanT := ZeroY - CFovY
ScanB := ZeroY + CFovY

GuiControlget, rX
GuiControlget, mrX


Loop, {
Gui,Submit, Nohide

if (aimtype=1)
{

GetKeyState, Mouse2, Lbutton, P
GoSub MouseMoves
}

if (aimtype=0)
{
GetKeyState, Mouse2, Rbutton, P
GoSub MouseMoves1
}
ImageSearch, AimPixelX, AimPixelY, ScanL, ScanT, ScanR, ScanB,  *1 hhp.bmp
GoSub GetAimOffset
GoSub GetAimMoves



}

MouseMoves:
If ( Mouse2 == "D" ) {
 DllCall("mouse_event", uint, 1, int, MoveX, int, MoveY, uint, 0, int, 0)
 }
Return

MouseMoves1:
If ( Mouse2 == "U" ) {
 DllCall("mouse_event", uint, 1, int, MoveX, int, MoveY, uint, 0, int, 0)
 }
Return


GetAimOffset:

 AimX := AimPixelX - ZeroX +41
 AimY := AimPixelY - ZeroY +63


  If ( AimX+10 > 0) {
   DirX := rx / 10
  }

  If ( AimX+10 < 0) {
   DirX := (-mrx) / 10
  }

  If ( AimY+3 > 0 ) {
   DirY := rX /10 *0.8
  }

  If ( AimY+3 < 0 ) {
   DirY := (-mrx) /10 *0.8
  }

 AimOffsetX := AimX * DirX
 AimOffsetY := AimY * DirY


GetAimMoves:
 RootX := Ceil(( AimOffsetX ** ( 1 / 2)))
 RootY := Ceil(( AimOffsetY ** ( 1 / 2)))
 MoveX := RootX * DirX
 MoveY := RootY * DirY
Return



SleepF:
SleepDuration = 1
TimePeriod = 1
DllCall("Winmm\timeBeginPeriod", uint, TimePeriod)
Iterations = 1
StartTime := A_TickCount
Loop, %Iterations% {
    DllCall("Sleep", UInt, TimePeriod)
}
DllCall("Winmm\timeEndPeriod", UInt, TimePeriod)
Return



DebugTool:
MouseGetPos, MX, MY
ToolTip, %AimOffsetX% | %AimOffsetY%
ToolTip, %AimX% | %AimY%
ToolTip, %IntAimX% | %IntAimY%
ToolTip, %RootX% | %RootY%
ToolTip, %MoveX% | %MoveY% || %MX% %MY%
Return

F2::



#Persistent
#KeyHistory, 0
#NoEnv
#HotKeyInterval 1
#MaxHotkeysPerInterval 127
#InstallKeybdHook
#UseHook
#SingleInstance, Force
SetKeyDelay,-1, 8
SetControlDelay, -1
SetMouseDelay, 0
SetWinDelay,-1
SendMode, InputThenPlay
SetBatchLines,-1
ListLines, Off

CoordMode, Mouse, Screen
PID := DllCall("GetCurrentProcessId")
Process, Priority, %PID%, Normal




ZeroX := 960
ZeroY := 540
CFovX := 340
CFovY := 400

ScanL := ZeroX - CFovX
ScanR := ZeroX + CFovX
ScanT := ZeroY - CFovY
ScanB := ZeroY + CFovY

GuiControlget, rX
GuiControlget, mrX


Loop, {
Gui,Submit, Nohide

if (aimtype=1)
{

GetKeyState, Mouse2, Lbutton, P
GoSub MouseMoves2
}

if (aimtype=0)
{
GetKeyState, Mouse2, Rbutton, P
GoSub MouseMoves11
}
ImageSearch, AimPixelX, AimPixelY, ScanL, ScanT, ScanR, ScanB,  *1 hhp2.bmp
GoSub GetAimOffset1
GoSub GetAimMoves1



}

MouseMoves2:
If ( Mouse2 == "D" ) {
 DllCall("mouse_event", uint, 1, int, MoveX, int, MoveY, uint, 0, int, 0)
 }
Return

MouseMoves11:
If ( Mouse2 == "U" ) {
 DllCall("mouse_event", uint, 1, int, MoveX, int, MoveY, uint, 0, int, 0)
 }
Return




GetAimOffset1:
Gui,Submit, Nohide


 AimX := AimPixelX - ZeroX +58
 AimY := AimPixelY - ZeroY +85


  If ( AimX+18 > 0) {
   DirX := rx / 10 /1.5
  }

  If ( AimX+18 < 0) {
   DirX := (-mrx) / 10 /1.5
  }

  If ( AimY+10 > 0 ) {
   DirY := rX /10 *0.8 /1.5
  }

  If ( AimY+10 < 0 ) {
   DirY := (-mrx) /10 *0.8 /1.5
  }

 AimOffsetX := AimX * DirX
 AimOffsetY := AimY * DirY

Return


GetAimMoves1:
 RootX := Ceil(( AimOffsetX ** ( 1 / 2)))
 RootY := Ceil(( AimOffsetY ** ( 1 / 2)))
 MoveX := RootX * DirX
 MoveY := RootY * DirY
Return



SleepF1:
SleepDuration = 1
TimePeriod = 1
DllCall("Winmm\timeBeginPeriod", uint, TimePeriod)
Iterations = 1
StartTime := A_TickCount
Loop, %Iterations% {
    DllCall("Sleep", UInt, TimePeriod)
}
DllCall("Winmm\timeEndPeriod", UInt, TimePeriod)
Return



DebugTool1:
MouseGetPos, MX, MY
ToolTip, %AimOffsetX% | %AimOffsetY%
ToolTip, %AimX% | %AimY%
ToolTip, %IntAimX% | %IntAimY%
ToolTip, %RootX% | %RootY%
ToolTip, %MoveX% | %MoveY% || %MX% %MY%
Return


3::
pause
Return

F3::
Reload
return
