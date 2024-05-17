using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImGuiNET;
using ClickableTransparentOverlay;
using System.Numerics;
using riothook.game.entities;
using riothook.hacks.esp;
using riothook.game.window;
using riothook.keys;
using System.Runtime.InteropServices;

namespace riothook.renderer
{
    public class Renderer : Overlay
    {
        ImDrawListPtr drawlist;

        public bool open = true;

        [DllImport("user32.dll")]
        static extern bool GetAsyncKeyState(int vKey);

        bool x = false;

        public static IntPtr bg;
        public static uint bgH;
        public static uint bgW;

        protected override Task PostInitialized()
        {
            ReplaceFont("C:\\Windows\\Fonts\\Arial.ttf", 14, FontGlyphRangeType.English);
            return base.PostInitialized();
        }

        protected override void Render()
        {
            Style();

            ImGui.StyleColorsClassic();
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4(0.05f, 0.05f, 0.05f, 1));
            ImGui.SetNextWindowSize(new Vector2(400, 300));

            Overlay();
            drawlist = ImGui.GetWindowDrawList();

            if (open)
            {
                ImGui.Begin("riothook - assault cube", ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoDocking);

                ImGui.BeginTabBar("0");

                if (ImGui.BeginTabItem("Aimbot"))
                {
                    ImGui.Checkbox("Aimbot", ref globals.aimbot);
                    Keybind(ref globals.aimbotkey, ref x, ref globals.aimboton);
                    ImGui.SetNextItemWidth(150);
                    ImGui.SliderFloat("Fov", ref globals.aimbotfov, 0, 300);
                    ImGui.SetNextItemWidth(150);
                    ImGui.SliderFloat("Smoothness", ref globals.aimbotsmoothness, 0f, 25f);

                    ImGui.EndTabItem();
                }

                if (ImGui.BeginTabItem("Visuals"))
                {
                    ImGui.Checkbox("ESP", ref globals.esp);

                    ImGui.Checkbox("Tracers", ref globals.tracers);
                    ImGui.SameLine();
                    ImGui.ColorEdit4("##Tracers Color", ref globals.tracersColor, ImGuiColorEditFlags.AlphaBar | ImGuiColorEditFlags.NoInputs | ImGuiColorEditFlags.AlphaPreview);

                    ImGui.Checkbox("Box", ref globals.box);
                    ImGui.SameLine();
                    ImGui.ColorEdit4("##Box Color", ref globals.boxsColor, ImGuiColorEditFlags.AlphaBar | ImGuiColorEditFlags.NoInputs | ImGuiColorEditFlags.AlphaPreview);

                    ImGui.Checkbox("Healthbar", ref globals.healthbar);
                    ImGui.SameLine();
                    ImGui.ColorEdit4("##Healthbar Color", ref globals.healthbarColor, ImGuiColorEditFlags.AlphaBar | ImGuiColorEditFlags.NoInputs | ImGuiColorEditFlags.AlphaPreview);

                    ImGui.EndTabItem();
                }

                ImGui.End();
            }

            if (entities.entitylist.ToList().Count > 0)
            {
                foreach (entity ent in entities.entitylist)
                {
                    if (globals.esp)
                    {
                        if (ent.onscreen())
                        {
                            if (globals.tracers) { esp.drawTracer(drawlist, ent); }
                            if (globals.box) { esp.drawBox(drawlist, ent); }
                            if (globals.healthbar) { esp.drawHealthbar(drawlist, ent); }
                        }
                    }
                }
            }

            ImGui.End();
        }

        private void Overlay()
        {
            ImGui.SetNextWindowSize(new Vector2(ImGui.GetIO().DisplaySize.X, ImGui.GetIO().DisplaySize.Y));
            ImGui.SetNextWindowPos(new Vector2(0, 0));
            ImGui.Begin("overlay", ImGuiWindowFlags.NoDecoration | ImGuiWindowFlags.NoBackground | ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoInputs | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse);
        }

        void Keybind(ref int bind, ref bool binding, ref bool keyOn)
        {
            var io = ImGui.GetIO();

            string bindName = Enum.GetName(typeof(_keys), bind);

            if (ImGui.Button("Bind " + bindName))
            {
                binding = !binding;
            }

            if (binding)
            {
                for (int key = 0; key < (int)_keys.Alt; key++)
                {
                    if (GetAsyncKeyState(key))
                    {
                        binding = false;
                        bind = key;
                    }
                }

                if (ImGui.IsKeyDown(ImGuiKey.Escape))
                {
                    bind = -1;
                    binding = false;
                }
            }

            if (ImGui.IsKeyDown((ImGuiKey)bind))
            {
                keyOn = true;
            }
            else
            {
                keyOn = false;
            }
        }

        public void Style()
        {
            ImGui.PushStyleVar(ImGuiStyleVar.ChildRounding, 6);
            ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 6);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowRounding, 12);
            ImGui.PushStyleVar(ImGuiStyleVar.GrabRounding, 6);
            ImGui.PushStyleVar(ImGuiStyleVar.TabRounding, 6);

            ImGui.PushStyleColor(ImGuiCol.Border, 0);
            ImGui.PushStyleVar(ImGuiStyleVar.ChildBorderSize, 0);
            ImGui.PushStyleVar(ImGuiStyleVar.FrameBorderSize, 0);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowBorderSize, 0);
            ImGui.PushStyleVar(ImGuiStyleVar.TabBarBorderSize, 0);
        }
    }
}
