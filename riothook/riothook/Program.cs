using riothook.renderer;
using riothook.game.entities;
using riothook.game.viewmatrix;
using riothook.game.window;
using Swed32;
using System.Runtime.InteropServices;
using riothook.hacks;
using riothook.game.offsets;
using System.Numerics;
using riothook;

Swed memory = new Swed("ac_client");
IntPtr game = memory.GetModuleBase(".exe");

Renderer renderer = new Renderer();
renderer.Start().Wait();

[DllImport("User32.dll")]
static extern bool GetAsyncKeyState(int key);

if (game != IntPtr.Zero)
{
    entities.memory = memory;
    entities.game = game;

    while (true)
    {
        window.GetWindowRect(memory.GetProcess().MainWindowHandle);

        entities.updateEntities();
        entities.updateLocalplayer();

        readmtx._readmtx(memory,game);

        if (GetAsyncKeyState(0x2D))
        {
            renderer.open = !renderer.open;
            Thread.Sleep(100);
        }

        if (GetAsyncKeyState(globals.aimbotkey) && globals.aimbot)
        {
            aimbot._aimbot(memory, game);
        }
    }
}
else
{
    Console.WriteLine("Game not found");
}